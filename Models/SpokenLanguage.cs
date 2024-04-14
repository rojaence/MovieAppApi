using System.Text.Json.Serialization;

namespace MovieAppApi.Models;

public class SpokenLanguage : ISpokenLanguage
{
  [JsonPropertyName("english_name")]
  public string? EnglishName { get; set;}
  [JsonPropertyName("iso_639_1")]
  public string? Iso639_1 { get; set;}
  [JsonPropertyName("name")]
  public string? Name { get; set;}
}