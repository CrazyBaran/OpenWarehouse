using Volo.Abp.Settings;

namespace JbCoders.OpenWarehouse.Settings;

public class OpenWarehouseSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(OpenWarehouseSettings.MySetting1));
    }
}
