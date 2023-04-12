namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Contracts.Orders;

public class CreateOrderItemDto
{
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
}