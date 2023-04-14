import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StockLocationDto } from '@proxy/inventory/application/contracts/stocks';
import { StockUnitService } from '@proxy/inventory/application/stocks';

@Component({
  selector: 'app-stock-locations',
  templateUrl: './stock-locations.component.html',
  styleUrls: ['./stock-locations.component.scss'],
  providers: [ListService],
})
export class StockLocationsComponent implements OnInit {
  stockId: string;
  stockLocations = { items: [], totalCount: 0 } as PagedResultDto<StockLocationDto>;

  constructor(
    public readonly list: ListService,
    private route: ActivatedRoute,
    private stockUnitService: StockUnitService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.stockId = params['id'];

      const stockStreamCreator = query => this.stockUnitService.getLocations(this.stockId, query);
      this.list.hookToQuery(stockStreamCreator).subscribe(response => {
        this.stockLocations = response;
      });
    });
  }
}
