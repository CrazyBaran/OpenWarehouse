import type { FullAuditedEntityDto } from '@abp/ng.core';

export interface CreateOrderDto {
  items: CreateOrderItemDto[];
}

export interface CreateOrderItemDto {
  productId?: string;
  quantity: number;
}

export interface LocationDto extends FullAuditedEntityDto {
  status?: string;
  hierarchyId?: string;
  quantity: number;
}

export interface OrderDto extends FullAuditedEntityDto<string> {
  status?: string;
  items: OrderItemDto[];
}

export interface OrderItemDto extends FullAuditedEntityDto {
  productId?: string;
  quantity: number;
  locations: LocationDto[];
}

export interface UpdateOrderDto {
  status?: string;
}
