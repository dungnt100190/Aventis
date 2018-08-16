export class SeachAndTable implements ISeachAndTable {
    id?: number;
    fallig?: Date;
    betreff?: string;
    leistungsverantw?: object[];
    fallnummer?: number;
    ersteller?: object[];
    empfanger?: object[];
    status?: object[];
    erfasst?: Date;
    bearbeitung?: Date;
    erledigt?: Date;
  
    constructor(data?: ISeachAndTable) {
      if (data) {
        for (const property in data) {
          if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
        }
      }
    }
  }
  
  export interface ISeachAndTable {
    id?: number,
    fallig?: Date,
    betreff?: string,
    leistungsverantw?: object[],
    fallnummer?: number,
    ersteller?: object[],
    empfanger?: object[],
    status?: object[],
    erfasst?: Date,
    bearbeitung?: Date,
    erledigt?: Date
  }