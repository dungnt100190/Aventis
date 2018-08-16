import { Component, OnInit, ViewChild } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';
import { PendenzenService, NavBarItem, ProcessCondition, TaskLoad, NavBarLoad } from '@app/kiss-pendenzen/pendenzen.service';
import { PendenzenSandbox } from '@app/kiss-pendenzen/pendenzen.sandbox';
import { PendenzenDetail } from '@app/shared/models/pendenzen/pendenzenDetail.model';
import { EmpfangerModel } from '@app/shared/models/pendenzen/empfanger.model';
import { Falltrager } from '@app/shared/models/pendenzen/falltrager.model';
import * as moment from 'moment';
import { LeftNavComponent } from '@app/kiss-pendenzen/left-nav/left-nav.component';
import { Content2Component } from '@app/kiss-pendenzen/content/content2/content2.component';
import { DxDataGridComponent, DxValidationSummaryComponent } from 'devextreme-angular';

@Component({
  selector: 'kiss-pendenzen-content3',
  templateUrl: './content3.component.html',
  styleUrls: [
    './content3.component.css',
    '../../../app.component.css',
    '../content.component.css',
  ],
  providers: [LeftNavComponent, Content2Component]
})
export class Content3Component implements OnInit {
  @ViewChild('assigneeDataGrid') assigneeDataGrid: DxDataGridComponent;
  @ViewChild('empfangerDatagrid') empfangerDatagrid: DxDataGridComponent;
  @ViewChild('falltragerDatagrid') falltragerDatagrid: DxDataGridComponent;
  // task data
  pendenzenDetail: PendenzenDetail;
  pendenzenDetailBackUp: PendenzenDetail;
  pendenzenDetailBk: PendenzenDetail;
  navbarItem: NavBarItem;
  taskInfo: TaskLoad;
  valueStatus: string;
  valueErsteller: string;
  valueErstellerBackUp: string;
  valueLeistungsverantw: string;
  messageForwardArea: string;
  isAdd: boolean;
  erfasstLabel: string;
  falligLabel: string;
  // button status
  disableBtnInProcessing: boolean;
  disableBtnFinish: boolean;
  disableBtnAssign: boolean;
  disableBtnAddNewTask: boolean;
  disableBtnEditTask: boolean;
  disableBtnAnfangszustandsdossier: boolean;
  _tempDisableBtnInProcessing: boolean;
  _tempDisableBtnFinish: boolean;
  _tempDisableBtnAssign: boolean;
  _tempDisableBtnAnfangszustandsdossier: boolean;
  _tempVisibleBtnAnfangszustandsdossier: boolean;
  _tempVisibleBtnApprove: boolean;
  _tempVisibleBtnReject: boolean;
  _tempVisibleBtnFinish: boolean;
  // control data
  dataTaskType: any[];
  dataLeistung: any[];
  dataBetrifftPerson: any[];
  // dropdown
  isGridReceiverOpened: boolean;
  isgrid32Opened: boolean;
  isAssigneeGridOpened: boolean;
  // popup
  assigneePopupVisible = false;
  popupConfirmVisible = false;
  anfangszustandsdossierPopupVisible: Boolean = false;
  // grid
  receiverData: EmpfangerModel[] = [];
  gridReceiverData: any;
  _gridReceiverBoxValue: number;
  _gridReceiverSelectedRowKeys: number[];
  falltragerData: Falltrager[] = [];
  gridFalltragerData: any;
  _gridFalltragerBoxValue: number;
  _gridFalltragerSelectedRowKeys: number[];
  _assigneeBoxValue: number;
  _assigneeSelectedRowKeys: number[];
  // control read only status
  isReadOnlyStatus: boolean;
  isReadOnlyPendenzTyp: boolean;
  isReadOnlyBetreff: boolean;
  isReadOnlyBeschreibung: boolean;
  isReadOnlyErsteller: boolean;
  isReadOnlyEmpfanger: boolean;
  isReadOnlyFalltrager: boolean;
  isReadOnlyLeistung: boolean;
  isReadOnlyLeistungsverantw: boolean;
  isReadOnlyBetrifftPerson: boolean;
  isReadOnlyAntwort: boolean;
  isReadOnlyErfasst: boolean;
  isReadOnlyFallig: boolean;
  isAcceptCustomValueFallig: boolean;
  // button visible
  visibleBtnAddNewTask: boolean;
  visibleBtnEditTask: boolean;
  visibleBtnSave: boolean;
  visibleBtnCancel: boolean;
  visibleBtnApprove: boolean;
  visibleBtnReject: boolean;
  visibleBtnAnfangszustandsdossier: boolean;
  visibleBtnFinish: boolean;
  // maxlength
  maxLengthSubject: number;
  maxLengthDescription: number;
  maxLengthAnswer: number;
  maxLengthMessageForward: number;
  valueMaxlengthDescription = null;
  valueMaxlengthAnswer = null;
  // validate
  isBetreffValid: Boolean = true;
  isEmpfangerValid: Boolean = true;
  isAssigneeValid: Boolean = true;
  isDescriptionValid: Boolean = true;
  isAnswerValid: Boolean = true;
  saveq: Boolean;
  betreffValidationError: Object;
  empfangerValidationError: Object;
  assigneeValidationError: Object;
  descriptionValidationError: Object;
  answerValidationError: Object;
  isValidating: Boolean = false;
  isAsssigneeValidating: Boolean = false;
  // form
  isCheckFormDirty: Boolean;
  loadingVisible = false;
  valueErledigt: string;
  valueBearbeitung: string;
  isAddNew = false;
  isEdit = false;
  strNameAssignTask: String = '';
  strKurzel: String = '';
  strAbteilung: String = '';
  processingStatus: Boolean = false;
  // conffig --filter row
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
  resetOperationText: String = 'Zurücksetzen';
  // --sorting
  sortingLabel: Object = {
    ascendingText: 'Aufsteigend sortieren',
    clearText: 'Sortierung aufheben',
    descendingText: 'Absteigend sortieren',
  };
  // get from localstorea
  userID: number;
  // tslint:disable-next-line:max-line-length
  constructor(private service: PendenzenService, private pendenzenSandbox: PendenzenSandbox, private loadLeftNav: LeftNavComponent, private content2: Content2Component) { }

