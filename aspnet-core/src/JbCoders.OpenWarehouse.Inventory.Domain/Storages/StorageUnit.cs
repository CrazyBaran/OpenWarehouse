using JbCoders.OpenWarehouse.Inventory.Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace JbCoders.OpenWarehouse.Inventory.Domain.Storages;

public class StorageUnit : FullAuditedEntity<Guid>, IMultiTenant, IHasConcurrencyStamp
{
    public Guid? TenantId { get; protected set; }
    public HierarchyId HierarchyId { get; set; }
    public string DisplayName { get; set; }
    public int LastChildNumber { get; set; }
    public string ConcurrencyStamp { get; set; }
    
    public virtual List<StockToStorage> StorageToStocks { get; set; }
}