import { environment } from './../../../../environments/environment.prod';
import {
  Component,
  Output,
  Input,
  EventEmitter,
  ChangeDetectionStrategy,
  Renderer2,
  ElementRef
} from '@angular/core';
import { browserFunction } from '../../utility';

@Component({
  selector: 'app-header',
  templateUrl: `./header.component.html`,
  styleUrls: ['./header.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderComponent {
  homePage: string;
  @Input() selectedLanguage: any;
  @Input() availableLanguages: Array<any>;
  @Input() userImage: string;
  @Input() userEmail: string;

  @Output() selectLanguage: EventEmitter<any> = new EventEmitter();
  @Output() logout: EventEmitter<any> = new EventEmitter();
  @Output() clickToggleNav: EventEmitter<any> = new EventEmitter();

  // menu components
  @Input() itemMenus: Array<any>;
  @Output() selectMenu: EventEmitter<any> = new EventEmitter();

  // search box
  @Input() searchBoxsData: Array<any>;

  isToggleNav: Boolean = false;

  constructor(
    private renderer: Renderer2
  ) {
    this.homePage = environment.page.dossier;
  }

  public onToggleNav(isToggleNav, event) {
    this.isToggleNav = !isToggleNav;
    const el = browserFunction.getToggleSelector(event);
    this.handlerToggleNav(el);
  }

  private handlerToggleNav(el: ElementRef): void {
    if (!el || this.isToggleNav === undefined) {
      return;
    }
    if (!this.isToggleNav) {
      this.renderer.removeClass(el, 'toggle--nav');
    } else {
      this.renderer.addClass(el, 'toggle--nav');
    }
  }
}
