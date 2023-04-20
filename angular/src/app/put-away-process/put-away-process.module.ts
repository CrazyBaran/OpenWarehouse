import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PutAwayProcessRoutingModule } from './put-away-process-routing.module';
import { PutAwayProcessComponent } from './put-away-process.component';
import { OrdersComponent } from './orders/orders.component';


@NgModule({
  declarations: [
    PutAwayProcessComponent,
    OrdersComponent
  ],
  imports: [
    CommonModule,
    PutAwayProcessRoutingModule
  ]
})
export class PutAwayProcessModule { }
