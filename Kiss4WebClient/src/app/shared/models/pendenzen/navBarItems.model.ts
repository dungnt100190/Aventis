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
    this.itmMeineFaellig = 0;
    this.itmMeineOffen = 0;
    this.itmMeineInBearbeitung = 0;
    this.itmMeineErstellt = 0;
    this.itmMeineErhalten = 0;
    this.itmMeineZuVisieren = 0;
    this.itmVersandteFaellig = 0;
    this.itmVersandteZuVisieren = 0;
    this.itmVersandteAllgemein = 0;
    this.itmVersandteOffen = 0;
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
