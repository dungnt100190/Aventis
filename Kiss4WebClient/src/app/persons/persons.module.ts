import { EffectsModule } from '@ngrx/effects';
import { DevExtremeModule } from 'devextreme-angular';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from 'ng2-translate';
import {
  ReactiveFormsModule,
} from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PersonsRoutingModule } from './persons-routing.module';
import { PersonsSandbox } from './persons.sandbox';
import { PersonsApiClient } from './personsApiClient.service';
import { PersonsService } from './persons.service';
import { PersonsResolver } from './persons.resolver';

/**
 * Persons Modules
 */
import { ComponentsModule } from '../shared/components';
import { LayoutContainersModule } from '../shared/layouts/layout.module';
import { PersonFormComponent } from './person-form/person-form.component';
import { PersonListComponent } from './person-list/person-list.component';
import { PersonsComponent } from './person/person.component';
import { PersonsEffects } from '@app/shared/store/effects/persons.effect';

@NgModule({
  imports: [
    CommonModule,
    ComponentsModule,
    LayoutContainersModule,
    DevExtremeModule,
    TranslateModule,
    ReactiveFormsModule,
    RouterModule,
    PersonsRoutingModule,
    EffectsModule.run(PersonsEffects),
  ],
  declarations: [
    PersonsComponent,
    PersonFormComponent,
    PersonListComponent
  ],
  providers: [
    PersonsSandbox,
    PersonsService,
    PersonsApiClient,
    PersonsResolver
  ],
})
export class PersonsModule { }
