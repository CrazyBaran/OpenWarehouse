using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Application;

[DependsOn(
typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule))]
public class OpenWarehousePutAwayProcessApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<OpenWarehousePutAwayProcessApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<OpenWarehousePutAwayProcessApplicationModule>(validate: true);
        });
    }
}