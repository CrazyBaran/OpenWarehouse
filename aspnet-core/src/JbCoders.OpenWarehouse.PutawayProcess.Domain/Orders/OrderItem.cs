namespace JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;

public class OrderItem
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
}