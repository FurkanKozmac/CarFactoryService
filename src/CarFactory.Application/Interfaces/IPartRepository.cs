using CarFactory.Domain.Entities;

namespace CarFactory.Application.Interfaces;

public interface IPartRepository
{
    Task<Part?> GetByIdAsync(int id, CancellationToken ct = default);
    Task <IEnumerable<Part>> GetAllAsync(CancellationToken ct = default);
    Task UpdateAsync(Part part, CancellationToken ct = default);
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}