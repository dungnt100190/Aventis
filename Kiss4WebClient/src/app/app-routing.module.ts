import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@app/shared/guards/auth.guard';
import { CanDeactivateGuard } from '@app/shared/guards/canDeactivate.guard';

const appRoutes: Routes = [
  { path: '', redirectTo: '/dossier', pathMatch: 'full' },
  { path: 'login', loadChildren: './auth/auth.module#AuthModule' },
  { path: 'dossier', loadChildren: './dossier-navigator/dossier-navigator.module#DossierNavigatorModule', canLoad: [AuthGuard] },
  { path: 'persons', loadChildren: './persons/persons.module#PersonsModule', canLoad: [AuthGuard] },
  { path: 'exception', loadChildren: './exceptions/exceptions.module#ExceptionsModule', canLoad: [AuthGuard] },
  { path: '**', redirectTo: '/exception/404' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes, { useHash: true })
  ],
  exports: [
    RouterModule
  ],
  providers: [AuthGuard, CanDeactivateGuard]
})
export class AppRoutingModule { }
