using CarFactory.Domain.Entities;

namespace CarFactory.Application.Interfaces;

public interface IStationRepository
{
    Task<Station?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<Station>> GetAllOrderedAsync(CancellationToken ct = default);
    Task<Station?> GetNextStationAsync(int currentSequenceOrder, CancellationToken ct = default);
}