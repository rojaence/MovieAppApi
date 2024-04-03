using MovieAppApi.Services;
using MovieAppApi.EnvConfig;
using MovieAppApi.Models;

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

var app = builder.Build();
// BASE API PATH
app.UseRouting();
app.UsePathBase("/api");
app.UseCors(movieAppCors);
DotEnv.Load();

ApiConfig config = new()
{
  BaseUrl = Environment.GetEnvironmentVariable("BASE_URL"),
  ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
  BearerToken = Environment.GetEnvironmentVariable("BEARER_TOKEN")
};

var restClient = new ApiClient(config);
var movieService = new MovieService(restClient);
var tvService = new TvService(restClient);

app.MapGet("/", () => "Hello World!");

app.MapGet("/movie", async () => {
  var res = await movieService.GetAll();
  return res;
});

app.MapGet("/trending/movie", async (TimeWindowEnum? timeWindow) => {
  var res = await movieService.GetTrending(timeWindow);
  return res;
});

app.MapGet("/popular/movie", async () => {
  var res = await movieService.GetPopular();
  return res;
});

app.MapGet("/tv", async () => {
  var res = await tvService.GetAll();
  return res;
});

app.MapGet("/trending/tv", async (TimeWindowEnum? timeWindow) => {
  var res = await tvService.GetTrending(timeWindow);
  return res;
});

app.MapGet("/popular/tv", async () => {
  var res = await tvService.GetPopular();
  return res;
});

app.Run();
