using JbCoders.OpenWarehouse.Inventory.Application.Contracts.Storages;
using JbCoders.OpenWarehouse.Inventory.Domain.Storages;

namespace JbCoders.OpenWarehouse.Inventory.Application.Storages.Profiles;

public class StorageUnitToStorageUnitDtoProfile : AutoMapper.Profile
{
    public StorageUnitToStorageUnitDtoProfile()
    {
        CreateMap<StorageUnit, StorageUnitDto>();
    }
}