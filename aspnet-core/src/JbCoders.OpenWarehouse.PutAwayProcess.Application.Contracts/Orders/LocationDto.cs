using Volo.Abp.Application.Dtos;

namespace JbCoders.OpenWarehouse.PutAwayProcess.Application.Contracts.Orders;

public class LocationDto : FullAuditedEntityDto
{
    public string Status { get; set; }
    public string HierarchyId { get; set; }
    public decimal Quantity { get; set; }
}