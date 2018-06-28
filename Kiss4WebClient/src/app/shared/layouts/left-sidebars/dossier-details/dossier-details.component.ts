import { DossierNavigatorTreeModel as TreeModel } from './../../../models';
import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'app-dossier-details',
    styleUrls: [`./dossier-details.component.scss`],
    templateUrl: './dossier-details.component.html'
})

export class DossierDetailsComponent {
    @Input() itemData: TreeModel;

    constructor() {
    }
}
