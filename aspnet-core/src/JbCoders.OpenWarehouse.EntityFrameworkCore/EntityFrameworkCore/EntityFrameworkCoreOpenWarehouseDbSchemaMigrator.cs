using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JbCoders.OpenWarehouse.Data;
using Volo.Abp.DependencyInjection;

namespace JbCoders.OpenWarehouse.EntityFrameworkCore;

public class EntityFrameworkCoreOpenWarehouseDbSchemaMigrator
    : IOpenWarehouseDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreOpenWarehouseDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the OpenWarehouseDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<OpenWarehouseDbContext>()
            .Database
            .MigrateAsync();
    }
}
