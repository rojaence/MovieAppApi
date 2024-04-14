using System.Text.Json.Serialization;

namespace MovieAppApi.Models;

public class ProductionCountry : IProductionCountry
{
  [JsonPropertyName("iso_3166_1")]
  public string? Iso3166_1 {  get; set; }
  [JsonPropertyName("name")]
  public string? Name { get; set; }
}