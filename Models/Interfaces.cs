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

public interface IMovieDetails<TCompany, TCountry, TLanguage> : IMovie {
  Uri? Homepage { get; set; }
  string? ImdbId { get; set; }
  long Budget { get; set; }
  List<TCompany>? ProductionCompanies { get; set; }
  List<TCountry>? ProductionCountries { get; set; }
  long Revenue { get; set; }
  long Runtime { get; set; }
  List<TLanguage>? SpokenLanguages { get; set; }
  string? Status { get; set; }
  string? Tagline { get; set; }
}

public interface IProductionCompany {
  long Id { get; set;}
  string? LogoPath { get; set;}
  string? Name { get; set;}
  string? OriginCountry { get; set;}

}

public interface IProductionCountry {
  string? Iso3166_1 { get; set;}
  string? Name { get; set;}
}

public interface ISpokenLanguage {
  string? EnglishName { get; set;}
  string? Iso639_1 { get; set;}
  string? Name { get; set;}
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