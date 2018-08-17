using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmBarauszahlungErfolgt : KissSearchUserControl
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const string QC_BEWILLIGT_DURCH = "BewilligtDurch";

        #endregion

        #region Private Fields

        private int _faLeistungId;

        #endregion

        #endregion

        #region Constructors

        public CtlVmBarauszahlungErfolgt()
        {
            InitializeComponent();

            qryVmErfolgteBA.SelectStatement = @"
                        SELECT
                          FBU.BuchungsDatum,
                          FBU.Text,
                          BewilligtDurch = dbo.fnGetLastFirstName(FBA.UserID_Modifier, NULL, NULL),
                          FBU.Betrag
                        FROM dbo.FbBarauszahlungAusbezahlt FAA
                          INNER JOIN dbo.FbBarauszahlungZyklus FBZ ON FBZ.FbBarauszahlungZyklusID = FAA.FbBarauszahlungZyklusID
                          INNER JOIN dbo.FbBarauszahlungAuftrag FBA ON FBA.FbBarauszahlungAuftragID = FBZ.FbBarauszahlungAuftragID
                          INNER JOIN dbo.FbBuchung FBU ON FBU.FbBuchungID = FAA.FbBuchungID
                        WHERE FBA.FaLeistungID = {0}
                        --- AND FBU.Betrag >= {edtSucheBetragVon}
                        --- AND FBU.Betrag <= {edtSucheBetragBis}
                        --- AND FBU.BuchungsDatum >= {edtSucheDatumVon}
                        --- AND FBU.BuchungsDatum < DATEADD(day, 1, {edtSucheDatumBis})
                        --- AND FBU.Text LIKE dbo.fnReplaceWildcard({edtSucheText})";
        }

        #endregion

        #region EventHandlers

        private void CtlVmBarauszahlungErfolgt_Load(object sender, EventArgs e)
        {
            SetupFieldNames();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int faLeistungId)
        {
            this.picTitel.Image = titleImage;
            _faLeistungId = faLeistungId;

            this.kissSearch.SelectParameters = new object[] { _faLeistungId };

            NewSearch();
            tabControlSearch.SelectTab(this.tpgListe);
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
        }

        protected override void RunSearch()
        {
            if (!string.IsNullOrEmpty(edtSucheBetragVon.Text) && !string.IsNullOrEmpty(edtSucheBetragBis.Text)
                && Convert.ToInt32(edtSucheBetragVon.Text) > Convert.ToInt32(edtSucheBetragBis.Text))
            {
                throw new KissInfoException("'Betrag von' darf nicht grösser sein als 'Betrag bis'.", edtSucheBetragVon);
            }

            if (edtSucheDatumVon.DateTime != null && edtSucheDatumBis.DateTime != null
                && edtSucheDatumVon.DateTime > edtSucheDatumBis.DateTime)
            {
                throw new KissInfoException("'Datum von' darf nicht grösser sein als 'Datum bis'.", edtSucheDatumVon);
            }

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void SetupFieldNames()
        {
            colDatum.FieldName = DBO.FbBuchung.BuchungsDatum;
            colText.FieldName = DBO.FbBuchung.Text;
            colBewilligtDurch.FieldName = QC_BEWILLIGT_DURCH;
            colBetrag.FieldName = DBO.FbBuchung.Betrag;
        }

        #endregion

        #endregion
    }
}