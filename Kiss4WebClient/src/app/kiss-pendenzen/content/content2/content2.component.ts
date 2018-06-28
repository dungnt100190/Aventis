import { Component } from '@angular/core';
import { PenService, Order } from '../../pen.service';

@Component({
  selector: 'kiss-pendenzen-content2',
  templateUrl: './content2.component.html',
  styleUrls: [
    './content2.component.css',
    '../../../app.component.css',
    '../content.component.css'
  ],
  providers: [PenService],
})
export class Content2Component {
  orders: Order[];
  showFilterRow: boolean;
  showHeaderFilter: boolean;
  allMode: string;
  checkBoxesMode: string;
  currentFilter: any;
  orderHeaderFilter: any;
  calculateFilterExpression: any;
  saleAmountHeaderFilter: any;

  constructor(service: PenService) {
    this.orders = service.getOrders();
    this.showFilterRow = true;
    this.showHeaderFilter = true;
    this.allMode = 'allPages';
    this.checkBoxesMode = 'onClick'
  }
}
