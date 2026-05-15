using ApprovalRequest.Application.DTOs.Common;
using ApprovalRequest.Application.DTOs.Request;
using ApprovalRequest.Application.Interfaces.Repositories;
using ApprovalRequest.Application.Interfaces.Services;
using ApprovalRequest.Domain.Entities;
using ApprovalRequest.Domain.Enums;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.Services;

public class RequestService : IRequestService
{
    private readonly IRequestRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<RequestService> _logger;
    public RequestService(
        IRequestRepository repository,
        IMapper mapper,
        ILogger<RequestService> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ApiResponse<RequestDto>> CreateAsync(CreateRequestDto dto)
    {

        var response = new ApiResponse<RequestDto>();
        _logger.LogInformation("Creating request {RequestTitle}", dto.Title);

        try
        {
            var entity = _mapper.Map<Request>(dto);

            await _repository.AddAsync(entity);

            response.Data = _mapper.Map<RequestDto>(entity);
            response.Success = true;
            response.StatusCode = 201;
            response.Message = "Request created successfully";

            _logger.LogInformation("Request created successfully {RequestTitle}", dto.Title);
            return response;
        }
        catch (Exception ex)
        {
            response.Message = $"An error occurred: {ex.Message}";
            _logger.LogError(ex, "Error creating request {RequestTitle}", dto.Title);

            return response;
        }

    }

    public async Task<ApiResponse<RequestDto>?> GetByIdAsync(Guid id)
    {
        var response = new ApiResponse<RequestDto>();
        _logger.LogInformation("Retrieving request {id}", id);

        try
        {

            var result = await _repository.GetByIdAsync(id);
            if (result == null)
            {
                response.StatusCode = 404;
                response.Message = "Request not found";
                _logger.LogWarning("Request {id} not found", id);
                return response;
            }
            response.Data = _mapper.Map<RequestDto>(result);
            response.Success = true;
            response.StatusCode = 200;
            response.Message = "Request retrieved successfully";
            _logger.LogInformation("Request {id} retrieved successfully", id);
            return response;

        }
        catch (Exception ex)
        {
            response.Message = $"An error occurred: {ex.Message}";
            _logger.LogError(ex, "Error retrieving request {id}", id);
            return response;
        }
    }

    public async Task<PagedResponse<RequestDto>> GetPaginatedDataAsync(int pageNumber, int pageSize)
    {
        var response = new PagedResponse<RequestDto>();
        _logger.LogInformation("Retrieving all requests with pagination: PageNumber={PageNumber}, PageSize={PageSize}", pageNumber, pageSize);

        try
        {
            var result = await _repository.GetPaginatedDataAsync(pageNumber, pageSize);
            response.Items = _mapper.Map<IEnumerable<RequestDto>>(result.Items);
            response.TotalRecords = result.TotalRecords;
            response.TotalPages = result.TotalPages;
            response.Success = true;
            response.StatusCode = 200;
            response.Message = "Requests retrieved successfully";
            _logger.LogInformation("Requests retrieved successfully with pagination: PageNumber={PageNumber}, PageSize={PageSize}", pageNumber, pageSize);
            return response;
        }
        catch (Exception ex)
        {
            response.Message = $"An error occurred: {ex.Message}";
            _logger.LogError(ex, "Error retrieving requests with pagination: PageNumber={PageNumber}, PageSize={PageSize}", pageNumber, pageSize);
            return response;

        }
    }

    public async Task<ApiResponse> ApprovalAsync(Guid id, ApprovalActionDto request)
    {
        var response = new ApiResponse();
        _logger.LogInformation(
            request.ApprovalAction == RequestStatus.Approved
            ? "Approving request {id}"
            : "Rejecting request {id}", id);
        try
        {
            var result = await _repository.GetByIdAsync(id);

            if (result == null)
            {
                response.StatusCode = 404;
                response.Message = "Request not found";

                return response;
            }

            result.Status = request.ApprovalAction == RequestStatus.Approved
               ? RequestStatus.Approved
               : RequestStatus.Rejected;

            result.ReviewedBy = request.ReviewedBy;
            result.DateReviewed = DateTime.Now;
            result.Remarks = request.Remarks;

            await _repository.UpdateAsync(result);

            response.Success = true;
            response.StatusCode = 200;
            response.Message = request.ApprovalAction == RequestStatus.Approved
                ? "Request approved successfully"
                : "Request rejected successfully";

            _logger.LogInformation(
            request.ApprovalAction == RequestStatus.Approved
            ? "Request approved successfully"
            : "Request rejected successfully", id);



            return response;
        }
        catch (Exception ex)
        {
            response.Message = $"An error occurred: {ex.Message}";
            _logger.LogError(ex, "Error processing request {id}", id);
            return response;
        }


    }


}
