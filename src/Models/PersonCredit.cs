using Newtonsoft.Json;

namespace MovieAppApi.Models;

public class PersonMovieCredit
{
  [JsonProperty("cast")]
  public List<MovieCast> Cast { get; } = [];

  [JsonProperty("crew")]
  public List<MovieCrew> Crew { get; } = [];

  [JsonProperty("id")]
  public long Id { get; set; }
}

public class PersonTvCredit
{
  [JsonProperty("cast")]
  public List<TvCast> Cast { get; } = [];

  [JsonProperty("crew")]
  public List<TvCrew> Crew { get; } = [];

  [JsonProperty("id")]
  public long Id { get; set; }
}

public class BaseCredit
{
  [JsonProperty("adult")]
  public bool Adult { get; set; }

  [JsonProperty("backdrop_path")]
  public string? BackdropPath { get; set; }

  [JsonProperty("genre_ids")]
  public List<long> GenreIds { get; } = [];

  [JsonProperty("id")]
  public long Id { get; set; }

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
  public long VoteCount { get; set; }

  [JsonProperty("credit_id")]
  public string? CreditId { get; set; }
}

public class BaseMovieCredit : BaseCredit
{ 
  [JsonProperty("original_title")]
  public string? OriginalTitle { get; set; }

  [JsonProperty("title")]
  public string? Title { get; set; }

  [JsonProperty("video")]
  public bool Video { get; set; }

  [JsonProperty("release_date")]
  public DateTime? ReleaseDate { get; set; }
}

public class BaseTvCredit : BaseCredit
{
  [JsonProperty("origin_country")]
  public List<string>? OriginCountry { get; set; }

  [JsonProperty("original_name")]
  public string? OriginalName { get; set; }

  [JsonProperty("first_air_date")]
  public DateTime? FirstAirDate { get; set; }

  [JsonProperty("name")]
  public string? Name { get; set; }

  [JsonProperty("episode_count")]
  public int EpisodeCount { get; set; }
}

public class MovieCast : BaseMovieCredit
{
  [JsonProperty("order")]
  public long? Order { get; set; }

  [JsonProperty("character")]
  public string? Character { get; set; }

}

public class MovieCrew  : BaseMovieCredit
{
  [JsonProperty("department")]
  public string? Department { get; set; }
  
  [JsonProperty("job")]
  public string? Job { get; set; } 
}

public class TvCast : BaseTvCredit
{
  [JsonProperty("character")]
  public string? Character { get; set; }
}

public class TvCrew : BaseTvCredit
{
  [JsonProperty("department")]
  public string? Department { get; set; }
    
  [JsonProperty("job")]
  public string? Job { get; set; } 
}