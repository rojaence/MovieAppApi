namespace MovieAppApi.Services;

using Microsoft.AspNetCore.Mvc;
using MovieAppApi.Exceptions;
using MovieAppApi.Models;
using RestSharp;

[ApiController]
[Route("person")]
public class PersonService(IHttpContextAccessor httpContextAccessor) : ApiServiceBase(httpContextAccessor)
{
  [Route("{id}")]
  public async Task<IResult> GetDetails(int id)
  {
    try {
      var request = new RestRequest($"/person/{id}");
      var response = await HandleRequest<PersonDetails>(request);
      return Results.Ok(response);
    }
    catch (RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  [Route("trending")]
  public async Task<IResult> GetTrending(TimeWindowEnum? timeWindow, int page = 1)
  {
    try 
    {
      var request = new RestRequest($"/trending/person/{timeWindow ?? TimeWindowEnum.day}");
      request.AddParameter("page", page);
      var response = await HandleRequest<PersonResponse>(request);
      return Results.Ok(response);
    }
    catch (RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  [Route("popular")]
  public async Task<IResult> GetPopular(int page = 1)  
  {
    try 
    {
      var request = new RestRequest("/person/popular");
      request.AddParameter("page", page);
      var response = await HandleRequest<PersonResponse>(request);
      return Results.Ok(response);
    }
    catch (RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  [Route("search")]
  public async Task<IResult> Search(string query, int page = 1)
  {
    try {
      var request = new RestRequest("/search/person");
      request.AddParameter("query", query);
      request.AddParameter("page", page);
      var response = await HandleRequest<PersonResponse>(request);
      return Results.Ok(response);
    } 
    catch (RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  [Route("{id}/credits/movie")]
  public async Task<IResult> GetMovieCredits(int id)
  {
    try {
      var request = new RestRequest($"/person/{id}/movie_credits");
      var response = await HandleRequest<PersonMovieCredit>(request);
      return Results.Ok(response);
    }
    catch (RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  [Route("{id}/credits/tv")]
  public async Task<IResult> GetTvCredits(int id)
  {
    try
    {
      var request = new RestRequest($"/person/{id}/tv_credits");
      var response = await HandleRequest<PersonTvCredit>(request);
      return Results.Ok(response);

    }
    catch (RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }
}