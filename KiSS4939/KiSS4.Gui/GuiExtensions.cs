using System;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui.Layout;

namespace KiSS4.Gui
{
    public static class GuiExtensions
    {
        public static void SaveLayoutOfChildControls(this Control ctl)
        {
            // --- save layout of all KissUserControls
            foreach (Control childControl in UtilsGui.AllControls(ctl, true))
            {
                if (childControl is KissUserControl)
                {
                    try
                    {
                        ((KissUserControl)childControl).SaveLayout();
                    }
                    catch (LayoutException ex)
                    {
                        KissMsg.ShowError("KissForm",
                                          "LayoutSubTeilweiseGespeichert",
                                          "Layout der Submaske konnte teilweise nicht gespeichert werden.",
                                          ex);
                    }
                    catch (Exception ex)
                    {
                        KissMsg.ShowError("KissForm",
                                          "LayoutSubNichtGespeichert",
                                          "Layout der Submaske konnte nicht gespeichert werden.",
                                          ex);
                    }
                }
            }
        }
    }
}