using MovieAppApi.Exceptions;
using Newtonsoft.Json;
using RestSharp;

namespace MovieAppApi.Services;

public class ApiServiceBase
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  // Constructor que inyecta IHttpContextAccessor
  public ApiServiceBase(IHttpContextAccessor httpContextAccessor)
  {
      _httpContextAccessor = httpContextAccessor;
  }

  private static readonly Lazy<RestClient> restClientInstance = new(() => {
    var config = GetApiConfig();
    var options = new RestClientOptions(config.BaseUrl!);
    var restClient = new RestClient(options);
    restClient.AddDefaultParameter("api_key", config.ApiKey!);
    return restClient;
  });

  private static ApiConfig GetApiConfig()
  {
    var config = new ApiConfig
    {
      BaseUrl = Environment.GetEnvironmentVariable("BASE_URL"),
      ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
    };
    return config;
  }

  protected RestClient _restClient = restClientInstance.Value;

  protected async Task<TResponse> HandleRequest<TResponse>(RestRequest request)
  {
    var language = _httpContextAccessor.HttpContext?.Items["language"]?.ToString();
    if (!string.IsNullOrEmpty(language))
    {
      request.AddQueryParameter("language", language);
    }
    var response = await _restClient.ExecuteAsync(request);
    if (!response.IsSuccessful)
    {
      var errorContent = JsonConvert.DeserializeObject<ErrorContent>(response.Content!)!;
      var errorMessage = $"Error calling API. {errorContent.StatusMessage}";
      throw new RequestException(errorMessage);
    }
    return JsonConvert.DeserializeObject<TResponse>(response.Content!)!;
  }
}