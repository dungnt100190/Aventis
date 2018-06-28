import { SelectedActionsModel } from './../../shared/models';
import { Router } from '@angular/router';
import { DossierSandbox } from './../dossier.sandbox';
import {
    Component,
    ChangeDetectionStrategy,
    OnInit,
    Injector,
    ViewEncapsulation
} from '@angular/core';

import { DossierNavigatorTreeModel as TreeModel } from './../../shared/models';
import { BaseComponent } from '../../shared/components/base.component';

@Component({
    selector: 'app-tree-list',
    templateUrl: './tree-list.component.html',
    styleUrls: ['./tree-list.component.scss'],
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class TreeListComponent extends BaseComponent implements OnInit {

    TreesData: Array<any>;
    icon_Name_Url: any = 'assets/icon/';
    icon_Characters_Url: any = 'assets/icon/characters-and-numbers/svg/';

    constructor(
        injector: Injector,
        public dossierSandbox: DossierSandbox,
        private router: Router) {
        super(injector);
    }

    ngOnInit(): void {
        this.titlePage = 'Dossiernavigator';
        this.setTitle(this.titlePage);
    }

    public onSelect(treeModel: TreeModel): void {
        this.dossierSandbox.selectDossier(treeModel);
        this.router.navigate([`dossier/detail/${treeModel.id}/${treeModel.faLeistungId}`]);
    }
}
