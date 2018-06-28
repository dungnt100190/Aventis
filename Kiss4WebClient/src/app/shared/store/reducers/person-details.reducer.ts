import * as actions from '../actions/person-details.action';
import { Person } from '../../models';
import { tryParseJSON } from '../../utility';

export interface State {
  loading: boolean;
  loaded: boolean;
  failed: boolean;
  data: Person;
};

const INITIAL_STATE: State = {
  loading: false,
  loaded: false,
  failed: false,
  data: tryParseJSON(localStorage.getItem('select:person'))
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
        data: null
      });
    }

    case actions.ActionTypes.RESET_STATE: { // 'RESET':
      return Object.assign({}, state, { // Always return the initial state
        loaded: true,
        loading: false,
        failed: false,
        data: null,
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
