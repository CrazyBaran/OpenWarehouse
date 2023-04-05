using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.Inventory.Application.Contracts;

[DependsOn(
    typeof(AbpDddApplicationContractsModule))]
public class OpenWarehouseInventoryApplicationContractsModule : AbpModule
{
    
}