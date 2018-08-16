import { Component, OnInit, ChangeDetectionStrategy, ViewChild, Input, EventEmitter, Output } from '@angular/core';
import { DxTreeViewComponent } from 'devextreme-angular';

@Component({
  selector: 'app-selected-actions',
  templateUrl: './selected-actions.component.html',
  styleUrls: ['./selected-actions.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SelectedActionsComponent implements OnInit {

  allowDeleting: Boolean = true;
  deleteType: String = 'static';
  selectionMode: String = 'single';
  height: any = 'auto';
  iconUrl: any = 'assets/icon/';

  @Input() selectedActions: Array<any> = [];
  @Output() onItemClick: EventEmitter<any> = new EventEmitter<any>();
  @Output() onDeleteClick: EventEmitter<any> = new EventEmitter<any>();

  constructor() {
  }

  ngOnInit() {
  }

  onClickItem(e: any): void {
    this.onItemClick.emit(e);
  }

  onDeleteItem(e: any): void {
    this.onDeleteClick.emit(e);
  }
}
