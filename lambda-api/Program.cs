using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens; // <-- Solo necesitas si usas JWT
// using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS segura
builder.Services.AddCors(options =>
{
    options.AddPolicy("LambdaPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Puerto de Angular por defecto
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

/* // Configuración de autenticación JWT (opcional, comentado por ahora)
// var jwtKey = builder.Configuration["Jwt:Key"] ?? "your-super-secret-key-min-32-characters-long";
// var key = Encoding.ASCII.GetBytes(jwtKey);

// builder.Services.AddAuthentication(x =>
// {
//     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(x =>
// {
//     x.RequireHttpsMetadata = false; // En desarrollo, cambiar a true en producción
//     x.SaveToken = true;
//     x.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(key),
//         ValidateIssuer = false,
//         ValidateAudience = false,
//         ClockSkew = TimeSpan.Zero
//     };
// });
*/

// Configuración de HTTPS
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 5188; // Puerto HTTPS personalizado
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware de seguridad
app.UseHttpsRedirection();
app.UseCors("LambdaPolicy");


// Headers de seguridad
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
    context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
    await next();
});

/*
// JWT Middleware (comentado por ahora)
// app.UseAuthentication();
*/
app.UseDefaultFiles();   // Importante, muestra index.html automáticamente
app.UseStaticFiles();    // Permite servir archivos estáticos (JS, CSS, img)

app.MapControllers();
app.MapFallbackToFile("/index.html"); // Redirige rutas de Angular

// Autorización (no requiere JWT por sí sola)
app.UseAuthorization();


app.MapControllers();

app.Run();
