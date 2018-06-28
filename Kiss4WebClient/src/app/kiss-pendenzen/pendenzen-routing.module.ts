import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { PendenzenComponent } from "./pendenzen.component";
import { AuthGuard } from "@app/shared/guards/auth.guard";

const pendenzenNavRoutes: Routes = [
  {
    path: '',
    component: PendenzenComponent,
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(pendenzenNavRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class PendenzenRoutingModule { }
