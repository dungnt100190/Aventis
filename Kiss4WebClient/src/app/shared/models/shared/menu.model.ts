
export class MenuModel implements IMenuModel {
    
    id: any | undefined;
    name: string;
    iconSrc?: string;
    sort?: number;
    disabled?: boolean;
    selected?: boolean;
    items?: IMenuModel[] | null;
    url?: string | undefined;

    constructor(data?: IMenuModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }
}

export interface IMenuModel {
    id: any | undefined;
    name: string;
    iconSrc?: string;
    sort?: number;
    disabled?: boolean;
    selected?: boolean;
    items?: IMenuModel[] | null;
    url?: string | undefined;
}

