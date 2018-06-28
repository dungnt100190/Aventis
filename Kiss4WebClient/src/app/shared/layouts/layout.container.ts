import { User } from './../models/auth/user.model';
import {
  Component,
  Input,
  ViewChild,
  ElementRef,
  OnInit,
  OnDestroy
  // tslint:disable-next-line:import-spacing
} from '@angular/core';
// tslint:disable-next-line:import-spacing
import { Observable } from 'rxjs/Observable';
// tslint:disable-next-line:import-spacing
import { Subscription } from 'rxjs/rx';
// tslint:disable-next-line:import-spacing
import { LayoutSandbox } from './layout.sandbox';
// tslint:disable-next-line:import-spacing
// tslint:disable-next-line:import-spacing
import { ConfigService } from '../../app-config.service';
import { AppSandbox } from '@app/app.sandbox';

@Component({
  selector: 'app-layout',
  templateUrl: `./layout.container.html`
})

// tslint:disable-next-line:component-class-suffix
export class LayoutContainer implements OnInit, OnDestroy {

  public userImage: String = '';
  public userEmail: String = '';
  private assetsFolder: String;
  @Input() isNavbar: boolean;

  @ViewChild('wrapperContainer', { read: ElementRef }) mainWrapperContainer: ElementRef;

  private subscriptions: Array<Subscription> = [];

  constructor(
    private configService: ConfigService,
    public layoutSandbox: LayoutSandbox,
    public appSandbox: AppSandbox
  ) {
    this.assetsFolder = this.configService.get('paths').userImageFolder;
  }

  ngOnInit() {
    this.registerEvents();
    this.appSandbox.setupRoles();
  }

  ngOnDestroy() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

  private registerEvents() {
    // Subscribes to user changes
    this.subscriptions.push(this.layoutSandbox.loggedUser$.subscribe((user: User) => {
      if (user.isLoggedIn) {
        this.userImage = this.assetsFolder + 'user.jpg';
        this.userEmail = localStorage.getItem('user');
      }
    }));
  }

  selectMenu(menu): void {
    // tslint:disable-next-line:curly
    if (!menu || menu.url === '' || menu.url === undefined) return;
    this.layoutSandbox.selectMenu(menu);
  }
}
