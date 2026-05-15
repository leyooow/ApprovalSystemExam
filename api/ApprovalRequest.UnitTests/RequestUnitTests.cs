using ApprovalRequest.Application.DTOs.Common;
using ApprovalRequest.Application.DTOs.Request;
using ApprovalRequest.Application.Interfaces.Repositories;
using ApprovalRequest.Application.Services;
using ApprovalRequest.Domain.Entities;
using ApprovalRequest.Domain.Enums;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.Common;
using Moq;
using Xunit;

public class RequestUnitTests
{
    private readonly Mock<IRequestRepository> _repoMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ILogger<RequestService>> _loggerMock;
    private readonly RequestService _service;

    public RequestUnitTests()
    {
        _repoMock = new Mock<IRequestRepository>();
        _mapperMock = new Mock<IMapper>();
        _loggerMock = new Mock<ILogger<RequestService>>();

        _service = new RequestService(
            _repoMock.Object,
            _mapperMock.Object,
            _loggerMock.Object
        );
    }

    [Fact]
    public async Task CreateAsync_Should_Create_Request()
    {
        // Arrange
        var dto = new CreateRequestDto { Title = "Test" };
        var entity = new Request();
        var mappedDto = new RequestDto();

        _mapperMock.Setup(x => x.Map<Request>(dto)).Returns(entity);
        _mapperMock.Setup(x => x.Map<RequestDto>(entity)).Returns(mappedDto);

        // Act
        var result = await _service.CreateAsync(dto);

        // Assert
        result.Success.Should().BeTrue();
        result.StatusCode.Should().Be(201);
        result.Data.Should().NotBeNull();

        _repoMock.Verify(x => x.AddAsync(entity), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_Should_Return_404_When_NotFound()
    {
        _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                 .ReturnsAsync((Request)null);

        var result = await _service.GetByIdAsync(Guid.NewGuid());

        result.StatusCode.Should().Be(404);
        result.Success.Should().BeFalse();
    }

    [Fact]
    public async Task GetByIdAsync_Should_Return_Data_When_Found()
    {
        var entity = new Request();
        var dto = new RequestDto();

        _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                 .ReturnsAsync(entity);

        _mapperMock.Setup(x => x.Map<RequestDto>(entity))
                   .Returns(dto);

        var result = await _service.GetByIdAsync(Guid.NewGuid());

        result.Success.Should().BeTrue();
        result.Data.Should().Be(dto);
    }

    [Fact]
    public async Task ApprovalAsync_Should_Approve_Request()
    {
        var entity = new Request { Status = RequestStatus.Pending };

        _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                 .ReturnsAsync(entity);

        var dto = new ApprovalActionDto
        {
            ReviewedBy = "lead",
            ApprovalAction = RequestStatus.Approved
        };

        var result = await _service.ApprovalAsync(Guid.NewGuid(), dto);

        result.Success.Should().BeTrue();
        entity.Status.Should().Be(RequestStatus.Approved);

        _repoMock.Verify(x => x.UpdateAsync(entity), Times.Once);
    }

    [Fact]
    public async Task ApprovalAsync_Should_Reject_Request()
    {
        var entity = new Request { Status = RequestStatus.Pending };

        _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                 .ReturnsAsync(entity);

        var dto = new ApprovalActionDto
        {
            ReviewedBy = "lead",
            ApprovalAction = RequestStatus.Rejected
        };

        var result = await _service.ApprovalAsync(Guid.NewGuid(), dto);

        result.Success.Should().BeTrue();
        entity.Status.Should().Be(RequestStatus.Rejected);
    }

    [Fact]
    public async Task ApprovalAsync_Should_Return_404_When_NotFound()
    {
        _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                 .ReturnsAsync((Request)null);

        var result = await _service.ApprovalAsync(Guid.NewGuid(), new ApprovalActionDto());

        result.StatusCode.Should().Be(404);
    }
}