import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';
import { ErstellerModel } from '@app/shared/models/pendenzen/ersteller.model';
import { BaseComponent } from '@app/shared/components/base.component';
import { PendenzenSandbox } from '@app/kiss-pendenzen/pendenzen.sandbox';
import { PendenzenService, NavBarItem, NavBarLoad } from '@app/kiss-pendenzen/pendenzen.service';
import { MasterData } from '@app/shared/models/pendenzen/masterData.model';
import { EmpfangerModel } from '@app/shared/models/pendenzen/empfanger.model';
import { Leistungsverantw } from '@app/shared/models/pendenzen/leistungsverantw.model';

import { SearchPendenzen } from '@app/shared/models/pendenzen/searchPendenzen.model';

import * as moment from 'moment';
import { DxFormComponent } from 'devextreme-angular';

@Component({
    selector: 'kiss-pendenzen-content1',
    templateUrl: './content1.component.html',
    styleUrls: [
        './content1.component.css',
        '../../../app.component.css',
        '../content.component.css'
    ],
})
export class Content1Component extends BaseComponent implements OnInit {
    @ViewChild(DxFormComponent) dxFormComponent: DxFormComponent;
    frmSearchOption: any;
    // select box
    itemsStatus: any;
    itemsPendenzTyp: any;
    itemsOrganisationseinheit: any;
    // dropdown
    isgrid1Opened: false;
    isgrid2Opened: boolean;
    isgrid3Opened: boolean;

    // grid
    grid1DataSource: any;
    _grid1BoxValue: number;
    _grid1SelectedRowKeys: number[];

    grid2DataSource: any;
    _grid2BoxValue: number;
    _grid2SelectedRowKeys: number[];

    grid3DataSource: any;
    _grid3BoxValue: number;
    _grid3SelectedRowKeys: number[];

    lstErsteller: ErstellerModel[] = [];
    lstEmpfanger: EmpfangerModel[] = [];
    lstLeistungsverantw: Leistungsverantw[] = [];
    objMaster: MasterData;

    idStatusSelected: number;
    idPendenzType: number;
    idErsteller: number;
    idEmpfanger: number;
    idOrganisationseinheit: number;
    idLeistungsverantw: number;
    strFromErfasst: string;
    strToErfasst: string;
    strFromFallig: string;
    strToFallig: string;
    strFromBearbeitung: string;
    strToBearbeitung: string;
    strFromErledigt: string;
    strToErledigt: string;
    objSearchOption: SearchPendenzen;
    isDisabled: boolean;

    navBarLoad: NavBarLoad;

    // conffig
    //-- filter row
    operationDescriptions: Object = {
        between: "Zwischen",
        contains: "Enthält",
        endsWith: "Endet mit",
        equal: "Ist gleich",
        greaterThan: "Größer als",
        greaterThanOrEqual: "Größer oder gleich",
        lessThan: "Kleiner als",
        lessThanOrEqual: "Kleiner oder gleich",
        notContains: "Enthält nicht",
        notEqual: "Ist nicht gleich",
        startsWith: "Beginnt mit"
    };
    resetOperationText: string = "Zurücksetzen";
    //-- sorting
    sortingLabel: Object = {
        ascendingText: "Aufsteigend sortieren",
        clearText: "Sortierung aufheben",
        descendingText: "Absteigend sortieren",
    }

    // Searching
    waitSearching: any;

    constructor(injector: Injector, public pendenzenSandbox: PendenzenSandbox, private service: PendenzenService) {
        super(injector);
        this.service.listenIsAddAndEdit().subscribe((item: any ) => {
          this.isDisabled = item.isAddOrEdit || false;
        });
        this.onValueChangedBetreff = this.onValueChangedBetreff.bind(this);
        this.onNameKlientInValueChanged = this.onNameKlientInValueChanged.bind(this);
        this.onVornameKlientInValueChanged = this.onVornameKlientInValueChanged.bind(this);
        this.onFallnummerValueChanged = this.onFallnummerValueChanged.bind(this);
    }

    ngOnInit(): void {
        this.pendenzenSandbox.LoadMasterData();
        this.pendenzenSandbox.GetErsteller();
        this.pendenzenSandbox.GetEmpfanger();
        this.pendenzenSandbox.GetLeistungsverantw();
        this.grid1DataSource = this.makeAsyncDataSource1();
        this.grid2DataSource = this.makeAsyncDataSource2();
        this.grid3DataSource = this.makeAsyncDataSource3();
        this.loadMasterData();
        this.listenNvabar();
    }

    onInitializedDateBox(e) {
        e.component.option("calendarOptions", 
        {
            firstDayOfWeek:1
        });
    }

    // Listen event from nvabar
    listenNvabar()
    {
        this.service.listenNavbarItem().subscribe((m: any) => {
            if (m !== undefined) {
                this.navBarLoad = m;
                this.clearSearchCondition();
            }
        });
    }
    
