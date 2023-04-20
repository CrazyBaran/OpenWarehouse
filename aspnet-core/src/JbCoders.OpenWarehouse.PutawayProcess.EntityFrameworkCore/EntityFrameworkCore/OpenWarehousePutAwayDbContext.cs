using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace JbCoders.OpenWarehouse.PutawayProcess.EntityFrameworkCore;

public class OpenWarehousePutAwayDbContext : 
    AbpDbContext<OpenWarehousePutAwayDbContext>, IOpenWarehousePutAwayDbContext
{
    public OpenWarehousePutAwayDbContext(DbContextOptions<OpenWarehousePutAwayDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders => Set<Order>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureOpenWarehousePutAwayProcess();
    }
}