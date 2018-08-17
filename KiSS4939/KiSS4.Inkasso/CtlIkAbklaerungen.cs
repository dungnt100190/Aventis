using System;
using System.Drawing;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Inkasso
{
    public partial class CtlIkAbklaerungen : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly int _faLeistungID;

        private const string QRY_ABKLAERUNG_DURCH = "AbklaerungDurch";

        #endregion

        #endregion

        #region Constructors

        public CtlIkAbklaerungen(Image titelImage, string titelText, int faLeistungID)
            : this()
        {
            picTitle.Image = titelImage;
            lblTitel.Text = titelText;

            _faLeistungID = faLeistungID;
        }

        public CtlIkAbklaerungen()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlIkAbklaerungen_Load(object sender, EventArgs e)
        {
            SetupDataSource();
            SetupDataMembers();
            SetupFieldNames();

            qryIkAbklaerung.Fill(_faLeistungID);
        }

        private void edtAbklaerungDurch_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                if (dlg.MitarbeiterSuchen(edtAbklaerungDurch.Text, e.ButtonClicked))
                {
                    qryIkAbklaerung[DBO.IkAbklaerung.UserID] = dlg["UserID"];
                    qryIkAbklaerung[QRY_ABKLAERUNG_DURCH] = dlg["Name"];
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void edtAbklaerungsart_EditValueChanged(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtAbklaerungsart.EditValue))
            {
                edtAuswertung.LOVFilter = edtAbklaerungsart.EditValue.ToString();
                edtAuswertung.ReadLOV();
            }
        }

        private void qryIkAbklaerung_AfterInsert(object sender, EventArgs e)
        {
            qryIkAbklaerung[DBO.IkAbklaerung.FaLeistungID] = _faLeistungID;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void SetupFieldNames()
        {
            edtBemerkungen.DataMember = DBO.IkAbklaerung.Bemerkung;
            edtDatumAuswertung.DataMember = DBO.IkAbklaerung.DatumAuswertung;
            edtDatumAbklaerung.DataMember = DBO.IkAbklaerung.DatumAbklaerung;
            edtAbklaerungsart.DataMember = DBO.IkAbklaerung.IkAbklaerungArtCode;
            edtAuswertung.DataMember = DBO.IkAbklaerung.IkAbklaerungAuswertungCode;
            edtAbklaerungDurch.DataMember = QRY_ABKLAERUNG_DURCH;
        }

        #endregion

        #region Private Methods

        private void SetupDataMembers()
        {
            coAbklaerungsDatum.FieldName = DBO.IkAbklaerung.DatumAbklaerung;
            colAabklaerungsart.FieldName = DBO.IkAbklaerung.IkAbklaerungArtCode;
            colAuswertung.FieldName = DBO.IkAbklaerung.IkAbklaerungAuswertungCode;
            colAbklaerungDurch.FieldName = QRY_ABKLAERUNG_DURCH;

            colAabklaerungsart.ColumnEdit = grdIkAbklaerung.GetLOVLookUpEdit("IkAbklaerungArt");
            colAuswertung.ColumnEdit = grdIkAbklaerung.GetLOVLookUpEdit("IkAbklaerungAuswertung");
        }

        private void SetupDataSource()
        {
            edtBemerkungen.DataSource = qryIkAbklaerung;
            edtDatumAuswertung.DataSource = qryIkAbklaerung;
            edtAuswertung.DataSource = qryIkAbklaerung;
            edtDatumAbklaerung.DataSource = qryIkAbklaerung;
            edtAbklaerungsart.DataSource = qryIkAbklaerung;
            edtAbklaerungDurch.DataSource = qryIkAbklaerung;
        }

        #endregion

        #endregion
    }
}