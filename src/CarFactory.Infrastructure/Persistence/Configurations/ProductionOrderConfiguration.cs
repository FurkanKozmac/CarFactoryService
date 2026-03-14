using CarFactory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Infrastructure.Persistence.Configurations;

public class ProductionOrderConfiguration: IEntityTypeConfiguration<ProductionOrder>
{
    public void Configure(EntityTypeBuilder<ProductionOrder> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.OrderNumber)
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(s => s.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasOne(p => p.Model)
            .WithMany(m => m.ProductionOrders)
            .HasForeignKey(p => p.ModelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.OrderNumber).IsUnique();
        builder.HasIndex(p => p.Status);
    }
}