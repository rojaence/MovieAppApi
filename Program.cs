using MovieAppApi.Services;
using MovieAppApi.EnvConfig;
using MovieAppApi.Models;

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

var app = builder.Build();

// BASE API PATH
app.UseRouting();
app.UsePathBase("/api");
app.UseCors(movieAppCors);

var movieService = new MovieService();
var tvService = new TvService();

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

app.MapGet("/movie/{id}", async (int id) => {
  var res = await movieService.GetDetails(id);
  return res;
});

app.MapGet("/movie/{id}/recommendations", async (int id) => {
  var res = await movieService.GetRecommendations(id);
  return res;
});

app.MapGet("/tv/{id}", async (int id) => {
  var res = await tvService.GetDetails(id);
  return res;
});

app.MapGet("/tv/{id}/recommendations", async (int id) => {
  var res = await tvService.GetRecommendations(id);
  return res;
});

app.Run();
