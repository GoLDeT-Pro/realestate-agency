package com.example.realestateclient.data.repositories

import com.example.realestateclient.data.api.RetrofitClient
import com.example.realestateclient.data.models.Property
import com.example.realestateclient.data.models.PropertyDetail
import com.example.realestateclient.data.models.SearchCriteria
import retrofit2.Call

class PropertyRepository {
    private val api = RetrofitClient.instance

    fun searchProperties(criteria: SearchCriteria): Call<List<Property>> {
        return api.getProperties(
            minPrice = criteria.minPrice,
            maxPrice = criteria.maxPrice,
            minArea = criteria.minArea,
            maxArea = criteria.maxArea,
            rooms = criteria.rooms,
            districtId = criteria.districtId,
            propertyTypeId = criteria.propertyTypeId
        )
    }

    fun getPropertyDetail(id: Int): Call<PropertyDetail> {
        return api.getPropertyDetail(id)
    }
}