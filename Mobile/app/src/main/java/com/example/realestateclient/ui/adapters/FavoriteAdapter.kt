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
import com.example.realestateclient.data.models.Favorite

class FavoriteAdapter(
    private var items: List<Favorite>,
    private val onItemClick: (Favorite) -> Unit
) : RecyclerView.Adapter<FavoriteAdapter.ViewHolder>() {

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
        val fav = items[position]
        holder.tvPrice.text = "%,.0f ₽".format(fav.price)
        holder.tvAddress.text = fav.address
        holder.tvDetails.text = ""

        Glide.with(holder.itemView.context)
            .load(fav.mainPhotoUrl)
            .placeholder(android.R.drawable.ic_menu_gallery)
            .into(holder.ivPhoto)

        holder.btnFavorite.visibility = View.GONE
        holder.itemView.setOnClickListener { onItemClick(fav) }
    }

    override fun getItemCount() = items.size

    fun updateList(newItems: List<Favorite>) {
        items = newItems
        notifyDataSetChanged()
    }
}