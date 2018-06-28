import {
  Injector,
  OnInit,
  Component,
  ChangeDetectionStrategy,
  OnDestroy
} from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl
} from '@angular/forms';
import { AuthSandbox } from '../auth.sandbox';
import { BaseComponent } from '../../shared/components/base.component';
import { RequestOptions } from '@angular/http';
import { clearCache } from '../../shared/utility/utilityHelpers';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class LoginComponent extends BaseComponent implements OnInit, OnDestroy {

  public submitted: Boolean = false;
  public username: AbstractControl;
  public password: AbstractControl;

  public loginForm: FormGroup;
  copyRightName: number;

  constructor(
    injector: Injector,
    private fb: FormBuilder,
    public authSandbox: AuthSandbox,

  ) {
    super(injector);
  }

  ngOnInit() {
    this.setTitle('Login');
    this.initLoginForm();
    this.copyRightName = new Date().getFullYear();
    clearCache();
  }

  ngOnDestroy() {
    this.authSandbox.unregisterEvents();
  }

  /**
   * Builds a form instance (using FormBuilder) with corresponding validation rules 
   */
  public initLoginForm(): void {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.username = this.loginForm.controls['username'];
    this.password = this.loginForm.controls['password'];
  }

  /**
   * Handles form 'submit' event. Calls sandbox login function if form is valid.
   *
   * @param event
   * @param form
   */
  public onSubmit(event: Event, form: any): void {

    event.stopPropagation();
    this.submitted = true;

    const tokens = this.authSandbox.getConfigsToken();

    form.client_id = tokens.client_id;
    form.client_secret = tokens.client_secret;
    form.grant_type = tokens.grant_type;
    form.scope = tokens.scope;

    // tslint:disable-next-line:curly
    if (this.loginForm.valid) this.authSandbox.login(form);
  }
}
