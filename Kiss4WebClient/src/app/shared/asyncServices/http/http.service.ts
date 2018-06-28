// tslint:disable-next-line:import-spacing
import { HttpClient }          from '@angular/common/http';
// tslint:disable-next-line:import-spacing
import { Injectable }          from '@angular/core';
import {
  Http,
  Request,
  RequestMethod,
  Response
// tslint:disable-next-line:import-spacing
}                               from '@angular/http';
// tslint:disable-next-line:import-spacing
import { Observable }           from 'rxjs/Observable';
// tslint:disable-next-line:import-spacing
import { HttpResponseHandler }  from './httpResponseHandler.service';
// tslint:disable-next-line:import-spacing
import { HttpAdapter }          from './http.adapter';
// tslint:disable-next-line:import-spacing
import { ConfigService }        from '../../../app-config.service';
import {
  methodBuilder,
  paramBuilder
  // tslint:disable-next-line:import-spacing
}                               from './utils.service';

/**
 * Supported @Produces media types
 */
export enum MediaType {
  JSON,
  FORM_DATA
}

@Injectable()
export class HttpService {

  public constructor(
    protected http: Http,
    protected httpCLient: HttpClient,
    protected configService: ConfigService,
    protected responseHandler: HttpResponseHandler) {
  }

  protected getBaseUrl(): string {
    return this.configService.get('api').baseUrl;
  }

  protected getConfigsApi(): any {
    return this.configService.get('api');
  }

  protected getDefaultHeaders(): Object {
    return null;
  }

  protected getTokens() {
    return localStorage.getItem('token');
  }

  protected getLangCulture() {
    return localStorage.getItem('currentLang.Culture') || 'de-CH';
  }

  /**
  * Request Interceptor
  *
  * @method requestInterceptor
  * @param {Request} req - request object
  */
  protected requestInterceptor(req: Request) {
    req.headers.append('Authorization', `Bearer ${this.getTokens()}`);
    req.headers.append('Accept-Language', this.getLangCulture());
  }

  /**
  * Response Interceptor
  *
  * @method responseInterceptor
  * @param {Response} observableRes - response object
  * @returns {Response} res - transformed response object
  */
  protected responseInterceptor(observableRes: Observable<any>, adapterFn?: Function): Observable<any> {
    return observableRes
    .map(res => HttpAdapter.baseAdapter(res, adapterFn))
    .catch((err, source) => this.responseHandler.onCatch(err, source));
  }
}
