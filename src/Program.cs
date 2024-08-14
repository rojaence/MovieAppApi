using MovieAppApi.Services;
using MovieAppApi.EnvConfig;
using MovieAppApi.Models;
using Microsoft.AspNetCore.Mvc;

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
var personService = new PersonService();

app.MapGet("/", () => "Hello World!");

app.MapGet("/movie", async (int page, string genres, string sortBy) => { 
  var res = await movieService.GetAll(page, genres, sortBy);
  return res;
});

app.MapGet("/trending/movie", async (TimeWindowEnum? timeWindow, int page) => {
  var res = await movieService.GetTrending(timeWindow, page);
  return res;
});

app.MapGet("/popular/movie", async () => {
  var res = await movieService.GetPopular();
  return res;
});

app.MapGet("/tv", async (int page, string genres, string sortBy) => {
  var res = await tvService.GetAll(page, genres, sortBy);
  return res;
});

app.MapGet("/trending/tv", async (TimeWindowEnum? timeWindow, int page) => {
  var res = await tvService.GetTrending(timeWindow, page);
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

app.MapGet("/movie/{id}/images", async (int id) => {
  var res = await movieService.GetImageGallery(id);
  return res;
});

app.MapGet("/movie/{id}/videos", async (int id) => {
  var res = await movieService.GetVideoGallery(id);
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

app.MapGet("/tv/{id}/images", async (int id) => {
  var res = await tvService.GetImageGallery(id);
  return res;
});

app.MapGet("/tv/{id}/videos", async (int id) => {
  var res = await tvService.GetVideoGallery(id);
  return res;
});

app.MapGet("search/movie", async (string query, int? page) => {
  var res = await movieService.Search(query, page ?? 1);
  return res;
});

app.MapGet("search/tv", async (string query, int? page) => {
  var res = await tvService.Search(query, page ?? 1);
  return res;
});

app.MapGet("person/{id}", async (int id) => {
  var res = await personService.GetDetails(id);
  return res;
});

app.MapGet("search/person", async (string query, int? page) => {
  var res = await personService.Search(query, page ?? 1);
  return res;
});

app.MapGet("person/{id}/credits/movie", async (int id) => { 
  var res = await personService.GetMovieCredits(id);
  return res;
});

app.MapGet("person/{id}/credits/tv", async (int id) => { 
  var res = await personService.GetTvCredits(id);
  return res;
});

app.MapGet("trending/person", async (TimeWindowEnum? timeWindow, int page) => {
  var res = await personService.GetTrending(timeWindow, page);
  return res;
});

app.MapGet("genre/movie", async () => { 
  var res = await movieService.GetGenres();
  return res;
});

app.MapGet("genre/tv", async () => { 
  var res = await tvService.GetGenres();
  return res;
});

app.Run();
