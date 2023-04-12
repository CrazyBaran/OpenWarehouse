using JbCoders.OpenWarehouse.PutAwayProcess.Application.Contracts.Orders;
using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Orders.Profiles;

public class OrderItemToOrderItemDtoProfile : AutoMapper.Profile
{
    public OrderItemToOrderItemDtoProfile()
    {
        CreateMap<OrderItem, OrderItemDto>();
    }    
}