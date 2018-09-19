import { Component, OnInit, Injector } from '@angular/core';
import { PendenzenSandbox } from '@app/kiss-pendenzen/pendenzen.sandbox';
import { BaseComponent } from '@app/shared/components/base.component';
import { NavBarItems } from '@app/shared/models/pendenzen/navBarItems.model';
import { NavBarItem, PendenzenService, NavBarLoad, TaskLoad } from '@app/kiss-pendenzen/pendenzen.service';

@Component({
  selector: 'kiss-pendenzen-left-nav',
  templateUrl: './left-nav.component.html',
  styleUrls: [
    './left-nav.component.css',
    '../../app.component.css'
  ]
})
export class LeftNavComponent extends BaseComponent implements OnInit {

  parentItems: any[];
  isOpen: boolean;
  navBarItems: NavBarItems;
  taskInfo: TaskLoad;
  selectedItemText: string;
  selectedItem: NavBarItem;
  navBarLoad: NavBarLoad;
  isDisabled: Boolean;
  isRefreshNavBarItems: Boolean = true;
  constructor(injector: Injector, private pendenzenSandbox: PendenzenSandbox, private service: PendenzenService) {
    super(injector);
  }
  ngOnInit(): void {
    this.navBarLoad = new NavBarLoad();
    this.subscribeInit();
    this.refreshNavBarItems();
    this.service.listenProcessTask().subscribe((m: any) => {
      if (m !== undefined) {
        this.taskInfo = m;
        this.refreshNavBarItems();
        this.isRefreshNavBarItems = false;
      }
    });
    this.service.listenIsAddAndEdit().subscribe((item: any ) => {
      this.isDisabled = item.isAddOrEdit || false;
    });
  }

  public subscribeInit()
  {
    this.pendenzenSandbox.navbarItems$.subscribe(data => {
      if (data) {
        this.navBarItems = new NavBarItems(data);
        this.parentItems = [
          {
            //id: "1",
            html: "<span style='font-size:18px; font-weight: 500; color: #39474f;'>Meine Pendenzen</span>",
            expanded: true,
            items: [{
              id: "SC001_left-menu_meine-pendenzen_fallige",
              text: "fällige (" + this.navBarItems.itmMeineFaellig + ")",
            },
            {
              id: "1_2",
              text: "offene (" + this.navBarItems.itmMeineOffen + ")",
            },
            {
              id: "1_3",
              text: "in Bearbeitung (" + this.navBarItems.itmMeineInBearbeitung + ")",
            },
            {
              id: "1_4",
              text: "selber erstellte (" + this.navBarItems.itmMeineErstellt + ")",
            },
            {
              id: "1_5",
              text: "erhaltene (" + this.navBarItems.itmMeineErhalten + ")",
            },
            {
              id: "1_6",
              text: "zu visierende (" + this.navBarItems.itmMeineZuVisieren + ")",
            },
            {
              id: "1_7",
              text: "an die Gruppe",
            },
            {
              id: "1_8",
              text: "erledigte",
            }]
          },
          {
            //id: "2",
            html: "<span style='font-size:18px; font-weight: 500; color: #39474f;'>Erstellte Pendenzen</span>",
            expanded: true,
            items: [{
              id: "2_1",
              text: "fällige (" + this.navBarItems.itmVersandteFaellig + ")",
            },
            {
              id: "2_2",
              text: "offene (" + this.navBarItems.itmVersandteOffen + ")",
            },
            {
              id: "2_3",
              text: "allgemeine (" + this.navBarItems.itmVersandteAllgemein + ")",
            },
            {
              id: "2_4",
              text: "zu visierende (" + this.navBarItems.itmVersandteZuVisieren + ")",
            },
            {
              id: "2_5",
              text: "an die Gruppe",
            },
            {
              id: "2_6",
              text: "erledigte",
            }]
          },
          {
            //id: "3",
            html: "<span style='font-size:18px; font-weight: 500; color: #39474f;'>Suchen</span>",
            expanded: true,
            items: [{
              id: "3_1",
              text: "Pendenzen suchen (0)",
            }]
          }
        ];
        if (this.taskInfo != undefined && this.taskInfo != null) {
          this.parentItems.forEach(element => {
            element.items.forEach(element => {
              if (element.id == this.taskInfo.navbarItem) {
                element.selected = true;
                this.selectedItem = element;
                this.navBarLoad.id = element.id;
                // this.changeNavBarItem();
              }
            });
          });
        } else {
          this.parentItems.forEach(element => {
            element.items.forEach(element => {
              if (element.id == "1_2") {
                element.selected = true;
                this.selectedItem = element;
                this.navBarLoad.id = element.id;
              }
            });
          });
        }
        this.changeNavBarItem();
      }
    });

  }

  public refreshNavBarItems() {
    this.pendenzenSandbox.LoadNavBarItems();
  }

  clickTreeView(e) {
    if (e.itemData.id !== undefined) {
      this.selectedItem = e.itemData;
      this.navBarLoad.id = e.itemData.id;
      // this.taskInfo.navbarItem = e.itemData.id;
      this.changeNavBarItem();
      this.service.actionChangeNavBarItem({isChangeNavBarItem: true, isEdit: false, isProcessingStatus: false})
    }
  }

  changeNavBarItem() {
    this.service.changeNavbarItem(this.selectedItem.text);
    this.service.actionNavbarItem(this.navBarLoad);
  }

  openNav() {
    if (this.isOpen) {
      document.getElementById('left-nav').style.width = '250px';
      document.getElementById('content').style.marginLeft = '250px';
      document.getElementById('left-nav-body').style.display = 'contents';
      document.getElementById('left-nav-header-title').style.display = 'contents';
      this.isOpen = !this.isOpen;
    } else {
      document.getElementById('left-nav').style.width = '64px';
      document.getElementById('content').style.marginLeft = '64px';
      document.getElementById('left-nav-body').style.display = 'none';
      document.getElementById('left-nav-header-title').style.display = 'none';
      this.isOpen = !this.isOpen;
    }
  }
}
