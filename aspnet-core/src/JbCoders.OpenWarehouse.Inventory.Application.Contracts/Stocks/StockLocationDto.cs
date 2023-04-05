using Volo.Abp.Application.Dtos;

namespace JbCoders.OpenWarehouse.Inventory.Application.Contracts.Stocks;

public class StockLocationDto : AuditedEntityDto
{
    public Guid StorageUnitId { get; set; }
    public string HierarchyId { get; set; }
    public string DisplayName { get; set; }
    public decimal Quantity { get; set; }
}