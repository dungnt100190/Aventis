import {
  Component,
  ChangeDetectorRef,
  ChangeDetectionStrategy,
  Input,
  Renderer2,
  ElementRef,
  AfterViewInit
} from '@angular/core';
import { TranslateService } from 'ng2-translate';

@Component({
  selector: 'app-left-sidebar',
  templateUrl: './left-sidebars.component.html',
  styleUrls: ['./left-sidebars.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LeftSidebarComponent implements AfterViewInit {

  @Input() isNavbar: boolean;

  constructor(
    private renderer: Renderer2) {
  }

  ngAfterViewInit(): void {
    /**
     * Detaches the change detector from the change detector tree.
     */
    if (!this.isNavbar) {
      const wrapperContainer = document.querySelectorAll('.wrapper-main').item(0);
      this.setEfToggleNav(wrapperContainer);
    }
  }

  /**
  * Detaches the change detector from the change detector tree.
  */
  toggleNavigator(isNavbar: boolean, el: any): void {
    this.isNavbar = !isNavbar;
    localStorage.setItem('settings:toogleNavbar', JSON.stringify(this.isNavbar));
    const path = el.path;
    let elWrapper: ElementRef;
    if (path !== undefined) {
      // for chorme
      elWrapper = path.find(item => item.classList.contains('wrapper-main'));
    } else {
      // fix for firefox
      const offsetParent = this.renderer.parentNode(el.target.offsetParent);
      elWrapper = this.getParentNodeWithLevel(offsetParent, 3);
    }
    this.setEfToggleNav(elWrapper);
  }

  private getParentNodeWithLevel(element, level: number = 1) {
    if (level === 1) { return this.renderer.parentNode(element); }
    const offsetParent = this.renderer.parentNode(element);
    level = level - 1;
    // n case
    return this.getParentNodeWithLevel(offsetParent, level);
  }

  private setEfToggleNav(el: any): void {
    if (el && this.isNavbar !== undefined) {
      if (this.isNavbar) {
        this.renderer.removeClass(el, 'toggle--sidebar');
      } else {
        this.renderer.addClass(el, 'toggle--sidebar');
      }
    }
  }
}
