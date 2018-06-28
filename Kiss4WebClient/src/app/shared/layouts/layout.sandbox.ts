import {
  Injectable, ViewChild
} from '@angular/core';
import { Router } from '@angular/router';
import { Sandbox } from '../sandbox/base.sandbox';
import { Store } from '@ngrx/store';
import * as store from '../store';
import * as authActions from '../store/actions/auth.action';
import * as settingsActions from '../store/actions/settings.action';
import * as menusActions from '../store/actions/menus.action';
import * as sbDataActions from '../store/actions/search-box.action';
import { TranslateService } from 'ng2-translate';
import { Subscription } from 'rxjs/rx';
import { mergeArrayObject } from '../utility';
import { User } from '@app/shared/models';

@Injectable()
export class LayoutSandbox extends Sandbox {

  public selectedLang$ = this.appState$.select(store.getSelectedLanguage);
  public availableLanguages$ = this.appState$.select(store.getAvailableLanguages);
  public itemMenus$ = this.appState$.select(store.getMenusData);
  public searchBoxsData$ = this.appState$.select(store.getSearchBoxDatasData);
  public selectedMenu$ = this.appState$.select(store.getSelectMenu);
  public availableMenus$ = this.appState$.select(store.getAvaiableMenus);

  private subscriptions: Array<Subscription> = [];

  constructor(
    protected appState$: Store<store.State>,
    private translateService: TranslateService,
    private router: Router
  ) {
    super(appState$);
    this.registerEvents();
  }

  public selectLanguage(lang: any): void {
    this.appState$.dispatch(new settingsActions.SetLanguageAction(lang.code));
    this.appState$.dispatch(new settingsActions.SetCultureAction(lang.culture));
    this.translateService.use(lang.code);
  }

  public logout() {
    this.appState$.dispatch(new authActions.DoLogoutAction());
    this.subscribeToLoginChanges();
  }

  private subscribeToLoginChanges() {
    this.loggedUser$
      .subscribe((user: User) => {
        if (!user.isLoggedIn) {
          localStorage.clear();
          user.remove();
          this.unregisterEvents();
          window.location.assign('/');
        }
      });
  }

  /**
  * Loads Menus from the server
  */
  public loadMenus(): void {
    this.appState$.dispatch(new menusActions.LoadAction());
  }

  /**
   * Select menu header
   * @param e item menu clicked
   */
  public selectMenu(menu: any): void {
    // tslint:disable-next-line:curly
    if (!menu || menu.url === '' || menu.url === undefined) return;
    this.appState$.dispatch(new menusActions.SelectAction(menu));
    this.router.navigate([menu.url]);
  }

  public clickItemSideBar(e: any): void {
    if (e) {
      const menu = e.itemData || {};
      if (menu && menu.url !== '' && menu.url !== undefined) {
        this.appState$.dispatch(new menusActions.SelectAction(menu));
        this.router.navigate([menu.url]);
      }
    }
  }

  public deleteItemSideBar(e: any): void {
    if (e) {
      const menu = e.itemData || {};
      if (menu && menu.url !== '' && menu.url !== undefined) {
        this.appState$.dispatch(new menusActions.SetAvaiableMenu(menu));
      }
    }

  }

  /**
* Loads SearchBoxDatas from the server
*/
  public loadSearchBoxDatas(): void {
    this.appState$.dispatch(new sbDataActions.LoadAction());
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
    this.loadMenus();
    this.loadSearchBoxDatas();
  }
}
