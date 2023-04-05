using JbCoders.OpenWarehouse.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse;

[DependsOn(
    typeof(OpenWarehouseEntityFrameworkCoreTestModule)
    )]
public class OpenWarehouseDomainTestModule : AbpModule
{

}
