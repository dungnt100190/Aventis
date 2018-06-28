import {
  Injectable
} from '@angular/core';

import { Observable } from 'rxjs/Observable';

@Injectable()
export class AppService {
  /**
   * Transforms grid data trees recieved from the API into array of 'DossierNavigatorTreeModel' instances
   *
   * @param trees
   */
  static getRolesAdapter(roles: any): Array<any> {
    return roles;
  }

  /**
   *
   * Transforms grid data langs recieved from the API api/translations into array of 'lagnuages' instances
   * @param langs
   */
  static getLangsAdapter(langs: any): Array<any> {
    return langs.map(lang => new lang());
  }

  static getDocumentCreate(xDocument: any): Observable<any> {
    return xDocument;
  }
}
