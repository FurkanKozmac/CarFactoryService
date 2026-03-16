using System.Reflection;
using CarFactory.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarFactory.Application.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceExtensions).Assembly));
    
            services.AddValidatorsFromAssembly(typeof(ApplicationServiceExtensions).Assembly);
    
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    
            return services;
        }
}