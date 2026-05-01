package com.example.realestateclient

import android.content.Intent
import android.os.Bundle
import android.widget.TextView
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.realestateclient.ui.adapters.FavoriteAdapter
import com.example.realestateclient.ui.viewmodels.FavoritesViewModel

class FavoritesActivity : AppCompatActivity() {
    private val viewModel: FavoritesViewModel by viewModels()
    private lateinit var adapter: FavoriteAdapter
    private val clientId by lazy { getSharedPreferences("app", MODE_PRIVATE).getInt("client_id", 0) }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_favorites)

        findViewById<TextView>(R.id.tvBack).setOnClickListener { finish() }

        val rvFavorites = findViewById<RecyclerView>(R.id.rvFavorites)
        rvFavorites.layoutManager = LinearLayoutManager(this)

        adapter = FavoriteAdapter(emptyList()) { favorite ->
            val intent = Intent(this, PropertyDetailActivity::class.java)
            intent.putExtra("property_id", favorite.propertyId)
            startActivity(intent)
        }
        rvFavorites.adapter = adapter

        viewModel.favorites.observe(this) { favorites ->
            adapter.updateList(favorites)
        }
        viewModel.loadFavorites(clientId)
    }
}