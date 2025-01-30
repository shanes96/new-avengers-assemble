var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();  // Add this line to enable controllers
builder.Services.AddOpenApi();  // Keep this for OpenAPI documentation if needed

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Enable HTTPS Redirection
app.UseHttpsRedirection();

// Map the UserProfileController route
app.MapControllers();  // Add this line to map the controllers

// You can keep the weather forecast endpoint if you need it, or remove it
var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
