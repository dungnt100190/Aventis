import '@ngrx/core/add/operator/select';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import * as Action from '../actions/pendenzen.action';
import { Pendenzen } from '../../models/pendenzen/pendenzen.model';

interface processState<T = boolean> {
    loading: T;
    loaded: T;
    failed: T;
}

export interface State extends processState {
  loading: boolean;
  loaded: boolean;
  failed: boolean;
  data: Array<Pendenzen>;
  //pendenzen: Pendenzen;
};

const INITIAL_STATE: State = {
  loading: false,
  loaded: false,
  failed: false,
  data: [],
  //pendenzen: new Pendenzen()
};

export function reducer(state = INITIAL_STATE, action: Action.Action): State {
  if (!action) return state;
  switch (action.type) {
    
    case Action.ActionTypes.LOAD: {
      return Object.assign({}, state, {
        loading: true
      });
    }

    case Action.ActionTypes.LOAD_SUCCESS: {
      return Object.assign({}, state, {
        loaded: true,
        loading: false,
        failed: false,
        data: action.payload
      });
    }

    case Action.ActionTypes.LOAD_FAIL: {
      return Object.assign({}, state, {
        loaded: false,
        loading: false,
        failed: true,
        data: []
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
//export const getPendenzen = (state: State) => state.pendenzen;
