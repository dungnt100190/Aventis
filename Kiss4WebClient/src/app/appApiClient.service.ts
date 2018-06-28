import {
  Injectable
} from '@angular/core';
import {
  HttpService,
  GET,
  Adapter,
  DefaultHeaders,
  POST,
  Path,
  Body
} from './shared/asyncServices/http';
import { Observable } from 'rxjs/Observable';
import { AppService } from './app.service';

@Injectable()
@DefaultHeaders({
  'Accept': 'application/json',
  'Content-Type': 'application/json',
})

export class AppApiClient extends HttpService {

  /**
   * Retrieves all TreesModel
   */
  @GET('api/me/rights')
  @Adapter(AppService.getRolesAdapter)
  public getRoles(): Observable<any> {
    return Observable.of(this.getConfigsApi()['rights']);
  }

  // call api documents create template
  @POST('api/documents/create?templateId={templateId}')
  @Adapter(AppService.getDocumentCreate)
  public DocumentCreate(@Path('templateId') templateId: any, @Body contextValues: any): Observable<any> {
    return null;
  };
}
