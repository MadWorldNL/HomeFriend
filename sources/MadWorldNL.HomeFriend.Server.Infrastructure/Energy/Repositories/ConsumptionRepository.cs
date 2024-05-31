using Microsoft.EntityFrameworkCore;

namespace MadWorldNL.HomeFriend.Energy.Repositories;

public class ConsumptionRepository : IConsumptionRepository
{
    private readonly EnergyDbContext _context;

    public ConsumptionRepository(EnergyDbContext context)
    {
        _context = context;
    }
    
    public async Task Add(ElectricConsumption consumption)
    {
        await _context.ElectricConsumptions.AddAsync(consumption);
        await _context.SaveChangesAsync();
    }
    
    public async Task Add(GasConsumption consumption)
    {
        await _context.GasConsumptions.AddAsync(consumption);
        await _context.SaveChangesAsync();
    }

    public List<ElectricConsumption> GetElectrics(DateTime start, DateTime ends)
    {
        return _context
            .ElectricConsumptions
            .AsNoTracking()
            .Where(e => e.TimestampUtc.Date >= start.Date && e.TimestampUtc.Date <= ends.Date)
            .ToList();
    }
    
    public List<GasConsumption> GetGases(DateTime start, DateTime ends)
    {
        return _context
            .GasConsumptions
            .AsNoTracking()
            .Where(e => e.TimestampUtc >= start && e.TimestampUtc <= ends)
            .ToList();
    }
}