  ngOnInit(): void {
    this.taskInfo = new TaskLoad();
    this.userID = parseInt(localStorage.getItem('user.userId'), null); // Get userID from localStorage
    this.pendenzenDetail = new PendenzenDetail();
    this.pendenzenDetailBk = new PendenzenDetail();
    this.pendenzenDetailBackUp = new PendenzenDetail();
    this.valueErledigt = '---';
    this.valueBearbeitung = '---';
    this.disableBtnInProcessing = true;
    this.disableBtnFinish = true;
    this.disableBtnAssign = true;
    this.visibleBtnFinish = true;
    this.saveq = false;
    this.setReadonly();
    this.setMaxLength();
    this.loadDropDownData();
    this.gridReceiverData = this.makeAsyncReceiverData();
    this.gridFalltragerData = this.makeAsyncFalltragerData();
    this.hideBtnSubmib();
    this.listNvabar();
    this.subscribeStore();
  }

  // subscribe store
  subscribeStore() {
    this.pendenzenSandbox.pendenzenDetail$.subscribe(data => {
      if (data) {
        this.isAdd = false;
        // bind data for Status
        this.setStatusOfPendenzenDetail(data.status);
        this.pendenzenDetail.id = data.id;
        this.pendenzenDetail.status = data.status;
        this.pendenzenDetail.pendenzTyp = data.pendenzTyp;
        this.pendenzenDetail.betreff = data.betreff ? data.betreff : null;
        this.pendenzenDetail.beschreibung = data.beschreibung ? data.beschreibung : null;
        this.pendenzenDetail.empfanger = data.empfanger ? data.empfanger : null;
        this.pendenzenDetail.empfangerName = data.empfangerName ? data.empfangerName : null;
        this.pendenzenDetail.empfangerId = data.empfangerId ? data.empfangerId : null;
        this.pendenzenDetail.falltrager = data.falltrager ? data.falltrager : null;
        this.pendenzenDetail.falltragerName = data.falltragerName ? data.falltragerName : null;
        this.pendenzenDetail.leistungModul = data.leistungModul ? data.leistungModul : null;
        this.pendenzenDetail.leistung = data.leistung ? data.leistung : null;
        this.pendenzenDetail.leistungsverantw = data.leistungsverantw ? data.leistungsverantw : null;
        this.pendenzenDetail.betrifftPerson = data.betrifftPerson ? data.betrifftPerson : null;
        this.pendenzenDetail.antwort = data.antwort ? data.antwort : null;
        this.pendenzenDetail.bearbeitungName = data.bearbeitungName === null ? '---' : data.bearbeitungName;
        this.pendenzenDetail.erledigtName = data.erledigtName === null ? '---' : data.erledigtName;
        this.pendenzenDetail.leistungName = data.leistungModul ? data.leistungModul : null;
        this.pendenzenDetail.leistungsverantName = data.leistungsverantName ? data.leistungsverantName : null;
        this.pendenzenDetail.personId = data.personId ? data.personId : null;
        this.pendenzenDetail.taskTypeName = data.taskTypeName ? data.taskTypeName : null;
        this.pendenzenDetail.betrifftPersonName = data.betrifftPersonName ? data.betrifftPersonName : null;
        this.pendenzenDetail.ersteller = data.ersteller ? data.ersteller : null;
        this.grid32BoxValue = data.falltrager;
        // bind data for empfanger
        this._gridReceiverBoxValue = data.empfangerId;
        this._gridReceiverSelectedRowKeys = [data.empfangerId];
        // bind data for falltrager
        this._gridFalltragerBoxValue = data.falltrager;
        this._gridFalltragerSelectedRowKeys = [data.falltrager];
        // bind data for Erfasst
        if (data.erfasst !== undefined && data.erfasst !== null && data.erfasst !== 'Invalid date') {
          let _erfasst = data.erfasst.split('.').join('/');
          this.erfasstLabel = moment(_erfasst, 'DD/MM/YYYY HH:mm:ss').format('DD.MM.YYYY');
          this.pendenzenDetail.erfasst = moment(_erfasst, 'DD/MM/YYYY HH:mm:ss').format('MM/DD/YYYY HH:mm:ss');
        } else {
          this.pendenzenDetail.erfasst = null;
          this.erfasstLabel = null;
        }
        // bind data for Fällig
        if (data.fallig !== undefined && data.fallig !== null && data.fallig !== 'Invalid date') {
          let _fallig = data.fallig.split('.').join('/');
          this.falligLabel = moment(_fallig, 'DD/MM/YYYY HH:mm:ss').format('DD.MM.YYYY');
          this.pendenzenDetail.fallig = moment(_fallig, 'DD/MM/YYYY HH:mm:ss').format('MM/DD/YYYY HH:mm:ss');
        } else {
          this.pendenzenDetail.fallig = null;
          this.falligLabel = null;
        }
        // enable button follow status
        switch (this.pendenzenDetail.status) {
          case 1: { // Pendent
            this.visibleBtnFinish = true;
            this.disableBtnInProcessing = false;
            this.disableBtnFinish = false;
            this.disableBtnAssign = false;
            this.disableBtnAddNewTask = false;
            this.disableBtnEditTask = false;
          }
            break;
          case 2: { // in Bearbeitung
            this.visibleBtnFinish = true;
            this.disableBtnInProcessing = true;
            this.disableBtnFinish = false;
            this.disableBtnAssign = false;
            this.disableBtnAddNewTask = false;
            this.disableBtnEditTask = false;
          }
            break;
          case 3: { // Erledigt
            this.visibleBtnFinish = true;
            this.disableBtnInProcessing = true;
            this.disableBtnFinish = true;
            this.disableBtnAssign = true;
            this.disableBtnAddNewTask = true;
            this.disableBtnEditTask = true;
          }
            break;
          default: { // 4 Verfallen
            this.visibleBtnFinish = true;
            this.disableBtnInProcessing = true;
            this.disableBtnFinish = true;
            this.disableBtnAssign = true;
            this.disableBtnAddNewTask = false;
            this.disableBtnEditTask = false;
          }
        }
        // dispaly button follow pendenzen typ
        switch (this.pendenzenDetail.pendenzTyp) {
          case 51: // Unbefristetes Gastrecht erteilen
          case 52: { // Befristetes Gastrecht erteilen
            this.visibleBtnAddNewTask = true;
            this.visibleBtnEditTask = true;
            this.visibleBtnApprove = true;
            this.visibleBtnReject = true;
            this.visibleBtnFinish = false;
            this.visibleBtnAnfangszustandsdossier = false;
          }
            break;
          case 14: { // Kontrolle Anfangszustand BFS
            this.visibleBtnAddNewTask = true;
            this.visibleBtnEditTask = true;
            this.visibleBtnAnfangszustandsdossier = true;
            this.visibleBtnApprove = false;
            this.visibleBtnReject = false;
            this.visibleBtnFinish = false;

            if (this.pendenzenDetail.status === 1 || this.pendenzenDetail.status === 2) {
              this.disableBtnAssign = false;
              this.disableBtnAnfangszustandsdossier = false;
            } else { this.disableBtnAnfangszustandsdossier = true; }
          }
            break;
          default: {
            this.visibleBtnApprove = false;
            this.visibleBtnReject = false;
            this.visibleBtnAnfangszustandsdossier = false;
          }
        }
        if (this.empfangerDatagrid) {
          this.empfangerDatagrid.instance.refresh();
          this.empfangerDatagrid.instance.state({});
        } if (this.falltragerDatagrid) {
          this.falltragerDatagrid.instance.refresh();
          this.falltragerDatagrid.instance.state({});
        }
      }
    });
  }

