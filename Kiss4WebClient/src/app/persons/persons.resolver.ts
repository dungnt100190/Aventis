import { Injectable }       from '@angular/core';
import {
  Resolve,
  ActivatedRouteSnapshot
}                           from '@angular/router';
import { PersonsSandbox }   from './persons.sandbox';

@Injectable()
export class PersonsResolver implements Resolve<any> {

    private personsSubscription;

    constructor(public personsSandbox: PersonsSandbox) { }

    /**
     * Triggered when application hits person details route.
     * It subscribes to person list data and finds one with id from the route params.  
     *
     * @param route
     */
    public resolve(route: ActivatedRouteSnapshot) {
        if (this.personsSubscription) return;

        this.personsSubscription = this.personsSandbox.personDetails$.subscribe(person => {
            if (!person) {
                this.personsSandbox.loadPersonDetails(parseInt(route.params.id));
                return;
            }

            this.personsSandbox.selectPerson(person);
        });
    }
}