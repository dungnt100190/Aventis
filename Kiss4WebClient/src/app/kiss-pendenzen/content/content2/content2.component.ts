import { Component, OnInit, Injector } from '@angular/core';
import { PendenzenSandbox } from '@app/kiss-pendenzen/pendenzen.sandbox';
import { BaseComponent } from '@app/shared/components/base.component';
import { Pendenzen } from '@app/shared/models/pendenzen/pendenzen.model';

@Component({
  selector: 'kiss-pendenzen-content2',
  templateUrl: './content2.component.html',
  styleUrls: [
    './content2.component.css',
    '../../../app.component.css',
    '../content.component.css'
  ],
})
export class Content2Component extends BaseComponent implements OnInit {
  showFilterRow: boolean;
  showHeaderFilter: boolean;
  allMode: string;
  checkBoxesMode: string;
  currentFilter: any;
  orderHeaderFilter: any;
  calculateFilterExpression: any;
  saleAmountHeaderFilter: any;

  pendenzenData: Pendenzen[];

  constructor(
    injector: Injector,
    public pendenzenSandbox: PendenzenSandbox
  ) {
    super(injector);
  }

  ngOnInit() {
    this.showFilterRow = true;
    this.showHeaderFilter = true;
    this.allMode = 'allPages';
    this.checkBoxesMode = 'onClick';
    this.pendenzenSandbox.loadListPendenzen();
    this.loadPendenzenData();
  }

  private loadPendenzenData() {
    this.pendenzenSandbox.pendenzenData$.subscribe(data => {
      if (data) {
        console.log(data);
        this.pendenzenData = data;
      }
    });
  }
}
