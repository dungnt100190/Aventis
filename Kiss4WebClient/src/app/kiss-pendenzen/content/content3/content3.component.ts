import { Component } from '@angular/core';

@Component({
  selector: 'kiss-pendenzen-content3',
  templateUrl: './content3.component.html',
  styleUrls: [
    './content3.component.css',
    '../../../app.component.css',
    '../content.component.css',
  ]
})
export class Content3Component {
  withTitleVisible: boolean;
  constructor() {
    this.withTitleVisible = false;
  }

  toggleWithTitle() {
    this.withTitleVisible = !this.withTitleVisible;
  }

}
