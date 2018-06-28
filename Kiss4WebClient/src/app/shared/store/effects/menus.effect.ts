import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import { Injectable } from '@angular/core';
import { Effect, Actions } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import { MenusMock } from './../../mocks/menus.mock';
import * as MenusActions from '../actions/menus.action';

@Injectable()
export class MenusEffects {

  constructor(
    private actions$: Actions) { }

  /**
   * Menus list
   */
  @Effect()
  getMenus$: Observable<Action> = this.actions$
    .ofType(MenusActions.ActionTypes.LOAD)
    .map((action: MenusActions.LoadAction) => action.payload)
    .switchMap(state => {
      return Observable.of(MenusMock)
        .map(menus => new MenusActions.LoadSuccessAction(menus))
        .catch(error => Observable.of(new MenusActions.LoadFailAction()));
    });
}
