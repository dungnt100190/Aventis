import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import { Injectable } from '@angular/core';
import { Effect, Actions } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import { PendenzenApiClient } from '../../../kiss-pendenzen/pendenzenApiClient.service';
import * as PendenzenAction from '../actions/pendenzen.action';

@Injectable()
export class PendenzensEffects {

  constructor(
    private actions$: Actions,
    private pendenzenApiClient: PendenzenApiClient) { }

  /**
   * Get NavBarItems
   */
  @Effect()
  getNavBarItems$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.LOAD_NAVBAR)
    .map((action: PendenzenAction.LoadNavBarAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.LoadNavBarItems()
        .map(data => new PendenzenAction.LoadNavBarSuccessAction(data))
        .catch(error => Observable.of(new PendenzenAction.LoadFailAction()));
    });

  /**
   * Get pendenzen data
   */
  @Effect()
  getPendenzens$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.LOAD)
    .map((action: PendenzenAction.LoadAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.GetPendenzenData(state)
        .map(data => new PendenzenAction.LoadSuccessAction(data))
        .catch(error => Observable.of(new PendenzenAction.LoadFailAction()));
    });

  /**
   * Get detail pendenzen
   */
  @Effect()
  getPendenzensDetail$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.LOAD_DETAIL)
    .map((action: PendenzenAction.LoadDetailAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.GetPendenzenDetail(state)
        .map(data => new PendenzenAction.LoadDetailSuccessAction(data))
        .catch(error => Observable.of(new PendenzenAction.LoadDetailFailAction()));
    });

  /**
   * Update status of task
   */
  @Effect()
  processPendenzen$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.PROCESS_PENDENZEN)
    .map((action: PendenzenAction.ProcessPendenzenAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.ProcessTask(state)
        .map(result => new PendenzenAction.ProcessPendenzenSuccessAction(result))
        .catch(error => Observable.of(new PendenzenAction.ProcessPendenzenFailAction()));
    });

  /**
   * search option pendenzen
   */
  @Effect()
  searchOptionPendenzens$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.LOAD_SEARCH_OPTION)
    .map((action: PendenzenAction.LoadSearchOptionAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.GetControlData()
        .map(Pendenzen => new PendenzenAction.LoadSearchOptionSuccessAction(Pendenzen))
        .catch(error => Observable.of(new PendenzenAction.LoadSearchOptionFailAction()));
    });

  /**
   * get ersteller
   */
  @Effect()
  getErsteller$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.LOAD_ERSTELLER)
    .map((action: PendenzenAction.LoadErstellerAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.GetErsteller(state)
        .map(result => new PendenzenAction.LoadErstellerSuccessAction(result))
        .catch(error => Observable.of(new PendenzenAction.LoadErstellerFailAction()));
    });

  /**
   * Get Empfanger
   */
  @Effect()
  getEmpfanger$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.LOAD_EMPFANGER)
    .map((action: PendenzenAction.LoadEmpfangerAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.GetEmpfanger()
        .map(result => new PendenzenAction.LoadEmpfangerSuccessAction(result))
        .catch(error => Observable.of(new PendenzenAction.LoadEmpfangerFailAction()));
    });

  /**
   * Get Empfanger
   */
  @Effect()
  loadMasterData$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.LOAD_MASTER_DATA)
    .map((action: PendenzenAction.LoadMasterDataAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.GetMasterData()
        .map(result => new PendenzenAction.LoadMasterDataSuccessAction(result))
        .catch(error => Observable.of(new PendenzenAction.LoadMasterDataFailAction()));
    });

  /**
   * Get Leistungsverantw
   */
  @Effect()
  getLeistungsverantw$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.LOAD_LEISTUNGSVERANTW)
    .map((action: PendenzenAction.LoadLeistungsverantwAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.GetLeistungsverantw()
        .map(result => new PendenzenAction.LoadLeistungsverantwSuccessAction(result))
        .catch(error => Observable.of(new PendenzenAction.LoadEmpfangerFailAction()));
    });

  /**
   * Get Falltrager
   */
  @Effect()
  getFalltrager$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.LOAD_FALLTRAGER)
    .map((action: PendenzenAction.LoadFalltragerAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.LoadFalltrager()
        .map(result => new PendenzenAction.LoadFalltragerSuccessAction(result))
        .catch(error => Observable.of(new PendenzenAction.LoadFalltragerFailAction()));
    });

  /**
   * Get Leistung & betrifft Person
   */
  @Effect()
  getLeistungPerson$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.LOAD_LEISTUNG_PERSON)
    .map((action: PendenzenAction.LoadLeistungPersonAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.LoadLeistungPerson(state)
        .map(result => new PendenzenAction.LoadLeistungPersonSuccessAction(result))
        .catch(error => Observable.of(new PendenzenAction.LoadLeistungPersonFailAction()));
    });

  /**
   * Create or Update task
   */
  @Effect()
  updateTask$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.UPDATE_TASK)
    .map((action: PendenzenAction.UpdateTaskAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.CreateUpdateTask(state)
        .map(result => new PendenzenAction.UpdateTaskSuccessAction(result))
        .catch(error => Observable.of(new PendenzenAction.UpdateTaskFailAction()));
    });

    /**
   * Update status of task
   */
  @Effect()
  getDataSearch$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.GET_DATA_SEARCH)
    .map((action: PendenzenAction.GetDataSearchAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.GetDataSearch(state)
        .map(result => new PendenzenAction.GetDataSearchSuccessAction(result))
        .catch(error => Observable.of(new PendenzenAction.GetDataSearchFailAction()));
    });

    /**
   * Update status of task
   */
  @Effect()
  getLeistungsverantwCreate$: Observable<Action> = this.actions$
    .ofType(PendenzenAction.ActionTypes.LOAD_LEISTUNGSVERANTW_CREATE)
    .map((action: PendenzenAction.GetLeistungsverantwCreateAction) => action.payload)
    .switchMap(state => {
      return this.pendenzenApiClient.GetLeistungsverantwCreate(state)
        .map(result => new PendenzenAction.GetLeistungsverantwCreateSuccessAction(result))
        .catch(error => Observable.of(new PendenzenAction.GetLeistungsverantwCreateFailAction()));
    });
}
