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
  var data = await movieService.GetAll();
  return data;
});

app.Run();
