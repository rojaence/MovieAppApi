namespace MovieAppApi.Services;

using MovieAppApi.Exceptions;
using MovieAppApi.Models;
using RestSharp;

public class PersonService : ApiServiceBase
{
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
}