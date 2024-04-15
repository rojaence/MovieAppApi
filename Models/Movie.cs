using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace MovieAppApi.Models;

public class Movie : IMovie, IWithGenres<long>
{
  [JsonPropertyName("adult")]
  public bool Adult { get; set; }
  [JsonPropertyName("backdrop_path")]
  public string? BackdropPath { get; set; }
  [JsonPropertyName("genre_ids")]
  public List<long>? Genres { get; set; }
  [JsonPropertyName("id")]
  public int Id { get; set; }
  [JsonPropertyName("original_language")]
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
  [JsonPropertyName("video")]
  public bool Video { get; set; }
  [JsonPropertyName("media_type")]
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public MediaTypeEnum MediaType { get; set; }
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

public class MovieDetails : IMovie, IMovieDetails<ProductionCompany, ProductionCountry, SpokenLanguage>, IWithGenres<Genre>
{
  [JsonPropertyName("adult")]
  public bool Adult { get; set; }
  [JsonPropertyName("backdrop_path")]
  public string? BackdropPath { get; set; }
  [JsonPropertyName("id")]
  public int Id { get; set; }
  [JsonPropertyName("original_language")]
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
  [JsonPropertyName("video")]
  public bool Video { get; set; }
  [JsonPropertyName("homepage")]
  public Uri? Homepage { get; set; }
  [JsonPropertyName("imdb_id")]
  public string? ImdbId { get; set; }
  [JsonPropertyName("budget")]
  public long Budget { get; set; }
  [JsonPropertyName("production_companies")]
  public List<ProductionCompany>? ProductionCompanies { get; set; }
  [JsonPropertyName("production_countries")]
  public List<ProductionCountry>? ProductionCountries { get; set; }
  [JsonPropertyName("revenue")]
  public long Revenue { get; set; }
  [JsonPropertyName("runtime")]
  public long Runtime { get; set; }
  [JsonPropertyName("spoken_languages")]
  public List<SpokenLanguage>? SpokenLanguages { get; set; }
  [JsonPropertyName("status")]
  public string? Status { get; set; }
  [JsonPropertyName("tagline")]
  public string? Tagline { get; set; }
  [JsonPropertyName("genres")]
  public List<Genre>? Genres { get; set;}
  [JsonPropertyName("belongs_to_collection")]
  public Collection? BelongsToCollection { get; set; }
}