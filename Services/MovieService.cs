using MovieAppApi.Models;

namespace MovieAppApi.Services;

public class MovieService(ApiClient restClient) : ApiServiceBase<MovieResponse>(restClient), IMediaService<MovieResponse>
{
  public async Task<MovieResponse> GetAll()
  {
    return await GetFromEndpoint("/discover/movie");
  }

  public async Task<MovieResponse> GetTrending(TimeWindowEnum? timeWindow)
  {
   return await GetFromEndpoint($"/trending/movie/{timeWindow ?? TimeWindowEnum.day}"); 
  }
  public async Task<MovieResponse> GetPopular()
  {
   return await GetFromEndpoint("/movie/popular"); 
  }
}