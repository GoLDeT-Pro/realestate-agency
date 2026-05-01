package com.example.realestateclient.data.models

data class LoginRequest(
    val phone: String,
    val password: String? = null
)