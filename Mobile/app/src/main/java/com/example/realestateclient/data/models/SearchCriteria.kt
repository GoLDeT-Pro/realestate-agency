package com.example.realestateclient.data.models

data class SearchCriteria(
    val minPrice: Double? = null,
    val maxPrice: Double? = null,
    val minArea: Double? = null,
    val maxArea: Double? = null,
    val rooms: Int? = null,
    val districtId: Int? = null,
    val propertyTypeId: Int? = null
)