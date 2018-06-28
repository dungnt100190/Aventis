import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppSandbox } from './app.sandbox';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'body',
  templateUrl: `./app.component.html`,
  host: { '[class.body-loginPage]': 'isLoginPage' },
  providers: [AppSandbox]
})
export class AppComponent implements OnDestroy, OnInit {

  public isLoginPage: boolean;
  private subscriptions: Array<Subscription> = [];

  constructor(
    private router: Router,
    public appSandbox: AppSandbox
  ) { }

  ngOnInit() {
    this.appSandbox.setupLanguage();
    // Load user from local storage into redux state
    this.appSandbox.loadUser();
    this.registerEvents();
  }

  ngOnDestroy(): void {
    this.unregisterEvents();
  }

  /**
   * Registers events needed for the application
   */
  private registerEvents(): void {
    // Subscribes to route change event and sets "isLoginPage" variable in order to set correct CSS class on body tag.
    this.router.events.subscribe((route) => {
      this.isLoginPage = route['url'] === '/login' ? true : false;
    });
    // Subscribes to culture
    this.subscriptions.push(this.appSandbox.culture$.subscribe((culture: string) => this.appSandbox.culture = culture));
  }

  /**
* Unsubscribes from events
*/
  public unregisterEvents() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }
}
