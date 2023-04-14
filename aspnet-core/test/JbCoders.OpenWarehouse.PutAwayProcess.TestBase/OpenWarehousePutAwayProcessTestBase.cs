using Volo.Abp.Modularity;
using Volo.Abp.Testing;

namespace JbCoders.OpenWarehouse.PutAwayProcess.TestBase;

public class OpenWarehousePutAwayProcessTestBase<TStartupModule> 
    : AbpIntegratedTest<TStartupModule>
    where TStartupModule : IAbpModule
{
    
}