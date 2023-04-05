using Localization.Resources.AbpUi;
using JbCoders.OpenWarehouse.Localization;
using JbCoders.OpenWarehouse.MasterData.HttpApi;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace JbCoders.OpenWarehouse;

[DependsOn(
    typeof(OpenWarehouseApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(OpenWarehouseMasterDataHttpApiModule)
    )]
public class OpenWarehouseHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<OpenWarehouseResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
