import {
  Component,
  Output,
  Input,
  EventEmitter,
  ChangeDetectionStrategy,
  ElementRef,
  OnInit
} from '@angular/core';

@Component({
  selector: 'language-selector',
  templateUrl: './languageSelector.component.html',
  styleUrls: ['./languageSelector.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  host: {
    '(document:click)': 'onDocumentClick($event)'
  }
})
export class LanguageSelectorComponent implements OnInit {
  selectedLangFlag: String = '';
  @Input() selectedLanguage: any;
  @Input() availableLanguages: Array<any>;
  @Output() select: EventEmitter<any> = new EventEmitter();

  public show: Boolean = false;

  constructor(private elementRef: ElementRef) {
  }

  ngOnInit() {
   const currentLang = this.availableLanguages.find(lang => lang.code === this.selectedLanguage);
   this.selectedLangFlag = currentLang !== null ? currentLang.flag : '';
  }

  public onDocumentClick(event): void {
    if (!this.elementRef.nativeElement.contains(event.target)) {
      this.show = false;
    }
  }

  public onToggle(): void {
    this.show = !this.show;
  }

  public selectLanguage(lang: any) {
    this.show = false;
    this.selectedLangFlag = lang.flag;
    this.select.emit({ code: lang.code, culture: lang.culture });
  }
}
