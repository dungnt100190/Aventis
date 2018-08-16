import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-report-viewer',
  templateUrl: './report-viewer.component.html',
  styleUrls: ['./report-viewer.component.scss']
})
export class ReportViewerComponent {

  @Input() contextValues: any;
  @Input() displayText: string;
  @Input() displayStyle: any = 'btn btn-default';
  @Input() queryName: any;
  @Output() onClickEvent: EventEmitter<any> = new EventEmitter<any>();

  constructor() { }

  onDocClick(report) {
    if (report === undefined || !report) { return; }
    this.onClickEvent.emit(report);
  }
}
