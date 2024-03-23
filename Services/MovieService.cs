using RestSharp;
using MovieAppApi.Models;
using System.Text.Json;

namespace MovieAppApi.Services;

public class MovieService(ApiClient restClient) : ApiServiceBase(restClient), IMediaService<MovieResponse>
{
  public async Task<MovieResponse> GetAll()
  {
    return await GetFromEndpoint("/discover/movie");
  }

  public async Task<MovieResponse> GetTrending(TimeWindow timeWindow = TimeWindow.day )
  {
   return await GetFromEndpoint($"/trending/movie/{timeWindow}"); 
  }
  public async Task<MovieResponse> GetPopular()
  {
   return await GetFromEndpoint("/movie/popular"); 
  }

  private async Task<MovieResponse> GetFromEndpoint(string endpoint)
  {
    var result = await _restClient.GetAsync(endpoint);
    var movieResponse = JsonSerializer.Deserialize<MovieResponse>(result);
    return movieResponse!;
  }
}