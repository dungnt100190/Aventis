/**
 * How use
 * app-document-generation
 *
 *  <!-- button document -->
     <app-document-generation [displayText]="'word'" [templateId]="'669164'" 
        [contextValues]="[{ Name: 'FaAktennotizID', Value: '17' }, { Name: 'BaPersonID', Value: '64820' }]"
        (onClickEvent)="onDocumentCreate($event)">
      </app-document-generation>

 onDocumentCreate(e) {
    this.appSandbox.postDocumentCreate(e);
    this.appSandbox.xDocument$.subscribe(document => {
      if (!document) return;
      this._document.downloadFile(document.fileBinary, document.docFormatCode, document.docTemplateName);
    });
  }
**/

import { DocumentsHelper } from './doc-helper';
import { DocumentGenerationComponent } from './document-generation.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    DocumentGenerationComponent
  ],
  exports: [
    DocumentGenerationComponent
  ],
  providers: [DocumentsHelper]
})
export class DocumentGenerationModule { }
