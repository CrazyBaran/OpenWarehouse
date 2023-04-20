import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateOrderDto, OrderDto, UpdateOrderDto } from '../contracts/orders/models';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  apiName = 'Default';
  

  create = (input: CreateOrderDto) =>
    this.restService.request<any, OrderDto>({
      method: 'POST',
      url: '/api/app/put-away-process/order',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/put-away-process/order/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, OrderDto>({
      method: 'GET',
      url: `/api/app/put-away-process/order/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<OrderDto>>({
      method: 'GET',
      url: '/api/app/put-away-process/order',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: UpdateOrderDto) =>
    this.restService.request<any, OrderDto>({
      method: 'PUT',
      url: `/api/app/put-away-process/order/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
