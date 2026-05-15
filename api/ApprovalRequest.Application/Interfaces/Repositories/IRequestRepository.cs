using ApprovalRequest.Application.DTOs.Common;
using ApprovalRequest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.Interfaces.Repositories;

public interface IRequestRepository : IBaseRepository<Request>
{
    Task<PagedResponse<Request>> GetPaginatedDataAsync(int pageNumber, int pageSize);
}
