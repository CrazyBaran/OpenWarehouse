using System.Runtime.InteropServices.ComTypes;
using JbCoders.OpenWarehouse.Inventory.Domain.Storages;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace JbCoders.OpenWarehouse.Inventory.Domain.Stocks;

public class StockToStorage: AuditedEntity, IMultiTenant, IHasConcurrencyStamp
{
    public StockToStorage(Guid stockUnitId, Guid storageUnitId, decimal quantity)
    {
        StockUnitId = stockUnitId;
        StorageUnitId = storageUnitId;
        Quantity = quantity;
    }

    public StockToStorage(StockUnit stockUnit, decimal quantity)
    {
        StockUnit = stockUnit;
        Quantity = quantity;
    }

    public StockToStorage(StorageUnit storageUnit, decimal quantity)
    {
        StorageUnit = storageUnit;
        Quantity = quantity;
    }
    
    public StockToStorage(StockUnit stockUnit, StorageUnit storageUnit, decimal quantity)
    {
        StockUnit = stockUnit;
        StorageUnit = storageUnit;
        Quantity = quantity;
    }
    
    public Guid? TenantId { get; protected set; }
    public Guid StockUnitId { get; protected set; }
    public StockUnit StockUnit { get; protected set; }
    public Guid StorageUnitId { get; protected set; }
    public StorageUnit StorageUnit { get; protected set; }
    
    public decimal Quantity { get; set; }
    
    public override object[] GetKeys()
    {
        return new object[] {StockUnitId, StorageUnitId};
    }

    public string ConcurrencyStamp { get; set; }
}