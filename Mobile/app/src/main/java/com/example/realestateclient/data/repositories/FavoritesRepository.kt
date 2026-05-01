package com.example.realestateclient.data.repositories

import com.example.realestateclient.data.api.RetrofitClient
import com.example.realestateclient.data.models.Favorite
import com.example.realestateclient.data.models.FavoriteRequest
import retrofit2.Call

class FavoritesRepository {
    private val api = RetrofitClient.instance

    fun getFavorites(clientId: Int): Call<List<Favorite>> {
        return api.getFavorites(clientId)
    }

    fun addFavorite(clientId: Int, propertyId: Int): Call<Void> {
        return api.addFavorite(FavoriteRequest(clientId, propertyId))
    }

    fun removeFavorite(clientId: Int, propertyId: Int): Call<Void> {
        return api.removeFavorite(clientId, propertyId)
    }
}