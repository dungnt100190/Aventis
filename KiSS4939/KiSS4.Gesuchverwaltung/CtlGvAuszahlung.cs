using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors.Controls;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Gesuchverwaltung
{
    public partial class CtlGvAuszahlung : GvBaseControl, IBelegleser
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASS_NAME = "CtlGvAuszahlung";
        private const int ICON_ID_GRAU = 1351;
        private const int ICON_ID_GRUEN = 1352;
        private const int ICON_ID_ROT = 1357;
        private const string QRY_GV_AUSZAHLUNGPOSITION_ERSTERVALUTATERMIN = "ErsterValutaTermin";
        private const string QRY_GV_AUSZAHLUNGPOSITION_POSITIONSART = "Positionsart";
        private const string QRY_GV_AUSZAHLUNGPOSITION_VALUTATERMINE = "ValutaTermine";
        private readonly bool _canDelete;
        private readonly bool _canInsert;
        private readonly bool _canUpdate;

        #endregion

        #endregion

        #region Constructors

        public CtlGvAuszahlung(SqlQuery qryGvGesuch, bool hasKompetenzstufe0, bool hasKompetenzstufe1, bool hasKompetenzstufe2)
            : base(qryGvGesuch, hasKompetenzstufe0, hasKompetenzstufe1, hasKompetenzstufe2)
        {
            InitializeComponent();

            SetupDataMembers();
            SetupFieldNames();

            _canDelete = qryGvAuszahlungPosition.CanDelete;
            _canInsert = qryGvAuszahlungPosition.CanInsert;
            _canUpdate = qryGvAuszahlungPosition.CanUpdate;
        }

        #endregion

        #region Properties

        public int GvGesuchId
        {
            get { return (int)_qryGvGesuch[DBO.GvGesuch.GvGesuchID]; }
        }

        private LOVsGenerated.BgEinzahlungsschein EinzahlungsscheinCode
        {
            get { return (LOVsGenerated.BgEinzahlungsschein)Utils.ConvertToInt(qryGvAuszahlungPosition[DBO.vwKreditor.EinzahlungsscheinCode]); }
        }

        private bool HasSingleValuta
        {
            get
            {
                return (qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungTerminArtCode] as int? ?? -1) ==
                       (int)LOVsGenerated.GvAuszahlungTerminArt.Valuta;
            }
        }

        private LOVsGenerated.GvAuszahlungPositionStatus StatusCode
        {
            get
            {
                return
                    (LOVsGenerated.GvAuszahlungPositionStatus)
                    Utils.ConvertToInt(qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungPositionStatusCode]);
            }
        }

        #endregion

        #region EventHandlers

        private void btnZahlungEditieren_Click(object sender, EventArgs e)
        {
            StatusWechsel(LOVsGenerated.GvAuszahlungPositionStatus.InVorbereitung);
        }

        private void btnZahlungFreigeben_Click(object sender, EventArgs e)
        {
            //sicherstellen, dass Berechnung des Totals der Auszahlungen auf den aktuellen Daten basiert
            qryGvAuszahlungPosition.Post();

            var total = GetTotalAuszahlung();
            var betragBewilligt = Utils.ConvertToDecimal(_qryGvGesuch[DBO.GvGesuch.BetragBewilligt]);

            if (total > betragBewilligt)
            {
                KissMsg.ShowInfo(
                    CLASS_NAME,
                    "Auszahlungsbetrag_zu_gross",
                    "Die Summe der Auszahlungsbeträge darf nicht grösser als der bewilligte Betrag sein.");
                return;
            }

            StatusWechsel(LOVsGenerated.GvAuszahlungPositionStatus.BewilligungErteilt);
        }

        private void btnZahlungSperren_Click(object sender, EventArgs e)
        {
            StatusWechsel(LOVsGenerated.GvAuszahlungPositionStatus.Gesperrt);
        }

        private void CtlGvAuszahlung_Load(object sender, EventArgs e)
        {
            // Load Status images
            cedStatus.SmallImages = KissImageList.SmallImageList;

            SqlQuery qryStati =
                DBUtil.OpenSQL(
                    @"
                SELECT Text,
                       Code,
                       Value1
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LOVName = 'GvAuszahlungPositionStatus'
                ORDER BY SortKey;");

            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                var description = row[DBO.XLOVCode.Text].ToString();
                var value = Utils.ConvertToInt(row[DBO.XLOVCode.Code]);

                int imageIndex;
                if (!int.TryParse(row[DBO.XLOVCode.Value1].ToString(), out imageIndex))
                {
                    imageIndex = -1;
                }

                cedStatus.Items.Add(new ImageComboBoxItem(description, value, KissImageList.GetImageIndex(imageIndex)));
            }

            // Set tool tips
            toolTip.SetToolTip(btnZahlungEditieren, KissMsg.GetMLMessage(CLASS_NAME, "ZahlungEditieren", "Zahlung editieren"));
            toolTip.SetToolTip(btnZahlungFreigeben, KissMsg.GetMLMessage(CLASS_NAME, "ZahlungFreigeben", "Zahlung freigeben"));
            toolTip.SetToolTip(btnZahlungSperren, KissMsg.GetMLMessage(CLASS_NAME, "ZahlungSperren", "Zahlung sperren"));

            // Set icons
            btnZahlungEditieren.IconID = ICON_ID_GRAU;
            btnZahlungFreigeben.IconID = ICON_ID_GRUEN;
            btnZahlungSperren.IconID = ICON_ID_ROT;
        }

        private void edtAuszahlungsTerminArtCode_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungTerminArtCode] = edtAuszahlungsTerminArtCode.EditValue;

            if (HasSingleValuta)
            {
                if (edtCalendar.BoldedDates.Count() == 1)
                {
                    qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.ValutaDatum] = edtCalendar.BoldedDates[0];
                }

                edtCalendar.RemoveAllBoldedDates();
                edtValutaDatum.Visible = true;
                edtValutaTermine.Visible = false;

                tabKreditor.SelectTab(tpgKreditor);
            }
            else
            {
                if (!DBUtil.IsEmpty(edtValutaDatum.EditValue))
                {
                    edtCalendar.AddBoldedDate((DateTime)edtValutaDatum.EditValue);
                }

                edtCalendar.BeginInvoke(new MethodInvoker(() => edtCalendar.UpdateBoldedDates()));

                edtValutaDatum.EditValue = DBNull.Value;
                edtValutaDatum.Visible = false;
                edtValutaTermine.Visible = true;

                tabKreditor.SelectTab(tpgCalendar);
            }

            SetCalendarEditMode();
        }

        private void edtBeguenstigter_Leave(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtValutaDatum.EditValue))
            {
                edtValutaDatum.Focus();
            }
        }

        private void edtBeguenstigter_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = DBUtil.IsEmpty(edtBeguenstigter.EditValue) ? string.Empty : edtBeguenstigter.EditValue.ToString();
            searchString = KissLookupDialog.PrepareSearchString(searchString);

            if (searchString == ".")
            {
                using (var dlg = new DlgAuswahl())
                {
                    var faFallId = Utils.ConvertToInt(_qryGvGesuch[DBO.GvGesuch.BaPersonID]);
                    var result = dlg.SearchKreditor(faFallId, null, searchString, e.ButtonClicked);

                    if (result)
                    {
                        qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.BaZahlungswegID] = dlg["ID$"];
                        qryGvAuszahlungPosition[DBO.vwKreditor.Kreditor] = dlg["Kreditor$"];
                        qryGvAuszahlungPosition[DBO.vwKreditor.ZusatzInfo] = dlg["ZusatzInfo$"];
                        qryGvAuszahlungPosition[DBO.vwKreditor.EinzahlungsscheinCode] = dlg["ESCode$"];
                        qryGvAuszahlungPosition[DBO.vwKreditor.PostKontoNummer] = dlg["PostKontoNummer$"];
                        qryGvAuszahlungPosition[DBO.vwKreditor.ReferenzNummer] = dlg["Referenznummer$"];

                        UpdateGui();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                using (var dlg = new DlgAuswahlBaZahlungsweg())
                {
                    dlg.SucheBaZahlungsweg(searchString);

                    var transfer = false;

                    switch (dlg.Count)
                    {
                        case 0:
                            KissMsg.ShowInfo(CLASS_NAME, "Kreditor_KeineEinträge", "Keine zutreffenden Kreditor-Einträge gefunden!");
                            break;

                        case 1:
                            transfer = true;
                            break;

                        default:
                            transfer = dlg.ShowDialog(this) == DialogResult.OK;
                            break;
                    }

                    if (transfer)
                    {
                        qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.BaZahlungswegID] = dlg[DBO.BaZahlungsweg.BaZahlungswegID];
                        qryGvAuszahlungPosition[DBO.vwKreditor.Kreditor] = dlg[DBO.vwKreditor.Kreditor];
                        qryGvAuszahlungPosition[DBO.vwKreditor.ZusatzInfo] = dlg[DBO.vwKreditor.ZusatzInfo];
                        qryGvAuszahlungPosition[DBO.vwKreditor.EinzahlungsscheinCode] = dlg[DBO.vwKreditor.EinzahlungsscheinCode];
                        qryGvAuszahlungPosition[DBO.vwKreditor.PostKontoNummer] = dlg[DBO.vwKreditor.PostKontoNummer];
                        qryGvAuszahlungPosition[DBO.vwKreditor.ReferenzNummer] = dlg[DBO.vwKreditor.ReferenzNummer];

                        UpdateGui();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void edtCalendar_MouseDown(object sender, MouseEventArgs e)
        {
            var info = edtCalendar.HitTest(e.Location);

            // info.HitArea ist auch Date, wenn auf einen Monat in der Monatsansicht geklickt wird. In dem Fall soll aber nicht selektiert werden.
            var displayRange = edtCalendar.GetDisplayRange(true);
            var visibleDays = (displayRange.End - displayRange.Start).Days;
            var isDayView = visibleDays <= (edtCalendar.CalendarDimensions.Width * 31);

            if (info.HitArea == MonthCalendar.HitArea.Date && isDayView)
            {
                if (edtCalendar.BoldedDates.Contains(info.Time))
                {
                    edtCalendar.RemoveBoldedDate(info.Time);
                }
                else
                {
                    edtCalendar.AddBoldedDate(info.Time);
                }

                edtCalendar.BeginInvoke(new MethodInvoker(() => edtCalendar.UpdateBoldedDates()));
                DisplayValutaTermine();
            }
        }

        private void edtGvPositionsart_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtPositionsart.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvPositionsartID] = DBNull.Value;
                    qryGvAuszahlungPosition[QRY_GV_AUSZAHLUNGPOSITION_POSITIONSART] = DBNull.Value;
                    return;
                }
            }

            DateTime? ersterValutaTermin = null;
            if ((int)qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungTerminArtCode] == (int)LOVsGenerated.GvAuszahlungTerminArt.Valuta)
            {
                if (!DBUtil.IsEmpty(qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.ValutaDatum]))
                {
                    ersterValutaTermin = (DateTime)qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.ValutaDatum];
                }
                else
                {
                    KissMsg.ShowInfo(CLASS_NAME, "Kein_Valutadatum_Terminart_Valuta", "Bitte wählen Sie zunächst ein Valuta Datum aus!");
                    return;
                }
            }
            else if ((int)qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungTerminArtCode] == (int)LOVsGenerated.GvAuszahlungTerminArt.Individuell)
            {
                if (!DBUtil.IsEmpty(qryGvAuszahlungPosition[QRY_GV_AUSZAHLUNGPOSITION_ERSTERVALUTATERMIN]))
                {
                    ersterValutaTermin = (DateTime)qryGvAuszahlungPosition[QRY_GV_AUSZAHLUNGPOSITION_ERSTERVALUTATERMIN];
                }
                else
                {
                    KissMsg.ShowInfo(CLASS_NAME, "Kein_Valutadatum_Terminart_Individuell", "Bitte wählen Sie zunächst mindestens ein Valuta Datum aus!");
                    return;
                }
            }

            var sql =
                @"
                DECLARE @SearchParam VARCHAR(MAX);
                SET @SearchParam = {0};

                SELECT
                  [KOA]               = KOA.KontoNr + ' ' + ISNULL(LANK.Text, KOA.Name),
                  [Positionsart]      = ISNULL(LANP.Text, GPA.Bezeichnung),
                  [GvPositionsartID$] = GPA.GvPositionsartID,
                  [KOAPositionsart$]  = KOA.KontoNr + ' ' + ISNULL(LANP.Text, GPA.Bezeichnung)
                FROM dbo.GvPositionsart      GPA  WITH(READUNCOMMITTED)
                  INNER JOIN dbo.BgKostenart KOA  WITH(READUNCOMMITTED) ON KOA.BgKostenartID = GPA.BgKostenartID
                  LEFT  JOIN dbo.XLangText   LANP WITH(READUNCOMMITTED) ON LANP.TID = GPA.BezeichnungTID
                                                                       AND LANP.LanguageCode = {3}
                  LEFT  JOIN dbo.XLangText   LANK WITH(READUNCOMMITTED) ON LANK.TID = KOA.NameTID
                                                                       AND LANK.LanguageCode = {3}
                WHERE (ISNULL(LANP.Text, GPA.Bezeichnung) LIKE '%' + @SearchParam + '%'
                    OR KOA.KontoNr LIKE @SearchParam + '%'
                    OR ISNULL(LANK.Text, KOA.Name) LIKE '%' + @SearchParam + '%'
                    OR KOA.KontoNr + ' ' + GPA.Bezeichnung LIKE '%' + @SearchParam + '%')
                  AND (GPA.HSOnly = 0 OR {1} = 1)
                  AND GPA.IsFLB = {2}
                  AND {4} BETWEEN ISNULL(GPA.DatumVon, '19000101') AND ISNULL(GPA.DatumBis, '99991231')
                ORDER BY [KOA], [Positionsart];";

            bool isFlbFondsSelected = IsFlbFondsSelected();
            using (var dlg = new KissLookupDialog())
            {
                var result = dlg.SearchData(sql, searchString, e.ButtonClicked, HasKompetenzstufe2, isFlbFondsSelected, Session.User.LanguageCode, ersterValutaTermin.Value);

                if (result)
                {
                    qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvPositionsartID] = dlg["GvPositionsartID$"];
                    qryGvAuszahlungPosition[QRY_GV_AUSZAHLUNGPOSITION_POSITIONSART] = dlg["KOAPositionsart$"];
                    qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.BuchungsText] =
                        qryGvAuszahlungPosition[QRY_GV_AUSZAHLUNGPOSITION_POSITIONSART].ToString();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void edtValutaDatum_Leave(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtPositionsart.EditValue))
            {
                edtPositionsart.Focus();
            }
        }

        private void grvGvAuszahlungPosition_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            // Betrag von rote Auszahlungen nich summieren
            if (e.Item == colBetrag.SummaryItem && e.SummaryProcess == CustomSummaryProcess.Calculate)
            {
                var status = (LOVsGenerated.GvAuszahlungPositionStatus)grvGvAuszahlungPosition.GetRowCellValue(e.RowHandle, colStatus.FieldName);

                if (status != LOVsGenerated.GvAuszahlungPositionStatus.Gesperrt && !DBUtil.IsEmpty(e.FieldValue))
                {
                    e.TotalValue = Convert.ToDecimal(e.TotalValue) + Convert.ToDecimal(e.FieldValue);
                }
            }
        }

        private void qryGvAuszahlungPosition_AfterDelete(object sender, EventArgs e)
        {
            Session.Commit();
        }

        private void qryGvAuszahlungPosition_AfterInsert(object sender, EventArgs e)
        {
            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvGesuchID] = _gvGesuchId;
            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungPositionStatusCode] = LOVsGenerated.GvAuszahlungPositionStatus.InVorbereitung;
            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungTerminArtCode] = LOVsGenerated.GvAuszahlungTerminArt.Valuta;

            // Auszahlungsart auf Grund Fonds setzen
            var gvFondsId = _qryGvGesuch[DBO.GvGesuch.GvFondsID];
            var kbZahlungskontoId =
                DBUtil.ExecuteScalarSQL(
                    @"
                SELECT KbZahlungskontoID
                FROM dbo.GvFonds
                WHERE GvFondsID = {0};",
                    gvFondsId);

            if (!DBUtil.IsEmpty(kbZahlungskontoId))
            {
                qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungArtCode] = LOVsGenerated.GvAuszahlungArt.ElektronischeAuszahlung;
            }
            else
            {
                qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungArtCode] = LOVsGenerated.GvAuszahlungArt.Papierverfuegung;
            }

            edtBeguenstigter.Focus();
        }

        private void qryGvAuszahlungPosition_AfterPost(object sender, EventArgs e)
        {
            try
            {
                SaveAuszahlungPositionValuta(edtCalendar.BoldedDates);

                Session.Commit();
            }
            catch (Exception)
            {
                Session.Rollback();
                throw;
            }

            UpdateGui();
        }

        private void qryGvAuszahlungPosition_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            try
            {
                DBUtil.ExecSQLThrowingException(
                    @"DELETE FROM dbo.GvAuszahlungPositionValuta WHERE GvAuszahlungPositionID = {0}",
                    qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungPositionID]);
            }
            catch (Exception)
            {
                Session.Rollback();
                throw;
            }
        }

        private void qryGvAuszahlungPosition_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if (StatusCode > LOVsGenerated.GvAuszahlungPositionStatus.InVorbereitung)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "Löschen_Nur_Positionen_In_Vorbereitung",
                        "Es können nur Positionen mit Status 'in Vorbereitung' gelöscht werden"));
            }
        }

        private void qryGvAuszahlungPosition_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBeguenstigter, lblBeguenstigter.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);
            DBUtil.CheckNotNullField(edtAuszahlungsArtCode, lblAuszahlungsArtCode.Text);
            DBUtil.CheckNotNullField(edtAuszahlungsTerminArtCode, lblAuszahlungsTerminCode.Text);

            if (HasSingleValuta)
            {
                DBUtil.CheckNotNullField(edtValutaDatum, lblValutaDatum.Text);
            }
            else
            {
                // es muss ein Valutadatum selektiert sein
                if (!edtCalendar.BoldedDates.Any())
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            CLASS_NAME,
                            "AuszahltemineLeer",
                            "Es sind noch keine individuellen Auszahltermine erfasst.",
                            KissMsgCode.MsgInfo),
                        edtCalendar);
                }

                qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.ValutaDatum] = DBNull.Value;
            }

            DBUtil.CheckNotNullField(edtPositionsart, lblPositionsart.Text);
            DBUtil.CheckNotNullField(edtKreditor, lblKreditor.Text);

            var betrag = edtBetrag.EditValue as decimal?;
            //var differenz = edtDifferenz.EditValue as decimal?;

            if (betrag < 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "Auszahlungsbetrag_Negativ",
                        "Der Auszahlungsbetrag darf nicht negativ sein."));
            }

            // Positionsart auf Valutadatum überprüfen
            var valutaList = new List<DateTime>();

            if (HasSingleValuta)
            {
                valutaList.Add(edtValutaDatum.DateTime);
            }
            else
            {
                valutaList.AddRange(edtCalendar.BoldedDates);
            }

            var qryPoaDatum = DBUtil.OpenSQL(@"
                SELECT DatumVon, DatumBis
                FROM dbo.GvPositionsart
                WHERE GvPositionsartID = {0};",
                qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvPositionsartID]);

            var poaDatumVon = Utils.ConvertToDateTime(qryPoaDatum[DBO.GvPositionsart.DatumVon], DateTime.MinValue);
            var poaDatumBis = Utils.ConvertToDateTime(qryPoaDatum[DBO.GvPositionsart.DatumBis], DateTime.MaxValue);

            if (valutaList.Any(x => x < poaDatumVon || x > poaDatumBis))
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "Valuta_Ausserhalb_Positionsart_Gültigkeit",
                        "Mindestens ein Valutadatum liegt ausserhalb des Gültigkeitsbereichs der gewählten Positionsart."));
            }

            //Falls Einzahlungsschein==1 (Oranger Einzahlungsschein) dann ist Ref-Nr. ein MussFeld
            if (!DBUtil.IsEmpty(qryGvAuszahlungPosition[DBO.vwKreditor.EinzahlungsscheinCode])
                    && Utils.ConvertToInt(qryGvAuszahlungPosition[DBO.vwKreditor.EinzahlungsscheinCode]) == 1)
            {
                DBUtil.CheckNotNullField(edtReferenzNummer, lblReferenzNummer.Text);

                if (!DBUtil.IsEmpty(qryGvAuszahlungPosition[DBO.vwKreditor.PostKontoNummer])
                        && !edtReferenzNummer.ValidateReferenzNummer(qryGvAuszahlungPosition[DBO.vwKreditor.PostKontoNummer].ToString()))
                {
                    edtReferenzNummer.Focus();
                    throw new KissCancelException();
                }
            }

            Session.BeginTransaction();
        }

        private void qryGvAuszahlungPosition_PositionChanged(object sender, EventArgs e)
        {
            GetAuszahlungPositionValuta();

            UpdateGui();
        }

        #endregion

        #region Methods

        #region Public Methods

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            bool editable = qryGvAuszahlungPosition.CanUpdate && StatusCode == LOVsGenerated.GvAuszahlungPositionStatus.InVorbereitung;

            if (!editable)
            {
                KissMsg.ShowInfo(
                    CLASS_NAME,
                    "Belegleser_Nicht_Mutierbar",
                    "Neue Daten vom Belegleser: Der Status der Position erlaubt keine Änderung der erfassten Daten");
                return;
            }

            using (var dlg = new DlgAuswahlBaZahlungsweg())
            {
                dlg.SucheBaZahlungsweg(beleg);

                var transfer = false;

                switch (dlg.Count)
                {
                    case 0:
                        KissMsg.ShowInfo(CLASS_NAME, "Kreditor_KeineEinträge", "Keine zutreffenden Kreditor-Einträge gefunden!");
                        break;

                    case 1:
                        transfer = true;
                        break;

                    default:
                        transfer = dlg.ShowDialog(this) == DialogResult.OK;
                        break;
                }

                if (transfer)
                {
                    qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.BaZahlungswegID] = dlg[DBO.BaZahlungsweg.BaZahlungswegID];
                    qryGvAuszahlungPosition[DBO.vwKreditor.Kreditor] = dlg[DBO.vwKreditor.Kreditor];
                    qryGvAuszahlungPosition[DBO.vwKreditor.ZusatzInfo] = dlg[DBO.vwKreditor.ZusatzInfo];
                    qryGvAuszahlungPosition[DBO.vwKreditor.EinzahlungsscheinCode] = dlg[DBO.vwKreditor.EinzahlungsscheinCode];
                    qryGvAuszahlungPosition[DBO.vwKreditor.ReferenzNummer] = dlg[DBO.vwKreditor.ReferenzNummer];
                }
            }
        }

        #endregion

        #region Protected Methods

        protected override void LoadData(bool refresh)
        {
            qryGvAuszahlungPosition.Fill(_gvGesuchId, Session.User.LanguageCode);

            // Position automatisch erstellen, falls qryGvAuszahlungPosition leer
            if (qryGvAuszahlungPosition.IsEmpty)
            {
                // nur moeglich, wenn BaZahlungswegID in dbo.GvAbklaerendeStelle vorhanden!!!
                SetKreditorInformationen();
            }

            // DataSource neu setzen um Summe im Grid anzuzeigen
            SetupDataSourceOnGrid();
            UpdateGui();
        }

        protected override void UpdateGui()
        {
            UpdateDifferenz();

            btnZahlungEditieren.Enabled = false;
            btnZahlungFreigeben.Enabled = false;
            btnZahlungSperren.Enabled = false;

            if (GesuchAbgeschlossen())
            {
                return;
            }

            var statusCode = StatusCode;

            // Enable / disable buttons
            if (qryGvAuszahlungPosition.CurrentRowState != DataRowState.Added && (Utils.ConvertToInt(_qryGvGesuch["GvStatusCode"]) != Convert.ToInt32(LOVsGenerated.GvStatus.Abgeschlossen)))
            {
                switch (statusCode)
                {
                    case LOVsGenerated.GvAuszahlungPositionStatus.InVorbereitung:
                        btnZahlungFreigeben.Enabled = true;
                        break;

                    case LOVsGenerated.GvAuszahlungPositionStatus.BewilligungErteilt:
                        btnZahlungEditieren.Enabled = true;
                        btnZahlungSperren.Enabled = true;
                        break;

                    case LOVsGenerated.GvAuszahlungPositionStatus.Importiert:
                        // alle deaktivieren
                        break;

                    case LOVsGenerated.GvAuszahlungPositionStatus.Gesperrt:
                        btnZahlungEditieren.Enabled = true;
                        break;
                }
            }

            // Disable controls dependeing on status
            bool enable = statusCode == LOVsGenerated.GvAuszahlungPositionStatus.InVorbereitung;
            qryGvAuszahlungPosition.EnableBoundFields(enable);

            edtCalendar.Enabled = enable;

            // Valuta-Datum
            var hasSingleValuta = HasSingleValuta;
            edtValutaDatum.Visible = hasSingleValuta;
            edtValutaTermine.Visible = !hasSingleValuta;

            //ReferenzNummer
            edtReferenzNummer.EditMode = (EinzahlungsscheinCode == LOVsGenerated.BgEinzahlungsschein.OrangerEinzahlungsschein) ? EditModeType.Normal : EditModeType.ReadOnly;

            SetCalendarEditMode();
        }

        #endregion

        #region Private Methods

        private void DisplayValutaTermine()
        {
            var valutaTermine = string.Join("  ", edtCalendar.BoldedDates.Select(d => d.ToString("d.M.")));

            qryGvAuszahlungPosition[QRY_GV_AUSZAHLUNGPOSITION_VALUTATERMINE] = valutaTermine;
            if (edtCalendar.BoldedDates.Any())
            {
                qryGvAuszahlungPosition[QRY_GV_AUSZAHLUNGPOSITION_ERSTERVALUTATERMIN] = edtCalendar.BoldedDates.Min();
            }
            else
            {
                qryGvAuszahlungPosition[QRY_GV_AUSZAHLUNGPOSITION_ERSTERVALUTATERMIN] = null;
            }

            qryGvAuszahlungPosition.RefreshDisplay();
        }

        private bool GesuchAbgeschlossen()
        {
            if (Utils.ConvertToInt(_qryGvGesuch["GvStatusCode"]) == Convert.ToInt32(LOVsGenerated.GvStatus.Abgeschlossen))
            {
                qryGvAuszahlungPosition.CanDelete = false;
                qryGvAuszahlungPosition.CanInsert = false;
                qryGvAuszahlungPosition.CanUpdate = false;
                qryGvAuszahlungPosition.EnableBoundFields();

                return true;
            }

            qryGvAuszahlungPosition.CanDelete = _canDelete;
            qryGvAuszahlungPosition.CanInsert = _canInsert;
            qryGvAuszahlungPosition.CanUpdate = _canUpdate;
            qryGvAuszahlungPosition.EnableBoundFields(!qryGvAuszahlungPosition.IsEmpty);

            return false;
        }

        private void GetAuszahlungPositionValuta()
        {
            qryValuta.Fill(qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungPositionID]);

            edtCalendar.RemoveAllBoldedDates();

            foreach (DataRow row in qryValuta.DataTable.Rows)
            {
                edtCalendar.AddBoldedDate((DateTime)row[DBO.GvAuszahlungPositionValuta.Datum]);
            }

            edtCalendar.BeginInvoke(new MethodInvoker(() => edtCalendar.UpdateBoldedDates()));
        }

        private decimal GetTotalAuszahlung()
        {
            var total = Utils.ConvertToDecimal(
                DBUtil.ExecuteScalarSQL(
                    @"
                    SELECT SUM(Betrag)
                    FROM dbo.GvAuszahlungPosition GAP WITH(READUNCOMMITTED)
                    WHERE GAP.GvGesuchID = {0}
                      AND GAP.GvAuszahlungPositionStatusCode <> 9; -- Gesperrt",
                    _gvGesuchId));
            return total;
        }

        /// <summary>
        /// A fonds is called a FLB-Fonds, when GvFondsTypCode is intern and no KbZahlungsKonto is associated
        /// </summary>
        /// <returns></returns>
        private bool IsFlbFondsSelected()
        {
            // Get associated FondsId
            var fondsTypCode = _qryGvGesuch[DBO.GvFonds.GvFondsTypCode] as int?;
            var kbZahlungskontoID = _qryGvGesuch[DBO.GvFonds.KbZahlungskontoID] as int?;

            return fondsTypCode.HasValue && fondsTypCode.Value == 1
                   && kbZahlungskontoID.HasValue;
        }

        private void SaveAuszahlungPositionValuta(DateTime[] dateTime)
        {
            var gvAuszalungPositionId = qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungPositionID];

            // alte Werte löschen
            DBUtil.ExecSQLThrowingException(
                @"DELETE FROM dbo.GvAuszahlungPositionValuta WHERE GvAuszahlungPositionID = {0};",
                gvAuszalungPositionId);

            if (HasSingleValuta)
            {
                return;
            }

            // neue Werte hinzufügen
            foreach (var date in dateTime)
            {
                qryValuta.Insert();
                qryValuta[DBO.GvAuszahlungPositionValuta.GvAuszahlungPositionID] = gvAuszalungPositionId;
                qryValuta[DBO.GvAuszahlungPositionValuta.Datum] = date;

                if (!qryValuta.Post())
                {
                    throw new KissCancelException();
                }
            }
        }

        private void SetCalendarEditMode()
        {
            if (HasSingleValuta)
            {
                edtCalendar.Enabled = false;
            }
            else
            {
                edtCalendar.Enabled = StatusCode == LOVsGenerated.GvAuszahlungPositionStatus.InVorbereitung;
            }
        }

        private void SetKreditorInformationen()
        {
            var qryBaZahlungsweg =
                DBUtil.OpenSQL(
                    @"
                SELECT
                    AKS.BaZahlungswegID,
                    KRE.Kreditor,
                    KRE.ZusatzInfo,
                    KRE.ReferenzNummer,
                    KRE.EinzahlungsscheinCode,
                    AKS.Zahlungsinstruktion,
                    AKS.MitteilungZeile1,
                    AKS.MitteilungZeile2,
                    AKS.MitteilungZeile3,
                    AKS.MitteilungZeile4
                FROM dbo.GvAbklaerendeStelle AKS
                  INNER JOIN dbo.vwKreditor KRE WITH(READUNCOMMITTED) ON KRE.BaZahlungswegID = AKS.BaZahlungswegID
                WHERE GvGesuchID = {0};",
                    GvGesuchId);

            if (qryBaZahlungsweg.IsEmpty)
            {
                return;
            }

            qryGvAuszahlungPosition.Insert();
            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvGesuchID] = GvGesuchId;
            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.BaZahlungswegID] = qryBaZahlungsweg[DBO.GvAbklaerendeStelle.BaZahlungswegID];
            qryGvAuszahlungPosition[DBO.vwKreditor.Kreditor] = qryBaZahlungsweg[DBO.vwKreditor.Kreditor];
            qryGvAuszahlungPosition[DBO.vwKreditor.ZusatzInfo] = qryBaZahlungsweg[DBO.vwKreditor.ZusatzInfo];
            qryGvAuszahlungPosition[DBO.vwKreditor.EinzahlungsscheinCode] = qryBaZahlungsweg[DBO.vwKreditor.EinzahlungsscheinCode];
            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.ReferenzNummer] = qryBaZahlungsweg[DBO.vwKreditor.ReferenzNummer];
            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.Zahlungsinstruktion] = qryBaZahlungsweg[DBO.GvAbklaerendeStelle.Zahlungsinstruktion];
            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.MitteilungZeile1] = qryBaZahlungsweg[DBO.GvAbklaerendeStelle.MitteilungZeile1];
            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.MitteilungZeile2] = qryBaZahlungsweg[DBO.GvAbklaerendeStelle.MitteilungZeile2];
            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.MitteilungZeile3] = qryBaZahlungsweg[DBO.GvAbklaerendeStelle.MitteilungZeile3];
            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.MitteilungZeile4] = qryBaZahlungsweg[DBO.GvAbklaerendeStelle.MitteilungZeile4];
        }

        private void SetupDataMembers()
        {
            edtBeguenstigter.DataMember = DBO.vwKreditor.Kreditor;
            edtBetrag.DataMember = DBO.GvAuszahlungPosition.Betrag;
            edtKreditor.DataMember = DBO.vwKreditor.Kreditor;
            edtPositionsart.DataMember = QRY_GV_AUSZAHLUNGPOSITION_POSITIONSART;
            edtValutaDatum.DataMember = DBO.GvAuszahlungPosition.ValutaDatum;
            edtValutaTermine.DataMember = QRY_GV_AUSZAHLUNGPOSITION_VALUTATERMINE;
            edtZahlungsinstruktionen.DataMember = DBO.GvAuszahlungPosition.Zahlungsinstruktion;
            edtZusatzinfo.DataMember = DBO.vwKreditor.ZusatzInfo;
            edtReferenzNummer.DataMember = DBO.vwKreditor.ReferenzNummer;
            edtBuchungsText.DataMember = DBO.GvAuszahlungPosition.BuchungsText;
            edtAuszahlungsTerminArtCode.DataMember = DBO.GvAuszahlungPosition.GvAuszahlungTerminArtCode;
            edtAuszahlungsArtCode.DataMember = DBO.GvAuszahlungPosition.GvAuszahlungArtCode;
        }

        private void SetupDataSourceOnGrid()
        {
            grdGvAuszahlungPosition.DataSource = null;
            grdGvAuszahlungPosition.DataSource = qryGvAuszahlungPosition;
        }

        private void SetupFieldNames()
        {
            colBeguenstigter.FieldName = DBO.vwKreditor.Kreditor;
            colBetrag.FieldName = DBO.GvAuszahlungPosition.Betrag;
            colPositionsart.FieldName = QRY_GV_AUSZAHLUNGPOSITION_POSITIONSART;
            colStatus.FieldName = DBO.GvAuszahlungPosition.GvAuszahlungPositionStatusCode;
            colValuta.FieldName = DBO.GvAuszahlungPosition.ValutaDatum;
        }

        private void StatusWechsel(LOVsGenerated.GvAuszahlungPositionStatus status)
        {
            if (!OnSaveData())
            {
                return;
            }

            qryGvAuszahlungPosition[DBO.GvAuszahlungPosition.GvAuszahlungPositionStatusCode] = status;
            qryGvAuszahlungPosition.Post();
        }

        private void UpdateDifferenz()
        {
            var total = GetTotalAuszahlung();
            edtDifferenz.EditValue = Utils.ConvertToDecimal(_qryGvGesuch[DBO.GvGesuch.BetragBewilligt]) - total;
        }

        #endregion

        #endregion
    }
}