using Microsoft.AspNetCore.Mvc;
using MovieAppApi.Exceptions;
using MovieAppApi.Models;
using RestSharp;

namespace MovieAppApi.Services;

[ApiController]
[Route("tv")]
public class TvService(IHttpContextAccessor httpContextAccessor) : ApiServiceBase(httpContextAccessor), IMediaService
{
  [HttpGet]
   public async Task<IResult> GetAll(int page = 1, string genres = "", string sortBy = "popularity.desc")
  {
    try 
    {
      var request = new RestRequest("discover/tv");
      request.AddParameter("page", page);
      request.AddParameter("with_genres", genres);
      request.AddParameter("sort_by", sortBy);
      var response = await HandleRequest<TvResponse>(request);
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
      var request = new RestRequest($"/trending/tv/{timeWindow ?? TimeWindowEnum.day}");
      request.AddParameter("page", page);
      var response = await HandleRequest<TvResponse>(request);
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
      var request = new RestRequest("/tv/popular");
      request.AddParameter("page", page);
      var response = await HandleRequest<TvResponse>(request);
      return Results.Ok(response);
    }
    catch (RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<IResult> GetDetails(int id) 
  {
    try
    {
      var request = new RestRequest($"/tv/{id}");
      var response = await HandleRequest<TvDetails>(request);
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
      var request = new RestRequest($"/tv/{id}/recommendations");
      var response = await HandleRequest<TvResponse>(request);
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
      var request = new RestRequest($"/tv/{id}/images");
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
      var request = new RestRequest($"/tv/{id}/videos");
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
      var request = new RestRequest("/search/tv");
      request.AddParameter("query", query);
      request.AddParameter("page", page);
      var response = await HandleRequest<TvResponse>(request);
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
      var request = new RestRequest("/genre/tv/list");
      var response = await HandleRequest<GenreResponse>(request);
      return Results.Ok(response);
    } catch (RequestException ex) {
      return Results.NotFound(ex.Message);
    }
  }
}