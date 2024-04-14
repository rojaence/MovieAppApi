using System.Text.Json.Serialization;

namespace MovieAppApi.Models;

public class ProductionCompany : IProductionCompany
{
  [JsonPropertyName("id")]
  public long Id {  get; set; }
  [JsonPropertyName("name")]
  public string? Name { get; set; }
  [JsonPropertyName("logo_path")]
  public string? LogoPath { get; set; }
  [JsonPropertyName("origin_country")]
  public string? OriginCountry { get; set; }
}