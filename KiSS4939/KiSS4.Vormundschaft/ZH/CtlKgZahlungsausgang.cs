using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft.ZH
{
    public partial class CtlKgZahlungsausgang : KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private bool _bBuchungModified;
        private KgBuchungstext _buchungstext;

        #endregion

        #endregion

        #region Constructors

        public CtlKgZahlungsausgang()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnEintragAusgleichen_Click(object sender, EventArgs e)
        {
            if (qryZahlungsausgang.Count > 0)
            {
                // Ausgeglichen wechseln
                qryZahlungsausgang["Ausgeglichen"] = !(bool)qryZahlungsausgang["Ausgeglichen"];
                SetTextOnButtons();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _bBuchungModified = true;
            OnSaveData();
        }

        private void btnZugeordneteDoks_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryKgBuchung["KgBuchungID"]))
            {
                KissMsg.ShowInfo("Diese Buchung ist noch nicht gespeichert, daher können die Dokumente nicht zugeorndet werden.\r\nBitte speichern Sie die Buchung und versuchen es nochmals.");
                return;
            }

            DlgKgDokumente dlg = new DlgKgDokumente();

            dlg.Init("ZKB Dokumente an Beleg " + (30000000000 + (int)qryKgBuchung["KgBuchungID"]) + " zuordnen",
                        (int)qryZahlungsausgang["BaPersonID"],
                        (int)qryKgBuchung["KgBuchungID"],
                        CtlKgDokumente.ZKBDokumentTypCode.Belastungsanzeige,
                        (string)qryKgBuchung["Text"]);

            dlg.ShowDialog();

            qryKgBuchung.Refresh();
        }

        private void CtlKgZahlungsausgang_Load(object sender, EventArgs e)
        {
            _buchungstext = new KgBuchungstext(edtBuchungstext, qryKgBuchung);

            tabControlSearch.SelectedTabIndex = 1;
            ApplicationFacade.DoEvents();
            tabControlSearch.SelectedTabIndex = 0;
        }

        private void edtBaPersonIDX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString;

            if (edtBaPersonIDX.Text == null)
            {
                searchString = "";
            }
            else
            {
                searchString = edtBaPersonIDX.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");
            }

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    KissMsg.ShowInfo("Bitte zuerst einen Suchbegriff eingeben!");
                }
                else
                {
                    edtBaPersonIDX.LookupID = DBNull.Value;
                    edtBaPersonIDX.EditValue = DBNull.Value;
                    return;
                }
                return;
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT BaPersonID$  = PRS.BaPersonID,
                     [Pers.-Nr]   = PRS.BaPersonID,
                     Name         = PRS.Name,
                     Vorname      = PRS.Vorname,
                     Wohnsitz     = PRS.Wohnsitz,
                     Klient$      = PRS.NameVorname
              FROM   dbo.vwPerson PRS
                INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) on LEI.BaPersonID = PRS.BaPersonID and
                                             LEI.FaProzessCode = 500
              WHERE  PRS.NameVorname like '%' + {0} + '%'
              ORDER BY PRS.NameVorname",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtBaPersonIDX.LookupID = dlg["BaPersonID$"];
                edtBaPersonIDX.Text = dlg["Klient$"] as string;
            }
        }

        private void edtBetrag_EditValueChanged(object sender, EventArgs e)
        {
            _bBuchungModified = true;
        }

        private void edtBuchungsdatum_EditValueChanged(object sender, EventArgs e)
        {
            _bBuchungModified = true;
        }

        private void edtBuchungstext_EditValueChanged(object sender, EventArgs e)
        {
            _bBuchungModified = true;
        }

        private void edtBuchungstext_TextChanged(object sender, EventArgs e)
        {
            if (edtBuchungstext.UserModified)
            {
                _buchungstext.FilterBuchungstext(edtBuchungstext.EditValue.ToString());
            }
        }

        private void edtKonto_EditValueChanged(object sender, EventArgs e)
        {
            _bBuchungModified = true;
        }

        private void edtKonto_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKonto.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryKgBuchung["SollKtoNr"] = DBNull.Value;
                    qryKgBuchung["Konto"] = DBNull.Value;

                    qryKontoVorschau.Fill(-1, -1);
                    grbAusgaben.Text = "Ausgaben des Mandanten";

                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT distinct
                     Konto   = KTO.KontoNr,
                     Name    = KTO.KontoName,
                     Klasse  = KLA.Text,
                     Konto$  = KTO.KontoNr + ' ' + KTO.KontoName
              FROM   FaLeistung LEI
                     INNER JOIN KgPeriode    PER ON PER.FaLeistungID = LEI.FaLeistungID AND
                                                    PER.KgPeriodeStatusCode = 1 --Aktiv
                     INNER JOIN KgKonto      KTO ON KTO.KgPeriodeID = PER.KgPeriodeID AND
                                                    KTO.KontoGruppe = 0
                     LEFT  JOIN XLOVCode     KLA ON KLA.LOVName = 'KgKontoKlasse' AND
                                                    KLA.Code = KTO.KgKontoKlasseCode
              WHERE  LEI.BaPersonID = {1}  AND
                     (KTO.KontoName like '%' + {0} + '%' OR
                      KTO.KontoNr like {0} + '%')
              ORDER BY KTO.KontoNr",
              searchString,
              e.ButtonClicked, qryZahlungsausgang["BaPersonID"]);

            if (!e.Cancel)
            {
                qryKgBuchung["SollKtoNr"] = dlg["Konto"];
                qryKgBuchung["Konto"] = dlg["Konto$"];
                qryKgBuchung["Text"] = dlg["Name"];

                qryKontoVorschau.Fill(qryZahlungsausgang["BaPersonID"], qryKgBuchung["SollKtoNr"]);

                if (!DBUtil.IsEmpty(qryKgBuchung["SollKtoNr"]))
                {
                    grbAusgaben.Text = "Ausgaben des Mandanten für Konto " + qryKgBuchung["SollKtoNr"];
                }
                else
                {
                    grbAusgaben.Text = "Ausgaben des Mandanten";
                }

                _buchungstext.LoadBuchungstext(qryKgBuchung["SollKtoNr"], true);
            }
        }

        private void grvAusgleich_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = grvAusgleich.CalcHitInfo(new Point(e.X, e.Y));

                string dokIDs = string.Empty;
                int? anzDoks = qryKgBuchung["AnzahlDokumente"] as int?;

                if (!DBUtil.IsEmpty(qryKgBuchung["DocIDsBuchung"]))
                {
                    dokIDs += (string)qryKgBuchung["DocIDsBuchung"];
                }

                qryDocument.Fill(qryDocument.SelectStatement, dokIDs);

                if (info == null || info.Column == null || info.Column.Name != "colDokumente" || anzDoks == null || anzDoks == 0)
                {
                    return;
                }

                if (anzDoks == 1)
                {
                    int kgDokumentID;

                    if (int.TryParse(dokIDs, out kgDokumentID))
                    {
                        int docID = (int)DBUtil.ExecuteScalarSQLThrowingException(@"SELECT DocumentID FROM KgDokument WHERE KgDokumentID = {0}", kgDokumentID);
                        edtDokumentHidden.DocumentID = docID;
                        edtDokumentHidden.OpenDoc();
                    }
                }
                else if (anzDoks > 1)
                {
                    KissLookupDialog dlg = new KissLookupDialog();
                    dlg.SearchData(@"
                        SELECT ID$ = KDOK.DocumentID,
                                Stichtag = KDOK.Stichtag,
                                Stichwort = KDOK.Stichwort,
                                Typ = LOV.Text,
                                [ZKB-Typ] = ISNULL(LOVZKB.Text, ''),
                                Erstellungsdatum = DOC.DateCreation,
                                [Letzte Speicherung] = DOC.DateLastSave
                        FROM   KgDokument KDOK
                        LEFT JOIN XLOVCode LOV ON LOV.LOVName = 'KgDokumentTyp' AND LOV.Code = KDOK.KgDokumentTypCode
                        LEFT JOIN SstZKBDokumente DOCZKB ON DOCZKB.DocumentID = KDOK.DocumentID
                        LEFT JOIN XLOVCode LOVZKB ON LOVZKB.LOVName = 'ZKBDokumentTyp' AND LOVZKB.Code = DOCZKB.ZKBDokumentTypCode
                        INNER JOIN XDocument DOC ON DOC.DocumentID = KDOK.DocumentID
                        WHERE KDOK.KgDokumentID IN (SELECT SplitValue FROM dbo.fnSplitStringToValues({0}, ',', 1))
                        ORDER BY KDOK.Stichtag DESC",
                        dokIDs,
                        true);

                    edtDokumentHidden.DocumentID = dlg["ID$"];
                    edtDokumentHidden.OpenDoc();
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }
        }

        private void qryKgBuchung_AfterInsert(object sender, EventArgs e)
        {
            decimal summe = GetSummeBuchungen();
            edtKonto.Focus();
            qryKgBuchung["Text"] = "";
            int? kgZahlungseingangartCode = qryZahlungsausgang["KgZahlungseingangArtCode"] as int?;
            if (kgZahlungseingangartCode.HasValue)
            {
                string kontoNr = DBUtil.GetConfigString(@"System\Vormundschaft\MT940Verarbeitung\AbbildungGVCaufKontoNr\" + kgZahlungseingangartCode.ToString(), null);
                if (!DBUtil.IsEmpty(kontoNr))
                {
                    edtKonto.EditValue = kontoNr;
                    edtKonto_UserModifiedFld(edtKonto, new UserModifiedFldEventArgs(false));
                    edtBuchungstext.Focus();
                }
            }
            qryKgBuchung["KgBuchungTypCode"] = 2;
            qryKgBuchung["KgZahlungseingangID"] = qryZahlungsausgang["KgZahlungseingangID"];
            qryKgBuchung["Buchungsdatum"] = qryZahlungsausgang["Datum"];
            qryKgBuchung["ErstelltUserID"] = Session.User.UserID;
            qryKgBuchung["Betrag"] = -(decimal)qryZahlungsausgang["Betrag"] - summe; // Betrag auf MT940 ist negativ
            qryKgBuchung["ValutaDatum"] = qryKgBuchung["Buchungsdatum"];

            _buchungstext.LoadBuchungstext(null, false);
            if (edtBuchungstext.EditValue != null)
            {
                _buchungstext.FilterBuchungstext(edtBuchungstext.EditValue.ToString());
            }

            qryKgBuchung.RowModified = false;
            _bBuchungModified = false;
        }

        private void qryKgBuchung_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtKonto, lblKonto2.Text);
            DBUtil.CheckNotNullField(edtBuchungsdatum, lblBuchungsDatum.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);
            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext2.Text);

            DateTime now = DateTime.Now;

            int? kgPeriodeID = DBUtil.ExecuteScalarSQL(@"SELECT TOP 1 KgPeriodeID
                FROM dbo.FaLeistung LEI
                    INNER JOIN dbo.KgPeriode PER ON PER.FaLeistungID = LEI.FaLeistungID AND PER.KgPeriodeStatusCode = 1 /*aktiv*/
                WHERE LEI.BaPersonID = {0} AND LEI.FaProzessCode = 500 AND {1} BETWEEN PER.PeriodeVon AND PER.PeriodeBis", qryZahlungsausgang["BaPersonID"], edtBuchungsdatum.EditValue) as int?;

            if (DBUtil.IsEmpty(kgPeriodeID))
            {
                KissMsg.ShowError("Keine aktive Periode gefunden.");
                throw new KissCancelException("Keine aktive Periode gefunden.");
            }

            qryKgBuchung["KgPeriodeID"] = kgPeriodeID;
            string habenKtoNr = GetKontokorrentkonto();

            if (DBUtil.IsEmpty(habenKtoNr))
            {
                KissMsg.ShowError("Keine Kontokorrentkonto in aktiver Periode gefunden.");
                throw new KissCancelException("Keine Kontokorrentkonto in aktiver Periode gefunden.");
            }
            qryKgBuchung["HabenKtoNr"] = habenKtoNr;

            if (qryKgBuchung.Row.RowState == DataRowState.Added)
            {
                qryKgBuchung["ErstelltDatum"] = now;
            }
            qryKgBuchung["MutiertUserID"] = Session.User.UserID;
            qryKgBuchung["MutiertDatum"] = now;
        }

        private void qryKgBuchung_PositionChanged(object sender, EventArgs e)
        {
            qryKontoVorschau.Fill(qryZahlungsausgang["BaPersonID"], qryKgBuchung["SollKtoNr"]);

            if (!DBUtil.IsEmpty(qryKgBuchung["SollKtoNr"]))
            {
                grbAusgaben.Text = "Ausgaben des Mandanten für Konto " + qryKgBuchung["SollKtoNr"];
            }
            else
            {
                grbAusgaben.Text = "Ausgaben des Mandanten";
            }

            _buchungstext.LoadBuchungstext(qryKgBuchung["SollKtoNr"], false);

            edtBuchungstext.Focus();
        }

        private void qryKgBuchung_PostCompleted(object sender, EventArgs e)
        {
            qryZahlungsausgang["Ausgeglichen"] = (GetSummeBuchungen() == -(decimal)qryZahlungsausgang["Betrag"]);
        }

        private void qryZahlungsausgang_AfterFill(object sender, EventArgs e)
        {
            qryKgBuchung.EnableBoundFields(qryZahlungsausgang.Count == 0);
            UpdateCounters();
        }

        private void qryZahlungsausgang_PositionChanged(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryZahlungsausgang["Mandant"]))
            {
                edtKonto.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
                edtBuchungsdatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
                edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
                edtBuchungstext.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            }
            else
            {
                edtKonto.EditMode = Kiss.Interfaces.UI.EditModeType.Normal;
                edtBuchungsdatum.EditMode = Kiss.Interfaces.UI.EditModeType.Normal;
                edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.Normal;
                edtBuchungstext.EditMode = Kiss.Interfaces.UI.EditModeType.Normal;

                qryKgBuchung.Fill(qryZahlungsausgang["KgZahlungseingangID"]);

                if (!(bool)qryZahlungsausgang["Ausgeglichen"])
                {
                    qryKgBuchung.Insert();
                }
                SetTextOnButtons();
            }
        }

        private void qryZahlungseingang_AfterPost(object sender, EventArgs e)
        {
            UpdateCounters();
        }

        private void qryZahlungseingang_BeforePost(object sender, EventArgs e)
        {
            if (!qryKgBuchung.Post())
            {
                throw new KissCancelException("Die Buchung konnte nicht gespeichert werden.");
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnAddData()
        {
            qryKgBuchung.Insert();
            return true;
        }

        public override bool OnDeleteData()
        {
            return qryKgBuchung.Delete();
        }

        public override bool OnSaveData()
        {
            if (!_bBuchungModified || qryKgBuchung.Row == null)
            {
                return true;
            }
            try
            {
                Session.BeginTransaction();
                if (qryKgBuchung.Row.RowState == DataRowState.Added)
                {
                    qryKgBuchung.RowModified = true;
                }
                qryKgBuchung.Post();
                qryZahlungsausgang.Post();
                Session.Commit();
                if (!DBUtil.IsEmpty(qryZahlungsausgang["Ausgeglichen"]) && !(bool)qryZahlungsausgang["Ausgeglichen"])
                {
                    qryKgBuchung.Insert();
                }
                return true;
            }
            catch (KissCancelException cex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                cex.ShowMessage();
                return false;
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }
                throw ex;
            }
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtNurAusgeglichenX.Checked = true;
            rbtnLebend.EditValue = 0;
            edtDatumVonX.Focus();
        }

        protected override void RunSearch()
        {
            qryKgBuchung.Refresh();
            qryKgBuchung.EnableBoundFields(false);
            base.RunSearch();
            qryZahlungsausgang.Fill();
            qryZahlungsausgang.Last();
        }

        #endregion

        #region Private Methods

        private string GetKontokorrentkonto()
        {
            return DBUtil.ExecuteScalarSQLThrowingException(@"SELECT TOP 1 KontoNr FROM dbo.FaLeistung LEI
                    INNER JOIN dbo.KgPeriode PER ON PER.FaLeistungID = LEI.FaLeistungID AND {1} BETWEEN PER.PeriodeVon AND PER.PeriodeBis AND PER.KgPeriodeStatusCode = 1 /*aktiv*/
                    INNER JOIN dbo.KgKonto KON ON KON.KgPeriodeID = PER.KgPeriodeID AND KgKontoartCode = 1 /*Kontokorrentkonto*/
                WHERE LEI.BaPersonID = {0} AND LEI.FaProzessCode = 500", qryZahlungsausgang["BaPersonID"], edtBuchungsdatum.EditValue) as string;
        }

        //// ComponentName: repositoryItemTextEdit1
        //private void repositoryItemTextEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        //{
        //    //if ((bool)qryZahlungseingang["Ausgeglichen"]) return;
        //    //qryAusgleich["AusglBetrag"] = e.NewValue;
        //    //UpdateAusgleichSum();
        //}
        private decimal GetSummeBuchungen()
        {
            decimal summe = 0;
            foreach (DataRow row in qryKgBuchung.DataTable.Rows)
            {
                if (row.RowState == DataRowState.Unchanged && !DBUtil.IsEmpty(row["Betrag"]))
                {
                    summe += (decimal)row["Betrag"];
                }
            }
            return summe;
        }

        private void SetTextOnButtons()
        {
            if (!(bool)qryZahlungsausgang["Ausgeglichen"])
            {
                btnEintragAusgleichen.Text = "Eintrag als ausgeglichen markieren";
            }
            else
            {
                btnEintragAusgleichen.Text = "Eintrag als nicht ausgeglichen markieren";
            }
        }

        private void UpdateCounters()
        {
            edtAnzahl.EditValue = qryZahlungsausgang.Count;
            decimal sum = 0;

            foreach (DataRow row in qryZahlungsausgang.DataTable.Rows)
            {
                if (row["Betrag"] is decimal)
                {
                    sum += (decimal)row["Betrag"];
                }
            }

            edtTotal.EditValue = sum;
        }

        #endregion

        #endregion
    }
}