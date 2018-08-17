using System;
using System.Data;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Arbeit
{
    public partial class CtlKaExterneBildung : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonId = -1;

        #endregion

        #endregion

        #region Constructors

        public CtlKaExterneBildung()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnLoeschenZahlung_Click(object sender, EventArgs e)
        {
            if (!qryZahlung.CanDelete) return;
            if (qryZahlung.Count == 0) return;

            qryZahlung.Delete();
        }

        private void btnNeuZahlung_Click(object sender, EventArgs e)
        {
            if (!qryZahlung.Post()) return;
            if (!qryZahlung.CanInsert) return;

            qryZahlung.Insert();
        }

        private void datum_Leave(object sender, EventArgs e)
        {
            if (!CheckDate(edtDatumVon, edtDatumBis))
            {
                KissMsg.ShowInfo("CtlKaExterneBildung", "DauerVonVorBis", "'bis' darf nicht vor 'Dauer von' liegen!");
                ((KissDateEdit)sender).Focus();
            }
        }

        private void qryExterneBildung_AfterFill(object sender, EventArgs e)
        {
            qryExterneBildung_PositionChanged(sender, null);
        }

        private void qryExterneBildung_AfterInsert(object sender, EventArgs e)
        {
            qryExterneBildung[DBO.KaExterneBildung.BaPersonID] = _baPersonId;
            qryExterneBildung[DBO.KaExterneBildung.SichtbarSDFlag] = KaUtil.IsVisibleSD(_baPersonId);
        }

        private void qryExterneBildung_AfterPost(object sender, EventArgs e)
        {
            if (!qryZahlung.Post())
            {
                throw new KissCancelException();
            }
        }

        private void qryExterneBildung_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.ExecSQL(@"DELETE dbo.KaExterneBildungZahlung WHERE KaExterneBildungID = {0}", qryExterneBildung[DBO.KaExterneBildung.KaExterneBildungID]);
        }

        private void qryExterneBildung_BeforeInsert(object sender, EventArgs e)
        {
        }

        private void qryExterneBildung_BeforePost(object sender, EventArgs e)
        {
            if (!qryExterneBildung.CanUpdate)
            {
                return;
            }

            DBUtil.CheckNotNullField(edtKaProgramm, lblKaProgramm.Text);
            DBUtil.CheckNotNullField(edtFaLeistung, lblFaLeistung.Text);

            qryZahlung.Post();

            qryExterneBildung[DBO.KaExterneBildung.Kurstyp] = edtKurstyp.EditValue;
        }

        private void qryExterneBildung_PositionChanged(object sender, EventArgs e)
        {
            qryZahlung.Fill(qryExterneBildung.Count == 0 ? DBNull.Value : qryExterneBildung[DBO.KaExterneBildung.KaExterneBildungID]);

            btnLoeschenZahlung.Enabled = (qryZahlung.Count > 0 && qryZahlung.CanUpdate);
            btnNeuZahlung.Enabled = (qryExterneBildung.Count > 0 && qryZahlung.CanInsert);

            LoadFaLeistungQuery();
        }

        private void qryZahlung_AfterDelete(object sender, EventArgs e)
        {
            btnLoeschenZahlung.Enabled = (qryZahlung.Count > 0 && qryZahlung.CanUpdate);
            qryExterneBildung["Zahlungen"] = DBUtil.ExecuteScalarSQL("SELECT SUM(Betrag) FROM dbo.KaExterneBildungZahlung WHERE KaExterneBildungID = {0}", qryExterneBildung["KaExterneBildungID"]);
        }

        private void qryZahlung_AfterInsert(object sender, EventArgs e)
        {
            qryZahlung[DBO.KaExterneBildungZahlung.KaExterneBildungID] = qryExterneBildung[DBO.KaExterneBildung.KaExterneBildungID];
        }

        private void qryZahlung_AfterPost(object sender, EventArgs e)
        {
            btnLoeschenZahlung.Enabled = (qryZahlung.Count > 0 && qryZahlung.CanUpdate);
            qryExterneBildung["Zahlungen"] = DBUtil.ExecuteScalarSQL("SELECT SUM(Betrag) FROM dbo.KaExterneBildungZahlung WHERE KaExterneBildungID = {0}", qryExterneBildung["KaExterneBildungID"]);
        }

        private void qryZahlung_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            qryExterneBildung.RowModified = true;
        }

        private void qryZahlung_PositionChanging(object sender, EventArgs e)
        {
            qryExterneBildung.RowModified = true;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string maskName, Image maskImage, int faLeistungId, int baPersonId)
        {
            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;
            _baPersonId = baPersonId;

            qryExterneBildung.Fill(_baPersonId, Session.User.IsUserKA ? 0 : 1);

            qryZahlung.CanUpdate = qryExterneBildung.CanUpdate && DBUtil.UserHasRight("CtlKaExterneBildung", "U");
            qryZahlung.CanInsert = qryExterneBildung.CanInsert && DBUtil.UserHasRight("CtlKaExterneBildung", "I");
            qryZahlung.CanDelete = qryExterneBildung.CanDelete && DBUtil.UserHasRight("CtlKaExterneBildung", "D");
            qryZahlung.EnableBoundFields();

            colTyp.ColumnEdit = grdExterneBildung.GetLOVLookUpEdit("KaExterneBildungKurstyp");

            LoadFaLeistungQuery();
        }

        #endregion

        #region Private Methods

        private bool CheckDate(KissDateEdit dateFrom, KissDateEdit dateTo)
        {
            bool rslt = true;

            if (!DBUtil.IsEmpty(dateFrom.EditValue) && !DBUtil.IsEmpty(dateTo.EditValue))
            {
                if (Convert.ToDateTime(dateFrom.EditValue) > Convert.ToDateTime(dateTo.EditValue))
                {
                    rslt = false;
                }
            }

            return rslt;
        }

        private void LoadFaLeistungQuery()
        {
            qryFaLeistung.Fill(qryExterneBildung[DBO.KaExterneBildung.FaLeistungID], _baPersonId);
            edtFaLeistung.LoadQuery(qryFaLeistung);
        }

        #endregion

        #endregion
    }
}