using JbCoders.OpenWarehouse.Inventory.Domain.Shared;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace JbCoders.OpenWarehouse.PutawayProcess.Domain.Services;

public class LocationAssignHandler
    : IDistributedEventHandler<StorageUnitAssignedEto>,
        ITransientDependency
{
    public async Task HandleEventAsync(StorageUnitAssignedEto eventData)
    {
        
    }
}