import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import {
 User
} from '../shared/models';
import {
  HttpService,
  DefaultHeaders,
  Adapter,
} from '../shared/asyncServices/http';
import { AuthSandbox } from './auth.sandbox';
import { RequestOptionsArgs, Headers } from '@angular/http';

@DefaultHeaders({
  'Accept': 'application/json',
  'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' // 'application/json'
})

@Injectable()
export class AuthApiClient extends HttpService {

  /**
   * Submits login form to the server
   *
   * @param form
   */
  @Adapter(AuthSandbox.authAdapter)
  public login(searchParams: any): Observable<any> {
    const options: RequestOptionsArgs = {
      headers: new Headers({ 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }),
    };
    return this.responseInterceptor(this.http.post(`${this.getConfigsApi().baseUrlToken}/connect/token`, searchParams, options));
  }

  /**
   * Logs out current user
   */
  @Adapter(AuthSandbox.logoutAdapter)
  public logout(): Observable<any> { return Observable.of(new User()); };
}
