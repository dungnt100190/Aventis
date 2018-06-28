import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import { Injectable } from '@angular/core';
import { Effect, Actions } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import { PendenzenApiClient } from '../../../kiss-pendenzen/pendenzenApiClient.service';
import * as PendenzenAction from '../actions/pendenzen.action';
import { Pendenzen } from '@app/shared/models/pendenzen/pendenzen.model';

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
    .ofType(PendenzenAction.ActionTypes.LOAD)
    .map((action: PendenzenAction.LoadAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.getListPendenzen()
        .map(Pendenzen => new PendenzenAction.LoadSuccessAction(Pendenzen))
        .catch(error => Observable.of(new PendenzenAction.LoadFailAction()));
    });
}
