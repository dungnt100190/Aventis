import { PersonsComponent } from './person/person.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../shared/guards/auth.guard';
import { CanDeactivateGuard } from '../shared/guards/canDeactivate.guard';
import { PersonsResolver } from './persons.resolver';
import { AuthorizeGuard } from './../shared/authorize/authorize.guard';

import { PersonFormComponent } from './person-form/person-form.component';
import { PersonListComponent } from './person-list/person-list.component';

const personsRoutes: Routes = [
    {
        path: '',
        component: PersonsComponent,
        data: {
            title: 'Persons Manager',
            name: 'person-list',
            roles: ['CtlPerson.mayInsert', 'CtlPerson.mayUpdate', 'CtlPerson.mayDelete']
        },
        canActivate: [AuthGuard, AuthorizeGuard],
        children: [
            { path: '', component: PersonListComponent },
            { path: 'detail/:id', component: PersonFormComponent, resolve: { detail: PersonsResolver } }
        ]
    },
];

@NgModule({
    imports: [
        RouterModule.forChild(personsRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class PersonsRoutingModule { }
