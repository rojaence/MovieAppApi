using MovieAppApi.Services;
using MovieAppApi.EnvConfig;
using MovieAppApi.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
