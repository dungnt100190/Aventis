export class NavBarItems implements INavBarItems {
  itmMeineFaellig?: number;
  itmMeineOffen?: number;
  itmMeineInBearbeitung?: number;
  itmMeineErstellt?: number;
  itmMeineErhalten?: number;
  itmMeineZuVisieren?: number;
  itmVersandteFaellig?: number;
  itmVersandteZuVisieren?: number;
  itmVersandteAllgemein?: number;
  itmVersandteOffen?: number;

  constructor(data?: INavBarItems) {
    if (data) {
      for (const property in data) {
        if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
      }
    }
  }
}

export interface INavBarItems {
  itmMeineFaellig?: number;
  itmMeineOffen?: number;
  itmMeineInBearbeitung?: number;
  itmMeineErstellt?: number;
  itmMeineErhalten?: number;
  itmMeineZuVisieren?: number;
  itmVersandteFaellig?: number;
  itmVersandteZuVisieren?: number;
  itmVersandteAllgemein?: number;
  itmVersandteOffen?: number;
}
