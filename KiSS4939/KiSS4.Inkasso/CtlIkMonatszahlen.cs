using System;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Inkasso
{
    public partial class CtlIkMonatszahlen : KissUserControl
    {
        private readonly int _faFallID = -1;
        private readonly int _fallBaPersonID = -1;
        private readonly int _ikRechtstitelID = -1;
        private int _faLeistungID = -1;
        private int _faProzessCode;

        public CtlIkMonatszahlen(int leistungID, int fallID, Image icon, int rechtstitelID, int fallPersonID, int prozessCode)
            : this()
        {
            picTitel.Image = icon;

            _faLeistungID = leistungID;
            _faFallID = fallID;
            _ikRechtstitelID = rechtstitelID;
            _fallBaPersonID = fallPersonID;
            _faProzessCode = prozessCode;

            // Berechnung automatisch durchführen
            CalcualteMissingPositions(2);
            qryMonatszahlen.Fill(_ikRechtstitelID);

            FillOtherRegisters();
        }

        public CtlIkMonatszahlen()
        {
            InitializeComponent();
        }

        public override KissUserControl DetailControl
        {
            get
            {
                if (tabMonatszahlen.SelectedTab.Controls.Count == 1 &&
                    tabMonatszahlen.SelectedTab.Controls[0] is KissUserControl)
                {
                    return (KissUserControl)tabMonatszahlen.SelectedTab.Controls[0];
                }
                return base.DetailControl;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CalcualteMissingPositions(1);
            qryMonatszahlen.Refresh();
        }

        /// <summary>
        /// </summary>
        /// <param name="modus">1 = Alle Daten eines Rechtstitels, 2 = Nur fehlende Monate ergänzen</param>
        private void CalcualteMissingPositions(int modus)
        {
            try
            {
                DBUtil.OpenSQL(
                    "EXEC dbo.spIkMonatszahlen_DetailAll NULL, {0}, {1}",
                    _ikRechtstitelID, modus);
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void FillOtherRegisters()
        {
            // TODO: Wann soll gesperrt werden?
            var canEdit = (_ikRechtstitelID > 0);
            tbpEinmalig.Enabled = (_ikRechtstitelID > 0);
            tbpVerrechnungskonto.Enabled = (_ikRechtstitelID > 0);

            // Register "Einmalige Forderungen" aktualisieren:
            ctlIkMonatszahlenEinmalig.Init(_ikRechtstitelID, 0, _faFallID, canEdit, true);

            // Register "Verrechnung" aktualisieren:
            ctlIkMonatszahlenVerrechnung.Init(_ikRechtstitelID, _faFallID, _fallBaPersonID, canEdit);
            // Register "Saldo" aktualisieren:
            ctlIkMonatszahlenSaldo.Init(_ikRechtstitelID);
        }

        private void gvwMonatszahlen_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Handled = false;
            if (gvwMonatszahlen.FocusedRowHandle == e.RowHandle)
            {
                return;
            }

            object mon = gvwMonatszahlen.GetRowCellValue(e.RowHandle, gvwMonatszahlen.Columns["Monat"]);
            int intMon = Utils.ConvertToInt(mon);
            bool ungerade = (intMon == 1 || intMon == 3 || intMon == 5 || intMon == 7 || intMon == 9 || intMon == 11);

            Color colorUngerade = Color.LightSalmon;
            Color colorGerade = Color.Bisque;

            if (GuiConfig.Theme == GuiConfig.KissTheme.KissBlue)
            {
                colorUngerade = GuiConfig.colBack03; //GuiConfig.colBack06;
                colorGerade = GuiConfig.colBack04; //GuiConfig.colBack04;
            }

            if (ungerade)
            {
                e.Appearance.BackColor = colorUngerade;
            }
            else
            {
                e.Appearance.BackColor = colorGerade;
            }
        }

        private void qryMonatszahlen_AfterFill(object sender, EventArgs e)
        {
            if (qryMonatszahlen.Count == 0)
            {
                qryMonatszahlen_PositionChanged(sender, e);
            }
        }

        private void qryMonatszahlen_BeforePost(object sender, EventArgs e)
        {
            if ((bool)qryMonatszahlen["Unterstuetzungsfall"])
            {
                qryMonatszahlen["BetragALBV_Calc"] = 0;
                qryMonatszahlen["BetragVermittelt_Calc"] = 0;
                qryMonatszahlen["BetragDiffALBV_Calc"] = 0;
                qryMonatszahlen["BetragSozialhilfe_Calc"] = qryMonatszahlen["TotalAliment"];
            }
            else
            {
                qryMonatszahlen["BetragALBV_Calc"] = qryMonatszahlen["BetragALBV"];
                qryMonatszahlen["BetragVermittelt_Calc"] = Convert.ToDecimal(qryMonatszahlen["TotalAliment"]) - Convert.ToDecimal(qryMonatszahlen["BetragALBV"]);
                qryMonatszahlen["BetragSozialhilfe_Calc"] = 0;
                if (Convert.ToDecimal(qryMonatszahlen["BetragALBV"]) < Convert.ToDecimal(qryMonatszahlen["BetragALBVverrechnung"]))
                {
                    qryMonatszahlen["BetragDiffALBV_Calc"] = 0;
                }
                else
                {
                    qryMonatszahlen["BetragDiffALBV_Calc"] = Convert.ToDecimal(qryMonatszahlen["BetragALBV"]) - Convert.ToDecimal(qryMonatszahlen["BetragALBVverrechnung"]);
                }
            }
        }

        private void qryMonatszahlen_PositionChanged(object sender, System.EventArgs e)
        {
            bool erledigt = (qryMonatszahlen["ErledigterMonat"] is bool) ? (bool)qryMonatszahlen["ErledigterMonat"] : false;

            bool canEdit = (qryMonatszahlen.Count > 0 && qryMonatszahlen.CanUpdate && (!erledigt));
            qryMonatszahlen.EnableBoundFields(canEdit);

            // Bemerkung soll immer editierbar sein.
            memBemerkung.EditMode = EditModeType.Normal;
        }

        private void tabMonatszahlen_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabMonatszahlen.SelectedTabIndex == 0)
            {
                // Montaszahlen neu berechnen
                //MonatszahlenBerechnen(false);
                qryMonatszahlen.Fill(_ikRechtstitelID);
            }
            else if (tabMonatszahlen.SelectedTabIndex == 3)
            {
                // Register Saldo aktualsisieren
                ctlIkMonatszahlenSaldo.GlaeubigerOeffnen();
            }
        }

        private void tabMonatszahlen_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (tabMontaszahlen.SelectedTyIndex == 0) qryMonatszahlen.Refresh();

            //bool CanEdit = (qryMonatszahlen.Count==0 && qryMonatszahlen.CanUpdate);
            //qryMonatszahlen.EnableBoundFields(CanEdit);
        }
    }
}