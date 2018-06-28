import * as actions from '../actions/dossier.action';
import { DossierNavigatorTreeModel as TreeModel, DossierFilterModel } from '../../models';
import { tryParseJSON } from '../../utility';

export interface State {
    loading: boolean;
    loaded: boolean;
    failed: boolean;
    filters: DossierFilterModel;
    trees: Array<TreeModel>;
    treeDetail: TreeModel;
};

const INITIAL_STATE: State = {
    loading: false,
    loaded: false,
    failed: false,
    filters: new DossierFilterModel(),
    trees: [],
    treeDetail: tryParseJSON(localStorage.getItem('select:dossier'))
};

export function reducer(state = INITIAL_STATE, action: actions.Actions | actions.FiltersAction): State {
    if (!action) { return state; }

    switch (action.type) {
        case actions.ActionTypes.LOAD: {
            return Object.assign({}, state, {
                loading: true,
                filters: action.payload
            });
        }

        case actions.ActionTypes.LOAD_SUCCESS: {
            return Object.assign({}, state, {
                loaded: true,
                loading: false,
                failed: false,
                trees: action.payload
            });
        }

        case actions.ActionTypes.LOAD_FAIL: {
            return Object.assign({}, state, {
                loaded: false,
                loading: false,
                failed: true,
                trees: []
            });
        }

        case actions.ActionTypes.GET_TREE_DETAIL: {
            return Object.assign({}, state, {
                treeDetail: action.payload
            });
        }

        // action filter visible
        case actions.SetVisibilityFilter.ACTIVE: {
            return Object.assign({}, state, {
                filters: action.payload
            });
        }

        case actions.SetVisibilityFilter.ARCHIVED: {
            return Object.assign({}, state, {
                filters: action.payload
            });
        }

        case actions.SetVisibilityFilter.CLOSED: {
            return Object.assign({}, state, {
                filters: action.payload
            });
        }

        case actions.SetVisibilityFilter.INCLUDE_GROUP: {
            return Object.assign({}, state, {
                filters: action.payload
            });
        }

        case actions.SetVisibilityFilter.INCLUDE_GUEST: {
            return Object.assign({}, state, {
                filters: action.payload
            });
        }

        case actions.SetVisibilityFilter.INCLUDE_TASKS: {
            return Object.assign({}, state, {
                filters: action.payload
            });
        }

        case actions.ActionTypes.RESET_STATE: { // 'RESET':
            return Object.assign({}, state, { // Always return the initial state
                loaded: true,
                loading: false,
                failed: false,
                treeDetail: null,
            });
        }

        default: {
            return state;
        }
    }
};

export const getTrees = (state: State) => state.trees;
export const getLoading = (state: State) => state.loading;
export const getLoaded = (state: State) => state.loaded;
export const getFailed = (state: State) => state.failed;
export const getFilters = (state: State) => state.filters;
export const getTreeDetail = (state: State) => state.treeDetail;