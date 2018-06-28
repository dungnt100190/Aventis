export class Person {
  public id: any;
  public name: string;
  public vorname: string;
  public nnummer?: string;
  public bffnummer?: any;
  constructor(data?: IPerson) {
    if (data) {
      for (const property in data) {
        if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
      }
    }
  }
}

export interface IPerson {
  id: any;
  name: string;
  vorname: string;
  nnummer?: string;
  bffnummer?: any;
}
