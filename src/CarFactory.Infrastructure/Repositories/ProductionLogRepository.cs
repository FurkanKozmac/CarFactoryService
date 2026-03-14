using CarFactory.Application.Interfaces;
using CarFactory.Domain.Entities;
using CarFactory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Infrastructure.Repositories;

public class ProductionLogRepository: IProductionLogRepository
{
    private readonly CarFactoryDbContext _context;

    public ProductionLogRepository(CarFactoryDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ProductionLog>> GetVehicleHistoryAsync(string vehicleVIN, CancellationToken ct = default)
    {
        return await _context.ProductionLogs
            .Include(l => l.Station)
            .Where(l => l.VehicleVIN == vehicleVIN)
            .OrderBy(l => l.EntryDate)
            .ToListAsync(ct);
    }

    public async Task AddAsync(ProductionLog log, CancellationToken ct = default)
    {
        await _context.ProductionLogs.AddAsync(log, ct);
    }

    public Task UpdateAsync(ProductionLog log, CancellationToken ct = default)
    {
        _context.ProductionLogs.Update(log);
        return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct);
    }
}