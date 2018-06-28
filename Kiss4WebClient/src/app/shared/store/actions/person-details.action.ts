import { Action } from '@ngrx/store';
import { type } from '../../utility';

export const ActionTypes = {
  LOAD: type('[Person Details] Load'),
  LOAD_SUCCESS: type('[Person Details] Load Success'),
  LOAD_FAIL: type('[Person Details] Load Fail'),
  RESET_STATE: type('[RESET_STATE] reset state for person')
};

/**
 * Person Actions
 */
export class LoadAction implements Action {
  type = ActionTypes.LOAD;
  constructor(public payload: any = null) { }
}

export class LoadSuccessAction implements Action {
  type = ActionTypes.LOAD_SUCCESS;
  constructor(public payload: any) { }
}

export class LoadFailAction implements Action {
  type = ActionTypes.LOAD_FAIL;
  constructor(public payload: any = null) { }
}

export class ResetState implements Action {
  type = ActionTypes.RESET_STATE;
  constructor(public payload: any = null) { }
}


export type Actions
  = LoadAction
  | LoadSuccessAction
  | LoadFailAction
  | ResetState;
