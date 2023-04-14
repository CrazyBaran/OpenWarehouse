using JbCoders.OpenWarehouse.PutawayProcess.EntityFrameworkCore;
using JbCoders.OpenWarehouse.PutAwayProcess.TestBase;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace JbCoders.OpenWarehouse.PutAwayProcess.EntityFrameworkCore.Tests;

[DependsOn(
    typeof(OpenWarehousePutAwayProcessEntityFrameworkCoreModule),
    typeof(OpenWarehousePutAwayProcessTestBaseModule),
    typeof(AbpEntityFrameworkCoreSqliteModule)
)]
public class OpenWarehousePutAwayProcessEntityFrameworkCoreTestModule : AbpModule
{
    private SqliteConnection _sqliteConnection;
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        _sqliteConnection = CreateDatabaseAndGetConnection();

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(abpDbContextConfigurationContext =>
            {
                abpDbContextConfigurationContext.DbContextOptions.UseSqlite(_sqliteConnection);
            });
        });
    }
    
    private static SqliteConnection CreateDatabaseAndGetConnection()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<OpenWarehousePutAwayDbContext>().UseSqlite(connection).Options;
        using (var context = new OpenWarehousePutAwayDbContext(options))
        {
            context.GetService<IRelationalDatabaseCreator>().CreateTables();
        }

        return connection;
    }

    public override void OnApplicationShutdown(ApplicationShutdownContext context)
    {
        _sqliteConnection.Dispose();
    }
}