import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'OpenWarehouse',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44371/',
    redirectUri: baseUrl,
    clientId: 'OpenWarehouse_App',
    responseType: 'code',
    scope: 'offline_access OpenWarehouse',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44371',
      rootNamespace: 'JbCoders.OpenWarehouse',
    },
  },
} as Environment;
