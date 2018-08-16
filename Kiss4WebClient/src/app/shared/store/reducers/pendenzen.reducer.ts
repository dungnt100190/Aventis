import '@ngrx/core/add/operator/select';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import * as Action from '../actions/pendenzen.action';
import { Pendenzen } from '../../models/pendenzen/pendenzen.model';
import { PendenzenDetail } from '@app/shared/models/pendenzen/pendenzenDetail.model';
import { NavBarItems } from '@app/shared/models/pendenzen/navBarItems.model';
import { SearchPendenzen } from '@app/shared/models/pendenzen/searchPendenzen.model';
import { ErstellerModel } from '@app/shared/models/pendenzen/ersteller.model';
import { MasterData } from '@app/shared/models/pendenzen/masterData.model';
import { EmpfangerModel } from '@app/shared/models/pendenzen/empfanger.model';
import { Leistungsverantw } from '@app/shared/models/pendenzen/leistungsverantw.model';
import { Falltrager } from '@app/shared/models/pendenzen/falltrager.model';
import { LeistungPerson } from '@app/shared/models/pendenzen/leistungPerson.model';

interface processState<T = boolean> {
  loading: T;
  updating: T;
  success: T;
  failed: T;
}

export interface State extends processState {
  loading: boolean;
  updating: boolean;
  success: boolean;
  failed: boolean;
  result: boolean;
  data: Array<Pendenzen>;
  detail: PendenzenDetail;
  navbarItems: NavBarItems;
  searchOption: SearchPendenzen;
  lstErsteller: Array<ErstellerModel>;
  objMasterData: MasterData;
  lstEmpfanger: Array<EmpfangerModel>;
  lstLeistungsverantw: Array<Leistungsverantw>;
  lstFalltrager: Array<Falltrager>;
  updateTask: boolean;
  lstSearch: Array<SearchPendenzen>;
  objLeistungPerson: LeistungPerson;
  strLeistungsverantw: string;
};

