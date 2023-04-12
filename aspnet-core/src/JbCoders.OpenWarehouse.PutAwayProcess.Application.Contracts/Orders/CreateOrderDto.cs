namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Contracts.Orders;

public class CreateOrderDto
{
    public List<CreateOrderItemDto> Items { get; set; }
}