using System.Text.Json;
using MovieAppApi.Models;
using RestSharp;

namespace MovieAppApi.Services;

public abstract class ApiServiceBase<TResponse>(ApiClient restClient)
{
  protected readonly ApiClient _restClient = restClient;
  protected async Task<TResponse> GetFromEndpoint(string endpoint)
  {
    var result = await _restClient.GetAsync(endpoint);
    var response = JsonSerializer.Deserialize<TResponse>(result);
    return response!;
  }

  protected async Task<dynamic> GetFromEndpointDynamic(string endpoint) 
  {
  var result = await _restClient.GetAsync(endpoint);
    var response = JsonSerializer.Deserialize<dynamic>(result);
    return response!;
  }
}