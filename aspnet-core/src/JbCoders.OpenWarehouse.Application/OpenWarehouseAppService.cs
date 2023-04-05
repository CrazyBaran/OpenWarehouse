using System;
using System.Collections.Generic;
using System.Text;
using JbCoders.OpenWarehouse.Localization;
using Volo.Abp.Application.Services;

namespace JbCoders.OpenWarehouse;

/* Inherit your application services from this class.
 */
public abstract class OpenWarehouseAppService : ApplicationService
{
    protected OpenWarehouseAppService()
    {
        LocalizationResource = typeof(OpenWarehouseResource);
    }
}
