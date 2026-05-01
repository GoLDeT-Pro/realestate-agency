package com.example.realestateclient

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.ImageView
import android.widget.TextView
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.ViewModelProvider
import com.bumptech.glide.Glide
import com.example.realestateclient.ui.viewmodels.FavoritesViewModel
import com.example.realestateclient.ui.viewmodels.PropertyDetailViewModel

class PropertyDetailActivity : AppCompatActivity() {
    private val viewModel: PropertyDetailViewModel by viewModels()
    private var propertyId: Int = 0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_property_detail)

        findViewById<TextView>(R.id.tvBack).setOnClickListener { finish() }

        propertyId = intent.getIntExtra("property_id", 0)
        viewModel.loadProperty(propertyId)

        val tvPrice = findViewById<TextView>(R.id.tvPrice)
        val tvAddress = findViewById<TextView>(R.id.tvAddress)
        val tvDistrict = findViewById<TextView>(R.id.tvDistrict)
        val tvArea = findViewById<TextView>(R.id.tvArea)
        val tvRooms = findViewById<TextView>(R.id.tvRooms)
        val tvFloor = findViewById<TextView>(R.id.tvFloor)
        val tvType = findViewById<TextView>(R.id.tvType)
        val tvDescription = findViewById<TextView>(R.id.tvDescription)
        val tvOwnerName = findViewById<TextView>(R.id.tvOwnerName)
        val tvOwnerPhone = findViewById<TextView>(R.id.tvOwnerPhone)
        val ivMainPhoto = findViewById<ImageView>(R.id.ivMainPhoto)

        viewModel.property.observe(this) { property ->
            tvPrice.text = "%,.0f ₽".format(property.price)
            tvAddress.text = property.address
            tvDistrict.text = "📍 ${property.district}"
            tvArea.text = "Площадь: ${property.area} м²"
            tvRooms.text = "Комнат: ${property.rooms}"
            tvFloor.text = "Этаж: ${property.floor ?: "?"} из ${property.totalFloors ?: "?"}"
            tvType.text = "Тип: ${property.propertyType}"
            tvDescription.text = property.description ?: ""
            tvOwnerName.text = property.ownerName
            tvOwnerPhone.text = property.ownerPhone

            Glide.with(this)
                .load(property.mainPhotoUrl)
                .placeholder(android.R.drawable.ic_menu_gallery)
                .into(ivMainPhoto)
        }

        findViewById<Button>(R.id.btnRequestViewing).setOnClickListener {
            val intent = Intent(this, CreateViewingRequestActivity::class.java)
            intent.putExtra("property_id", propertyId)
            startActivity(intent)
        }

        findViewById<Button>(R.id.btnAddToFavorites).setOnClickListener {
            val vm = ViewModelProvider(this).get(FavoritesViewModel::class.java)
            val clientId = getSharedPreferences("app", MODE_PRIVATE).getInt("client_id", 0)
            vm.addFavorite(clientId, propertyId)
            Toast.makeText(this, "Добавлено в избранное", Toast.LENGTH_SHORT).show()
        }
    }
}