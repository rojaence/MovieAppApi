using RestSharp;

namespace MovieAppApi.Services;

public abstract class ApiServiceBase(ApiClient restClient)
{
  protected readonly ApiClient _restClient = restClient;
}