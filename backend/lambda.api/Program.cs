var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configure CORS with specific origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .WithExposedHeaders("X-Pagination");
    });
});

var app = builder.Build();

// Use CORS before routing
app.UseCors("DevelopmentPolicy");

// Enable routing and endpoint mapping
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();