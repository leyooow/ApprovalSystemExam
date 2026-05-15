using ApprovalRequest.Application.DTOs.Common;
using ApprovalRequest.Application.DTOs.Request;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using Xunit;

public class RequestIntegrationTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public RequestIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Create_Should_Return_201()
    {
        var dto = new CreateRequestDto
        {
            Title = "Integration Test",
            Description = "Test",
            RequestedBy = "Leo"
        };

        var response = await _client.PostAsJsonAsync("/api/approval", dto);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task GetById_Should_Return_404_If_NotFound()
    {
        var id = Guid.NewGuid();

        var response = await _client.GetAsync($"/api/approval/{id}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task FullFlow_Create_Then_Approve_Should_Work()
    {
        // Create
        var createDto = new CreateRequestDto
        {
            Title = "Flow Test",
            Description = "Flow",
            RequestedBy = "Leo"
        };

        var createResponse = await _client.PostAsJsonAsync("/api/approval", createDto);
        var created = await createResponse.Content.ReadFromJsonAsync<ApiResponse<RequestDto>>();

        // Approve
        var approveDto = new ApprovalActionDto
        {
            ReviewedBy = "Admin"
        };

        var approveResponse = await _client.PutAsJsonAsync(
            $"/api/approval/{created!.Data.Id}/approve",
            approveDto);

        approveResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}