import type { AuditedEntityDto, FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateStockDto {
  productId?: string;
  storageUnitId?: string;
  quantity: number;
}

export interface StockDto extends FullAuditedEntityDto<string> {
  totalQuantity: number;
}

export interface StockLocationDto extends AuditedEntityDto {
  storageUnitId?: string;
  hierarchyId?: string;
  displayName?: string;
  quantity: number;
}

export interface StockLocationResultRequestDto extends PagedAndSortedResultRequestDto {
  depth?: number;
  parentStorageUnitHierarchyId?: string;
}

export interface UpdateStockDto {
  storageUnitId?: string;
  quantity: number;
}