  // Listen event from nvabar
  listNvabar() {
    this.service.listenTaskId().subscribe((m: any) => {
      if (m !== undefined) {
        this.taskInfo = m;
        this.getPendenzenDetail();
      }
    });
  }

  onInitializedDateBox(e) {
    e.component.option('calendarOptions', { firstDayOfWeek: 1 });
  }
  // bind data for Ersteller
  loadErsteller() {
    this.pendenzenSandbox.LoadErsteller(0);
    this.pendenzenSandbox.loadErsteller$.subscribe(data => {
      data ? this.pendenzenDetail.ersteller = data : this.pendenzenDetail.ersteller = null;
    });
  }

  getPendenzenDetail(): void {
    this.hideBtnSubmib();
    this.pendenzenDetail = new PendenzenDetail();
    this.pendenzenSandbox.GetPendenzenDetail(this.taskInfo.taskId);
  }

  onClickInProcessing() {
    this.processingStatus = true;
    var processCon = new ProcessCondition();
    processCon.TaskId = this.pendenzenDetail.id;
    processCon.ProcessType = 'process';
    processCon.ReceiverId = this.pendenzenDetail.empfanger;
    this.pendenzenSandbox.ProcessTask(processCon);
    this.pendenzenSandbox.processTask$.subscribe(data => {
      this.disableBtnInProcessing = data;
      if (data === true) {
        this.service.actionProcessTask(this.taskInfo);
        this.service.actionIsProcessing({ idTask: this.pendenzenDetail.id, processingStatus: this.processingStatus, isChangeNavBarItem: false });
      }
    });
    this.service.actionIsAddAndEdit({ isAddOrEdit: false, isChangeNavBarItem: false });
    this.handleShowEditText();
  }

  onClickFinishTask() {
    this.processingStatus = true;
    var processCon = new ProcessCondition();
    processCon.TaskId = this.pendenzenDetail.id;
    processCon.ProcessType = 'finish';
    processCon.ReceiverId = this.userID;
    this.pendenzenSandbox.ProcessTask(processCon);
    this.pendenzenSandbox.processTask$.subscribe(data => {
      this.disableBtnFinish = this.disableBtnInProcessing = this.disableBtnAssign = data;
      if (data === true) {
        this.service.actionProcessTask(this.taskInfo);
      }
    });
    this.service.actionIsAddAndEdit({ isAddOrEdit: false, isAssignAnDone: true, isChangeNavBarItem: false });
    this.handleShowEditText();
  }
  onClickAddNewTask() {
    this.isAddNew = true;
    this.isEdit = false;
    this.backupBtnDisableStatus();
    this.handleShowEditBox();
    this.isCheckFormDirty = false;
    this.isReadOnlyStatus = true;
    this.isReadOnlyPendenzTyp = false;
    this.isReadOnlyBetreff = false;
    this.isReadOnlyBeschreibung = false;
    this.isReadOnlyErsteller = true;
    this.isReadOnlyEmpfanger = false;
    this.isReadOnlyFalltrager = false;
    this.isReadOnlyLeistung = true;
    this.isReadOnlyLeistungsverantw = false;
    this.isReadOnlyBetrifftPerson = false;
    this.isReadOnlyAntwort = true;
    this.isReadOnlyErfasst = true;
    this.isReadOnlyFallig = false;
    this.isAdd = true;
    // disable btns
    this.disableBtnFinish = true;
    this.disableBtnInProcessing = true;
    this.disableBtnAssign = true;
    this.disableBtnAnfangszustandsdossier = true;
    // visible btns
    this.visibleBtnAnfangszustandsdossier = false;
    this.visibleBtnApprove = false;
    this.visibleBtnReject = false;
    this.visibleBtnFinish = true;
    this.displayBtnSubmib();
    this.valueStatus = 'Pendent';
    this.valueErledigt = '---';
    this.valueBearbeitung = '---';
    // reset data
    this.pendenzenDetailBk = JSON.parse(JSON.stringify(this.pendenzenDetail));
    this.pendenzenDetail = new PendenzenDetail();
    this.pendenzenDetail.status = 1;
    this.valueStatus = 'Pendent';
    console.log(this.pendenzenDetail)
    this._gridReceiverBoxValue = null;
    this._gridReceiverSelectedRowKeys = [];
    this._gridFalltragerBoxValue = null;
    this._gridFalltragerSelectedRowKeys = [];
    this.valueLeistungsverantw = '';
    this.dataLeistung = [];
    this.dataBetrifftPerson = [];
    this.valueErledigt = '---';
    this.pendenzenDetail.id = null;
    this.pendenzenDetail.pendenzTyp = this.dataTaskType[0].value;
    this.pendenzenDetail.erfasst = moment().format('MM-DD-YYYY hh:mm:ss');
    this.pendenzenDetail.fallig = null;
    this.pendenzenDetail.falltrager = null;
    this.pendenzenDetail.betreff = null;
    this.pendenzenDetail.beschreibung = null;
    this.pendenzenDetail.bearbeitungName = null;
    this.pendenzenDetail.antwort = null;
    this.pendenzenDetailBackUp = JSON.parse(JSON.stringify(this.pendenzenDetail));
    this.displayBtnSubmib();
    this.loadErsteller();
    console.log(this.pendenzenDetail)
    this.service.actionIsAddAndEdit({ isAddOrEdit: true, isChangeNavBarItem: false });
  }

