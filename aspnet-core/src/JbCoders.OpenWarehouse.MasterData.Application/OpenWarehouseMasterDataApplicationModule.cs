using JbCoders.OpenWarehouse.MasterData.Application.Contracts;
using JbCoders.OpenWarehouse.MasterData.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.MasterData.Application;

[DependsOn(typeof(OpenWarehouseMasterDataDomainModule),
    typeof(OpenWarehouseMasterDataApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule))]
public class OpenWarehouseMasterDataApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<OpenWarehouseMasterDataApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<OpenWarehouseMasterDataApplicationModule>(validate: true);
        });
    }
}