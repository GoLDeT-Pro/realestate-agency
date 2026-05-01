package com.example.realestateclient.ui.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageButton
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.example.realestateclient.R
import com.example.realestateclient.data.models.Property

class PropertyAdapter(
    private var items: List<Property>,
    private val onItemClick: (Property) -> Unit,
    private val onFavoriteClick: (Property) -> Unit
) : RecyclerView.Adapter<PropertyAdapter.ViewHolder>() {

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val ivPhoto: ImageView = view.findViewById(R.id.ivPhoto)
        val tvPrice: TextView = view.findViewById(R.id.tvPrice)
        val tvAddress: TextView = view.findViewById(R.id.tvAddress)
        val tvDetails: TextView = view.findViewById(R.id.tvDetails)
        val btnFavorite: ImageButton = view.findViewById(R.id.btnFavorite)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.item_property, parent, false)
        return ViewHolder(view)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val property = items[position]
        holder.tvPrice.text = "%,.0f ₽".format(property.price)
        holder.tvAddress.text = property.address
        holder.tvDetails.text = "${property.rooms} комн. · ${property.area} м²"

        Glide.with(holder.itemView.context)
            .load(property.mainPhotoUrl)
            .placeholder(android.R.drawable.ic_menu_gallery)
            .into(holder.ivPhoto)

        holder.btnFavorite.setOnClickListener { onFavoriteClick(property) }
        holder.itemView.setOnClickListener { onItemClick(property) }
    }

    override fun getItemCount() = items.size

    fun updateList(newItems: List<Property>) {
        items = newItems
        notifyDataSetChanged()
    }
}