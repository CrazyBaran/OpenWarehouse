import { NgModule } from '@angular/core';

import { InventoryRoutingModule } from './inventory-routing.module';
import { InventoryComponent } from './inventory.component';
import { StoragesComponent } from './storages/storages.component';
import { StocksComponent } from './stocks/stocks.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [InventoryComponent, StoragesComponent, StocksComponent],
  imports: [InventoryRoutingModule, SharedModule],
})
export class InventoryModule {}
