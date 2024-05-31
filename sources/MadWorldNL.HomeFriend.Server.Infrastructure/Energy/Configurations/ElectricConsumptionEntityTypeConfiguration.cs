using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MadWorldNL.HomeFriend.Energy.Configurations;

public class ElectricConsumptionEntityTypeConfiguration : IEntityTypeConfiguration<ElectricConsumption>
{
    public void Configure(EntityTypeBuilder<ElectricConsumption> builder)
    {
        builder.HasKey(c => c.Id);
    }
}