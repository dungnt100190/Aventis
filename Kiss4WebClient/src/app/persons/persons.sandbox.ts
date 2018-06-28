import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs/rx';
import { Sandbox } from '../shared/sandbox/base.sandbox';
import * as store from '../shared/store';
import * as personsActions from '../shared/store/actions/persons.action';
import * as personDetailsActions from '../shared/store/actions/person-details.action';
import * as settingsActions from '../shared/store/actions/settings.action';
import {
  Person,
  User,
  SelectedActionsModel
} from '../shared/models';
import { UtilService } from '../shared/utility';

@Injectable()
export class PersonsSandbox extends Sandbox {

  public persons$ = this.appState$.select(store.getPersonsData);
  public personsLoading$ = this.appState$.select(store.getPersonsLoading);
  public personDetails$ = this.appState$.select(store.getPersonDetailsData);
  public personDetailsLoading$ = this.appState$.select(store.getPersonDetailsLoading);
  public personAdded$ = this.appState$.select(store.getPersonAddNew);
  public statusAdding$ = this.appState$.select(store.getStatusAdding);

  private subscriptions: Array<Subscription> = [];

  constructor(
    protected appState$: Store<store.State>,
    private utilService: UtilService,
    private router: Router
  ) {
    super(appState$);
    this.registerEvents();
  }

  /**
* Loads persons from the server
*/
  public loadPersons(): void {
    this.appState$.dispatch(new personsActions.LoadAction());
  }

  /**
   * Loads person details from the server
   */
  public loadPersonDetails(id: any): void {
    this.appState$.dispatch(new personDetailsActions.LoadAction(id));
  }

  // ADD NEW
  public createPerson(person: any): void {
    this.appState$.dispatch(new personsActions.AddNewAction(new Person(person)));
  }

  /**
   * Dispatches an action to select person details
   */
  public selectPerson(person: any): void {
    this.appState$.dispatch(new personDetailsActions.LoadSuccessAction(person));
    if (person != null) {
      localStorage.setItem('select:person', JSON.stringify(person));
      const actions = new SelectedActionsModel();
      actions.id = person.id;
      actions.name = `${person.name}`;
      actions.data = person;
      actions.url = `persons/detail/${person.id}`;
      this.updateSelectedActions(actions);
    }
  }

  public deletePersonItem(person: any): void {
    this.appState$.dispatch(new settingsActions.DeleteItemSelectedAction(person));
    this.selectedAction$.subscribe(dossiers => {
      if (dossiers.length === 0) {
        localStorage.setItem('select:dossier', null);
        localStorage.setItem('select:person', null);
        this.router.navigate(['dossier']);
      }
    });
  }

  public updateSelectedActions(actions: any) {
    this.appState$.dispatch(new settingsActions.UpdateSelectedAction(actions));
  }

  public notifyMessage(messageTranslationCode: string, type: string = 'info', titleTranslationCode?: string): any {
    this.utilService.displayNotification(messageTranslationCode, type, titleTranslationCode);
  }

  /**
   * Unsubscribes from events
   */
  public unregisterEvents() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

  public resetState() {
    this.appState$.dispatch(new personDetailsActions.ResetState());
  }

  /**
   * Subscribes to events
   */
  private registerEvents(): void {

    this.subscriptions.push(this.loggedUser$.subscribe((user: User) => {
      // tslint:disable-next-line:curly
      if (user.isLoggedIn) this.loadPersons();
    }));
  }
}
