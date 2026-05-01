package com.example.realestateclient.ui.viewmodels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.example.realestateclient.data.models.PropertyDetail
import com.example.realestateclient.data.repositories.PropertyRepository
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class PropertyDetailViewModel : ViewModel() {
    private val repo = PropertyRepository()
    private val _property = MutableLiveData<PropertyDetail>()
    val property: LiveData<PropertyDetail> = _property

    fun loadProperty(id: Int) {
        repo.getPropertyDetail(id).enqueue(object : Callback<PropertyDetail> {
            override fun onResponse(call: Call<PropertyDetail>, response: Response<PropertyDetail>) {
                if (response.isSuccessful && response.body() != null)
                    _property.postValue(response.body()!!)
            }
            override fun onFailure(call: Call<PropertyDetail>, t: Throwable) {}
        })
    }
}