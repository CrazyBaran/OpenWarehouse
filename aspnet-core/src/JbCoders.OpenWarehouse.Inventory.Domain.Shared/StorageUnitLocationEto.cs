namespace JbCoders.OpenWarehouse.Inventory.Domain.Shared;

public class StorageUnitLocationEto
{
    public Guid StorageUnitId { get; set; }
    public string HierarchyId { get; set; }
    public decimal Quantity { get; set; }
}