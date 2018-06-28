import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'kiss-pendenzen-left-nav',
  templateUrl: './left-nav.component.html',
  styleUrls: [
    './left-nav.component.css',
    '../../app.component.css'
  ]
})
export class LeftNavComponent {
  parentItems: any;
  isOpen: boolean;

  changeSelection(e) {
    console.log(e)
  }

  constructor() {
    this.parentItems = [
      {
        id: "1",
        html: "<span style='font-size:18px; font-weight: 500; color: #39474f;'>Meine Pendenzen</span>",
        expanded: true,
        items: [{
          id: "1_1",
          text: "fällige (0)",
        },
        {
          id: "1_2",
          text: "offene (0)",
        },
        {
          id: "1_3",
          text: "in Bearbeitung (0)",
        },
        {
          id: "1_4",
          text: "selber erstellte (0)",
        },
        {
          id: "1_5",
          text: "erhaltene (0)",
        },
        {
          id: "1_6",
          text: "zu visierende (0)",
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
        id: "2",
        html: "<span style='font-size:18px; font-weight: 500; color: #39474f;'>Erstellte Pendenzen</span>",
        expanded: true,
        items: [{
          id: "2_1",
          text: "fällige (0)",
        },
        {
          id: "2_2",
          text: "offene (0)",
        },
        {
          id: "2_3",
          text: "allgemeine (0)",
        },
        {
          id: "2_4",
          text: "zu visierende (0)",
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
        id: "3",
        html: "<span style='font-size:18px; font-weight: 500; color: #39474f;'>Suchen</span>",
        expanded: true,
        items: [{
          id: "3_1",
          text: "Pendenzen suchen (0)",
        }]
      }
    ];
  }

  openNav() {
    if(this.isOpen) {
      document.getElementById("left-nav").style.width = "250px";
      document.getElementById("content").style.marginLeft = "250px";
      document.getElementById("left-nav-body").style.display = "contents";
      document.getElementById("left-nav-header-title").style.display = "contents";
      this.isOpen = !this.isOpen;
    } else {
      document.getElementById("left-nav").style.width = "64px";
      document.getElementById("content").style.marginLeft= "64px";
      document.getElementById("left-nav-body").style.display = "none";
      document.getElementById("left-nav-header-title").style.display = "none";
      this.isOpen = !this.isOpen;
    }
  }

}
