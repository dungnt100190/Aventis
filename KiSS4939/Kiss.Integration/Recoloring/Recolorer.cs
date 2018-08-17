using KiSS4.DB;

namespace Kiss.Integration.Recoloring
{
    public class Recolorer
    {
        public static void SetColors(ColorSet colorSet)
        {
            // Set Kiss5 Colors
            KiSS4.Gui.GuiConfig.Theme = KiSS4.Gui.GuiConfig.KissTheme.KissBlue;

            //colBack..
            KiSS4.Gui.GuiConfig.colBack01 = colorSet.KissEditControlBackground;

            KiSS4.Gui.GuiConfig.colBack02 = colorSet.B10;
            KiSS4.Gui.GuiConfig.colBack03 = colorSet.B10;
            KiSS4.Gui.GuiConfig.colBack04 = colorSet.B15;
            KiSS4.Gui.GuiConfig.colBack05 = colorSet.KissPanelBackground;  //muss KissPanelBackground sein, sonst wird ein Panel in einem TabControl zu dunkel dargestellt
            KiSS4.Gui.GuiConfig.colBack06 = colorSet.KissGridHeaderBackground;

            //Logische Farben
            KiSS4.Gui.GuiConfig.PanelColor = colorSet.KissPanelBackground;
            KiSS4.Gui.GuiConfig.ButtonBackColorEnabled = colorSet.KissButtonBackground;
            KiSS4.Gui.GuiConfig.EditBorderColor = colorSet.KissEditControlBorder;
            KiSS4.Gui.GuiConfig.EditColorNormal = colorSet.KissEditControlBackground;
            KiSS4.Gui.GuiConfig.EditButtonColor = colorSet.KissEditControlBackground;
            KiSS4.Gui.GuiConfig.ControlBorder = colorSet.KissButtonBorder;
            KiSS4.Gui.GuiConfig.GridEditable = colorSet.KissEditControlBackground;
            KiSS4.Gui.GuiConfig.GridReadOnly = colorSet.KissGridCellsBackground;
            KiSS4.Gui.GuiConfig.GridRowEnabledBackColor = colorSet.KissGridCellsBackground;
            KiSS4.Gui.GuiConfig.GridRowLogischGeloeschtBackColor = colorSet.KissGridCellsBackground;
            KiSS4.Gui.GuiConfig.GridRowReadOnly = colorSet.KissGridCellsBackground;
            KiSS4.Gui.GuiConfig.GridRowHighlightedRed = colorSet.B10;
            KiSS4.Gui.GuiConfig.GroupBoxBorderColor = colorSet.KissEditControlBackground;
            KiSS4.Gui.GuiConfig.GroupBoxBackColor = colorSet.KissPanelBackground;
            KiSS4.Gui.GuiConfig.EditColorReadOnly = colorSet.KissEditControlBackgroundReadOnly;
            //KiSS4.Gui.GuiConfig.EditColorRequired =  colorSet.KissEditControlBackgroundReadOnly; //TBD

            KiSS4.Gui.GuiConfig.NavBarBackground = colorSet.B23;
            KiSS4.Gui.GuiConfig.NavBarGroupBackColor = colorSet.KissNavigationPanelBackground;
            KiSS4.Gui.GuiConfig.NavBarGroupHeaderBackColor = colorSet.KissRibbonPageBackground;

            DBUtil.DefaultMessageDialogBackColor = colorSet.KissPanelBackground;
        }
    }
}