using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.MasterData.Application.Contracts;

[DependsOn(
    typeof(AbpDddApplicationContractsModule))]
public class OpenWarehouseMasterDataApplicationContractsModule : AbpModule
{
    
}