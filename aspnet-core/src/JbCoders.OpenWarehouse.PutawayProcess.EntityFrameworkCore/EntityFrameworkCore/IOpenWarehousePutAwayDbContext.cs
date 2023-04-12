using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace JbCoders.OpenWarehouse.PutawayProcess.EntityFrameworkCore;

public interface IOpenWarehousePutAwayDbContext : IEfCoreDbContext
{
    DbSet<Order> Orders { get; }
}