import { PersonsMock } from './../shared/mocks';
import { Person } from './../shared/models/person.model';
import { Injectable } from '@angular/core';
import {
  HttpService,
  GET,
  PUT,
  POST,
  DELETE,
  Body,
  Path,
  Adapter,
  DefaultHeaders
} from '../shared/asyncServices/http';
import { Observable } from 'rxjs/Observable';
import { PersonsService } from './persons.service';
import { HttpHeaders } from '@angular/common/http';

@Injectable()
@DefaultHeaders({
  'Accept': 'application/json',
  'Content-Type': 'application/json',
})

export class PersonsApiClient extends HttpService {

  /**
   * Retrieves all persons
   */
  // @GET('api/personen')
  @Adapter(PersonsService.gridAdapter)
  public getPersons(): Observable<any> {
    // mock data
    return Observable.of(PersonsMock); // null;
  };

  /**
   * Retrieves person details by a given id
   * 
   * @param id
   */
  @GET('api/personen/{id}')
  @Adapter(PersonsService.personDetailsAdapter)
  public getPersonDetails(@Path('id') id: number): Observable<any> { return null; };

  /**
   * Submits person update by a given id
   * 
   * @param id
   * @param person
   */
  @PUT('api/personen/{id}')
  @Adapter(PersonsService.updatePersonAdapter)
  public updatePerson(@Path('id') id: any, @Body person: Person): Observable<any> { return null; }

  /**
   * Submits login form to the server
   * 
   * @param person
   */
  @POST('api/personen')
  @Adapter(PersonsService.insertPersonAdapter)
  public insertPerson(@Body person: Person): Observable<any> { return null; };

  /**
   * Delete person by a given id
   *
   * @param id
   */
  @DELETE('api/personen/{id}')
  @Adapter(PersonsService.deletePersonAdapter)
  public deletePerson(@Path('id') id: number): Observable<any> { return null; };
}
