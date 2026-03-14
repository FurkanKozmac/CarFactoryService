using CarFactory.Domain.Entities;
using CarFactory.Domain.Enums;

namespace CarFactory.Application.Interfaces;

public interface IVehicleRepository
{
    Task<Vehicle?> GetByVinAsync(string vin, CancellationToken ct = default);
    Task<IEnumerable<Vehicle>> GetByStationAsync(int stationId, CancellationToken ct = default);
    Task<IEnumerable<Vehicle>> GetByStatusAsync(VehicleStatus status, CancellationToken ct = default);
    Task AddAsync(Vehicle vehicle, CancellationToken ct = default);
    Task UpdateAsync(Vehicle vehicle, CancellationToken ct = default);
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}