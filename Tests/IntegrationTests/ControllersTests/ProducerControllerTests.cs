using FluentAssertions;
using GameBoardShop.Models;
using GameBoardShop.ViewModels;
using IntegrationTests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace IntegrationTests.ControllersTests;

public class ProducerControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private HttpClient _client;
    private CustomWebApplicationFactory<Program> _factory;
    private string _baseUrl = "/api/Producer";
    private string _notFoundUrl = "/api/Error/404";
    private string _moreThan50Char = "Lorem ipsum dolor sit amet, consectetuer elitarumon";

    private void SeedProducer(Producer producer)
    {
        var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        using var scope = scopeFactory!.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<GameBoardShopContext>();
        dbContext!.Add(producer);
        dbContext.SaveChanges();
    }
    
    public ProducerControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task Index_ForValidRequest_ReturnsOkResult()
    {
        //act
        var response = await _client.GetAsync(_baseUrl);

        //assert
        response.Should().HaveStatusCode(System.Net.HttpStatusCode.OK);
    }

    [Fact]
    public async Task Delete_ForNonExsistingProducer_RedirectsToErrorUriAndReturnsOkResult()
    {
        //arrange
        var randomGuid= Guid.NewGuid();
        string? uriAfterRedirect;
       
        //act
        var response = await _client.PostAsync(_baseUrl + $"/delete/{randomGuid}", null);
        uriAfterRedirect = response?.RequestMessage?.RequestUri?.AbsolutePath;

        //assert
        response.Should().HaveStatusCode(System.Net.HttpStatusCode.OK);
        uriAfterRedirect.Should().Be(_notFoundUrl);
    }

    [Fact]
    public async Task Delete_ForExsistingProducer_ReturnsOkResult()
    {
        //arrange
        string? uriAfterRedirect;
        var producer = new Producer() { CreatedAt=DateTime.UtcNow, Name="ProducerName" };
        SeedProducer(producer);

        //act
        var response = await _client.PostAsync(_baseUrl + $"/delete/{producer.Id}", null);
        uriAfterRedirect = response?.RequestMessage?.RequestUri?.AbsolutePath;

        //assert
        response.Should().HaveStatusCode(System.Net.HttpStatusCode.OK);
        uriAfterRedirect.Should().Be($"{_baseUrl}");
    }

    [Fact]
    public async Task Details_ForNonExsistingProducer_RedirectsToErrorUriAndReturnsOkResult()
    {
        //arrange
        var randomGuid = Guid.NewGuid();
        string? uriAfterRedirect;

        //act
        var response = await _client.GetAsync(_baseUrl + $"/details/{randomGuid}");
        uriAfterRedirect = response?.RequestMessage?.RequestUri?.AbsolutePath;

        //assert
        response.Should().HaveStatusCode(System.Net.HttpStatusCode.OK);
        uriAfterRedirect.Should().Be(_notFoundUrl);
    }

    [Fact]
    public async Task Details_ForExsistingProducer_ReturnsOkResult()
    {
        //arrange
        var producer = new Producer() { CreatedAt = DateTime.UtcNow, Name = "ProducerName" };
        SeedProducer(producer);

        //act
        var response = await _client.GetAsync(_baseUrl + $"/details/{producer.Id}");

        //assert
        response.Should().HaveStatusCode(System.Net.HttpStatusCode.OK);
    }

    [Fact]
    public async Task Create_ForInvalidModel_ReturnsValidationErrorAndReturnsOkResult()
    {
        //arrange 
        var newProducer = new NewProducerVM() { Name =_moreThan50Char };
        var httpContent = newProducer.ToFormUrlEncodedContent();
        string? responseString;

        //act
        var response = await _client.PostAsync(_baseUrl + $"/create", httpContent);
        responseString = await response.Content.ReadAsStringAsync();

        //assert
        response.Should().HaveStatusCode(System.Net.HttpStatusCode.OK);
        responseString.Should().Contain("Name&#x27; must be 50 characters or fewer.");
    }

}

