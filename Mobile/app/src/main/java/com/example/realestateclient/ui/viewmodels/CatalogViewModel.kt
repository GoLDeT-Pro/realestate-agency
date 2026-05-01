package com.example.realestateclient.ui.viewmodels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.example.realestateclient.data.models.Property
import com.example.realestateclient.data.models.SearchCriteria
import com.example.realestateclient.data.repositories.PropertyRepository
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class CatalogViewModel : ViewModel() {
    private val repo = PropertyRepository()
    private val _properties = MutableLiveData<List<Property>>()
    val properties: LiveData<List<Property>> = _properties

    fun loadProperties(criteria: SearchCriteria = SearchCriteria()) {
        repo.searchProperties(criteria).enqueue(object : Callback<List<Property>> {
            override fun onResponse(call: Call<List<Property>>, response: Response<List<Property>>) {
                if (response.isSuccessful && response.body() != null)
                    _properties.postValue(response.body()!!)
            }
            override fun onFailure(call: Call<List<Property>>, t: Throwable) {}
        })
    }
}