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

//import { LeftNavComponent } from '@app/kiss-pendenzen/left-nav/left-nav.component';
//import { ContentComponent } from '@app/kiss-pendenzen/content/content.component';
//import { Content1Component } from '@app/kiss-pendenzen/content/content1/content1.component';
//import { Content2Component } from '@app/kiss-pendenzen/content/content2/content2.component';
//import { Content3Component } from '@app/kiss-pendenzen/content/content3/content3.component';

//import { BrowserModule } from '@angular/platform-browser';
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { DxDataGridModule, DxSelectBoxModule, DxDateBoxModule, DxDropDownBoxModule, DxFormModule, DxTextAreaModule, DxButtonModule, DxPopoverModule, DxTabPanelModule, DxTreeViewModule, DxTemplateModule, DxBoxModule } from 'devextreme-angular';
//import { PenService } from '@app/kiss-pendenzen/pen-demo.service';


@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    ComponentsModule,
    LayoutContainersModule,
    DevExtremeModule,
    TranslateModule,
    PendenzenRoutingModule,
    EffectsModule.run(PendenzensEffects),
    //BrowserModule,
    //BrowserAnimationsModule,
    //DxButtonModule,
    //DxBoxModule,
    //DxDateBoxModule,
    //DxDataGridModule,
    //DxDropDownBoxModule,
    //DxFormModule,
    //DxPopoverModule,
    //DxSelectBoxModule,
    //DxTextAreaModule,
    //DxTabPanelModule,
    //DxTreeViewModule,
    //DxTemplateModule
  ],
  declarations: [
    PendenzenComponent,
    //LeftNavComponent,
    //ContentComponent,
    //Content1Component,
    //Content2Component,
    //Content3Component,
  ],
  providers: [
    PendenzenService,
    PendenzenSandbox,
    PendenzenApiClient,
    //PenService
  ]
})
export class PendenzenModule {
}
