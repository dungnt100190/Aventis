using System;
using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Inkasso
{
    public partial class DlgLandesindexKopieren : KissDialog
    {
        #region Constructors

        public DlgLandesindexKopieren(string name)
        {
            InitializeComponent();

            lblVorlage.Text = name;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Das Jahr für die Neuberechnung.
        /// </summary>
        public int Jahr
        {
            get
            {
                var val = (DateTime?)edtMonatJahr.EditValue;
                return val.HasValue ? val.Value.Year : -1;
            }
        }

        /// <summary>
        /// Der Name des neuen Landesindex.
        /// </summary>
        public string LandesindexName
        {
            get { return edtName.Text; }
        }

        /// <summary>
        /// Der Monat, der als 100% für die Neuberechnung gilt.
        /// </summary>
        public int Monat
        {
            get
            {
                var val = (DateTime?)edtMonatJahr.EditValue;
                return val.HasValue ? val.Value.Month : -1;
            }
        }

        /// <summary>
        /// True wenn der Landesindex aufgrund <see cref="Monat"/> und <see cref="Jahr"/> neuberechnet werden soll.
        /// </summary>
        public bool Neuberechnen
        {
            get { return edtNeuberechnung.Checked; }
        }

        #endregion

        #region EventHandlers

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (Neuberechnen && (Jahr < 1 || Monat < 1))
            {
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void edtNeuberechnung_CheckedChanged(object sender, EventArgs e)
        {
            edtMonatJahr.Enabled = edtNeuberechnung.Checked;
            lblHundert.Enabled = edtNeuberechnung.Checked;
            lblVorlage.Enabled = edtNeuberechnung.Checked;
            lblVorlageText.Enabled = edtNeuberechnung.Checked;
        }

        #endregion
    }
}