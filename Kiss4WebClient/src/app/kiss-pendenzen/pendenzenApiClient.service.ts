import { Injectable } from '@angular/core';
import {
  HttpService, DefaultHeaders,
  GET, POST, PUT,
  Adapter, Path, Body,
} from '../shared/asyncServices/http';
import { Observable } from 'rxjs/Observable';
import { PendenzenService, ProcessCondition } from '@app/kiss-pendenzen/pendenzen.service';
import { Pendenzen } from '@app/shared/models/pendenzen/pendenzen.model';
import { PendenzenDetail } from '@app/shared/models/pendenzen/pendenzenDetail.model';
import { SearchPendenzen } from '@app/shared/models/pendenzen/searchPendenzen.model';

@Injectable()
@DefaultHeaders({
  'Accept': 'application/json',
  'Content-Type': 'application/json',
})

export class PendenzenApiClient extends HttpService {
  /**
   * Retrieves NavBar Items 
   */
  @GET('api/Pendenzen/LoadNavBarItems')
  @Adapter(PendenzenService.log)
  public LoadNavBarItems(): Observable<any> {
    return null;
  };

  /**
   * Retrieves pendenzen data list
   */
  @GET('api/Pendenzen/GetPendenzenData/{itemType}')
  @Adapter(PendenzenService.log)
  public GetPendenzenData(@Path('itemType') itemType: string): Observable<any> {
    return null;
  };

  /**
   * Retrieves detail info of a pendenzen
   * @param taskId 
   */
  @GET('api/Pendenzen/GetPendenzenDetail/{taskId}')
  @Adapter(PendenzenService.log)
  public GetPendenzenDetail(@Path('taskId') taskId: number): Observable<any> {
    return null;
  };

  /**
   * Change status of task: to process (in Bearbeitung)
   * Change status of task: to finish (Erledigt)
   * @param processCon 
   */
  @POST('api/Pendenzen/ProcessTask')
  @Adapter(PendenzenService.log)
  public ProcessTask(@Body processCon: ProcessCondition): Observable<any> {
    return null;
  };

  /**
   * Assign Pendenzen to other Person (Weiterleiten)
   * @param pendenzen 
   */
  @POST('api/Pendenzen/AssignToOtherPerson')
  @Adapter(PendenzenService.log)
  public AssignToOtherPerson(@Body pendenzen: Pendenzen): Observable<any> {
    return null;
  };

  /**
   * Add (Neue Pendenz) or Edit (Bearbeiten) pendenzen
   * @param pendenzen 
   */
  @POST('api/Pendenzen/CreateUpdateTask')
  @Adapter(PendenzenService.log)
  public CreateUpdateTask(@Body pendenzen: PendenzenDetail): Observable<any> {
    return null;
  };

  /**
   * Retrieves data for search & detail controls --> Quyen
   */
  @GET('api/Pendenzen/GetControlData')
  @Adapter(PendenzenService.log)
  public GetControlData(): Observable<any> {
    return null;
  };

  /**
   * Get Pendenz Typ
   */
  @GET('api/Pendenzen/GetPendenzenType')
  @Adapter(PendenzenService.log)
  public GetPendenzenType(): Observable<any> {
    return null;
  };

  /**
   * Get Ersteller
   */
  @GET('api/Pendenzen/GetErsteller/{id}')
  @Adapter(PendenzenService.log)
  public GetErsteller(@Path('id') id: number): Observable<any> {
    return null;
  };

  /** 
   * Get Master data
   */
  @GET('api/GetMasterData')
  @Adapter(PendenzenService.log)
  public GetMasterData(): Observable<any> {
    return null;
  };

  /** 
   * Get Empfanger
   */
  @GET('api/Pendenzen/GetEmpfanger')
  @Adapter(PendenzenService.log)
  public GetEmpfanger(): Observable<any> {
    return null;
  };

  /** 
   * Get Empfanger
   */
  @GET('api/Pendenzen/GetLeistungsverantw')
  @Adapter(PendenzenService.log)
  public GetLeistungsverantw(): Observable<any> {
    return null;
  };

  /**
   * Load Falltrager
   */
  @GET('api/Pendenzen/LoadFalltrager')
  @Adapter(PendenzenService.log)
  public LoadFalltrager(): Observable<any> {
    return null;
  };

  /**
   * Load Leistung & betrifft Person
   */
  @GET('api/Pendenzen/LoadLeistungPerson/{faFallID}')
  @Adapter(PendenzenService.log)
  public LoadLeistungPerson(@Path('faFallID') faFallID: number): Observable<any> {
    return null;
  };

  /**
   * Search pendenzen (Suche)
   * @param objSearch 
   */
  @POST('api/Pendenzen/Search')
  @Adapter(PendenzenService.log)
  public GetDataSearch(@Body objSearch: SearchPendenzen): Observable<any> {
    return null;
  };

  /**
   * Search pendenzen (Suche)
   * @param objSearch 
   */
  @POST('api/Pendenzen/LeistungsverantwCreate/{faFallId}')
  @Adapter(PendenzenService.log)
  public GetLeistungsverantwCreate(@Path('faFallId') faFallId?: number): Observable<any> {
    return null;
  };
}
