using Newtonsoft.Json;

namespace MovieAppApi.Models;

public class Genre : IGenre 
{
  [JsonProperty("id")]
  public long Id { get; set;}
  [JsonProperty("name")]
  public string? Name { get; set;}
}