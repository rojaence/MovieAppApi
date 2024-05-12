using Newtonsoft.Json;

namespace MovieAppApi.Models;

public class Collection : ICollection
{
  [JsonProperty("id")]
  public long Id { get; set; }
  [JsonProperty("name")]
  public string? Name { get; set; }
  [JsonProperty("poster_path")]
  public string? PosterPath { get; set; }
  [JsonProperty("backdrop_path")]
  public string? BackdropPath { get; set; }
}