// Angular core modules
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule, Title } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  NgModule,
  APP_INITIALIZER

} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

// Modules
import { HttpServiceModule } from './shared/asyncServices/http/http.module';
import { UtilityModule } from './shared/utility';

// Store
import { store } from './shared/store';
// Effects
import { MenusEffects } from './shared/store/effects/menus.effect';
import { SettingsEffects } from './shared/store/effects/settings.effect';
import { SearchBoxDatasEffects } from './shared/store/effects/search-box.effect';

// Services
import { ConfigService } from './app-config.service';
import { AppApiClient } from './appApiClient.service';
import { AppService } from './app.service';

// Third party libraries
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { TranslateModule } from 'ng2-translate';
import { SimpleNotificationsModule } from 'angular2-notifications';
//import { DxDataGridModule, DxSelectBoxModule, DxDateBoxModule, DxDropDownBoxModule, DxFormModule, DxTextAreaModule, DxButtonModule, DxPopoverModule, DxTabPanelModule, DxTreeViewModule, DxTemplateModule, DxBoxModule } from 'devextreme-angular';

// app
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { environment } from 'environments/environment.prod';
import { AppSandbox } from '@app/app.sandbox';
import { LayoutContainersModule } from '@app/shared/layouts/layout.module';

/**
 * Calling functions or calling new is not supported in metadata when using AoT.
 * The work-around is to introduce an exported function.
 *
 * The reason for this limitation is that the AoT compiler needs to generate the code that calls the factory
 * and there is no way to import a lambda from a module, you can only import an exported symbol.
 */

export function configServiceFactory(config: ConfigService) {
  return () => config.load();
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    // Angular core dependencies
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    // Third party modules
    TranslateModule.forRoot(),
    SimpleNotificationsModule.forRoot(),
    // App custom dependencies
    HttpServiceModule.forRoot(),
    UtilityModule.forRoot(),
    AppRoutingModule,
    LayoutContainersModule.forRoot(),
    /**
     * StoreModule.provideStore is imported once in the root module, accepting a reducer
     * function or object map of reducer functions. If passed an object of
     * store, combineReducers will be run creating your application
     * meta-reducer. This returns all providers for an @ngrx/store
     * based application.
     */
    StoreModule.provideStore(store),

    /**
     * Store devtools instrument the store retaining past versions of state
     * and recalculating new states. This enables powerful time-travel
     * debugging.
     *
     * To use the debugger, install the Redux Devtools extension for either
     * Chrome or Firefox
     *
     * See: https://github.com/zalmoxisus/redux-devtools-extension
     */
    environment.production ? [] : StoreDevtoolsModule.instrumentOnlyWithExtension(),

    /**
     * EffectsModule.run() sets up the effects class to be initialized
     * immediately when the application starts.
     *
     * See: https://github.com/ngrx/effects/blob/master/docs/api.md#run
     */

    EffectsModule.run(SettingsEffects),
    EffectsModule.run(MenusEffects),
    EffectsModule.run(SearchBoxDatasEffects),

    //DxButtonModule,
    //DxBoxModule,
    //DxDateBoxModule,
    //DxDataGridModule,
    //DxDropDownBoxModule,
    //DxFormModule,
    //DxPopoverModule,
    //DxSelectBoxModule,
    //DxTextAreaModule,
    //DxTabPanelModule,
    //DxTreeViewModule,
    //DxTemplateModule
  ],
  providers: [
    Title,
    ConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: configServiceFactory,
      deps: [ConfigService],
      multi: true
    },
    AppService,
    AppApiClient,
    AppSandbox
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
