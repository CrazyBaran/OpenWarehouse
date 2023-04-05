using JbCoders.OpenWarehouse.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OpenWarehouseEntityFrameworkCoreModule),
    typeof(OpenWarehouseApplicationContractsModule)
    )]
public class OpenWarehouseDbMigratorModule : AbpModule
{

}
