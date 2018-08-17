using System;
using System.Data;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    public partial class CtlStdZahlungsmodi : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly ModulID _modul;

        #endregion

        #region Private Fields

        private string _keyPath;

        #endregion

        #endregion

        #region Constructors

        public CtlStdZahlungsmodi(ModulID modul)
        {
            InitializeComponent();

            _modul = modul;
        }

        #endregion

        #region EventHandlers

        private void CtlUser_Load(object sender, EventArgs e)
        {
            switch (_modul)
            {
                case ModulID.S: _keyPath = @"System\Sozialhilfe\Zahlungsmodus\"; break;
                case ModulID.A: _keyPath = @"System\Asyl\Zahlungsmodus\"; break;
            }

            colZahlungsartCode.ColumnEdit = grdZahlungsmodus.GetLOVLookUpEdit("KbAuszahlungsArt");
            qryZahlungsmodus.Fill(@"
                SELECT *,
                       Zahlungsmodus = CONVERT(VARCHAR(200), NULL),
                       ZahlungsartCode = CONVERT(INT, NULL)
                FROM dbo.XConfig
                WHERE KeyPath LIKE {0}+'%'
                ORDER BY KeyPath;",
                _keyPath);
        }

        private void qryZahlungsmodus_AfterFill(object sender, EventArgs e)
        {
            foreach (DataRow row in qryZahlungsmodus.DataTable.Rows)
            {
                row["Zahlungsmodus"] = row["KeyPath"].ToString().Replace(_keyPath, "");

                try
                {
                    row["ZahlungsartCode"] = Convert.ToInt32(row["ValueVarchar"].ToString());
                }
                catch
                {
                }

                row.AcceptChanges();
            }
        }

        private void qryZahlungsmodus_AfterInsert(object sender, EventArgs e)
        {
            edtZahlungsmodus.Focus();
        }

        private void qryZahlungsmodus_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtZahlungsmodus, lblZahlungsmodus.Text);
            DBUtil.CheckNotNullField(edtZahlungsartCode, lblZahlungsartCode.Text);

            qryZahlungsmodus["KeyPath"] = _keyPath + qryZahlungsmodus["Zahlungsmodus"];
            qryZahlungsmodus["ValueVarchar"] = qryZahlungsmodus["ZahlungsartCode"].ToString(); //später noch BaZahlungsweg und ESR
            qryZahlungsmodus["ValueCode"] = 1;
            qryZahlungsmodus["DatumVon"] = new DateTime(1900, 1, 1);
        }

        #endregion
    }
}