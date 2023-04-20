import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateStorageUnitDto, StorageUnitDto, StorageUnitResultRequestDto } from '../contracts/storages/models';

@Injectable({
  providedIn: 'root',
})
export class StorageUnitService {
  apiName = 'Default';
  

  create = (input: CreateStorageUnitDto) =>
    this.restService.request<any, StorageUnitDto>({
      method: 'POST',
      url: '/api/app/inventory/storage-unit',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/inventory/storage-unit/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, StorageUnitDto>({
      method: 'GET',
      url: `/api/app/inventory/storage-unit/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: StorageUnitResultRequestDto) =>
    this.restService.request<any, PagedResultDto<StorageUnitDto>>({
      method: 'GET',
      url: '/api/app/inventory/storage-unit',
      params: { depth: input.depth, parentStorageUnitHierarchyId: input.parentStorageUnitHierarchyId, displayNameSearch: input.displayNameSearch, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateStorageUnitDto) =>
    this.restService.request<any, StorageUnitDto>({
      method: 'PUT',
      url: `/api/app/inventory/storage-unit/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
