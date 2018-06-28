import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../shared/guards/auth.guard';
import { DossierNavigatorComponent } from './dossiers/dossier-navigator.component';
import { TreeListComponent } from './tree-list/tree-list.component';
import { TreeDetailComponent } from './tree-detail/tree-detail.component';

const dossierNavRoutes: Routes = [
    {
        path: '',
        component: DossierNavigatorComponent,
        canActivate: [AuthGuard],
        children: [
            { path: '', component: TreeListComponent },
            { path: 'detail/:id/:faLeistungId', component: TreeDetailComponent }
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(dossierNavRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class DossierRoutingModule { }
