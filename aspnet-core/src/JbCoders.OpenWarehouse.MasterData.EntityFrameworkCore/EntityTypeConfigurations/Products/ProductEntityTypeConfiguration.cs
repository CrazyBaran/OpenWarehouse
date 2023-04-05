using JbCoders.OpenWarehouse.MasterData.Domain;
using JbCoders.OpenWarehouse.MasterData.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JbCoders.OpenWarehouse.MasterData.EntityFrameworkCore.EntityTypeConfigurations.Products;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToContainer(OpenWarehouseMasterDataDbProperties.DbTablePrefix + "Products");
        builder.HasNoDiscriminator();
        builder.HasKey(_ => new {_.TenantId, _.Id});
        builder.Property(_ => _.Id).ToJsonProperty("id");
        builder.HasPartitionKey(_ => _.TenantId);
    }
}