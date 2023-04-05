using JbCoders.OpenWarehouse.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace JbCoders.OpenWarehouse.Permissions;

public class OpenWarehousePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(OpenWarehousePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(OpenWarehousePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OpenWarehouseResource>(name);
    }
}
