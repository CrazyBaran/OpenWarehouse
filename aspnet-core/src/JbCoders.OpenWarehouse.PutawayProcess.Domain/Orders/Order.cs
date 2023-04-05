using Volo.Abp.Domain.Entities.Auditing;

namespace JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;

public class Order: FullAuditedAggregateRoot<Guid>
{
    public List<OrderItem> Items { get; set; }
}