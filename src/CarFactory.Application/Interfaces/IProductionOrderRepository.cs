using CarFactory.Domain.Entities;
using CarFactory.Domain.Enums;

namespace CarFactory.Application.Interfaces;

public interface IProductionOrderRepository
{
    Task<ProductionOrder?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<ProductionOrder>> GetFilteredAsync(
        OrderStatus? status = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        CancellationToken ct = default);
    Task AddAsync(ProductionOrder order, CancellationToken ct = default);
    Task UpdateAsync(ProductionOrder order, CancellationToken ct = default);
    Task<int> SaveChangesAsync(CancellationToken ct = default);

}