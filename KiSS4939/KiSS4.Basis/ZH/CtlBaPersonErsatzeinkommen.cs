using System;
using System.ComponentModel;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis.ZH
{
    public partial class CtlBaPersonErsatzeinkommen : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID = -1;

        #endregion

        #endregion

        #region Constructors

        public CtlBaPersonErsatzeinkommen()
        {
            InitializeComponent();

            colBaErsatzeinkommenCode.ColumnEdit = grdBaErsatzeinkommen.GetLOVLookUpEdit((SqlQuery)edtBaErsatzeinkommenCode.Properties.DataSource);
        }

        #endregion

        #region Properties

        [DefaultValue(-1)]
        public int BaPersonID
        {
            get { return _baPersonID; }
            set
            {
                _baPersonID = value;
                qryBaErsatzeinkommen.Fill(value);
            }
        }

        #endregion

        #region EventHandlers

        private void edtBaErsatzeinkommenCode_EditValueChanged(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtBaErsatzeinkommenCode.EditValue))
            {
                lblBetragALBV.Visible = (int)edtBaErsatzeinkommenCode.EditValue == 13;
                edtBetragALBV.Visible = (int)edtBaErsatzeinkommenCode.EditValue == 13;
                lblCHF.Visible = (int)edtBaErsatzeinkommenCode.EditValue == 13;
            }
        }

        private void qryBaErsatzeinkommen_AfterFill(object sender, EventArgs e)
        {
            if (qryBaErsatzeinkommen.Count == 0 && qryBaErsatzeinkommen.CanInsert)
            {
                qryBaErsatzeinkommen.Insert();
            }
        }

        private void qryBaErsatzeinkommen_AfterInsert(object sender, EventArgs e)
        {
            qryBaErsatzeinkommen["BaPersonID"] = BaPersonID;
            edtBaErsatzeinkommenCode.Focus();
        }

        private void qryBaErsatzeinkommen_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBaErsatzeinkommenCode, lblBaErsatzeinkommenCode.Text);
        }

        private void qryBaErsatzeinkommen_PositionChanged(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryBaErsatzeinkommen["BaErsatzeinkommenCode"]))
            {
                lblBetragALBV.Visible = (int)qryBaErsatzeinkommen["BaErsatzeinkommenCode"] == 13;
                edtBetragALBV.Visible = (int)qryBaErsatzeinkommen["BaErsatzeinkommenCode"] == 13;
                lblCHF.Visible = (int)qryBaErsatzeinkommen["BaErsatzeinkommenCode"] == 13;
            }
            else
            {
                lblBetragALBV.Visible = false;
                edtBetragALBV.Visible = false;
                lblCHF.Visible = false;
            }
        }

        #endregion
    }
}