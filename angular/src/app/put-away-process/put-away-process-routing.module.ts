import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PutAwayProcessComponent } from './put-away-process.component';
import { OrdersComponent } from './orders/orders.component';

const routes: Routes = [
  { path: '',
    component: PutAwayProcessComponent,
    children: [
      { path: 'orders', component: OrdersComponent }
    ]
  }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PutAwayProcessRoutingModule { }
