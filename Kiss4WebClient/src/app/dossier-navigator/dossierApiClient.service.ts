import {
  Injectable
} from '@angular/core';
import {
  HttpService,
  GET,
  Path,
  Adapter,
  DefaultHeaders,
} from '../shared/asyncServices/http';
import { Observable } from 'rxjs/Observable';
import { DossierService } from './dossier.service';

@Injectable()
@DefaultHeaders({
  'Accept': 'application/json',
  'Content-Type': 'application/json',
})

export class DossierApiClient extends HttpService {

  /**
   * Retrieves all TreesModel
   */
  @GET('api/trees{query}')
  @Adapter(DossierService.gridAdapter)
  public getTrees(@Path('query') query: any): Observable<any> {
    return null;
  };
}