    loadMasterData(): any {
        this.pendenzenSandbox.loadMasterData$.subscribe(data => {
            this.itemsStatus = data.status;
            this.itemsPendenzTyp = data.pendenzType;
            this.itemsOrganisationseinheit = data.organisationseinheit;
        })
    }

    // grid 1
    getErsteller() {
        this.pendenzenSandbox.getErsteller$.subscribe(data => {
            data.forEach(el => {
                let erstellerTemp = new ErstellerModel();
                erstellerTemp.id = el.id,
                    erstellerTemp.typ = el.typ,
                    erstellerTemp.name = el.name,
                    erstellerTemp.kurzel = el.kurzel,
                    erstellerTemp.abteilung = el.abteilung
                this.lstErsteller.push(erstellerTemp);
            });
        });
        return this.lstErsteller;
    }


    onGetValueStatus(event: any) {
        this.idStatusSelected = event.value;

        this.searchOnChange();
    }

    onGetPendenzTyp(event: any) {
        this.idPendenzType = event.value;

        this.searchOnChange();
    }

    onValueChangedBetreff() {
        this.searchOnChange();
    }

    onGetErsteller(event: any) {
        if(event.selectedRowsData.length === 0) 
            this.idErsteller = null;
        else
            this.idErsteller = event.selectedRowsData[0].id;
        this.isgrid1Opened = false;

        this.searchOnChange();
    }

    onGetEmpfamger(event: any) {
        if(event.selectedRowsData.length === 0) 
            this.idEmpfanger = null;
        else
            this.idEmpfanger = event.selectedRowsData[0].id;
        this.isgrid2Opened = false;

        this.searchOnChange();
    }

    onNameKlientInValueChanged() {
        this.searchOnChange();
    }

    onVornameKlientInValueChanged() {
        this.searchOnChange();
    }

    onFallnummerValueChanged() {
        this.searchOnChange();
    }

    onGetLeistungsverantw(event: any) {
        if(event.selectedRowsData.length === 0) 
            this.idLeistungsverantw = null;
        else
            this.idLeistungsverantw = event.selectedRowsData[0].userId;
        this.isgrid3Opened = false;

        this.searchOnChange();
    }

    onGetValueOrganisationseinheit(event: any) {
        this.idOrganisationseinheit = event.value;

        this.searchOnChange();
    }

    onErfasstFromValueChanged(e) {
        this.searchOnChange();
    }

    onErfasstToValueChanged(e) {
        this.searchOnChange();
    }

    onFalligFromValueChanged(e) {
        this.searchOnChange();
    }

    onFalligToValueChanged(e) {
        this.searchOnChange();
    }

    onBearbeitungFromValueChanged(e) {
        this.searchOnChange();
    }

    onBearbeitungToValueChanged(e) {
        this.searchOnChange();
    }

    onErledigtFromValueChanged(e) {
        this.searchOnChange();
    }

    onErledigtToValueChanged(e) {
        this.searchOnChange();
    }



    makeAsyncDataSource1() {
        const data1 = this.getErsteller();
        return new CustomStore({
            loadMode: "raw",
            key: "id",
            load: function () {
                return data1;
            }
        });
    };

    get grid1BoxValue(): number {
        return this._grid1BoxValue;
    }

    set grid1BoxValue(value: number) {
        this._grid1SelectedRowKeys = value && [value] || [];
        this._grid1BoxValue = value;
    }

    get grid1SelectedRowKeys(): number[] {
        return this._grid1SelectedRowKeys;
    }

    set grid1SelectedRowKeys(value: number[]) {
        this._grid1BoxValue = value.length && value[0] || null;
        this._grid1SelectedRowKeys = value;
    }

    grid1Box_displayExpr(item) {
        let displayExpr = "";
        if (item.kurzel)
            displayExpr += item.kurzel + " - ";
        if (item.name)
            displayExpr += item.name;
        if (item.abteilung)
            displayExpr += " (" + item.abteilung + ")";
        return item && displayExpr;
    }

    // grid2
    getEmpfanger(): any {
        this.pendenzenSandbox.getEmpfanger$.subscribe(data => {
            data.forEach(el => {
                let empfangerTemp = new EmpfangerModel();
                empfangerTemp.id = el.id,
                    empfangerTemp.typ = el.typ,
                    empfangerTemp.name = el.name,
                    empfangerTemp.kurzel = el.kurzel,
                    empfangerTemp.abteilung = el.abteilung
                this.lstEmpfanger.push(empfangerTemp);
            });
        })
        return this.lstEmpfanger;
    }

    makeAsyncDataSource2() {
        const data2 = this.getEmpfanger();
        return new CustomStore({
            loadMode: "raw",
            key: "id",
            load: function () {
                return data2;
            }
        });
    };

    get grid2BoxValue(): number {
        return this._grid2BoxValue;
    }

    set grid2BoxValue(value: number) {
        this._grid2SelectedRowKeys = value && [value] || [];
        this._grid2BoxValue = value;
    }

    get grid2SelectedRowKeys(): number[] {
        return this._grid2SelectedRowKeys;
    }

