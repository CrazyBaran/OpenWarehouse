namespace JbCoders.OpenWarehouse.Inventory.Application.Contracts.Stocks;

public class CreateStockDto
{
    public Guid ProductId { get; set; }
    public Guid StorageUnitId { get; set; }
    public decimal Quantity { get; set; }
}