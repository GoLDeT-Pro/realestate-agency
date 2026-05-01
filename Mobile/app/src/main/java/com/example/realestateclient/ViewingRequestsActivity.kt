package com.example.realestateclient

import android.os.Bundle
import android.widget.TextView
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.realestateclient.ui.adapters.ViewingRequestAdapter
import com.example.realestateclient.ui.viewmodels.ViewingRequestsViewModel

class ViewingRequestsActivity : AppCompatActivity() {
    private val viewModel: ViewingRequestsViewModel by viewModels()
    private val clientId by lazy { getSharedPreferences("app", MODE_PRIVATE).getInt("client_id", 0) }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_viewing_requests)

        findViewById<TextView>(R.id.tvBack).setOnClickListener { finish() }

        val rvRequests = findViewById<RecyclerView>(R.id.rvRequests)
        rvRequests.layoutManager = LinearLayoutManager(this)

        val adapter = ViewingRequestAdapter(emptyList())
        rvRequests.adapter = adapter

        viewModel.requests.observe(this) { requests ->
            adapter.updateList(requests)
        }
        viewModel.loadRequests(clientId)
    }
}