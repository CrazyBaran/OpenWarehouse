using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;
using JbCoders.OpenWarehouse.PutAwayProcess.Domain.Shared.Orders;
using JbCoders.OpenWarehouse.PutAwayProcess.TestBase.Data;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace JbCoders.OpenWarehouse.PutAwayProcess.TestBase;

public class OpenWarehousePutAwayTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Order, Guid> _orderRepository;

    public OpenWarehousePutAwayTestDataSeedContributor(IRepository<Order, Guid> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await _orderRepository.InsertAsync(new Order
            {
                Status = OrderStatus.Draft,
                Items = new List<OrderItem>
                {
                    new()
                    {
                        ProductId = Guid.NewGuid(),
                        Quantity = 10
                    }
                }
            },
            true);

        await _orderRepository.InsertAsync(new Order(OrderTestData.OrderWithOneLineWaitingForLocation.OrderId)
        {
            Status = OrderStatus.WaitingForLocations,
            Items = new List<OrderItem>()
            {
                new()
                {
                    ProductId = OrderTestData.OrderWithOneLineWaitingForLocation.OrderLineProductId,
                    Quantity = 10
                }
            }
        }, true);
    }
}