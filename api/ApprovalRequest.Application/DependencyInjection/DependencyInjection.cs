using ApprovalRequest.Application.Interfaces.Repositories;
using ApprovalRequest.Application.Interfaces.Services;
using ApprovalRequest.Application.MappingProfiles;
using ApprovalRequest.Application.Services;
using ApprovalRequest.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.DepenedencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateRequestValidator>();

        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<RequestMappingProfile>();
        });


        services.AddScoped<IRequestService, RequestService>();


        return services;
    }
}