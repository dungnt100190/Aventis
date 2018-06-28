import { treeNavModels } from './../../shared/mocks';
import {
  Injector,
  OnInit,
  Component,
  ChangeDetectionStrategy,
  OnDestroy,
  ViewChild,
  EventEmitter
} from '@angular/core';
import { DossierSandbox } from '../dossier.sandbox';
import {
  DossierNavigatorTreeModel as TreeModel, User, DossierFilterModel
} from '../../shared/models';
import { BaseComponent } from '../../shared/components/base.component';
import { Subscription } from 'rxjs/rx';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-dossier-navigator',
  templateUrl: `./dossier-navigator.component.html`,
  styleUrls: ['./dossier-navigator.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class DossierNavigatorComponent extends BaseComponent implements OnInit, OnDestroy {

  dossierDetail: TreeModel;
  private subscriptions: Array<Subscription> = [];

  constructor(
    injector: Injector,
    public dossierSandbox: DossierSandbox,
    private route: ActivatedRoute,
    private router: Router
  ) {
    super(injector);
  }

  ngOnInit() {
    this.dossierSandbox.resetState();
    this.registerEvents();
  }

  ngOnDestroy() {
    this.unregisterEvents();
  }

  /**
   * Unsubscribes from events
   */
  public unregisterEvents() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

  /*
  * Registers events
  */
  private registerEvents(): void {
    const filters = new DossierFilterModel();
    // get parrams:
    this.route.queryParams.subscribe(parrams => {
      filters.UserId = +parrams['UserId'] || localStorage.getItem('user.userId');
      filters.Active = parrams.hasOwnProperty('Active') ? parrams['Active'] === 'true' : true;
      filters.Closed = parrams.hasOwnProperty('Closed') ? parrams['Closed'] === 'true' : false;
      filters.Archived = parrams.hasOwnProperty('Archived') ? parrams['Archived'] === 'true' : false;
      filters.IncludeGroup = parrams.hasOwnProperty('IncludeGroup') ? parrams['IncludeGroup'] === 'true' : false;
      filters.IncludeGuest = parrams.hasOwnProperty('IncludeGuest') ? parrams['IncludeGuest'] === 'true' : false;
      filters.IncludeTasks = parrams.hasOwnProperty('IncludeTasks') ? parrams['IncludeTasks'] === 'true' : false;

      this.loadTrees(filters);
    });
  }

  private loadTrees(filters: DossierFilterModel): void {
    this.subscriptions.push(this.dossierSandbox.loggedUser$.subscribe((user: User) => {
      if (user.isLoggedIn) { this.dossierSandbox.loadDossierTrees(filters); }
    }));
  }

  onClickSelectAction(itemData) {
    this.dossierSandbox.selectDossier(itemData.data);
    this.router.navigate([itemData.url]);
  }

  onDeleteSelectAction(itemData) {
    this.dossierSandbox.deleteDossierItem(itemData);
  }
}
