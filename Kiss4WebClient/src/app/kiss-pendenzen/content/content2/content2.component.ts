import {Component, Injector, OnInit, ViewChild} from '@angular/core';
import {NavBarItem, PendenzenService, TaskLoad, NavBarLoad, gridSetting} from '@app/kiss-pendenzen/pendenzen.service';
import {PendenzenSandbox} from '@app/kiss-pendenzen/pendenzen.sandbox';
import {BaseComponent} from '@app/shared/components/base.component';
import {Pendenzen} from '@app/shared/models/pendenzen/pendenzen.model';
import {SearchPendenzen} from '@app/shared/models/pendenzen/searchPendenzen.model';
import {DxDataGridComponent} from 'devextreme-angular';

@Component({
  selector: 'kiss-pendenzen-content2',
  templateUrl: './content2.component.html',
  styleUrls: [
    './content2.component.css',
    '../../../app.component.css',
    '../content.component.css'
  ],
})
export class Content2Component extends BaseComponent implements OnInit {
  @ViewChild('pendenzenDatagrid') pendenzenDatagrid: DxDataGridComponent;

  navBarLoad: NavBarLoad;
  taskInfo: TaskLoad;
  pendenzenData: Pendenzen[];
  toggleVisible: boolean;
  pendenzenItem: Pendenzen;
  objSearch: SearchPendenzen;
  isDisabled: boolean;

  idTask: number;
  isAddNew: boolean;
  isEdit: boolean;
  isProcessingStatus: boolean;
  isChangeNavBarItem: boolean;
  // conffig
  //-- filter row
  operationDescriptions: Object = {
    between: 'Zwischen',
    contains: 'Enthält',
    endsWith: 'Endet mit',
    equal: 'Ist gleich',
    greaterThan: 'Größer als',
    greaterThanOrEqual: 'Größer oder gleich',
    lessThan: 'Kleiner als',
    lessThanOrEqual: 'Kleiner oder gleich',
    notContains: 'Enthält nicht',
    notEqual: 'Ist nicht gleich',
    startsWith: 'Beginnt mit'
  };
  resetOperationText: string = 'Zurücksetzen';
  //-- header filter
  headerFilterTexts: Object = {
    cancel: 'Abbrechen',
    emptyValue: '(Leerwerte)',
    ok: 'Ok',
    selectAll: 'Alles auswählen',
    noDataText: 'Keine Daten verfügbar'
  };
  // select all Alles auswählen
  //-- sorting
  sortingLabel: Object = {
    ascendingText: 'Aufsteigend sortieren',
    clearText: 'Sortierung aufheben',
    descendingText: 'Absteigend sortieren',
  };
  //-- hidden Spalte ausblenden

  // Fix bug focus row
  selectedKeys = [];
  loadingVisible = false;

  gridSetting: gridSetting;

  public FagListenReload = false;

  constructor(injector: Injector, private pendenzenSandbox: PendenzenSandbox, private service: PendenzenService) {
    super(injector);
  }

  ngOnInit(): void {
    this.navBarLoad = new NavBarLoad();
    this.gridSetting = new gridSetting();
    this.listNvabar();
    this.subscribePendenzenData();
  }

