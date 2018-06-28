import { ActivatedRoute } from '@angular/router';
import { Component, ChangeDetectionStrategy, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'page-gate-way',
  templateUrl: `./pageBadGateway.component.html`,
  styleUrls: ['./pageBadGateway.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PageBadGatewayComponent implements OnInit {
  constructor(private location: Location,
  private route: ActivatedRoute) {}

  messager: any;

  ngOnInit() {
    this.messager = this.route.snapshot.paramMap.get('roles');
    console.log(this.messager);
  }

  public goBack() {
    this.location.back();
  }
}