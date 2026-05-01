package com.example.realestateclient.ui.viewmodels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.example.realestateclient.data.models.LoginResponse
import com.example.realestateclient.data.repositories.AuthRepository
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class LoginViewModel : ViewModel() {
    private val repo = AuthRepository()
    private val _loginResult = MutableLiveData<Result<LoginResponse>>()
    val loginResult: LiveData<Result<LoginResponse>> = _loginResult

    fun login(phone: String, password: String) {
        repo.login(phone, password).enqueue(object : Callback<LoginResponse> {
            override fun onResponse(call: Call<LoginResponse>, response: Response<LoginResponse>) {
                if (response.isSuccessful && response.body() != null)
                    _loginResult.postValue(Result.success(response.body()!!))
                else
                    _loginResult.postValue(Result.failure(Exception("Ошибка входа")))
            }
            override fun onFailure(call: Call<LoginResponse>, t: Throwable) {
                _loginResult.postValue(Result.failure(t))
            }
        })
    }
}