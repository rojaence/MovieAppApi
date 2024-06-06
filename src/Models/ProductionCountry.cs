using Newtonsoft.Json;

namespace MovieAppApi.Models;

public class ProductionCountry : IProductionCountry
{
  [JsonProperty("iso_3166_1")]
  public string? Iso3166_1 {  get; set; }
  [JsonProperty("name")]
  public string? Name { get; set; }
}