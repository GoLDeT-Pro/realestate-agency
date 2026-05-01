package com.example.realestateclient.data.models

data class Favorite(
    val propertyId: Int,
    val address: String,
    val price: Double,
    val mainPhotoUrl: String?
)