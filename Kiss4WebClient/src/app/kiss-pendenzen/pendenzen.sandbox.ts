import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Sandbox } from '../shared/sandbox/base.sandbox';
import * as store from '../shared/store';
import { UtilService } from '../shared/utility';
import * as pendenzenActions from '../shared/store/actions/pendenzen.actions';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PendenzenSandbox extends Sandbox {
    public pendenzenData$: Observable<any> = this.appState$.select(store.getPendenzenData);
    constructor(
        protected appState$: Store<store.State>,
        private utilService: UtilService,
        private router: Router
    ) {
        super(appState$);
    }

    /**
  * Load list pendenzen from the server
  */
    public loadListPendenzen(): void {
        this.appState$.dispatch(new pendenzenActions.LoadAction());
    }

    btnClickEvent(e?: any) {
        // alert('clicked button');
        this.pendenzenData$.subscribe(data => {
            if(data) { console.log(data); }
        });
    }
}