import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { DevExtremeModule } from 'devextreme-angular';
import { TranslateModule } from 'ng2-translate';

import { RouterModule } from '@angular/router';

import { ComponentsModule } from '../shared/components';
import { LayoutContainersModule } from '../shared/layouts/layout.module';
import { PendenzenComponent } from './pendenzen.component';
import { PendenzenService } from './pendenzen.service';
import { PendenzenRoutingModule } from '@app/kiss-pendenzen/pendenzen-routing.module';
import { PendenzenApiClient } from '@app/kiss-pendenzen/pendenzenApiClient.service';
import { PendenzenSandbox } from '@app/kiss-pendenzen/pendenzen.sandbox';
import { EffectsModule } from '@ngrx/effects';
import { PendenzensEffects } from '@app/shared/store/effects/pendenzen.effect';

import { LeftNavComponent } from '../kiss-pendenzen/left-nav/left-nav.component';
import { ContentComponent } from '../kiss-pendenzen/content/content.component';
import { Content1Component } from '../kiss-pendenzen/content/content1/content1.component';
import { Content2Component } from '../kiss-pendenzen/content/content2/content2.component';
import { Content3Component } from '../kiss-pendenzen/content/content3/content3.component';
import { PenService } from '../kiss-pendenzen/pen.service';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    ComponentsModule,
    LayoutContainersModule,
    DevExtremeModule,
    TranslateModule,
    PendenzenRoutingModule,
    EffectsModule.run(PendenzensEffects)
  ],
  declarations: [
    PendenzenComponent,
    LeftNavComponent,
    ContentComponent,
    Content1Component,
    Content2Component,
    Content3Component,
  ],
  providers: [
    PendenzenService,
    PendenzenSandbox,
    PendenzenApiClient,
    PenService
  ]
})
export class PendenzenModule {
}
