package com.example.realestateclient.data.repositories

import com.example.realestateclient.data.api.RetrofitClient
import com.example.realestateclient.data.models.CreateViewingRequestDto
import com.example.realestateclient.data.models.ViewingRequest
import retrofit2.Call

class ViewingRequestRepository {
    private val api = RetrofitClient.instance

    fun createRequest(request: ViewingRequest, clientId: Int): Call<Void> {
        val dto = CreateViewingRequestDto(
            clientId = clientId,
            propertyId = request.propertyId,
            preferredDate = request.preferredDate,
            preferredTime = request.preferredTime,
            comment = request.comment
        )
        return api.createViewingRequest(dto)
    }

    fun getClientRequests(clientId: Int): Call<List<ViewingRequest>> {
        return api.getClientRequests(clientId)
    }
}