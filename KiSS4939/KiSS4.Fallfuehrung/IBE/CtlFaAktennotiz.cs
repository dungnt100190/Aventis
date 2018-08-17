using System;
using System.Drawing;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Fallfuehrung.IBE
{
    public partial class CtlFaAktennotiz : KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        int _baPersonID;
        int _faLeistungID;
        private string _klientName;

        #endregion

        #endregion

        #region Constructors

        public CtlFaAktennotiz()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void qryFaAktennotiz_AfterInsert(object sender, EventArgs e)
        {
            qryFaAktennotiz["FaLeistungID"] = _faLeistungID;
            qryFaAktennotiz["Datum"] = DateTime.Today;
            qryFaAktennotiz["UserID"] = Session.User.UserID;
            qryFaAktennotiz["User"] = Session.User.LastName + " " + Session.User.FirstName;
            qryFaAktennotiz["Vertraulich"] = 0;
            qryFaAktennotiz["Kontaktpartner"] = _klientName;
            qryFaAktennotiz[DBO.FaAktennotizen.IsDeleted] = false;
            qryFaAktennotiz.SetCreator();
            edtDatum.Focus();
        }

        private void qryFaAktennotiz_BeforePost(object sender, EventArgs e)
        {
            //Themenliste
            qryFaAktennotiz["FaThemaText"] = edtFaDokBesprTyp.GetDisplayText(edtFaDokBesprTyp.EditValue);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void FillQuery()
        {
            kissSearch.SelectParameters = new object[] { _faLeistungID };
            qryFaAktennotiz.Fill(_faLeistungID);
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FAAKTENNOTIZID":
                    return qryFaAktennotiz["FaAktennotizID"];
                case "FALEISTUNGID":
                    return qryFaAktennotiz["FaLeistungID"];
                case "BAPERSONID":
                    return _baPersonID;
                case "USERID":
                    return qryFaAktennotiz["UserID"];
                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL(@"
                        SELECT UserID
                        FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                        WHERE FaLeistungID = {0};",
                        qryFaAktennotiz["FaLeistungID"]);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string maskName, Image maskImage, int baPersonID, int faLeistungID)
        {
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;
            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT Name = Name + ISNULL(' ' + Vorname, '')
                FROM dbo.BaPerson WITH(READUNCOMMITTED)
                WHERE BaPersonID = {0};", _baPersonID);

            _klientName = Utils.ConvertToString(qry["Name"]);
            LoadBetroffenePersonen();
            FillQuery();
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
                                     FROM dbo.FaAktennotizen AKN
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

        private void LoadBetroffenePersonen()
        {
            edtBetroffenePersonen.LookupSQL = GetSQLBetroffenePersonen(false, _baPersonID, _faLeistungID);
        }

        #endregion

        #endregion
    }
}