  subscribePendenzenData(){
    this.pendenzenSandbox.pendenzenData$.subscribe(data => {
      this.pendenzenData = [];
      if (data && data.length > 0) {
        data.forEach(element => {
          let pendenzenItem = new Pendenzen();
          pendenzenItem.id = element.xTaskID;
          pendenzenItem.fallig = element.expirationDate;
          pendenzenItem.betreff = element.subject;
          pendenzenItem.leistungsverantw = element.leistungModul;
          pendenzenItem.falltrager = element.faFall;
          pendenzenItem.fallnummer = element.fallnummer ? `${element.fallnummer}` : '';
          pendenzenItem.person = element.personBP;
          pendenzenItem.ersteller = element.sender;
          pendenzenItem.empfanger = element.receiver;
          pendenzenItem.status = element.taskStatusCode === 1 ? 'Pendent' : (element.taskStatusCode === 2 ? 'in Bearbeitung' : 'Erledigt');
          pendenzenItem.erfasst = element.createDate;
          pendenzenItem.bearbeitung = element.taskStatusCode === 1 ? '' : element.startDate;
          pendenzenItem.erledigt = element.doneDate;
          pendenzenItem.antwort = element.responseText;
          this.pendenzenData.push(Object.assign({}, pendenzenItem));
        });
        console.log(this.isChangeNavBarItem);
        console.log(this.isEdit);
        console.log(this.idTask);
        if(!this.isChangeNavBarItem && (this.isEdit || this.isProcessingStatus) && this.idTask) {
          this.taskInfo.taskId = this.idTask;
        } else {
          // set default paging when Adding new record
          // this.pendenzenDatagrid.instance.pageIndex(0);
          this.taskInfo.taskId = this.pendenzenData[0].id;
        }
        this.service.actionTaskId(this.taskInfo);
        // Get first detail of task from grid
        // this.selectedKeys = [this.isEdit || this.isProcessingStatus ? this.idTask : this.taskInfo.taskId];
        this.selectedKeys = [this.taskInfo.taskId];
      } else {
        this.taskInfo.taskId = undefined;
        this.service.actionTaskId(this.taskInfo);
      }
    });
  }
  // Listen event from nvabar
  listNvabar() {
    this.taskInfo = new TaskLoad();
    this.service.listenNavbarItem().subscribe((m: any) => {
      if (m !== undefined) {
        this.navBarLoad = m;
        this.taskInfo.navbarItem = this.navBarLoad.id;
        this.getPendenzenData();
      }
    });
    this.service.listenSearchOption().subscribe((m: any) => {
      if (m !== undefined) {
        this.objSearch = m;
        this.getSearchOptionData(this.objSearch);
      }
    });
    this.service.listenIsAddAndEdit().subscribe((item: any) => {
      this.isDisabled = item.isAddOrEdit || false;
      this.isAddNew = item.isAddNew;
      if (item.isEdit) { this.idTask = item.idTask; }
      if (item.isAddNew || item.isAssignAnDone) { this.idTask = undefined; }
      this.isEdit = item.isEdit;
      this.isChangeNavBarItem = item.isChangeNavBarItem;
      console.log(item)
    });
    this.service.listenIsProcessing().subscribe((item: any) => {
      this.isProcessingStatus = item.processingStatus;
      this.idTask = item.idTask;
      this.isChangeNavBarItem = item.isChangeNavBarItem;
    });
    // Export Excel
    this.service.listenExportedExcel().subscribe((gridSetting: any) => {
      this.gridSetting = gridSetting;
      if (this.gridSetting.key == null || this.gridSetting.key == '') return;
      else if (this.gridSetting.key == 'exportExcel') {
        this.pendenzenDatagrid.instance.exportToExcel(false);
      }
      else if (this.gridSetting.key == 'showcustomizationwindow') {
        this.gridSetting.key ? this.pendenzenDatagrid.instance.showColumnChooser() : this.pendenzenDatagrid.instance.hideColumnChooser();
      }
      else if (this.gridSetting.key == 'headerFillter') {
        this.pendenzenDatagrid.headerFilter(this.gridSetting.value);
      }
      else if (this.gridSetting.key == 'fillterRow') {
        this.pendenzenDatagrid.filterRow(this.gridSetting.value);
      }
      else if (this.gridSetting.key == 'groupingPanel') {
        this.pendenzenDatagrid.groupPanel(this.gridSetting.value);
      }
      else if (this.gridSetting.key == 'grouping') {
        this.pendenzenDatagrid.grouping(this.gridSetting.value);
      }
      else if (this.gridSetting.key == 'search') {
        this.pendenzenDatagrid.searchPanel(this.gridSetting.value);
      }
    });

    this.service.listenChangeNavBarItem().subscribe((item: any) => {
      this.isChangeNavBarItem = item.isChangeNavBarItem || false;
      this.isEdit = false;
      this.isProcessingStatus = false;
    });
  }

  getSearchOptionData(objSearch: any) {
    this.pendenzenSandbox.GetDataSearchOption(objSearch);
    this.pendenzenSandbox.getDataSearch$.subscribe(data => {
      this.pendenzenData = [];
      // Must remove this line of code
      //  this.taskInfo.taskId = 0;
      // this.service.actionTaskId(this.taskInfo);
      if (data && data.length > 0) {
        data.forEach(element => {
          let pendenzenItem = new Pendenzen();
          pendenzenItem.id = element.xTaskID;
          pendenzenItem.fallig = element.expirationDate;
          pendenzenItem.betreff = element.subject;
          pendenzenItem.leistungsverantw = element.leistungModul;
          pendenzenItem.falltrager = element.faFall;
          pendenzenItem.fallnummer = element.fallnummer ? `${element.fallnummer}` : '';
          pendenzenItem.person = element.personBP;
          pendenzenItem.ersteller = element.sender;
          pendenzenItem.empfanger = element.receiver;
          pendenzenItem.status = element.taskStatusCode === 1 ? 'Pendent' : (element.taskStatusCode === 2 ? 'in Bearbeitung' : 'Erledigt');
          pendenzenItem.erfasst = element.createDate;
          pendenzenItem.bearbeitung = element.taskStatusCode === 1 ? '' : element.startDate;
          pendenzenItem.erledigt = element.doneDate;
          pendenzenItem.antwort = element.responseText;
          this.pendenzenData.push(Object.assign({}, pendenzenItem));
        });
        this.taskInfo.taskId = this.pendenzenData[0].id;
        this.service.actionTaskId(this.taskInfo);
        this.selectedKeys = [this.pendenzenData[0].id];
      } 
      else 
      {
        this.taskInfo.taskId = null;
        this.service.actionTaskId(this.taskInfo);
      }
    });
  }

  getPendenzenData() {
    if (this.navBarLoad.id !== null && typeof this.navBarLoad.id !== undefined) {
      this.pendenzenSandbox.LoadPendenzenData(this.navBarLoad.id);
    }
  }

  onSelectionChanged(e) {
    if (typeof e !== 'undefined') {
      if (typeof e.key !== 'undefined') {
        this.taskInfo.taskId = e.key;
      }
      this.service.actionTaskId(this.taskInfo);
    }
  }

  handlePopover() {
    this.toggleVisible = !this.toggleVisible;
  }
}
