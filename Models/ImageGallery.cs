namespace MovieAppApi.Models;

using Newtonsoft.Json;

public class ImageGallery
{
  [JsonProperty("backdrops")]
  public List<ImageResource>? Backdrops { get; set; }
  [JsonProperty("id")]
  public long Id { get; set; }
  [JsonProperty("logos")]
  public List<ImageResource>? Logos { get; set; }
  [JsonProperty("posters")]
  public List<ImageResource>? Posters { get; set; }
}
