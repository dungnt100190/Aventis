using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Inkasso
{
    public partial class CtlIkKontoauszug : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID;
        private int _faFallID;
        private int _faLeistungID;

        #endregion

        #endregion

        #region Constructors

        public CtlIkKontoauszug()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnNeueZahlung_Click(object sender, EventArgs e)
        {
            ZahlungOeffnen();
        }

        private void btnRefreshSearch_Click(object sender, EventArgs e)
        {
            FillQueries();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            ResetSearchFields();
            FillQueries();
        }

        private void btnZahlungsdetail_Click(object sender, EventArgs e)
        {
            if (qryKontoauszug.DataTable.Columns.Contains("KbOpAusgleichID") && qryKontoauszug["KbOpAusgleichID"] != null)
            {
                ZahlungOeffnen((int)qryKontoauszug["KbOpAusgleichID"]);
            }
        }

        private void edtForderungsart_EditValueChanged(object sender, EventArgs e)
        {
            FillQueries();
        }

        private void edtGlaeubiger_EditValueChanged(object sender, EventArgs e)
        {
            FillQueries();
        }

        private void grvKontoauszug_DoubleClick(object sender, EventArgs e)
        {
            if (qryKontoauszug["KbOpAusgleichID"] is int && (int)qryKontoauszug["KbOpAusgleichID"] > 0)
            {
                ZahlungOeffnen((int)qryKontoauszug["KbOpAusgleichID"]);
            }
        }

        private void qryKontoauszug_AfterFill(object sender, EventArgs e)
        {
            decimal saldo = (decimal)0.0;

            foreach (DataRow row in qryKontoauszug.DataTable.Rows)
            {
                saldo += (decimal)row["BetragSoll"] - (decimal)row["BetragHaben"];
                row["Saldo"] = saldo;
            }

            qryKontoauszug.DataTable.AcceptChanges();
            qryKontoauszug.RowModified = false;

            grdKontoauszug.DataSource = qryKontoauszug;
        }

        private void qryKontoauszug_PositionChanged(object sender, EventArgs e)
        {
            btnZahlungsdetail.Enabled = (int)qryKontoauszug["KbOpAusgleichID"] > 0;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int baPersonID, object faLeistungID, Int32 faProzessCode)
        {
            _baPersonID = baPersonID;
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;

            // --- if there is faLeistungID --> Schuldner/Gläubiger Mask
            if (faLeistungID is int)
            {
                _faLeistungID = (int)faLeistungID;
                int.TryParse(DBUtil.ExecuteScalarSQL(
                "SELECT FaFallID FROM FaLeistung WHERE FaLeistungID = {0}",
                 faLeistungID).ToString(), out _faFallID);

                btnNeueZahlung.Enabled = true;
            }
            else //overall Kontoauszug
            {
                int.TryParse(DBUtil.ExecuteScalarSQL(
                "SELECT FaFallID FROM FaLeistung WHERE BaPersonID = {0} AND ModulID = 2 ORDER BY DatumVon DESC",
                baPersonID).ToString(), out _faFallID);

                btnNeueZahlung.Enabled = false;
                edtVerdichtet.Checked = true;
            }

            Debug.WriteLine("CtlIkKontoauszug.Init()");
            Debug.WriteLine("baPerson      : " + baPersonID);
            Debug.WriteLine("faLeistungID  : " + faLeistungID);
            Debug.WriteLine("faFallID      : " + _faFallID);
            Debug.WriteLine("faProzessCode : " + faProzessCode);

            if (faProzessCode != 0)
            {
                edtForderungsart.LOVFilter = faProzessCode.ToString();
                edtForderungsart.LOVName = "IkForderungEinmalig";
            }

            qryGlaeubigerSuchen.Fill(_faFallID);

            if (faLeistungID is int && baPersonID != _faFallID)
            {
                edtGlaeubiger.EditValue = baPersonID;
                edtGlaeubiger.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                edtGlaeubiger.EditMode = EditModeType.Normal;
            }

            FillQueries();
        }

        #endregion

        #region Private Methods

        private void FillQueries()
        {
            grdKontoauszug.DataSource = null;

            // Verdichtete Anzeige
            var verdichtet = edtVerdichtet.Checked;
            colBemerkung.Visible = !verdichtet;
            // MemoEdit für Multiline
            colGlaeubiger.ColumnEdit = verdichtet ? cedGlaeubiger : null;

            qryKontoauszug.Fill(_faLeistungID,
                                edtGlaeubiger.EditValue,
                                _baPersonID == _faFallID ? _baPersonID : -1, // falls person <> schuldner --> -1
                                edtForderungsart.EditValue,
                                _faFallID,
                                edtBuchungenVon.EditValue,
                                edtBuchungenBis.EditValue,
                                edtSaldovortrag.Checked,
                                verdichtet);

            grvKontoauszug.MoveLast();
        }

        private void ResetSearchFields()
        {
            edtGlaeubiger.EditValue = null;
            edtBuchungenVon.EditValue = null;
            edtBuchungenBis.EditValue = null;
            edtForderungsart.EditValue = null;
            edtSaldovortrag.Checked = true;
            edtVerdichtet.Checked = false;
        }

        private void ZahlungOeffnen()
        {
            KissDialog dlg = new DlgZahlungenErfassen(_baPersonID, _faLeistungID);

            dlg.ShowDialog();
            qryKontoauszug.Refresh();
        }

        // use this Method if you want to display an already "(Teil-) Ausgeglichene Forderung"
        private void ZahlungOeffnen(int kbOpAusgleichID)
        {
            KissDialog dlg = new DlgZahlungenErfassen(_baPersonID, _faLeistungID, kbOpAusgleichID);

            dlg.ShowDialog();
            qryKontoauszug.Refresh();
        }

        #endregion

        #endregion
    }
}