

using Volo.Abp.Application.Dtos;

namespace JbCoders.OpenWarehouse.MasterData.Application.Contracts.Products;

public class ProductDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }
}