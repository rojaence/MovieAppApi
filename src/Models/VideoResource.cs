namespace MovieAppApi.Models;

using Newtonsoft.Json;

public class VideoResource 
{
  [JsonProperty("iso_639_1")]
  public string? Iso639_1 { get; set; }
  [JsonProperty("iso_3166_1")]
  public string? Iso3166_1 { get; set; }
  [JsonProperty("name")]
  public string? Name { get; set; }
  [JsonProperty("key")]
  public string? Key { get; set; }
  [JsonProperty("site")]
  public string? Site { get; set; }
  [JsonProperty("size")]
  public int Size { get; set; }
  [JsonProperty("type")]
  public string? Type { get; set; }
  [JsonProperty("official")]
  public bool Official { get; set; }
  [JsonProperty("published_at")]
  public DateTime? PublisedAt { get; set; }
  [JsonProperty("id")]
  public string? Id { get; set; }
}

public class VideoGallery
{
  [JsonProperty("id")]
  public long Id { get; set; }
  [JsonProperty("results")]
  public List<VideoResource> Results { get; } = [];
}