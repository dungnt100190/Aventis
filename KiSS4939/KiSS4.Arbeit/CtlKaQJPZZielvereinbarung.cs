using System;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaQJPZZielvereinbarung.
    /// </summary>
    public partial class CtlKaQJPZZielvereinbarung : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID;
        private int _faLeistungID;

        #endregion

        #endregion

        #region Constructors

        public CtlKaQJPZZielvereinbarung()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlKaQJPZZielvereinbarung_Load(object sender, System.EventArgs e)
        {
            SetEditMode();
            FillZielvereinbarung();
        }

        private void qryZielvereinbarung_AfterInsert(object sender, System.EventArgs e)
        {
            qryZielvereinbarung["FaLeistungID"] = _faLeistungID;
            qryZielvereinbarung["SichtbarSDFlag"] = KaUtil.IsVisibleSD(_baPersonID);
        }

        private void qryZielvereinbarung_AfterPost(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(qryZielvereinbarung["ZielvereinbarungDokID"]))
            {
                DBUtil.ExecSQL(@"UPDATE KaQJPZZielvereinbarung SET ZielvereinbarungDokID = NULL WHERE FaLeistungID = {0}", _faLeistungID);
            }
            else
            {
                DBUtil.ExecSQL(@"UPDATE KaQJPZZielvereinbarung SET ZielvereinbarungDokID = {0} WHERE FaLeistungID = {1}", Convert.ToInt32(qryZielvereinbarung["ZielvereinbarungDokID"]), _faLeistungID);
            }
            FillZielvereinbarung();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return DBUtil.ExecuteScalarSQL(@"SELECT BaPersonID FROM FaLeistung WHERE FaLeistungID = {0}", _faLeistungID);

                case "FALEISTUNGID":
                    return _faLeistungID;

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("SELECT UserID FROM FaLeistung WHERE FaLeistungID = {0}", _faLeistungID);

            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;
        }

        #endregion

        #region Private Methods

        private void FillZielvereinbarung()
        {
            qryZielvereinbarung.Fill(@"
                SELECT	KAZ.SichtbarSDFlag,
                        KAZ.FaLeistungID,
                        KAZ.ZielDatum,
                        KAZ.VereinbartesZiel,
                        KAZ.ErreichenBis,
                        KAZ.ZielDatum,
                        KAZ.KriterienPruefen,
                        KAZ.BeurteilungID,
                        KAZ.DatumBeurteilung,
                        KAZ.ZielvereinbarungDokID,
                        KAZ.KaQJPZZielvereinbarungID,
                        Beurteilung = dbo.fnLOVText('ZielErreicht', KAZ.BeurteilungID)
                FROM	KaQJPZZielvereinbarung KAZ
                WHERE	KAZ.FaLeistungID = {0}
                  AND (KAZ.SichtbarSDFlag = 1 OR KAZ.SichtbarSDFlag = {1})
                ORDER BY KAZ.ZielDatum DESC",
                _faLeistungID, Session.User.IsUserKA ? 0 : 1);
        }

        private void SetEditMode()
        {
            //DBUtil.GetFallRights(this.FaLeistungID, out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);
            //qryZielvereinbarung.CanUpdate = MayUpd && DBUtil.UserHasRight("KaQJPZZielvereinbarung", "U");
            //qryZielvereinbarung.CanInsert = MayIns && DBUtil.UserHasRight("KaQJPZZielvereinbarung", "I");
            //qryZielvereinbarung.CanDelete = MayDel && DBUtil.UserHasRight("KaQJPZZielvereinbarung", "D");

            DBUtil.ApplyFallRightsToSqlQuery(_faLeistungID, qryZielvereinbarung);
            DBUtil.ApplyUserRightsToSqlQuery("CtlKaQJPZZielvereinbarung", qryZielvereinbarung);

            qryZielvereinbarung.EnableBoundFields();
        }

        private bool ZielvereinbarungExists()
        {
            var rslt = false;

            rslt = Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*) FROM KaQJPZZielvereinbarung WHERE FaLeistungID = {0}",
                _faLeistungID)
                ) > 0;

            return rslt;
        }

        #endregion

        #endregion
    }
}