  onClickEditTask() {
    this.isEdit = true;
    this.isAddNew = false;
    this._gridReceiverBoxValue = this.pendenzenDetail.empfangerId;
    this._gridReceiverSelectedRowKeys = [this.pendenzenDetail.empfangerId];
    this._gridFalltragerBoxValue = this.pendenzenDetail.falltrager;
    this._gridFalltragerSelectedRowKeys = [this.pendenzenDetail.falltrager];
    if (this.pendenzenDetail.falltrager != null)
      this.loadLeistungPersonData(this.pendenzenDetail.falltrager);
    this.backupBtnDisableStatus();
    this.handleShowEditBox();
    this.isAdd = true;
    this.isCheckFormDirty = false;
    if (this.pendenzenDetail.status == 1) {
      this.isReadOnlyStatus = true;
      this.isReadOnlyPendenzTyp = true;
      this.isReadOnlyBetreff = false;
      this.isReadOnlyBeschreibung = false;
      this.isReadOnlyErsteller = true;
      this.isReadOnlyEmpfanger = false;
      this.isReadOnlyFalltrager = false;
      this.isReadOnlyLeistung = false;
      this.isReadOnlyLeistungsverantw = true;
      this.isReadOnlyBetrifftPerson = false;
      this.isReadOnlyAntwort = false;
      this.isReadOnlyErfasst = true;
      this.isReadOnlyFallig = false;
    } else if (this.pendenzenDetail.status == 2) {
      this.isReadOnlyStatus = true;
      this.isReadOnlyPendenzTyp = true;
      this.isReadOnlyBetreff = true;
      this.isReadOnlyBeschreibung = true;
      this.isReadOnlyErsteller = true;
      this.isReadOnlyEmpfanger = true;
      this.isReadOnlyFalltrager = true;
      this.pendenzenDetail.falltrager != null ? this.isReadOnlyLeistung = false : this.isReadOnlyLeistung = true;
      this.isReadOnlyLeistungsverantw = true;
      this.isReadOnlyBetrifftPerson = true;
      this.isReadOnlyAntwort = false;
      this.isReadOnlyErfasst = true;
      this.isReadOnlyFallig = true;
    }
    this.isAcceptCustomValueFallig = false;
    this.pendenzenDetail.id = this.taskInfo.taskId;
    this.pendenzenDetailBk = JSON.parse(JSON.stringify(this.pendenzenDetail));
    this.pendenzenDetailBackUp = JSON.parse(JSON.stringify(this.pendenzenDetail));
    // visible btns
    this.displayBtnSubmib();
    this.service.actionIsAddAndEdit({ isAddOrEdit: true, isAddNew: this.isAddNew, isEdit: true, isChangeNavBarItem: false });
  }

  onClickApproveTask() { }
  onClickRejectTask() { }

  onClickAnfangszustandsdossier() {
    this.anfangszustandsdossierPopupVisible = true;
  }
  // validate
  validateBetreff() {
    if (this.pendenzenDetail.betreff == undefined || this.pendenzenDetail.betreff == null || this.pendenzenDetail.betreff == '') {
      this.betreffValidationError = { message: 'Das Feld \'Betreff\' darf nicht leer bleiben !' };
      this.isBetreffValid = false;
      return false;
    } else if (this.pendenzenDetail.betreff.trim().length > this.maxLengthSubject) {
      this.betreffValidationError = { message: 'Der Inhalt eines Feldes überschreitet die maximal zugelassene Länge.\n \ Bitte kürzen Sie zuerst den Inhalt und versuchen Sie anschliessend nochmals zu speichern. ! !' };
      this.isBetreffValid = false;
      return false;
    } else {
      this.betreffValidationError = null;
      this.isBetreffValid = true;
      return true;
    }
  }

  validateDescription() {
    if (this.pendenzenDetail.beschreibung != undefined && this.pendenzenDetail.beschreibung != null && this.pendenzenDetail.beschreibung.trim().length > this.maxLengthDescription) {
      this.descriptionValidationError = { message: 'Der Inhalt eines Feldes überschreitet die maximal zugelassene Länge.\n \ Bitte kürzen Sie zuerst den Inhalt und versuchen Sie anschliessend nochmals zu speichern. !' };
      this.valueMaxlengthDescription = this.maxLengthDescription;
      this.isDescriptionValid = false;
      return false;
    } else {
      this.descriptionValidationError = null;
      this.isDescriptionValid = true;
      return true;
    }
  }

