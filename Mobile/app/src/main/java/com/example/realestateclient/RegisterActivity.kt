package com.example.realestateclient

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import com.example.realestateclient.ui.viewmodels.RegisterViewModel

class RegisterActivity : AppCompatActivity() {
    private val viewModel: RegisterViewModel by viewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_register)

        findViewById<TextView>(R.id.tvBack).setOnClickListener { finish() }

        val nameEt = findViewById<EditText>(R.id.etFullName)
        val phoneEt = findViewById<EditText>(R.id.etPhoneReg)
        val emailEt = findViewById<EditText>(R.id.etEmail)
        findViewById<Button>(R.id.btnRegister).setOnClickListener {
            viewModel.register(nameEt.text.toString(), phoneEt.text.toString(), emailEt.text.toString())
        }

        viewModel.registerResult.observe(this) { result ->
            result.onSuccess {
                Toast.makeText(this, "Регистрация успешна", Toast.LENGTH_SHORT).show()
                finish()
            }.onFailure { error ->
                Toast.makeText(this, "Ошибка: ${error.message}", Toast.LENGTH_LONG).show()
            }
        }
    }
}