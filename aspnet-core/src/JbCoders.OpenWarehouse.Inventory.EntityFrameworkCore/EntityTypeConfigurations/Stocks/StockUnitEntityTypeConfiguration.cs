using JbCoders.OpenWarehouse.Inventory.Domain;
using JbCoders.OpenWarehouse.Inventory.Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace JbCoders.OpenWarehouse.Inventory.EntityFrameworkCore.EntityTypeConfigurations.Stocks;

public class StockUnitEntityTypeConfiguration : IEntityTypeConfiguration<StockUnit>
{
    public void Configure(EntityTypeBuilder<StockUnit> builder)
    {
        builder.ToTable(OpenWarehouseInventoryDbProperties.DbTablePrefix + "StockUnits",
            OpenWarehouseInventoryDbProperties.DbSchema);
        builder.HasKey(_ => _.Id);
        builder.HasIndex(_ => new {_.TenantId, _.Id});
        builder.Property(_ => _.TenantId).IsRequired();
        
        builder.HasMany(_ => _.StockToStorages)
            .WithOne(_ => _.StockUnit).HasForeignKey(_ => _.StockUnitId);
        
        builder.ConfigureByConvention();
    }
}