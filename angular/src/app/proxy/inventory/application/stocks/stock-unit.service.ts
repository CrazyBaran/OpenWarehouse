import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateStockDto, StockDto, StockLocationDto, StockLocationResultRequestDto, UpdateStockDto } from '../contracts/stocks/models';

@Injectable({
  providedIn: 'root',
})
export class StockUnitService {
  apiName = 'Default';
  

  create = (input: CreateStockDto) =>
    this.restService.request<any, StockDto>({
      method: 'POST',
      url: '/api/app/inventory/stock-unit',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/inventory/stock-unit/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, StockDto>({
      method: 'GET',
      url: `/api/app/inventory/stock-unit/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<StockDto>>({
      method: 'GET',
      url: '/api/app/inventory/stock-unit',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getLocations = (id: string, input: StockLocationResultRequestDto) =>
    this.restService.request<any, PagedResultDto<StockLocationDto>>({
      method: 'GET',
      url: `/api/app/inventory/stock-unit/${id}/locations`,
      params: { depth: input.depth, parentStorageUnitHierarchyId: input.parentStorageUnitHierarchyId, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: UpdateStockDto) =>
    this.restService.request<any, StockDto>({
      method: 'PUT',
      url: `/api/app/inventory/stock-unit/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
