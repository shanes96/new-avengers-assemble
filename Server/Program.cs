var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(); 
builder.Services.AddOpenApi();  

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:8000")  
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Enable HTTPS Redirection
app.UseHttpsRedirection();

// Enable CORS for your frontend
app.UseCors("AllowFrontend");

// Map the API controllers
app.MapControllers();

app.Run();
