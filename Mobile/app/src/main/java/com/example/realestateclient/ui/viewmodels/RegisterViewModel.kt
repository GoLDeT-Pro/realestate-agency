package com.example.realestateclient.ui.viewmodels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.example.realestateclient.data.models.ClientProfile
import com.example.realestateclient.data.models.LoginResponse
import com.example.realestateclient.data.repositories.AuthRepository
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class RegisterViewModel : ViewModel() {
    private val repo = AuthRepository()
    private val _registerResult = MutableLiveData<Result<LoginResponse>>()
    val registerResult: LiveData<Result<LoginResponse>> = _registerResult

    fun register(fullName: String, phone: String, email: String) {
        val profile = ClientProfile(fullName, phone, email)
        repo.register(profile).enqueue(object : Callback<LoginResponse> {
            override fun onResponse(call: Call<LoginResponse>, response: Response<LoginResponse>) {
                if (response.isSuccessful && response.body() != null)
                    _registerResult.postValue(Result.success(response.body()!!))
                else
                    _registerResult.postValue(Result.failure(Exception("Ошибка регистрации")))
            }
            override fun onFailure(call: Call<LoginResponse>, t: Throwable) {
                _registerResult.postValue(Result.failure(t))
            }
        })
    }
}