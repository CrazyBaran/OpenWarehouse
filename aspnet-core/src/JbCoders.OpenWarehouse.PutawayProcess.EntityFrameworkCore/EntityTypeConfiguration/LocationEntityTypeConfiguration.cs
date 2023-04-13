using JbCoders.OpenWarehouse.PutawayProcess.Domain;
using JbCoders.OpenWarehouse.PutawayProcess.Domain.Orders;
using JbCoders.OpenWarehouse.PutAwayProcess.Domain.Shared.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace JbCoders.OpenWarehouse.PutawayProcess.EntityFrameworkCore.EntityTypeConfiguration;

public class LocationEntityTypeConfiguration 
    : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable(OpenWarehousePutAwayProcessDbProperties.DbTablePrefix + "Locations",
            OpenWarehousePutAwayProcessDbProperties.DbSchema);
        builder.HasKey(_ => new {_.OrderId, _.ProductId, _.StorageUnitId});
        builder.HasIndex(_ => new {_.TenantId, _.OrderId, _.ProductId, _.StorageUnitId});
        builder.HasIndex(_ => new {_.TenantId, _.OrderId, _.ProductId, _.HierarchyId});
        builder.Property(_ => _.TenantId).IsRequired();

        builder.Property(_ => _.Status)
            .HasConversion<EnumToStringConverter<LocationStatus>>()
            .HasMaxLength(256);
        
        builder.ConfigureByConvention();
    }
}