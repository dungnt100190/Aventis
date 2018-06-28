export class DossierFilterModel implements IDossierFilterModel {
    UserId?: any | null;
    Active?: boolean;
    Closed?: boolean;
    Archived?: boolean;
    IncludeGroup?: boolean;
    IncludeGuest?: boolean;
    IncludeTasks?: boolean;

    constructor(data?: IDossierFilterModel) {
        if (data) {
            for (const property in data) {
                if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
            }
        }
    }
}

export interface IDossierFilterModel {
    UserId?: any | null;
    Active?: boolean;
    Closed?: boolean;
    Archived?: boolean;
    IncludeGroup?: boolean;
    IncludeGuest?: boolean;
    IncludeTasks?: boolean;
}
