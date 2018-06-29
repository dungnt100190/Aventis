import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Sandbox } from '../shared/sandbox/base.sandbox';
import * as store from '../shared/store';
import { UtilService } from '../shared/utility';
import * as PendenzenAction from '../shared/store/actions/pendenzen.action';
import { Observable } from 'rxjs/Observable';
import { debug } from 'util';

@Injectable()
export class PendenzenSandbox extends Sandbox {

  public pendenzenData$: Observable<any> = this.appState$.select(store.getPendenzenData);
  public navbarItems$: Observable<any> = this.appState$.select(store.getNavBarItems);

  constructor(
    protected appState$: Store<store.State>,
    private utilService: UtilService,
    private router: Router
  ) {
    super(appState$);
  }

  /**
  * Load list pendenzen from the server
  */
  public loadListPendenzen(): void {
    this.appState$.dispatch(new PendenzenAction.LoadAction());
  }

  /**
  * Load navbarItems from the server
  */
  public LoadNavBarItems(): void {
    this.appState$.dispatch(new PendenzenAction.LoadNavBarAction());
  }
}
