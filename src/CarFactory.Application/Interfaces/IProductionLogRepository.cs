using CarFactory.Domain.Entities;

namespace CarFactory.Application.Interfaces;

public interface IProductionLogRepository
{
    Task<IEnumerable<ProductionLog>> GetVehicleHistoryAsync(string vehicleVIN, CancellationToken ct = default);
    Task AddAsync(ProductionLog log, CancellationToken ct = default);
    Task UpdateAsync(ProductionLog log, CancellationToken ct = default);
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}