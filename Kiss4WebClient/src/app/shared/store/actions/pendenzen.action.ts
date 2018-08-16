import { Action } from '@ngrx/store';
import { type } from '../../utility';

import { Pendenzen } from '../../models/pendenzen/pendenzen.model';
import { NavBarItems } from '../../models/pendenzen/navBarItems.model';
import { SearchPendenzen } from '../../models/pendenzen/searchPendenzen.model';
import { ErstellerModel } from '@app/shared/models/pendenzen/ersteller.model';
import { MasterData } from '@app/shared/models/pendenzen/masterData.model';
import { EmpfangerModel } from '@app/shared/models/pendenzen/empfanger.model';
import { Leistungsverantw } from '@app/shared/models/pendenzen/leistungsverantw.model';
import { PendenzenDetail } from '@app/shared/models/pendenzen/pendenzenDetail.model';
import { Falltrager } from '@app/shared/models/pendenzen/falltrager.model';
import { LeistungPerson } from '@app/shared/models/pendenzen/leistungPerson.model';

export const ActionTypes = {
  // Actions Load data
  LOAD: type('[Pendenzens] Load'),
  LOAD_SUCCESS: type('[Pendenzens] Load Success'),
  LOAD_FAIL: type('[Pendenzens] Load Fail'),
  LOAD_NAVBAR: type('[NavBarItems] Load'),
  LOAD_NAVBAR_SUCCESS: type('[NavBarItems] Load Success'),
  LOAD_NAVBAR_FAIL: type('[NavBarItems] Load Fail'),
  LOAD_DETAIL: type('[Pendenzen] Load detail'),
  LOAD_DETAIL_SUCCESS: type('[Pendenzen] Load detail Success'),
  LOAD_DETAIL_FAIL: type('[Pendenzen] Load detail Fail'),

  PROCESS_PENDENZEN: type('Process [Pendenzen] Run'),
  PROCESS_PENDENZEN_SUCCESS: type('Process [Pendenzen] Run Success'),
  PROCESS_PENDENZEN_FAIL: type('Process [Pendenzen] Run Fail'),

  LOAD_SEARCH_OPTION: type('[SearchOption] Load'),
  LOAD_SEARCH_OPTION_SUCCESS: type('[SearchOption] Load Success'),
  LOAD_SEARCH_OPTION_FAIL: type('[SearchOption] Load Fail'),
  LOAD_PENDENZEN_TYPE: type('[PendenzenType] Load'),
  LOAD_PENDENZEN_TYPE_SUCCESS: type('[PendenzenType] Load Success'),
  LOAD_PENDENZEN_TYPE_FAIL: type('[PendenzenType] Load Fail'),
  LOAD_ERSTELLER: type('[LoadErsteller] Load'),
  LOAD_ERSTELLER_SUCCESS: type('[LoadErsteller] Load Success'),
  LOAD_ERSTELLER_FAIL: type('[LoadErsteller] Load Fail'),

  LOAD_MASTER_DATA: type('[Load Master Data] Run'),
  LOAD_MASTER_DATA_SUCCESS: type('[Load Master Data] Run Success'),
  LOAD_MASTER_DATA_FAIL: type('[Load Master Data] Run Fail'),

  LOAD_EMPFANGER: type('[Load Empfanger Data] Run'),
  LOAD_EMPFANGER_SUCCESS: type('[Load Empfanger Data] Run Success'),
  LOAD_EMPFANGER_FAIL: type('[Load Empfanger Data] Run Fail'),

  LOAD_LEISTUNGSVERANTW: type('[Load Leistungsverantw Data] Run'),
  LOAD_LEISTUNGSVERANTW_SUCCESS: type('[Load Leistungsverantw Data] Run Success'),
  LOAD_LEISTUNGSVERANTW_FAIL: type('[Load Leistungsverantw Data] Run Fail'),

  LOAD_FALLTRAGER: type('[Load Falltrager] Run'),
  LOAD_FALLTRAGER_SUCCESS: type('[Load Falltrager] Run Success'),
  LOAD_FALLTRAGER_FAIL: type('[Load Falltrager] Run Fail'),
  LOAD_LEISTUNG_PERSON: type('[Load LeistungPerson] Run'),
  LOAD_LEISTUNG_PERSON_SUCCESS: type('[Load LeistungPerson] Run Success'),
  LOAD_LEISTUNG_PERSON_FAIL: type('[Load LeistungPerson] Run Fail'),

  UPDATE_TASK: type('[Create Update Task] Run'),
  UPDATE_TASK_SUCCESS: type('[Create Update Task] Run Success'),
  UPDATE_TASK_FAIL: type('[Create Update Task] Run Fail'),

  GET_DATA_SEARCH: type('[Get Data Search] Run'),
  GET_DATA_SEARCH_SUCCESS: type('[Get Data Search] Run Success'),
  GET_DATA_SEARCH_FAIL: type('[Get Data Search] Run Fail'),

  LOAD_LEISTUNGSVERANTW_CREATE: type('[Get Leistungsverantw Create] Run'),
  LOAD_LEISTUNGSVERANTW_CREATE_SUCCESS: type('[Get Leistungsverantw Create] Run Success'),
  LOAD_LEISTUNGSVERANTW_CREATE_FAIL: type('[Get Leistungsverantw Create] Run Fail'),
};

