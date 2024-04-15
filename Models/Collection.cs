using System.Text.Json.Serialization;

namespace MovieAppApi.Models;

public class Collection : ICollection
{
  [JsonPropertyName("id")]
  public long Id { get; set; }
  [JsonPropertyName("name")]
  public string? Name { get; set; }
  [JsonPropertyName("poster_path")]
  public string? PosterPath { get; set; }
  [JsonPropertyName("backdrop_path")]
  public string? BackdropPath { get; set; }
}