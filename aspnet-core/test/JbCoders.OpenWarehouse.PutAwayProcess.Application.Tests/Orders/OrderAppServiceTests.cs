using JbCoders.OpenWarehouse.PutAwayProcess.Application.Contracts.Orders;
using Shouldly;
using Volo.Abp.Application.Dtos;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Tests.Orders;

public class OrderAppServiceTests : OpenWarehousePutAwayProcessApplicationTestBase
{
    private readonly IOrderAppService _orderAppService;

    public OrderAppServiceTests()
    {
        _orderAppService = GetRequiredService<IOrderAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Orders()
    {
        var result = await _orderAppService.GetListAsync(new PagedAndSortedResultRequestDto());

        result.Items.ShouldNotBeEmpty();
    }
}