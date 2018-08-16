import { SeachAndTable } from "@app/shared/models/pendenzen/searchAndTable.model";

export class SearchPendenzen extends SeachAndTable implements ISearchPendenzen {
  idStatus?: number;
    idPendenzTyp?: number;
    betreff?: string;
    idErsteller?: number;
    idEmpfanger?: number;
    nameKlientIn?: string;
    vornameKlientIn?: string;
    fallnummer?: number;
    idLeistungsverantw?: number;
    idOrganisationseinheit?: number;
    fromErfasst?: string;
    toErfasst?: string;
    fromFallig?: string;
    toFallig?: string;
    fromBearbeitung?: string;
    toBearbeitung?: string;
    fromErledigt?: string;
    toErledigt?: string;
    idMenu?: string;
  
    constructor(data?: ISearchPendenzen) {
      super();
      if (data) {
        for (const property in data) {
          if (data.hasOwnProperty(property)) { (<any>this)[property] = (<any>data)[property]; }
        }
      }
    }
  }
  
  export interface ISearchPendenzen {
    idStatus?: number,
    idPendenzTyp?: number,
    betreff?: string,
    idErsteller?: number,
    idEmpfanger?: number,
    nameKlientIn?: string,
    vornameKlientIn?: string,
    fallnummer?: number,
    idLeistungsverantw?: number,
    idOrganisationseinheit?: number,
    fromErfasst?: string,
    toErfasst?: string,
    fromFallig?: string,
    toFallig?: string,
    fromBearbeitung?: string,
    toBearbeitung?: string,
    fromErledigt?: string,
    toErledigt?: string,
    idMenu?: string;
  }