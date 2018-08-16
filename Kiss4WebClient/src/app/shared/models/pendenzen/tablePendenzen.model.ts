import { ISeachAndTable, SeachAndTable } from "@app/shared/models/pendenzen/searchAndTable.model";

export class TablePendenzen implements ITablePendenzen {
    id?: number;
    fallig?: Date;
    betreff?: string;
    leistungsverantw?: string;
    fallnummer?: number;
    ersteller?: string;
    empfanger?: string;
    status?: string;
    erfasst?: Date;
    bearbeitung?: Date;
    erledigt?: Date
    falltrager?: string;
    person?: string;
    antwort?: string;

    constructor(data?: ITablePendenzen) {
        if (data) {
            for (const property in data) {
                if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
            }
        }
    }
}

export interface ITablePendenzen {
    id?: number,
    fallig?: Date,
    betreff?: string,
    leistungsverantw?: string,
    fallnummer?: number,
    ersteller?: string,
    empfanger?: string,
    status?: string,
    erfasst?: Date,
    bearbeitung?: Date,
    erledigt?: Date,
    falltrager?: string,
    person?: string,
    antwort?: string
}