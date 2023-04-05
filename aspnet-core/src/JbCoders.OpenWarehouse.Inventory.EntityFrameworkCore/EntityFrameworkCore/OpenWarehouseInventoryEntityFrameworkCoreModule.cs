using JbCoders.OpenWarehouse.Inventory.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.Inventory.EntityFrameworkCore;

[DependsOn(typeof(OpenWarehouseInventoryDomainModule))]
[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
public class OpenWarehouseInventoryEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<OpenWarehouseInventoryDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
        });
    }
}