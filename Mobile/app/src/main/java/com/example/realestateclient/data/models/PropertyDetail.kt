package com.example.realestateclient.data.models

data class PropertyDetail(
    val id: Int,
    val address: String,
    val area: Double,
    val rooms: Int,
    val floor: Int?,
    val totalFloors: Int?,
    val price: Double,
    val description: String?,
    val status: String,
    val district: String,
    val propertyType: String,
    val ownerName: String,
    val ownerPhone: String,
    val photoUrls: List<String>,
    val isFavorite: Boolean,
    val mainPhotoUrl: String?
)