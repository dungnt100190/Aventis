import { PersonsSandbox } from './../persons.sandbox';
import {
  Component,
  OnInit,
  ChangeDetectionStrategy,
  Injector
} from '@angular/core';

import { BaseComponent } from '../../shared/components/base.component';
import { Person, ActionHandler } from '../../shared/models';
import { SetClassRight } from '../../shared/authorize/authorize.decorators';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
@SetClassRight('CtlPerson')
export class PersonListComponent extends BaseComponent implements OnInit {

  actionNew: ActionHandler;
  personsData: Person[];

  constructor(
    injector: Injector,
    public personsSandbox: PersonsSandbox
  ) {
    super(injector);
  }

  ngOnInit() {
    this.titlePage = 'Page manager persons';
    this.setTitle(this.titlePage);
    this.loadPersonDatas();
    this.initActionNew();
  }

  private initActionNew() {
    this.actionNew = new ActionHandler();
    this.actionNew.isVisible = true;
    this.actionNew.roles = [this.permissions.mayInsert];
  }

  private loadPersonDatas() {
    this.personsSandbox.persons$.subscribe(persons => {
      this.personsData = persons;
    });
  }

  onNewClick() {
    console.warn('Implement new');
  }

  public onSelect(data: Person): void {
    console.warn('implement select');
  }
}
