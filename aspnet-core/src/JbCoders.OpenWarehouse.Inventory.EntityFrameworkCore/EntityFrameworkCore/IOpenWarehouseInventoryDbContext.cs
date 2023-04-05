using JbCoders.OpenWarehouse.Inventory.Domain.Stocks;
using JbCoders.OpenWarehouse.Inventory.Domain.Storages;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace JbCoders.OpenWarehouse.Inventory.EntityFrameworkCore;

public interface IOpenWarehouseInventoryDbContext : IEfCoreDbContext
{
    DbSet<StorageUnit> StorageUnits { get; }
    DbSet<StockUnit> StockUnits { get; }
    DbSet<StockToStorage> StockToStorages { get; }
}