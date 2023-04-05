namespace JbCoders.OpenWarehouse.Inventory.Application.Contracts.Stocks;

public class UpdateStockDto
{
    public Guid StorageUnitId { get; set; }
    public decimal Quantity { get; set; }
}