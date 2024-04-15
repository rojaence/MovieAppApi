using System.Text.Json.Serialization;

namespace MovieAppApi.Models;

public class Genre : IGenre 
{
  [JsonPropertyName("id")]
  public long Id { get; set;}
  [JsonPropertyName("name")]
  public string? Name { get; set;}
}