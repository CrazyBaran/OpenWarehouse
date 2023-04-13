using JbCoders.OpenWarehouse.PutAwayProcess.Application.Contracts.Orders;
using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;
using JbCoders.OpenWarehouse.PutAwayProcess.Domain.Shared.Orders;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Orders;

public class OrderAppService 
    : CrudAppService<Order,OrderDto,Guid, PagedAndSortedResultRequestDto,
        CreateOrderDto, UpdateOrderDto>
{
    public OrderAppService(IRepository<Order, Guid> repository) : base(repository)
    {
    }

    protected override Order MapToEntity(CreateOrderDto createInput)
    {
        var order = new Order()
        {
            Status = OrderStatus.Draft,
            Items = createInput.Items.Select(item => 
                new OrderItem()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                }).ToList()
        };

        return order;
    }

    protected override async Task MapToEntityAsync(UpdateOrderDto updateInput, Order entity)
    {
        if (Enum.TryParse<OrderStatus>(updateInput.Status, out var parsedStatus)
            && parsedStatus == OrderStatus.WaitingForLocations)
        {
            entity.ReadyToPutAway();
        }
    }
}