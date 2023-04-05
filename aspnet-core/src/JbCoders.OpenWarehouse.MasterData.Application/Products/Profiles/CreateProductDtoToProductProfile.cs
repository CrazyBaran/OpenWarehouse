using JbCoders.OpenWarehouse.MasterData.Application.Contracts.Products;
using JbCoders.OpenWarehouse.MasterData.Domain.Products;
using Volo.Abp.AutoMapper;

namespace JbCoders.OpenWarehouse.MasterData.Application.Products.Profiles;

public class CreateProductDtoToProductProfile : AutoMapper.Profile
{
    public CreateProductDtoToProductProfile()
    {
        CreateMap<CreateProductDto, Product>()
            .Ignore(_ => _.Id)
            .Ignore(_ => _.TenantId)
            .IgnoreFullAuditedObjectProperties();
    }
}