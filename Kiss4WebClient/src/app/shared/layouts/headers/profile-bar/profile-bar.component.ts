import { Component, Output, EventEmitter, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'profile-bar',
  templateUrl: `./profile-bar.component.html`,
  styleUrls: ['./profile-bar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileBarComponent {

  isLogout = false;
  @Input() userImage = '';
  @Input() userEmail = '';
  @Output() logout: EventEmitter<any> = new EventEmitter();

  constructor() { }

  toggleLogout() {
    this.isLogout = !this.isLogout;
  }
}
