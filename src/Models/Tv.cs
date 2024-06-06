using Newtonsoft.Json;

namespace MovieAppApi.Models;

public class Tv : ITv
{
  [JsonProperty("adult")]
  public bool Adult { get; set; }
  [JsonProperty("backdrop_path")]
  public string? BackdropPath { get; set; }
  [JsonProperty("genre_ids")]
  public List<int>? GenreIds { get; set; }
  [JsonProperty("id")]
  public int Id { get; set; }
  [JsonProperty("original_language")]
  public string? OriginalLanguage { get; set; }
  [JsonProperty("original_name")]
  public string? OriginalName { get; set; }
  [JsonProperty("overview")]
  public string? Overview { get; set; }
  [JsonProperty("popularity")]
  public double Popularity { get; set; }
  [JsonProperty("poster_path")]
  public string? PosterPath { get; set; }
  [JsonProperty("vote_average")]
  public double VoteAverage { get; set; }
  [JsonProperty("vote_count")]
  public int VoteCount { get; set; }
  [JsonProperty("origin_country")]
  public List<string>? OriginCountry { get; set; }
  [JsonProperty("first_air_date")]
  public DateTime? FirstAirDate { get; set; }
  [JsonProperty("name")]
  public string? Name { get; set; }
}

public class TvDetails : ITv, IWithGenres<Genre>
{
  [JsonProperty("adult")]
  public bool Adult { get; set; }
  [JsonProperty("backdrop_path")]
  public string? BackdropPath { get; set; }
  [JsonProperty("created_by")]
  public List<Producer>? CreatedBy { get; set; }
  [JsonProperty("episode_run_time")]
  public List<int>? EpisodeRunTime { get; set; }
  [JsonProperty("homepage")]
  public Uri? HomePage { get; set; }
  [JsonProperty("in_production")]
  public bool InProduction { get; set; }
  [JsonProperty("languages")]
  public List<string>? Languages { get; set; }
  [JsonProperty("last_episode_to_air")]
  public Episode? LastEpisodeToAir { get; set; }
  [JsonProperty("next_episode_to_air")]
  public Episode? NextEpisodeToAir { get; set; }
  [JsonProperty("networks")]
  public List<Network>? Networks { get; set; }
  [JsonProperty("number_of_episodes")]
  public int NumberOfEpisodes { get; set; }
  [JsonProperty("number_of_seasons")]
  public int NumberOfSeasons { get; set; }
  [JsonProperty("production_companies")]
  public List<ProductionCompany>? ProductionCompanies { get; set; }
  [JsonProperty("production_countries")]
  public List<ProductionCountry>? ProductionCountries { get; set; }
  [JsonProperty("spoken_languages")]
  public List<SpokenLanguage>? SpokenLanguages { get; set; }
  [JsonProperty("status")]
  public string? Status { get; set; }
  [JsonProperty("tagline")] 
  public string? Tagline { get; set; }
  [JsonProperty("type")]
  public string? Type { get; set; }
  [JsonProperty("genres")]
  public List<Genre>? Genres { get; set; }
  [JsonProperty("name")]
  public string? Name { get; set; }
  [JsonProperty("original_name")]
  public string? OriginalName { get; set; }
  [JsonProperty("origin_country")]
  public List<string>? OriginCountry { get; set; }
  [JsonProperty("first_air_date")]
  public DateTime? FirstAirDate { get; set; }
  [JsonProperty("last_air_date")]
  public DateTime? LastAirDate { get; set; }
  [JsonProperty("id")]
  public int Id { get; set; }
  [JsonProperty("original_language")]
  public string? OriginalLanguage { get; set; }
  [JsonProperty("overview")]
  public string? Overview { get; set; }
  [JsonProperty("popularity")]
  public double Popularity { get; set; }
  [JsonProperty("poster_path")]
  public string? PosterPath { get; set; }
  [JsonProperty("vote_average")]
  public double VoteAverage { get; set; }
  [JsonProperty("vote_count")]
  public int VoteCount { get; set; }
  [JsonProperty("seasons")]
  public List<Season>? Seasons { get; set; }
}

public class TvResponse : IMediaResponse<Tv>
{
  [JsonProperty("page")]
  public int Page { get; set; }
  [JsonProperty("results")]
  public List<Tv> Results { get; } = [];
  [JsonProperty("total_pages")]
  public int TotalPages { get; set; }
  [JsonProperty("total_results")]
  public int TotalResults { get; set; } 
}