using JbCoders.OpenWarehouse.Inventory.Domain.Shared;
using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;
using JbCoders.OpenWarehouse.PutawayProcess.Domain.Services;
using JbCoders.OpenWarehouse.PutAwayProcess.TestBase.Data;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Domain.Tests.Orders;

public class LocationAssignHandlerTests : OpenWarehousePutAwayProcessDomainTestBase
{
    private readonly LocationAssignHandler _locationAssignHandler;
    private readonly IRepository<Order, Guid> _orderRepository;
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    
    public LocationAssignHandlerTests()
    {
        _locationAssignHandler = GetRequiredService<LocationAssignHandler>();
        _orderRepository = GetRequiredService<IRepository<Order, Guid>>();
        _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
    }

    [Fact]
    public async Task Should_Assign_Location()
    {
        // Arrange
        var storageUnitAssignedEto = new StorageUnitAssignedEto()
        {
            OrderId = OrderTestData.OrderWithOneLineWaitingForLocation.OrderId,
            ProductId = OrderTestData.OrderWithOneLineWaitingForLocation.OrderLineProductId,
            Locations = new List<StorageUnitLocationEto>()
            {
                new()
                {
                    StorageUnitId = Guid.NewGuid(),
                    HierarchyId = "/1/",
                    Quantity = 10
                }
            }
        };
        
        // Act
        using (var uow = _unitOfWorkManager.Begin())
        {
            await _locationAssignHandler.HandleEventAsync(storageUnitAssignedEto);
            await uow.CompleteAsync();
        }

        // Assert
        var order = await _orderRepository.FindAsync(OrderTestData.OrderWithOneLineWaitingForLocation.OrderId);
        order.ShouldNotBeNull();
        order.Items.ShouldNotBeEmpty();
        order.Items.Count.ShouldBe(1);
        var orderItem = order.Items.First();
        orderItem.Locations.ShouldNotBeNull();
        orderItem.Locations.Count.ShouldBe(1);
        var location = orderItem.Locations.First();
        location.StorageUnitId.ShouldBe(storageUnitAssignedEto.Locations.First().StorageUnitId);
        location.HierarchyId.ShouldBe(storageUnitAssignedEto.Locations.First().HierarchyId);
        location.Quantity.ShouldBe(storageUnitAssignedEto.Locations.First().Quantity);
    }
}