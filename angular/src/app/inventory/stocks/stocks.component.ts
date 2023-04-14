import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { StockDto } from '@proxy/inventory/application/contracts/stocks';
import { StockUnitService } from '@proxy/inventory/application/stocks';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-stocks',
  templateUrl: './stocks.component.html',
  styleUrls: ['./stocks.component.scss'],
  providers: [ListService],
})
export class StocksComponent implements OnInit {
  stocks = { items: [], totalCount: 0 } as PagedResultDto<StockDto>;

  constructor(
    public readonly list: ListService,
    private stockUnitService: StockUnitService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const stockStreamCreator = query => this.stockUnitService.getList(query);

    this.list.hookToQuery(stockStreamCreator).subscribe(response => {
      this.stocks = response;
    });
  }

  showDetails(id: string) {
    this.router.navigate([id, 'locations'], { relativeTo: this.route });
  }
}
