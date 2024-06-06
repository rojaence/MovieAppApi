using Newtonsoft.Json;

namespace MovieAppApi.Models;

public class Movie : IMovie, IWithGenres<long>
{
  [JsonProperty("adult")]
  public bool Adult { get; set; }
  [JsonProperty("backdrop_path")]
  public string? BackdropPath { get; set; }
  [JsonProperty("genre_ids")]
  public List<long>? Genres { get; set; }
  [JsonProperty("id")]
  public int Id { get; set; }
  [JsonProperty("original_language")]
  public string? OriginalLanguage { get; set; }
  [JsonProperty("original_title")]
  public string? OriginalTitle { get; set; }
  [JsonProperty("overview")]
  public string? Overview { get; set; }
  [JsonProperty("popularity")]
  public double Popularity { get; set; }
  [JsonProperty("poster_path")]
  public string? PosterPath { get; set; }
  [JsonProperty("release_date")]
  public DateTime? ReleaseDate { get; set; }
  [JsonProperty("title")]
  public string? Title { get; set; }
  [JsonProperty("vote_average")]
  public double VoteAverage { get; set; }
  [JsonProperty("vote_count")]
  public int VoteCount { get; set; }
  [JsonProperty("video")]
  public bool Video { get; set; }
  [JsonProperty("media_type")]
  public MediaTypeEnum MediaType { get; set; }
}

public class MovieResponse : IMediaResponse<Movie>
{
  [JsonProperty("page")]
  public int Page { get; set; }
  [JsonProperty("results")]
  public List<Movie> Results { get; } = [];
  [JsonProperty("total_pages")]
  public int TotalPages { get; set; }
  [JsonProperty("total_results")]
  public int TotalResults { get; set; }
}

public class MovieDetails : IMovie, IMovieDetails<ProductionCompany, ProductionCountry, SpokenLanguage>, IWithGenres<Genre>
{
  [JsonProperty("adult")]
  public bool Adult { get; set; }
  [JsonProperty("backdrop_path")]
  public string? BackdropPath { get; set; }
  [JsonProperty("id")]
  public int Id { get; set; }
  [JsonProperty("original_language")]
  public string? OriginalLanguage { get; set; }
  [JsonProperty("original_title")]
  public string? OriginalTitle { get; set; }
  [JsonProperty("overview")]
  public string? Overview { get; set; }
  [JsonProperty("popularity")]
  public double Popularity { get; set; }
  [JsonProperty("poster_path")]
  public string? PosterPath { get; set; }
  [JsonProperty("release_date")]
  public DateTime? ReleaseDate { get; set; }
  [JsonProperty("title")]
  public string? Title { get; set; }
  [JsonProperty("vote_average")]
  public double VoteAverage { get; set; }
  [JsonProperty("vote_count")]
  public int VoteCount { get; set; }
  [JsonProperty("video")]
  public bool Video { get; set; }
  [JsonProperty("homepage")]
  public Uri? Homepage { get; set; }
  [JsonProperty("imdb_id")]
  public string? ImdbId { get; set; }
  [JsonProperty("budget")]
  public long Budget { get; set; }
  [JsonProperty("production_companies")]
  public List<ProductionCompany>? ProductionCompanies { get; set; }
  [JsonProperty("production_countries")]
  public List<ProductionCountry>? ProductionCountries { get; set; }
  [JsonProperty("revenue")]
  public long Revenue { get; set; }
  [JsonProperty("runtime")]
  public long Runtime { get; set; }
  [JsonProperty("spoken_languages")]
  public List<SpokenLanguage>? SpokenLanguages { get; set; }
  [JsonProperty("status")]
  public string? Status { get; set; }
  [JsonProperty("tagline")]
  public string? Tagline { get; set; }
  [JsonProperty("genres")]
  public List<Genre>? Genres { get; set;}
  [JsonProperty("belongs_to_collection")]
  public Collection? BelongsToCollection { get; set; }
}