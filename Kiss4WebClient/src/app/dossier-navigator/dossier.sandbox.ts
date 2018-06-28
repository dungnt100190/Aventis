import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs/Subscription';
import { Sandbox } from '../shared/sandbox/base.sandbox';
import * as store from '../shared/store';
import * as dossierActions from '../shared/store/actions/dossier.action';
import * as settingsActions from '../shared/store/actions/settings.action';
import {
  DossierNavigatorTreeModel as TreeModel,
  SelectedActionsModel
} from '../shared/models';

@Injectable()
export class DossierSandbox extends Sandbox {
  public dossierDatas$ = this.appState$.select(store.getDossierTreesData);
  public filterDossier$ = this.appState$.select(store.getFiltersDossier);
  public dossierLoading$ = this.appState$.select(store.getDossierTreesLoading);
  public dossierDetail$ = this.appState$.select(store.getTreeDetail);
  private subscriptions: Array<Subscription> = [];

  constructor(
    private router: Router,
    protected appState$: Store<store.State>
  ) {
    super(appState$);
    this.registerEvents();
  }

  /**
* Loads dossier tree from the server
*/
  public loadDossierTrees(filters: any): void {
    this.appState$.dispatch(new dossierActions.LoadAction(filters));
  }

  public selectDossier(treeModel: TreeModel): void {
    this.appState$.dispatch(new dossierActions.GetTreeDetailAction(treeModel));
    if (treeModel !== null) {
      localStorage.setItem('select:dossier', JSON.stringify(treeModel));
      const actions = new SelectedActionsModel();
      actions.id = treeModel.id;
      actions.name = `${treeModel.name}`;
      actions.data = treeModel;
      actions.url = `dossier/detail/${treeModel.id}/${treeModel.faLeistungId}`;
      this.updateSelectedActions(actions);
    }
  }

  public deleteDossierItem(treeModel: TreeModel): void {
    this.appState$.dispatch(new settingsActions.DeleteItemSelectedAction(treeModel));
    // Lắng nghe selectedAction thay đổi
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

  // update filters
  // tslint:disable-next-line:member-ordering
  OnFiltersChanged = {
    onCkbActive: (e) => {
      this.filterDossier$.subscribe(filters => {
        filters.Active = e.value;
        this.appState$.dispatch(new dossierActions.SetVisibilityFilterAction.SetActiveAction(filters));
        this.appState$.dispatch(new dossierActions.LoadAction(filters));
      });

    },
    onCkbClosed: (e) => {
      this.filterDossier$.subscribe(filters => {
        filters.Closed = e.value;
        this.appState$.dispatch(new dossierActions.SetVisibilityFilterAction.SetClosedAction(filters));
        this.appState$.dispatch(new dossierActions.LoadAction(filters));
      });
    },
    onCkbArchived: (e) => {
      this.filterDossier$.subscribe(filters => {
        filters.Archived = e.value;
        this.appState$.dispatch(new dossierActions.SetVisibilityFilterAction.SetClosedAction(filters));
        this.appState$.dispatch(new dossierActions.LoadAction(filters));
      });
    },
    onCkbIncludeGroup: (e) => {
      this.filterDossier$.subscribe(filters => {
        filters.IncludeGroup = e.value;
        this.appState$.dispatch(new dossierActions.SetVisibilityFilterAction.SetIncludeGroupAction(filters));
        this.appState$.dispatch(new dossierActions.LoadAction(filters));
      });
    },
    onCkbIncludeGuest: (e) => {
      this.filterDossier$.subscribe(filters => {
        filters.IncludeGuest = e.value;
        this.appState$.dispatch(new dossierActions.SetVisibilityFilterAction.SetIncludeGuestAction(filters));
        this.appState$.dispatch(new dossierActions.LoadAction(filters));
      });
    },
    onCkbIncludeTasks: (e) => {
      this.filterDossier$.subscribe(filters => {
        filters.IncludeTasks = e.value;
        this.appState$.dispatch(new dossierActions.SetVisibilityFilterAction.SetIncludeGroupAction(filters));
        this.appState$.dispatch(new dossierActions.LoadAction(filters));
      });
    },
  };

  public resetState() {
    this.appState$.dispatch(new dossierActions.ResetState());
  }

  /**
   * Unsubscribes from events
   */
  public unregisterEvents() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

  /**
   * Subscribes to events
   */
  private registerEvents(): void {
    // Subscribes to culture
    this.subscriptions.push(this.culture$.subscribe((culture: string) => this.culture = culture));
  }
}
