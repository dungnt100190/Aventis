export class ErstellerModel implements IErstellerModel {
    typ : string;
    kurzel: string;
    name: string;
    abteilung: string;
    id?: number;
    typeCode?: number;
    displayText: string;
  
    constructor(data?: IErstellerModel) {
      if (data) {
        for (const property in data) {
          if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
        }
      }
    }
  }
  
  export interface IErstellerModel {
    typ : string,
    kurzel: string,
    name: string,
    abteilung: string,
    id?: number,
    typeCode?: number,
    displayText: string
  }