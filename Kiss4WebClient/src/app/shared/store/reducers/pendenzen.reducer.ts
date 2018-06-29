import '@ngrx/core/add/operator/select';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import * as Action from '../actions/pendenzen.action';
import { Pendenzen } from '../../models/pendenzen/pendenzen.model';
import { NavBarItems } from '@app/shared/models/pendenzen/navBarItems.model';

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
  navbarItems: NavBarItems
};

const INITIAL_STATE: State = {
  loading: false,
  loaded: false,
  failed: false,
  data: [],
  navbarItems: new NavBarItems()
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
      debugger;
      return Object.assign({}, state, {
        loaded: false,
        loading: false,
        failed: true,
        data: [],
      });
    }

    case Action.ActionTypes.LOAD_NAVBAR: {
      return Object.assign({}, state, {
        loading: true
      });
    }

    case Action.ActionTypes.LOAD_NAVBAR_SUCCESS: {
      return Object.assign({}, state, {
        loaded: true,
        loading: false,
        failed: false,
        navbarItems: action.payload
      });
    }

    case Action.ActionTypes.LOAD_NAVBAR_FAIL: {
      debugger;
      return Object.assign({}, state, {
        loaded: false,
        loading: false,
        failed: true,
        navbarItems: null
      });
    }

    default: {
      return state;
    }
  }
};

export const getData = (state: State) => state.data;
export const getNavBarItems = (state: State) => state.navbarItems;
export const getLoading = (state: State) => state.loading;
export const getLoaded = (state: State) => state.loaded;
export const getFailed = (state: State) => state.failed;
