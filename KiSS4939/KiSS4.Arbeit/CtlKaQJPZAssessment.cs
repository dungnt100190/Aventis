using System.Drawing;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public partial class CtlKaQJPZAssessment : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID;
        private int _faLeistungID;

        #endregion

        #endregion

        #region Constructors

        public CtlKaQJPZAssessment()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "BAPERSONID":
                    return DBUtil.ExecuteScalarSQL(@"SELECT BaPersonID FROM FaLeistung WHERE FaLeistungID = {0}", _faLeistungID);

                case "FALEISTUNGID":
                    return _faLeistungID;

                case "OWNERUSERID":
                    return DBUtil.ExecuteScalarSQL(@"SELECT UserID FROM FaLeistung WHERE FaLeistungID = {0}", _faLeistungID);
            }

            return base.GetContextValue(FieldName);
        }

        public void Init(string maskName, Image maskImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitle.Text = maskName;
            this.imageTitle.Image = maskImage;
            _faLeistungID = FaLeistungID;
            _baPersonID = BaPersonID;

            SetupDataSource();
            SetupDataMember();

            SetupEditMode();
            FillQuery();
        }

        #endregion

        #region Private Methods

        private bool AssessmentExists()
        {
            bool? exists = DBUtil.ExecuteScalarSQL(@"
                SELECT CONVERT(BIT, ISNULL((SELECT TOP 1 1
                FROM dbo.KaQJPZAssessment QJA
                WHERE QJA.FaLeistungID = {0}), 0))", _faLeistungID) as bool?;

            return exists.HasValue ? exists.Value : false;
        }

        private void FillQuery()
        {
            if (!AssessmentExists() && qryQJAssessment.CanInsert && qryQJAssessment.CanUpdate)
            {
                DBUtil.ExecSQL(@"
                  INSERT INTO KaQJPZAssessment (FaLeistungID, SichtbarSDFlag, Creator, Modifier)
                  VALUES ({0}, {1}, {2}, {2})",
                               _faLeistungID, KaUtil.IsVisibleSD(_baPersonID), DBUtil.GetDBRowCreatorModifier());
            }

            qryQJAssessment.Fill(_faLeistungID, Session.User.IsUserKA ? 0 : 1);
        }

        private void SetupDataMember()
        {
            edtDatum.DataMember = DBO.KaQJPZAssessment.DatumAssessment;
            edtProjGefaehrGrund.DataMember = DBO.KaQJPZAssessment.ProjGefaehrGrund;
            chkA.DataMember = DBO.KaQJPZAssessment.AufgA;
            chkB.DataMember = DBO.KaQJPZAssessment.AufgB;
            chkC.DataMember = DBO.KaQJPZAssessment.AufgC;
            chkD.DataMember = DBO.KaQJPZAssessment.AufgD;
            chkProjGefaehrdet.DataMember = DBO.KaQJPZAssessment.ProjGefaehrFlag;
        }

        private void SetupDataSource()
        {
            edtDatum.DataSource = qryQJAssessment;
            edtProjGefaehrGrund.DataSource = qryQJAssessment;
            chkA.DataSource = qryQJAssessment;
            chkB.DataSource = qryQJAssessment;
            chkC.DataSource = qryQJAssessment;
            chkD.DataSource = qryQJAssessment;
            chkProjGefaehrdet.DataSource = qryQJAssessment;
        }

        private void SetupEditMode()
        {
            bool MayRead;
            bool MayIns;
            bool MayUpd;
            bool MayDel;
            bool MayClose;
            bool MayReopen;
            DBUtil.GetFallRights(_faLeistungID, out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);
            qryQJAssessment.CanUpdate = MayUpd && DBUtil.UserHasRight(Name, "U");
            qryQJAssessment.CanInsert = MayIns && DBUtil.UserHasRight(Name, "I");
            qryQJAssessment.EnableBoundFields();
        }

        #endregion

        private void chkProjGefaehrdet_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        #endregion
    }
}