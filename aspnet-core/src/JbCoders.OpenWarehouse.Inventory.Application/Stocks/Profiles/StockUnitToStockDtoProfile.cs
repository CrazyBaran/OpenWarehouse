using JbCoders.OpenWarehouse.Inventory.Application.Contracts.Stocks;
using JbCoders.OpenWarehouse.Inventory.Domain.Stocks;
using Volo.Abp.AutoMapper;

namespace JbCoders.OpenWarehouse.Inventory.Application.Stocks.Profiles;

public class StockUnitToStockDtoProfile : AutoMapper.Profile
{
    public StockUnitToStockDtoProfile()
    {
        CreateMap<StockUnit, StockDto>()
            .Ignore(_ => _.TotalQuantity);
    }
}