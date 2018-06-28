import '@ngrx/core/add/operator/select';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { MenuModel } from '../../models';
import * as actions from '../actions/menus.action';
import { mergeArrayObject, spliceObjectArray } from '../../utility';

export interface State {
  selectedMenu: Array<any>;
  avaiableMenus: Array<any>;
  loading: boolean;
  loaded: boolean;
  failed: boolean;
  data: Array<MenuModel>;
};

const INITIAL_STATE: State = {
  selectedMenu: [],
  avaiableMenus: [],
  loading: false,
  loaded: false,
  failed: false,
  data: []// MenusMock
};

export function reducer(state = INITIAL_STATE, action: actions.Actions): State {
  if (!action) return state;
  switch (action.type) {
    case actions.ActionTypes.SELECT: {
      let reduced = mergeArrayObject(state.avaiableMenus, action.payload, 'id');
      localStorage.setItem('selectedMenu', JSON.stringify([action.payload]));
      localStorage.setItem('avaiableMenus', JSON.stringify(reduced));
      return Object.assign({}, state, {
        selectedMenu: [action.payload],
        avaiableMenus: reduced
      });
    }

    case actions.ActionTypes.AVAIABLE_MENU: {
      let reduced = spliceObjectArray(state.avaiableMenus, action.payload, 'id');
      localStorage.setItem('avaiableMenus', JSON.stringify(reduced));
      return Object.assign({}, state, {
        avaiableMenus: reduced
      })
    }

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
        data: action.payload,
        selectedMenu: localStorage.getItem('selectedMenu') != null ? JSON.parse(localStorage.getItem('selectedMenu')) : [],
        avaiableMenus: localStorage.getItem('avaiableMenus') != null ? JSON.parse(localStorage.getItem('avaiableMenus')) : [],
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

    default: {
      return state;
    }
  }
};

export const getData = (state: State) => state.data;
export const getLoading = (state: State) => state.loading;
export const getLoaded = (state: State) => state.loaded;
export const getFailed = (state: State) => state.failed;
export const getSelectItem = (state: State) => state.selectedMenu;
export const getAvaiableMenus = (state: State) => state.avaiableMenus;
