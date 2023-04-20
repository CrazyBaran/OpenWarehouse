import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateStorageUnitDto {
  displayName?: string;
  parentStorageUnitHierarchyId?: string;
}

export interface StorageUnitDto extends FullAuditedEntityDto<string> {
  hierarchyId?: string;
  displayName?: string;
}

export interface StorageUnitResultRequestDto extends PagedAndSortedResultRequestDto {
  depth: number;
  parentStorageUnitHierarchyId?: string;
  displayNameSearch?: string;
}
