package com.example.realestateclient.data.models

data class LoginResponse(
    val clientId: Int,
    val fullName: String,
    val token: String
)