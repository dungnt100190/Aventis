import { Action } from '@ngrx/store';
import { Pendenzen } from '../../models/pendenzen/pendenzen.model';
import { NavBarItems } from '../../models/pendenzen/navBarItems.model';
import { type } from '../../utility';

export const ActionTypes = {
  // Actions Load data
  LOAD: type('[Pendenzens] Load'),
  LOAD_SUCCESS: type('[Pendenzens] Load Success'),
  LOAD_FAIL: type('[Pendenzens] Load Fail'),
  LOAD_NAVBAR: type('[NavBarItems] Load'),
  LOAD_NAVBAR_SUCCESS: type('[NavBarItems] Load Success'),
  LOAD_NAVBAR_FAIL: type('[NavBarItems] Load Fail'),
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

export type Action
  = LoadAction
  | LoadSuccessAction
  | LoadFailAction
  | LoadNavBarAction
  | LoadNavBarSuccessAction
  | LoadNavBarFailAction;
