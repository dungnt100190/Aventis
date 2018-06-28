import { Injectable } from '@angular/core';
import { TranslateService } from 'ng2-translate';
import { NotificationsService } from 'angular2-notifications';
import { ConfigService } from '../../app-config.service';
import { Observable } from 'rxjs/rx';

@Injectable()
export class UtilService {

  constructor(
    private translateService: TranslateService,
    private notificationService: NotificationsService,
    private configService: ConfigService
  ) { }

  /**
   * Translates given message code and title code and displays corresponding notification
   *
   * @param messageTranslationCode
   * @param type
   * @param titleTranslationCode
   */
  public displayNotification(messageTranslationCode: string, type: string = 'info', titleTranslationCode?: string) {
    const message: string = this.translateService.instant(messageTranslationCode);
    let title: string = titleTranslationCode ? this.translateService.instant(titleTranslationCode) : null;

    switch (type) {
      case 'error':
        title = this.translateService.instant('ErrorNotificationTitle');
        break;

      case 'success':
        title = this.translateService.instant('SuccessNotificationTitle');
        break;

      case 'alert':
        title = this.translateService.instant('WarningNotificationTitle');
        break;

      default:
        title = this.translateService.instant('InfoNotificationTitle');
        break;
    }

    this.notificationService[type](title, message, this.configService.get('notifications').options);
  }

  /**
   * Translates lookup names by looking into lookup code
   *
   * @param data
   */
  public translateLookupData(data: Array<any>): Array<any> {
    // Translate quantity stock adjustment reasons
    return data.map(lookup => {
      lookup.name = lookup.code ? this.translateService.instant('Lookups')[lookup.code] : lookup.name;
      return lookup;
    });
  }

   /**
   * Get Browserlang from translate service
   */
  public getBrowserLang() {
    return this.translateService.getBrowserLang();
  }

  /**
   * Get BrowserCultureLang from translate service
   */
  public getBrowserCultureLang() {
    return this.translateService.getBrowserCultureLang();
  }

  /**
   * add lang to translate
   * @param langs
   */
  public addLangs(langs: string[]): void {
    this.translateService.addLangs(langs);
  }

  /**
   * Set lang translate default
   * @param lang
   */
  public setDefaultLang(lang: string): void {
    this.translateService.setDefaultLang(lang);
  }

  public getConfig(key: string): any {
    return this.configService.get(key);
  }
}
