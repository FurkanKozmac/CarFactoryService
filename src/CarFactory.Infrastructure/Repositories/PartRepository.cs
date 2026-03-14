using CarFactory.Application.Interfaces;
using CarFactory.Domain.Entities;
using CarFactory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Infrastructure.Repositories;

public class PartRepository: IPartRepository
{
    private readonly CarFactoryDbContext _context;

    public PartRepository(CarFactoryDbContext context)
    {
        _context = context;
    }
    
    public async Task<Part?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Parts
            .FirstOrDefaultAsync(v => v.Id == id, ct);
    }

    public async Task<IEnumerable<Part>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Parts
            .ToListAsync(ct);
    }

    public Task UpdateAsync(Part part, CancellationToken ct = default)
    {
        _context.Parts.Update(part);
         return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct);
    }
}