const INITIAL_STATE: State = {
  loading: false,
  updating: false,
  success: false,
  failed: false,
  result: false,
  data: [],
  detail: new PendenzenDetail(),
  navbarItems: new NavBarItems(),
  searchOption: new SearchPendenzen(),
  lstErsteller: [],
  objMasterData: new MasterData(),
  lstEmpfanger: [],
  lstLeistungsverantw: [],
  lstFalltrager: [],
  updateTask: false,
  lstSearch: [],
  objLeistungPerson: new LeistungPerson(),
  strLeistungsverantw: ''
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
      return Object.assign({}, state, {
        loaded: false,
        loading: false,
        failed: true,
        navbarItems: new NavBarItems()
      });
    }

    case Action.ActionTypes.LOAD_DETAIL: {
      return Object.assign({}, state, {
        loading: true
      });
    }

    case Action.ActionTypes.LOAD_DETAIL_SUCCESS: {
      return Object.assign({}, state, {
        loaded: true,
        loading: false,
        failed: false,
        detail: action.payload
      });
    }

    case Action.ActionTypes.LOAD_DETAIL_FAIL: {
      return Object.assign({}, state, {
        loaded: false,
        loading: false,
        failed: true,
        detail: new PendenzenDetail(),
      });
    }

    case Action.ActionTypes.PROCESS_PENDENZEN: {
      return Object.assign({}, state, {
        updating: true,
      });
    }

    case Action.ActionTypes.PROCESS_PENDENZEN_SUCCESS: {
      return Object.assign({}, state, {
        updating: false,
        success: true,
        failed: false,
        result: action.payload
      });
    }

    case Action.ActionTypes.PROCESS_PENDENZEN_FAIL: {
      return Object.assign({}, state, {
        updating: false,
        success: false,
        failed: true,
        result: false
      });
    }

    case Action.ActionTypes.LOAD_SEARCH_OPTION: {
      return Object.assign({}, state, {
        loading: true
      });
    }

    case Action.ActionTypes.LOAD_SEARCH_OPTION: {
      return Object.assign({}, state, {
        loading: true
      });
    }

    case Action.ActionTypes.LOAD_SEARCH_OPTION_SUCCESS: {
      return Object.assign({}, state, {
        loaded: true,
        loading: false,
        failed: false,
        searchOption: action.payload
      });
    }

    case Action.ActionTypes.LOAD_SEARCH_OPTION_FAIL: {
      debugger;
      return Object.assign({}, state, {
        loaded: false,
        loading: false,
        failed: true,
        searchOption: null
      });
    }

    case Action.ActionTypes.LOAD_ERSTELLER: {
      return Object.assign({}, state, {
        loading: true
      });
    }

    case Action.ActionTypes.LOAD_ERSTELLER_SUCCESS: {
      return Object.assign({}, state, {
        loaded: true,
        loading: false,
        failed: false,
        lstErsteller: action.payload
      });
    }

    case Action.ActionTypes.LOAD_ERSTELLER_FAIL: {
      debugger;
      return Object.assign({}, state, {
        loaded: false,
        loading: false,
        failed: true,
        lstErsteller: null
      });
    }

    case Action.ActionTypes.LOAD_MASTER_DATA: {
      return Object.assign({}, state, {
        loading: true,
      });
    }

    case Action.ActionTypes.LOAD_MASTER_DATA_SUCCESS: {
      return Object.assign({}, state, {
        loading: false,
        loaded: true,
        failed: false,
        objMasterData: action.payload
      });
    }

    case Action.ActionTypes.LOAD_MASTER_DATA_FAIL: {
      return Object.assign({}, state, {
        loading: false,
        loaded: false,
        failed: true,
        objMasterData: null
      });
    }

    case Action.ActionTypes.LOAD_EMPFANGER: {
      return Object.assign({}, state, {
        loading: true,
      });
    }

    case Action.ActionTypes.LOAD_EMPFANGER_SUCCESS: {
      return Object.assign({}, state, {
        loading: false,
        loaded: true,
        failed: false,
        lstEmpfanger: action.payload
      });
    }

    case Action.ActionTypes.LOAD_EMPFANGER_FAIL: {
      return Object.assign({}, state, {
        loading: false,
        loaded: false,
        failed: true,
        lstEmpfanger: null
      });
    }

    case Action.ActionTypes.LOAD_LEISTUNGSVERANTW: {
      return Object.assign({}, state, {
        loading: true,
      });
    }

    case Action.ActionTypes.LOAD_LEISTUNGSVERANTW_SUCCESS: {
      return Object.assign({}, state, {
        loading: false,
        loaded: true,
        failed: false,
        lstLeistungsverantw: action.payload
      });
    }

    case Action.ActionTypes.LOAD_LEISTUNGSVERANTW_FAIL: {
      return Object.assign({}, state, {
        loading: false,
        loaded: false,
        failed: true,
        lstLeistungsverantw: null
      });
    }

    case Action.ActionTypes.LOAD_FALLTRAGER: {
      return Object.assign({}, state, {
        loading: true,
      });
    }

    case Action.ActionTypes.LOAD_FALLTRAGER_SUCCESS: {
      return Object.assign({}, state, {
        loading: false,
        loaded: true,
        failed: false,
        lstFalltrager: action.payload
      });
    }

    case Action.ActionTypes.LOAD_FALLTRAGER_FAIL: {
      return Object.assign({}, state, {
        loading: false,
        loaded: false,
        failed: true,
        lstFalltrager: []
      });
    }

    case Action.ActionTypes.LOAD_LEISTUNG_PERSON: {
      return Object.assign({}, state, {
        loading: true,
      });
    }

    case Action.ActionTypes.LOAD_LEISTUNG_PERSON_SUCCESS: {
      return Object.assign({}, state, {
        loading: false,
        loaded: true,
        failed: false,
        objLeistungPerson: action.payload
      });
    }

    case Action.ActionTypes.LOAD_LEISTUNG_PERSON_FAIL: {
      return Object.assign({}, state, {
        loading: false,
        loaded: false,
        failed: true,
        objLeistungPerson: null
      });
    }
    
    case Action.ActionTypes.UPDATE_TASK: {
      return Object.assign({}, state, {
        updating: true,
      });
    }

    case Action.ActionTypes.UPDATE_TASK_SUCCESS: {
      return Object.assign({}, state, {
        updating: false,
        success: true,
        failed: false,
        updateTask: action.payload
      });
    }

    case Action.ActionTypes.UPDATE_TASK_FAIL: {
      return Object.assign({}, state, {
        updating: false,
        success: false,
        failed: true,
        updateTask: false
      });
    }

    case Action.ActionTypes.GET_DATA_SEARCH: {
      return Object.assign({}, state, {
        loading: true,
      });
    }

    case Action.ActionTypes.GET_DATA_SEARCH_SUCCESS: {
      return Object.assign({}, state, {
        loading: false,
        loaded: false,
        failed: false,
        lstSearch: action.payload
      });
    }

    case Action.ActionTypes.GET_DATA_SEARCH_FAIL: {
      return Object.assign({}, state, {
        loading: false,
        loaded: false,
        failed: false,
        lstSearch: []
      });
    }

    case Action.ActionTypes.LOAD_LEISTUNGSVERANTW_CREATE: {
      return Object.assign({}, state, {
        loading: true,
      });
    }

    case Action.ActionTypes.LOAD_LEISTUNGSVERANTW_CREATE_SUCCESS: {
      return Object.assign({}, state, {
        loading: false,
        loaded: false,
        failed: false,
        strLeistungsverantw: action.payload
      });
    }

    case Action.ActionTypes.LOAD_LEISTUNGSVERANTW_CREATE_FAIL: {
      return Object.assign({}, state, {
        loading: false,
        loaded: false,
        failed: false,
        strLeistungsverantw: ''
      });
    }

    default: {
      return state;
    }
  }
};

export const getData = (state: State) => state.data;
export const getNavBarItems = (state: State) => state.navbarItems;
export const getDetail = (state: State) => state.detail;

export const processTask = (state: State) => state.result;
export const updateTask = (state: State) => state.updateTask;
export const getDataSearch = (state: State) => state.lstSearch;

export const searchOptionPendenzen = (state: State) => state.searchOption;
export const loadMasterData = (state: State) => state.objMasterData;
export const getEmpfanger = (state: State) => state.lstEmpfanger;
export const getErsteller = (state: State) => state.lstErsteller;
export const getLeistungsverantw = (state: State) => state.lstLeistungsverantw;
export const getFalltrager = (state: State) => state.lstFalltrager;
export const getLeistungPerson = (state: State) => state.objLeistungPerson;

export const getLoading = (state: State) => state.loading;
export const getLoaded = (state: State) => state.success;
export const getFailed = (state: State) => state.failed;
export const getLeistungsverantwCreate = (state: State) => state.strLeistungsverantw;
