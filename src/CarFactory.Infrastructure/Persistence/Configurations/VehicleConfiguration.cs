using CarFactory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Infrastructure.Persistence.Configurations;

public class VehicleConfiguration: IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(v => v.VIN);

        builder.Property(v => v.VIN)
            .HasMaxLength(17)
            .IsRequired();

        builder.Property(v => v.Color)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(v => v.CurrentStatus)
            .HasConversion<string>()
            .IsRequired();
        
        builder.HasOne(v => v.Model)
            .WithMany(m => m.Vehicles)
            .HasForeignKey(v => v.ModelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(v => v.CurrentStation)
            .WithMany(s => s.Vehicles)
            .HasForeignKey(v => v.CurrentStationId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(v => v.CurrentStatus);
        builder.HasIndex(v => v.CurrentStationId);
    }
}