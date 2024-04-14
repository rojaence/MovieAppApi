using MovieAppApi.Models;
using System.Text.Json;

namespace MovieAppApi.Services;

public class TvService() : ApiServiceBase, IMediaService<TvResponse>
{
  public async Task<TvResponse> GetAll()
  {
    var result = await _restClient.GetAsync("/discover/tv");
    var response = JsonSerializer.Deserialize<TvResponse>(result);
    return response!;
  }

  public async Task<TvResponse> GetTrending(TimeWindowEnum? timeWindow)
  {
    var result = await _restClient.GetAsync($"/trending/tv/{timeWindow ?? TimeWindowEnum.day}");
    var response = JsonSerializer.Deserialize<TvResponse>(result);
    return response!;
  }
  public async Task<TvResponse> GetPopular()
  {
    var result = await _restClient.GetAsync("/tv/popular");
    var response = JsonSerializer.Deserialize<TvResponse>(result);
    return response!;
  }
}