using Volo.Abp.Application.Dtos;

namespace JbCoders.OpenWarehouse.Inventory.Application.Contracts.Stocks;

public class StockLocationResultRequestDto : PagedAndSortedResultRequestDto
{
    public int? Depth { get; set; }
    public string? ParentStorageUnitHierarchyId { get; set; } 
}