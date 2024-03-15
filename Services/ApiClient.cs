namespace MovieAppApi.Services;
using MovieAppApi.Models;

using RestSharp;
using System.Threading.Tasks;

public class ApiClient
{
  private readonly ApiConfig _apiConfig;
  private readonly RestClient _restClient;

  public ApiClient(ApiConfig config)
  {
    var options = new RestClientOptions(config.BaseUrl!);
    _apiConfig = config;
    _restClient = new RestClient(options);
  }

  public async Task<string> GetAsync(string resource)
  {
    var request = new RestRequest(resource);
    request.AddHeader("accept", "application/json");
    request.AddHeader("Authorization", _apiConfig.BearerToken!);
    request.AddParameter("api_key", _apiConfig.ApiKey);
    var response = await _restClient.GetAsync(request);
    return response.Content!;
  }
}