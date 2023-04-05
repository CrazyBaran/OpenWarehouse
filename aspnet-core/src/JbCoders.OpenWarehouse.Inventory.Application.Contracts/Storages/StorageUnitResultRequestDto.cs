using Volo.Abp.Application.Dtos;

namespace JbCoders.OpenWarehouse.Inventory.Application.Contracts.Storages;

public class StorageUnitResultRequestDto : PagedAndSortedResultRequestDto
{
    public int Depth { get; set; } = 1;
    public string? ParentStorageUnitHierarchyId { get; set; } 
}