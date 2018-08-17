using System;
using System.Drawing;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Fallfuehrung.IBE
{
    public partial class CtlFaDokumente : KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID;
        private int _faLeistungID;

        #endregion

        #endregion

        #region Constructors

        public CtlFaDokumente()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void qryFaDokumente_AfterInsert(object sender, EventArgs e)
        {
            qryFaDokumente[DBO.FaDokumente.FaLeistungID] = _faLeistungID;
            qryFaDokumente[DBO.FaDokumente.Vertraulich] = 0;
            qryFaDokumente[DBO.FaDokumente.DatumErstellung] = DateTime.Today;
            qryFaDokumente[DBO.FaDokumente.BaPersonID_LT] = _baPersonID;
            qryFaDokumente[DBO.FaDokumente.IstBericht] = false;
            qryFaDokumente[DBO.FaDokumente.IsDeleted] = false;
            qryFaDokumente.SetCreator();
        }

        private void qryFaDokumente_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatumErstellung, lblDatumErstellung.Text);
            DBUtil.CheckNotNullField(edtStichwort, lblStichwort.Text);
            qryFaDokumente.SetModifierModified();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "ABSENDER":
                    return qryFaDokumente[DBO.FaDokumente.UserID_Absender];

                case "DOKUMENTID":
                    return qryFaDokumente["FaDokumenteID"];

                case "USERID":
                    return Session.User.UserID;

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL(@"
                                        SELECT UserID
                                        FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                        WHERE FaLeistungID = {0}", qryFaDokumente["FaLeistungID"]);

                case "BAPERSONID":
                    return qryFaDokumente[DBO.FaDokumente.BaPersonID_LT];

                case "FT":
                    return DBUtil.ExecuteScalarSQL(@"
                                        select FAL.BaPersonID
                                        from   dbo.FaFall FAL
                                               inner join dbo.FaLeistung LEI on LEI.FaFallID = FAL.FaFallID
                                        where LEI.FaLeistungID = {0}",
                      qryFaDokumente["FaLeistungID"]);

                case "FALLUSERID":
                    return DBUtil.ExecuteScalarSQL(@"
                                        select FAL.UserID
                                        from   dbo.FaFall FAL
                                               inner join dbo.FaLeistung LEI on LEI.FaFallID = FAL.FaFallID
                                        where LEI.FaLeistungID = {0}",
                      qryFaDokumente["FaLeistungID"]);
            }
            return base.GetContextValue(fieldName);
        }

        public void Init(string maskName, Image maskImage, int baPersonID, int faLeistungID)
        {
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;
            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;

            tabControlSearch.SelectedTabIndex = 0;

            colThemen.ColumnEdit = grdDokumente.GetLOVLookUpEdit("FaThema");
            LoadBetroffenepersonen();
            RunSearch();
        }

        #endregion

        #region Protected Methods

        protected override void RunSearch()
        {
            kissSearch.SelectParameters = new object[] { _faLeistungID };
            base.RunSearch();
        }

        #endregion

        #region Private Static Methods

        private static string GetSQLBetroffenePersonen(bool emptyEntry, int baPersonID, int faLeistungID)
        {
            return string.Format(@"
                DECLARE @CurrentIDsCSV VARCHAR(255);
                DECLARE @EmptyEntry    BIT;
                DECLARE @FaLeistungID  INT;
                DECLARE @BaPersonID    INT;

                DECLARE @TmpOutput TABLE
                (
                    Code INT NULL UNIQUE,
                    Text VARCHAR(255) NOT NULL
                );

                SELECT @EmptyEntry   = {0},
                       @FaLeistungID = {1},
                       @BaPersonID   = {2};

                IF (@EmptyEntry = 1)
                BEGIN
                    INSERT INTO @TmpOutput (Code, Text)
                      SELECT Code = NULL,
                             Text = '';
                END;

                SET @CurrentIDsCSV= (SELECT dbo.ConcDistinct(BaPersonIDs)
                                     FROM dbo.FaDokumente
                                     WHERE FaLeistungID = @FaLeistungID)

                -- Suche von Personen im Klientensystem
                INSERT INTO @TmpOutput (Code, Text)
                  SELECT FCN.Code,
                         FCN.Text
                  FROM dbo.fnFaGetBeteiligtePersonenInstitutionen(@BaPersonID, @CurrentIDsCSV) FCN
                  WHERE Code > 0; -- Nur die Personen anzeigen, keine Institution

                -- Output
                SELECT Code, Text
                FROM @TmpOutput
                ORDER BY CASE
                           WHEN Code IS NULL THEN 0
                           ELSE 1
                         END,
                         Text;", DBUtil.SqlLiteral(emptyEntry), DBUtil.SqlLiteral(faLeistungID), DBUtil.SqlLiteral(baPersonID));
        }

        #endregion

        #region Private Methods

        private void LoadBetroffenepersonen()
        {
            edtBetroffenePersonen.LookupSQL = GetSQLBetroffenePersonen(false, _baPersonID, _faLeistungID);
        }

        #endregion

        #endregion
    }
}