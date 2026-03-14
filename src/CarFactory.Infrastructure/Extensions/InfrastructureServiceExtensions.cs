using CarFactory.Application.Interfaces;
using CarFactory.Infrastructure.Persistence;
using CarFactory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarFactory.Infrastructure.Extensions;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<CarFactoryDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IPartRepository, PartRepository>();
        services.AddScoped<IStationRepository, StationRepository>();
        services.AddScoped<IProductionLogRepository, ProductionLogRepository>();
        services.AddScoped<IProductionOrderRepository, ProductionOrderRepository>();

        return services;
    }
}