using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.DTOs.Common;
public class PagedResponse<T> : ApiResponse
{
    public IEnumerable<T> Items { get; set; } = [];

    public int TotalRecords { get; set; }

    public int TotalPages { get; set; }
}