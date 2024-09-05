using MovieAppApi.EnvConfig;
using MovieAppApi.middlewares;
using Microsoft.OpenApi.Models;

var envMode = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
if (envMode == "Development") {
  // Load Env with API config params
  DotEnv.Load();
}

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
      policy.WithOrigins(Environment.GetEnvironmentVariable("CLIENT_URL")!);
    }
  );
});

// Agregar servicios
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

builder.Services.AddMvc();
builder.Services.AddSwaggerGen(c => {
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieAppApi", Version = "v1"});
});
builder.Services.AddSwaggerGenNewtonsoftSupport();


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

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
