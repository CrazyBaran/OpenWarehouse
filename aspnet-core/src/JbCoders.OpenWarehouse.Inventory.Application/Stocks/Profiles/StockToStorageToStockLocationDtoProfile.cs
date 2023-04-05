using JbCoders.OpenWarehouse.Inventory.Application.Contracts.Stocks;
using JbCoders.OpenWarehouse.Inventory.Domain.Stocks;

namespace JbCoders.OpenWarehouse.Inventory.Application.Stocks.Profiles;

public class StockToStorageToStockLocationDtoProfile : AutoMapper.Profile
{
    public StockToStorageToStockLocationDtoProfile()
    {
        CreateMap<StockToStorage, StockLocationDto>()
            .ForMember(dst => dst.HierarchyId, opt => 
                opt.MapFrom(src => src.StorageUnit.HierarchyId))
            .ForMember(dst => dst.DisplayName, opt => 
                opt.MapFrom(src => src.StorageUnit.DisplayName))
;
    }
}