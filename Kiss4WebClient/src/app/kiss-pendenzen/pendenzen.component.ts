import { Component, OnInit, Inject, Injectable, Injector } from "@angular/core";
import { BaseComponent } from "@app/shared/components/base.component";

@Component({
  selector: 'kiss-pendenzen',
  templateUrl: './pendenzen.component.html',
  styleUrls: ['./pendenzen.component.css']
})
export class PendenzenComponent extends BaseComponent implements OnInit {

  constructor(
    injector: Injector,
  ) {
    super(injector)
  }

  ngOnInit(): void {
    this.setTitle("Pendenzenwaltung")
  }
}
