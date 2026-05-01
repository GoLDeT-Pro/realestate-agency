package com.example.realestateclient.data.models

data class Property(
    val id: Int,
    val address: String,
    val area: Double,
    val rooms: Int,
    val price: Double,
    val status: String,
    val district: String,
    val propertyType: String,
    val mainPhotoUrl: String?
)