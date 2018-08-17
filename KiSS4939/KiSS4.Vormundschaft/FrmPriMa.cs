using System;

using KiSS4.Common;
using KiSS4.DB;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class FrmPriMa : KissSearchForm
    {
        #region Constructors

        public FrmPriMa()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void FrmPriMa_Load(object sender, EventArgs e)
        {
            NewSearch();
        }

        private void qryAdresse_BeforePost(object sender, EventArgs e)
        {
            edtPLZOrt.DoValidate();
            qryAdresse.SetModifierModified();
        }

        private void qryAdresse_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            if (qryPriMa.DataTable.Columns.Contains(e.Column.ColumnName))
            {
                qryPriMa[e.Column.ColumnName] = qryAdresse[e.Column.ColumnName];
            }
        }

        private void qryPriMa_AfterDelete(object sender, EventArgs e)
        {
            DBUtil.NewHistoryVersion();

            DBUtil.ExecSQL(@"
                DELETE
                FROM dbo.BaAdresse
                WHERE VmPriMaID = {0}", qryPriMa[DBO.VmPriMa.VmPriMaID]);

            if (qryPriMa.IsEmpty)
            {
                FillAddressQuery(null);
            }
        }

        private void qryPriMa_AfterFill(object sender, EventArgs e)
        {
            if (qryPriMa.IsEmpty)
            {
                FillAddressQuery(null);
            }

            grdVmPriMa.Focus();
        }

        private void qryPriMa_AfterInsert(object sender, EventArgs e)
        {
            edtTitel.Focus();
        }

        private void qryPriMa_AfterPost(object sender, EventArgs e)
        {
            // #3798 Speichern hat nicht richtig funktioniert
            if (DBUtil.IsEmpty(qryAdresse[DBO.VmPriMa.VmPriMaID]))
            {
                qryAdresse[DBO.VmPriMa.VmPriMaID] = qryPriMa[DBO.VmPriMa.VmPriMaID];
            }

            DBUtil.NewHistoryVersion();

            if (!qryAdresse.Post())
            {
                throw new KissCancelException();
            }
        }

        private void qryPriMa_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtName, lblNameVorname.Text);
            DBUtil.CheckNotNullField(edtVorname, lblNameVorname.Text);

            if (!edtVersichertennummer.ValidateVersNr(true, false))
            {
                // set focus
                edtVersichertennummer.Focus();

                // cancel, message already shown
                throw new KissCancelException();
            }
        }

        private void qryPriMa_PositionChanged(object sender, EventArgs e)
        {
            int? vmPriMaID = null;

            if (!DBUtil.IsEmpty(qryPriMa[DBO.VmPriMa.VmPriMaID]))
            {
                vmPriMaID = Convert.ToInt32(qryPriMa[DBO.VmPriMa.VmPriMaID]);
            }

            // Adresse
            FillAddressQuery(vmPriMaID);

            if (qryAdresse.Count == 0)
            {
                qryAdresse.Insert(null);
                qryAdresse.SetCreator();
                qryAdresse.SetModifierModified();
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void FillAddressQuery(int? vmPriMaID)
        {
            string sql = @"
                SELECT BaAdresseID,
                       BaPersonID,
                       BaInstitutionID,
                       PlatzierungInstID,
                       DatumVon,
                       DatumBis,
                       AdresseCode,
                       AdressZusatz = ADR.Zusatz,
                       Strasse,
                       HausNr,
                       Postfach,
                       PLZ,
                       Ort,
                       Kanton,
                       BaLandID,
                       OrtschaftCode,
                       Bemerkung,
                       PlatzierungsartCode,
                       AdresseGesperrt = ADR.Gesperrt,
                       VmMandantID,
                       VmPriMaID,
                       KaBetriebID,
                       Modifier,
                       Modified,
                       Creator,
                       Created
                FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
                WHERE 1=2";

            // check if we have an id or just want to get structure without any data
            if (vmPriMaID != null)
            {
                sql = sql.Replace("1=2", string.Format("ADR.{0} = {1}", DBO.VmPriMa.VmPriMaID, vmPriMaID.Value));
            }

            qryAdresse.Fill(sql);
        }

        #endregion

        #endregion
    }
}