using JbCoders.OpenWarehouse.PutawayProcess.Domain;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Testing;

namespace JbCoders.OpenWarehouse.PutAwayProcess.TestBase;

[DependsOn(
    typeof(OpenWarehousePutAwayProcessDomainModule),
    typeof(AbpTestBaseModule),
    typeof(AbpAutofacModule)
)]
public class OpenWarehousePutAwayProcessTestBaseModule : AbpModule
{
    
}