export class LoadAction implements Action {
  type = ActionTypes.LOAD;
  constructor(public payload?: any) { }
}

export class LoadSuccessAction implements Action {
  type = ActionTypes.LOAD_SUCCESS;
  constructor(public payload: Array<Pendenzen>) { }
}

export class LoadFailAction implements Action {
  type = ActionTypes.LOAD_FAIL;
  constructor(public payload?: any) { }
}

export class LoadNavBarAction implements Action {
  type = ActionTypes.LOAD_NAVBAR;
  constructor(public payload?: any) { }
}

export class LoadNavBarSuccessAction implements Action {
  type = ActionTypes.LOAD_NAVBAR_SUCCESS;
  constructor(public payload: NavBarItems) { }
}

export class LoadNavBarFailAction implements Action {
  type = ActionTypes.LOAD_NAVBAR_FAIL;
  constructor(public payload?: any) { }
}

export class LoadDetailAction implements Action {
  type = ActionTypes.LOAD_DETAIL;
  constructor(public payload?: any) { }
}

export class LoadDetailSuccessAction implements Action {
  type = ActionTypes.LOAD_DETAIL_SUCCESS;
  constructor(public payload: PendenzenDetail) { }
}

export class LoadDetailFailAction implements Action {
  type = ActionTypes.LOAD_DETAIL_FAIL;
  constructor(public payload?: any) { }
}

export class ProcessPendenzenAction implements Action {
  type = ActionTypes.PROCESS_PENDENZEN;
  constructor(public payload?: any) { }
}

export class ProcessPendenzenSuccessAction implements Action {
  type = ActionTypes.PROCESS_PENDENZEN_SUCCESS;
  constructor(public payload: boolean) { }
}

export class ProcessPendenzenFailAction implements Action {
  type = ActionTypes.PROCESS_PENDENZEN_FAIL;
  constructor(public payload?: any) { }
}

export class LoadSearchOptionAction implements Action {
  type = ActionTypes.LOAD_SEARCH_OPTION;
  constructor(public payload?: any) { }
}

export class LoadSearchOptionSuccessAction implements Action {
  type = ActionTypes.LOAD_SEARCH_OPTION_SUCCESS;
  constructor(public payload: Array<SearchPendenzen>) { }
}

export class LoadSearchOptionFailAction implements Action {
  type = ActionTypes.LOAD_SEARCH_OPTION_FAIL;
  constructor(public payload?: any) { }
}

export class LoadPendenzenTypeAction implements Action {
  type = ActionTypes.LOAD_PENDENZEN_TYPE;
  constructor(public payload?: any) { }
}

export class LoadPendenzenTypeSuccessAction implements Action {
  type = ActionTypes.LOAD_PENDENZEN_TYPE_SUCCESS;
  constructor(public payload: Array<SearchPendenzen>) { }
}

export class LoadPendenzenTypeFailAction implements Action {
  type = ActionTypes.LOAD_PENDENZEN_TYPE_FAIL;
  constructor(public payload?: any) { }
}

export class LoadErstellerAction implements Action {
  type = ActionTypes.LOAD_ERSTELLER;
  constructor(public payload?: any) { }
}

export class LoadErstellerSuccessAction implements Action {
  type = ActionTypes.LOAD_ERSTELLER_SUCCESS;
  constructor(public payload: Array<ErstellerModel>) { }
}

export class LoadErstellerFailAction implements Action {
  type = ActionTypes.LOAD_ERSTELLER_FAIL;
  constructor(public payload?: any) { }
}

export class LoadMasterDataAction implements Action {
  type = ActionTypes.LOAD_MASTER_DATA;
  constructor(public payload?: any) { }
}

export class LoadMasterDataSuccessAction implements Action {
  type = ActionTypes.LOAD_MASTER_DATA_SUCCESS;
  constructor(public payload: MasterData) { }
}

export class LoadMasterDataFailAction implements Action {
  type = ActionTypes.LOAD_MASTER_DATA_FAIL;
  constructor(public payload?: any) { }
}

export class LoadEmpfangerAction implements Action {
  type = ActionTypes.LOAD_EMPFANGER;
  constructor(public payload?: any) { }
}

export class LoadEmpfangerSuccessAction implements Action {
  type = ActionTypes.LOAD_EMPFANGER_SUCCESS;
  constructor(public payload: Array<EmpfangerModel>) { }
}

export class LoadEmpfangerFailAction implements Action {
  type = ActionTypes.LOAD_EMPFANGER_FAIL;
  constructor(public payload?: any) { }
}

