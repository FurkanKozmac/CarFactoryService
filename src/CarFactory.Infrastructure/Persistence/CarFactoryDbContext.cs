using CarFactory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Infrastructure.Persistence;

public class CarFactoryDbContext: DbContext
{
    public CarFactoryDbContext(DbContextOptions<CarFactoryDbContext> options) : base(options) {}

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<VehicleModel> VehicleModels => Set<VehicleModel>();
    public DbSet<Station> Stations => Set<Station>();
    public DbSet<Part> Parts => Set<Part>();
    public DbSet<VehicleModelPart> VehicleModelParts => Set<VehicleModelPart>();
    public DbSet<ProductionOrder> ProductionOrders => Set<ProductionOrder>();
    public DbSet<ProductionLog> ProductionLogs => Set<ProductionLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarFactoryDbContext).Assembly);
    }
}