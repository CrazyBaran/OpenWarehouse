using JbCoders.OpenWarehouse.Inventory.Application.Contracts.Storages;
using JbCoders.OpenWarehouse.Inventory.Domain.Storages;
using Volo.Abp.AutoMapper;

namespace JbCoders.OpenWarehouse.Inventory.Application.Storages.Profiles;

public class CreateStorageUnitDtoToStorageUnitProfile : AutoMapper.Profile
{
    public CreateStorageUnitDtoToStorageUnitProfile()
    {
        CreateMap<CreateStorageUnitDto, StorageUnit>()
            .Ignore(_ => _.Id)
            .Ignore(_ => _.TenantId)
            .Ignore(_ => _.HierarchyId)
            .Ignore(_ => _.LastChildNumber)
            .Ignore(_ => _.ConcurrencyStamp)
            .Ignore(_ => _.StorageToStocks)
            .IgnoreFullAuditedObjectProperties();    
    }
}