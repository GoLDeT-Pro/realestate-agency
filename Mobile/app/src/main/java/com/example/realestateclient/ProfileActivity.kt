package com.example.realestateclient

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import com.example.realestateclient.data.models.ClientProfile
import com.example.realestateclient.ui.viewmodels.ProfileViewModel

class ProfileActivity : AppCompatActivity() {
    private val viewModel: ProfileViewModel by viewModels()
    private val clientId by lazy { getSharedPreferences("app", MODE_PRIVATE).getInt("client_id", 0) }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_profile)

        findViewById<TextView>(R.id.tvBack).setOnClickListener { finish() }

        val etPhone = findViewById<EditText>(R.id.etProfilePhone)
        val etEmail = findViewById<EditText>(R.id.etProfileEmail)
        val btnSave = findViewById<Button>(R.id.btnSaveProfile)
        val btnLogout = findViewById<Button>(R.id.btnLogout)

        viewModel.profile.observe(this) { profile ->
            etPhone.setText(profile.phone)
            etEmail.setText(profile.email ?: "")
        }

        viewModel.loadProfile(clientId)

        btnSave.setOnClickListener {
            val phone = etPhone.text.toString().trim()
            val email = etEmail.text.toString().trim()
            if (phone.isEmpty()) {
                Toast.makeText(this, "Введите телефон", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }
            val profile = ClientProfile(
                fullName = "",
                phone = phone,
                email = email
            )
            viewModel.updateProfile(clientId, profile)
            Toast.makeText(this, "Сохранено", Toast.LENGTH_SHORT).show()
        }

        btnLogout.setOnClickListener {
            getSharedPreferences("app", MODE_PRIVATE).edit().clear().apply()
            startActivity(Intent(this, LoginActivity::class.java))
            finish()
        }
    }
}