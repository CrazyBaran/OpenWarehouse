import { ModuleWithProviders, NgModule } from '@angular/core';
import { PUT_AWAY_PROCESS_ROUTE_PROVIDER } from './providers/route.provider';

@NgModule()
export class PutAwayProcessConfigModule {
  static forRoot(): ModuleWithProviders<PutAwayProcessConfigModule> {
    return {
      ngModule: PutAwayProcessConfigModule,
      providers: [PUT_AWAY_PROCESS_ROUTE_PROVIDER],
    };
  }
}
