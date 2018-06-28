export class User {
  public access_token?: string;
  public expires_in?: any;
  public isLoggedIn?: boolean;
  public token_type?: string;

  constructor(user?: any) {
    this.access_token = user ? user.access_token : '';
    this.isLoggedIn = this.access_token ? true : false;
    this.token_type = user ? user.token_type : '';
    this.expires_in = user ? user.expires_in : null;
  }

  /**
   * Saves user into local storage
   *
   * @param user
   */
  public save(): void {
    localStorage.setItem('currentUser', JSON.stringify(this));
    localStorage.setItem('token', this.access_token);
  }

  /**
   * Saves user into local storage
   */
  public remove(): void {
    localStorage.setItem('currentUser', JSON.stringify(new User()));
    localStorage.setItem('token', null);
    localStorage.setItem('user', null);
  }
}
