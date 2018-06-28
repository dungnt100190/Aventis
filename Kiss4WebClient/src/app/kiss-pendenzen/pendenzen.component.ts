import { Component, OnInit, Inject, Injectable, Injector } from "@angular/core";
import { BaseComponent } from "@app/shared/components/base.component";
import { PendenzenSandbox } from "@app/kiss-pendenzen/pendenzen.sandbox";

@Component({
  selector: 'kiss-pendenzen',
  templateUrl: './pendenzen.component.html',
  styleUrls: ['./pendenzen.component.css']
})
export class PendenzenComponent extends BaseComponent implements OnInit {
  constructor(
    injector: Injector,
    public pendenzenSandbox: PendenzenSandbox
  ) {
    super(injector)
  }
  ngOnInit(): void {
    this.pendenzenSandbox.loadListPendenzen();

  }

  onBtnClick(e) {
    this.pendenzenSandbox.btnClickEvent();

  }
}
