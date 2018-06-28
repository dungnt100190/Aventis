export class LoginForm {
  public client_id: any;
  public client_secret: any;
  public grant_type: any;
  public scope: any;
  public username: string;
  public password: string;

  constructor(loginForm: any) {
    this.client_id = loginForm.client_id || null;
    this.client_secret = loginForm.client_secret || null;
    this.grant_type = loginForm.grant_type || null;
    this.scope = loginForm.scope || null;
    this.username = loginForm.username || '';
    this.password = loginForm.password || '';
  }
}