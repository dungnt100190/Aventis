export class PendenzenDetail implements IPendenzenDetail {
    id?: number;
    status?: number;
    pendenzTyp?: number;
    betreff: string;
    beschreibung: string;
    empfanger?: number;
    empfangerName: string;
    empfangerId?: number;
    falltrager?: number;
    falltragerName: string;
    leistungModul: string;
    leistung?: number;
    leistungName?: string;
    leistungsverantw?: number;
    betrifftPerson?: number;
    antwort: string;
    erfasst: string;
    fallig: string;
    bearbeitungName: string;
    erledigtName: string;
    senderId: string;
    leistungsverantName?: string;
    personId?: number;
    taskTypeName?: string;
    betrifftPersonName?: string;
    ersteller?: string;
    constructor(data?: IPendenzenDetail) {
        if (data) {
            for (const property in data) {
                if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
            }
        }
    }
}

export interface IPendenzenDetail {
    id?: number;
    status?: number;
    pendenzTyp?: number;
    betreff: string;
    beschreibung: string;
    empfanger?: number;
    empfangerName: string;
    empfangerId?: number;
    falltrager?: number;
    falltragerName: string;
    leistungModul: string;
    leistung?: number;
    leistungName?: string;
    leistungsverantw?: number;
    betrifftPerson?: number;
    antwort: string;
    erfasst: string;
    fallig: string;
    bearbeitungName: string;
    erledigtName: string;
    senderId: string;
    leistungsverantName?: string;
    personId?: number;
    taskTypeName?: string;
    betrifftPersonName?: string;
    ersteller?: string;
}