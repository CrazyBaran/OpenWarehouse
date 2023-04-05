using JbCoders.OpenWarehouse.Inventory.Domain.Stocks;
using JbCoders.OpenWarehouse.Inventory.Domain.Storages;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace JbCoders.OpenWarehouse.Inventory.EntityFrameworkCore;

public class OpenWarehouseInventoryDbContext : 
    AbpDbContext<OpenWarehouseInventoryDbContext>, IOpenWarehouseInventoryDbContext
{
    public OpenWarehouseInventoryDbContext(DbContextOptions<OpenWarehouseInventoryDbContext> options) : 
        base(options)
    {
    }

    public DbSet<StorageUnit> StorageUnits => Set<StorageUnit>();
    public DbSet<StockUnit> StockUnits => Set<StockUnit>();
    public DbSet<StockToStorage> StockToStorages => Set<StockToStorage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ConfigureOpenWarehouseInventory();
    }
}