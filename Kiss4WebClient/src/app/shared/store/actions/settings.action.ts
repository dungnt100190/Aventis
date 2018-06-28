import { Action } from '@ngrx/store';
import { type } from '../../utility';

export const ActionTypes = {
  SET_LANGUAGE: type('[Settings] SetLanguage'),
  SET_CULTURE: type('[Settings] SetCulture'),
  LOAD_API_ROLES: type('[LOAD_API_ROLES] call api'),
  SET_AVAIBLE_ROLES: type('[SET_AVAIBLE_ROLES] Get data'),
  LOAD_FAIL: type('[LOAD_FAIL] Load Fail'),
  LOAD_API_LANGUAGE: type('[LOAD_API_LANGUAGE] call api translations'),
  SET_AVAIBLE_LANGUAGE: type('[SET_AVAIBLE_LANGUAGE] Get data'),
  UPDATE_SELECT_ACTION: type('[UPDATE_SELECT_ACTION] Set'),
  DELETE_ITEM_SELECT_ACTION: type('[DELETE_ITEM_SELECT_ACTION] update'),
  RESET_STATE: type('[RESET_STATE] reset state for setting'),
  DOCUMENT_CREATE: type('[Document create action] call'),
  DOCUMENT_CREATE_SUCCESS: type('[Document create action] Success'),
  DOCUMENT_CREATE_ERROR: type('[Document create action] Error')
};

/**
 * Settings Actions
 */
export class SetLanguageAction implements Action {
  type = ActionTypes.SET_LANGUAGE;

  constructor(public payload: string) { }
}

export class SetCultureAction implements Action {
  type = ActionTypes.SET_CULTURE;

  constructor(public payload: string) { }
}

export class LoadApiRolesAction implements Action {
  type = ActionTypes.LOAD_API_ROLES;

  constructor(public payload: any = null) { };
}

export class SetAvailableRolesAction implements Action {
  type = ActionTypes.SET_AVAIBLE_ROLES;

  constructor(public payload: any) { };
}

export class LoadFailAction implements Action {
  type = ActionTypes.LOAD_FAIL;

  constructor(public payload: any = null) { };
}

// language
export class LoadApiLangsAction implements Action {
  type = ActionTypes.LOAD_API_LANGUAGE;

  constructor(public payload: any = null) { };
}

export class SetAvailableLanguagesAction implements Action {
  type = ActionTypes.SET_AVAIBLE_LANGUAGE;

  constructor(public payload: any) { };
}

export class UpdateSelectedAction implements Action {
  type = ActionTypes.UPDATE_SELECT_ACTION;
  constructor(public payload: any) { }
}

export class DeleteItemSelectedAction implements Action {
  type = ActionTypes.DELETE_ITEM_SELECT_ACTION;
  constructor(public payload: any) { }
}

export class ResetState implements Action {
  type = ActionTypes.RESET_STATE;
  constructor(public payload: any = null) { }
}

// DOCUMENT CREATE FEATURE
export class DocumentCreate implements Action {
  type = ActionTypes.DOCUMENT_CREATE;
  constructor(public payload: any = null) { };
}

export class DocumentCreateSuccess implements Action {
  type = ActionTypes.DOCUMENT_CREATE_SUCCESS;
  constructor(public payload: any = null) { };
}

export class DocumentCreateError implements Action {
  type = ActionTypes.DOCUMENT_CREATE;
  constructor(public payload: any = null) { };
}
// DOCUMENT CREATE FEATURE

export type Actions
  = SetLanguageAction
  | SetCultureAction
  | LoadApiRolesAction
  | SetAvailableRolesAction
  | LoadFailAction
  | LoadApiLangsAction
  | SetAvailableLanguagesAction
  | UpdateSelectedAction
  | DeleteItemSelectedAction
  | ResetState
  | DocumentCreate
  | DocumentCreateSuccess
  | DocumentCreateError;
