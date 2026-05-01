package com.example.realestateclient

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import com.example.realestateclient.data.models.ViewingRequest
import com.example.realestateclient.ui.viewmodels.ViewingRequestsViewModel

class CreateViewingRequestActivity : AppCompatActivity() {
    private val viewModel: ViewingRequestsViewModel by viewModels()
    private var propertyId: Int = 0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_create_viewing_request)

        findViewById<TextView>(R.id.tvBack).setOnClickListener { finish() }

        propertyId = intent.getIntExtra("property_id", 0)

        val etDate = findViewById<EditText>(R.id.etDate)
        val etTime = findViewById<EditText>(R.id.etTime)
        val etComment = findViewById<EditText>(R.id.etComment)

        findViewById<Button>(R.id.btnSubmit).setOnClickListener {
            val date = etDate.text.toString()
            val time = etTime.text.toString()
            if (date.isEmpty() || time.isEmpty()) {
                Toast.makeText(this, "Заполните дату и время", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }
            val request = ViewingRequest(
                propertyId = propertyId,
                preferredDate = date,
                preferredTime = time,
                comment = etComment.text.toString()
            )
            val clientId = getSharedPreferences("app", MODE_PRIVATE).getInt("client_id", 0)
            viewModel.createRequest(request, clientId)
            Toast.makeText(this, "Заявка отправлена", Toast.LENGTH_SHORT).show()
            finish()
        }
    }
}