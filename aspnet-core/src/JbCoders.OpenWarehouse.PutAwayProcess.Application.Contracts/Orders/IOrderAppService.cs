using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Contracts.Orders;

public interface IOrderAppService: ICrudAppService<OrderDto,Guid, PagedAndSortedResultRequestDto,
    CreateOrderDto, UpdateOrderDto>, ITransientDependency
{
    
}