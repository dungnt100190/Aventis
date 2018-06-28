import { Action } from '@ngrx/store';
import { SearchBoxModel } from '../../models';
import { type } from '../../utility';

export const ActionTypes = {
  LOAD: type('[Search Box data] Load'),
  LOAD_SUCCESS: type('[Search Box data] Load Success'),
  LOAD_FAIL: type('[Search Box data] Load Fail')
};

/**
 * Search Box data Action
 */

export class LoadAction implements Action {
  type = ActionTypes.LOAD;

  constructor(public payload: any = null) { }
}

export class LoadSuccessAction implements Action {
  type = ActionTypes.LOAD_SUCCESS;

  constructor(public payload: Array<SearchBoxModel>) { }
}

export class LoadFailAction implements Action {
  type = ActionTypes.LOAD_FAIL;

  constructor(public payload: any = null) { }
}

export type Actions
  = LoadAction
  | LoadSuccessAction
  | LoadFailAction;
