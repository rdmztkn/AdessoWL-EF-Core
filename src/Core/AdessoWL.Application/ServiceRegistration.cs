using AdessoWL.Application.Features.Queries.GetGroups;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AdessoWL.Application;

public static class ServiceRegistration
{
    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assm));

        services.AddAutoMapper(assm);

        services.AddValidatorsFromAssemblyContaining<GetGroupsValidator>();
    }
}
