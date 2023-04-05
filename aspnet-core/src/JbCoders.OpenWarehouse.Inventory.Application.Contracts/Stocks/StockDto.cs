using Volo.Abp.Application.Dtos;

namespace JbCoders.OpenWarehouse.Inventory.Application.Contracts.Stocks;

public class StockDto : FullAuditedEntityDto<Guid>
{
    public decimal TotalQuantity { get; set; }
}