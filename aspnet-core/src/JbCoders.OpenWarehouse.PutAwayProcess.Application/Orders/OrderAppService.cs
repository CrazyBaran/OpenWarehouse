using JbCoders.OpenWarehouse.PutAwayProcess.Application.Contracts.Orders;
using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Orders;

public class OrderAppService : CrudAppService<Order,OrderDto,Guid>
{
    public OrderAppService(IRepository<Order, Guid> repository) : base(repository)
    {
    }
}