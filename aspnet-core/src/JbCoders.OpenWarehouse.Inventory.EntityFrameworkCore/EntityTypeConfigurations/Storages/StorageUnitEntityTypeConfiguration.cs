using JbCoders.OpenWarehouse.Inventory.Domain;
using JbCoders.OpenWarehouse.Inventory.Domain.Storages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace JbCoders.OpenWarehouse.Inventory.EntityFrameworkCore.EntityTypeConfigurations.Storages;

public class StorageUnitEntityTypeConfiguration : IEntityTypeConfiguration<StorageUnit>
{
    public void Configure(EntityTypeBuilder<StorageUnit> builder)
    {
        builder.ToTable(OpenWarehouseInventoryDbProperties.DbTablePrefix + "StorageUnits",
            OpenWarehouseInventoryDbProperties.DbSchema);
        builder.HasKey(_ => _.Id);
        builder.HasIndex(_ => new {_.TenantId, _.Id});
        builder.HasIndex(_ => new {_.TenantId, _.HierarchyId}).IsUnique();
        builder.Property(_ => _.TenantId).IsRequired();
        builder.Property(_ => _.DisplayName).HasMaxLength(256);

        builder.HasMany(_ => _.StorageToStocks)
            .WithOne(_ => _.StorageUnit).HasForeignKey(_ => _.StorageUnitId);
        
        builder.ConfigureByConvention();
    }
}