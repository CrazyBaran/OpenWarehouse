using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace JbCoders.OpenWarehouse.Inventory.Domain.Stocks;

public class StockUnit : FullAuditedEntity<Guid>, IMultiTenant
{
    public StockUnit(Guid id) : base(id)
    { }
    
    public Guid? TenantId { get; protected set; }

    public virtual List<StockToStorage> StockToStorages { get; set; } = new();
}