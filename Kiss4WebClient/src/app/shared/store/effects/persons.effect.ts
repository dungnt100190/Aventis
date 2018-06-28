import { RequestMethod } from '@angular/http';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import { Injectable } from '@angular/core';
import { Effect, Actions } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import { PersonsApiClient } from '../../../persons/personsApiClient.service';
import * as personsActions from '../actions/persons.action';
import * as personDetailsActions from '../actions/person-details.action';

@Injectable()
export class PersonsEffects {

  constructor(
    private actions$: Actions,
    private personsApiClient: PersonsApiClient) { }

  /**
   * Product list
   */
  @Effect()
  getPersons$: Observable<Action> = this.actions$
    .ofType(personsActions.ActionTypes.LOAD)
    .map((action: personsActions.LoadAction) => action.payload)
    .switchMap(state => {
      return this.personsApiClient.getPersons()
        .map(persons => new personsActions.LoadSuccessAction(persons))
        .catch(error => Observable.of(new personsActions.LoadFailAction()));
    });

  /**
   * Person details
   */
  @Effect()
  getPersonDetails$: Observable<Action> = this.actions$
    .ofType(personDetailsActions.ActionTypes.LOAD)
    .map((action: personDetailsActions.LoadAction) => action.payload)
    .switchMap(state => {
      return this.personsApiClient.getPersonDetails(state)
        .map(persons => new personDetailsActions.LoadSuccessAction(persons))
        .catch(error => Observable.of(new personDetailsActions.LoadFailAction()));
    });

  // Addnew
  @Effect()
  addNewPerson$: Observable<Action> = this.actions$
    .ofType(personsActions.ActionTypes.ADD_NEW)
    .map((action: personsActions.AddNewAction) => action.payload)
    .switchMap(state => {
      return this.personsApiClient.insertPerson(state)
        .map(person => new personsActions.AddSuccessAction(person))
        .catch(error => Observable.of(new personsActions.AddFailAction(error)));
    });
}
