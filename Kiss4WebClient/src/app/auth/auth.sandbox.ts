import { Injectable } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs/rx';
import { Sandbox } from '../shared/sandbox/base.sandbox';
import * as store from '../shared/store';
import * as authActions from '../shared/store/actions/auth.action';
import * as settingsActions from '../shared/store/actions/settings.action';
import { User } from '../shared/models';
import {
  UtilService,
  tryParseJwt
} from '../shared/utility';
import {
  LoginForm
} from '../shared/models';
import { environment } from '../../environments/environment';

@Injectable()
export class AuthSandbox extends Sandbox {

  public loginLoading$ = this.appState$.select(store.getAuthLoading);
  public loginLoaded$ = this.appState$.select(store.getAuthLoaded);

  private subscriptions: Array<Subscription> = [];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    protected appState$: Store<store.State>,
    private utilService: UtilService
  ) {
    super(appState$);
    this.registerAuthEvents();
  }

  /**
   * Dispatches login action
   *
   * @param form
   */
  public login(form: any): void {
    this.appState$.dispatch(new authActions.DoLoginAction(new LoginForm(form)));
  }

  /**
   * Unsubscribe from events
   */
  public unregisterEvents() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

  /**
   * Registers events
   */
  private registerAuthEvents(): void {
    // Subscribes to logged user data and save/remove it from the local storage
    this.subscriptions.push(this.loggedUser$.subscribe((user: User) => {
      if (user.isLoggedIn) {
        user.save();
        if (localStorage.getItem('user') === null) {
          const userInfo: any = tryParseJwt(user.access_token);
          localStorage.setItem('user.userId', userInfo.sub);
          localStorage.setItem('user', userInfo.LogonName);
        }
        if (this.router.url === environment.page.login) { return this.router.navigate([environment.page.dossier]); }
      } else {
        // clear state appState
        this.appState$.dispatch(new settingsActions.ResetState());
        user.remove();
      }
    }));
  }

  /**
   * Uncapitalize response keys
   *
   * @param user
   */
  // tslint:disable-next-line:member-ordering
  static authAdapter(user: any): any {
    return Object.assign({}, user, { access_token: user.access_token });
  }

  // tslint:disable-next-line:member-ordering
  static logoutAdapter(user: any): any {
    return Object.assign({}, user);
  }

  public getConfigsToken() {
    return this.utilService.getConfig('tokens');
  }
}
