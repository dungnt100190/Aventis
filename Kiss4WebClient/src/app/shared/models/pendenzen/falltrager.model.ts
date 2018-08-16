export class Falltrager implements IFalltrager {
    id?: number;
    name?: string;
    vorname?: string;
    benutzer?: string
    faFallID?: number;
    nameVorname?: string;

    constructor(data?: IFalltrager) {
        if (data) {
            for (const property in data) {
                if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
            }
        }
    }
}

export interface IFalltrager {
    id?: number;
    name?: string;
    vorname?: string;
    benutzer?: string
    faFallID?: number;
    nameVorname?: string;
}