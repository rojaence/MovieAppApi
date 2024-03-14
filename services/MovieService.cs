using RestSharp;

namespace MovieAppApi.Services;

public class MovieService(ApiClient restClient) : ApiServiceBase(restClient)
{
  public async Task<string> GetAll()
  {
    var resource = "/discover/movie";
    return await _restClient.GetAsync(resource);
  }
}