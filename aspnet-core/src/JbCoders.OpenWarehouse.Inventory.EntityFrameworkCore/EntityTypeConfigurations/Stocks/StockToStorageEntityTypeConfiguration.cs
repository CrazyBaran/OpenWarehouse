using JbCoders.OpenWarehouse.Inventory.Domain;
using JbCoders.OpenWarehouse.Inventory.Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace JbCoders.OpenWarehouse.Inventory.EntityFrameworkCore.EntityTypeConfigurations.Stocks;

public class StockToStorageEntityTypeConfiguration : IEntityTypeConfiguration<StockToStorage>
{
    public void Configure(EntityTypeBuilder<StockToStorage> builder)
    {
        builder.ToTable(OpenWarehouseInventoryDbProperties.DbTablePrefix + "StockToStorages",
            OpenWarehouseInventoryDbProperties.DbSchema);
        builder.HasKey(_ => new {_.StockUnitId, _.StorageUnitId});
        builder.HasIndex(_ => new {_.TenantId, _.StockUnitId, _.StorageUnitId});
        builder.Property(_ => _.TenantId).IsRequired();
        builder.ConfigureByConvention();
    }
}