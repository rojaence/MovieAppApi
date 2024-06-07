using Microsoft.AspNetCore.Http.HttpResults;
using MovieAppApi.Services;
using MovieAppApi.EnvConfig;
using MovieAppApi.Models;

namespace MovieAppApi.UnitTests;

public class TvServiceTests
{

  readonly TvService Service;

  public TvServiceTests()
  {
    DotEnv.Load("/workspaces/MovieAppApiContainer/src");
    Service = new TvService();
  }

  [Fact]
  public async Task GetAllTvSeries()
  {
    var response = await Service.GetAll();
    var tvResponse = Assert.IsType<Ok<TvResponse>>(response);
    Assert.NotEmpty(tvResponse.Value!.Results);
    Assert.Equal(1, tvResponse.Value!.Page);
  }

  [Fact]
  public async Task GetTrending()
  {
    var response = await Service.GetTrending(TimeWindowEnum.week);
    var tvResponse = Assert.IsType<Ok<TvResponse>>(response);
    Assert.NotEmpty(tvResponse.Value!.Results);
    Assert.Equal(1, tvResponse.Value!.Page);
  }

  [Fact]
  public async Task GetDetails()
  {
    var response = await Service.GetDetails(25);
    var details = Assert.IsType<Ok<TvDetails>>(response);
    Assert.Equal("Star Wars: Droids", details.Value!.OriginalName);
    Assert.Equal(25, details.Value!.Id);
  }

  [Fact]
  public async Task GetDetailsNotFound()
  {
    var response = await Service.GetDetails(-1);
    Assert.IsType<NotFound<string>>(response);
  }

  [Fact]
  public async Task GetRecommendations()
  {
    var response = await Service.GetRecommendations(25);
    var TvResponse = Assert.IsType<Ok<TvResponse>>(response);
    Assert.NotEmpty(TvResponse.Value!.Results);
    Assert.Equal(1, TvResponse.Value!.Page);
  }
  
  [Fact]
  public async Task GetRecommendationsEmpty()
  {
    var response = await Service.GetRecommendations(5000);
    var TvResponse = Assert.IsType<Ok<TvResponse>>(response);
    Assert.Empty(TvResponse.Value!.Results);
    Assert.Equal(1, TvResponse.Value!.Page);
    Assert.Equal(0, TvResponse.Value!.TotalPages);
    Assert.Equal(0, TvResponse.Value!.TotalResults);
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
    var response = await Service.GetImageGallery(-1);
    Assert.IsType<NotFound<string>>(response);
  }

  [Fact]
  public async Task GetVideos()
  {
    var response = await Service.GetVideoGallery(100);
    var imageGallery = Assert.IsType<Ok<VideoGallery>>(response);
    Assert.NotEmpty(imageGallery.Value!.Results);
    Assert.Equal(100, imageGallery.Value!.Id);
  }

  [Fact]
  public async Task GetVideosNotFound()
  {
    var response = await Service.GetVideoGallery(-1);
    Assert.IsType<NotFound<string>>(response);
  }
}

