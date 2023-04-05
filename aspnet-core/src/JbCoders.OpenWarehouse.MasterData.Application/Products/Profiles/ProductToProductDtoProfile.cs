using JbCoders.OpenWarehouse.MasterData.Application.Contracts.Products;
using JbCoders.OpenWarehouse.MasterData.Domain.Products;

namespace JbCoders.OpenWarehouse.MasterData.Application.Products.Profiles;

public class ProductToProductDtoProfile : AutoMapper.Profile
{
    public ProductToProductDtoProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}