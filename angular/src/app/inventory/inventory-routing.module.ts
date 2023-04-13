import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InventoryComponent } from './inventory.component';
import { StoragesComponent } from './storages/storages.component';
import { StocksComponent } from './stocks/stocks.component';

const routes: Routes = [
  {
    path: '',
    component: InventoryComponent,
    children: [
      { path: 'storages', component: StoragesComponent },
      { path: 'stocks', component: StocksComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InventoryRoutingModule {}
