using System.Threading.Tasks;

namespace JbCoders.OpenWarehouse.Data;

public interface IOpenWarehouseDbSchemaMigrator
{
    Task MigrateAsync();
}
