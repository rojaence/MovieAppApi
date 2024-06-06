using Microsoft.AspNetCore.Http.HttpResults;
using MovieAppApi.Services;
using MovieAppApi.EnvConfig;
using MovieAppApi.Models;

namespace MovieAppApi.UnitTests;

public class MovieServiceTests
{

  readonly MovieService Service;

  public MovieServiceTests()
  {
    DotEnv.Load("/workspaces/MovieAppApiContainer/src");
    Service = new MovieService();
  }

  [Fact]
  public async Task GetAllMovies()
  {
    var response = await Service.GetAll();
    var movieResponse = Assert.IsType<Ok<MovieResponse>>(response);
    Assert.NotEmpty(movieResponse.Value!.Results);
    Assert.Equal(1, movieResponse.Value!.Page);
  }

  [Fact]
  public async Task GetTrending()
  {
    var response = await Service.GetTrending(TimeWindowEnum.week);
    var movieResponse = Assert.IsType<Ok<MovieResponse>>(response);
    Assert.NotEmpty(movieResponse.Value!.Results);
    Assert.Equal(1, movieResponse.Value!.Page);
  }

  [Fact]
  public async Task GetDetails()
  {
    var response = await Service.GetDetails(25);
    var details = Assert.IsType<Ok<MovieDetails>>(response);
    Assert.Equal("Jarhead", details.Value!.OriginalTitle);
    Assert.Equal(25, details.Value!.Id);
  }

  [Fact]
  public async Task GetDetailsNotFound()
  {
    var response = await Service.GetDetails(10);
    Assert.IsType<NotFound<string>>(response);
  }

  [Fact]
  public async Task GetRecommendations()
  {
    var response = await Service.GetRecommendations(25);
    var movieResponse = Assert.IsType<Ok<MovieResponse>>(response);
    Assert.NotEmpty(movieResponse.Value!.Results);
    Assert.Equal(1, movieResponse.Value!.Page);
  }
  
  [Fact]
  public async Task GetRecommendationsEmpty()
  {
    var response = await Service.GetRecommendations(10);
    var movieResponse = Assert.IsType<Ok<MovieResponse>>(response);
    Assert.Empty(movieResponse.Value!.Results);
    Assert.Equal(1, movieResponse.Value!.Page);
    Assert.Equal(0, movieResponse.Value!.TotalPages);
    Assert.Equal(0, movieResponse.Value!.TotalResults);
  }

  [Fact]
  public async Task GetImages()
  {
    var response = await Service.GetImageGallery(25);
    var imageGallery = Assert.IsType<Ok<ImageGallery>>(response);
    Assert.NotEmpty(imageGallery.Value!.Backdrops);
    Assert.Equal(25, imageGallery.Value!.Id);
  }

  [Fact]
  public async Task GetImagesNotFound()
  {
    var response = await Service.GetImageGallery(10);
    Assert.IsType<NotFound<string>>(response);
  }

  [Fact]
  public async Task GetVideos()
  {
    var response = await Service.GetVideoGallery(25);
    var imageGallery = Assert.IsType<Ok<VideoGallery>>(response);
    Assert.NotEmpty(imageGallery.Value!.Results);
    Assert.Equal(25, imageGallery.Value!.Id);
  }

  [Fact]
  public async Task GetVideosNotFound()
  {
    var response = await Service.GetVideoGallery(10);
    Assert.IsType<NotFound<string>>(response);
  }
}

