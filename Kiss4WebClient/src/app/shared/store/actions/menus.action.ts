import { Action } from '@ngrx/store';
import { MenuModel } from '../../models';
import { type } from '../../utility';

export const ActionTypes = {
  SELECT: type('[Menus] select'),
  AVAIABLE_MENU: type('[Menu] udpates AVAIABLE_MENU'),
  LOAD: type('[Menus] Load'),
  LOAD_SUCCESS: type('[Menus] Load Success'),
  LOAD_FAIL: type('[Menus] Load Fail')
};

/**
 * Menu Action
 */
export class SelectAction implements Action {
  type = ActionTypes.SELECT;

  constructor(public payload: any) { }
}

export class SetAvaiableMenu implements Action {
  type = ActionTypes.AVAIABLE_MENU;

  constructor(public payload: any) { }
}

export class LoadAction implements Action {
  type = ActionTypes.LOAD;

  constructor(public payload: any = null) { }
}

export class LoadSuccessAction implements Action {
  type = ActionTypes.LOAD_SUCCESS;

  constructor(public payload: Array<MenuModel>) { }
}

export class LoadFailAction implements Action {
  type = ActionTypes.LOAD_FAIL;

  constructor(public payload: any = null) { }
}

export type Actions
  = SelectAction
  | SetAvaiableMenu
  | LoadAction
  | LoadSuccessAction
  | LoadFailAction;
