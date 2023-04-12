using JbCoders.OpenWarehouse.PutAwayProcess.Domain.Shared.Orders;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;

public class Location : FullAuditedEntity, IMultiTenant
{
    public Guid? TenantId { get; protected set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public OrderItem OrderItem { get; set; }
    public string HierarchyId { get; set; }
    public decimal Quantity { get; set; }
    
    public LocationStatus Status { get; set; }
    
    public override object[] GetKeys()
    {
        return new object[] { OrderId, ProductId, HierarchyId};
    }
}