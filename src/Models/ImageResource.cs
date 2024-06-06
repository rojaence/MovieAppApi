namespace MovieAppApi.Models;

using Newtonsoft.Json;

public class ImageResource
{
  [JsonProperty("aspect_ratio")]
  public float AspectRatio { get; set; }
  [JsonProperty("height")]
  public int Height  { get; set; }
  [JsonProperty("iso_639_1")]
  public string? Iso639_1 { get; set; }
  [JsonProperty("file_path")]
  public string? FilePath { get; set; }
  [JsonProperty("vote_average")]
  public float VoteAverage { get; set; }
  [JsonProperty("vote_count")]
  public int VoteCount { get; set; }
  [JsonProperty("width")]
  public int Width { get; set; }
}