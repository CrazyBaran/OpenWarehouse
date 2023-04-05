using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;

namespace Volo.Abp.EntityFrameworkCore;

public static class AbpDbContextConfigurationContextCosmosExtensions
{
    public static DbContextOptionsBuilder UseCosmos(
        [NotNull] this AbpDbContextConfigurationContext context,
        [CanBeNull] Action<CosmosDbContextOptionsBuilder> sqlServerOptionsAction = null)
    {
        var configuration = context.ServiceProvider.GetService(typeof(IConfiguration)) as IConfiguration;
        return context.DbContextOptions.UseCosmos(context.ConnectionString,
            configuration[$"CosmosDbs:{context.ConnectionStringName}"], 
            optionsBuilder =>
            {
                sqlServerOptionsAction?.Invoke(optionsBuilder);
            });
    }
}