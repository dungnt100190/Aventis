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
import { PendenzenService } from '@app/kiss-pendenzen/pendenzen.service';

@Injectable()
@DefaultHeaders({
  'Accept': 'application/json',
  'Content-Type': 'application/json',
})

export class PendenzenApiClient extends HttpService {

  /**
   * Retrieves pendenzen data 
   */
  @GET('api/Pendenzen/GetListPendenzen')
  @Adapter(PendenzenService.log)
  public getListPendenzen(): Observable<any> {
    return null;
  };

  /**
  * Retrieves NavBarItems 
  */
  @GET('api/Pendenzen/RefreshNavBarItems')
  @Adapter(PendenzenService.log)
  public RefreshNavBarItems(): Observable<any> {
    return null;
  };
}
