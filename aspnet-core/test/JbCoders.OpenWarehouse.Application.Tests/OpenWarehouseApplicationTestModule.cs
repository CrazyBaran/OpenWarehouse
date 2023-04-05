using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse;

[DependsOn(
    typeof(OpenWarehouseApplicationModule),
    typeof(OpenWarehouseDomainTestModule)
    )]
public class OpenWarehouseApplicationTestModule : AbpModule
{

}
