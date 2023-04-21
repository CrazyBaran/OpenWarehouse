import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PutAwayProcessRoutingModule } from './put-away-process-routing.module';
import { PutAwayProcessComponent } from './put-away-process.component';
import { OrdersComponent } from './orders/orders.component';
import { SharedModule } from '../shared/shared.module';
import { UiExtensionsModule } from '@abp/ng.theme.shared/extensions';
import { PageModule } from '@abp/ng.components/page';


@NgModule({
  declarations: [
    PutAwayProcessComponent,
    OrdersComponent
  ],
  imports: [
    PutAwayProcessRoutingModule,
    SharedModule,
  ]
})
export class PutAwayProcessModule { }
