using Newtonsoft.Json;

namespace MovieAppApi.Models;

public class Producer 
{
  [JsonProperty("id")]
  public int Id { get; set; }
  [JsonProperty("credit_id")]
  public string? CreditId { get; set; }
  [JsonProperty("name")]
  public string? Name { get; set; }
  [JsonProperty("original_name")]
  public string? OriginalName { get; set; }
  [JsonProperty("gender")]
  public int Gender { get; set; }
  [JsonProperty("profile_path")]
  public string? ProfilePath { get; set; }
}