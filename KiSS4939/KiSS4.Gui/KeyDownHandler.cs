using System;
using System.Collections.Generic;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using KiSS4.DB;

namespace KiSS4.Gui
{
    public static class KeyDownHandler
    {
        public static void OnKeyDown(Control activeControl, Control parent, KeyEventArgs e)
        {
            if (e.Handled)
            {
                return;
            }

            var ctl = activeControl;

            while (ctl is UserControl)
            {
                ctl = ((UserControl)ctl).ActiveControl;
            }

            if (ctl == null)
            {
                ctl = parent;
            }
            else if (ctl is TextBoxMaskBox)
            {
                ctl = ctl.Parent;
            }

            #region Show DlgTranslateMask

            if (e.KeyCode == Keys.F7 && e.Shift && e.Control)
            {
                if (ctl == null || ctl.Parent == null || parent.GetType().FullName.Equals("KiSS4.Main.FrmLogin"))
                {
                    //KissMsg.ShowInfo("KissForm", "ShowTranslationDialogNotPossible", "Aus dieser Maske kann keine Übersetzung erfolgen.");
                    return;
                }
                try
                {
                    // Create a list of all possible controls and the form to show.
                    // If only one to translate show translate dialog, otherwise show first dialog to let the user select what to translate

                    // create a list to hold all controls to translate
                    List<Control> controls = new List<Control>();
                    Control trans = ctl;

                    // fill list
                    while (true)
                    {
                        // loop until we reach a control or a form
                        while (!(trans is KissComplexControl || trans is KissForm))
                        {
                            if (trans == null)
                            {
                                break;
                            }

                            trans = trans.Parent;
                        }

                        if (trans == null)
                        {
                            break;
                        }

                        // add control to list
                        controls.Add(trans);

                        // check if we reached end (form)
                        if (trans is KissForm || trans.Parent == null)
                        {
                            // stop loop
                            break;
                        }

                        // set parent to prevent endless loop
                        trans = trans.Parent;
                    }

                    // check amount of items in list
                    switch (controls.Count)
                    {
                        case 0:
                            // no items to translate, cancel
                            return;

                        case 1:
                            // just one item found, select this to translate
                            trans = controls[0];
                            break;

                        default:
                            // more than one item found, use dialog to let the user select the control to translate
                            DlgSelectTranslation dlg = new DlgSelectTranslation(controls);

                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                // get the control the user selected
                                trans = dlg.SelectedControl;

                                // validate
                                if (trans == null)
                                {
                                    // invalid, throw error
                                    throw new KissErrorException("No control was returned from dialog, cannot proceed.");
                                }
                            }
                            else
                            {
                                // user pressed cancel
                                return;
                            }
                            break;
                    }

                    // type specific handling of the translation
                    if (trans is KissComplexControl)
                    {
                        KissComplexControl c = (KissComplexControl)trans;
                        KissDialog dlg = new DlgTranslateMask(c.GetType().Name, c.Translation.Components);
                        dlg.ShowDialog();
                    }
                    else if (trans is KissForm)
                    {
                        KissForm f = (KissForm)trans;
                        KissDialog dlg = new DlgTranslateMask(f.GetType().Name, f.Translation.Components);
                        dlg.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError("KissForm", "ShowTranslationDialogFailed", "Fehler beim Öffnen des Übersetzungsfensters", ex.Message, ex);
                }
            }

            #endregion Show DlgTranslateMask

            if ((ctl is BaseEdit))
            {
                if (e.Modifiers == Keys.None)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Return:
                            if ((ctl is KissTextEdit && ((KissTextEdit)ctl).EnterKeyEvent == null) ||
                                 (ctl is KissDateEdit && ((KissDateEdit)ctl).EnterKeyEvent == null) ||
                                 (ctl is KissButtonEdit && ((KissButtonEdit)ctl).EnterKeyEvent == null) ||
                                 (ctl is KissCalcEdit && ((KissCalcEdit)ctl).EnterKeyEvent == null) ||
                                 (ctl is KissComboBox && ((KissComboBox)ctl).EnterKeyEvent == null) ||
                                 (ctl is KissLookUpEdit && ((KissLookUpEdit)ctl).EnterKeyEvent == null))
                            {
                                SendKeys.SendWait("{TAB}");
                                e.Handled = true;
                            }
                            break;

                        case Keys.Up:
                            if (!((ctl is DateEdit) && ((DateEdit)ctl).IsPopupOpen) &&
                                 !((ctl is KissLookUpEdit) && ((KissLookUpEdit)ctl).IsPopupOpen) &&
                                 !((ctl is KissComboBox) && ((KissComboBox)ctl).IsPopupOpen) &&
                                 !(ctl is KissMemoEdit) &&
                                 !(ctl.Parent is KissGrid))
                            {
                                SendKeys.SendWait("+{TAB}");
                                e.Handled = true;
                            }
                            break;

                        case Keys.Down:
                            if (!((ctl is DateEdit) && ((DateEdit)ctl).IsPopupOpen) &&
                                 !((ctl is KissLookUpEdit) && ((KissLookUpEdit)ctl).IsPopupOpen) &&
                                 !((ctl is KissComboBox) && ((KissComboBox)ctl).IsPopupOpen) &&
                                 !(ctl is KissMemoEdit) &&
                                 !(ctl.Parent is KissGrid))
                            {
                                SendKeys.SendWait("{TAB}");
                                e.Handled = true;
                            }
                            break;

                        case Keys.F1:
                            {
                                if (!DBUtil.IsEmpty(ctl.Tag))
                                {
                                    new KissHelpDialog(ctl.Tag.ToString());
                                }
                                break;
                            }
                    }
                }
            }
        }
    }
}