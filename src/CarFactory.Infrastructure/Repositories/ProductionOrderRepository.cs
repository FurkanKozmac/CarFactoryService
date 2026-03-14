using CarFactory.Application.Interfaces;
using CarFactory.Domain.Entities;
using CarFactory.Domain.Enums;
using CarFactory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Infrastructure.Repositories;

public class ProductionOrderRepository: IProductionOrderRepository
{
    
    private readonly CarFactoryDbContext _context;

    public ProductionOrderRepository(CarFactoryDbContext context)
    {
        _context = context;
    }
    
    public async Task<ProductionOrder?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.ProductionOrders
            .FirstOrDefaultAsync(v => v.Id == id, ct);
    }

    public async Task<IEnumerable<ProductionOrder>> GetFilteredAsync(
        OrderStatus? status = null, 
        DateTime? startDate = null, 
        DateTime? endDate = null,
        CancellationToken ct = default)
    {
        var query = _context.ProductionOrders
            .Include(o => o.Model)
            .AsQueryable();

        if (status.HasValue)
            query = query.Where(o => o.Status == status.Value);

        if (startDate.HasValue)
            query = query.Where(o => o.OrderDate >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(o => o.OrderDate <= endDate.Value);

        return await query.ToListAsync(ct);
    }

    public async Task AddAsync(ProductionOrder order, CancellationToken ct = default)
    {
        await _context.ProductionOrders.AddAsync(order, ct);
    }

    public Task UpdateAsync(ProductionOrder order, CancellationToken ct = default)
    {
        _context.ProductionOrders.Update(order);
        return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct);
    }
}