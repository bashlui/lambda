var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// (Opcional: agrega CORS si quieres exponer la API desde otros lugares)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Permitir servir archivos estáticos
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

// Catch-all para rutas del frontend Angular
app.MapFallbackToFile("/index.html");

app.Run();
