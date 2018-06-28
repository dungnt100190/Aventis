import { Component, ChangeDetectionStrategy } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'page-not-found',
  templateUrl: `./pageNotFound.component.html`,
  styleUrls: ['./pageNotFound.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PageNotFoundComponent {
	constructor(private location: Location) {}

  public goBack() {
    this.location.back();
  }
}