using System.Runtime.InteropServices.ComTypes;
using JbCoders.OpenWarehouse.PutawayProcess.Domain;
using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace JbCoders.OpenWarehouse.PutawayProcess.EntityFrameworkCore.EntityTypeConfiguration;

public class OrderItemEntityTypeConfiguration 
    : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable(OpenWarehousePutAwayProcessDbProperties.DbTablePrefix + "OrderItems",
            OpenWarehousePutAwayProcessDbProperties.DbSchema);
        builder.HasKey(_ => new { _.OrderId, _.ProductId });       
        builder.HasIndex(_ => new {_.TenantId, _.OrderId, _.ProductId});
        builder.Property(_ => _.TenantId).IsRequired();
        
        builder.HasMany(_ => _.Locations)
            .WithOne(_ => _.OrderItem)
            .HasForeignKey(_ => new {_.OrderId, _.ProductId});
        
        builder.ConfigureByConvention();
    }
}