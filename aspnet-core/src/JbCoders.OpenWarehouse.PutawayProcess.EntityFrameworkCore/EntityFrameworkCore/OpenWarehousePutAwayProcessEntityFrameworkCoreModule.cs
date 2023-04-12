using JbCoders.OpenWarehouse.PutawayProcess.Domain;
using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;
using JbCoders.OpenWarehouse.PutawayProcess.EntityFrameworkCore.Repositories.Orders;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.PutawayProcess.EntityFrameworkCore;

[DependsOn(typeof(OpenWarehousePutAwayProcessDomainModule))]
[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
public class OpenWarehousePutAwayProcessEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<OpenWarehousePutAwayDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
        });
        
        Configure<AbpEntityOptions>(options =>
        {
            options.Entity<Order>(orderOptions =>
            {
                orderOptions.DefaultWithDetailsFunc = OrderEfCoreQueryableExtensions.IncludeDetails;
            });
        });
    }
}