using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace JbCoders.OpenWarehouse.MasterData.Domain.Products;

public class Product : FullAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; protected set; }
    
    public string Name { get; set; }
}