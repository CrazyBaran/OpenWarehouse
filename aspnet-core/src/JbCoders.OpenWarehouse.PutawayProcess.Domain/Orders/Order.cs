using JbCoders.OpenWarehouse.PutAwayProcess.Domain.Shared.Orders;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;

public class Order : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public OrderStatus Status { get; set; }
    public List<OrderItem> Items { get; set; }
    public Guid? TenantId { get; protected set; }
}