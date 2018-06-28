import { Component } from '@angular/core';

@Component({
  selector: 'kiss-pendenzen-content',
  templateUrl: './content.component.html',
  styleUrls: [
    './content.component.css',
    '../../app.component.css'
  ]
})
export class ContentComponent {
  withTitleVisible: boolean;
  constructor() {
    this.withTitleVisible = false;
  }

  toggleWithTitle() {
    this.withTitleVisible = !this.withTitleVisible;
  }

}
