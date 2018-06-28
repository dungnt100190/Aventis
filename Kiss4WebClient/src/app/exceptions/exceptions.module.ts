import { TranslateModule } from 'ng2-translate';
import { PageBadGatewayComponent } from './pageBadGateway/pageBadGateway.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExceptionsRoutingModule } from './exceptions-routing.module';
import { PageNotFoundComponent } from './pageNotFound/pageNotFound.component';

@NgModule({
  imports: [
    CommonModule,
    TranslateModule,
    ExceptionsRoutingModule
  ],
  declarations: [
    PageNotFoundComponent,
    PageBadGatewayComponent
  ]
})
export class ExceptionsModule { }
