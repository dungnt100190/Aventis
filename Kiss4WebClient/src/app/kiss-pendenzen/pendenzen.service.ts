import { Injectable } from "@angular/core";
import { BehaviorSubject, Subject, Observable } from "rxjs/rx";

@Injectable()
export class PendenzenService {
    constructor() { }

    static log(data: any) {
        return data;
    }

    private _navbarItemSource = new BehaviorSubject("");
    currentNavbarItem = this._navbarItemSource.asObservable();
    changeNavbarItem(itemText: string) {
        this._navbarItemSource.next(itemText);
    }

    private _navbarItemListener = new Subject<any>();
    listenNavbarItem(): Observable<any> {
        return this._navbarItemListener.asObservable();
    }
    actionNavbarItem(data: any) {
        this._navbarItemListener.next(data);
    }

    private _taskIdSource = new BehaviorSubject(0);
    currentTaskId = this._taskIdSource.asObservable();
    changeTaskId(id: number) {
        this._taskIdSource.next(id);
    }

    private _taskIdListener = new Subject<any>();
    listenTaskId(): Observable<any> {
        return this._taskIdListener.asObservable();
    }
    actionTaskId(data: any) {
        this._taskIdListener.next(data);
    }

    private _listTaskIdSource = new BehaviorSubject([]);
    currentListTaskId = this._listTaskIdSource.asObservable();
    changeListTaskId(listId: any[]) {
        this._listTaskIdSource.next(listId);
    }

    private _processTaskListener = new Subject<any>();
    listenProcessTask(): Observable<any> {
        return this._processTaskListener.asObservable();
    }
    actionProcessTask(data: any) {
        this._processTaskListener.next(data);
    }

    private _searchOptionListener = new Subject<any>();
    listenSearchOption(): Observable<any> {
        return this._searchOptionListener.asObservable();
    }
    actionSearchOption(data: any) {
        this._searchOptionListener.next(data);
    }

    private _isAddAndEdit = new Subject<any>();
    listenIsAddAndEdit(): Observable<any> {
      return this._isAddAndEdit.asObservable();
    }
    actionIsAddAndEdit(data: any) {
      this._isAddAndEdit.next(data);
    }

    private _isProcessing = new Subject<any>();
    listenIsProcessing(): Observable<any> {
      return this._isProcessing.asObservable();
    }
    actionIsProcessing(data: any) {
      this._isProcessing.next(data);
    }

    private _expoertedExcel = new Subject<any>();
    listenExportedExcel(): Observable<any> {
      return this._expoertedExcel.asObservable();
    }
    actionExportedExcel(data: any) {
      this._expoertedExcel.next(data);
    }

    private _isChangeNavBarItem = new Subject<any>();
    listenChangeNavBarItem(): Observable<any> {
      return this._isChangeNavBarItem.asObservable();
    }
    actionChangeNavBarItem(data: any) {
      this._isChangeNavBarItem.next(data);
    }

    private _validationSummary = new Subject<any>();
    listenValidationSummary(): Observable<any> {
      return this._validationSummary.asObservable();
    }
    actionValidationSummary(data: any) {
      this._validationSummary.next(data);
    }
}

export class gridSetting {
    key: string;
    value: boolean;
}

export class NavBarItem {
    id: string;
    selected: boolean;
    text: string;
}

export class NavBarLoad {
    id: string;
    taskId: number;
}

export class TaskLoad {
    taskId: number;
    navbarItem: string;
    isActionStatus: boolean;
    taskIdProcess: number;
    ersteller: string;
}

export class ProcessCondition {
    TaskId: number;
    ProcessType: string;
    ReceiverId?: number;
    descriptionTask: string;
}
