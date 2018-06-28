import {
  Injectable,
  Inject,
  forwardRef
} from '@angular/core';
import { Person } from '../shared/models';
import { PersonsSandbox } from './persons.sandbox';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PersonsService {

  private personsSubscription;

  /**
   * Transforms grid data persons recieved from the API into array of 'Person' instances
   *
   * @param persons
   */
  static gridAdapter(persons: any): Array<any> {
    console.log(persons);
    return null;
  }

  /**
   * Transforms product details recieved from the API into instance of 'Product'
   *
   * @param person
   */
  static personDetailsAdapter(person: any) {
    return person;
  }

  /**
   * Update person 
   * @param id: number, 
   * @param person: Person
   */
  static updatePersonAdapter(id: any, person: any): Person {
    return person.map(person => new Person(person))[0];
  }

  /**
   * Post new person 
   * @param person: Person
   */
  static insertPersonAdapter(person: any): Person {
    return new Person(person);
  }

  /**
   * Delete person  by id
   * @param id
   */
  static deletePersonAdapter(id: number): any {
    return id;
  }
}
