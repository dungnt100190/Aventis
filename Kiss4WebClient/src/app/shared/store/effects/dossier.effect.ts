import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import { Injectable } from '@angular/core';
import { Effect, Actions } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import { DossierApiClient } from '../../../dossier-navigator/dossierApiClient.service';
import * as dossierAction from '../actions/dossier.action';
import {
  DossierNavigatorTreeModel
    as TreeModel, DossierFilterModel
} from '../../models';
import { tryMapPathApi } from '../../utility';

@Injectable()
export class DossierEffects {

  constructor(
    private actions$: Actions,
    private dossierApiClient: DossierApiClient) { }

  /**
   * Trees list
   */
  @Effect()
  getTrees$: Observable<Action> = this.actions$
    .ofType(dossierAction.ActionTypes.LOAD)
    .map((action: dossierAction.LoadAction) => action.payload)
    .switchMap((state: DossierFilterModel) => {
      const query = tryMapPathApi(state);
      return this.dossierApiClient.getTrees(query)
        .map(trees => new dossierAction.LoadSuccessAction(trees))
        .catch(error => Observable.of(new dossierAction.LoadFailAction()));
    });
}
