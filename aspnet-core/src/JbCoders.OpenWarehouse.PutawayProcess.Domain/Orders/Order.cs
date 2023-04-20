using JbCoders.OpenWarehouse.PutAwayProcess.Domain.Shared.Orders;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;

public class Order : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public OrderStatus Status { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public Guid? TenantId { get; protected set; }
    
    public void ReadyToPutAway()
    {
        Status = OrderStatus.WaitingForLocations;
        
        foreach (var orderItem in Items)
        {
            AddDistributedEvent(new OrderItemReadyForLocationEto
            {
                OrderId = Id,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity
            });
        }
    }
}