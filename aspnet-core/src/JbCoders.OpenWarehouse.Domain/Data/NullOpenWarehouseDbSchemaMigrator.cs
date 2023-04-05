using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace JbCoders.OpenWarehouse.Data;

/* This is used if database provider does't define
 * IOpenWarehouseDbSchemaMigrator implementation.
 */
public class NullOpenWarehouseDbSchemaMigrator : IOpenWarehouseDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
