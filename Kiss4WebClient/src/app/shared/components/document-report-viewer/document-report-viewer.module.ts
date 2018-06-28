import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReportService } from './report.service';

import { DocumentReportViewerComponent } from './document-report-viewer.component';
import { ReportViewerComponent } from './report-viewer/report-viewer.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    DocumentReportViewerComponent,
    ReportViewerComponent,
  ],
  exports: [
    DocumentReportViewerComponent,
    ReportViewerComponent
  ],
  providers: [ReportService]
})
export class DocumentReportViewerModule { }
