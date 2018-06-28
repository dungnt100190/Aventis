import { Action } from '@ngrx/store';
import { Person } from '../../models';
import { type } from '../../utility';

export const ActionTypes = {
  // Actions Load data
  LOAD: type('[Persons] Load'),
  LOAD_SUCCESS: type('[Persons] Load Success'),
  LOAD_FAIL: type('[Persons] Load Fail'),
  // Actions Add New person
  ADD_NEW: type('[Person] User Add new'),
  ADDING: type('[Person] Adding'),
  ADD_SUCCESS: type('[Person] Add new person success'),
  Add_FAIL: type('[Person] Add new person Fail'),
  // Action Update
  UPDATE: type('[Person] Update'),
  UPDATING: type('[Person] Updating'),
  UPDATE_SUCCESS: type('[Person] Update success'),
  UPDATE_FAIL: type('[Person] Update fail'),
  // Action Delete
  DELETE: type('[Person] Delete person'),
  DELETING: type('[Person] Deleting'),
  DELETE_SUCCESS: type('[Person] Delete success'),
  DELETE_FAIL: type('[Person] Delete fail'),

  // page details
  LOAD_DETAIL: type('Person Load detail')
};

/**
 * Person Action
 */

export class LoadAction implements Action {
  type = ActionTypes.LOAD;

  constructor(public payload: any = null) { }
}

export class LoadSuccessAction implements Action {
  type = ActionTypes.LOAD_SUCCESS;
  constructor(public payload: Array<Person>) { }
}

export class LoadFailAction implements Action {
  type = ActionTypes.LOAD_FAIL;
  constructor(public payload: any = null) { }
}

export class AddNewAction implements Action {
  type = ActionTypes.ADD_NEW;
  constructor(public payload: Person) { }
}

export class AddSuccessAction implements Action {
  type = ActionTypes.ADD_SUCCESS;
  constructor(public payload: Person) { }
}

export class AddFailAction implements Action {
  type = ActionTypes.Add_FAIL;
  constructor(public payload: any = null) { }
}

export class UpdateAction implements Action {
  type = ActionTypes.UPDATE;
  constructor(id: any, public payload: any = null) { }
}

export class UpdateSuccessAction implements Action {
  type = ActionTypes.UPDATE_SUCCESS;
  constructor(public payload: any = null) { }
}

export class UpdateFailAction implements Action {
  type = ActionTypes.UPDATE_FAIL;
  constructor(public payload: any = null) { }
}

export class DeleteAction implements Action {
  type = ActionTypes.DELETE;
  constructor(public payload: any) { }
}

export class DeleteSuccessAction implements Action {
  type = ActionTypes.DELETE_SUCCESS;
  constructor(public payload: any = null) { }
}

export class DeleteFailAction implements Action {
  type = ActionTypes.DELETE_FAIL;
  constructor(public payload: any = null) { }
}

export type Actions
  = LoadAction
  | LoadSuccessAction
  | LoadFailAction
  | AddNewAction
  | AddSuccessAction
  | AddFailAction
  | UpdateAction
  | UpdateSuccessAction
  | UpdateFailAction
  | DeleteAction
  | DeleteSuccessAction
  | DeleteFailAction;
