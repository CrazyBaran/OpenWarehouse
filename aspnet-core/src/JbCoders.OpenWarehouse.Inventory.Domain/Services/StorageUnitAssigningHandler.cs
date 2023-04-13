using JbCoders.OpenWarehouse.Inventory.Domain.Shared;
using JbCoders.OpenWarehouse.Inventory.Domain.Storages;
using JbCoders.OpenWarehouse.PutAwayProcess.Domain.Shared.Orders;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;

namespace JbCoders.OpenWarehouse.Inventory.Domain.Services;

public class StorageUnitAssigningHandler 
    : IDistributedEventHandler<OrderItemReadyForLocationEto>,
        ITransientDependency
{
    private readonly IDistributedEventBus _distributedEventBus;
    private readonly IRepository<StorageUnit> _storageUnitRepository;

    public StorageUnitAssigningHandler(IDistributedEventBus distributedEventBus,
        IRepository<StorageUnit> storageUnitRepository)
    {
        _distributedEventBus = distributedEventBus;
        _storageUnitRepository = storageUnitRepository;
    }
    
    public async Task HandleEventAsync(OrderItemReadyForLocationEto eventData)
    {
        var storageUnitCount = await _storageUnitRepository.CountAsync();
        var randomizer = new Random();
        var skip = randomizer.Next(storageUnitCount);


        var storageUnit = await (await _storageUnitRepository.GetQueryableAsync())
            .Skip(skip).FirstAsync();
        await _distributedEventBus.PublishAsync(new StorageUnitAssignedEto()
        {
            OrderId = eventData.OrderId,
            ProductId = eventData.ProductId,
            StorageUnitId = storageUnit.Id
        });
    }
}