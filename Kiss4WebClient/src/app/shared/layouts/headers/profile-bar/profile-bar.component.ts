import { Component, Output, EventEmitter, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'profile-bar',
  templateUrl: `./profile-bar.component.html`,
  styleUrls: ['./profile-bar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileBarComponent {

  @Input() userImage: string;
  @Input() userEmail: string;
  @Output() logout: EventEmitter<any> = new EventEmitter();

  constructor() { }
}
