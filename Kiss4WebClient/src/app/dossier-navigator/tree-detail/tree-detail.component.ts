import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { DossierSandbox } from './../dossier.sandbox';
import { DxFormComponent } from 'devextreme-angular';
import { Component, OnInit, Input, ViewChild, Injector } from '@angular/core';
import {
  DossierNavigatorTreeModel as TreeModel
} from '../../shared/models';
import { BaseComponent } from '../../shared/components/base.component';

@Component({
  selector: 'app-tree-detail',
  templateUrl: './tree-detail.component.html',
  styleUrls: ['./tree-detail.component.scss']
})

export class TreeDetailComponent extends BaseComponent implements OnInit {

  formData: TreeModel;
  @ViewChild('treeForm')
  public treeForm: DxFormComponent;

  colCountByScreen: Object = {
    xs: 1,
    sm: 3,
    md: 3,
    lg: 3
  };

  constructor(
    injector: Injector,
    public dossierSandbox: DossierSandbox,
    private router: Router,
    private location: Location) {
    super(injector);
  }

  ngOnInit(): void {
    this.loadDetail();
  }

  private loadDetail(): void {
    this.dossierSandbox.dossierDetail$.subscribe((dossier: any) => {
      if (dossier) {
        this.formData = dossier;
        this.titlePage = `Detail ${dossier.name}`;
        this.setTitle(this.titlePage);
      }
    });
  }

  getSizeScreen(width) {
    if (width < 768) { return 'xs'; }
    if (width < 992) { return 'sm'; }
    if (width < 1200) { return 'md'; }
    return 'lg';
  }

  goBack(): void {
    this.location.back();
  }
}
