package com.example.realestateclient.data.models

data class CreateViewingRequestDto(
    val clientId: Int,
    val propertyId: Int,
    val preferredDate: String,
    val preferredTime: String,
    val comment: String?
)