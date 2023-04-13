using Volo.Abp.EventBus;

namespace JbCoders.OpenWarehouse.Inventory.Domain.Shared;

[EventName("JbCoders.OpenWarehouse.Inventory.StorageUnitAssigned")]
public class StorageUnitAssignedEto
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public Guid StorageUnitId { get; set; }
}