using JbCoders.OpenWarehouse.MasterData.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.MasterData.HttpApi;

[DependsOn(
    typeof(OpenWarehouseMasterDataApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class OpenWarehouseMasterDataHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(OpenWarehouseMasterDataHttpApiModule).Assembly);
        });
    }
}