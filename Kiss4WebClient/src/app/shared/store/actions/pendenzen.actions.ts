import { Action } from '@ngrx/store';
import { type } from '../../utility';

export const ActionTypes = {
    // Actions Load data
    LOAD: type('[Pendenzens] Load'),
    LOAD_SUCCESS: type('[Pendenzens] Load Success'),
    LOAD_FAIL: type('[Pendenzens] Load Fail'),
  };

  export class LoadAction implements Action {
    type = ActionTypes.LOAD;
  
    constructor(public payload?: any) { }
  }
  
  export class LoadSuccessAction implements Action {
    type = ActionTypes.LOAD_SUCCESS;
    constructor(public payload?: any[]) { }
  }
  
  export class LoadFailAction implements Action {
    type = ActionTypes.LOAD_FAIL;
    constructor(public  payload?: any) { }
  }
  
  
  export type Actions
    = LoadAction
    | LoadSuccessAction
    | LoadFailAction;
