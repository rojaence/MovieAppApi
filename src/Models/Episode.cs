using Newtonsoft.Json;

namespace MovieAppApi.Models;

public class Episode
{
  [JsonProperty("id")]
  public int Id { get; set; }
  [JsonProperty("overview")]
  public string? Overview { get; set; }
  [JsonProperty("name")]
  public string? Name { get; set; }
  [JsonProperty("vote_average")]
  public double VoteAverage { get; set; }
  [JsonProperty("vote_count")]
  public int VoteCount { get; set; }
  [JsonProperty("air_date")]
  public DateTime? AirDate { get; set; }
  [JsonProperty("episode_number")]
  public int EpisodeNumber { get; set; }
  [JsonProperty("episode_type")]
  public string? EpisodeType { get; set; }
  [JsonProperty("production_code")]
  public string? ProductionCode { get; set; }
  [JsonProperty("runtime")]
  public int? Runtime { get; set; }
  [JsonProperty("season_number")]
  public int SeasonNumber { get; set; }
  [JsonProperty("show_id")]
  public int ShowId { get; set; }
  [JsonProperty("still_path")]
  public string? StillPath { get; set; }
}