
export class DossierNavigatorTreeModel implements IDossierNavigatorTreeModel {

    id: any | undefined;
    parentId: any | null;
    type?: any;
    iconId?: any;
    name?: any;
    baPersonId: any | null;
    userId?: any | null;
    b?: any;
    f?: any;
    s?: any;
    i?: any;
    m?: any;
    a?: any;
    k?: any;
    faLeistungId?: any | null;
    personCount?: any | undefined;
    orgUnitId?: any | null;

    constructor(data?: IDossierNavigatorTreeModel) {
        if (data) {
            for (const property in data) {
                if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
            }
        }
    }
}

export interface IDossierNavigatorTreeModel {
    id: any | undefined;
    parentId: any | null;
    type?: any;
    iconId?: any;
    name?: any;
    baPersonId: any | null;
    userId?: any | null;
    b?: any;
    f?: any;
    s?: any;
    i?: any;
    m?: any;
    a?: any;
    k?: any;
    faLeistungId?: any | null;
    personCount?: any | undefined;
    orgUnitId?: any | null;
}
