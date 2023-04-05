using Volo.Abp.Application.Dtos;

namespace JbCoders.OpenWarehouse.Inventory.Application.Contracts.Storages;

public class StorageUnitDto : FullAuditedEntityDto<Guid>
{
    public string HierarchyId { get; set; }
    public string DisplayName { get; set; }
}