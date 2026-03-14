using CarFactory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Infrastructure.Persistence.Configurations;

public class VehicleModelPartConfiguration: IEntityTypeConfiguration<VehicleModelPart>
{
    public void Configure(EntityTypeBuilder<VehicleModelPart> builder)
    {
        builder.HasKey(p => new { p.VehicleModelId, p.PartId });

        builder.Property(p => p.RequiredQuantity)
            .IsRequired();

        builder.HasOne(p => p.VehicleModel)
            .WithMany(m => m.RequiredParts)
            .HasForeignKey(p => p.VehicleModelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Part)
            .WithMany(p => p.VehicleModelParts)
            .HasForeignKey(p => p.PartId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}