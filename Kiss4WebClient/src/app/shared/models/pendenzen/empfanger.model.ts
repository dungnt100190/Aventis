export class EmpfangerModel implements IEmpfangerModel {
    typ: string;
    kurzel: string;
    name: string;
    abteilung: string;
    id?: number;
    typeCode?: number;
    displayText: string;

    constructor(data?: IEmpfangerModel) {
        if (data) {
            for (const property in data) {
                if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
            }
        }
    }
}

export interface IEmpfangerModel {
    typ: string,
    kurzel: string,
    name: string,
    abteilung: string,
    id?: number,
    typeCode?: number,
    displayText: string
}