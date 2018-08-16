export class LeistungPerson implements ILeistungPerson {
    listLeistung: Array<SelectItem> = [];
    listBetrifftPerson: Array<SelectItem> = [];

    constructor(data?: ILeistungPerson) {
        if (data) {
            for (const property in data) {
                if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
            }
        }
    }
}

export interface ILeistungPerson {
    listLeistung: Array<SelectItem>;
    listBetrifftPerson: Array<SelectItem>;
}
class SelectItem {
    value: number;
    name: string;
}