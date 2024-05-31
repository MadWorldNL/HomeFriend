using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MadWorldNL.HomeFriend.Energy.Configurations;

public class GasConsumptionEntityTypeConfiguration : IEntityTypeConfiguration<GasConsumption>
{
    public void Configure(EntityTypeBuilder<GasConsumption> builder)
    {
        builder.HasKey(c => c.Id);
    }
}