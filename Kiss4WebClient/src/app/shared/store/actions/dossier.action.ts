import { Action } from '@ngrx/store';
import { DossierNavigatorTreeModel as TreesModel, DossierFilterModel } from '../../models';
import { type } from '../../utility';

export const ActionTypes = {
  // Actions Load data
  LOAD: type('[Dossier nav Trees] Load'),
  LOAD_SUCCESS: type('[Dossier nav Trees] Load Success'),
  LOAD_FAIL: type('[Dossier nav Trees] Load Fail'),
  GET_TREE_DETAIL: type('[GET_TREE_DETAIL] load'),
  RESET_STATE: type('[RESET_STATE] reset state for dossier')
};

export const SetVisibilityFilter = {
  // Action set filter
  ACTIVE: type('[SET_VISIBILITY_FILTER] --- Aktiv'),
  CLOSED: type('[SET_VISIBILITY_FILTER] --- Closed'),
  ARCHIVED: type('[SET_VISIBILITY_FILTER] --- Archived'),
  INCLUDE_GROUP: type('[SET_VISIBILITY_FILTER] --- IncludeGroup'),
  INCLUDE_GUEST: type('[SET_VISIBILITY_FILTER] --- IncludeGuest'),
  INCLUDE_TASKS: type('[SET_VISIBILITY_FILTER] --- IncludeTasks'),
};

/**
 * Dossier nav Trees Action
 */

export class LoadAction implements Action {
  type = ActionTypes.LOAD;
  constructor(public payload: DossierFilterModel) { }
}

export class LoadSuccessAction implements Action {
  type = ActionTypes.LOAD_SUCCESS;
  constructor(public payload: Array<TreesModel>) { }
}

export class LoadFailAction implements Action {
  type = ActionTypes.LOAD_FAIL;
  constructor(public payload: any = null) { }
}

export class GetTreeDetailAction implements Action {
  type = ActionTypes.GET_TREE_DETAIL;

  constructor(public payload: any) { }
}

export class ResetState implements Action {
  type = ActionTypes.RESET_STATE;
  constructor(public payload: any = null) { }
}

/**
 * ------------------------------------
 * Set Visibility dossier Filter Action
 * @param payload: DossierFilterModel
 * ------------------------------------
*/

export namespace SetVisibilityFilterAction {
  export class SetActiveAction implements Action {
    type = SetVisibilityFilter.ACTIVE;
    constructor(public payload?: DossierFilterModel) { }
  }
  export class SetClosedAction implements Action {
    type = SetVisibilityFilter.CLOSED;
    constructor(public payload?: DossierFilterModel) { }
  }
  export class SetArchivedAction implements Action {
    type = SetVisibilityFilter.ARCHIVED;
    constructor(public payload?: DossierFilterModel) { }
  }
  export class SetIncludeGroupAction implements Action {
    type = SetVisibilityFilter.INCLUDE_GROUP;
    constructor(public payload?: DossierFilterModel) { }
  }
  export class SetIncludeGuestAction implements Action {
    type = SetVisibilityFilter.INCLUDE_GUEST;
    constructor(public payload?: DossierFilterModel) { }
  }
  export class SetIncludeTasksAction implements Action {
    type = SetVisibilityFilter.INCLUDE_TASKS;
    constructor(public payload?: DossierFilterModel) { }
  }
}


export type Actions
  = LoadAction
  | LoadSuccessAction
  | LoadFailAction
  | GetTreeDetailAction
  | ResetState;

export type FiltersAction
  = SetVisibilityFilterAction.SetActiveAction
  | SetVisibilityFilterAction.SetClosedAction
  | SetVisibilityFilterAction.SetArchivedAction
  | SetVisibilityFilterAction.SetIncludeGroupAction
  | SetVisibilityFilterAction.SetIncludeGuestAction
  | SetVisibilityFilterAction.SetIncludeTasksAction;

