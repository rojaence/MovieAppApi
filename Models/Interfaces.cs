namespace MovieAppApi.Models;

using System;
using System.Collections.Generic;

public interface IMedia
{
    public bool Adult { get; set; }
    public string? BackdropPath { get; set; }
    public List<int>? GenreIds { get; set; }
    public int Id { get; set; }
    public string? OriginalLanguage { get; set; }
    public string? Overview { get; set; }
    public double Popularity { get; set; }
    public string? PosterPath { get; set; }
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }
}

public interface IMovie : IMedia {
  public string? Title { get; set; }
  public string? OriginalTitle { get; set; }
  public DateTime ReleaseDate { get; set; }
  public bool Video { get; set; }
}

public interface ITv : IMedia {
  public string? Name { get; set; }
  public string? OriginalName { get; set; }
  List<string>? OriginCountry { get; set; }
  DateTime FirstAirDate { get; set; }
}

public interface IMediaResponse<TMedia>
{
  public int Page { get; set; }
  public List<TMedia>? Results { get; set; }
  public int TotalPages { get; set; }
  public int TotalResults { get; set; }
}

public interface IMediaService<TResponse>
{
  Task<TResponse> GetAll();
  Task<TResponse> GetTrending(TimeWindowEnum? timeWindow);
  Task<TResponse> GetPopular();
}