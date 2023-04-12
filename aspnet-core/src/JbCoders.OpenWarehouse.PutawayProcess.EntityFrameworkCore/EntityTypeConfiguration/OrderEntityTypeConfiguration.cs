using JbCoders.OpenWarehouse.PutawayProcess.Domain;
using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;
using JbCoders.OpenWarehouse.PutAwayProcess.Domain.Shared.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace JbCoders.OpenWarehouse.PutawayProcess.EntityFrameworkCore.EntityTypeConfiguration;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(OpenWarehousePutAwayProcessDbProperties.DbTablePrefix + "Orders",
            OpenWarehousePutAwayProcessDbProperties.DbSchema);
        builder.HasKey(_ => _.Id);
        builder.HasIndex(_ => new { _.TenantId, _.Id });
        builder.Property(_ => _.TenantId).IsRequired();
        builder.HasMany(_ => _.Items)
            .WithOne(_ => _.Order)
            .HasForeignKey(_ => _.OrderId);
        builder.Property(_ => _.Status)
            .HasConversion<EnumToStringConverter<OrderStatus>>()
            .HasMaxLength(256);
        
        
        builder.ConfigureByConvention();
    }
}