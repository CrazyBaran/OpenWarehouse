using JbCoders.OpenWarehouse.MasterData.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Cosmos;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.MasterData.EntityFrameworkCore.EntityFrameworkCore;

[DependsOn(
    typeof(OpenWarehouseMasterDataDomainModule),
    typeof(AbpEntityFrameworkCoreCosmosModule)
)]
public class OpenWarehouseMasterDataEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<OpenWarehouseMasterDataDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });
        
        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also OpenWarehouseMigrationsDbContextFactory for EF Core tooling. */
            options.UseCosmos<OpenWarehouseMasterDataDbContext>();
        });
    }

    public override async Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        var db = context.ServiceProvider.GetService<OpenWarehouseMasterDataDbContext>();
        await db.Database.EnsureCreatedAsync();
    }
}