import { getMenusData } from './../index';

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import { Injectable } from '@angular/core';
import { Effect, Actions } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import * as SearchBoxActions from '../actions/search-box.action';
import { Store } from '@ngrx/store';
import * as store from '../index';
import { SearchBoxsMock } from '../../mocks';

@Injectable()
export class SearchBoxDatasEffects {

  constructor(
    private actions$: Actions) { }

  /**
   * Menus list
   */
  @Effect()
  getSearchBoxDatas$: Observable<Action> = this.actions$
    .ofType(SearchBoxActions.ActionTypes.LOAD)
    .map((action: SearchBoxActions.LoadAction) => action.payload)
    .switchMap(state => {
      return Observable.of(SearchBoxsMock)
        .map(datas => new SearchBoxActions.LoadSuccessAction(datas))
        .catch(error => Observable.of(new SearchBoxActions.LoadFailAction()));
    });
}
