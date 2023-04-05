using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace JbCoders.OpenWarehouse;

[Dependency(ReplaceServices = true)]
public class OpenWarehouseBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "OpenWarehouse";
}