    set grid2SelectedRowKeys(value: number[]) {
        this._grid2BoxValue = value.length && value[0] || null;
        this._grid2SelectedRowKeys = value;
    }

    // grid2Box_displayExpr = grid1Box_displayExpr

    // grid 3
    getLeistungsverantw() {
        this.pendenzenSandbox.getLeistungsverantw$.subscribe(data => {
            data.forEach(el => {
                let leistungsverantwTemp = new Leistungsverantw();
                leistungsverantwTemp.userId = el.userId,
                    leistungsverantwTemp.name = el.name,
                    leistungsverantwTemp.logonName = el.logonName,
                    leistungsverantwTemp.displayText = el.displayText,
                    this.lstLeistungsverantw.push(leistungsverantwTemp);
            });
        })
        return this.lstLeistungsverantw;
    }

    makeAsyncDataSource3() {
        const data3 = this.getLeistungsverantw();
        return new CustomStore({
            loadMode: "raw",
            key: "userId",
            load: function () {
                return data3;
            }
        });
    };

    get grid3BoxValue(): number {
        return this._grid3BoxValue;
    }

    set grid3BoxValue(value: number) {
        this._grid3SelectedRowKeys = value && [value] || [];
        this._grid3BoxValue = value;
    }

    get grid3SelectedRowKeys(): number[] {
        return this._grid3SelectedRowKeys;
    }

    set grid3SelectedRowKeys(value: number[]) {
        this._grid3BoxValue = value.length && value[0] || null;
        this._grid3SelectedRowKeys = value;
    }

    grid3Box_displayExpr(item) {
        return item && item.displayText;
    }

    // handle search
    search() {
        this.objSearchOption = new SearchPendenzen();
        this.objSearchOption.idMenu = this.navBarLoad !== undefined && this.navBarLoad.id !== undefined ? this.navBarLoad.id : '1_2';
        this.objSearchOption.idStatus = this.idStatusSelected;
        this.objSearchOption.idPendenzTyp = this.idPendenzType;
        this.objSearchOption.betreff = this.frmSearchOption.betreff;
        this.objSearchOption.idErsteller = this.idErsteller;
        this.objSearchOption.idEmpfanger = this.idEmpfanger;
        this.objSearchOption.nameKlientIn = this.frmSearchOption.nameKlientIn;
        this.objSearchOption.vornameKlientIn = this.frmSearchOption.vornameKlientIn;
        this.objSearchOption.fallnummer = this.frmSearchOption.fallnummer.split(' ').join('');
        this.objSearchOption.idLeistungsverantw = this.idLeistungsverantw;
        this.objSearchOption.idOrganisationseinheit = this.idOrganisationseinheit;
        if (this.strFromErfasst !== undefined && this.strFromErfasst !== null)
            this.objSearchOption.fromErfasst = moment(this.strFromErfasst).format('YYYY-MM-DD');

        if (this.strToErfasst !== undefined && this.strToErfasst !== null)
            this.objSearchOption.toErfasst = moment(this.strToErfasst).format('YYYY-MM-DD');

        if (this.strFromFallig !== undefined && this.strFromFallig !== null)
            this.objSearchOption.fromFallig = moment(this.strFromFallig).format('YYYY-MM-DD');

        if (this.strToFallig !== undefined && this.strToFallig !== null)
            this.objSearchOption.toFallig = moment(this.strToFallig).format('YYYY-MM-DD');

        if (this.strFromBearbeitung !== undefined && this.strFromBearbeitung !== null)
            this.objSearchOption.fromBearbeitung = moment(this.strFromBearbeitung).format('YYYY-MM-DD');

        if (this.strToBearbeitung !== undefined && this.strToBearbeitung !== null)
            this.objSearchOption.toBearbeitung = moment(this.strToBearbeitung).format('YYYY-MM-DD');

        if (this.strFromErledigt !== undefined && this.strFromErledigt !== null)
            this.objSearchOption.fromErledigt = moment(this.strFromErledigt).format('YYYY-MM-DD');

        if (this.strToErledigt !== undefined && this.strToErledigt !== null)
            this.objSearchOption.toErledigt = moment(this.strToErledigt).format('YYYY-MM-DD');

        this.service.actionSearchOption(this.objSearchOption);
    }

    searchOnChange() {
        clearTimeout( this.waitSearching );
        this.waitSearching = setTimeout(()=> this.search(), 1000)
    }

    clearSearchCondition() {
        this.idStatusSelected = null;
        this.idPendenzType = null;
        this.grid1BoxValue = null;
        this.grid2BoxValue = null;
        this.grid3BoxValue = null;
        this.idOrganisationseinheit = null;
        this.dxFormComponent.instance.resetValues();
        this.strFromErfasst = null;
        this.strToErfasst = null;
        this.strFromFallig = null;
        this.strToFallig = null;
        this.strFromBearbeitung = null;
        this.strToBearbeitung = null;
        this.strFromErledigt = null;
        this.strToErledigt = null;
    }

}
