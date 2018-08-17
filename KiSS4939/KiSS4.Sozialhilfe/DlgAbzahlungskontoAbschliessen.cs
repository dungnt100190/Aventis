using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Sozialhilfe
{
    public partial class DlgAbzahlungskontoAbschliessen : KissDialog
    {
        #region Constructors

        public DlgAbzahlungskontoAbschliessen()
        {
            InitializeComponent();
        }

        public DlgAbzahlungskontoAbschliessen(decimal betrag)
            : this()
        {
            edtBetrag.EditValue = betrag;

            if (DBUtil.GetConfigBool(@"System\Sozialhilfe\AbschliessenMitBetragEditierbar", false))
            {
                edtBetrag.EditMode = EditModeType.Required;
            }
            else
            {
                edtBetrag.EditMode = EditModeType.ReadOnly;
            }
        }

        #endregion

        #region Properties

        public LOV.AbzahlungskontoAbschlussgrund Abschlussgrund
        {
            get; private set;
        }

        public decimal Betrag
        {
            get { return edtBetrag.EditValue as decimal? ?? 0; }
        }

        #endregion

        #region EventHandlers

        private void btnKontoNichtAusgleichen_Click(object sender, EventArgs e)
        {
            Abschlussgrund = LOV.AbzahlungskontoAbschlussgrund.KontoWirdNichtAusgeglichen;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnUebergabeAnInkasso_Click(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);
            Abschlussgrund = LOV.AbzahlungskontoAbschlussgrund.UebergabeAnInkasso;

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}