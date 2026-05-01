package com.example.realestateclient.data.api

import com.example.realestateclient.data.models.*
import retrofit2.Call
import retrofit2.http.*

interface ApiService {

    @POST("api/auth/login")
    fun login(@Body request: LoginRequest): Call<LoginResponse>

    @POST("api/auth/register")
    fun register(@Body profile: ClientProfile): Call<LoginResponse>

    @GET("api/properties")
    fun getProperties(
        @Query("minPrice") minPrice: Double? = null,
        @Query("maxPrice") maxPrice: Double? = null,
        @Query("minArea") minArea: Double? = null,
        @Query("maxArea") maxArea: Double? = null,
        @Query("rooms") rooms: Int? = null,
        @Query("districtId") districtId: Int? = null,
        @Query("propertyTypeId") propertyTypeId: Int? = null
    ): Call<List<Property>>

    @GET("api/properties/{id}")
    fun getPropertyDetail(@Path("id") id: Int): Call<PropertyDetail>

    @GET("api/favorites/{clientId}")
    fun getFavorites(@Path("clientId") clientId: Int): Call<List<Favorite>>

    @POST("api/favorites")
    fun addFavorite(@Body body: FavoriteRequest): Call<Void>

    @DELETE("api/favorites/{clientId}/{propertyId}")
    fun removeFavorite(
        @Path("clientId") clientId: Int,
        @Path("propertyId") propertyId: Int
    ): Call<Void>

    @POST("api/viewingrequests")
    fun createViewingRequest(@Body body: CreateViewingRequestDto): Call<Void>

    @GET("api/viewingrequests/client/{clientId}")
    fun getClientRequests(@Path("clientId") clientId: Int): Call<List<ViewingRequest>>

    @GET("api/profile/{id}")
    fun getProfile(@Path("id") id: Int): Call<ClientProfile>

    @PUT("api/profile/{id}")
    fun updateProfile(@Path("id") id: Int, @Body profile: ClientProfile): Call<Void>
}