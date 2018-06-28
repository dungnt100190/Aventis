import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';

import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AppSandbox } from '@app/app.sandbox';

@Injectable()
export class AuthorizeGuard implements CanActivate {
  constructor(private router: Router, private appSandbox: AppSandbox) { }

  canActivate(route: ActivatedRouteSnapshot) {
    return this.checkAuthorize(route.data.roles);
  }

  private checkAuthorize(roles: any) {
    return this.appSandbox.availableRoles$.switchMap((rights: Array<string>) => {
      let allow = false;
      if (roles) {
        let i = 0;
        const length = roles.length;
        while (i < length && !allow) {
          const classRight = roles[i].split('.');
          const className = rights[classRight[0]];
          allow = className && className[classRight[1]] ? true : false;
          i++;
        }
      }
      if (!allow) { this.router.navigate(['exception/502', { roles: roles }]); }
      return Observable.of(allow);
    });
  }
}
