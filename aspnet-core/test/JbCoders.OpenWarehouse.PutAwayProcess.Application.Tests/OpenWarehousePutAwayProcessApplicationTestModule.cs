using JbCoders.OpenWarehouse.PutAwayProcess.Domain.Tests;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Tests;

[DependsOn(
    typeof(OpenWarehousePutAwayProcessApplicationModule),
    typeof(OpenWarehousePutAwayProcessDomainTestModule)
)]
public class OpenWarehousePutAwayProcessApplicationTestModule : AbpModule
{
    
}