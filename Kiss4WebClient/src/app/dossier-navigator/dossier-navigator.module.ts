import { EffectsModule } from '@ngrx/effects';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import {
  ReactiveFormsModule,
  NG_VALIDATORS,
  FormControl
} from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DossierRoutingModule } from './dossier-routing.module';
import { DossierSandbox } from './dossier.sandbox';
import { DossierApiClient } from './dossierApiClient.service';
import { DossierService } from './dossier.service';

import { TranslateModule } from 'ng2-translate';

/**
 * Components
 */
import { DossierNavigatorComponent } from './dossiers/dossier-navigator.component';
import { TreeListComponent } from './tree-list/tree-list.component';
import { NavFiltersComponent } from './nav-filters/nav-filters.component';

/**
 * Dossier Modules
 */
import { ComponentsModule } from '../shared/components';
import { LayoutContainersModule } from './../shared/layouts/layout.module';

/**
 * Module devextreme
 */
import { DevExtremeModule } from 'devextreme-angular';
import { TreeDetailComponent } from './tree-detail/tree-detail.component';
import { DossierEffects } from '@app/shared/store/effects/dossier.effect';


@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    ComponentsModule,
    LayoutContainersModule,
    DevExtremeModule,
    DossierRoutingModule,
    TranslateModule,
    RouterModule,
    EffectsModule.run(DossierEffects),
  ],
  declarations: [
    TreeListComponent,
    NavFiltersComponent,
    DossierNavigatorComponent,
    TreeDetailComponent,
  ],
  providers: [
    DossierApiClient,
    DossierService,
    DossierSandbox,
  ]
})
export class DossierNavigatorModule { }
