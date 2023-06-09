using Volo.Abp.Application.Dtos;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Contracts.Orders;

public class OrderDto : FullAuditedEntityDto<Guid>
{
    public string Status { get; set; }
    public List<OrderItemDto> Items { get; set; }
}