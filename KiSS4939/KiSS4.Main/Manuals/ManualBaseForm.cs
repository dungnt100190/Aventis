using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Main
{
    public partial class ManualBaseForm : KissChildForm
    {
        protected Dictionary<int, string> _manualsLangAsKey;

        public ManualBaseForm()
        {
            InitializeComponent();
            _manualsLangAsKey = new Dictionary<int, string>();
        }

        private void ManualBaseForm_Shown(object sender, EventArgs e)
        {
            try
            {
                if (Session.Active && Session.User != null)
                {
                    foreach (var manual in _manualsLangAsKey)
                    {
                        if (Session.User.LanguageCode == manual.Key)
                        {
                            Help.ShowHelp(this, manual.Value, HelpNavigator.Topic);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorOpeningHelpFile", "Fehler beim Anzeigen der Hilfedatei.", ex);
            }
            finally
            {
                Close();
            }
        }
    }
}