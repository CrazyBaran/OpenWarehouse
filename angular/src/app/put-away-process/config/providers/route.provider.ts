import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { ePutAwayProcessRouteNames } from '../enums/route-names';

export const PUT_AWAY_PROCESS_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

export function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: undefined,
        name: ePutAwayProcessRouteNames.PutAwayProcessManagement,
        iconClass: 'fas fa-dolly',
        order: 3,
        layout: eLayoutType.application,
      },
      {
        path: '/put-away-process/orders',
        name: ePutAwayProcessRouteNames.Orders,
        parentName: ePutAwayProcessRouteNames.PutAwayProcessManagement,
        iconClass: 'fas fa-file',
        order: 1,
      }
    ]);
  };
}
