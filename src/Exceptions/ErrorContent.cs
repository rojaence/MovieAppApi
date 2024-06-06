using Newtonsoft.Json;

namespace MovieAppApi.Exceptions;

public class ErrorContent 
{
  [JsonProperty("success")]
  public bool Success { get; set; }
  [JsonProperty("status_code")]
  public int StatusCode { get; set; }
  [JsonProperty("status_message")]
  public string? StatusMessage { get; set; }  
}