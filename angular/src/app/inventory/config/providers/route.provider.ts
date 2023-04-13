import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eInventoryRouteNames } from '../enums/route-names';

export const INVENTORY_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

export function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: undefined,
        name: eInventoryRouteNames.InventoryManagement,
        iconClass: 'fas fa-clipboard-list',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/inventory/storages',
        name: eInventoryRouteNames.Storages,
        parentName: eInventoryRouteNames.InventoryManagement,
        iconClass: 'fas fa-warehouse',
        order: 1,
      },
      {
        path: '/inventory/stocks',
        name: eInventoryRouteNames.Stocks,
        parentName: eInventoryRouteNames.InventoryManagement,
        iconClass: 'fas fa-boxes',
        order: 1,
      },
    ]);
  };
}
