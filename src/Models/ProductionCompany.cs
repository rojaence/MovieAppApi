using Newtonsoft.Json;

namespace MovieAppApi.Models;

public class ProductionCompany : IProductionCompany
{
  [JsonProperty("id")]
  public long Id {  get; set; }
  [JsonProperty("name")]
  public string? Name { get; set; }
  [JsonProperty("logo_path")]
  public string? LogoPath { get; set; }
  [JsonProperty("origin_country")]
  public string? OriginCountry { get; set; }
}