using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;

public class OrderItem : FullAuditedEntity, IMultiTenant
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public override object[] GetKeys()
    {
        return new object[]{ OrderId, ProductId };
    }

    public Guid? TenantId { get; protected set; }
    
    public List<Location> Locations { get; set; }
}