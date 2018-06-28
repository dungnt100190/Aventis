import {
  Injector,
  OnInit,
  Component,
  ChangeDetectionStrategy,
} from '@angular/core';

import { Router } from '@angular/router';
import { PersonsSandbox } from '../persons.sandbox';
import { BaseComponent } from '../../shared/components/base.component';
import { SetClassRight } from '../../shared/authorize/authorize.decorators';

@Component({
  selector: 'app-person',
  templateUrl: `./person.component.html`,
  styleUrls: ['./person.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
@SetClassRight('CtlPerson')
export class PersonsComponent extends BaseComponent implements OnInit {

  allowEdit = 'tesst';

  constructor(
    injector: Injector,
    public personsSandbox: PersonsSandbox
  ) {
    super(injector);
  }

  ngOnInit() {
    this.personsSandbox.resetState();
  }

  onClickSelectAction(itemData) {
    console.log('not implement');
  }

  onDeleteSelectAction(itemData) {
    console.log('not implement');
  }
}
