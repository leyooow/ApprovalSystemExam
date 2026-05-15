using ApprovalRequest.Application.DTOs.Common;
using ApprovalRequest.Application.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.Interfaces.Services;

public interface IRequestService
{
    Task<ApiResponse<RequestDto>> CreateAsync(CreateRequestDto request);

    Task<ApiResponse<RequestDto>?> GetByIdAsync(Guid id);

    Task<PagedResponse<RequestDto>> GetPaginatedDataAsync(int pageNumber, int pageSize);

    Task<ApiResponse> ApprovalAsync(Guid id, ApprovalActionDto request);

}
