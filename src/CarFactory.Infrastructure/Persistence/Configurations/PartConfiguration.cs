using CarFactory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Infrastructure.Persistence.Configurations;

public class PartConfiguration: IEntityTypeConfiguration<Part>
{
    public void Configure(EntityTypeBuilder<Part> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.PartNumber)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(p => p.StockQuantity)
            .IsRequired();

        builder.HasIndex(p => p.PartNumber).IsUnique();
    }
}