  validateAnswer() {
    if (this.pendenzenDetail.antwort != undefined && this.pendenzenDetail.antwort != null && this.pendenzenDetail.antwort.trim().length > this.maxLengthAnswer) {
      this.answerValidationError = { message: 'Der Inhalt eines Feldes überschreitet die maximal zugelassene Länge.\n \ Bitte kürzen Sie zuerst den Inhalt und versuchen Sie anschliessend nochmals zu speichern. !' };
      this.valueMaxlengthAnswer = this.maxLengthAnswer;
      this.isAnswerValid = false;
      return false;
    } else {
      this.answerValidationError = null;
      this.isAnswerValid = true;
      return true;
    }
  }

  onBetreffValueChanged(name, e) {
    if (this.isValidating) {
      this.validateBetreff();
      this.sendValidationSummary();
    }
    this.isFormDirty(name, e);
  }

  validateEmpfanger() {
    if (this.grid31BoxValue === undefined || this.grid31BoxValue == null || this.grid31BoxValue === 0) {
      this.empfangerValidationError = { message: 'Das Feld \'Empfänger\' darf nicht leer bleiben !' };
      this.isEmpfangerValid = false;
      return false;
    } else {
      this.empfangerValidationError = null;
      this.isEmpfangerValid = true;
      return true;
    }
  }

  onEmpfangerValueChanged(name, e) {
    if (this.isValidating) {
      this.validateEmpfanger();
    }
    this.isFormDirty(name, e);
    this.sendValidationSummary();
  }

  onAnswerValueChanged(name, e) {
    if (this.isValidating) {
      this.validateAnswer();
    }
    this.isFormDirty(name, e);
    this.sendValidationSummary();
  }

  onDescriptionValueChanged(name, e) {
    if (this.isValidating) {
      this.validateDescription();
    }
    this.isFormDirty(name, e);
    this.sendValidationSummary();
  }

  onClickSave() {
    this.isValidating = true;
    let _isBetreffValid = this.validateBetreff();
    let _isEmpfangerValid = this.validateEmpfanger();
    let _isAnswerValid = this.validateAnswer();
    let _isDescriptionValid = this.validateDescription();
    if (_isBetreffValid && _isEmpfangerValid && _isAnswerValid && _isDescriptionValid) {
      let pendenzenDetailTemp = new PendenzenDetail();
      pendenzenDetailTemp.id = this.pendenzenDetail.id ? this.pendenzenDetail.id : null;
      pendenzenDetailTemp.status = this.pendenzenDetail.status ? this.pendenzenDetail.status : null;
      pendenzenDetailTemp.pendenzTyp = this.pendenzenDetail.pendenzTyp ? this.pendenzenDetail.pendenzTyp : null;
      pendenzenDetailTemp.betreff = this.pendenzenDetail.betreff ? this.pendenzenDetail.betreff : null;
      pendenzenDetailTemp.beschreibung = this.pendenzenDetail.beschreibung ? this.pendenzenDetail.beschreibung : null;
      pendenzenDetailTemp.empfanger = this.pendenzenDetail.empfanger ? this.pendenzenDetail.empfanger : null;
      pendenzenDetailTemp.empfangerName = this.pendenzenDetail.empfangerName ? this.pendenzenDetail.empfangerName : null;
      pendenzenDetailTemp.empfangerId = this.pendenzenDetail.empfangerId ? this.pendenzenDetail.empfangerId : null;
      pendenzenDetailTemp.falltrager = this.pendenzenDetail.falltrager ? this.pendenzenDetail.falltrager : null;
      pendenzenDetailTemp.falltragerName = this.pendenzenDetail.falltragerName ? this.pendenzenDetail.falltragerName : null;
      pendenzenDetailTemp.leistungModul = this.pendenzenDetail.leistungModul ? this.pendenzenDetail.leistungModul : null;
      pendenzenDetailTemp.leistung = this.pendenzenDetail.leistung ? this.pendenzenDetail.leistung : null;
      pendenzenDetailTemp.leistungsverantw = this.pendenzenDetail.leistungsverantw ? this.pendenzenDetail.leistungsverantw : null;
      pendenzenDetailTemp.betrifftPerson = this.pendenzenDetail.betrifftPerson ? this.pendenzenDetail.betrifftPerson : null;
      pendenzenDetailTemp.antwort = this.pendenzenDetail.antwort ? this.pendenzenDetail.antwort : null;
      pendenzenDetailTemp.bearbeitungName = this.pendenzenDetail.bearbeitungName === null ? this.pendenzenDetail.bearbeitungName : '';
      pendenzenDetailTemp.erledigtName = this.pendenzenDetail.erledigtName === null ? this.pendenzenDetail.erledigtName : '';
      pendenzenDetailTemp.personId = this.pendenzenDetail.personId === null ? null : this.pendenzenDetail.personId;
      this.hideBtnSubmib();
      pendenzenDetailTemp.falltrager = this.grid32BoxValue;
      pendenzenDetailTemp.senderId = this.userID.toString();
      if (this.pendenzenDetail.erfasst !== undefined && this.pendenzenDetail.erfasst !== null) {
        pendenzenDetailTemp.erfasst = moment(this.pendenzenDetail.erfasst, 'MM-DD-YYYY hh:mm:ss').format('MM/DD/YYYY HH:mm:ss');
      }
      if (this.pendenzenDetail.fallig !== undefined && this.pendenzenDetail.fallig !== null) {
        pendenzenDetailTemp.fallig = moment(this.pendenzenDetail.fallig).format('MM/DD/YYYY HH:mm:ss');
      }
      this.pendenzenSandbox.UpdateTask(pendenzenDetailTemp);
      this.pendenzenSandbox.updateTask$.subscribe(data => {
        if (data === true) {
          if (this.isAdd) { this.taskInfo.taskId = 0; }
          this.service.actionProcessTask(this.taskInfo);
        }
      });
      this.setReadonly();
      this.isValidating = false;
      this.isAdd = false;
      this.service.actionIsAddAndEdit({
        isAddOrEdit: false,
        idTask: this.pendenzenDetail.id,
        isAddNew: this.isAddNew,
        isEdit: this.isEdit,
        isChangeNavBarItem: false
      });
      this.handleShowEditText();
    }
    this.sendValidationSummary();
  }

