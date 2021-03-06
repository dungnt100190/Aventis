import { Injectable } from '@angular/core';
import { Sandbox } from './shared/sandbox/base.sandbox';
import { Store } from '@ngrx/store';
import * as store from './shared/store';
import * as settingsActions from './shared/store/actions/settings.action';
import { TranslateService } from 'ng2-translate';
import { ConfigService } from './app-config.service';

@Injectable()
export class AppSandbox extends Sandbox {
  public xDocument$ = this.appState$.select(store.getXDocumentCreate);
  constructor(
    protected appState$: Store<store.State>,
    private translate: TranslateService,
    private configService: ConfigService
  ) {
    super(appState$);
  }

  /**
   * Sets up default language for the application. Uses browser default language.
   */
  public setupLanguage(): void {
    const localization: any = this.configService.get('localization');
    const languages: Array<string> = localization.languages.map(lang => lang.code);
    const browserLang: string = this.translate.getBrowserLang();

    this.translate.addLangs(languages);
    this.translate.setDefaultLang(localization.defaultLanguage);

    // const selectedLang = browserLang.match(/en|de|fr|it/) ? browserLang : localization.defaultLanguage;
    const selectedLang = localization.defaultLanguage;
    const selectedCulture = localization.languages.filter(lang => lang.code === selectedLang)[0].culture;

    this.translate.use(selectedLang);
    this.appState$.dispatch(new settingsActions.SetLanguageAction(selectedLang));
    this.appState$.dispatch(new settingsActions.SetCultureAction(selectedCulture));
  }

  public setupRoles(): void {
    this.availableRoles$.subscribe((roles: any[]) => {
      if (roles.length === 0) {
        this.appState$.dispatch(new settingsActions.LoadApiRolesAction());
      }
    });
  }

  public postDocumentCreate(payload: any) {
    this.appState$.dispatch(new settingsActions.DocumentCreate(payload));
  }

  /**
   * Returns global notification options
   */
  public getNotificationOptions(): any {
    return this.configService.get('notifications').options;
  }
}
