package com.example.realestateclient.data.repositories

import com.example.realestateclient.data.api.RetrofitClient
import com.example.realestateclient.data.models.ClientProfile
import com.example.realestateclient.data.models.LoginRequest
import com.example.realestateclient.data.models.LoginResponse
import retrofit2.Call

class AuthRepository {
    private val api = RetrofitClient.instance

    fun login(phone: String, password: String? = null): Call<LoginResponse> {
        return api.login(LoginRequest(phone, password))
    }

    fun register(profile: ClientProfile): Call<LoginResponse> {
        return api.register(profile)
    }
}