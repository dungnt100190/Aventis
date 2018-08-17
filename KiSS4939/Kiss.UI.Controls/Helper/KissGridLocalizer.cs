using System;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls.Helper
{
    /// <summary>
    /// Übersetzt das DevExpress Grid auf Deutsch.
    /// TODO: Wegen Verwendung von satellite assemblies obsolet.
    /// </summary>
    [Obsolete]
    public class KissGridLocalizer : GridControlLocalizer
    {
        #region Fields

        #region Private Static Fields

        private static KissGridLocalizer _instance;

        #endregion

        #endregion

        #region Constructors

        private KissGridLocalizer()
        {
        }

        #endregion

        #region Properties

        public static KissGridLocalizer Instance
        {
            get { return _instance ?? (_instance = new KissGridLocalizer()); }
        }

        public override string Language
        {
            get { return "Deutsch"; }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void PopulateStringTable()
        {
            base.PopulateStringTable();

            AddString(GridControlStringId.CellPeerName, "Element: {0}, Spalten-Anzeigeindex: {1}"); //Item: {0}, Column Display Index: {1}
            AddString(GridControlStringId.GridGroupPanelText, "Zu gruppierende Spalten in diesen Bereich ziehen"); //Drag a column header here to group by that column
            AddString(GridControlStringId.GridGroupRowDisplayTextFormat, "{0}: {1}"); // {0}: {1}
            AddString(GridControlStringId.ErrorWindowTitle, "Fehler"); //Error
            AddString(GridControlStringId.InvalidRowExceptionMessage, "Wollen Sie den Fehler korrigieren?");//Do you want to correct the value?
            AddString(GridControlStringId.GridOutlookIntervals, "Älter;Letzten Monat;Früher diesen Monat;Vor drei Wochen;Vor zwei Wochen;Letzte Woche;;;;;;;;Gestern;Heute;Morgen;;;;;;;;Nächste Woche;In zwei Wochen;In drei Wochen;Später diesen Monat;Nächsten Monat;Über den nächsten Monat hinaus;");//Older;Last Month;Earlier this Month;Three Weeks Ago;Two Weeks Ago;Last Week;;;;;;;;Yesterday;Today;Tomorrow;;;;;;;;Next Week;Two Weeks Away;Three Weeks Away;Later this Month;Next Month;Beyond Next Month;

            AddString(GridControlStringId.DefaultGroupSummaryFormatString_Count, "Anz.: {0}");//Count={0}
            AddString(GridControlStringId.DefaultGroupSummaryFormatString_Min, "Min. von {1}: {0}");//Min of {1} is {0}
            AddString(GridControlStringId.DefaultGroupSummaryFormatString_Max, "Max. von {1}: {0}");//Max of {1} is {0}
            AddString(GridControlStringId.DefaultGroupSummaryFormatString_Avg, "Durchschn. von {1}: {0:0.##}");//Avg of {1} is {0:0.##}
            AddString(GridControlStringId.DefaultGroupSummaryFormatString_Sum, "Summe von {1}: {0:0.##}");//Sum of {1} is {0:0.##}

            AddString(GridControlStringId.DefaultTotalSummaryFormatStringInSameColumn_Count, "Anz.: {0}");//Count={0}
            AddString(GridControlStringId.DefaultTotalSummaryFormatStringInSameColumn_Min, "Min: {0}");//Min={0}
            AddString(GridControlStringId.DefaultTotalSummaryFormatStringInSameColumn_Max, "Max: {0}");//Max={0}
            AddString(GridControlStringId.DefaultTotalSummaryFormatStringInSameColumn_Avg, "Durchschn.: {0:0.##}");//Avg={0:0.##}
            AddString(GridControlStringId.DefaultTotalSummaryFormatStringInSameColumn_Sum, "Summe: {0:0.##}");//Sum={0:0.##}

            AddString(GridControlStringId.DefaultTotalSummaryFormatString_Count, "Anz.: {0}");//Count={0}
            AddString(GridControlStringId.DefaultTotalSummaryFormatString_Min, "Min. von {1}: {0}");//Min of {1} is {0}
            AddString(GridControlStringId.DefaultTotalSummaryFormatString_Max, "Max. von {1}: {0}");//Max of {1} is {0}
            AddString(GridControlStringId.DefaultTotalSummaryFormatString_Avg, "Durchschn. von {1}: {0:0.##}");//Avg of {1} is {0:0.##}
            AddString(GridControlStringId.DefaultTotalSummaryFormatString_Sum, "Summe von {1}: {0:0.##}");//Sum of {1} is {0:0.##}

            AddString(GridControlStringId.DefaultGroupColumnSummaryFormatStringInSameColumn_Count, "Anz.: {0}");//Count={0}
            AddString(GridControlStringId.DefaultGroupColumnSummaryFormatStringInSameColumn_Min, "Min: {0}");//Min={0}
            AddString(GridControlStringId.DefaultGroupColumnSummaryFormatStringInSameColumn_Max, "Max: {0}");//Max={0}
            AddString(GridControlStringId.DefaultGroupColumnSummaryFormatStringInSameColumn_Avg, "Durchschn.: {0:0.##}");//Avg={0:0.##}
            AddString(GridControlStringId.DefaultGroupColumnSummaryFormatStringInSameColumn_Sum, "Summe: {0:0.##}");//Sum={0:0.##}

            AddString(GridControlStringId.DefaultGroupColumnSummaryFormatString_Count, "Anz.: {0}");//Count={0}
            AddString(GridControlStringId.DefaultGroupColumnSummaryFormatString_Min, "Min. von {1}: {0}");//Min of {1} is {0}
            AddString(GridControlStringId.DefaultGroupColumnSummaryFormatString_Max, "Max. von {1}: {0}");//Max of {1} is {0}
            AddString(GridControlStringId.DefaultGroupColumnSummaryFormatString_Avg, "Durchschn. von {1}: {0:0.##}");//Avg of {1} is {0:0.##}
            AddString(GridControlStringId.DefaultGroupColumnSummaryFormatString_Sum, "Summe von {1}: {0:0.##}");//Sum of {1} is {0:0.##}

            AddString(GridControlStringId.PopupFilterAll, "(Alle)");//(All)
            AddString(GridControlStringId.PopupFilterBlanks, "(Leer)");//(Blanks)
            AddString(GridControlStringId.PopupFilterNonBlanks, "(Nicht leer)");//(Non blanks)

            AddString(GridControlStringId.ColumnChooserCaption, "Spaltenwähler");//Column Chooser
            AddString(GridControlStringId.ColumnChooserCaptionForMasterDetail, "{0}: Spaltenwähler");//{0}: Column Chooser
            AddString(GridControlStringId.ColumnChooserDragText, "Spalten hierher ziehen, um das Layout anzupassen");//Drag a column here to customize layout

            AddString(GridControlStringId.GridNewRowText, "Hier klicken, um eine neue Zeile einzufügen");//Click here to add a new row

            AddString(GridControlStringId.MenuGroupPanelFullCollapse, "Alles reduzieren");//Full Collapse
            AddString(GridControlStringId.MenuGroupPanelFullExpand, "Alles erweitern");//Full Expand
            AddString(GridControlStringId.MenuGroupPanelClearGrouping, "Gruppierung löschen");//Clear Grouping

            AddString(GridControlStringId.MenuColumnSortAscending, "Aufsteigend sortieren");//Sort Ascending
            AddString(GridControlStringId.MenuColumnSortDescending, "Absteigend sortieren");//Sort Descending
            AddString(GridControlStringId.MenuColumnSortBySummaryAverage, "Durchschnitt");//Average
            AddString(GridControlStringId.MenuColumnSortBySummaryCount, "Anzahl");//Count
            AddString(GridControlStringId.MenuColumnSortBySummarySum, "Sum");//Sum
            AddString(GridControlStringId.MenuColumnSortBySummaryMax, "Max");//Max
            AddString(GridControlStringId.MenuColumnSortBySummaryMin, "Min");//Min
            AddString(GridControlStringId.MenuColumnSortBySummaryAscending, "Aufsteigend");//Ascending
            AddString(GridControlStringId.MenuColumnSortBySummaryDescending, "Absteigend");//Descending
            AddString(GridControlStringId.MenuColumnClearSorting, "Sortierung aufheben");//Clear Sorting

            AddString(GridControlStringId.MenuColumnUnGroup, "Gruppierung aufheben");//Ungroup
            AddString(GridControlStringId.MenuColumnGroup, "Nach dieser Spalte gruppieren");//Group By This Column
            AddString(GridControlStringId.MenuColumnShowGroupPanel, "Gruppierungen anzeigen");//Show Group Panel
            AddString(GridControlStringId.MenuColumnHideGroupPanel, "Gruppierungen ausblenden");//Hide Group Panel
            AddString(GridControlStringId.MenuColumnGroupInterval, "Gruppierungsintervall");//Group Interval
            AddString(GridControlStringId.MenuColumnGroupIntervalNone, "Kein");//None
            AddString(GridControlStringId.MenuColumnGroupIntervalDay, "Tag");//Day
            AddString(GridControlStringId.MenuColumnGroupIntervalMonth, "Monat");//Month
            AddString(GridControlStringId.MenuColumnGroupIntervalYear, "Jahr");//Year
            AddString(GridControlStringId.MenuColumnGroupIntervalSmart, "Intelligent");//Smart
            AddString(GridControlStringId.MenuColumnResetGroupSummarySort, "Summensortierung löschen");//Clear Summary Sorting
            AddString(GridControlStringId.MenuColumnSortGroupBySummaryMenu, "Nach Summierung sortieren");//Sort By Summary
            AddString(GridControlStringId.MenuColumnGroupSummarySortFormat, "{1} nach '{0}' - {2}");//{1} by '{0}' - {2}
            AddString(GridControlStringId.MenuColumnGroupSummaryEditor, "Gruppensummierungseditor...");//Group Summary Editor...

            AddString(GridControlStringId.MenuColumnShowColumnChooser, "Spaltenwähler anzeigen");//Show Column Chooser
            AddString(GridControlStringId.MenuColumnHideColumnChooser, "Spaltenwähler ausblenden");//Hide Column Chooser

            AddString(GridControlStringId.MenuColumnBestFit, "Optimale Grösse");//Best Fit
            AddString(GridControlStringId.MenuColumnBestFitColumns, "Optimale Grösse (alle Spalten)");//Best Fit (all columns)

            AddString(GridControlStringId.MenuColumnUnboundExpressionEditor, "Expression-Editor...");//Expression Editor...

            AddString(GridControlStringId.MenuColumnClearFilter, "Filter löschen");//Clear Filter
            AddString(GridControlStringId.MenuColumnFilterEditor, "Filter-Editor...");//Filter Editor...

            AddString(GridControlStringId.MenuColumnFixedStyle, "Fixiert");//Fixed Style
            AddString(GridControlStringId.MenuColumnFixedNone, "Kein");//None
            AddString(GridControlStringId.MenuColumnFixedLeft, "Links");//Left
            AddString(GridControlStringId.MenuColumnFixedRight, "Rechts");//Right

            AddString(GridControlStringId.MenuColumnShowSearchPanel, "Suchbereich anzeigen");//Show Search Panel
            AddString(GridControlStringId.MenuColumnHideSearchPanel, "Suchbereich ausblenden");//Hide Search Panel

            AddString(GridControlStringId.MenuFooterSum, "Sum");//Sum
            AddString(GridControlStringId.MenuFooterMax, "Max");//Max
            AddString(GridControlStringId.MenuFooterMin, "Min");//Min
            AddString(GridControlStringId.MenuFooterCount, "Anzahl");//Count
            AddString(GridControlStringId.MenuFooterAverage, "Durchschnitt");//Average
            AddString(GridControlStringId.MenuFooterCustomize, "Anpassen...");//Customize...
            AddString(GridControlStringId.MenuFooterRowCount, "Zeilenanzahl anzeigen");//Show row count

            AddString(GridControlStringId.GroupSummaryEditorFormCaption, "Gruppensummierungen");//Group Summaries
            AddString(GridControlStringId.TotalSummaryEditorFormCaption, "Total für '{0}'");//Totals for '{0}'
            AddString(GridControlStringId.TotalSummaryPanelEditorFormCaption, "Totale anzeigen");//View Totals

            AddString(GridControlStringId.SummaryEditorFormItemsTabCaption, "Elemente");//Items
            AddString(GridControlStringId.SummaryEditorFormOrderTabCaption, "Reihenfolge");//Order
            AddString(GridControlStringId.SummaryEditorFormOrderLeftSide, "Linke Seite:");//Left side:
            AddString(GridControlStringId.SummaryEditorFormOrderRightSide, "Rechte Seite");//Right side:
            AddString(GridControlStringId.SummaryEditorFormOrderAndAlignmentTabCaption, "Reihenfolge und Ausrichtung");//Order and Alignment
            AddString(GridControlStringId.SummaryEditorFormMoveItemUpCaption, "Nach oben");//Up
            AddString(GridControlStringId.SummaryEditorFormMoveItemDownCaption, "Nach unten");//Down

            AddString(GridControlStringId.FilterEditorTitle, "Filter-Editor");//Filter Editor
            AddString(GridControlStringId.FilterPanelCaptionFormatStringForMasterDetail, "{0} Filter:");//{0} filter:
            AddString(GridControlStringId.GroupPanelDisplayFormatStringForMasterDetail, "{0}:");//{0}:
            AddString(GridControlStringId.ProgressWindowTitle, "Lade Daten");//Loading data
            AddString(GridControlStringId.ProgressWindowCancel, "Abbrechen");//Cancel

            AddString(GridControlStringId.ErrorPanelTextFormatString, "Beim Bearbeiten des Server-Aufrufs ist ein Fehler aufgetreten ({0})");//Error occurred during processing server request ({0})
        }

        #endregion

        #endregion

        #region Other

        /*
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
        */

        #endregion
    }
}