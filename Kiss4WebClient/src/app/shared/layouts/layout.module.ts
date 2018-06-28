import { RouterModule } from '@angular/router';
import {
  NgModule
} from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComponentsModule } from '../components';
import { LayoutContainer } from './layout.container';
import { LayoutSandbox } from './layout.sandbox';
import { TranslateModule } from 'ng2-translate';

import {
  DevExtremeModule
} from 'devextreme-angular';

import { HeaderComponent } from './headers/header.component';
import { HorizontalNavigationComponent } from './headers/horizontal-navigation/horizontal-navigation.component';
import { SearchBoxComponent } from './headers/search-box/search-box.component';
import { ProfileBarComponent } from './headers/profile-bar/profile-bar.component';
import { LanguageSelectorComponent } from './headers/languages/languageSelector.component';
import { NotificationBoxComponent } from './headers/notification-box/notification-box.component';
import { SelectedActionsComponent } from './left-sidebars/selected-actions/selected-actions.component';
import { BreadCrumbComponent } from './contents/bread-crumb/bread-crumb.component';
import { LeftSidebarComponent } from './left-sidebars/left-sidebars.component';
import { DossierDetailsComponent } from './left-sidebars/dossier-details/dossier-details.component';
import { PageContentComponent } from './contents/page-content/page.content.component';
import { ToolbarsComponent } from './contents/toolbars/toolbars.component';
import { AuthorizeModule } from '@app/shared/authorize/authorize.module';

export const CONTAINERS = [
  LayoutContainer,
  HeaderComponent,
  PageContentComponent,
  ToolbarsComponent,
  HorizontalNavigationComponent,
  SearchBoxComponent,
  ProfileBarComponent,
  LanguageSelectorComponent,
  NotificationBoxComponent,
  SelectedActionsComponent,
  BreadCrumbComponent,
  LeftSidebarComponent,
  DossierDetailsComponent
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ComponentsModule,
    DevExtremeModule,
    TranslateModule,
    AuthorizeModule.forFeature()
  ],
  declarations: [CONTAINERS],
  exports: [CONTAINERS],
  providers: [LayoutSandbox]
})

export class LayoutContainersModule { }
