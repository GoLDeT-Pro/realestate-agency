package com.example.realestateclient.ui.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.realestateclient.R
import com.example.realestateclient.data.models.ViewingRequest

class ViewingRequestAdapter(
    private var items: List<ViewingRequest>
) : RecyclerView.Adapter<ViewingRequestAdapter.ViewHolder>() {

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val tvAddress: TextView = view.findViewById(R.id.tvAddress)
        val tvStatus: TextView = view.findViewById(R.id.tvStatus)
        val tvDateTime: TextView = view.findViewById(R.id.tvDateTime)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.item_request, parent, false)
        return ViewHolder(view)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val req = items[position]
        holder.tvAddress.text = req.propertyAddress ?: "Объект #${req.propertyId}"
        holder.tvStatus.text = req.status ?: "Новый"
        holder.tvDateTime.text = "${req.preferredDate} ${req.preferredTime}"
    }

    override fun getItemCount() = items.size

    fun updateList(newItems: List<ViewingRequest>) {
        items = newItems
        notifyDataSetChanged()
    }
}