using System;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public partial class CtlKaVermittlungSIEinsaetze : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _faLeistungId = -1;

        #endregion

        #endregion

        #region Constructors

        public CtlKaVermittlungSIEinsaetze()
        {
            InitializeComponent();

            // HACK: Tabulator springt nicht aus einem KissLookUpEdit, wenn es nicht das letzte seiner Art ist..
            tpgEinsatz.Controls.Add(new KissLookUpEdit { TabIndex = 999, TabStop = false, Visible = false });
            tpgVorschlag.Controls.Add(new KissLookUpEdit { TabIndex = 999, TabStop = false, Visible = false });
            tpgZwischenbericht.Controls.Add(new KissLookUpEdit { TabIndex = 999, TabStop = false, Visible = false });
        }

        #endregion

        #region EventHandlers

        private void btnDetailsEinsatzplatz_Click(object sender, EventArgs e)
        {
            FormController.OpenForm("FrmKaEinsatzorte");
            FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEP", "KaEinsatzplatzID", qrySIVorschlag["KaEinsatzplatzID"]);
        }

        private void edtPensum_Leave(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtPensum.EditValue))
            {
                if (Convert.ToInt32(edtPensum.EditValue) > 100)
                {
                    KissMsg.ShowInfo("CtlKaVermittlungSIEinsaetze", "PensumZuGross", "Pensum darf nicht höher sein als 100%!");
                    ((KissCalcEdit)sender).Focus();
                }
            }
        }

        private void edtResultat_EditValueChanged(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtResultat.EditValue))
            {
                edtAblehnungsgrund.EditMode = qrySIVorschlag.CanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
            }
            else
            {
                if (Convert.ToInt32(edtResultat.EditValue) == 1)
                {
                    if (qrySIVorschlag.CanUpdate)
                    {
                        edtAblehnungsgrund.EditValue = null;
                    }
                    edtAblehnungsgrund.EditMode = EditModeType.ReadOnly;
                }
                else
                {
                    edtAblehnungsgrund.EditMode = qrySIVorschlag.CanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
                }
            }
        }

        private void qrySIEinsatz_BeforePost(object sender, EventArgs e)
        {
            qrySIVorschlag["Abschluss"] = edtEinsatzende.EditValue;

            qrySIVorschlag["Arbeitspensum"] = edtPensum.EditValue;

            qrySIVorschlag["EinsatzVon"] = edtEinsatzAb.EditValue;
        }

        private void qrySIEinsatz_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qrySIVorschlag.RowModified = true;
        }

        private void qrySIVorschlag_AfterFill(object sender, EventArgs e)
        {
            qrySIVorschlag_PositionChanged(sender, null);
        }

        private void qrySIVorschlag_AfterPost(object sender, EventArgs e)
        {
            if (!qrySIEinsatz.Post())
                throw new KissCancelException();
        }

        private void qrySIVorschlag_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.ExecSQL(@"DELETE KaVermittlungEinsatz WHERE KaVermittlungVorschlagID = {0}", qrySIVorschlag["KaVermittlungVorschlagID"]);
            DBUtil.ExecSQL(@"DELETE KaVermittlungSIZwischenbericht WHERE KaVermittlungVorschlagID = {0}", qrySIVorschlag["KaVermittlungVorschlagID"]);
        }

        private void qrySIVorschlag_PositionChanged(object sender, EventArgs e)
        {
            if (qrySIVorschlag.Count == 0)
            {
                qrySIEinsatz.Fill(DBNull.Value);
                qrySIZwischenbericht.Fill(DBNull.Value);
            }
            else
            {
                qrySIEinsatz.Fill(qrySIVorschlag["KaVermittlungVorschlagID"]);
                qrySIZwischenbericht.Fill(qrySIVorschlag["KaVermittlungVorschlagID"]);
            }
        }

        private void qrySIZwischenbericht_AfterInsert(object sender, EventArgs e)
        {
            qrySIZwischenbericht["KaVermittlungVorschlagID"] = qrySIVorschlag["KaVermittlungVorschlagID"];
            edtAnfrage.Focus();
        }

        private void tabEinsaetze_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            switch (tabEinsaetze.SelectedTabIndex)
            {
                case 2:
                    // Tab Zwischenbericht
                    ActiveSQLQuery = qrySIZwischenbericht;
                    break;

                default:
                    ActiveSQLQuery = qrySIVorschlag;
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
                    return qrySIVorschlag["KaVermittlungVorschlagID"];
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
            qrySIVorschlag.Fill(_faLeistungId, Session.User.IsUserKA ? 0 : 1);

            bool mayRead, mayIns, mayUpd, mayDel, mayClose, mayReopen;
            DBUtil.GetFallRights(_faLeistungId, out mayRead, out mayIns, out mayUpd, out mayDel, out mayClose, out mayReopen);
            qrySIEinsatz.CanUpdate = qrySIVorschlag.CanUpdate && DBUtil.UserHasRight("CtlKaVermittlungSIEinsaetze", "U") && mayUpd;
            qrySIEinsatz.CanInsert = qrySIVorschlag.CanInsert && DBUtil.UserHasRight("CtlKaVermittlungSIEinsaetze", "I") && mayIns;
            qrySIEinsatz.CanDelete = qrySIVorschlag.CanDelete && DBUtil.UserHasRight("CtlKaVermittlungSIEinsaetze", "D") && mayDel;
            qrySIEinsatz.EnableBoundFields();

            qrySIZwischenbericht.CanUpdate = DBUtil.UserHasRight("CtlKaVermittlungSIEinsaetze", "U") && mayUpd;
            qrySIZwischenbericht.CanInsert = DBUtil.UserHasRight("CtlKaVermittlungSIEinsaetze", "I") && mayIns;
            qrySIZwischenbericht.CanDelete = DBUtil.UserHasRight("CtlKaVermittlungSIEinsaetze", "D") && mayDel;
            qrySIZwischenbericht.EnableBoundFields();

            colResultat.ColumnEdit = grdVermittlungSiEinsaetze.GetLOVLookUpEdit("KaVorschlagResultat");
            colIntervention.ColumnEdit = grdZwischenbericht.GetLOVLookUpEdit("KaVermittlungSIEinsatzIntervention");
            colVorgMassnahme.ColumnEdit = grdZwischenbericht.GetLOVLookUpEdit("KaVermittlungSIEinsatzMassnahme");

            btnDetailsEinsatzplatz.Enabled = !qrySIVorschlag.IsEmpty &&
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
                    qrySIVorschlag.Find(string.Format("KaVermittlungVorschlagID = {0}", param["KaVermittlungVorschlagID"]));

                    return true;
            }

            // did not understand message
            return false;
        }

        #endregion

        #endregion
    }
}