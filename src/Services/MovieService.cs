namespace MovieAppApi.Services;

using Microsoft.AspNetCore.Mvc;
using MovieAppApi.Exceptions;
using MovieAppApi.Models;
using RestSharp;

[ApiController]
[Route("movies")]
public class MovieService(IHttpContextAccessor httpContextAccessor) : ApiServiceBase(httpContextAccessor), IMediaService
{
  [HttpGet]
  public async Task<IResult> GetAll(int page = 1, string genres = "", string sortBy = "popularity.desc")
  {
    try 
    {
      var request = new RestRequest("/discover/movie");
      request.AddParameter("page", page);
      request.AddParameter("with_genres", genres);
      request.AddParameter("sort_by", sortBy);
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response); 
    } 
    catch (RequestException ex) 
    {
      return Results.NotFound(ex.Message);
    }
  }

  [HttpGet]
  [Route("trending")]
  public async Task<IResult> GetTrending(TimeWindowEnum? timeWindow, int page = 1)
  {
    try 
    {
      var request = new RestRequest($"/trending/movie/{timeWindow ?? TimeWindowEnum.day}");
      request.AddParameter("page", page);
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response); 
    } 
    catch (RequestException ex) 
    {
      return Results.NotFound(ex.Message);
    }
  }

  [HttpGet]
  [Route("popular")]
  public async Task<IResult> GetPopular(int page = 1)
  {
    try 
    {
      var request = new RestRequest("/movie/popular");
      request.AddParameter("page", page);
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response); 
    } 
    catch (RequestException ex) 
    {
      return Results.NotFound(ex.Message);
    }
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<IResult> GetDetails(int id) {
    try 
    {
      var request = new RestRequest($"/movie/{id}");
      var response = await HandleRequest<MovieDetails>(request);
      return Results.Ok(response); 
    } 
    catch (RequestException ex) 
    {
      return Results.NotFound(ex.Message);
    }
  }

  [HttpGet]
  [Route("{id}/recommendations")]
  public async Task<IResult> GetRecommendations(int id)
  {
    try {
      var request = new RestRequest($"/movie/{id}/recommendations");
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response);
    } 
    catch(RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  [HttpGet]
  [Route("{id}/images")]
  public async Task<IResult> GetImageGallery(int id)
  {
    try {
      var request = new RestRequest($"/movie/{id}/images");
      var response = await HandleRequest<ImageGallery>(request);
      return Results.Ok(response);
    }
    catch(RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }
  
  [HttpGet]
  [Route("{id}/videos")]
  public async Task<IResult> GetVideoGallery(int id)
  {
    try {
      var request = new RestRequest($"/movie/{id}/videos");
      var response = await HandleRequest<VideoGallery>(request);
      return Results.Ok(response);
    }
    catch(RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  [HttpGet]
  [Route("search")]
  public async Task<IResult> Search(string query, int page = 1)
  {
    try {
      var request = new RestRequest("/search/movie");
      request.AddParameter("query", query);
      request.AddParameter("page", page);
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response);
    } 
    catch (RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  [HttpGet]
  [Route("genres")]
  public async Task<IResult> GetGenres() {
    try {
      var request = new RestRequest("/genre/movie/list");
      var response = await HandleRequest<GenreResponse>(request);
      return Results.Ok(response);
    } catch (RequestException ex) {
      return Results.NotFound(ex.Message);
    }
  }
}