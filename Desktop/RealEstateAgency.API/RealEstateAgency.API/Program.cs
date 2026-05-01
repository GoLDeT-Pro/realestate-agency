var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var parts = connectionString.Split(';');
string server = parts[0].Split('=')[1];
string database = parts[1].Split('=')[1];
string uid = parts[2].Split('=')[1];
string pwd = parts[3].Split('=')[1];

builder.Services.AddSingleton(new DatabaseService(server, database, uid, pwd));
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PropertyService>();
builder.Services.AddScoped<DealService>();
builder.Services.AddScoped<ViewingRequestService>();
builder.Services.AddScoped<DictionaryService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();