using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Fibu
{
    partial class CtlFibuKontoblatt : Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID;

        #endregion

        #endregion

        #region Constructors

        public CtlFibuKontoblatt()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlFibuKontoblatt_Load(object sender, EventArgs e)
        {
            lblMandant.Text = "";

            NeueSuche();

            ShowPerioden();
        }

        private void CtlFibuKontoblatt_Print(object sender, EventArgs e)
        {
            if (!CheckPrms())
            {
                return;
            }

            GetKissMainForm().ContextPrint(this, null);
        }

        private void CtlFibuKontoblatt_Search(object sender, EventArgs e)
        {
            if (TabControlEx1.SelectedTabIndex == 0)
            {
                NeueSuche();
            }
            else
            {
                Suchen();
            }
        }

        private void edtKontoBisX_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            var fbPeriodeID = 0;
            if (qryPeriodeX.Count > 0)
            {
                fbPeriodeID = (int)qryPeriodeX["FbPeriodeID"];
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.KontoSuchen(edtKontoBisX.Text, fbPeriodeID, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtKontoBisX.Text = dlg["KontoNr"].ToString();
                edtKontonameBisX.Text = dlg["KontoName"].ToString();
            }
        }

        private void edtKontoVonX_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            var fbPeriodeID = 0;
            if (qryPeriodeX.Count > 0)
            {
                fbPeriodeID = (int)qryPeriodeX["FbPeriodeID"];
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.KontoSuchen(edtKontoVonX.Text, fbPeriodeID, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtKontoVonX.Text = dlg["KontoNr"].ToString();
                edtKontonameVonX.Text = dlg["KontoName"].ToString();
            }
        }

        private void edtMandantX_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MandantSuchenB(edtMandantX.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                UpdateEditTextAndShowPerioden(dlg);
            }
        }

        private void qryKontoblaetter_AfterFill(object sender, EventArgs e)
        {
            grdKontoblaetter.DataSource = null;

            // init grid with summary items
            grvKontoblaetter.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragSoll", colBetragSoll, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragHaben", colBetragHaben, "{0:N2}")});

            grdKontoblaetter.DataSource = qryKontoblaetter;
        }

        private void qryPeriodeX_PositionChanged(object sender, EventArgs e)
        {
            SetRanges();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string GetContextName()
        {
            if (qryPeriodeX.Count > 0)
            {
                return Name;
            }

            return Name + "2";
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FBPERIODEID":
                    return qryPeriodeX.Count > 0 ? qryPeriodeX["FbPeriodeID"] : DBNull.Value;

                case "KONTONRVON":
                    return edtKontoVonX.EditValue;

                case "KONTONRBIS":
                    return edtKontoBisX.EditValue;

                case "DATUMVON":
                    return edtDatumVonX.EditValue;

                case "DATUMBIS":
                    return edtDatumBisX.EditValue;
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string maskName, Image maskImage, int baPersonID)
        {
            var qryMandantHatPerioden =
                DBUtil.ExecuteScalarSQL(
                    @"SELECT COUNT(*)
                      FROM FbPeriode
                      WHERE BaPersonID = {0}",
                    baPersonID);

            if (Convert.ToInt32(qryMandantHatPerioden) == 0)
            {
                KissMsg.ShowInfo("CtlFibuBuchung", "MandantHatKeinePerioden", "Der Mandant hat keine Periode.");
            }
            else
            {
                var dlg = new DlgAuswahl();
                var result = !dlg.MandantSuchenB(Convert.ToString(baPersonID), false);
                UpdateEditTextAndShowPerioden(dlg);
            }

            edtMandantX.EditMode = EditModeType.ReadOnly;
        }

        #endregion

        #region Private Methods

        private bool CheckPrms()
        {
            // Suchfelder validieren
            if (DBUtil.IsEmpty(edtKontoVonX.EditValue))
            {
                KissMsg.ShowInfo("CtlFibuKontoblatt", "KontoNrLeer", "Das Feld 'Konto-Nr. von' darf nicht leer bleiben");
                return false;
            }

            if (DBUtil.IsEmpty(edtKontoBisX.EditValue))
            {
                edtKontoBisX.EditValue = edtKontoVonX.EditValue;
            }

            if (edtDatumVonX.EditValue == null)
            {
                KissMsg.ShowInfo("CtlFibuKontoblatt", "DatumVonLeer", "Das Feld 'Datum von' darf nicht leer bleiben");
                return false;
            }

            if (edtDatumBisX.EditValue == null)
            {
                KissMsg.ShowInfo("CtlFibuKontoblatt", "DatumBisLeer", "Das Feld 'Datum bis' darf nicht leer bleiben");
                return false;
            }

            return true;
        }

        private void NeueSuche()
        {
            TabControlEx1.SelectedTabIndex = 1;

            if (edtMandantX.EditMode != EditModeType.ReadOnly)
            {
                qryPeriodeX.DataTable.Rows.Clear();

                foreach (var ctl in tabSuchen.Controls.OfType<BaseEdit>())
                {
                    (ctl).EditValue = null;
                }

                ApplicationFacade.DoEvents();
                edtMandantX.Focus();
            }
        }

        private void SetRanges()
        {
            if (qryPeriodeX.Count == 0)
            {
                return;
            }

            edtDatumVonX.DateTime = (DateTime)qryPeriodeX["PeriodeVon"];
            edtDatumBisX.DateTime = (DateTime)qryPeriodeX["PeriodeBis"];

            edtKontoVonX.EditValue = qryPeriodeX["MinKontoNr"];
            edtKontoBisX.EditValue = qryPeriodeX["MaxKontoNr"];

            edtKontonameVonX.Text = DBUtil.ExecuteScalarSQL(@"
                SELECT KontoName
                FROM FbKonto
                WHERE FbPeriodeID = {0}
                  AND KontoNr = {1}",
                qryPeriodeX["FbPeriodeID"],
                qryPeriodeX["MinKontoNr"]).ToString();

            edtKontonameBisX.Text = DBUtil.ExecuteScalarSQL(@"
                SELECT KontoName
                FROM FbKonto
                WHERE FbPeriodeID = {0}
                  AND KontoNr = {1}",
                qryPeriodeX["FbPeriodeID"],
                qryPeriodeX["MaxKontoNr"]).ToString();
        }

        private void ShowPerioden()
        {
            qryPeriodeX.Fill(@"
                SELECT FbPeriodeID,
                       PeriodeVon,
                       PeriodeBis,
                       StatusText = STA.Text,
                       MinKontoNr = (SELECT MIN(KontoNr) FROM FbKonto WHERE FbPeriodeID = PER.FbPeriodeID),
                       MaxKontoNr = (SELECT MAX(KontoNr) FROM FbKonto WHERE FbPeriodeID = PER.FbPeriodeID)
                FROM   FbPeriode      PER
                  INNER JOIN XLOVCode STA ON STA.Code = PER.PeriodeStatusCode AND
                                             STA.LOVName = 'FbPeriodeStatus'
                WHERE  BaPersonID = {0}
                ORDER BY PeriodeVon", _baPersonID);

            if (qryPeriodeX.Count > 0)
            {
                qryPeriodeX.Last();
                SetRanges();
            }
        }

        private void Suchen()
        {
            if (!CheckPrms()) return;

            Cursor = Cursors.WaitCursor;

            // Parameter aufbereiten
            // Mandant/Periode
            string fbPeriodeIDText;
            if (qryPeriodeX.Count > 0)
            {
                fbPeriodeIDText = DBUtil.SqlLiteral(qryPeriodeX["FbPeriodeID"]);
                colMandant.Visible = false;
                colText.Width = 180 + 115; //Breite von Text + Mandant
            }
            else
            {
                fbPeriodeIDText = "null";
                colMandant.Visible = true;
                colText.Width = 180;
            }

            qryKontoblaetter.Fill(
               "EXEC spFbGetKontoblaetter " +
                       fbPeriodeIDText + "," +
                       edtKontoVonX.EditValue + "," +
                       edtKontoBisX.EditValue + "," +
                       DBUtil.SqlLiteral(edtDatumVonX.DateTime, true) + "," +
                       DBUtil.SqlLiteral(edtDatumBisX.DateTime, true));

            lblMandant.Text = edtMandantX.Text + "  (" + edtDatumVonX.Text + " - " + edtDatumBisX.Text + ")";
            TabControlEx1.SelectedTabIndex = 0;
            grvKontoblaetter.ExpandAllGroups();
            Cursor = Cursors.Default;
        }

        private void UpdateEditTextAndShowPerioden(DlgAuswahl dlg)
        {
            if (DBUtil.IsEmpty(dlg["BaPersonID"]))
            {
                _baPersonID = 0;
            }
            else
            {
                _baPersonID = (int)dlg["BaPersonID"];
            }

            editMandantNrX.Text = dlg["BaPersonID"].ToString();
            edtMandantX.Text = dlg["Mandant"].ToString();
            edtPlzOrtX.Text = dlg["PLZOrt"].ToString();
            edtMTX.Text = dlg["MTName"].ToString();
            ShowPerioden();
        }

        #endregion

        #endregion
    }
}