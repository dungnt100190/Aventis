import { PageNotFoundComponent } from './pageNotFound/pageNotFound.component';
import { PageBadGatewayComponent } from './pageBadGateway/pageBadGateway.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '502', component: PageBadGatewayComponent },
  { path: '404', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExceptionsRoutingModule { }
