import { Injectable } from '@angular/core';
import {
  CanActivate, Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Route,
  CanLoad
} from '@angular/router';
import { Observable } from 'rxjs/rx';
import { environment } from 'environments/environment';

@Injectable()
export class AuthGuard implements CanLoad, CanActivate {
  constructor(private router: Router) { }

  canLoad(route: Route): boolean {
    if (this.isLoggedIn()) {
      return true;
    }
    this.router.navigate([environment.page.login]);
    return false;
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    // check authentication
    return this.isLoggedIn(state.url);
  }

  isLoggedIn(url?: string): boolean {
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser && currentUser.isLoggedIn) { return true; }
    // Navigate to the login page with extras
    this.router.navigate([environment.page.login]);
    return false;
  }
}
