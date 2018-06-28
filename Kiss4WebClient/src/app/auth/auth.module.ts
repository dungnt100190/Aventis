import { EffectsModule } from '@ngrx/effects';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { ComponentsModule } from '../shared/components';
import { TranslateModule } from 'ng2-translate';
import { SimpleNotificationsModule } from 'angular2-notifications';
import { AuthSandbox } from './auth.sandbox';
import { AuthApiClient } from './authApiClient.service';
import { AuthEffects } from '@app/shared/store/effects/auth.effect';

@NgModule({
  imports: [
    CommonModule,
    ComponentsModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule,
    SimpleNotificationsModule,
    AuthRoutingModule,
    EffectsModule.run(AuthEffects),
  ],
  declarations: [
    LoginComponent
  ],
  providers: [
    AuthApiClient,
    AuthSandbox
  ]
})
export class AuthModule { }