  handleShowEditText() {
    let edit = document.getElementById('app-content3-body');
    edit.style.display = 'none';
    let label = document.getElementById('app-content3-body-lable');
    label.style.display = 'block';
  }

  handleShowEditBox() {
    let edit = document.getElementById('app-content3-body');
    edit.style.display = 'block';
    let label = document.getElementById('app-content3-body-lable');
    label.style.display = 'none';
  }

  onClickCancel() {
    if (this.isCheckFormDirty) {
      this.popupConfirmVisible = true;
    } else {
      this.onClickYes();
      this.service.actionIsAddAndEdit({ isAddOrEdit: false, isChangeNavBarItem: false });
    }
  }

  setReadonly() {
    this.isReadOnlyStatus = true;
    this.isReadOnlyPendenzTyp = true;
    this.isReadOnlyBetreff = true;
    this.isReadOnlyBeschreibung = true;
    this.isReadOnlyErsteller = true;
    this.isReadOnlyEmpfanger = true;
    this.isReadOnlyFalltrager = true;
    this.isReadOnlyLeistung = true;
    this.isReadOnlyLeistungsverantw = true;
    this.isReadOnlyBetrifftPerson = true;
    this.isReadOnlyAntwort = true;
    this.isReadOnlyErfasst = true;
    this.isReadOnlyFallig = false;
    this.isAcceptCustomValueFallig = false;
  }

  displayBtnSubmib() {
    this.visibleBtnAddNewTask = false;
    this.visibleBtnEditTask = false;
    this.visibleBtnSave = true;
    this.visibleBtnCancel = true;
  }

  setMaxLength() {
    this.maxLengthSubject = 50;
    this.maxLengthDescription = 1000;
    this.maxLengthAnswer = 1000;
    this.maxLengthMessageForward = 1000;
  }

  hideBtnSubmib() {
    this.visibleBtnAddNewTask = true;
    this.visibleBtnEditTask = true;
    this.visibleBtnSave = false;
    this.visibleBtnCancel = false;
  }

  // Control data
  loadDropDownData(): any {
    this.pendenzenSandbox.LoadMasterData();
    this.pendenzenSandbox.loadMasterData$.subscribe(data => {
      if (data) {
        this.dataTaskType = data.pendenzType;
      }
    });
  }

  loadLeistungPersonData(faFallID: number): any {
    this.pendenzenSandbox.LoadLeistungPerson(faFallID);
    this.pendenzenSandbox.objLeistungPerson$.subscribe(data => {
      if (data) {
        this.dataLeistung = data.listLeistung;
        this.dataBetrifftPerson = data.listBetrifftPerson;
      }
    });
  }

  onChangeTaskType(name, e) {
    this.isFormDirty(name, e);
  }

  onChangeLeistung(name, e) {
    this.pendenzenDetail.leistung = e.value;
    let faFallId: number = 0;
    faFallId = e.value;
    if (faFallId != null) {
      this.pendenzenSandbox.GetLeistungsverantwCreate(faFallId);
      this.pendenzenSandbox.getLeistungsverantwCreate$.subscribe(data => {
        this.valueLeistungsverantw = data.leistungsverantwName;
        this.pendenzenDetail.leistungsverantName = data.leistungsverantwName;
        this.pendenzenDetail.leistungsverantw = data.userID;
      });
    }
    this.isFormDirty(name, e);
  }

  onChangeBetrifftPerson(name, e) {
    this.pendenzenDetail.personId = e.value;
    this.isFormDirty(name, e);
  }

  // grid Empfanger
  loadReceiverData(): any {
    this.pendenzenSandbox.GetEmpfanger();
    this.pendenzenSandbox.getEmpfanger$.subscribe(data => {
      if (data && data.length > 0) {
        data.forEach(element => {
          let empfangerTemp = new EmpfangerModel();
          empfangerTemp.id = element.id;
          empfangerTemp.typ = element.typ;
          empfangerTemp.name = element.name;
          empfangerTemp.kurzel = element.kurzel;
          empfangerTemp.abteilung = element.abteilung;
          this.receiverData.push(empfangerTemp);
        });
      }
    });
    return this.receiverData;
  }

  makeAsyncReceiverData() {
    const data = this.loadReceiverData();
    return new CustomStore({
      loadMode: 'raw',
      key: 'id',
      load: function () {
        return data;
      }
    });
  }

  get grid31BoxValue(): number {
    return this._gridReceiverBoxValue;
  }

  set grid31BoxValue(value: number) {
    this._gridReceiverSelectedRowKeys = value && [value] || [];
    this._gridReceiverBoxValue = value;
  }

  get grid31SelectedRowKeys(): number[] {
    return this._gridReceiverSelectedRowKeys;
  }

  set grid31SelectedRowKeys(value: number[]) {
    this._gridReceiverBoxValue = value.length && value[0] || null;
    this._gridReceiverSelectedRowKeys = value;
  }

  grid31Box_displayExpr(item) {
    let displayExpr = '';
    if (item) {
      if (item.kurzel)
        displayExpr += item.kurzel + ' - ';
      if (item.name)
        displayExpr += item.name;
      if (item.abteilung)
        displayExpr += ' (' + item.abteilung + ')';
    }
    return displayExpr;
  }

