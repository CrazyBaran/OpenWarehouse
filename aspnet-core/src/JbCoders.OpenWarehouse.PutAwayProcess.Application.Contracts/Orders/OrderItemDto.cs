using Volo.Abp.Application.Dtos;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Contracts.Orders;

public class OrderItemDto : FullAuditedEntityDto
{
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public List<LocationDto> Locations { get; set; }
}