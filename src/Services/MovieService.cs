namespace MovieAppApi.Services;

using MovieAppApi.Exceptions;
using MovieAppApi.Models;
using RestSharp;

public class MovieService : ApiServiceBase, IMediaService
{
  public async Task<IResult> GetAll()
  {
    try 
    {
      var request = new RestRequest("/discover/movie");
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response); 
    } 
    catch (RequestException ex) 
    {
      return Results.NotFound(ex.Message);
    }
  }

  public async Task<IResult> GetAll(int page = 1, string genres = "", string sortBy = "popularity.desc")
  {
    try 
    {
      var request = new RestRequest("/discover/movie");
      request.AddParameter("page", page);
      request.AddParameter("with_genres", genres);
      request.AddParameter("sort_by", sortBy);
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response); 
    } 
    catch (RequestException ex) 
    {
      return Results.NotFound(ex.Message);
    }
  }

  public async Task<IResult> GetTrending(TimeWindowEnum? timeWindow, int page = 1)
  {
    try 
    {
      var request = new RestRequest($"/trending/movie/{timeWindow ?? TimeWindowEnum.day}");
      request.AddParameter("page", page);
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response); 
    } 
    catch (RequestException ex) 
    {
      return Results.NotFound(ex.Message);
    }
  }

  public async Task<IResult> GetPopular()
  {
    try 
    {
      var request = new RestRequest("/movie/popular");
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response); 
    } 
    catch (RequestException ex) 
    {
      return Results.NotFound(ex.Message);
    }
  }

  public async Task<IResult> GetDetails(int id) {
    try 
    {
      var request = new RestRequest($"/movie/{id}");
      var response = await HandleRequest<MovieDetails>(request);
      return Results.Ok(response); 
    } 
    catch (RequestException ex) 
    {
      return Results.NotFound(ex.Message);
    }
  }

  public async Task<IResult> GetRecommendations(int id)
  {
    try {
      var request = new RestRequest($"/movie/{id}/recommendations");
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response);
    } 
    catch(RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  public async Task<IResult> GetImageGallery(int id)
  {
    try {
      var request = new RestRequest($"/movie/{id}/images");
      var response = await HandleRequest<ImageGallery>(request);
      return Results.Ok(response);
    }
    catch(RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  public async Task<IResult> GetVideoGallery(int id)
  {
    try {
      var request = new RestRequest($"/movie/{id}/videos");
      var response = await HandleRequest<VideoGallery>(request);
      return Results.Ok(response);
    }
    catch(RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  public async Task<IResult> Search(string query, int page = 1)
  {
    try {
      var request = new RestRequest("/search/movie");
      request.AddParameter("query", query);
      request.AddParameter("page", page);
      var response = await HandleRequest<MovieResponse>(request);
      return Results.Ok(response);
    } 
    catch (RequestException ex)
    {
      return Results.NotFound(ex.Message);
    }
  }

  public async Task<IResult> GetGenres() {
    try {
      var request = new RestRequest("/genre/movie/list");
      var response = await HandleRequest<GenreResponse>(request);
      return Results.Ok(response);
    } catch (RequestException ex) {
      return Results.NotFound(ex.Message);
    }
  }
}