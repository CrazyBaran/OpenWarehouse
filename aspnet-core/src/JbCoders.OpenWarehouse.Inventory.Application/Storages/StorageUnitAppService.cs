using JbCoders.OpenWarehouse.Inventory.Application.Contracts.Storages;
using JbCoders.OpenWarehouse.Inventory.Domain.Storages;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace JbCoders.OpenWarehouse.Inventory.Application.Storages;

public class StorageUnitAppService : CrudAppService<StorageUnit, 
    StorageUnitDto, Guid, StorageUnitResultRequestDto, CreateStorageUnitDto>
{
    public StorageUnitAppService(IRepository<StorageUnit, Guid> repository) : base(repository)
    {
    }

    protected override async Task<StorageUnit> MapToEntityAsync(CreateStorageUnitDto createInput)
    {
        var entity = await base.MapToEntityAsync(createInput);

        var parentHierarchyId = createInput.ParentStorageUnitHierarchyId == null
            ? HierarchyId.GetRoot()
            : HierarchyId.Parse(createInput.ParentStorageUnitHierarchyId);

        var lastDescendantStorageUnit = await (await Repository.GetQueryableAsync())
            .Where(_ => _.HierarchyId.GetAncestor(1) == parentHierarchyId)
            .OrderByDescending(_ => _.HierarchyId).FirstOrDefaultAsync();

        entity.HierarchyId = parentHierarchyId.GetDescendant(lastDescendantStorageUnit?.HierarchyId, null);
        
        return entity;
    }

    protected override async Task<IQueryable<StorageUnit>> CreateFilteredQueryAsync(StorageUnitResultRequestDto input)
    {
        var filteredQueryAsync = await base.CreateFilteredQueryAsync(input);

        var parentHierarchyId = input.ParentStorageUnitHierarchyId is null
            ? HierarchyId.GetRoot()
            : HierarchyId.Parse(input.ParentStorageUnitHierarchyId);
        filteredQueryAsync = filteredQueryAsync
            .Where(ancestor =>
                ancestor.HierarchyId != parentHierarchyId &&
                ancestor.HierarchyId
                    .IsDescendantOf(parentHierarchyId) &&
                ancestor.HierarchyId.GetLevel() <= parentHierarchyId.GetLevel() + input.Depth);

        if (!string.IsNullOrWhiteSpace(input.DisplayNameSearch))
        {
            filteredQueryAsync = filteredQueryAsync
                .Where(_ => _.DisplayName.Contains(input.DisplayNameSearch));
        }
        return filteredQueryAsync;
    }

    protected override IQueryable<StorageUnit> ApplyDefaultSorting(IQueryable<StorageUnit> query)
    {
        return query.OrderBy(_ => _.HierarchyId);
    }
}