using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MovieAppApi.Converters;

namespace MovieAppApi.Models;

public class BasePerson 
{
  [JsonProperty("adult")]
  public bool Adult { get; set; }

  [JsonProperty("gender")]
  public long Gender { get; set; }

  [JsonProperty("id")]
  public long Id { get; set; }

  [JsonProperty("known_for_department")]
  public string? KnownForDepartment { get; set; }

  [JsonProperty("name")]
  public string? Name { get; set; }

  [JsonProperty("original_name")]
  public string? OriginalName { get; set; }

  [JsonProperty("popularity")]
  public double Popularity { get; set; }

  [JsonProperty("profile_path")]
  public string? ProfilePath { get; set; }
}

public class MediaAppearances
{
  public List<Movie> Movies { get; set; } = [];
  public List<Tv> TvSeries { get; set; } = [];
}

public class Person : BasePerson {
  [JsonProperty("known_for")]
  [JsonConverter(typeof(KnownForConverter))]
  public MediaAppearances? KnownFor { get; set; }
}

public class PersonDetails : BasePerson
{
  [JsonProperty("also_known_as")]
  public List<string>? AlsoKnownAs { get; set; }

  [JsonProperty("biography")]
  public string? Biography { get; set; }

  [JsonProperty("birthday")]
  public DateTime? Birthday { get; set; }

  [JsonProperty("deathday")]
  public DateTime? Deathday { get; set; }

  [JsonProperty("homepage")]
  public string? Homepage { get; set; }

  [JsonProperty("imdb_id")]
  public string? ImdbId { get; set; }

  [JsonProperty("place_of_birth")]
  public string? PlaceOfBirth { get; set; }
}

public class PersonResponse : IMediaResponse<Person>
{
  [JsonProperty("page")]
  public int Page { get; set; }
  [JsonProperty("results")]
  public List<Person> Results { get; } = [];
  [JsonProperty("total_pages")]
  public int TotalPages { get; set; }
  [JsonProperty("total_results")]
  public int TotalResults { get; set; }
}