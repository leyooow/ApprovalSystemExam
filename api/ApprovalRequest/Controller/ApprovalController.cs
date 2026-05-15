using ApprovalRequest.Application.DTOs.Common;
using ApprovalRequest.Application.DTOs.Request;
using ApprovalRequest.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApprovalRequest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApprovalController : ControllerBase
{
    private readonly IRequestService _requestService;

    public ApprovalController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    /// <summary>
    /// Create new request
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<RequestDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateRequestDto request)
    {
        var result = await _requestService.CreateAsync(request);

        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Get request by ID
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<RequestDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _requestService.GetByIdAsync(id);

        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Get all requests with pagination
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<RequestDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPaginatedDataAsync(int pageNumber = 1, int pageSize = 10)
    {
        var result = await _requestService.GetPaginatedDataAsync(pageNumber, pageSize);

        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Approve request
    /// </summary>
    [HttpPut("{id:guid}/approve")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Approve(Guid id, [FromBody] ApprovalActionDto request)
    {
        request.ApprovalAction = Domain.Enums.RequestStatus.Approved;

        var result = await _requestService.ApprovalAsync(id, request);

        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Reject request
    /// </summary>
    [HttpPut("{id:guid}/reject")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Reject(Guid id, [FromBody] ApprovalActionDto request)
    {
        request.ApprovalAction = Domain.Enums.RequestStatus.Rejected;

        var result = await _requestService.ApprovalAsync(id, request);

        return StatusCode(result.StatusCode, result);
    }
}