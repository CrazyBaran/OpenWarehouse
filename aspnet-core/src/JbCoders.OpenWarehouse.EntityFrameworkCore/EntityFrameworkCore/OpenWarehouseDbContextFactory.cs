using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace JbCoders.OpenWarehouse.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class OpenWarehouseDbContextFactory : IDesignTimeDbContextFactory<OpenWarehouseDbContext>
{
    public OpenWarehouseDbContext CreateDbContext(string[] args)
    {
        OpenWarehouseEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<OpenWarehouseDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"),
                action => action.UseHierarchyId());

        return new OpenWarehouseDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../JbCoders.OpenWarehouse.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
