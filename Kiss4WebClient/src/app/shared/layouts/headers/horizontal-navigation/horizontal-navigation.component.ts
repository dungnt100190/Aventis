import {
  Component,
  Output,
  Input,
  EventEmitter,
  ChangeDetectionStrategy
} from '@angular/core';

@Component({
  selector: 'kiss-menu-header',
  templateUrl: `./horizontal-navigation.component.html`,
  styleUrls: ['./horizontal-navigation.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HorizontalNavigationComponent {
  @Input() itemMenus: Array<any>;
  @Output() select: EventEmitter<any> = new EventEmitter();

  public selectMenu(e) {
    this.select.emit(e);
  }
}
