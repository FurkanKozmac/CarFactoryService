using CarFactory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Infrastructure.Persistence.Configurations;

public class VehicleModelConfiguration: IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(v => v.Year)
            .HasMaxLength(4)
            .IsRequired();

        builder.HasIndex(v => new { v.Name, v.Year }).IsUnique();
    }
}