import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import { Injectable } from '@angular/core';
import { Effect, Actions } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import * as settingsAction from '../actions/settings.action';
import { AppApiClient } from '@app/appApiClient.service';

@Injectable()
export class SettingsEffects {

  constructor(
    private actions$: Actions,
    private appApiClient: AppApiClient) { }

  /**
   * Trees list
   */
  @Effect()
  getRoles$: Observable<Action> = this.actions$
    .ofType(settingsAction.ActionTypes.LOAD_API_ROLES)
    .map((action: settingsAction.LoadApiRolesAction) => action.payload)
    .switchMap(() => {
      return this.appApiClient.getRoles()
        .map(roles => new settingsAction.SetAvailableRolesAction(roles))
        .catch(error => Observable.of(new settingsAction.LoadFailAction()));
    });

  @Effect()
  getDocument$: Observable<Action> = this.actions$
    .ofType(settingsAction.ActionTypes.DOCUMENT_CREATE)
    .map((action: settingsAction.DocumentCreate) => action.payload)
    .switchMap((state: any) => {
      return this.appApiClient.DocumentCreate(state.templateId, state.contextValues)
        .map(document => new settingsAction.DocumentCreateSuccess(document))
        .catch(error => Observable.of(new settingsAction.DocumentCreateError()));
    });

}
