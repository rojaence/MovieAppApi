using MovieAppApi.Exceptions;
using MovieAppApi.Models;
using RestSharp;

namespace MovieAppApi.Services;

public class TvService : ApiServiceBase, IMediaService
{
  public async Task<IResult> GetAll()
  {
    try 
    {
      var request = new RestRequest("discover/tv");
      var response = await HandleRequest<TvResponse>(request);
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
      var request = new RestRequest($"/trending/tv/{timeWindow ?? TimeWindowEnum.day}");
      var response = await HandleRequest<TvResponse>(request);
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
      var request = new RestRequest("/tv/popular");
      var response = await HandleRequest<TvResponse>(request);
      return Results.Ok(response);
    }
    catch (RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

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

  public async Task<IResult> Search(string query)
  {
    try {
      var request = new RestRequest("/search/tv");
      request.AddParameter("query", query);
      var response = await HandleRequest<TvResponse>(request);
      return Results.Ok(response);
    } 
    catch (RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }
}