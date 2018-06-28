import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import { Injectable } from '@angular/core';
import { Effect, Actions } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import { PendenzenApiClient } from '../../../kiss-pendenzen/pendenzenApiClient.service';
import * as pendenzenActions from '../actions/pendenzen.actions';

@Injectable()
export class PendenzensEffects {

  constructor(
    private actions$: Actions,
    private pendenzenApiClient: PendenzenApiClient) { }

  /**
   * Product list
   */
  @Effect()
  getPendenzens$: Observable<Action> = this.actions$
    .ofType(pendenzenActions.ActionTypes.LOAD)
    .map((action: pendenzenActions.LoadAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.getListPendenzen()
        .map(items => new pendenzenActions.LoadSuccessAction(items))
        .catch(error => Observable.of(new pendenzenActions.LoadFailAction()));
    });
}