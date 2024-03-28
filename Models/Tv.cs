using System.Text.Json.Serialization;

namespace MovieAppApi.Models;

public class Tv : ITv
{
  [JsonPropertyName("adult")]
  public bool Adult { get; set; }
  [JsonPropertyName("backdrop_path")]
  public string? BackdropPath { get; set; }
  [JsonPropertyName("genre_ids")]
  public List<int>? GenreIds { get; set; }
  [JsonPropertyName("id")]
  public int Id { get; set; }
  [JsonPropertyName("original_language")]
  public string? OriginalLanguage { get; set; }
  [JsonPropertyName("original_name")]
  public string? OriginalName { get; set; }
  [JsonPropertyName("overview")]
  public string? Overview { get; set; }
  [JsonPropertyName("popularity")]
  public double Popularity { get; set; }
  [JsonPropertyName("poster_path")]
  public string? PosterPath { get; set; }
  [JsonPropertyName("release_date")]
  public DateTime ReleaseDate { get; set; }
  [JsonPropertyName("vote_average")]
  public double VoteAverage { get; set; }
  [JsonPropertyName("vote_count")]
  public int VoteCount { get; set; }
  [JsonPropertyName("origin_country")]
  public List<string>? OriginCountry { get; set; }
  [JsonPropertyName("first_air_date")]
  public DateTime FirstAirDate { get; set; }
  [JsonPropertyName("name")]
  public string? Name { get; set; }
}

public class TvResponse : IMediaResponse<Tv>
{
  [JsonPropertyName("page")]
  public int Page { get; set; }
  [JsonPropertyName("results")]
  public List<Tv>? Results { get; set; }
  [JsonPropertyName("total_pages")]
  public int TotalPages { get; set; }
  [JsonPropertyName("total_results")]
  public int TotalResults { get; set; } 
}