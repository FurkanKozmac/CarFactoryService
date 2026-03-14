using CarFactory.Application.Interfaces;
using CarFactory.Domain.Entities;
using CarFactory.Domain.Enums;
using CarFactory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Infrastructure.Repositories;

public class VehicleRepository: IVehicleRepository
{
    private readonly CarFactoryDbContext _context;

    public VehicleRepository(CarFactoryDbContext context)
    {
        _context = context;
    }
    
    public async Task<Vehicle?> GetByVinAsync(string vin, CancellationToken ct = default)
    {
        return await _context.Vehicles
            .Include(v => v.Model)
            .Include(v => v.CurrentStation)
            .FirstOrDefaultAsync(v => v.VIN == vin, ct);
    }

    public async Task<IEnumerable<Vehicle>> GetByStationAsync(int stationId, CancellationToken ct = default)
    {
        return await _context.Vehicles
            .Include(v => v.Model)
            .Where(v => v.CurrentStationId == stationId)
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<Vehicle>> GetByStatusAsync(VehicleStatus status, CancellationToken ct = default)
    {
        return await _context.Vehicles
            .Include(v => v.Model)
            .Where(v => v.CurrentStatus == status)
            .ToListAsync(ct);
    }

    public async Task AddAsync(Vehicle vehicle, CancellationToken ct = default)
    {
         await _context.Vehicles.AddAsync(vehicle, ct);

    }

    public Task UpdateAsync(Vehicle vehicle, CancellationToken ct = default)
    {
        _context.Vehicles.Update(vehicle);
        return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct);
    }
}