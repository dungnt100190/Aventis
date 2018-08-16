import { Component, OnInit } from '@angular/core';
import { PendenzenService ,gridSetting} from '@app/kiss-pendenzen/pendenzen.service';

@Component({
  selector: 'kiss-pendenzen-content',
  templateUrl: './content.component.html',
  styleUrls: [
    './content.component.css',
    '../../app.component.css'
  ]
})
export class ContentComponent implements OnInit {
  popover1Visible: boolean;
  selectedItem: string;
  gridSetting : gridSetting;

  validationSummary: any;

  constructor(private service: PendenzenService) {
  }

  ngOnInit(): void {
    this.service.currentNavbarItem.subscribe(itemText => this.selectedItem = itemText);
    this.gridSetting = new gridSetting();
    this.gridSetting.value = false;
    this.popover1Visible = false;
    this.receiveValidationSummary();
    this.closeErrorMessageArea();
  }

  togglePopover1() {
    this.popover1Visible = !this.popover1Visible;
  }

  exportedExcel()
  {
    this.gridSetting.key = "exportExcel";
    this.gridSetting.value = false;
    this.service.actionExportedExcel(this.gridSetting);
  }

  columnChooser()
  {
    this.gridSetting.key = "showcustomizationwindow";
    this.gridSetting.value = false;
    this.service.actionExportedExcel(this.gridSetting);
  }

  grouping()
  {
    // this.gridSetting.key = "grouping";
    // this.gridSetting.value = !this.gridSetting.value;
    // this.service.actionExportedExcel(this.gridSetting);
  }

  groupingPanel()
  {
    // this.gridSetting.key = "groupingPanel";
    // this.gridSetting.value = !this.gridSetting.value;
    // this.service.actionExportedExcel(this.gridSetting);
  }

  headerFillter()
  {
    // this.gridSetting.key = "headerFillter";
    // this.gridSetting.value = !this.gridSetting.value;
    // this.service.actionExportedExcel(this.gridSetting);
  }

  fillterRow()
  {
    // this.gridSetting.key = "fillterRow";
    // this.gridSetting.value = !this.gridSetting.value;
    // this.service.actionExportedExcel(this.gridSetting);
  }

  search()
  {
    // this.gridSetting.key = "search";
    // this.gridSetting.value = !this.gridSetting.value;
    // this.service.actionExportedExcel(this.gridSetting);
  }

  closeErrorMessageArea() {
    document.getElementById('error-container').style.display = 'none';
  }

  showErrorMessageArea() {
    document.getElementById('error-container').style.display = 'block';
  }

  receiveValidationSummary() {
    this.validationSummary = [];
    this.service.listenValidationSummary().subscribe(data =>{
      this.validationSummary = data.validationSummary;
      if(this.validationSummary.length > 0)
        this.showErrorMessageArea();
      if(this.validationSummary.length === 0)
        this.closeErrorMessageArea();
    })
  }
}
