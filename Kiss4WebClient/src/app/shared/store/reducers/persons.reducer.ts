import { Action } from '@ngrx/store';
import * as actions from '../actions/persons.action';
import { Person } from '../../models';

export interface State {
    loading: boolean;
    loaded: boolean;
    failed: boolean;
    data: Array<Person>;
    person: Person;
    ADDING: boolean;
    deleted: boolean;
    personId: any;
};

const INITIAL_STATE: State = {
    loading: false,
    loaded: false,
    failed: false,
    data: [],
    person: new Person(),
    ADDING: false,
    deleted: false,
    personId: null
};

export function reducer(state = INITIAL_STATE, action: actions.Actions): State {
    if (!action) { return state; }

    switch (action.type) {
        case actions.ActionTypes.LOAD: {
            return Object.assign({}, state, {
                loading: true
            });
        }

        case actions.ActionTypes.LOAD_SUCCESS: {
            return Object.assign({}, state, {
                loaded: true,
                loading: false,
                failed: false,
                data: action.payload
            });
        }

        case actions.ActionTypes.LOAD_FAIL: {
            return Object.assign({}, state, {
                loaded: false,
                loading: false,
                failed: true,
                data: []
            });
        }

        case actions.ActionTypes.ADD_NEW: {
            return Object.assign({}, state, {
                adding: false,
                person: action.payload
            });
        }

        case actions.ActionTypes.ADD_SUCCESS: {
            return Object.assign({}, state, {
                adding: true,
                person: action.payload
            });
        }

        case actions.ActionTypes.Add_FAIL: {
            return Object.assign({}, state, {
                failed: true,
                person: null
            });
        }

        case actions.ActionTypes.UPDATE: {
            return Object.assign({}, state, {
                personId: action.payload,
            });
        }

        case actions.ActionTypes.UPDATE_SUCCESS: {
            return Object.assign({}, state, {
                person: action.payload
            });
        }

        case actions.ActionTypes.UPDATE_FAIL: {
            return Object.assign({}, state, {
                failed: true,
                person: null
            });
        }

        case actions.ActionTypes.DELETE: {
            return Object.assign({}, state, {
                deleted: false,
                personId: action.payload
            });
        }

        case actions.ActionTypes.DELETE_SUCCESS: {
            return Object.assign({}, state, {
                deleted: true,
                personId: action.payload
            });
        }

        case actions.ActionTypes.DELETE_FAIL: {
            return Object.assign({}, state, {
                deleted: false,
                personId: action.payload
            });
        }

        default: {
            return state;
        }
    }
};

export const getData = (state: State) => state.data;
export const getLoading = (state: State) => state.loading;
export const getLoaded = (state: State) => state.loaded;
export const getFailed = (state: State) => state.failed;
export const getPerson = (state: State) => state.person;
export const getDeleted = (state: State) => state.deleted;
export const getPersonId = (state: State) => state.personId;
export const getAdding = (state: State) => state.ADDING;