  onGrid31SelectionChanged(e) {
    this.pendenzenDetail.empfangerId = e.selectedRowKeys[0];
    this.isGridReceiverOpened = false;
  }

  getErledigt() {
    return this.receiverData.filter(ele =>
      ele.id === this.pendenzenDetail.empfanger
    );
  }

  // grid Falltrager
  loadFalltragerData(): any {
    this.pendenzenSandbox.LoadFalltrager();
    this.pendenzenSandbox.falltragerData$.subscribe(data => {
      if (data && data.length > 0) {
        data.forEach(element => {
          let falltragerTemp = new Falltrager(element);
          this.falltragerData.push(falltragerTemp);
        });
      }
    });
    return this.falltragerData;
  }

  makeAsyncFalltragerData() {
    const data = this.loadFalltragerData();
    return new CustomStore({
      loadMode: 'raw',
      key: 'id',
      load: function () {
        return data;
      }
    });
  }

  get grid32BoxValue(): number {
    return this._gridFalltragerBoxValue;
  }

  set grid32BoxValue(value: number) {
    this._gridFalltragerSelectedRowKeys = value && [value] || [];
    this._gridFalltragerBoxValue = value;
  }

  get grid32SelectedRowKeys(): number[] {
    return this._gridFalltragerSelectedRowKeys;
  }

  set grid32SelectedRowKeys(value: number[]) {
    this._gridFalltragerBoxValue = value.length && value[0] || null;
    this._gridFalltragerSelectedRowKeys = value;
  }

  grid32Box_displayExpr(item: Falltrager) {
    let displayExpr = '';
    if (item) {
      if (item.name) {
        displayExpr += item.name + ', '; }
      if (item.vorname) {
        displayExpr += item.vorname + ' '; }
    }
    return displayExpr;
  }

  onGrid32SelectionChanged(e) {
    if (e.selectedRowsData[0] && e.selectedRowsData[0].faFallID) {
      this.loadLeistungPersonData(e.selectedRowsData[0].faFallID); }
    this.pendenzenDetail.falltrager = e.selectedRowKeys[0];

    if (this.pendenzenDetail && this.pendenzenDetail.falltrager != null) {
      this.isReadOnlyLeistung = false; }
    this.isgrid32Opened = false;
  }

  // grid Assignee
  get assigneeBoxValue(): number {
    return this._assigneeBoxValue;
  }

  set assigneeBoxValue(value: number) {
    this._assigneeSelectedRowKeys = value && [value] || [];
    this._assigneeBoxValue = value;
  }

  get assigneeSelectedRowKeys(): number[] {
    return this._assigneeSelectedRowKeys;
  }

  set assigneeSelectedRowKeys(value: number[]) {
    this._assigneeBoxValue = value.length && value[0] || null;
    this._assigneeSelectedRowKeys = value;
  }

  assigneeBox_displayExpr(item) {
    let displayExpr = '';
    if (item) {
      if (item.kurzel) {
        displayExpr += item.kurzel + ' - '; }
      if (item.name) {
        displayExpr += item.name; }
      if (item.abteilung) {
        displayExpr += ' (' + item.abteilung + ')'; }
    }
    return displayExpr;
  }

  onAssigneeGridSelectionChanged(e) {
    this.isAssigneeGridOpened = false;
  }

  // popup Assignee
  showAssigneePopup() {
    this.assigneePopupVisible = true;
    if (this.assigneeDataGrid) {
      this.assigneeDataGrid.instance.refresh(); }
  }

  validateAssignee() {
    if (this.assigneeBoxValue == undefined || this.assigneeBoxValue == null || this.assigneeBoxValue == 0) {
      this.assigneeValidationError = { message: 'Das Feld \'Weiterleiten an\' darf nicht leer bleiben !' };
      this.isAssigneeValid = false;
      return false;
    } else {
      this.assigneeValidationError = null;
      this.isAssigneeValid = true;
      return true;
    }
  }

  onAssigneeValueChanged() {
    if (this.isAsssigneeValidating) {
      this.validateAssignee(); }
    this.sendValidationSummary();
  }

  saveAssignee() {
    this.processingStatus = true;
    this.isAsssigneeValidating = true;
    if (this.validateAssignee()) {
      var processCon = new ProcessCondition();
      processCon.TaskId = this.pendenzenDetail.id;
      processCon.ProcessType = 'assign';
      processCon.ReceiverId = this.assigneeBoxValue;
      processCon.descriptionTask = this.pendenzenDetail.beschreibung == null ? '' : this.pendenzenDetail.beschreibung;
      if (this.messageForwardArea != null || this.messageForwardArea != undefined) {
        processCon.descriptionTask = this.messageForwardArea + ' ' + processCon.descriptionTask;
      }
      processCon.descriptionTask = ('WG ' + this.pendenzenDetail.empfangerName + ' ' + processCon.descriptionTask).trim();
      this.pendenzenSandbox.ProcessTask(processCon);
      this.pendenzenSandbox.processTask$.subscribe(data => {
        if (data === true) {
          this.service.actionProcessTask(this.taskInfo);
          this.service.actionIsProcessing({
            idTask: this.pendenzenDetail.id, processingStatus: this.processingStatus, isChangeNavBarItem: false
          });
        }
      });
      this.assigneePopupVisible = false;
      this.isAsssigneeValidating = false;
      this.resetAssigneePopupValues();
    }
    this.service.actionIsAddAndEdit({ isAddOrEdit: false, isChangeNavBarItem: false, isEdit: false });
    this.handleShowEditText();
    this.sendValidationSummary();
  }

  cancelAssignee() {
    if (this.assigneeDataGrid) {
      this.assigneeDataGrid.instance.state({});
    }
    this.assigneePopupVisible = false;
    this.isAssigneeValid = true;
    this.isAsssigneeValidating = false;
    this.resetAssigneePopupValues();
    this.service.actionValidationSummary({ validationSummary: [] });
  }

