using System.Reflection;
using JbCoders.OpenWarehouse.MasterData.Domain;
using JbCoders.OpenWarehouse.MasterData.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace JbCoders.OpenWarehouse.MasterData.EntityFrameworkCore;

[ConnectionStringName(OpenWarehouseMasterDataDbProperties.ConnectionStringName)]
public class OpenWarehouseMasterDataDbContext : 
    AbpDbContext<OpenWarehouseMasterDataDbContext>
{
    public OpenWarehouseMasterDataDbContext(DbContextOptions<OpenWarehouseMasterDataDbContext> options) : 
        base(options)
    { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}