export class LoadLeistungsverantwAction implements Action {
  type = ActionTypes.LOAD_LEISTUNGSVERANTW;
  constructor(public payload?: any) { }
}

export class LoadLeistungsverantwSuccessAction implements Action {
  type = ActionTypes.LOAD_LEISTUNGSVERANTW_SUCCESS;
  constructor(public payload: Array<Leistungsverantw>) { }
}

export class LoadLeistungsverantwFailAction implements Action {
  type = ActionTypes.LOAD_LEISTUNGSVERANTW_FAIL;
  constructor(public payload?: any) { }
}

export class LoadFalltragerAction implements Action {
  type = ActionTypes.LOAD_FALLTRAGER;
  constructor(public payload?: any) { }
}

export class LoadFalltragerSuccessAction implements Action {
  type = ActionTypes.LOAD_FALLTRAGER_SUCCESS;
  constructor(public payload: Array<Falltrager>) { }
}

export class LoadFalltragerFailAction implements Action {
  type = ActionTypes.LOAD_FALLTRAGER_FAIL;
  constructor(public payload?: any) { }
}

export class LoadLeistungPersonAction implements Action {
  type = ActionTypes.LOAD_LEISTUNG_PERSON;
  constructor(public payload?: any) { }
}

export class LoadLeistungPersonSuccessAction implements Action {
  type = ActionTypes.LOAD_LEISTUNG_PERSON_SUCCESS;
  constructor(public payload: LeistungPerson) { }
}

export class LoadLeistungPersonFailAction implements Action {
  type = ActionTypes.LOAD_LEISTUNG_PERSON_FAIL;
  constructor(public payload?: any) { }
}

export class UpdateTaskAction implements Action {
  type = ActionTypes.UPDATE_TASK;
  constructor(public payload?: any) { }
}

export class UpdateTaskSuccessAction implements Action {
  type = ActionTypes.UPDATE_TASK_SUCCESS;
  constructor(public payload: boolean) { }
}

export class UpdateTaskFailAction implements Action {
  type = ActionTypes.UPDATE_TASK_FAIL;
  constructor(public payload?: any) { }
}

export class GetDataSearchAction implements Action {
  type = ActionTypes.GET_DATA_SEARCH;
  constructor(public payload?: any) { }
}

export class GetDataSearchSuccessAction implements Action {
  type = ActionTypes.GET_DATA_SEARCH_SUCCESS;
  constructor(public payload: boolean) { }
}

export class GetDataSearchFailAction implements Action {
  type = ActionTypes.GET_DATA_SEARCH_FAIL;
  constructor(public payload?: any) { }
}

export class GetLeistungsverantwCreateAction implements Action {
  type = ActionTypes.LOAD_LEISTUNGSVERANTW_CREATE;
  constructor(public payload?: any) { }
}

export class GetLeistungsverantwCreateSuccessAction implements Action {
  type = ActionTypes.LOAD_LEISTUNGSVERANTW_CREATE_SUCCESS;
  constructor(public payload: boolean) { }
}

export class GetLeistungsverantwCreateFailAction implements Action {
  type = ActionTypes.LOAD_LEISTUNGSVERANTW_CREATE_FAIL;
  constructor(public payload?: any) { }
}

export type Action
  = LoadAction
  | LoadSuccessAction
  | LoadFailAction
  | LoadNavBarAction
  | LoadNavBarSuccessAction
  | LoadNavBarFailAction
  | LoadDetailAction
  | LoadDetailSuccessAction
  | LoadDetailFailAction
  | ProcessPendenzenAction
  | ProcessPendenzenSuccessAction
  | ProcessPendenzenFailAction
  | LoadSearchOptionAction
  | LoadSearchOptionSuccessAction
  | LoadSearchOptionFailAction
  | LoadErstellerAction
  | LoadErstellerSuccessAction
  | LoadErstellerFailAction
  | LoadMasterDataAction
  | LoadMasterDataSuccessAction
  | LoadMasterDataFailAction
  | LoadEmpfangerAction
  | LoadEmpfangerSuccessAction
  | LoadEmpfangerFailAction
  | LoadLeistungsverantwAction
  | LoadLeistungsverantwSuccessAction
  | LoadLeistungsverantwFailAction
  | LoadFalltragerAction
  | LoadFalltragerSuccessAction
  | LoadFalltragerFailAction
  | LoadLeistungPersonAction
  | LoadLeistungPersonSuccessAction
  | LoadLeistungPersonFailAction
  | UpdateTaskAction
  | UpdateTaskSuccessAction
  | UpdateTaskFailAction
  | GetDataSearchAction
  | GetDataSearchSuccessAction
  | GetDataSearchFailAction
  | GetLeistungsverantwCreateAction
  | GetLeistungsverantwCreateSuccessAction
  | GetLeistungsverantwCreateFailAction;
