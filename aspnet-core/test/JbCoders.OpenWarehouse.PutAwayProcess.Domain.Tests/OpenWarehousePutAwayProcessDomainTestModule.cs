using JbCoders.OpenWarehouse.PutAwayProcess.EntityFrameworkCore.Tests;
using JbCoders.OpenWarehouse.PutAwayProcess.TestBase;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Domain.Tests;

[DependsOn(
    typeof(OpenWarehousePutAwayProcessEntityFrameworkCoreTestModule),
    typeof(OpenWarehousePutAwayProcessTestBaseModule)
)]
public class OpenWarehousePutAwayProcessDomainTestModule : AbpModule
{
    
}