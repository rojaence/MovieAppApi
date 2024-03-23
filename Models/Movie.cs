using System.Text.Json.Serialization;

namespace MovieAppApi.Models;

public class Movie : IMovie
{
  [JsonPropertyName("adult")]
  public bool Adult { get; set; }
  [JsonPropertyName("backdrop_path")]
  public string? BackdropPath { get; set; }
  [JsonPropertyName("genre_ids")]
  public List<int>? GenreIds { get; set; }
  [JsonPropertyName("id")]
  public int Id { get; set; }
  [JsonPropertyName("original_languages")]
  public string? OriginalLanguage { get; set; }
  [JsonPropertyName("original_title")]
  public string? OriginalTitle { get; set; }
  [JsonPropertyName("overview")]
  public string? Overview { get; set; }
  [JsonPropertyName("popularity")]
  public double Popularity { get; set; }
  [JsonPropertyName("poster_path")]
  public string? PosterPath { get; set; }
  [JsonPropertyName("release_date")]
  public DateTime ReleaseDate { get; set; }
  [JsonPropertyName("title")]
  public string? Title { get; set; }
  [JsonPropertyName("vote_average")]
  public double VoteAverage { get; set; }
  [JsonPropertyName("vote_count")]
  public int VoteCount { get; set; }
}

public class MovieResponse : IMediaResponse<Movie>
{
  [JsonPropertyName("page")]
  public int Page { get; set; }
  [JsonPropertyName("results")]
  public List<Movie>? Results { get; set; }
  [JsonPropertyName("total_pages")]
  public int TotalPages { get; set; }
  [JsonPropertyName("total_results")]
  public int TotalResults { get; set; }
}