using JbCoders.OpenWarehouse.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace JbCoders.OpenWarehouse.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class OpenWarehouseController : AbpControllerBase
{
    protected OpenWarehouseController()
    {
        LocalizationResource = typeof(OpenWarehouseResource);
    }
}
