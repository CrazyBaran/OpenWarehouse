using JbCoders.OpenWarehouse.PutawayProcess.EntityFrameworkCore.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace JbCoders.OpenWarehouse.PutawayProcess.EntityFrameworkCore;

public static class OpenWarehousePutAwayDbContextModelCreatingExtensions
{
    public static void ConfigureOpenWarehousePutAwayProcess(
        this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        builder.ApplyConfiguration(new OrderItemEntityTypeConfiguration());
        builder.ApplyConfiguration(new LocationEntityTypeConfiguration());
    }
}