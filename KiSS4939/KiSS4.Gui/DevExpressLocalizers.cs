using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using KiSS4.DB;

namespace KiSS4.Gui
{
	// That's the way it works (do once at startup --> FrmMain)
	//   DevExpress.XtraGrid.Localization.GridLocalizer.Active = new MyGridLocalizer();
	//   DevExpress.XtraEditors.Controls.Localizer.Active = new MyEditorLocalizer();

	#region Class MyGridLocalizer

	/// <summary>
	/// Our own GridLocalizer, used for multilanguage texts on grid
	/// </summary>
	public class MyGridLocalizer : DevExpress.XtraGrid.Localization.GridLocalizer
	{
		private static int languageCode = -1;
		private static Dictionary<GridStringId, string> dicLocatlization = new Dictionary<GridStringId, string>();

		/// <summary>
		/// Get the language used with strings
		/// </summary>
		public override string Language
		{
			get { return "Deutsch"; }
		}

		/// <summary>
		/// Get defined string from localizer
		/// </summary>
		/// <param name="id">The id of the string <see>DevExpress.XtraGrid.Localization.GridStringId</see></param>
		/// <returns>The language string or "" if nothing found</returns>
		public override string GetLocalizedString(GridStringId id)
		{
			string ret = string.Empty;

			if (Session.User != null && Session.User.LanguageCode == languageCode)
			{
				if (dicLocatlization.ContainsKey(id))
					return dicLocatlization[id];
			}
			else
				dicLocatlization.Clear();

			switch (id)
			{
				case GridStringId.FileIsNotFoundError: ret = KissMsg.GetMLMessage("MyGridLocalizer", "FileIsNotFoundError", "Datei '{0}' wurde nicht gefunden"); break; //File {0} is not found
				case GridStringId.FilterPanelCustomizeButton: ret = KissMsg.GetMLMessage("MyGridLocalizer", "FilterPanelCustomizeButton", "Filter bearbeiten"); break; //Edit Filter
				case GridStringId.ColumnViewExceptionMessage: ret = KissMsg.GetMLMessage("MyGridLocalizer", "ColumnViewExceptionMessage", " Wollen Sie den Wert korrigieren ?"); break; // Do you want to correct the value ?
				case GridStringId.CustomizationCaption: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomizationCaption", "Benutzerdefiniert"); break; //Customization
				case GridStringId.CustomizationColumns: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomizationColumns", "Spalten"); break; //Columns
				case GridStringId.CustomizationBands: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomizationBands", "Linien"); break; //Bands
				case GridStringId.PopupFilterAll: ret = KissMsg.GetMLMessage("MyGridLocalizer", "PopupFilterAll", "(Alle)"); break; //(All)
				case GridStringId.PopupFilterCustom: ret = KissMsg.GetMLMessage("MyGridLocalizer", "PopupFilterCustom", "(Benutzer)"); break; //(Custom)
				case GridStringId.PopupFilterBlanks: ret = KissMsg.GetMLMessage("MyGridLocalizer", "PopupFilterBlanks", "(Leer)"); break; //(Blanks)
				case GridStringId.PopupFilterNonBlanks: ret = KissMsg.GetMLMessage("MyGridLocalizer", "PopupFilterNonBlanks", "(Nicht leer)"); break; //(Non blanks)
				case GridStringId.CustomFilterDialogFormCaption: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogFormCaption", "Benutzer AutoFilter"); break; //Custom AutoFilter
				case GridStringId.CustomFilterDialogCaption: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogCaption", "Zeilen hier anzeigen:"); break; //Show rows where:
				case GridStringId.CustomFilterDialogRadioAnd: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogRadioAnd", "&Und"); break; //&And
				case GridStringId.CustomFilterDialogRadioOr: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogRadioOr", "&Oder"); break; //&Or
				case GridStringId.CustomFilterDialogOkButton: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogOkButton", "&Ok"); break; //&OK
				case GridStringId.CustomFilterDialogClearFilter: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogClearFilter", "Filter &löschen"); break; //C&lear Filter
				case GridStringId.CustomFilterDialogCancelButton: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogCancelButton", "A&bbrechen"); break; //&Cancel
				case GridStringId.CustomFilterDialog2FieldCheck: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialog2FieldCheck", "Felder"); break; //Field
				case GridStringId.CustomFilterDialogConditionEQU: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogConditionEQU", "gleich"); break; //equals
				case GridStringId.CustomFilterDialogConditionNEQ: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogConditionNEQ", "ungleich"); break; //does not equal
				case GridStringId.CustomFilterDialogConditionGT: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogConditionGT", "ist grösser als"); break; //is greater than
				case GridStringId.CustomFilterDialogConditionGTE: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogConditionGTE", "ist grösser oder gleich"); break; //is greater than or equal to
				case GridStringId.CustomFilterDialogConditionLT: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogConditionLT", "ist weniger als"); break; //is less than
				case GridStringId.CustomFilterDialogConditionLTE: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogConditionLTE", "ist weniger oder gleich"); break; //is less than or equal to
				case GridStringId.CustomFilterDialogConditionBlanks: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogConditionBlanks", "leer"); break; //blanks
				case GridStringId.CustomFilterDialogConditionNonBlanks: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogConditionNonBlanks", "nicht leer"); break; //non blanks
				case GridStringId.CustomFilterDialogConditionLike: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogConditionLike", "wie"); break; //like
				case GridStringId.CustomFilterDialogConditionNotLike: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CustomFilterDialogConditionNotLike", "nicht wie"); break; //not like
				case GridStringId.MenuFooterSum: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterSum", "Sum"); break; //Sum
				case GridStringId.MenuFooterMin: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterMin", "Min"); break; //Min
				case GridStringId.MenuFooterMax: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterMax", "Max"); break; //Max
				case GridStringId.MenuFooterCount: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterCount", "Anzahl"); break; //Count
				case GridStringId.MenuFooterAverage: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterAverage", "Durchschnitt"); break; //Average
				case GridStringId.MenuFooterNone: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterNone", "Keine"); break; //None
				case GridStringId.MenuFooterSumFormat: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterSumFormat", "SUM={0:#.##}"); break; //SUM={0:#.##}
				case GridStringId.MenuFooterMinFormat: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterMinFormat", "MIN={0}"); break; //MIN={0}
				case GridStringId.MenuFooterMaxFormat: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterMaxFormat", "MAX={0}"); break; //MAX={0}
				case GridStringId.MenuFooterCountFormat: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterCountFormat", "{0}"); break; //{0}
				case GridStringId.MenuFooterCountGroupFormat: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterCountGroupFormat", "Anzahl={0}"); break; //Count={0}
				case GridStringId.MenuFooterAverageFormat: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterAverageFormat", "Durchschnitt={0:#.##}"); break; //AVR={0:#.##}
				case GridStringId.MenuFooterCustomFormat: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuFooterCustomFormat", "Benutzer={0}"); break; //Custom={0}
				case GridStringId.MenuColumnSortAscending: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuColumnSortAscending", "Aufsteigend sortieren"); break; //Sort Ascending
				case GridStringId.MenuColumnSortDescending: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuColumnSortDescending", "Absteigend sortieren"); break; //Sort Descending
				case GridStringId.MenuColumnClearSorting: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuColumnClearSorting", "Sortierung löschen"); break; //Clear Sorting
				case GridStringId.MenuColumnGroup: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuColumnGroup", "Nach dieser Spalte gruppieren"); break; //Group By This Column
				case GridStringId.MenuColumnUnGroup: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuColumnUnGroup", "Gruppierung löschen"); break; //UnGroup
				case GridStringId.MenuColumnColumnCustomization: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuColumnColumnCustomization", "Spaltenwähler"); break; //Column Chooser
				case GridStringId.MenuColumnBestFit: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuColumnBestFit", "Optimale Grösse"); break; //Best Fit
				case GridStringId.MenuColumnFilter: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuColumnFilter", "Filter möglich"); break; //Can Filter
				case GridStringId.MenuColumnFilterEditor: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuColumnFilterEditor", "Filter Editor"); break; //Filter Editor
				case GridStringId.MenuColumnClearFilter: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuColumnClearFilter", "Filter löschen"); break; //Clear Filter
				case GridStringId.MenuColumnBestFitAllColumns: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuColumnBestFitAllColumns", "Optimale Grösse (alle Spalten)"); break; //Best Fit (all columns)
				case GridStringId.MenuGroupPanelFullExpand: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuGroupPanelFullExpand", "Alles erweitern"); break; //Full Expand
				case GridStringId.MenuGroupPanelFullCollapse: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuGroupPanelFullCollapse", "Alles reduzieren"); break; //Full Collapse
				case GridStringId.MenuGroupPanelClearGrouping: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuGroupPanelClearGrouping", "Gruppierung löschen"); break;
				case GridStringId.PrintDesignerBandedView: ret = KissMsg.GetMLMessage("MyGridLocalizer", "PrintDesignerBandedView", "Druckeinstellungen (Linienansicht)"); break; //Print Settings (Banded View)
				case GridStringId.PrintDesignerGridView: ret = KissMsg.GetMLMessage("MyGridLocalizer", "PrintDesignerGridView", "Druckeinstellungen (Gitteransicht)"); break; //Print Settings (Grid View)
				case GridStringId.PrintDesignerCardView: ret = KissMsg.GetMLMessage("MyGridLocalizer", "PrintDesignerCardView", "Druckeinstellungen (Kartenansicht)"); break; //Print Settings (Card View)
				case GridStringId.PrintDesignerDescription: ret = KissMsg.GetMLMessage("MyGridLocalizer", "PrintDesignerDescription", "Verschiedene Druckoptionen einstellen für die aktuelle Ansicht."); break; //Set up various printing options for the current view.
				case GridStringId.PrintDesignerBandHeader: ret = KissMsg.GetMLMessage("MyGridLocalizer", "PrintDesignerBandHeader", "Linienüberschrift"); break; //BandHeader
				case GridStringId.MenuColumnGroupBox: ret = KissMsg.GetMLMessage("MyGridLocalizer", "MenuColumnGroupBox", "Gruppieren"); break; //Group By Box
				case GridStringId.CardViewNewCard: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CardViewNewCard", "Neue Karte"); break; //New Card
				case GridStringId.CardViewQuickCustomizationButton: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CardViewQuickCustomizationButton", "Anpassen"); break; //Customize
				case GridStringId.CardViewQuickCustomizationButtonFilter: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CardViewQuickCustomizationButtonFilter", "Filter"); break; //Filter
				case GridStringId.CardViewQuickCustomizationButtonSort: ret = KissMsg.GetMLMessage("MyGridLocalizer", "CardViewQuickCustomizationButtonSort", "Sortierung:"); break; //Sort:
				case GridStringId.GridGroupPanelText: ret = KissMsg.GetMLMessage("MyGridLocalizer", "GridGroupPanelText", "Zu gruppierende Spalten in diesen Bereich ziehen"); break; //Drag a column header here to group by that column
				case GridStringId.GridNewRowText: ret = KissMsg.GetMLMessage("MyGridLocalizer", "GridNewRowText", "Hier klicken, um eine neue Zeile einzufügen"); break; //Click here to add a new row
				case GridStringId.GridOutlookIntervals: ret = KissMsg.GetMLMessage("MyGridLocalizer", "GridOutlookIntervals", "Älter;Letzten Monat;Früher diesen Monat;Drei Wochen zurück;Zwei Wochen zurück;Letzte Woche;;;;;;;;Gestern;Heute;Morgen;;;;;;;;Nächste Woche;In zwei Wochen;In drei Wochen;Später diesen Monath;Nächsten Monat;Über den nächsten Monat hinaus;"); break; //Older;Last Month;Earlier this Month;Three Weeks Ago;Two Weeks Ago;Last Week;;;;;;;;Yesterday;Today;Tomorrow;;;;;;;;Next Week;Two Weeks Away;Three Weeks Away;Later this Month;Next Month;Beyond Next Month;
				case GridStringId.FilterBuilderOkButton: ret = KissMsg.GetMLMessage("MyGridLocalizer", "FilterBuilderOkButton", "&Ok"); break; //&OK
				case GridStringId.FilterBuilderCancelButton: ret = KissMsg.GetMLMessage("MyGridLocalizer", "FilterBuilderCancelButton", "A&bbrechen"); break; //&Cancel
				case GridStringId.FilterBuilderApplyButton: ret = KissMsg.GetMLMessage("MyGridLocalizer", "FilterBuilderApplyButton", "&Anwenden"); break; //&Apply
				case GridStringId.FilterBuilderCaption: ret = KissMsg.GetMLMessage("MyGridLocalizer", "FilterBuilderCaption", "Filter Editor"); break; //Filter Builder
				default:
					// stop here to show that we are missing a value
					if (System.Diagnostics.Debugger.IsAttached)
					{
						System.Diagnostics.Debugger.Break();
					}

					// no value found, try to get value from baseclass and validate it
					ret = base.GetLocalizedString(id);
					if (DBUtil.IsEmpty(ret))
						return string.Empty;
					break;
			}

			if (Session.User != null)
			{
				languageCode = Session.User.LanguageCode;
				dicLocatlization[id] = ret;
			}

			return ret;
		}
	}

	#endregion

	#region Class MyEditorLocalizer

	/// <summary>
	/// Our own Localizer, used for multilanguage texts on editor
	/// </summary>
	public class MyEditorLocalizer : DevExpress.XtraEditors.Controls.Localizer
	{
		private static int languageCode = -1;
		private static Dictionary<StringId, string> dicLocatlization = new Dictionary<StringId, string>();

		/// <summary>
		/// Get the language used with strings
		/// </summary>
		public override string Language
		{
			get { return "Deutsch"; }
		}

		/// <summary>
		/// Get defined string from localizer
		/// </summary>
		/// <param name="id">The id of the string <see>DevExpress.XtraEditors.Controls.StringId</see></param>
		/// <returns>The language string or "" if nothing found</returns>
		public override string GetLocalizedString(StringId id)
		{
			string ret = string.Empty;

			if (Session.User != null && Session.User.LanguageCode == languageCode)
			{
				if (dicLocatlization.ContainsKey(id))
					return dicLocatlization[id];
			}
			else
				dicLocatlization.Clear();

			switch (id)
			{
				case StringId.None: return string.Empty;
				case StringId.CaptionError: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CaptionError", "Fehler"); break; //"Error";
				case StringId.InvalidValueText: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "InvalidValueText", "Ungültiger Wert"); break; //"Invalid Value";
				case StringId.CheckChecked: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CheckChecked", "Ausgewählt"); break; //"Checked";
				case StringId.CheckUnchecked: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CheckUnchecked", "Nicht ausgewählt"); break; //"Unchecked";
				case StringId.CheckIndeterminate: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CheckIndeterminate", "Unbestimmt"); break; //"Indeterminate";
				case StringId.DateEditToday: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "DateEditToday", "Heute"); break; //"Today";
				case StringId.DateEditClear: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "DateEditClear", "Löschen"); break; //"Clear";
				case StringId.OK: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "OK", "&Ok"); break; //"&OK";
				case StringId.Cancel: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "Cancel", "A&bbrechen"); break; //"&Cancel";
				case StringId.NavigatorFirstButtonHint: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NavigatorFirstButtonHint", "Anfang"); break; //"First";
				case StringId.NavigatorPreviousButtonHint: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NavigatorPreviousButtonHint", "Vorheriger"); break; //"Previous";
				case StringId.NavigatorPreviousPageButtonHint: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NavigatorPreviousPageButtonHint", "Vorherige Seite"); break; //"Previous Page";
				case StringId.NavigatorNextButtonHint: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NavigatorNextButtonHint", "Nächster"); break; //"Next";
				case StringId.NavigatorNextPageButtonHint: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NavigatorNextPageButtonHint", "Nächste Seite"); break; //"Next Page";
				case StringId.NavigatorLastButtonHint: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NavigatorLastButtonHint", "Ende"); break; //"Last";
				case StringId.NavigatorAppendButtonHint: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NavigatorAppendButtonHint", "Anfügen"); break; //"Append";
				case StringId.NavigatorRemoveButtonHint: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NavigatorRemoveButtonHint", "Löschen"); break; //"Delete";
				case StringId.NavigatorEditButtonHint: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NavigatorEditButtonHint", "Bearbeiten"); break; //"Edit";
				case StringId.NavigatorEndEditButtonHint: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NavigatorEndEditButtonHint", "Bearbeiten fertig"); break; //"End Edit";
				case StringId.NavigatorCancelEditButtonHint: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NavigatorCancelEditButtonHint", "Bearbeiten abbrechen"); break; //"Cancel Edit";
				case StringId.NavigatorTextStringFormat: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NavigatorTextStringFormat", "Eintrag {0} von {1}"); break; //"Record {0} of {1}";
				case StringId.PictureEditMenuCut: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "PictureEditMenuCut", "Ausschneiden"); break; //"Cut";
				case StringId.PictureEditMenuCopy: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "PictureEditMenuCopy", "Kopieren"); break; //"Copy";
				case StringId.PictureEditMenuPaste: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "PictureEditMenuPaste", "Einfügen"); break; //"Paste";
				case StringId.PictureEditMenuDelete: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "PictureEditMenuDelete", "Löschen"); break; //"Delete";
				case StringId.PictureEditMenuLoad: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "PictureEditMenuLoad", "Öffnen"); break; //"Load";
				case StringId.PictureEditMenuSave: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "PictureEditMenuSave", "Speichern"); break; //"Save";
				case StringId.PictureEditOpenFileFilter: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "PictureEditOpenFileFilter", "Bitmap Dateien (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG Datei Interchange Format (*.jpg;*.jpeg)|*.jpg;*.jpeg|Icon Dateien (*.ico)|*.ico|Alle Bilddateien |*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|Alle Dateien |*.*"); break; //"Bitmap Files (*.bmp)|*.bmp|"+"Graphics Interchange Format (*.gif)|*.gif|"+"JPEG File Interchange Format (*.jpg;*.jpeg)|*.jpg;*.jpeg|"+"Icon Files (*.ico)|*.ico|"+"All Picture Files |*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|"+"All Files |*.*";
				case StringId.PictureEditSaveFileFilter: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "PictureEditSaveFileFilter", "Bitmap Dateien (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG Datei Interchange Format (*.jpg)|*.jpg"); break; //"Bitmap Files (*.bmp)|*.bmp|"+"Graphics Interchange Format (*.gif)|*.gif|"+"JPEG File Interchange Format (*.jpg)|*.jpg";
				case StringId.PictureEditOpenFileTitle: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "PictureEditOpenFileTitle", "Öffnen"); break; //"Open";
				case StringId.PictureEditSaveFileTitle: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "PictureEditSaveFileTitle", "Speichern als"); break; //"Save As";
				case StringId.PictureEditOpenFileError: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "PictureEditOpenFileError", "Falsches Bildformat"); break; //"Wrong picture format";
				case StringId.PictureEditOpenFileErrorCaption: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "PictureEditOpenFileErrorCaption", "Fehler beim Öffnen"); break; //"Open error";
				case StringId.LookUpEditValueIsNull: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "LookUpEditValueIsNull", "[EditValue ist leer]"); break; //"[EditValue is null]";
				case StringId.LookUpInvalidEditValueType: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "LookUpInvalidEditValueType", "Ungültiger Typ von LookUpEdit EditValue"); break; //"Invalid LookUpEdit EditValue type.";
				case StringId.LookUpColumnDefaultName: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "LookUpColumnDefaultName", "Name"); break; //"Name";
				case StringId.MaskBoxValidateError: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "MaskBoxValidateError", "Der eingegebene Wert ist nicht komplett. Wollen Sie ihn korrigieren?\r\n\r\nJa - zum Editor zurückkehren und den Wert korrigieren.\r\nNein - den Wert so belassen.\r\nAbbrechen - auf den vorherigen Wert zurücksetzen.\r\n"); break; //"The entered value is incomplete.  Do you want to correct it?\r\n\r\n"+"Yes - return to the editor and correct the value.\r\n"+"No - leave the value as is.\r\n"+"Cancel - reset to the previous value.\r\n";
				case StringId.UnknownPictureFormat: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "UnknownPictureFormat", "Unbekanntes Bildformat"); break; //"Unknown picture format";
				case StringId.DataEmpty: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "DataEmpty", "Keine Bilddaten"); break; //"No image data";
				case StringId.NotValidArrayLength: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "NotValidArrayLength", "Ungültige Arraylänge"); break; //"Not valid array length.";
				case StringId.ImagePopupEmpty: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "ImagePopupEmpty", "(Leer)"); break; //"(Empty)";
				case StringId.ImagePopupPicture: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "ImagePopupPicture", "(Bild)"); break; //"(Picture)";
				case StringId.ColorTabCustom: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "ColorTabCustom", "Benutzerdefiniert"); break; //"Custom";
				case StringId.ColorTabWeb: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "ColorTabWeb", "Web"); break; //"Web";
				case StringId.ColorTabSystem: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "ColorTabSystem", "System"); break; //"System";
				case StringId.CalcButtonMC: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CalcButtonMC", "MC"); break; //"MC";
				case StringId.CalcButtonMR: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CalcButtonMR", "MR"); break; //"MR";
				case StringId.CalcButtonMS: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CalcButtonMS", "MS"); break; //"MS";
				case StringId.CalcButtonMx: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CalcButtonMx", "M+"); break; //"M+";
				case StringId.CalcButtonSqrt: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CalcButtonSqrt", "sqrt"); break; //"sqrt";
				case StringId.CalcButtonBack: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CalcButtonBack", "Zurück"); break; //"Back";
				case StringId.CalcButtonCE: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CalcButtonCE", "CE"); break; //"CE";
				case StringId.CalcButtonC: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CalcButtonC", "C"); break; //"C";
				case StringId.CalcError: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "CalcError", "Berechnungsfehler"); break; //"Calculation Error";
				case StringId.TabHeaderButtonPrev: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "TabHeaderButtonPrev", "Links scrollen"); break; //"Scroll Left";
				case StringId.TabHeaderButtonNext: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "TabHeaderButtonNext", "Rechts scrollen"); break; //"Scroll Right";
				case StringId.TabHeaderButtonClose: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "TabHeaderButtonClose", "Schliessen"); break; //"Close";
				case StringId.XtraMessageBoxOkButtonText: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "XtraMessageBoxOkButtonText", "&Ok"); break; //"&OK";
				case StringId.XtraMessageBoxCancelButtonText: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "XtraMessageBoxCancelButtonText", "A&bbrechen"); break; //"&Cancel";
				case StringId.XtraMessageBoxYesButtonText: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "XtraMessageBoxYesButtonText", "&Ja"); break; //"&Yes";
				case StringId.XtraMessageBoxNoButtonText: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "XtraMessageBoxNoButtonText", "&Nein"); break; //"&No";
				case StringId.XtraMessageBoxAbortButtonText: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "XtraMessageBoxAbortButtonText", "A&bbrechen"); break; //"&Abort";
				case StringId.XtraMessageBoxRetryButtonText: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "XtraMessageBoxRetryButtonText", "&Wiederholen"); break; //"&Retry";
				case StringId.XtraMessageBoxIgnoreButtonText: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "XtraMessageBoxIgnoreButtonText", "&Ignorieren"); break; //"&Ignore";
				case StringId.TextEditMenuUndo: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "TextEditMenuUndo", "&Rückgängig"); break; //"&Undo";
				case StringId.TextEditMenuCut: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "TextEditMenuCut", "&Ausschneiden"); break; //"Cu&t";
				case StringId.TextEditMenuCopy: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "TextEditMenuCopy", "&Kopieren"); break; //"&Copy";
				case StringId.TextEditMenuPaste: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "TextEditMenuPaste", "&Einfügen"); break; //"&Paste";
				case StringId.TextEditMenuDelete: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "TextEditMenuDelete", "&Löschen"); break; //"&Delete";
				case StringId.TextEditMenuSelectAll: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "TextEditMenuSelectAll", "A&lle auswählen"); break; //"S elect &All";
				case StringId.FilterGroupAnd: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterGroupAnd", "Und"); break; //"And";
				case StringId.FilterGroupNotAnd: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterGroupNotAnd", "Nicht Und"); break; //"Not And";
				case StringId.FilterGroupNotOr: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterGroupNotOr", "Nicht Oder"); break; //"Not Or";
				case StringId.FilterGroupOr: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterGroupOr", "Oder"); break; //"Or";
				case StringId.FilterClauseAnyOf: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseAnyOf", "Ist eines von"); break; //"Is any of";
				case StringId.FilterClauseBeginsWith: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseBeginsWith", "Beginnt mit"); break; //"Begins with";
				case StringId.FilterClauseBetween: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseBetween", "Ist zwischen"); break; //"Is between";
				case StringId.FilterClauseBetweenAnd: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseBetweenAnd", "und"); break; //"and";
				case StringId.FilterClauseContains: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseContains", "Enthält"); break; //"Contains";
				case StringId.FilterClauseEndsWith: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseEndsWith", "Endet mit"); break; //"Ends with";
				case StringId.FilterClauseEquals: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseEquals", "gleich"); break; //"Equals";
				case StringId.FilterClauseGreater: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseGreater", "Ist grösser als"); break; //"Is greater than";
				case StringId.FilterClauseGreaterOrEqual: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseGreaterOrEqual", "Ist grösser als oder gleich"); break; //"Is greater than or equal to";
				case StringId.FilterClauseIsNotNull: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseIsNotNull", "Ist nicht leer"); break; //"Is not blank";
				case StringId.FilterClauseIsNull: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseIsNull", "Ist leer"); break; //"Is blank";
				case StringId.FilterClauseLess: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseLess", "Ist weniger als"); break; //"Is less than";
				case StringId.FilterClauseLessOrEqual: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseLessOrEqual", "Ist weniger als oder gleich"); break; //"Is less than or equal to";
				case StringId.FilterClauseLike: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseLike", "Ist wie"); break; //"Is like";
				case StringId.FilterClauseNoneOf: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseNoneOf", "Ist keines von"); break; //"Is none of";
				case StringId.FilterClauseNotBetween: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseNotBetween", "Ist nicht zwischen"); break; //"Is not between";
				case StringId.FilterClauseDoesNotContain: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseDoesNotContain", "Enthält nicht"); break; //"Does not contain";
				case StringId.FilterClauseDoesNotEqual: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseDoesNotEqual", "Ungleich"); break; //"Does not equal";
				case StringId.FilterClauseNotLike: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterClauseNotLike", "Ist nicht wie"); break; //"Is not like";
				case StringId.FilterEmptyEnter: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterEmptyEnter", "<Wert eingeben>"); break; //"<enter a value>";
				case StringId.FilterEmptyValue: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterEmptyValue", "<leer>"); break; //"<empty>";
				case StringId.FilterMenuConditionAdd: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterMenuConditionAdd", "Bedingung hinzufügen"); break; //"Add Condition";
				case StringId.FilterMenuGroupAdd: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterMenuGroupAdd", "Gruppe hinzufügen"); break; //"Add Group";
				case StringId.FilterMenuClearAll: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterMenuClearAll", "Alles löschen"); break; //"Clear All";
				case StringId.FilterMenuRowRemove: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterMenuRowRemove", "Gruppe entfernen"); break; //"Remove Group";
				case StringId.FilterToolTipNodeAdd: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterToolTipNodeAdd", "Eine neue Bedingung zu dieser Gruppe hinzufügen"); break; //"Adds a new condition to this group.";
				case StringId.FilterToolTipNodeRemove: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterToolTipNodeRemove", "Diese Bedingung löschen"); break; //"Removes this condition.";
				case StringId.FilterToolTipNodeAction: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterToolTipNodeAction", "Aktionen."); break; //"Actions.";
				case StringId.FilterToolTipValueType: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterToolTipValueType", "Vergleichen mit einem Wert / Wert eines anderen Feldes"); break; //"Compare to a value / another field's value.";
				case StringId.FilterToolTipElementAdd: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterToolTipElementAdd", "Ein neues Element zur Liste hinzufügen"); break; //"Adds a new item to the list.";
				case StringId.FilterToolTipKeysAdd: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterToolTipKeysAdd", "(Benutzen Sie die Taste Insert oder +)"); break; //"(Use the Insert or Add key)";
				case StringId.FilterToolTipKeysRemove: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "FilterToolTipKeysRemove", "(Benutzen Sie die Taste Delete oder -)"); break; //"(Use the Delete or Subtract key)";
				case StringId.ContainerAccessibleEditName: ret = KissMsg.GetMLMessage("MyEditorLocalizer", "ContainerAccessibleEditName", "Steuerelement bearbeiten"); break; //"Editing control";
				default:
					// stop here to show that we are missing a value
					if (System.Diagnostics.Debugger.IsAttached)
					{
						System.Diagnostics.Debugger.Break();
					}

					// no value found, try to get value from baseclass and validate it
					ret = base.GetLocalizedString(id);
					if (DBUtil.IsEmpty(ret))
						return string.Empty;
					break;
			}

			if (Session.User != null)
			{
				languageCode = Session.User.LanguageCode;
				dicLocatlization[id] = ret;
			}

			return ret;
		}
	}

	#endregion
}
