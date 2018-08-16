import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Sandbox } from '../shared/sandbox/base.sandbox';
import * as store from '../shared/store';
import { UtilService } from '../shared/utility';
import * as PendenzenAction from '../shared/store/actions/pendenzen.action';
import { Observable } from 'rxjs/Observable';
import { ProcessCondition } from '@app/kiss-pendenzen/pendenzen.service';
import { PendenzenDetail } from '@app/shared/models/pendenzen/pendenzenDetail.model';
import { SearchPendenzen } from '@app/shared/models/pendenzen/searchPendenzen.model';

@Injectable()
export class PendenzenSandbox extends Sandbox {
  public navbarItems$: Observable<any> = this.appState$.select(store.getNavBarItems);
  public pendenzenData$: Observable<any> = this.appState$.select(store.getPendenzenData);
  public pendenzenDetail$: Observable<any> = this.appState$.select(store.getPendenzenDetail);

  public processTask$: Observable<any> = this.appState$.select(store.processTask);
  public updateTask$: Observable<any> = this.appState$.select(store.updateTask);

  public getDataSearch$: Observable<any> = this.appState$.select(store.getDataSearch);
  public loadErsteller$: Observable<any> = this.appState$.select(store.getErsteller);
  public loadMasterData$: Observable<any> = this.appState$.select(store.loadMasterData);
  public getEmpfanger$: Observable<any> = this.appState$.select(store.getEmpfanger);
  public getErsteller$: Observable<any> = this.appState$.select(store.getEmpfanger);
  public getLeistungsverantw$: Observable<any> = this.appState$.select(store.getLeistungsverantw);
  public falltragerData$: Observable<any> = this.appState$.select(store.getFalltrager);
  public objLeistungPerson$: Observable<any> = this.appState$.select(store.getLeistungPerson);
  public getLeistungsverantwCreate$: Observable<any> = this.appState$.select(store.getLeistungsverantwCreate);

  constructor(
    protected appState$: Store<store.State>,
    private utilService: UtilService,
    private router: Router
  ) {
    super(appState$);
  }

  /**
   * Load navbarItems from the server
   */
  public LoadNavBarItems(): void {
    this.appState$.dispatch(new PendenzenAction.LoadNavBarAction());
  }

  /**
   * Load list pendenzen from the server
   */
  public LoadPendenzenData(itemType: string): void {
    this.appState$.dispatch(new PendenzenAction.LoadAction(itemType));
  }

  /**
   * Get detail pendenzen from the server
   */
  public GetPendenzenDetail(taskId: number): void {
    this.appState$.dispatch(new PendenzenAction.LoadDetailAction(taskId));
  }

  /**
   * Run process task from the server
   */
  public ProcessTask(processCon: ProcessCondition): void {
    this.appState$.dispatch(new PendenzenAction.ProcessPendenzenAction(processCon));
  }

  /**
  * Load ersteller from the server
  */
  public LoadErsteller(id: number): void {
    this.appState$.dispatch(new PendenzenAction.LoadErstellerAction(id));
  }

  /**
  * Load ersteller from the server
  */
  public GetErsteller(): void {
    this.appState$.dispatch(new PendenzenAction.LoadEmpfangerAction());
  }

  /**
   * load master data from the server
   */
  public LoadMasterData(): void {
    this.appState$.dispatch(new PendenzenAction.LoadMasterDataAction());
  }

  /**
   * get empfanger from the server
   */
  public GetEmpfanger(): void {
    this.appState$.dispatch(new PendenzenAction.LoadEmpfangerAction());
  }

  /**
   * get empfanger from the server
   */
  public GetLeistungsverantw(): void {
    this.appState$.dispatch(new PendenzenAction.LoadLeistungsverantwAction());
  }

  /**
   * get falltrager from the server
   */
  public LoadFalltrager(): void {
    this.appState$.dispatch(new PendenzenAction.LoadFalltragerAction());
  }

  /**
   * get Leistung & betrifft Person from the server
   */
  public LoadLeistungPerson(faFallID: number): void {
    this.appState$.dispatch(new PendenzenAction.LoadLeistungPersonAction(faFallID));
  }

   /**
   * Create or Update task from the server
   */
  public UpdateTask(pendenzen: PendenzenDetail): void {
    this.appState$.dispatch(new PendenzenAction.UpdateTaskAction(pendenzen));
  }

  /**
   * get data search option from server
   */
  GetDataSearchOption(objSearch: SearchPendenzen): any {
    this.appState$.dispatch(new PendenzenAction.GetDataSearchAction(objSearch));
  }

  /**
   * get data search option from server
   */
  GetLeistungsverantwCreate(faFallId: number): any {
    this.appState$.dispatch(new PendenzenAction.GetLeistungsverantwCreateAction(faFallId));
  }
}
