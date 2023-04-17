using JbCoders.OpenWarehouse.PutawayProcess.EntityFrameworkCore;
using JbCoders.OpenWarehouse.PutAwayProcess.TestBase;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Tests;

public abstract class OpenWarehousePutAwayProcessApplicationTestBase
    : OpenWarehousePutAwayProcessTestBase<OpenWarehousePutAwayProcessApplicationTestModule>
{
    protected virtual void UsingDbContext(Action<IOpenWarehousePutAwayDbContext> action)
    {
        using (var dbContext = GetRequiredService<IOpenWarehousePutAwayDbContext>())
        {
            action.Invoke(dbContext);
        }
    }

    protected virtual T UsingDbContext<T>(Func<IOpenWarehousePutAwayDbContext, T> action)
    {
        using (var dbContext = GetRequiredService<IOpenWarehousePutAwayDbContext>())
        {
            return action.Invoke(dbContext);
        }
    }
}