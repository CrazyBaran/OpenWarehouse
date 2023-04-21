import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { OrderDto } from '@proxy/put-away-process/application/contracts/orders';
import { OrderService } from '@proxy/put-away-process/application/orders';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss'],
  providers: [ListService],
})
export class OrdersComponent implements OnInit {
  orders = { items: [], totalCount: 0 } as PagedResultDto<OrderDto>;

  constructor(public readonly list: ListService,
              private orderService: OrderService) { }

  ngOnInit(): void {
    const orderStreamCreator = query => this.orderService.getList(query);

    this.list.hookToQuery(orderStreamCreator).subscribe(response => {
      this.orders = response;
    });
  }
}
