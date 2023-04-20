using JbCoders.OpenWarehouse.Inventory.Domain.Shared;
using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Uow;

namespace JbCoders.OpenWarehouse.PutawayProcess.Domain.Services;

public class LocationAssignHandler
    : IDistributedEventHandler<StorageUnitAssignedEto>,
        ITransientDependency
{
    private readonly IRepository<Order, Guid> _orderRepository;
    public LocationAssignHandler(IRepository<Order, Guid> orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public virtual async Task HandleEventAsync(StorageUnitAssignedEto eventData)
    {
        var order = await _orderRepository.GetAsync(eventData.OrderId);

        var orderItem = order.Items.FirstOrDefault(_ => _.ProductId == eventData.ProductId);
        if (orderItem == null)
        {
            throw new BusinessException($"Cannot find order item in order with id: {eventData.OrderId} with product id: {eventData.ProductId}");
        }

        foreach (var storageUnitLocationEto in eventData.Locations)
        {
            orderItem.Locations.Add(new Location
            {
                StorageUnitId = storageUnitLocationEto.StorageUnitId,
                HierarchyId = storageUnitLocationEto.HierarchyId,
                Quantity = storageUnitLocationEto.Quantity
            });
        }

        await _orderRepository.UpdateAsync(order, autoSave: true);
    }
}