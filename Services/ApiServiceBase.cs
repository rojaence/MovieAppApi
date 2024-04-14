namespace MovieAppApi.Services;

public abstract class ApiServiceBase()
{
  protected static readonly Lazy<ApiClient> restClientInstance = new(() => {
    var config = new ApiConfig
    {
      BaseUrl = Environment.GetEnvironmentVariable("BASE_URL"),
      ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
      BearerToken = Environment.GetEnvironmentVariable("BEARER_TOKEN")
    };
    return new ApiClient(config);
  });

  protected readonly ApiClient _restClient = restClientInstance.Value;
}