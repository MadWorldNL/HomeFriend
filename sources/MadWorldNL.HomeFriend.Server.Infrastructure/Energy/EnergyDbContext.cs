using Microsoft.EntityFrameworkCore;

namespace MadWorldNL.HomeFriend.Energy;

public class EnergyDbContext : DbContext
{
    public DbSet<ElectricConsumption> ElectricConsumptions { get; set; } = null!;
    public DbSet<GasConsumption> GasConsumptions { get; set; } = null!;
}