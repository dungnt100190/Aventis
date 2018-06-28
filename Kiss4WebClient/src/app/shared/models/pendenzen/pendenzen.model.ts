export class Pendenzen implements IPendenzen {
  OrderNumber?: number;
  OrderDate?: any;
  DeliveryDate?: any;
  SaleAmount?: number;
  Employee?: string;
  CustomerStoreCity?: string;

  constructor(data?: IPendenzen) {
    if (data) {
      for (const property in data) {
        if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
      }
    }
  }
}

export interface IPendenzen {
  OrderNumber?: number;
  OrderDate?: any;
  DeliveryDate?: any;
  SaleAmount?: number;
  Employee?: string;
  CustomerStoreCity?: string;
}
