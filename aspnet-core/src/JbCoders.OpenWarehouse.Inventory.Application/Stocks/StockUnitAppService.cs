using JbCoders.OpenWarehouse.Inventory.Application.Contracts.Stocks;
using JbCoders.OpenWarehouse.Inventory.Domain.Stocks;
using JbCoders.OpenWarehouse.Inventory.Domain.Storages;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace JbCoders.OpenWarehouse.Inventory.Application.Stocks;

public class StockUnitAppService : CrudAppService<StockUnit, 
    StockDto, Guid, PagedAndSortedResultRequestDto, CreateStockDto, UpdateStockDto>
{
    private readonly IRepository<StockToStorage> _stockToStorageRepository;
    private readonly IRepository<StorageUnit> _storageUnitRepository;

    public StockUnitAppService(
        IRepository<StockUnit, Guid> repository,
        IRepository<StockToStorage> stockToStorageRepository,
        IRepository<StorageUnit> storageUnitRepository) 
        : base(repository)
    {
        _stockToStorageRepository = stockToStorageRepository;
        _storageUnitRepository = storageUnitRepository;
    }

    public override async Task<StockDto> CreateAsync(CreateStockDto input)
    {
        await CheckCreatePolicyAsync();

        StockUnit? stockUnit = await (await Repository.GetQueryableAsync())
            .Include(_ => _.StockToStorages.Where(_ => _.StorageUnitId == input.StorageUnitId))
            .FirstOrDefaultAsync(_ => _.Id == input.ProductId);

        stockUnit ??= new StockUnit(input.ProductId);

        StorageUnit storageUnit = await _storageUnitRepository.FirstAsync(_ => _.Id == input.StorageUnitId);

        var stockToStorage = new StockToStorage(stockUnit, storageUnit, input.Quantity);

        await _stockToStorageRepository.InsertAsync(stockToStorage, autoSave: true);

        return await MapToGetOutputDtoAsync(stockUnit);
    }

    public override async Task<StockDto> UpdateAsync(Guid id, UpdateStockDto input)
    {
        await CheckUpdatePolicyAsync();
        
        var entity = await (await Repository.GetQueryableAsync())
            .Include(_ => _.StockToStorages.Where(_ => _.StorageUnitId == input.StorageUnitId))
            .FirstAsync(_ => _.Id == id);

        if (entity.StockToStorages.Count == 0)
        {
            var storageUnit = await _storageUnitRepository.FirstAsync(_ => _.Id == input.StorageUnitId);
            entity.StockToStorages.Add(new StockToStorage(storageUnit, input.Quantity));
        }

        entity.StockToStorages.First().Quantity = input.Quantity;
        await Repository.UpdateAsync(entity, autoSave: true);
        
        return await MapToGetOutputDtoAsync(entity);
    }

    public virtual async Task<PagedResultDto<StockLocationDto>> GetLocationsAsync(Guid id, 
        StockLocationResultRequestDto input)
    {
        var query = (await _stockToStorageRepository.GetQueryableAsync())
            .Include(_ => _.StorageUnit).Where(_ => _.StockUnitId == id);
        var totalCount = await AsyncExecuter.CountAsync(query);

        
        var entityDtos = new List<StockLocationDto>();

        if (totalCount > 0)
        {
            var parentHierarchyId = input.ParentStorageUnitHierarchyId == null
                ? HierarchyId.GetRoot()
                : HierarchyId.Parse(input.ParentStorageUnitHierarchyId);

            if (input.ParentStorageUnitHierarchyId != null)
            {
                query = query.Where(ancestor =>
                    ancestor.StorageUnit.HierarchyId != parentHierarchyId &&
                    ancestor.StorageUnit.HierarchyId
                        .IsDescendantOf(parentHierarchyId));
            }
            
            if(input.Depth != null)
            {
                query = query.Where(ancestor =>
                    ancestor.StorageUnit.HierarchyId.GetLevel() <= parentHierarchyId.GetLevel() + input.Depth);
            }

            query = query.OrderBy(_ => _.StorageUnit.HierarchyId);
            query = query.PageBy(input).Take(input.MaxResultCount);
            var entities = await AsyncExecuter.ToListAsync(query);
            entityDtos = ObjectMapper.Map<List<StockToStorage>, List<StockLocationDto>>(entities);
        }
        
        return new PagedResultDto<StockLocationDto>(
            totalCount,
            entityDtos
            );
    }

    protected override async Task<StockDto> MapToGetOutputDtoAsync(StockUnit entity)
    {
        var mapToGetOutputDtoAsync = await base.MapToGetOutputDtoAsync(entity);

        var totalQuantity = await (await _stockToStorageRepository.GetQueryableAsync())
            .Where(_ => _.StockUnitId == entity.Id).SumAsync(_ => _.Quantity);
        
        mapToGetOutputDtoAsync.TotalQuantity = totalQuantity;
        return mapToGetOutputDtoAsync;
    }

    protected override async Task<List<StockDto>> MapToGetListOutputDtosAsync(List<StockUnit> entities)
    {
        var mapToGetListOutputDtosAsync = await base.MapToGetListOutputDtosAsync(entities);
        
        var entitiesIds = entities.Select(_ => _.Id).ToArray();
        var groupStockUnits = await (await _stockToStorageRepository.GetQueryableAsync())
            .Where(_ => entitiesIds.Contains(_.StockUnitId)).GroupBy(_ => _.StockUnitId)
            .Select(_ => new
            {
                StockUnitId = _.Key,
                TotalQuantity = _.Sum(_ => _.Quantity)
            }).ToDictionaryAsync(_ => _.StockUnitId, _ => _);

        foreach (var stockDto in mapToGetListOutputDtosAsync)
        {
            stockDto.TotalQuantity = groupStockUnits.GetValueOrDefault(stockDto.Id)?.TotalQuantity ?? 0;
        }
        
        return mapToGetListOutputDtosAsync;
    }
}