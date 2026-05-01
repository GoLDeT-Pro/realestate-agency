package com.example.realestateclient

import android.content.Intent
import android.os.Bundle
import android.widget.TextView
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.realestateclient.ui.adapters.PropertyAdapter
import com.example.realestateclient.ui.viewmodels.CatalogViewModel
import com.example.realestateclient.ui.viewmodels.FavoritesViewModel

class CatalogActivity : AppCompatActivity() {
    private val viewModel: CatalogViewModel by viewModels()
    private lateinit var adapter: PropertyAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_catalog)

        findViewById<TextView>(R.id.tvBack).setOnClickListener { finish() }

        val rvProperties = findViewById<RecyclerView>(R.id.rvProperties)
        rvProperties.layoutManager = LinearLayoutManager(this)

        adapter = PropertyAdapter(
            emptyList(),
            onItemClick = { property ->
                val intent = Intent(this, PropertyDetailActivity::class.java)
                intent.putExtra("property_id", property.id)
                startActivity(intent)
            },
            onFavoriteClick = { property ->
                val vm = ViewModelProvider(this).get(FavoritesViewModel::class.java)
                val clientId = getSharedPreferences("app", MODE_PRIVATE).getInt("client_id", 0)
                vm.addFavorite(clientId, property.id)
            }
        )
        rvProperties.adapter = adapter

        viewModel.properties.observe(this) { properties ->
            adapter.updateList(properties)
        }
        viewModel.loadProperties()
    }
}