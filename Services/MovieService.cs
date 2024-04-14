using MovieAppApi.Models;
using System.Text.Json;
namespace MovieAppApi.Services;

public class MovieService() : ApiServiceBase, IMediaService<MovieResponse>
{
  public async Task<MovieResponse> GetAll()
  {
    var result = await _restClient.GetAsync("/discover/movie");
    var response = JsonSerializer.Deserialize<MovieResponse>(result);
    return response!;
  }

  public async Task<MovieResponse> GetTrending(TimeWindowEnum? timeWindow)
  {
    var result = await _restClient.GetAsync($"/trending/movie/{timeWindow ?? TimeWindowEnum.day}");
    var response = JsonSerializer.Deserialize<MovieResponse>(result);
    return response!;
  }
  public async Task<MovieResponse> GetPopular()
  {
    var result = await _restClient.GetAsync("/movie/popular");
    var response = JsonSerializer.Deserialize<MovieResponse>(result);
    return response!;
  }

  public async Task<MovieDetails> GetDetails(int id) {
    var result = await _restClient.GetAsync($"/movie/{id}");
    var response = JsonSerializer.Deserialize<MovieDetails>(result);
    return response!;
  }
}