export class Leistungsverantw implements ILeistungsverantw {
    userId: number;
    name: string;
    logonName: string;
    displayText: string;
  
    constructor(data?: ILeistungsverantw) {
      if (data) {
        for (const property in data) {
          if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
        }
      }
    }
  }
  
  export interface ILeistungsverantw {
    userId: number,
    name: string,
    logonName: string,
    displayText: string,
  }