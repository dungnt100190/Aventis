using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Inkasso
{
    public partial class CtlIkBetreibungenVerlustscheine : KissUserControl
    {
        #region Enumerations

        internal enum Auswahl
        {
            AlleBetreibungenUndVerlustscheine = 1,
            NurAktiveBetreibungen = 2,
            NurAktiveVerlustscheine = 3,
            AlleAktivenBetreibungenUndVerlustscheine = 4
        }

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        private const int DELTA_TWO_BANDS = 2;
        private readonly int _faLeistungID;

        // Empirically found delta required between grid width and sum of bands

        #endregion

        #region Private Fields

        private bool _button1Virgin = true;
        private bool _button3Virgin = true;
        private bool _firstResizeCtlAiBetreibungenVerlustscheine = true;

        #endregion

        #endregion

        #region Constructors

        public CtlIkBetreibungenVerlustscheine(Image icon, string titel, int faLeistungID)
            : this()
        {
            Debug.WriteLine("Constructor(Image, titel, Image)");

            picTitle.Image = icon;
            lblTitel.Text = titel;

            _faLeistungID = faLeistungID;

            Debug.WriteLine("faLeistungID = " + faLeistungID);
        }

        public CtlIkBetreibungenVerlustscheine()
        {
            InitializeComponent();

            Debug.WriteLine("Constructor");

            // --- zeige Betreibungen und Verlustscheine
            btnShowBoth_Click(null, null);

            Resize += CtlAiBetreibungenVerlustscheine_Resize;
            bandedGridView1.RowCellStyle += bandedGridView1_RowCellStyle;

            colBetreibungStatus.ColumnEdit = grdZahlungen.GetLOVLookUpEdit("IkBetreibungStatus");
            colVerlustscheinStatus.ColumnEdit = grdZahlungen.GetLOVLookUpEdit("IkVerlustscheinStatus");
            colVerlustscheinTyp.ColumnEdit = grdZahlungen.GetLOVLookUpEdit("IkVerlustscheinTyp");
        }

        #endregion

        #region EventHandlers

        private void bandedGridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column == null)
            {
                return;
            }

            // --- no custom customization for selected rows
            if (bandedGridView1.GetSelectedRows() != null)
            {
                if (bandedGridView1.GetSelectedRows()[0] == e.RowHandle)
                {
                    Debug.WriteLine("GetSelectedRows()");
                    return;
                }
            }

            if (bandedGridView1.Bands[0].Columns.Contains((BandedGridColumn)e.Column)) // Betreibung
            {
                object colBetrStatusVal = bandedGridView1.GetRowCellValue(e.RowHandle, colBetreibungStatus);

                if (colBetrStatusVal == null)
                {
                    return;
                }

                if (grdBetreibungen.Styles != null && grdBetreibungen.Styles.Count > 0)
                {
                    int betrStatus = Convert.ToInt32(colBetrStatusVal);
                    switch (betrStatus)
                    {
                        case 1:
                            return;

                        case 2:
                            e.Appearance.Assign(grdBetreibungen.Styles["CellYellow"].ToAppearance());
                            return;

                        default:
                            e.Appearance.Assign(grdBetreibungen.Styles["CellYellowLight"].ToAppearance());
                            return;
                    }
                }
            }

            object colVerlStatusVal = bandedGridView1.GetRowCellValue(e.RowHandle, colVerlustscheinStatus);

            if (colVerlStatusVal == null)
            {
                return;
            }

            if (grdBetreibungen.Styles != null && grdBetreibungen.Styles.Count > 0)
            {
                var verlStatus = (int)colVerlStatusVal;

                switch (verlStatus)
                {
                    case 1:
                        return;

                    case 2:
                        e.Appearance.Assign(grdBetreibungen.Styles["CellGreen"].ToAppearance());
                        return;

                    default:
                        e.Appearance.Assign(grdBetreibungen.Styles["CellGreenLight"].ToAppearance());
                        return;
                }
            }
        }

        private void btnClipBetreibungen_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(GetViewExcel(bandedGridView1.Bands[0].View, 0, 7, true, null));
        }

        private void btnClipVerlustscheine_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(GetViewExcel(bandedGridView1.Bands[1].View, 8, 15, true, null));
        }

        private void btnNeueBetreibung_Click(object sender, EventArgs e)
        {
            if (qryBetreibung.CanInsert)
            {
                xTabControl1.SelectedTabIndex = xTabControl1.TabPages.IndexOf(tabBetreibung);
            }

            qryBetreibung.Insert();
        }

        private void btnNeuerVerlustschein_Click(object sender, EventArgs e)
        {
            if (qryBetreibung.CanInsert)
            {
                xTabControl1.SelectedTabIndex = xTabControl1.TabPages.IndexOf(tabVerlustschein);
            }

            qryBetreibung.Insert();
        }

        private void btnNeueZahlung_Click(object sender, EventArgs e)
        {
            if (qryBetreibung.Row != null)
            {
                if (DataRowState.Added == qryBetreibung.Row.RowState)
                {
                    qryBetreibung.RowModified = true;
                }

                qryBetreibung.Post();
            }
        }

        private void btnShowBoth_Click(object sender, EventArgs e)
        {
            GridBand band0 = ((BandedGridView)grdBetreibungen.View).Bands[0];
            GridBand band1 = ((BandedGridView)grdBetreibungen.View).Bands[1];
            band0.Visible = true;
            band1.Visible = true;
            ColBetreibungReserve();
            ColVerlustscheinReserve();
            band0.Width = grdBetreibungen.Width / 2 - DELTA_TWO_BANDS / 2;
            band1.Width = grdBetreibungen.Width - band0.Width - DELTA_TWO_BANDS;
            ColBetreibungUnReserve();
            ColVerlustscheinUnReserve();
        }

        private void btnShowVerlustscheine_Click(object sender, EventArgs e)
        {
            GridBand band0 = ((BandedGridView)grdBetreibungen.View).Bands[0];
            GridBand band1 = ((BandedGridView)grdBetreibungen.View).Bands[1];
            band0.Visible = false;
            band1.Visible = true;

            if (_button3Virgin)
            {
                colVerlustscheinAm.BestFit();
                colVerlustscheinTotal.BestFit();
                colVerlustscheinKosten.BestFit();
                colVerlustscheinZins.BestFit();
                colVerlustscheinNummer.BestFit();
                colVerlustscheinAmt.BestFit();
                colVerlustscheinStatus.BestFit();
                colVerlustscheinTyp.BestFit();
                // prevent shrinking of most important columns
                colVerlustscheinTotal.MinWidth = colVerlustscheinTotal.Width;
                colVerlustscheinNummer.MinWidth = colVerlustscheinNummer.Width;
                _button3Virgin = false; // optimize first time only, then respect user settings
            }

            band1.Width = grdBetreibungen.Width - DELTA_TWO_BANDS; // - band0.Width
        }

        private void buttonShowBetreibungen_Click(object sender, EventArgs e)
        {
            GridBand band0 = ((BandedGridView)grdBetreibungen.View).Bands[0];
            GridBand band1 = ((BandedGridView)grdBetreibungen.View).Bands[1];
            band1.Visible = false;
            band0.Visible = true;

            if (_button1Virgin)
            {
                colBetreibungAm.BestFit();
                colBetreibungFortsetzungAm.BestFit();
                colBetreibungNummer.BestFit();
                colBetreibungStatus.BestFit();
                colBetreibungBetrag.BestFit();
                colBetreibungVon.BestFit();
                colBetreibungBis.BestFit();
                colBetreibungGlaeubiger.BestFit();
                // prevent shrinking of most important columns
                colBetreibungBetrag.MinWidth = colBetreibungBetrag.Width;
                _button1Virgin = false; // optimize first time only, then respect user settings
            }

            band0.Width = grdBetreibungen.Width - DELTA_TWO_BANDS; // - band1.Width
        }

        private void cboAuswahl_EditValueChanged(object sender, EventArgs e)
        {
            OnRefreshData();
        }

        private void cboBetreibungStatus_EditValueChanged(object sender, EventArgs e)
        {
            if (DBNull.Value == cboBetreibungStatus.EditValue || 1 == (int)cboBetreibungStatus.EditValue)
            {
                SetVisibleDetailsBetreibung(false);
            }
            else
            {
                SetVisibleDetailsBetreibung(true);
            }
        }

        private void cboVerlustscheinStatus_EditValueChanged(object sender, EventArgs e)
        {
            if (DBNull.Value == cboVerlustscheinStatus.EditValue || 1 == (int)cboVerlustscheinStatus.EditValue)
            {
                SetVisibleDetailsVerlustschein(false);
            }
            else
            {
                SetVisibleDetailsVerlustschein(true);
            }
        }

        private void CtlAiBetreibungenVerlustscheine_Resize(object sender, EventArgs e)
        {
            // Because this Dialog is parked in FrmFall it is forced to resize AFTER having been
            // loaded. So we have no access to the actual panelGrdBetreibungenVerlustscheine.Width without this event.
            if (_firstResizeCtlAiBetreibungenVerlustscheine)
            {
                btnShowBoth_Click(null, null);
                _firstResizeCtlAiBetreibungenVerlustscheine = false;
            }
        }

        private void CtlIkBetreibungenVerlustscheine_Load(object sender, EventArgs e)
        {
            bandedGridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            bandedGridView1.OptionsView.ShowIndicator = true;
        }

        private void qryBetreibung_AfterInsert(object sender, EventArgs e)
        {
            Debug.WriteLine("qryBetreibung.AfterInsert");

            qryBetreibung["FaLeistungID"] = _faLeistungID;

            Debug.WriteLine("qryBetreibung.AfterInsert");

            qryBetreibung["BetreibungBetrag"] = 0.0;

            qryBetreibung["BetreibungAm"] = DateTime.Today;
            qryBetreibung["VerlustscheinAm"] = DateTime.Today;
            qryBetreibung["VerlustscheinBetrag"] = 0.0;
            qryBetreibung["VerlustscheinZins"] = 0.0;
            qryBetreibung["VerlustscheinKosten"] = 0.0;

            if (xTabControl1.SelectedTab == tabBetreibung)
            {
                qryBetreibung["IkBetreibungStatusCode"] = 2; // Betreibungsverfahren laufend
                qryBetreibung["IkVerlustscheinStatusCode"] = 1; // Kein Verlustschein
                qryBetreibung["IkVerlustscheinTypCode"] = 1; // Aus Betreibung
            }
            else
            {
                qryBetreibung["IkBetreibungStatusCode"] = 1; // Keine Betreibung
                qryBetreibung["IkVerlustscheinStatusCode"] = 2; // Aktiver Verlustschein
                qryBetreibung["IkVerlustscheinTypCode"] = 1; // Aus Betreibung
            }
        }

        private void qryBetreibung_AfterPost(object sender, EventArgs e)
        {
            SetTotals();
        }

        private void qryBetreibung_PositionChanged(object sender, EventArgs e)
        {
            if (qryBetreibung.Row == null)
            {
                return;
            }
            if (DataRowState.Added == qryBetreibung.Row.RowState)
            {
                return; // added row has unset fields, confuses statements below
            }

            qryZahlungen.Fill(qryBetreibung["IkBetreibungID"]);

            decimal totalZahlungen = 0;
            foreach (DataRow row in qryZahlungen.DataTable.Rows)
            {
                totalZahlungen += (decimal)row["Teilbetrag"];
            }

            if (1 == (int)qryBetreibung["IkBetreibungStatusCode"])
            {
                calcSaldoBetreibung.EditValue = DBNull.Value;
            }
            else
            {
                calcSaldoBetreibung.EditValue = (decimal)qryBetreibung["BetreibungBetrag"] - totalZahlungen;
            }
            if (1 == (int)qryBetreibung["IkVerlustscheinStatusCode"])
            {
                calcSaldoVerlustschein.EditValue = DBNull.Value;
            }
            else
            {
                calcSaldoVerlustschein.EditValue = (decimal)qryBetreibung["VerlustscheinTotal"] - totalZahlungen;
            }

            // HACK: xTabControl Refresh databinding
            ActiveSQLQuery.RefreshDisplay();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string GetContextName()
        {
            return "Ai";
        }

        public override void OnRefreshData()
        {
            int focusedRow = bandedGridView1.FocusedRowHandle;

            qryBetreibung.SelectStatement = CreateQueryBetreibung();
            qryBetreibung.Fill(_faLeistungID);
            SetTotals();
            bandedGridView1.FocusedRowHandle = focusedRow;

            btnNeueBetreibung.Enabled = qryBetreibung.CanInsert;
            btnNeuerVerlustschein.Enabled = qryBetreibung.CanInsert;
        }

        #endregion

        #region Private Static Methods

        private static void ColReserveWidth(GridColumn col, int width)
        {
            if (width != 0)
            {
                col.Width = width;
                col.MinWidth = width;
                // --- set FixedWidth
                col.OptionsColumn.FixedWidth = true;
            }
            else
            {
                col.MinWidth = 0;
                // --- clear FixedWidth
                col.OptionsColumn.FixedWidth = false;
            }
        }

        private static string GetViewExcel(ColumnView view, int colFrom, int colTo, bool withHeader, string replacementNl)
        {
            string x = "";

            if (withHeader)
            {
                for (int c = colFrom; c <= colTo; ++c)
                {
                    if (view.Columns[c].VisibleIndex < 0)
                    {
                        continue;
                    }
                    string colCaption = view.Columns[c].Caption;
                    if (null != replacementNl)
                    {
                        colCaption = colCaption.Replace("\r\n", replacementNl);
                    }
                    x += colCaption + '\t';
                }
            }

            for (int r = 0; r < view.RowCount; ++r)
            {
                x += "\r\n";
                for (int c = colFrom; c <= colTo; ++c)
                {
                    if (view.Columns[c].VisibleIndex < 0)
                    {
                        continue;
                    }
                    string cell = view.GetRowCellDisplayText(r, view.Columns[c]);
                    if (null != replacementNl)
                    {
                        cell = cell.Replace("\r\n", replacementNl);
                    }
                    x += cell + '\t';
                }
            }

            return x;
        }

        #endregion

        #region Private Methods

        private void ColBetreibungReserve()
        {
            ColReserveWidth(colBetreibungAm, 70);
            ColReserveWidth(colBetreibungBetrag, 70);
            ColReserveWidth(colBetreibungNummer, 70);
        }

        private void ColBetreibungUnReserve()
        {
            ColReserveWidth(colBetreibungAm, 0);
            ColReserveWidth(colBetreibungBetrag, 0);
            ColReserveWidth(colBetreibungNummer, 0);
        }

        private void ColVerlustscheinReserve()
        {
            ColReserveWidth(colVerlustscheinAm, 70);
            ColReserveWidth(colVerlustscheinNummer, 70);
            ColReserveWidth(colVerlustscheinTotal, 70);
        }

        private void ColVerlustscheinUnReserve()
        {
            ColReserveWidth(colVerlustscheinAm, 0);
            ColReserveWidth(colVerlustscheinNummer, 0);
            ColReserveWidth(colVerlustscheinTotal, 0);
        }

        private String CreateQueryBetreibung()
        {
            Debug.WriteLine("CreateQueryBetreibung() enter");
            var query = new StringBuilder();
            query.Append(
                @"
                SELECT
                   BET.IkBetreibungID,
                   BET.FaLeistungID,
                   BET.IkBetreibungStatusCode,
                   BET.IkVerlustscheinStatusCode,
                   BET.IkVerlustscheinTypCode,
                   BET.BetreibungAm,
                   BET.BetreibungNummer,
                   BET.BetreibungAmt,
                   BET.BetreibungBetrag,
                   BET.BetreibungVon,
                   BET.BetreibungBis,
                   BET.BetreibungFortsetzungAm,
                   BET.BetreibungVerwertungAm,
                   BET.BetreibungRechtsoeffnungAm,
                   BET.Glaeubiger,
                   BET.VerlustscheinAm,
                   BET.VerlustscheinNummer,
                   BET.VerlustscheinAmt,
                   BET.VerlustscheinBetrag,
                   BET.VerlustscheinZins,
                   BET.VerlustscheinKosten,
                   BET.VerlustscheinVerjaehrungAm,
                   BET.Bemerkung,
                   VerlustscheinTotal = $0.00
                FROM IkBetreibung BET
                  LEFT  JOIN IkRechtstitel RTT ON RTT.IkRechtstitelID = BET.IkRechtstitelID");

            switch ((Auswahl)cboAuswahl.EditValue)
            {
                case Auswahl.AlleBetreibungenUndVerlustscheine:
                    Debug.WriteLine("case AUSWAHL.ALLE_BETREIBUNGEN_UND_VERLUSTSCHEINE");
                    query.Append(
                        @"
                        WHERE (BET.FaLeistungID = {0} OR RTT.FaLeistungID = {0})
                        ORDER BY BET.IkBetreibungID");
                    break;

                case Auswahl.NurAktiveBetreibungen:
                    Debug.WriteLine("case AUSWAHL.NUR_AKTIVE_BETREIBUNGEN");
                    query.Append(
                        @"
                          INNER JOIN XLOVCode  LVB ON BET.IkBetreibungStatusCode=LVB.Code
                                                    AND LVB.LOVName='IkBetreibungStatus'
                                                    AND LVB.Value1=1 -- IsBetreibung
                                                    AND LVB.Value2=0 -- IsAbgeschlossen
                        WHERE (BET.FaLeistungID = {0} OR RTT.FaLeistungID = {0})
                        ORDER BY BET.IkBetreibungID");
                    break;

                case Auswahl.NurAktiveVerlustscheine:
                    Debug.WriteLine("case AUSWAHL.NUR_AKTIVE_VERLUSTSCHEINE");
                    query.Append(
                        @"
                          INNER JOIN XLOVCode  LVV ON BET.IkVerlustscheinStatusCode=LVV.Code
                                                    AND LVV.LOVName='IkVerlustscheinStatus'
                                                    AND LVV.Value1=1 -- IsVerlustschein
                                                    AND LVV.Value2=0 -- IsAbgeschlossen
                        WHERE (BET.FaLeistungID = {0} OR RTT.FaLeistungID = {0})
                        ORDER BY BET.IkBetreibungID");
                    break;

                case Auswahl.AlleAktivenBetreibungenUndVerlustscheine:
                    Debug.WriteLine("case AUSWAHL.ALLE_AKTIVEN_BETREIBUNGEN_UND_VERLUSTSCHEINE");
                    query.Append(
                        @"
                          INNER JOIN XLOVCode       LVB ON BET.IkBetreibungStatusCode=LVB.Code
                                                       AND LVB.LOVName='IkBetreibungStatus'
                          INNER JOIN   XLOVCode     LVV ON BET.IkVerlustscheinStatusCode=LVV.Code
                                                       AND LVV.LOVName='IkVerlustscheinStatus'
                        WHERE (BET.FaLeistungID = {0} OR RTT.FaLeistungID = {0})
                          AND ((LVB.Value1=1 AND LVB.Value2=0) OR (LVV.Value1=1 AND LVV.Value2=0))
                        ORDER BY BET.IkBetreibungID");
                    break;

                default:
                    Debug.WriteLine("default");
                    throw new Exception(
                        KissMsg.GetMLMessage(
                            "CtlAiBetreibungenVerlustscheine",
                            "CodingErrorEditValue",
                            "Coding error in CtlAiBetreibungenVerlustscheine.cboAuswahl_EditValueChanged: Illegal value in cboAuswahl.EditValue: {0}",
                            KissMsgCode.MsgError,
                            cboAuswahl.EditValue));
            }

            String result = query.ToString();
            Debug.WriteLine(result);
            return result;
        }

        private void SetStyle()
        {
            grdBetreibungen.Styles.AddReplace(
                "CellYellowLight",
                new ViewStyleEx(
                    "CellYellowLight",
                    "",
                    new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel),
                    Color.FromArgb(((255)), ((255)), ((189))),
                    SystemColors.WindowText,
                    Color.Empty,
                    LinearGradientMode.Horizontal));

            grdBetreibungen.Styles.AddReplace(
                "CellYellow",
                new ViewStyleEx(
                    "CellYellow",
                    "",
                    new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel),
                    Color.Yellow,
                    SystemColors.WindowText,
                    Color.Empty,
                    LinearGradientMode.Horizontal));

            grdBetreibungen.Styles.AddReplace(
                "CellGreenLight",
                new ViewStyleEx(
                    "CellGreenLight",
                    "",
                    new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel),
                    Color.PaleGreen,
                    SystemColors.WindowText,
                    Color.Empty,
                    LinearGradientMode.Horizontal));

            grdBetreibungen.Styles.AddReplace(
                "CellGreen",
                new ViewStyleEx(
                    "CellGreen",
                    "",
                    new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel),
                    Color.LimeGreen,
                    SystemColors.WindowText,
                    Color.Empty,
                    LinearGradientMode.Horizontal));
        }

        private void SetTotals()
        {
            decimal sumActiveVerlustscheine = 0;
            foreach (DataRow row in qryBetreibung.DataTable.Rows)
            {
                decimal vBetrag = DBNull.Value == row["VerlustscheinBetrag"] ? 0 : (decimal)row["VerlustscheinBetrag"];
                decimal vZins = DBNull.Value == row["VerlustscheinZins"] ? 0 : (decimal)row["VerlustscheinZins"];
                decimal vKosten = DBNull.Value == row["VerlustscheinKosten"] ? 0 : (decimal)row["VerlustscheinKosten"];

                row["VerlustscheinTOTAL"] = (vBetrag + vZins + vKosten);
                if ((int)row["IkVerlustscheinStatusCode"] == 2)
                {
                    sumActiveVerlustscheine += (decimal)row["VerlustscheinTotal"];
                }

                row.AcceptChanges();
            }

            qryBetreibung.RowModified = false;

            calcSummeAktiveVerlustscheine.EditValue = sumActiveVerlustscheine;
        }

        private void SetVisibleDetailsBetreibung(bool visible)
        {
            txtBetreibungAmt.Visible = visible;
            kissLabel13.Visible = visible;
            kissLabel12.Visible = visible;
            txtBetreibungGlaeubiger.Visible = visible;
            dateBetreibungRechtsoeffnungAm.Visible = visible;
            dateBetreibungVerwertungAm.Visible = visible;
            dateBetreibungFortsetzungAm.Visible = visible;
            dateBetreibungBis.Visible = visible;
            dateBetreibungVon.Visible = visible;
            kissLabel11.Visible = visible;
            txtBetreibungNummer.Visible = visible;
            calcBetreibungBetrag.Visible = visible;
            dateBetreibungEroeffnet.Visible = visible;
            kissLabel4.Visible = visible;
            kissLabel6.Visible = visible;
            kissLabel5.Visible = visible;
            kissLabel7.Visible = visible;
            kissLabel10.Visible = visible;
            kissLabel9.Visible = visible;
            kissLabel8.Visible = visible;
        }

        private void SetVisibleDetailsVerlustschein(bool visible)
        {
            kissLabel18.Visible = visible;
            cboVerlustscheinTyp.Visible = visible;
            calcVerlustscheinZins.Visible = visible;
            kissLabel24.Visible = visible;
            calcVerlustscheinKosten.Visible = visible;
            kissLabel15.Visible = visible;
            txtVerlustscheinAmt.Visible = visible;
            kissLabel14.Visible = visible;
            dateVerlustscheinVerjaehrung.Visible = visible;
            txtVerlustscheinNummer.Visible = visible;
            calcVerlustscheinBetrag.Visible = visible;
            dateVerlustscheinAm.Visible = visible;
            kissLabel19.Visible = visible;
            kissLabel21.Visible = visible;
            kissLabel22.Visible = visible;
            kissLabel23.Visible = visible;
        }

        #endregion

        private void grdBetreibungen_Load(object sender, EventArgs e)
        {
            SetStyle();

            cboAuswahl.ItemIndex = 0;
        }

        #endregion
    }
}