  assigneePopupHiding(e) {
    this.cancelAssignee();
  }

  resetAssigneePopupValues() {
    this.assigneeBoxValue = null;
    this.messageForwardArea = null;
  }

  // Check form dirty
  onChanged(name, e) {
    this.isFormDirty(name, e);
    if (name === 'falltrager' && e.value == null) {
      this.pendenzenDetail.leistung = null;
      this.pendenzenDetail.leistungsverantName = null;
      this.pendenzenDetail.personId = null;
      this.dataLeistung = [];
      this.dataBetrifftPerson = [];
    }
  }

  isFormDirty(name, e) {
    if (name === 'ersteller' && e.value !== this.valueErstellerBackUp) {
      this.isCheckFormDirty = true;
    } else {
      if (e.value !== this.pendenzenDetailBackUp[name]) {
        this.isCheckFormDirty = true;
      }
    }
  }

  onClickYes() {
    // cancel validate
    this.isBetreffValid = true;
    this.isEmpfangerValid = true;
    this.isDescriptionValid = true;
    this.isAnswerValid = true;
    this.isValidating = false;
    this.pendenzenDetail = this.pendenzenDetailBk;
    this.setStatusOfPendenzenDetail(this.pendenzenDetail.status);
    this.service.actionIsAddAndEdit({ isAddOrEdit: false, isChangeNavBarItem: false });
    // disable btns -- rolback
    this.rolbackBtnDisableStatus();
    // visible btns
    this.hideBtnSubmib();
    this.setReadonly();
    this.isAdd = false;
    this.isAddNew = false;
    this.isEdit = false;
    this.handleShowEditText();
    this.popupConfirmVisible = false;
    this.service.actionValidationSummary({ validationSummary: [] });
  }

  onClickNo() {
    this.popupConfirmVisible = false;
    // disable btns
    if (this.pendenzenDetail.status === 2) {
      this.disableBtnInProcessing = true;
    } else {
      this.disableBtnInProcessing = false;
    }
    this.disableBtnFinish = false;
    this.disableBtnAssign = false;
    if (this.pendenzenDetail && this.pendenzenDetail.id == null) {
      this.disableBtnInProcessing = true;
      this.disableBtnFinish = true;
      this.disableBtnAssign = true;
    }
    // visible btns
    this.displayBtnSubmib();
  }

  backupBtnDisableStatus() {
    this._tempDisableBtnInProcessing = this.disableBtnInProcessing;
    this._tempDisableBtnFinish = this.disableBtnFinish;
    this._tempDisableBtnAssign = this.disableBtnAssign;
    this._tempDisableBtnAnfangszustandsdossier = this.disableBtnAnfangszustandsdossier;
    this._tempVisibleBtnAnfangszustandsdossier = this.visibleBtnAnfangszustandsdossier;
    this._tempVisibleBtnApprove = this.visibleBtnApprove;
    this._tempVisibleBtnReject = this.visibleBtnReject;
    this._tempVisibleBtnFinish = this.visibleBtnFinish;
  }

  rolbackBtnDisableStatus() {
    this.disableBtnInProcessing = this._tempDisableBtnInProcessing;
    this.disableBtnFinish = this._tempDisableBtnFinish;
    this.disableBtnAssign = this._tempDisableBtnAssign;
    this.disableBtnAnfangszustandsdossier = this._tempDisableBtnAnfangszustandsdossier;
    this.visibleBtnAnfangszustandsdossier = this._tempVisibleBtnAnfangszustandsdossier;
    this.visibleBtnApprove = this._tempVisibleBtnApprove;
    this.visibleBtnReject = this._tempVisibleBtnReject;
    this.visibleBtnFinish = this._tempVisibleBtnFinish;
  }

  showAnfangszustandsdossierPopup() {
    this.anfangszustandsdossierPopupVisible = true;
  }

  onClickAnfangszustandsdossierYes() {
    this.anfangszustandsdossierPopupVisible = false;
    this.processingStatus = true;
    var processCon = new ProcessCondition();
    processCon.TaskId = this.pendenzenDetail.id;
    processCon.ProcessType = 'anfangszustandsdossier';
    processCon.ReceiverId = this.userID;
    this.pendenzenSandbox.ProcessTask(processCon);
    this.pendenzenSandbox.processTask$.subscribe(data => {
      if (data === true) {
        this.service.actionProcessTask(this.taskInfo);
      }
    });
    this.service.actionIsAddAndEdit({ isAddOrEdit: false, isChangeNavBarItem: false });
    this.handleShowEditText();
  }

  onClickAnfangszustandsdossierNo() {
    this.anfangszustandsdossierPopupVisible = false;
  }

  sendValidationSummary() {
    let validationSummary = [];
    if (this.betreffValidationError != null) {
      validationSummary.push(this.betreffValidationError);
    }
    if (this.empfangerValidationError != null) {
      validationSummary.push(this.empfangerValidationError);
    }
    if (this.descriptionValidationError != null) {
      validationSummary.push(this.descriptionValidationError);
    }
    if (this.answerValidationError != null) {
      validationSummary.push(this.answerValidationError);
    }
    if (this.isAddNew || this.isEdit) {
      this.service.actionValidationSummary({ validationSummary: validationSummary });
    } else {
      this.service.actionValidationSummary({ validationSummary: [] });
    }
  }
  // Set status of pendenzenDetial
  public setStatusOfPendenzenDetail(status) {
    switch (status) {
      case 1:
        this.valueStatus = 'Pendent';
        break;
      case 2:
        this.valueStatus = 'in Bearbeitung';
        break;
      case 3:
        this.valueStatus = 'Erledigt';
        break;
      case 4:
        this.valueStatus = 'Verfallen';
        break;
      default:
        this.valueStatus = '';
        break;
    }
  }
}
