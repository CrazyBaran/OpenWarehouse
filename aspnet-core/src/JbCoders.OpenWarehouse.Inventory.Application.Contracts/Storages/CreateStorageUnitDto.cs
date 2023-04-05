namespace JbCoders.OpenWarehouse.Inventory.Application.Contracts.Storages;

public class CreateStorageUnitDto
{
    public string DisplayName { get; set; }
    public string? ParentStorageUnitHierarchyId { get; set; }
}