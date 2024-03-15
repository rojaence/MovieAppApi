using RestSharp;
using MovieAppApi.Models;
using System.Text.Json;

namespace MovieAppApi.Services;

public class MovieService(ApiClient restClient) : ApiServiceBase(restClient)
{
  public async Task<MovieResponse> GetAll()
  {
    var resource = "/discover/movie";
    var result = await _restClient.GetAsync(resource);
    var movieResponse = JsonSerializer.Deserialize<MovieResponse>(result, new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    });
    return movieResponse!;
  }
}