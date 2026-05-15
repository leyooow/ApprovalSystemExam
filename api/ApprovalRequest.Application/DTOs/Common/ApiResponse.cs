using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.DTOs.Common;

public class ApiResponse
{
    public bool Success { get; set; } = false;

    public int StatusCode { get; set; } = 500;

    public string Message { get; set; } = string.Empty;

}

public class ApiResponse<T> : ApiResponse
{
    public T? Data { get; set; }
}
