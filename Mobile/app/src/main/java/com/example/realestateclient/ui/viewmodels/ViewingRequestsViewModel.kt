package com.example.realestateclient.ui.viewmodels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.example.realestateclient.data.models.ViewingRequest
import com.example.realestateclient.data.repositories.ViewingRequestRepository
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class ViewingRequestsViewModel : ViewModel() {
    private val repo = ViewingRequestRepository()
    private val _requests = MutableLiveData<List<ViewingRequest>>()
    val requests: LiveData<List<ViewingRequest>> = _requests

    fun loadRequests(clientId: Int) {
        repo.getClientRequests(clientId).enqueue(object : Callback<List<ViewingRequest>> {
            override fun onResponse(call: Call<List<ViewingRequest>>, response: Response<List<ViewingRequest>>) {
                if (response.isSuccessful && response.body() != null)
                    _requests.postValue(response.body()!!)
            }
            override fun onFailure(call: Call<List<ViewingRequest>>, t: Throwable) {}
        })
    }

    fun createRequest(request: ViewingRequest, clientId: Int) {
        repo.createRequest(request, clientId).enqueue(object : Callback<Void> {
            override fun onResponse(call: Call<Void>, response: Response<Void>) {}
            override fun onFailure(call: Call<Void>, t: Throwable) {}
        })
    }
}