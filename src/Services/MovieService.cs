namespace MovieAppApi.Services;

using MovieAppApi.Exceptions;
using MovieAppApi.Models;
using RestSharp;

public class MovieService : ApiServiceBase, IMediaService
{
  public async Task<IResult> GetAll()
  {
    try 
    {
      var request = new RestRequest("/discover/movie");
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response); 
    } 
    catch (RequestException ex) 
    {
      return Results.NotFound(ex.Message);
    }
  }

  public async Task<IResult> GetTrending(TimeWindowEnum? timeWindow)
  {
    try 
    {
      var request = new RestRequest($"/trending/movie/{timeWindow ?? TimeWindowEnum.day}");
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response); 
    } 
    catch (RequestException ex) 
    {
      return Results.NotFound(ex.Message);
    }
  }

  public async Task<IResult> GetPopular()
  {
    try 
    {
      var request = new RestRequest("/movie/popular");
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response); 
    } 
    catch (RequestException ex) 
    {
      return Results.NotFound(ex.Message);
    }
  }

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
}