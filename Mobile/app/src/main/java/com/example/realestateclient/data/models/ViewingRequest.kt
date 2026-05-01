package com.example.realestateclient.data.models

data class ViewingRequest(
    val id: Int = 0,
    val propertyId: Int,
    val preferredDate: String,
    val preferredTime: String,
    val comment: String?,
    val status: String? = null,
    val propertyAddress: String? = null
)