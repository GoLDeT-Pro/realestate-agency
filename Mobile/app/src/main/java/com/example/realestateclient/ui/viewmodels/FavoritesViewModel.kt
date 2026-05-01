package com.example.realestateclient.ui.viewmodels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.example.realestateclient.data.models.Favorite
import com.example.realestateclient.data.repositories.FavoritesRepository
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class FavoritesViewModel : ViewModel() {
    private val repo = FavoritesRepository()
    private val _favorites = MutableLiveData<List<Favorite>>()
    val favorites: LiveData<List<Favorite>> = _favorites

    fun loadFavorites(clientId: Int) {
        repo.getFavorites(clientId).enqueue(object : Callback<List<Favorite>> {
            override fun onResponse(call: Call<List<Favorite>>, response: Response<List<Favorite>>) {
                if (response.isSuccessful && response.body() != null)
                    _favorites.postValue(response.body()!!)
            }
            override fun onFailure(call: Call<List<Favorite>>, t: Throwable) {}
        })
    }

    fun addFavorite(clientId: Int, propertyId: Int) {
        repo.addFavorite(clientId, propertyId).enqueue(object : Callback<Void> {
            override fun onResponse(call: Call<Void>, response: Response<Void>) {
                loadFavorites(clientId) // обновить список
            }
            override fun onFailure(call: Call<Void>, t: Throwable) {}
        })
    }

    fun removeFavorite(clientId: Int, propertyId: Int) {
        repo.removeFavorite(clientId, propertyId).enqueue(object : Callback<Void> {
            override fun onResponse(call: Call<Void>, response: Response<Void>) {
                loadFavorites(clientId)
            }
            override fun onFailure(call: Call<Void>, t: Throwable) {}
        })
    }
}