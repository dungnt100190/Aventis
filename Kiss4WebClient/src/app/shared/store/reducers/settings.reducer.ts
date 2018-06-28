import { LanguageModel } from './../../models/shared/language.model';
import '@ngrx/core/add/operator/select';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import * as settings from '../actions/settings.action';
import { role } from './../../models';
import { tryParseJSON, mergeArrayObject, spliceObjectArray } from '../../utility';

export interface State {
  selectedLanguage: string;
  selectedCulture: string;
  availableLanguages: Array<any>;
  availableRoles: Array<any>;
  selectedActions: Array<any>;
  documentCreateObject: any;
  xDocumentCreated: Pick<any, any>;
};

const INITIAL_STATE: State = {
  selectedLanguage: '',
  selectedCulture: '',
  availableLanguages: [
    { code: 'de', name: 'DE', culture: 'de-CH', flag: 'famfamfam-flag-de' },
    { code: 'en', name: 'EN', culture: 'en-EN', flag: 'famfamfam-flag-gb' },
    { code: 'fr', name: 'FR', culture: 'fr-CH', flag: 'famfamfam-flag-fr' },
    { code: 'it', name: 'IT', culture: 'it-CH', flag: 'famfamfam-flag-it' }
  ],
  availableRoles: tryParseJSON(localStorage.getItem('user.rights')) || [],
  selectedActions: tryParseJSON(localStorage.getItem('select:actions')) || [],
  documentCreateObject: {
    templateId: 669164,
    contextValues: [
      { Name: 'FaAktennotizID', Value: '17' },
      { Name: 'BaPersonID', Value: '64820' }
    ]
  },
  xDocumentCreated: null
};

export function reducer(state = INITIAL_STATE, action: settings.Actions): State {
  switch (action.type) {
    case settings.ActionTypes.SET_LANGUAGE: {
      return Object.assign({}, state, { selectedLanguage: action.payload });
    }

    case settings.ActionTypes.SET_CULTURE: {
      const selectedCulture = action.payload;
      localStorage.setItem('currentLang.Culture', selectedCulture);
      return Object.assign({}, state, { selectedCulture: selectedCulture });
    }

    case settings.ActionTypes.SET_AVAIBLE_ROLES: {
      const rightData = action.payload;
      const rights = {};
      rightData.forEach(right => rights[right.className] = right);
      localStorage.setItem('user.rights', JSON.stringify(rights));
      return Object.assign({}, state, { availableRoles: rights })
    }

    case settings.ActionTypes.SET_AVAIBLE_LANGUAGE: {
      return Object.assign({}, state, {
        availableLanguages: action.payload
      });
    }

    case settings.ActionTypes.UPDATE_SELECT_ACTION: {
      const selecteds = mergeArrayObject(state.selectedActions, action.payload, 'id');
      localStorage.setItem('select:actions', JSON.stringify(selecteds));
      return Object.assign({}, state, {
        selectedActions: selecteds
      });
    }

    case settings.ActionTypes.DELETE_ITEM_SELECT_ACTION: {
      const selecteds = spliceObjectArray(state.selectedActions, action.payload, 'id');
      localStorage.setItem('select:actions', JSON.stringify(selecteds));
      return Object.assign({}, state, {
        selectedActions: selecteds
      });
    }

    case settings.ActionTypes.RESET_STATE: { // 'RESET':
      return Object.assign({}, state, { // Always return the initial state
        selectedActions: [],
        availableRoles: []
      });
    }

    case  settings.ActionTypes.DOCUMENT_CREATE: {
      return Object.assign({}, state, {
        documentCreateObject: action.payload,
      });
    }

    case settings.ActionTypes.DOCUMENT_CREATE_SUCCESS: {
      return Object.assign({}, state, {
        xDocumentCreated: action.payload
      });
    }

    case settings.ActionTypes.DOCUMENT_CREATE_ERROR: {
      return Object.assign({}, state, {
        xDocumentCreated: action.payload
      });
    }

    default: {
      return state;
    }
  }
}

export const getSelectedLanguage = (state: State) => state.selectedLanguage;
export const getSelectedCulture = (state: State) => state.selectedCulture;
export const getAvailableLanguages = (state: State) => state.availableLanguages;
export const getAvailableRoles = (state: State) => state.availableRoles;
export const getSelectedActions = (state: State) => state.selectedActions;
export const getXDocumentCreate = (state: State) => state.xDocumentCreated;
export const getDocumentCreateObject = (state: State) => state.documentCreateObject;
