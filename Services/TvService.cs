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
}