using JbCoders.OpenWarehouse.PutAwayProcess.Application.Contracts.Orders;
using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Orders.Profiles;

public class LocationToLocationDtoProfile : AutoMapper.Profile
{
    public LocationToLocationDtoProfile()
    {
        CreateMap<Location, LocationDto>();
    }    
}