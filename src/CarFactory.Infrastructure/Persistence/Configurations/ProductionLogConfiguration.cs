using CarFactory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Infrastructure.Persistence.Configurations;

public class ProductionLogConfiguration: IEntityTypeConfiguration<ProductionLog>
{
    public void Configure(EntityTypeBuilder<ProductionLog> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.VehicleVIN)
            .HasMaxLength(17)
            .IsRequired();

        builder.Property(v => v.OperatorId)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.HasOne(p => p.Vehicle)
            .WithMany(m => m.ProductionLogs)
            .HasForeignKey(p => p.VehicleVIN)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.Station)
            .WithMany(m => m.ProductionLogs)
            .HasForeignKey(p => p.StationId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(p => new { p.VehicleVIN, p.EntryDate });
        builder.HasIndex(p => new { p.StationId, p.EntryDate });
    }
}