using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace JbCoders.OpenWarehouse.PutawayProcess.EntityFrameworkCore.Repositories.Orders;

public static class OrderEfCoreQueryableExtensions
{
    public static IQueryable<Order> IncludeDetails(this IQueryable<Order> queryable)
    {
        return queryable
            .Include(_ => _.Items)
            .ThenInclude(_ => _.Locations);
    }
}