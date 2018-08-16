export class MasterData implements IMasterData {
    lstStatus: Array<SelectItem> = [];
    lstPendenzType: Array<SelectItem> = [];
    lstOrganisationseinheit: Array<SelectItem> = [];

    constructor(data?: IMasterData) {
        if (data) {
            for (const property in data) {
                if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
            }
        }
    }
}

export interface IMasterData {
    lstStatus: Array<SelectItem>,
    lstPendenzType: Array<SelectItem>,
    lstOrganisationseinheit: Array<SelectItem>,
}
class SelectItem {
    value: number;
    name: string;
}