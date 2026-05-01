package com.example.realestateclient

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import com.example.realestateclient.ui.viewmodels.LoginViewModel

class LoginActivity : AppCompatActivity() {
    private val viewModel: LoginViewModel by viewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        val etPhone = findViewById<EditText>(R.id.etPhone)
        findViewById<Button>(R.id.btnLogin).setOnClickListener {
            viewModel.login(etPhone.text.toString().trim(), "")
        }
        findViewById<TextView>(R.id.tvRegister).setOnClickListener {
            startActivity(Intent(this, RegisterActivity::class.java))
        }

        viewModel.loginResult.observe(this) { result ->
            result.onSuccess { response ->
                getSharedPreferences("app", MODE_PRIVATE).edit()
                    .putInt("client_id", response.clientId).apply()
                startActivity(Intent(this, MainActivity::class.java))
                finish()
            }.onFailure { error ->
                Toast.makeText(this, "Ошибка: ${error.message}", Toast.LENGTH_LONG).show()
            }
        }
    }
}