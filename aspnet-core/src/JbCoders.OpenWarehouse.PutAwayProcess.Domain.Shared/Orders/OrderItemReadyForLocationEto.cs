using Volo.Abp.EventBus;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Domain.Shared.Orders;

[EventName("JbCoders.OpenWarehouse.PutAwayProcess.OrderItemReadyForLocation")]
public class OrderItemReadyForLocationEto
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
}