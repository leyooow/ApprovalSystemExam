using ApprovalRequest.Application.DTOs.Common;
using ApprovalRequest.Application.Interfaces.Repositories;
using ApprovalRequest.Domain.Entities;
using ApprovalRequest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ApprovalRequest.Infrastructure.Repositories;

public class RequestRepository
    : BaseRepository<Request>, IRequestRepository
{
    private readonly AppDbContext _context;

    public RequestRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<PagedResponse<Request>> GetPaginatedDataAsync(int pageNumber, int pageSize)
    {
        var totalRecords = await _context.Requests.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

        var items = await _context.Requests
            .AsNoTracking()
            .OrderByDescending(x => x.DateCreated)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResponse<Request>
        {
            Items = items,
            TotalRecords = totalRecords,
            TotalPages = totalPages
        };
    }


}