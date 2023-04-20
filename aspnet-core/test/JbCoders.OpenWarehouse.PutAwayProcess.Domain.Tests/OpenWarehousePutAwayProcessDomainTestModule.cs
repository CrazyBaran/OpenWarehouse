using JbCoders.OpenWarehouse.PutAwayProcess.EntityFrameworkCore.Tests;
using JbCoders.OpenWarehouse.PutAwayProcess.TestBase;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Domain.Tests;

[DependsOn(
    typeof(OpenWarehousePutAwayProcessEntityFrameworkCoreTestModule)
)]
public class OpenWarehousePutAwayProcessDomainTestModule : AbpModule
{
    
}