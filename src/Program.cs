using MovieAppApi.Services;
using MovieAppApi.EnvConfig;
using MovieAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using MovieAppApi.middlewares;

// Load Env with API config params
DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);
// CORS
var movieAppCors = "_movieAppCors";
builder.Services.AddCors(options =>
{
  options.AddPolicy
  (
    name: movieAppCors,
    policy => 
    {
      policy.WithOrigins("http://localhost:4200");
    }
  );
});

// Agregar servicios
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<TvService>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddControllers();

var app = builder.Build();

// BASE API PATH
app.UseRouting();
app.UsePathBase("/api");
app.UseCors(movieAppCors);
app.UseMiddleware<LanguageMiddleware>();
app.MapControllers();

app.MapGet("/", async context => 
{
  var language = context.Request.Headers.AcceptLanguage.ToString().ToLower();
  var message = language.Contains("es")
  ?
  "Hola, bienvenido a MovieAppApi por Ronny Endara. Este producto utiliza TMDB y las API de TMDB, pero no esta respaldado, certificado ni aprobado de ningun otro modo por TMDB."
  :
  "Hello, welcome to MovieAppApi by Ronny Endara. This product uses TMDB and the TMDB APIs but is not endorsed, certified, or otherwise approved by TMDB.";
  await context.Response.WriteAsync(message);
});

app.Run();
