using MovieAppApi.Models;

namespace MovieAppApi.Services;

public class TvService(ApiClient restClient) : ApiServiceBase<TvResponse>(restClient), IMediaService<TvResponse>
{
  public async Task<TvResponse> GetAll()
  {
    return await GetFromEndpoint("/discover/tv");
  }

  public async Task<TvResponse> GetTrending(TimeWindowEnum? timeWindow)
  {
   return await GetFromEndpoint($"/trending/tv/{timeWindow ?? TimeWindowEnum.day}"); 
  }
  public async Task<TvResponse> GetPopular()
  {
   return await GetFromEndpoint("/tv/popular"); 
  }
}