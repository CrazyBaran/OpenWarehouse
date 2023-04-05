using JbCoders.OpenWarehouse.MasterData.Application.Contracts.Products;
using JbCoders.OpenWarehouse.MasterData.Domain.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace JbCoders.OpenWarehouse.MasterData.Application.Products;

[UnitOfWork(isTransactional: false)]
public class ProductAppService : CrudAppService<Product, 
    ProductDto, Guid, PagedAndSortedResultRequestDto, CreateProductDto>
{
    public ProductAppService(IRepository<Product, Guid> repository) : base(repository)
    {
    }
}