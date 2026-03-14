using CarFactory.Application.Interfaces;
using CarFactory.Domain.Entities;
using CarFactory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Infrastructure.Repositories;

public class StationRepository: IStationRepository
{
    private readonly CarFactoryDbContext _context;

    public StationRepository(CarFactoryDbContext context)
    {
        _context = context;
    }
    
    public async Task<Station?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Stations
            .FirstOrDefaultAsync(v => v.Id == id, ct);
    }

    public async Task<IEnumerable<Station>> GetAllOrderedAsync(CancellationToken ct = default)
    {
        return await _context.Stations
            .OrderBy(s => s.SequenceOrder)
            .ToListAsync(ct);
    }

    public async Task<Station?> GetNextStationAsync(int currentSequenceOrder, CancellationToken ct = default)
    {
        return await _context.Stations
            .FirstOrDefaultAsync(v => v.SequenceOrder + 1 == currentSequenceOrder, ct);
    }
}