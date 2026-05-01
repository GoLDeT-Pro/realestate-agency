package com.example.realestateclient.ui.viewmodels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.example.realestateclient.data.api.RetrofitClient
import com.example.realestateclient.data.models.ClientProfile
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class ProfileViewModel : ViewModel() {
    private val _profile = MutableLiveData<ClientProfile>()
    val profile: LiveData<ClientProfile> = _profile

    fun loadProfile(clientId: Int) {
        RetrofitClient.instance.getProfile(clientId).enqueue(object : Callback<ClientProfile> {
            override fun onResponse(call: Call<ClientProfile>, response: Response<ClientProfile>) {
                if (response.isSuccessful && response.body() != null)
                    _profile.postValue(response.body()!!)
            }
            override fun onFailure(call: Call<ClientProfile>, t: Throwable) {}
        })
    }

    fun updateProfile(clientId: Int, profile: ClientProfile) {
        RetrofitClient.instance.updateProfile(clientId, profile).enqueue(object : Callback<Void> {
            override fun onResponse(call: Call<Void>, response: Response<Void>) {}
            override fun onFailure(call: Call<Void>, t: Throwable) {}
        })
    }
}