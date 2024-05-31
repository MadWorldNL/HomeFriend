using MadWorldNL.HomeFriend.Energy.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MadWorldNL.HomeFriend.Energy;

public class EnergyDbContext : DbContext
{
    public EnergyDbContext(DbContextOptions<EnergyDbContext> options) : base(options)
    {
    }
    
    public DbSet<ElectricConsumption> ElectricConsumptions { get; set; } = null!;
    public DbSet<GasConsumption> GasConsumptions { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ElectricConsumptionEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GasConsumptionEntityTypeConfiguration());
    }
}