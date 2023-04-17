using JbCoders.OpenWarehouse.PutAwayProcess.TestBase;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Domain.Tests;

[DependsOn(
    typeof(OpenWarehousePutAwayProcessDomainTestModule),
    typeof(OpenWarehousePutAwayProcessTestBaseModule)
)]
public class OpenWarehousePutAwayProcessDomainTestModule : AbpModule
{
    
}