import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { PersonsSandbox } from './../persons.sandbox';
import { Person } from './../../shared/models/person.model';
import {
  Component,
  ChangeDetectionStrategy,
  ViewChild,
  Injector,
  OnInit,
} from '@angular/core';

import { DxFormComponent } from 'devextreme-angular';
import { BaseComponent } from '../../shared/components/base.component';
import { ActionHandler } from '../../shared/models';
import { SetClassRight } from '../../shared/authorize/authorize.decorators';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
@SetClassRight('CtlPerson')
export class PersonFormComponent extends BaseComponent implements OnInit {

  formData: Person;
  actionCancel: ActionHandler = new ActionHandler();
  actionSave: ActionHandler = new ActionHandler();
  actionDelete: ActionHandler = new ActionHandler();

  @ViewChild('personForm')
  public personForm: DxFormComponent;

  colCountByScreen: Object = {
    xs: 1,
    sm: 3,
    md: 3,
    lg: 3
  };

  constructor(
    injector: Injector,
    public personsSandbox: PersonsSandbox,
    private location: Location,
  ) {
    super(injector);
  }

  ngOnInit() {
    this.setActionButtons();
    this.loadPersonDetail();
  }

  private setActionButtons() {
    this.actionCancel.isVisible = true;
    this.actionCancel.roles = [this.permissions.mayInsert, this.permissions.mayUpdate, this.permissions.mayDelete];

    this.actionSave = new ActionHandler();
    this.actionSave.isVisible = true;
    this.actionSave.roles = [this.permissions.mayInsert, this.permissions.mayUpdate];

    this.actionDelete = new ActionHandler();
    this.actionDelete.isVisible = false;
    if (!this.formData) { return; }
    if (this.formData.id > 0) {
      this.actionDelete.isVisible = true;
      this.actionDelete.roles = [this.permissions.mayDelete];
    }
  }

  private loadPersonDetail() {
    this.personsSandbox.personDetails$.subscribe(person => {
      if (!person) { return; }
      this.formData = person;
      this.titlePage = `Detail ${person.name}`;
      this.setTitle(this.titlePage);
    });
  }

  public getSizeScreen(width) {
    if (width < 768) { return 'xs'; }
    if (width < 992) { return 'sm'; }
    if (width < 1200) { return 'md'; }
    return 'lg';
  }

  goBack() {
    this.location.back();
  }
}
