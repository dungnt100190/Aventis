using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft.ZH
{
    public partial class CtlKgDokumentenPool : KissUserControl
    {
        private int _baPersonID = 0;
        private int _kgBuchungID = 0;
        private bool _onlyShowDocsFromPerson = false;
        private KiSS4.Vormundschaft.ZH.CtlKgDokumente.ZKBDokumentTypCode _zkbDokumentTypCodeToAssign = KiSS4.Vormundschaft.ZH.CtlKgDokumente.ZKBDokumentTypCode.Alle;

        public CtlKgDokumentenPool()
        {
            InitializeComponent();
            ReloadDokumentListe();
            grvQuery1.OptionsView.ShowGroupPanel = true;
            grvQuery1.OptionsBehavior.AutoExpandAllGroups = true;
        }

        // Falls true, werden nur Dokumente angezeigt, die dieser Person zugeordnet sind (keine Fremden, und keine noch überhaupt nicht zugeordnete Dokumente)
        public event EventHandler CloseEvent;

        public void Init(string titleName, Image titleImage)
        {
            Init(0, 0, CtlKgDokumente.ZKBDokumentTypCode.Alle, "");
        }

        public void Init(int baPersonID, int kgBuchungID, KiSS4.Vormundschaft.ZH.CtlKgDokumente.ZKBDokumentTypCode zkbDokumentTypCodeToAssign, string stichwort)
        {
            _baPersonID = baPersonID;
            _kgBuchungID = kgBuchungID;
            _zkbDokumentTypCodeToAssign = zkbDokumentTypCodeToAssign;
            edtStichworte.EditValue = stichwort;

            if (_baPersonID > 0)
            {
                // Person übergeben, selektiere den Mandanten dazu (der Mandant kann nicht mehr gewechselt werden)
                _onlyShowDocsFromPerson = true;
                edtBaPersonID.EditValue = _baPersonID;
                ctlGotoFall.BaPersonID = _baPersonID;
                edtMandant.EditValue = DBUtil.ExecuteScalarSQL("SELECT DisplayText FROM vwPerson WHERE BaPersonID = {0}", _baPersonID);
                edtMandant.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
                btnAutomatischeZuordnungStarten.Visible = false;
                LoadKonti();
            }

            if (_kgBuchungID > 0)
            {
                // Der Dialog wird mit einer Buchung initialisiert, d.h. der Benutzer kann Konto nicht wählen
                edtKgKonto.Visible = false;
                lblBaZahlungsweg.Text = "Selektierte Dokumente werden der Buchung " + (30000000000 + _kgBuchungID) + " zugeordnet";

                // Dafür können auch bereits zugeordnete Dokumente angezeigt werden (Gleicher Klient)
                edtNurNichtZugeordneteDoks.Visible = true;
            }

            ReloadDokumentListe();
        }

        /// <summary>
        /// Initialisiere die Maske nur für den Klienten, und nur für Gutschriften und Belastungen
        /// </summary>
        /// <param name="baPersonID"></param>
        public void InitOnlyForPerson(int baPersonID)
        {
            edtNurNichtZugeordneteDoks.EditValue = false;
            Init(baPersonID, 0, CtlKgDokumente.ZKBDokumentTypCode.NurGutschriftenUndBelastungen, "");

            lblZKBDokumente.Text = "ZKB Dokumenten-Pool (Gutschriften/Belastungen)";

            lblMandant.Visible = false;
            edtMandant.Visible = false;
            edtBaPersonID.Visible = false;
            ctlGotoFall.Visible = false;
            lblBaZahlungsweg.Visible = false;
            edtKgKonto.Visible = false;
            lblStichwort.Visible = false;
            edtStichworte.Visible = false;
            btnZuordnen.Visible = false;
            colSel.Visible = false;
            btnSelektionEntfernen.Visible = false;
        }

        protected void OnCloseEvent()
        {
            if (CloseEvent != null)
            {
                CloseEvent(this, null);
            }
        }

        private void btnAutomatischeZuordnungStarten_Click(object sender, EventArgs e)
        {
            DBUtil.ExecSQLThrowingException("EXEC spSstZKBDokumenteZuordnen");

            KissMsg.ShowInfo("Die automatische Zuordnung der noch nicht zugeordneten ZKB-Dokumente ist nochmals durchgeführt worden.");

            ReloadDokumentListe();
        }

        private void btnDokOeffnen_Click(object sender, EventArgs e)
        {
            DokumentOeffnen();
        }

        private void btnSelektionEntfernen_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in qryZKBDokumente.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"])) row["Sel"] = false;
            }
        }

        private void btnZuordnen_Click(object sender, EventArgs e)
        {
            int count = 0;

            if (DBUtil.IsEmpty(edtBaPersonID.EditValue))
            {
                KissMsg.ShowInfo("Bitte selektieren Sie zuerst einen Mandanten");
                return;
            }

            if (DBUtil.IsEmpty(edtStichworte.EditValue))
            {
                edtStichworte.EditValue = "-";
            }

            foreach (DataRow row in qryZKBDokumente.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                {
                    try
                    {
                        int? kontoID = (int?)edtKgKonto.EditValue;

                        int kgDokTypeCode = 6;  // 6 = Mandant
                        if (!DBUtil.IsEmpty(edtKgKonto.EditValue))
                        {
                            kgDokTypeCode = 5;  // 5 = Konto
                        }
                        if (_kgBuchungID > 0)
                        {
                            kgDokTypeCode = 4;  // 4 = Buchung
                        }

                        if ((int)row["ZKBDokumentTypCode"] != (int)KiSS4.Vormundschaft.ZH.CtlKgDokumente.ZKBDokumentTypCode.Kontoauszug)
                        {
                            kontoID = null; // Nur Kontoauszüge werden aufs Kontokorrent-Konto gebucht
                        }

                        int? buchungID = _kgBuchungID > 0 ? (int?)_kgBuchungID : null;

                        // Falls bereits in K-Dokument existiert, und neu die BuchungsID gesetzt werden soll, wird der existierende Eintrag updated.
                        if (!DBUtil.IsEmpty(row["KgDokumentID"]) && buchungID != null && DBUtil.IsEmpty(row["BelegNr"]))
                        {
                            // Ein bereits existierender KgDokument-Eintrag soll lediglich mit dem Beleg-Eintrag (und Stichwort) ergänzt werden
                            DBUtil.ExecSQLThrowingException(@"UPDATE KgDokument SET Stichwort = {0}, KgBuchungID = {1} WHERE KgDokumentID = {2}", edtStichworte.EditValue, buchungID, row["KgDokumentID"]);
                        }
                        else
                        {
                            DBUtil.ExecSQLThrowingException(@"INSERT INTO KgDokument (KgDokumentTypCode, DocumentID, Stichwort, Stichtag, BaPersonID, KgKontoID, KgBuchungID)
                                                                            VALUES
                                                                            (
                                                                                {0},
                                                                                {1},
                                                                                {2},
                                                                                {3},
                                                                                {4},
                                                                                {5},
                                                                                {6}
                                                                            )", kgDokTypeCode, row["DocumentID"], edtStichworte.EditValue, row["Stichtag"], edtBaPersonID.EditValue, kontoID, buchungID);
                        }
                        row["Sel"] = false;
                        count++;
                    }
                    catch (Exception ex)
                    {
                        KissMsg.ShowError("Fehler beim Zuordnen des ZKB-Dokuments zum Mandanten:" + ex.ToString());
                    }
                }
            }

            // KissMsg.ShowInfo(string.Format("{0} ZKB Dokumente wurden dem Mandanten {1}, PersonNr {2} zugewiesen", count, edtMandant.EditValue, edtBaPersonID.EditValue));

            if (count > 0)
            {
                ReloadDokumentListe();
                OnCloseEvent();
            }
        }

        private void DokumentOeffnen()
        {
            edtDokumentHidden.DocumentID = qryZKBDokumente["DocumentID"];
            edtDokumentHidden.OpenDoc();
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            ReloadDokumentListe();
        }

        private void edtMandant_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string SearchString = DBUtil.IsEmpty(edtMandant.EditValue) ? "%" : edtMandant.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    KissMsg.ShowInfo("Bitte zuerst einen Suchbegriff eingeben!");
                }
                else
                {
                    edtBaPersonID.EditValue = "";
                    edtMandant.EditValue = "";
                    ctlGotoFall.BaPersonID = 0;
                }
                return;
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              DECLARE @suchID INT
              IF ISNUMERIC({0}) = 1 AND CHARINDEX('.', {0}) = 0 AND CHARINDEX(',', {0}) = 0 BEGIN
                SELECT @suchID =  CONVERT(int, {0})
              END
              SELECT BaPersonID$  = PRS.BaPersonID,
                     [Pers.-Nr]   = PRS.BaPersonID,
                     Name         = PRS.Name,
                     Vorname      = PRS.Vorname,
                     Wohnsitz     = PRS.Wohnsitz,
                     [Beist. oder Vorm.] = dbo.fnVmGetMTName(PRS.BaPersonID),
                     Mandant$     = PRS.DisplayText
              FROM   dbo.vwPerson PRS
                     inner join dbo.FaLeistung LEI WITH (READUNCOMMITTED) on LEI.BaPersonID = PRS.BaPersonID and
                                                  LEI.FaProzessCode = 500
              WHERE  PRS.DisplayText like '%' + {0} + '%'
                     OR LEI.FaFallID = @suchID OR PRS.BaPersonID = @suchID
              ORDER BY PRS.DisplayText",
              SearchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg["BaPersonID$"];
                edtMandant.EditValue = dlg["Mandant$"];
                ctlGotoFall.BaPersonID = dlg["BaPersonID$"];
                LoadKonti();
            }
        }

        private void edtNurNichtZugeordneteDoks_CheckedChanged(object sender, EventArgs e)
        {
            ReloadDokumentListe();
        }

        private void grdZKBDokumente_DoubleClick(object sender, EventArgs e)
        {
            DokumentOeffnen();
        }

        private void LoadKonti()
        {
            if (DBUtil.IsEmpty(edtBaPersonID.EditValue))
            {
                edtKgKonto.LoadQuery(DBUtil.OpenSQL("Select * from BaZahlungsweg 0 = 1"));    // Leere Liste
            }
            else
            {
                edtKgKonto.LoadQuery(DBUtil.OpenSQL(@"
                    Select DISTINCT
                        Code = KON.KgKontoID,
                        Text = 'Periode ' + ISNULL(CONVERT(varchar, PER.PeriodeVon, 104), '') +
                        ' - ' +
                        ISNULL(CONVERT(varchar, PER.PeriodeBis, 104), '') +
                        ISNULL(', ' + BNK.Name, '') +
                        ISNULL(', ' + ZAH.BankKontoNummer, '') +
                        ', ' + EIZ.ShortText +
                        ISNULL(', ' + dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer,BNK.PCKontoNr)),'')
                    FROM  dbo.BaZahlungsweg ZAH WITH (READUNCOMMITTED)
                           LEFT  JOIN dbo.BaBank         BNK  WITH (READUNCOMMITTED) ON BNK.BaBankID = ZAH.BaBankID
                           LEFT  JOIN dbo.XLOVCode       EIZ  WITH (READUNCOMMITTED) ON EIZ.LOVName = 'BgEinzahlungsschein' AND
                                                                  EIZ.Code = ZAH.EinzahlungsscheinCode
                            INNER JOIN KgPeriode PER WITH (READUNCOMMITTED) ON PER.BaZahlungswegID = ZAH.BaZahlungswegID
                            INNER JOIN KgKonto KON  WITH (READUNCOMMITTED) ON KON.KgPeriodeID = PER.KgPeriodeID AND KON.KgKontoartCode = 1 /* 1 = Kontokorrent */
                    WHERE ZAH.BaKontoartCode = 4 -- 4 = Verkehrskonto
                        AND ZAH.BaPersonID = {0}
                    ORDER BY 'Periode ' + ISNULL(CONVERT(varchar, PER.PeriodeVon, 104), '') +
                        ' - ' +
                        ISNULL(CONVERT(varchar, PER.PeriodeBis, 104), '') +
                        ISNULL(', ' + BNK.Name, '') +
                        ISNULL(', ' + ZAH.BankKontoNummer, '') +
                        ', ' + EIZ.ShortText +
                        ISNULL(', ' + dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer,BNK.PCKontoNr)),'') DESC", edtBaPersonID.EditValue));

                edtKgKonto.ItemIndex = 0;
            }
        }

        private void qryZKBDokumente_PositionChanged(object sender, EventArgs e)
        {
            if ((int)qryZKBDokumente["ZKBDokumentTypCode"] == (int)KiSS4.Vormundschaft.ZH.CtlKgDokumente.ZKBDokumentTypCode.Kontoauszug)
            {
                edtStichworte.EditValue = "Kontoauszug - " +
                    Utils.ConvertToDateTime(qryZKBDokumente["Stichtag"]).ToString("dd.MM.yyyy");
            }
        }

        private void ReloadDokumentListe()
        {
            // Entscheide, welche Typen gezeigt werden sollen
            bool zeigeKontoauszuege = (_zkbDokumentTypCodeToAssign == CtlKgDokumente.ZKBDokumentTypCode.Alle | _zkbDokumentTypCodeToAssign == CtlKgDokumente.ZKBDokumentTypCode.Kontoauszug) ? true : false;
            bool zeigeGutschriften = (_zkbDokumentTypCodeToAssign == CtlKgDokumente.ZKBDokumentTypCode.Alle | _zkbDokumentTypCodeToAssign == CtlKgDokumente.ZKBDokumentTypCode.Gutschriftanzeige | _zkbDokumentTypCodeToAssign == CtlKgDokumente.ZKBDokumentTypCode.NurGutschriftenUndBelastungen) ? true : false;
            bool zeigeBelastungen = (_zkbDokumentTypCodeToAssign == CtlKgDokumente.ZKBDokumentTypCode.Alle | _zkbDokumentTypCodeToAssign == CtlKgDokumente.ZKBDokumentTypCode.Belastungsanzeige | _zkbDokumentTypCodeToAssign == CtlKgDokumente.ZKBDokumentTypCode.NurGutschriftenUndBelastungen) ? true : false;

            qryZKBDokumente.Fill(edtNurNichtZugeordneteDoks.EditValue, edtFilter.Text, zeigeKontoauszuege, zeigeBelastungen, zeigeGutschriften, _onlyShowDocsFromPerson, _baPersonID);
            grvQuery1.OptionsView.ShowGroupPanel = true;
            grvQuery1.OptionsBehavior.AutoExpandAllGroups = true;
        }
    }
}