using JbCoders.OpenWarehouse.Inventory.Application.Contracts;
using JbCoders.OpenWarehouse.Inventory.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.Inventory.Application;

[DependsOn(typeof(OpenWarehouseInventoryDomainModule),
    typeof(OpenWarehouseInventoryApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule))]
public class OpenWarehouseInventoryApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<OpenWarehouseInventoryApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<OpenWarehouseInventoryApplicationModule>(validate: true);
        });
    }
}