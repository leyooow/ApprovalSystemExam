using ApprovalRequest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.DTOs.Common;
public class RequestDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? RequestedBy { get; set; }

    public RequestStatus Status { get; set; }

    public string? ReviewedBy { get; set; }

    public string? Remarks { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateReviewed { get; set; }
}