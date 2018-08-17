using System;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public partial class CtlKaVermittlungJobtimalEinsaetze : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _faLeistungId = -1;

        #endregion

        #endregion

        #region Constructors

        public CtlKaVermittlungJobtimalEinsaetze()
        {
            InitializeComponent();

            // HACK: Tabulator springt nicht aus einem KissLookUpEdit, wenn es nicht das letzte seiner Art ist..
            tpgEinsatz.Controls.Add(new KissLookUpEdit { TabIndex = 999, TabStop = false, Visible = false });
            tpgVertrag.Controls.Add(new KissLookUpEdit { TabIndex = 999, TabStop = false, Visible = false });
        }

        #endregion

        #region EventHandlers

        private void btnDetailsEinsatzplatz_Click(object sender, EventArgs e)
        {
            FormController.OpenForm("FrmKaEinsatzorte");
            FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEP", "KaEinsatzplatzID", qryJobtimalVorschlag["KaEinsatzplatzID"]);
        }

        private void edtPensum_Leave(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtPensum.EditValue))
            {
                if (Convert.ToInt32(edtPensum.EditValue) > 100)
                {
                    KissMsg.ShowInfo("CtlKaVermittlungJobtimalEinsaetze", "PensumZuGross", "Pensum darf nicht höher sein als 100%!");
                    ((KissCalcEdit)sender).Focus();
                }
            }
        }

        private void qryJobtimalEinsatz_BeforePost(object sender, EventArgs e)
        {
            qryJobtimalVorschlag["Abschluss"] = edtEinsatzende.EditValue;

            qryJobtimalVorschlag["Arbeitspensum"] = edtPensum.EditValue;
            qryJobtimalVorschlag["Leistungsfaehigkeit"] = edtPensumErgänzungen.EditValue;

            qryJobtimalVorschlag["EinsatzVon"] = edtEinsatzAb.EditValue;
        }

        private void qryJobtimalEinsatz_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryJobtimalVorschlag.RowModified = true;
        }

        private void qryJobtimalVorschlag_AfterFill(object sender, EventArgs e)
        {
            qryJobtimalVorschlag_PositionChanged(sender, null);
        }

        private void qryJobtimalVorschlag_AfterPost(object sender, EventArgs e)
        {
            if (!qryJobtimalEinsatz.Post())
                throw new KissCancelException();
        }

        private void qryJobtimalVorschlag_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.ExecSQL(@"DELETE KaVermittlungEinsatz WHERE KaVermittlungVorschlagID = {0}", qryJobtimalVorschlag["KaVermittlungVorschlagID"]);
            DBUtil.ExecSQL(@"DELETE KaJobtimalVertrag WHERE KaVermittlungVorschlagID = {0}", qryJobtimalVorschlag["KaVermittlungVorschlagID"]);
        }

        private void qryJobtimalVorschlag_PositionChanged(object sender, EventArgs e)
        {
            if (qryJobtimalVorschlag.Count == 0)
            {
                qryJobtimalEinsatz.Fill(DBNull.Value);
                qryJobtimalVertrag.Fill(DBNull.Value);
            }
            else
            {
                qryJobtimalEinsatz.Fill(qryJobtimalVorschlag["KaVermittlungVorschlagID"]);
                qryJobtimalVertrag.Fill(qryJobtimalVorschlag["KaVermittlungVorschlagID"]);
            }
        }

        private void qryJobtimalZwischenbericht_AfterInsert(object sender, EventArgs e)
        {
            qryJobtimalVertrag["KaVermittlungVorschlagID"] = qryJobtimalVorschlag["KaVermittlungVorschlagID"];
            edtDatum.Focus();
        }

        private void tabEinsaetze_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            switch (tabEinsaetze.SelectedTabIndex)
            {
                case 1:
                    // Tab Verträge
                    ActiveSQLQuery = qryJobtimalVertrag;
                    break;

                default:
                    ActiveSQLQuery = qryJobtimalVorschlag;
                    break;
            }
        }

        private void tabEinsaetze_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !ActiveSQLQuery.Post();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FALEISTUNGID":
                    return _faLeistungId;

                case "BAPERSONID":
                    return (int)DBUtil.ExecuteScalarSQL("select BaPersonID from FaLeistung where FaLeistungID = {0}", _faLeistungId);

                case "KAVERMITTLUNGVORSCHLAGID":
                    return qryJobtimalVorschlag["KaVermittlungVorschlagID"];

                case "KAEINSATZPLATZID":
                    return qryJobtimalVorschlag["KaEinsatzplatzID"];

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", _faLeistungId);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string maskName, Image maskImage, int faLeistungId, int baPersonId)
        {
            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;
            _faLeistungId = faLeistungId;

            tabEinsaetze.SelectedTabIndex = 0;
            qryJobtimalVorschlag.Fill(_faLeistungId, Session.User.IsUserKA ? 0 : 1);

            bool mayRead, mayIns, mayUpd, mayDel, mayClose, mayReopen;
            DBUtil.GetFallRights(_faLeistungId, out mayRead, out mayIns, out mayUpd, out mayDel, out mayClose, out mayReopen);
            qryJobtimalEinsatz.CanUpdate = qryJobtimalVorschlag.CanUpdate && DBUtil.UserHasRight("CtlKaVermittlungJobtimalEinsaetze", "U") && mayUpd;
            qryJobtimalEinsatz.CanInsert = qryJobtimalVorschlag.CanInsert && DBUtil.UserHasRight("CtlKaVermittlungJobtimalEinsaetze", "I") && mayIns;
            qryJobtimalEinsatz.CanDelete = qryJobtimalVorschlag.CanDelete && DBUtil.UserHasRight("CtlKaVermittlungJobtimalEinsaetze", "D") && mayDel;
            qryJobtimalEinsatz.EnableBoundFields();

            qryJobtimalVertrag.CanUpdate = DBUtil.UserHasRight("CtlKaVermittlungJobtimalEinsaetze", "U") && mayUpd;
            qryJobtimalVertrag.CanInsert = DBUtil.UserHasRight("CtlKaVermittlungJobtimalEinsaetze", "I") && mayIns;
            qryJobtimalVertrag.CanDelete = DBUtil.UserHasRight("CtlKaVermittlungJobtimalEinsaetze", "D") && mayDel;
            qryJobtimalVertrag.EnableBoundFields();

            colDokumentTyp.ColumnEdit = grdVertrag.GetLOVLookUpEdit("KaJobtimalVertragTyp");

            btnDetailsEinsatzplatz.Enabled = !qryJobtimalVorschlag.IsEmpty &&
                                                  ((DBUtil.UserHasRight("FrmKaEinsatzorte", "U") && mayUpd)
                                                   || (DBUtil.UserHasRight("FrmKaEinsatzorte", "I") && mayIns)
                                                   || (DBUtil.UserHasRight("FrmKaEinsatzorte", "D") && mayDel));
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "SelectRow":
                    if (!param.Contains("KaVermittlungVorschlagID")) param["KaVermittlungVorschlagID"] = -1;

                    tabEinsaetze.SelectedTabIndex = 0;
                    qryJobtimalVorschlag.Find(string.Format("KaVermittlungVorschlagID = {0}", param["KaVermittlungVorschlagID"]));

                    return true;
            }

            // did not understand message
            return false;
        }

        #endregion

        #endregion
    }
}