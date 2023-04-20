using Volo.Abp.Data;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.PutawayProcess.Domain;

[DependsOn(typeof(AbpDddDomainModule),
typeof(AbpDataModule))]
public class OpenWarehousePutAwayProcessDomainModule : AbpModule
{
    
}