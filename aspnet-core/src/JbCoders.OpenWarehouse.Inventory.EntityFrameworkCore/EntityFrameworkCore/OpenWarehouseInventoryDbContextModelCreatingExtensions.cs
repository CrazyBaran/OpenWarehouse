using JbCoders.OpenWarehouse.Inventory.EntityFrameworkCore.EntityTypeConfigurations.Stocks;
using JbCoders.OpenWarehouse.Inventory.EntityFrameworkCore.EntityTypeConfigurations.Storages;
using Microsoft.EntityFrameworkCore;

namespace JbCoders.OpenWarehouse.Inventory.EntityFrameworkCore;

public static class OpenWarehouseInventoryDbContextModelCreatingExtensions
{
    public static void ConfigureOpenWarehouseInventory(
        this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new StorageUnitEntityTypeConfiguration());
        builder.ApplyConfiguration(new StockUnitEntityTypeConfiguration());
        builder.ApplyConfiguration(new StockToStorageEntityTypeConfiguration());
    }
}