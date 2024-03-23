using MovieAppApi.Services;
using MovieAppApi.EnvConfig;

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

app.MapGet("/", () => "Hello World!");

app.MapGet("/movies", async () => {
  var res = await movieService.GetAll();
  return res;
});

app.MapGet("/trending/movies", async () => {
  var res = await movieService.GetTrending();
  return res;
});

app.MapGet("/popular/movies", async () => {
  var res = await movieService.GetPopular();
  return res;
});

app.Run();