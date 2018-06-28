import {
  Injectable
} from '@angular/core';
import {
  DossierNavigatorTreeModel as TreesModel
} from './../shared/models';

@Injectable()
export class DossierService {

  /**
   * Transforms grid data trees recieved from the API into array of 'DossierNavigatorTreeModel' instances
   *
   * @param trees
   */
  static gridAdapter(trees: any): Array<any> {
    if (trees) { trees[0].parentId = '0'; }
    return trees.map(tree => new TreesModel(tree));
  }
}
