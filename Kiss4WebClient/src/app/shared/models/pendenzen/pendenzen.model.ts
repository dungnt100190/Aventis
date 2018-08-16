export class Pendenzen implements IPendenzen {
    id?: number;
    fallig?: Date;
    betreff?: string;
    leistungsverantw?: string;
    fallnummer?: string;
    ersteller?: string;
    empfanger?: string;
    status?: string;
    erfasst?: Date;
    bearbeitung?: Date;
    erledigt?: Date
    falltrager?: string;
    person?: string;
    antwort?: string;

    constructor(data?: IPendenzen) {
        if (data) {
            for (const property in data) {
                if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
            }
        }
    }
}

export interface IPendenzen {
    id?: number;
    fallig?: Date;
    betreff?: string;
    leistungsverantw?: string;
    fallnummer?: string;
    ersteller?: string;
    empfanger?: string;
    status?: string;
    erfasst?: Date;
    bearbeitung?: Date;
    erledigt?: Date;
    falltrager?: string;
    person?: string;
    antwort?: string;
}