using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;
using SharpLibrary.WinControls;

namespace KiSS4.Vormundschaft.ZH
{
    public partial class CtlKgBuchung : KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID;
        private bool _filling;
        private bool _insertMode;
        private DataRow _saveRow;
        private int _selectedCount;

        #endregion

        #endregion

        #region Constructors

        public CtlKgBuchung()
        {
            InitializeComponent();
            lblSucheKreditorBaZahlungswegID.Text = null;
            lblSucheDebitorBaInstitutionID.Text = null;
            tabControlBuchung.SelectedTabIndex = 1;
        }

        #endregion

        #region EventHandlers

        private void btnAlle_Click(object sender, EventArgs e)
        {
            SelectAllOrNothing(true);
        }

        private void btnKeine_Click(object sender, EventArgs e)
        {
            SelectAllOrNothing(false);
        }

        private void btnKopie_Click(object sender, EventArgs e)
        {
            // Varianten:
            // Fall 0: Restbetrag (KgBuchungTyp 5): Dieser Spezialfall wird nicht unterstützt,
            //      Es gibt bisher nur drei Buchungen dieses Typs. Es wurde weder überprüft ob für
            //      diese Buchungen eine Kopie sinnvoll ist noch wie sie zu durchzuführen wäre.
            // Fall 1: stornierte Buchung: Erzeugen einer Neubuchung
            // Fall 2: übertragene Buchung aus Monatsbudget: Erzeugen einer übertragbaren, manuellen Buchung
            // Fall 3: manuelle Buchung: erzeugen einer weiteren manuellen Buchung
            if (qryKgBuchung["KgBuchungTypCode"] as int? == 5)
            {
                KissMsg.ShowInfo("Das Kopieren einer Buchung des Buchungtyps 'Restbetrag' wird nicht unterstützt.");
                return;
            }
            if (!qryKgBuchung.Post())
            {
                return;
            }

            DataRow row = qryKgBuchung.Row;
            qryKgBuchung.Insert();

            foreach (DataColumn col in qryKgBuchung.DataTable.Columns)
            {
                qryKgBuchung[col.ColumnName] = row[col.ColumnName];
            }
            qryKgBuchung["KgBuchungID"] = null;
            qryKgBuchung["KgBuchungTS"] = null;
            // Periode und Buchungsdatum belassen, wird beim Speichern überprüft
            qryKgBuchung["KgPeriodeStatusCode"] = 1; // aktiv, gerade vorher getestet
            qryKgBuchung["KgPositionID"] = null; // Keine Position vorhanden, die neue Buchung ist eine manuelle Buchung
            qryKgBuchung["KgBuchungTypCode"] = 2; // Manuell
            qryKgBuchung["KgAusgleichStatusCode"] = 1;
            // bisher KgAusgleichStatusCode:
            // - bei manuellen buchungen null, ausser es ist eine Kopie einer Budgetbuchung
            // - Bei Budgetbuchung immer 1
            // - Bei Ausgleich (Einzahlung) immer NULL
            // - Bei Automatisch(er Ausgleich Auszahlung) NULL oder 3
            // => sehr unzuverlässige Angabe
            // Auswertung der Angabe: nur in CtlKgZahlungseingang, um Ausgleiche den richtigen Buchungen zuzuordnen
            qryKgBuchung["KgZahlungseingangID"] = null;
            // CodeVorlage: kopieren (ist immer null, wird nie verwendet)
            qryKgBuchung["BelegNr"] = null;
            qryKgBuchung["BelegNrPos"] = null;
            qryKgBuchung["BuchungsDatum"] = DateTime.Today;
            // SollKtoNr: kopieren
            // HabenKtoNr: kopieren
            // Betrag: kopieren
            // BetragFW: kopieren (ist immer null, wird nie verwendet)
            // FbWaehrungID: kopieren (ist immer null, wird nie verwendet)
            // Text: kopieren
            qryKgBuchung["ValutaDatum"] = DateTime.Today;
            qryKgBuchung["BarbezugDatum"] = null;
            qryKgBuchung["TransferDatum"] = null;
            qryKgBuchung["KgBuchungStatusCode"] = 2; //freigegeben / grün
            // UserIDKasse: kopieren (ist immer null, wird nie verwendet)
            // BaZahlungswegID: kopieren
            // BaInstitutionID: kopieren
            // EinzahlungsscheinCode: kopieren
            // KgAuszahlungsArtCode: kopieren
            // BaBankID: kopieren: kopieren
            // BankKontoNummer: kopieren
            // IBANNummer: kopieren
            // PostKontoNummer: kopieren
            // ESRTeilnehmer: kopieren
            // ESRReferenznummer: kopieren
            // BeguenstigtName: kopieren
            // BeguenstigtName2: kopieren
            // BeguenstigtStrasse: kopieren
            // BeguenstigtHausNr: kopieren
            // BeguenstigtPostfach: kopieren
            // BeguenstigtOrt: kopieren
            // BeguenstigtPLZ: kopieren
            // BeguenstigtLandCode: kopieren
            // MitteilungZeile1: kopieren
            // MitteilungZeile2: kopieren
            // MitteilungZeile3: kopieren
            // MitteilungZeile4: kopieren
            qryKgBuchung["ErstelltUserID"] = Session.User.UserID;
            qryKgBuchung["ErstelltDatum"] = null; // wird automatisch befüllt
            qryKgBuchung["MutiertUserID"] = Session.User.UserID;
            qryKgBuchung["MutiertDatum"] = null; // wird automatisch befüllt
            qryKgBuchung["PscdFehlermeldung"] = null;
            qryKgBuchung["PscdBelegNr"] = null;
            qryKgBuchung["StorniertKgBuchungID"] = null;
            qryKgBuchung["NeubuchungVonKgBuchungID"] = null;
            //Debitor: kopieren
            //Kreditor: kopieren
            //ZusatzInfo: kopieren
            //PeriodeInfo: kopieren
            //POS.Bemerkung: kopieren
            qryKgBuchung["JumpToMBPfad"] = null;
            qryKgBuchung["JumpToKgPositionID"] = null;
            qryKgBuchung["Sel"] = null;
            // FaFallID: kopieren

            // KgBuchungstatuscode kann NULL sein (nur bei bei KgBuchungTyp 3:automatisch, 4:Ausgleich, 5:Restbetrag)
            if (!DBUtil.IsEmpty(row["KgBuchungStatusCode"]) && (int)row["KgBuchungStatusCode"] == 8) //Storno
            {
                qryKgBuchung["NeubuchungVonKgBuchungID"] = row["KgBuchungID"];
                qryKgBuchung["Text"] = "NEU " + row["KgBuchungID"] + ", " + row["Text"];
            }
            SetEditMode();

            edtDatum.Focus();
        }

        private void btnMonatsbudget_Click(object sender, EventArgs e)
        {
            if (qryKgBuchung.Count == 0 || DBUtil.IsEmpty(qryKgBuchung["JumpToMBPfad"])) return;

            FormController.OpenForm("FrmFall", "Action", "JumpToNodeByFieldValue",
                        "BaPersonID", qryKgBuchung["FallBaPersonID"],
                        "ModulID", 5,
                        "FieldValue", qryKgBuchung["JumpToMBPfad"]);
            Control control = Session.MainForm.ActiveControl;
            if (qryKgBuchung["JumpToKgPositionID"] is int && control.Name.Equals("FrmFall"))
            {
                System.Collections.Specialized.HybridDictionary param = new System.Collections.Specialized.HybridDictionary();
                param.Add("Action", "JumpToPath");
                param.Add("ActiveSQLQuery.Find", "KgPositionID = " + qryKgBuchung["JumpToKgPositionID"]);
                param.Add("BaPersonID", qryKgBuchung["FallBaPersonID"]);
                param.Add("ModulID", 5);
                param.Add("FaFallID", qryKgBuchung["FaFallID"]);

                FormController.SendMessage((KissChildForm)control, param);
            }
            //Session.MainForm.ActiveControl
            //FormController.SendMessage(, param);// qryKgBuchung["classname"]
        }

        private void btnStorno_Click(object sender, EventArgs e)
        {
            // Allfällige Änderungen Speichern
            if (!qryKgBuchung.Post())
            {
                return;
            }
            _selectedCount = CountSelected();

            if (_selectedCount == 0)
            {
                KissMsg.ShowInfo("Es wurde keine Buchung ausgewählt.");
                return;
            }

            string msg;

            if (_selectedCount == 1)
            {
                msg = "Soll eine Buchung storniert werden?";
            }
            else
            {
                msg = string.Format("Sollen {0} Buchungen storniert werden?", _selectedCount);
            }

            if (KissMsg.ShowQuestion(msg))
            {
                Cursor = Cursors.WaitCursor;
                DlgProgressLog.Show("Storno", 700, 500, StornoStart, StornoEnd, Session.MainForm);
                Cursor = Cursors.Default;
            }
        }

        private void CtlKgBuchung_Load(object sender, EventArgs e)
        {
            //Buchungsstati laden (ohne Code 1 grau)
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KgBuchungsStatus' and Code <> 1 order by SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    (int)row["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            colStatus3.ColumnEdit = repositoryItemImageComboBox1;

            // Dasselbe für edtSucheStatus
            edtSucheStatus.Properties.SmallImages = KissImageList.SmallImageList;
            edtSucheStatus.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, -1));
            foreach (DevExpress.XtraEditors.Controls.ImageComboBoxItem item in repositoryItemImageComboBox1.Items)
                edtSucheStatus.Properties.Items.Add(item);

            colTyp.ColumnEdit = grdPeriode.GetLOVLookUpEdit(DBUtil.OpenSQL(@"
                            select Code, Text = ShortText
                            from   XLOVCode
                            where  LOVName = 'KgBuchungTyp'"));

            lblDebitor.Location = lblKreditor.Location;
            edtDebitor.Location = edtKreditor.Location;
            lblZahlbarAn.Location = lblMitteilung.Location;

            tabZahlinfo.Visible = false;
            tpgAusgleich.HideTab = true;
            qryKgBuchung.EnableBoundFields(false);

            edtSucheErfasst.EditValue = Session.User.LogonName;
            edtSucheErfasst.LookupID = Session.User.UserID;

            tabControlSearch.SelectedTabIndex = 1;
            ApplicationFacade.DoEvents();

            tabControlSearch.SelectedTabIndex = 0;

            RunSearch();
            edtKeineResultate.Checked = false;
        }

        private void edtDebitor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtDebitor.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    KissMsg.ShowInfo("Bitte zuerst einen Suchbegriff eingeben!");
                }
                else
                {
                    qryKgBuchung["BaInstitutionID"] = DBNull.Value;
                    qryKgBuchung["Debitor"] = DBNull.Value;
                    qryKgBuchung["ZusatzInfo"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$                 = INS.BaInstitutionID,
                     Institution         = INS.Name,
                     Adresse             = INS.AdresseMehrzeilig,
                     Typ                 = INS.Typ
              FROM   vwInstitution INS
              WHERE  INS.Name LIKE '%' + {0} + '%' AND
                     INS.Debitor = 1 AND
                     INS.BaFreigabeStatusCode = 2 --definitv
              ORDER BY INS.Name",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryKgBuchung["BaInstitutionID"] = dlg["ID$"];
                qryKgBuchung["Debitor"] = dlg["Institution"];
                qryKgBuchung["ZusatzInfo"] = dlg["Adresse"];
            }
        }

        private void edtKontoBis_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            SetKontoNames();
        }

        private void edtKontoHaben_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = KontoSucheUndGridUpdate(edtKontoHaben, e.ButtonClicked);
        }

        private void edtKontoSoll_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = KontoSucheUndGridUpdate(edtKontoSoll, e.ButtonClicked);
        }

        private void edtKontoVon_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            SetKontoNames();
        }

        private void edtKreditor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKreditor.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryKgBuchung["Kreditor"] = DBNull.Value;
                    qryKgBuchung["ZusatzInfo"] = DBNull.Value;
                    qryKgBuchung["BaZahlungswegID"] = DBNull.Value;
                    qryKgBuchung["EinzahlungsscheinCode"] = DBNull.Value;
                    qryKgBuchung["BaBankID"] = DBNull.Value;
                    qryKgBuchung["BankKontoNummer"] = DBNull.Value;
                    qryKgBuchung["IBANNummer"] = DBNull.Value;
                    qryKgBuchung["PostKontoNummer"] = DBNull.Value;
                    qryKgBuchung["BeguenstigtName"] = DBNull.Value;
                    qryKgBuchung["BeguenstigtName2"] = DBNull.Value;
                    qryKgBuchung["BeguenstigtStrasse"] = DBNull.Value;
                    qryKgBuchung["BeguenstigtHausNr"] = DBNull.Value;
                    qryKgBuchung["BeguenstigtPostfach"] = DBNull.Value;
                    qryKgBuchung["BeguenstigtOrt"] = DBNull.Value;
                    qryKgBuchung["BeguenstigtPLZ"] = DBNull.Value;
                    qryKgBuchung["BeguenstigtLandCode"] = DBNull.Value;
                    return;
                }
            }

            if (searchString == ".")
            {
                KissLookupDialog dlg = new KissLookupDialog();

                e.Cancel = !dlg.SearchData(@"
                    SELECT ID$                    = KRE.BaZahlungswegID,
                           Person                 = KRE.PersonNameVorname,
                           Kontoart               = KRE.BaKontoart,
                           Zahlungsweg            = KRE.Zahlungsweg,
                           Kreditor$              = KRE.PersonNameVorname,
                           ZusatzInfo$            = KRE.ZusatzInfo,
                           BaZahlungswegID$       = KRE.BaZahlungswegID,
                           EinzahlungsscheinCode$ = KRE.EinzahlungsscheinCode,
                           BaBankID$              = KRE.BaBankID,
                           BankKontoNummer$       = KRE.BankKontoNummer,
                           IBANNummer$            = KRE.IBANNummer,
                           PostKontoNummer$       = KRE.PostKontoNummer,
                           Name$                  = KRE.BeguenstigtName,
                           AdressZusatz$          = KRE.BeguenstigtName2,
                           Strasse$               = KRE.BeguenstigtStrasse,
                           HausNr$                = KRE.BeguenstigtHausNr,
                           Postfach$              = KRE.BeguenstigtPostfach,
                           Ort$                   = KRE.BeguenstigtOrt,
                           PLZ$                   = KRE.BeguenstigtPLZ,
                           LandCode$              = KRE.BeguenstigtLandCode
                    FROM   vwKreditor KRE
                    WHERE  KRE.BaPersonID = {1} AND
                           IsNull(KRE.BaKontoartCode,0) <> 4 AND -- ohne Verkehrskonto
                           dbo.fnDateOf(GETDATE()) BETWEEN IsNull(KRE.ZahlungswegDatumVon,'1900-01-01') AND
                                                           IsNull(KRE.ZahlungswegDatumBis,'9999-12-31')",
                searchString,
                e.ButtonClicked, _baPersonID, null, null);

                if (!e.Cancel)
                {
                    qryKgBuchung["Kreditor"] = dlg["Kreditor$"];
                    qryKgBuchung["ZusatzInfo"] = dlg["ZusatzInfo$"];
                    qryKgBuchung["BaZahlungswegID"] = dlg["BaZahlungswegID$"];
                    qryKgBuchung["EinzahlungsscheinCode"] = dlg["EinzahlungsscheinCode$"];
                    qryKgBuchung["BaBankID"] = dlg["BaBankID$"];
                    qryKgBuchung["BankKontoNummer"] = dlg["BankKontoNummer$"];
                    qryKgBuchung["IBANNummer"] = dlg["IBANNummer$"];
                    qryKgBuchung["PostKontoNummer"] = dlg["PostKontoNummer$"];
                    qryKgBuchung["BeguenstigtName"] = dlg["Name$"];
                    qryKgBuchung["BeguenstigtName2"] = dlg["AdressZusatz$"];
                    qryKgBuchung["BeguenstigtStrasse"] = dlg["Strasse$"];
                    qryKgBuchung["BeguenstigtHausNr"] = dlg["HausNr$"];
                    qryKgBuchung["BeguenstigtPostfach"] = dlg["Postfach$"];
                    qryKgBuchung["BeguenstigtOrt"] = dlg["Ort$"];
                    qryKgBuchung["BeguenstigtPLZ"] = dlg["PLZ$"];
                    qryKgBuchung["BeguenstigtLandCode"] = dlg["LandCode$"];
                }
            }
            else
            {
                DlgKgAuswahlZahlungsweg dlg2 = new DlgKgAuswahlZahlungsweg();
                ApplicationFacade.DoEvents();

                bool transfer = false;
                dlg2.SucheBaZahlungsweg(searchString);
                switch (dlg2.Count)
                {
                    case 0: KissMsg.ShowInfo("Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                        break;

                    case 1: transfer = true;
                        break;

                    default: transfer = dlg2.ShowDialog(this) == DialogResult.OK;
                        break;
                }

                if (transfer)
                {
                    qryKgBuchung["Kreditor"] = dlg2["Kreditor"];
                    qryKgBuchung["ZusatzInfo"] = dlg2["ZusatzInfo"];
                    qryKgBuchung["BaZahlungswegID"] = dlg2["BaZahlungswegID"];
                    qryKgBuchung["EinzahlungsscheinCode"] = dlg2["EinzahlungsscheinCode"];
                    qryKgBuchung["BaBankID"] = dlg2["BaBankID"];
                    qryKgBuchung["BankKontoNummer"] = dlg2["BankKontoNummer"];
                    qryKgBuchung["IBANNummer"] = dlg2["IBANNummer"];
                    qryKgBuchung["PostKontoNummer"] = dlg2["PostKontoNummer"];
                    qryKgBuchung["BeguenstigtName"] = dlg2["InstitutionName"];  //Feld kommt aus vwKreditor -> heisst weiterhin InstitutionName
                    qryKgBuchung["BeguenstigtName2"] = dlg2["AdressZusatz"];
                    qryKgBuchung["BeguenstigtStrasse"] = dlg2["Strasse"];
                    qryKgBuchung["BeguenstigtHausNr"] = dlg2["HausNr"];
                    qryKgBuchung["BeguenstigtPostfach"] = dlg2["Postfach"];
                    qryKgBuchung["BeguenstigtOrt"] = dlg2["Ort"];
                    qryKgBuchung["BeguenstigtPLZ"] = dlg2["PLZ"];
                    qryKgBuchung["BeguenstigtLandCode"] = dlg2["LandCode"];
                }
            }
            qryKgBuchung.RefreshDisplay();
            SetEditMode();
        }

        private void edtMandant_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtMandant.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    _baPersonID = -1;
                    qryKgBuchung["Mandant"] = null;
                    qryKgBuchung["BaPersonID"] = null;
                    qryKgBuchung["Adresse"] = null;
                    qryKgBuchung["MTName"] = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              DECLARE @suchID INT
              IF ISNUMERIC({0}) = 1 AND CHARINDEX('.', {0}) = 0 AND CHARINDEX(',', {0}) = 0 BEGIN
                SELECT @suchID =  CONVERT(int, {0})
              END

              SELECT distinct
                     BaPersonID$      = PRS.BaPersonID,
                     [Personen-Nr.]   = PRS.BaPersonID,
                     Name             = PRS.NameVorname,
                     Geburtsdatum     = PRS.Geburtsdatum,
                     [Alter]          = PRS.[Alter],
                     Adresse          = PRS.Wohnsitz,
                     [Beist. oder Vorm.] = dbo.fnVmGetMTName(PRS.BaPersonID),
                     FallBaPersonID$  = FAL.BaPersonID
              FROM   vwPerson PRS
                     INNER JOIN dbo.FaLeistung LEI on LEI.BaPersonID = PRS.BaPersonID and
                                                  LEI.FaProzessCode = 500
                     INNER JOIN dbo.FaFall FAL ON FAL.FaFallID = LEI.FaFallID
              WHERE  PRS.NameVorname LIKE '%' + @p0 + '%'
                     OR LEI.FaFallID = @suchID OR PRS.BaPersonID = @suchID

              ORDER BY PRS.NameVorname",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                _baPersonID = (int)dlg["BaPersonID$"];
                qryKgBuchung["Mandant"] = dlg["Name"];
                qryKgBuchung["BaPersonID"] = dlg["BaPersonID$"];
                qryKgBuchung["Adresse"] = dlg["Adresse"];
                qryKgBuchung["MTName"] = dlg["Beist. oder Vorm."];
                qryKgBuchung["FallBaPersonID"] = dlg["FallBaPersonID$"];

                qryKgBuchung["KgPeriodeID"] = DBUtil.ExecuteScalarSQL(@"
                    select KgPeriodeID
                    from   KgPeriode PER
                           inner join FaLeistung LEI on LEI.FaLeistungID = PER.FaLeistungID
                    where  LEI.BaPersonID = {0} and
                           {1} between PER.PeriodeVon and PER.PeriodeBis",
                    qryKgBuchung["BaPersonID"],
                    qryKgBuchung["BuchungsDatum"]);

                DisplaySaldo(true);
                DisplaySaldo(false);
            }
        }

        private void edtSucheBelegNrBis_Enter(object sender, EventArgs e)
        {
            edtSucheBelegNrBis.SelectAll();
        }

        private void edtSucheBelegNrVon_Enter(object sender, EventArgs e)
        {
            edtSucheBelegNrVon.SelectAll();
        }

        private void edtSucheDebitor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtSucheDebitor.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    lblSucheDebitorBaInstitutionID.Text = null;
                    edtSucheDebitor.EditValue = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$                 = INS.BaInstitutionID,
                     Institution         = INS.Name,
                     Adresse             = INS.Adresse,
                     Typ                 = INS.Typ
              FROM   vwInstitution INS
              WHERE  INS.BaFreigabeStatusCode = 2 AND
                     INS.Name LIKE '%' + {0} + '%' AND
                     INS.Debitor = 1
              ORDER BY INS.Name",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                lblSucheDebitorBaInstitutionID.Text = dlg["ID$"].ToString();
                edtSucheDebitor.EditValue = dlg["Institution"];
            }
        }

        private void edtSucheErfasst_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = "";
            if (edtSucheErfasst.Text != null)
                searchString = edtSucheErfasst.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                    searchString = "%";
                else
                {
                    edtSucheErfasst.EditValue = DBNull.Value;
                    edtSucheErfasst.LookupID = DBNull.Value;
                    edtSucheErfasst.ToolTip = "";
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$ = UserID,
                [Kürzel] = LogonName,
                [Mitarbeiter/in] = NameVorname,
                [Org.Einheit] = OrgUnit,
                DisplayText$ = DisplayText
              FROM   vwUser
              WHERE  DisplayText LIKE '%' + {0} + '%'
              ORDER BY NameVorname",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtSucheErfasst.EditValue = dlg["Kürzel"];
                edtSucheErfasst.LookupID = dlg["ID$"];
                edtSucheErfasst.ToolTip = dlg["DisplayText$"].ToString();
            }
        }

        private void edtSucheKreditor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtSucheKreditor.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    lblSucheKreditorBaZahlungswegID.Text = null;
                    edtSucheKreditor.EditValue = null;
                    return;
                }
            }

            DlgKgAuswahlZahlungsweg dlg2 = new DlgKgAuswahlZahlungsweg();
            ApplicationFacade.DoEvents();

            bool auswahl = false;
            dlg2.SucheBaZahlungsweg(searchString);
            switch (dlg2.Count)
            {
                case 0: KissMsg.ShowInfo("Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                    break;

                case 1: auswahl = true;
                    break;

                default: auswahl = dlg2.ShowDialog(this) == DialogResult.OK;
                    break;
            }

            if (auswahl)
            {
                lblSucheKreditorBaZahlungswegID.Text = dlg2["BaZahlungswegID"].ToString();
                edtSucheKreditor.EditValue = dlg2["Kreditor"];
            }
            else
            {
                lblSucheKreditorBaZahlungswegID.Text = null;
                edtSucheKreditor.EditValue = null;
            }
        }

        private void edtSucheMandant_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = string.Empty;
            if (edtSucheMandant.EditValue != null)
                searchString = edtSucheMandant.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    _baPersonID = -1;
                    edtSucheMandant.EditValue = null;
                    edtSucheBaPersonID.EditValue = null;
                    edtSucheAdresse.EditValue = null;
                    edtSucheMT.EditValue = null;
                    if (qryPeriode.DataTable != null)
                        qryPeriode.DataTable.Rows.Clear();
                    qryPeriode.EnableBoundFields(false);
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              DECLARE @suchID INT
              IF ISNUMERIC({0}) = 1 AND CHARINDEX('.', {0}) = 0 AND CHARINDEX(',', {0}) = 0 BEGIN
                SELECT @suchID =  CONVERT(int, {0})
              END
              SELECT distinct
                     BaPersonID$      = PRS.BaPersonID,
                     [Personen-Nr.]   = PRS.BaPersonID,
                     Name             = PRS.NameVorname,
                     Geburtsdatum     = PRS.Geburtsdatum,
                     [Alter]          = PRS.[Alter],
                     Adresse          = PRS.Wohnsitz,
                     [Beist. oder Vorm.] = dbo.fnVmGetMTName(PRS.BaPersonID)
              FROM   vwPerson PRS
                     inner join FaLeistung LEI on LEI.BaPersonID = PRS.BaPersonID and
                                                  LEI.FaProzessCode = 500
              WHERE  PRS.NameVorname LIKE '%' + {0} + '%'
                     OR LEI.FaFallID = @suchID OR PRS.BaPersonID = @suchID
              ORDER BY PRS.NameVorname",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                _baPersonID = (int)dlg["BaPersonID$"];
                edtSucheMandant.EditValue = dlg["Name"];
                edtSucheBaPersonID.EditValue = dlg["BaPersonID$"];
                edtSucheAdresse.EditValue = dlg["Adresse"];
                edtSucheMT.EditValue = dlg["Beist. oder Vorm."];

                // Perioden anzeigen:
                qryPeriode.Fill(_baPersonID);
                try
                {
                    while (qryPeriode.Count > 0 &&
                        (DateTime.Today < (DateTime)qryPeriode["PeriodeVon"] || DateTime.Today > (DateTime)qryPeriode["PeriodeBis"]))
                    {
                        if (!qryPeriode.Next())
                        {
                            break;
                        }
                    }
                }
                catch
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
                edtSucheKgPeriodeID.EditValue = qryPeriode["KgPeriodeID"];
            }
        }

        private void edtText_Enter(object sender, EventArgs e)
        {
            edtText.SelectAll();
        }

        private void grvBuchungen_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column != colSelektion)
            {
                return;
            }
            bool rowModified = qryKgBuchung.RowModified;
            grvBuchungen.SetRowCellValue(e.RowHandle, colSelektion, e.Value);
            if (!rowModified)
            {
                qryKgBuchung.Row.AcceptChanges();
                qryKgBuchung.RowModified = false;
            }
            btnStorno.Enabled = CountSelected() > 0;
        }

        private void grvBuchungen_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == colSelektion)
            {
                if (DBUtil.IsEmpty(grvBuchungen.GetRowCellValue(e.RowHandle, e.Column)))
                {
                    e.RepositoryItem = repositoryItemTextEdit1;
                }
                else
                {
                    e.RepositoryItem = repositoryItemCheckEdit1;
                }
            }
        }

        private void lblDatum_Click(object sender, EventArgs e)
        {
            LabelClick(sender);
        }

        private void lblKontoHaben_Click(object sender, EventArgs e)
        {
            LabelClick(sender);
        }

        private void lblKontoSoll_Click(object sender, EventArgs e)
        {
            LabelClick(sender);
        }

        private void lblMandant_Click(object sender, EventArgs e)
        {
            LabelClick(sender);
        }

        private void lblText_Click(object sender, EventArgs e)
        {
            LabelClick(sender);
        }

        private void qryKgBuchung_AfterFill(object sender, EventArgs e)
        {
            qryKgBuchung.Last();
            lblRowCount.Text = qryKgBuchung.Count.ToString();
        }

        private void qryKgBuchung_AfterInsert(object sender, EventArgs e)
        {
            ctlErfassungMutation1.ShowInfo();

            _filling = true;

            edtSollSaldo.Text = "";
            edtHabenSaldo.Text = "";

            qryKgBuchung["KgBuchungTypCode"] = 2;    //manuell
            qryKgBuchung["KgAuszahlungsArtCode"] = 101;  //elektronische Auszahlung
            qryKgBuchung["KgBuchungStatusCode"] = 2;    //freigegeben (grün)
            qryKgBuchung["BuchungsDatum"] = DateTime.Today;

            if (_saveRow != null)
            {
                if (lblDatum.Font.Underline)
                    qryKgBuchung["BuchungsDatum"] = _saveRow["BuchungsDatum"];

                if (lblMandant.Font.Underline)
                {
                    qryKgBuchung["Mandant"] = _saveRow["Mandant"];
                    qryKgBuchung["BaPersonID"] = _saveRow["BaPersonID"];
                    qryKgBuchung["Adresse"] = _saveRow["Adresse"];
                    qryKgBuchung["KgPeriodeID"] = _saveRow["KgPeriodeID"];
                }

                if (lblKontoSoll.Font.Underline)
                {
                    qryKgBuchung["SollKtoNr"] = _saveRow["SollKtoNr"];
                    qryKgBuchung["SollKtoNrName"] = _saveRow["SollKtoNrName"];
                    qryKgBuchung["SollKontoartCode"] = _saveRow["SollKontoartCode"];
                    DisplaySaldo(true);
                }

                if (lblKontoHaben.Font.Underline)
                {
                    qryKgBuchung["HabenKtoNr"] = _saveRow["HabenKtoNr"];
                    qryKgBuchung["HabenKtoNrName"] = _saveRow["HabenKtoNrName"];
                    qryKgBuchung["HabenKontoartCode"] = _saveRow["HabenKontoartCode"];
                    DisplaySaldo(false);
                }

                if (lblText.Font.Underline) qryKgBuchung["Text"] = _saveRow["Text"];

                qryKgBuchung.RefreshDisplay();
            }

            SetEditMode();

            _filling = false;

            if (DBUtil.IsEmpty(qryKgBuchung["BuchungsDatum"]))
            {
                edtDatum.Focus();
            }
            else if (DBUtil.IsEmpty(qryKgBuchung["ValutaDatum"]))
            {
                edtValutaDatum.Focus();
            }
            else if (DBUtil.IsEmpty(qryKgBuchung["Mandant"]))
            {
                edtMandant.Focus();
            }
            else if (DBUtil.IsEmpty(qryKgBuchung["SollKtoNrName"]))
            {
                edtKontoSoll.Focus();
            }
            else if (DBUtil.IsEmpty(qryKgBuchung["HabenKtoNrName"]))
            {
                edtKontoHaben.Focus();
            }
            else if (DBUtil.IsEmpty(qryKgBuchung["Text"]))
            {
                edtText.Focus();
            }
            else
            {
                edtBetrag.Focus();
            }
        }

        private void qryKgBuchung_AfterPost(object sender, EventArgs e)
        {
            if (_insertMode)
            {
                _saveRow = qryKgBuchung.Row;
            }
            DisplaySaldo(true);
            DisplaySaldo(false);

            if (!qryKgDokumente.Post())
            {
                tabControlBuchung.SelectedTabIndex = 3;
                throw new KissCancelException();
            }
        }

        private void qryKgBuchung_BeforeDelete(object sender, EventArgs e)
        {
            if ((int)qryKgBuchung["KgBuchungTypCode"] != 2) //nicht manuell
            {
                KissMsg.ShowInfo("Buchungen, die nicht vom Typ 'manuell' sind, können nicht gelöscht werden!");
                throw new Exception();
            }

            if (qryKgBuchung.Row.RowState == DataRowState.Modified)
            {
                //check: Periode immer noch aktiv
                switch ((int)DBUtil.ExecuteScalarSQL("select KgPeriodeStatusCode from KgPeriode where KgPeriodeID = {0}",
                    qryKgBuchung["KgPeriodeID"]))
                {
                    case 2:
                        KissMsg.ShowInfo("Die Buchung kann nicht gelöscht werden, da die Periode auf inaktiv gesetzt wurde!");
                        throw new Exception();
                    case 3:
                        KissMsg.ShowInfo("Die Buchung kann nicht gelöscht werden, da die Periode abgeschlossen ist!");
                        throw new Exception();
                }
            }

            int status = (int)qryKgBuchung["KgBuchungStatusCode"];
            if (status != 2) // Nur grüne sollen gelöscht werden können
            {
                KissMsg.ShowInfo("Der Status der Buchung lässt das Löschen nicht mehr zu!");
                throw new Exception();
            }
        }

        private void qryKgBuchung_BeforeInsert(object sender, EventArgs e)
        {
            tabControlSearch.SelectedTabIndex = 0;
        }

        private void qryKgBuchung_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatum, lblDatum.Text);
            DBUtil.CheckNotNullField(edtKontoSoll, lblKontoSoll.Text);
            DBUtil.CheckNotNullField(edtKontoHaben, lblKontoHaben.Text);
            DBUtil.CheckNotNullField(edtText, lblText.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);

            if (Convert.ToDecimal(qryKgBuchung["Betrag"]) <= Decimal.Zero)
            {
                edtBetrag.Focus();
                throw new KissInfoException("Der Betrag darf nicht 0.00 oder negativ sein!");
            }

            //check auf aktive Periode gemäss Buchungsdatum
            SqlQuery qry = DBUtil.OpenSQL(@"
                select KgPeriodeID,
                       KgPeriodeStatusCode,
                       PeriodeInfo = convert(varchar,PER.PeriodeVon,104) + ' - ' + convert(varchar,PER.PeriodeBis,104) + char(13) + char(10) +
                                     PST.Text + char(13) + char(10) +
                                         case when PER.KgPeriodeStatusCode = 1 AND PER.AbgeschlossenBis is not null
                                     then 'definitv bis ' + convert(varchar,PER.AbgeschlossenBis,104)
                                     else ''
                                     end
                from   KgPeriode PER
                       inner join FaLeistung LEI on LEI.FaLeistungID = PER.FaLeistungID
                       left  join XLOVCode   PST on PST.LOVName = 'KgPeriodeStatus' AND
                                                    PST.Code = PER.KgPeriodeStatusCode
                where  LEI.BaPersonID = {0} and
                       {1} between PER.PeriodeVon and PER.PeriodeBis",
                qryKgBuchung["BaPersonID"],
                qryKgBuchung["BuchungsDatum"]);

            if (qry.Count == 0)
                throw new KissInfoException(string.Format("Keine aktive Periode gefunden für den {0}!", edtDatum.Text));

            switch ((int)qry["KgPeriodeStatusCode"])
            {
                case 1: // active
                    qryKgBuchung["KgPeriodeID"] = qry["KgPeriodeID"];
                    qryKgBuchung["PeriodeInfo"] = qry["PeriodeInfo"];
                    break;

                case 2: // inactive
                    throw new KissInfoException(string.Format("Die zutreffende Periode für den {0} ist inaktiv!", edtDatum.Text));
                case 3: // closed
                    throw new KissInfoException(string.Format("Die zutreffende Periode für den {0} ist abgeschlossen!", edtDatum.Text));
            }

            if (edtValutaDatum.Visible && edtValutaDatum.EditMode == EditModeType.Normal)
                DBUtil.CheckNotNullField(edtValutaDatum, lblValutaDatum.Text);

            if (edtKreditor.Visible && edtKreditor.EditMode == EditModeType.Normal)
                DBUtil.CheckNotNullField(edtKreditor, lblKreditor.Text);

            if (edtReferenzNummer.Visible && edtReferenzNummer.EditMode == EditModeType.Normal)
                DBUtil.CheckNotNullField(edtReferenzNummer, lblReferenzNummer.Text);

            _insertMode = qryKgBuchung.Row.RowState == DataRowState.Added;

            ctlErfassungMutation1.SetFields();
        }

        private void qryKgBuchung_PositionChanged(object sender, EventArgs e)
        {
            DisplaySaldo(true);
            DisplaySaldo(false);

            qryAusgleich.Fill(qryKgBuchung["KgBuchungID"]);
            qryKgDokumente.Fill(qryKgBuchung["KgBuchungID"]);

            tpgAusgleich.HideTab = (qryAusgleich.Count == 0);

            int? status = qryKgBuchung["KgBuchungStatusCode"] as int?;

            if (status.HasValue && status.Value == 8) //Storno
                qryStorno.Fill(qryKgBuchung["KgBuchungID"]);
            else
                qryStorno.DataTable.Rows.Clear();

            btnStorno.Enabled = CountSelected() > 0;

            btnMonatsbudget.Visible = !DBUtil.IsEmpty(qryKgBuchung["JumpToMBPfad"]);

            SetEditMode();
            if (qryKgBuchung.Count > 0)
            {
                // Aufruf von RefreshDisplay bei Count = 0 führt zu einer Exception
                qryKgBuchung.RefreshDisplay();
            }

            ctlErfassungMutation1.ShowInfo();

            UpdateBuchungenGrid(true, true);
        }

        private void qryKgDokumente_AfterInsert(object sender, EventArgs e)
        {
            string stichwort = "";

            int sollKontoartCode = 99;
            if (!DBUtil.IsEmpty(qryKgBuchung["SollKontoartCode"]))
                sollKontoartCode = (int)qryKgBuchung["SollKontoartCode"];

            int habenKontoartCode = 99;
            if (!DBUtil.IsEmpty(qryKgBuchung["HabenKontoartCode"]))
                habenKontoartCode = (int)qryKgBuchung["HabenKontoartCode"];

            if (sollKontoartCode > 3)  // 1:Kontokorrent/Verkehrskonto, 2: Debitor, 3: Kreditor
            {
                stichwort = qryKgBuchung["SollKtoNrName"].ToString();
            }
            else if (habenKontoartCode > 3)
            {
                stichwort = qryKgBuchung["HabenKtoNrName"].ToString();
            }

            if (stichwort.Contains(" "))
            {
                qryKgDokumente["Stichwort"] = stichwort.Substring(stichwort.IndexOf(" "));
            }

            qryKgDokumente["KgDokumentTypCode"] = 4; // Buchung
            qryKgDokumente["KgBuchungID"] = qryKgBuchung["KgBuchungID"];
            edtStichwort.Focus();
        }

        private void qryKgDokumente_BeforePost(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryKgDokumente["Stichwort"]))
                qryKgDokumente["Stichwort"] = "-";
        }

        private void qryKgDokumente_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            qryKgBuchung.RowModified = true;
        }

        private void qryPeriode_PositionChanged(object sender, EventArgs e)
        {
            edtSucheKgPeriodeID.EditValue = qryPeriode["KgPeriodeID"];
        }

        private void tabControlBuchung_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.tabControlBuchung.SelectedTab == tpgBuchung)
            {
                e.Cancel = !qryKgBuchung.Post();
            }
            else if (this.tabControlBuchung.SelectedTab == tpgDokumente)
            {
                e.Cancel = !qryKgDokumente.Post();
            }
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            btnAlle.Visible = (page == tpgListe);
            btnKeine.Visible = (page == tpgListe);
            btnKopie.Visible = (page == tpgListe);
            btnStorno.Visible = (page == tpgListe);

            tabControlHabenSoll.Visible = page == tpgListe;
            tabControlBuchung.Height = tabControlHabenSoll.Visible ? 504 : 504 - tabControlHabenSoll.Height;
            //panel2.Top = tabControlHabenSoll.Visible ? this.Height - 535 - 50 : this.Height - 385 - 50; ;
            //grdEinzelzahlung.Height = visible ? this.Height - 535 - 50 : this.Height - 385 - 50;
            tabControlSearch.Height = Height - tabControlBuchung.Height - 50;
            panel2.Visible = page == tpgListe;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnAddData()
        {
            if (tabControlBuchung.SelectedTab == tpgDokumente)
                qryKgDokumente.Insert();
            else
                qryKgBuchung.Insert();

            return true;
        }

        public override bool OnDeleteData()
        {
            if (tabControlBuchung.SelectedTab == tpgDokumente)
            {
                if (!qryKgDokumente.Delete()) return false;

                //qryKgBuchung["Doc"] = (qryKgDokumente.Count > 0);
                //qryKgBuchung.RowModified = false;
                //qryKgBuchung.Row.AcceptChanges();
                return true;
            }

            return qryKgBuchung.Delete();
        }

        public override bool OnSaveData()
        {
            if (tabControlBuchung.SelectedTab == tpgDokumente)
            {
                if (!qryKgDokumente.Post()) return false;

                //		qryKgBuchung["Doc"] = (qryKgDokumente.Count > 0);

                //		refreshing = true;
                //		qryKgBuchung.Post();
                //		refreshing = false;
                return true;
            }

            return qryKgBuchung.Post();
        }

        public override void OnSearch()
        {
            edtSucheMandant.CheckPendingSearchValue();
            edtSucheKreditor.CheckPendingSearchValue();
            edtSucheDebitor.CheckPendingSearchValue();
            edtSucheKgPeriodeID.EditValue = qryPeriode["KgPeriodeID"];
            base.OnSearch();
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            var baPersonId = parameters["BaPersonID"];
            var datum = parameters["Datum"];
            var betrag = parameters["Betrag"];

            if (!DBUtil.IsEmpty(baPersonId) && !DBUtil.IsEmpty(datum) && !DBUtil.IsEmpty(betrag))
            {
                if (OnAddData())
                {
                    qryKgBuchung["BuchungsDatum"] = datum;
                    qryKgBuchung["ValutaDatum"] = datum;
                    qryKgBuchung["BaPersonID"] = baPersonId;
                    edtMandant.EditValue = baPersonId;
                    edtMandant_UserModifiedFld(edtMandant, new UserModifiedFldEventArgs(false));
                    qryKgBuchung["Betrag"] = betrag;

                    edtKontoSoll.Focus();
                }
            }

            return base.ReceiveMessage(parameters);
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            qryPeriode.DataTable.Rows.Clear();
            edtSucheMandant.Focus();
        }

        protected override void RunSearch()
        {
            ApplicationFacade.DoEvents(); // ist dies wirklich nötig?
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private int CountSelected()
        {
            int count = 0;
            foreach (DataRow row in qryKgBuchung.DataTable.Rows)
            {
                if (row.RowState != DataRowState.Detached && row.RowState != DataRowState.Deleted && !DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                {
                    count++;
                }
            }
            return count;
        }

        private void DisplaySaldo(Boolean sollKto)
        {
            if (_filling) return;

            try
            {
                string fldName;
                Control ctlSaldo;

                if (sollKto)
                {
                    fldName = "SollKtoNr";
                    ctlSaldo = edtSollSaldo;
                }
                else
                {
                    fldName = "HabenKtoNr";
                    ctlSaldo = edtHabenSaldo;
                }

                if (DBUtil.IsEmpty(qryKgBuchung[fldName]) || DBUtil.IsEmpty(qryKgBuchung["KgPeriodeID"]))
                {
                    ctlSaldo.Text = "";
                }
                else
                {
                    SqlQuery qry = DBUtil.OpenSQL(@"
                        exec spKgGetSaldo {0},{1}",
                        qryKgBuchung["KgPeriodeID"],
                        qryKgBuchung[fldName]);

                    ctlSaldo.Text = ((decimal)qry["Saldo"]).ToString("N2");
                }
            }
            catch
            {
                //TODO Log exception
            }
        }

        private bool KontoSuche(KissButtonEdit sender, bool buttonClicked, bool soll)
        {
            if (_filling) return false;
            string searchString = sender.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");
            bool cancel;

            if (DBUtil.IsEmpty(searchString))
            {
                if (buttonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    if (soll)
                    {
                        qryKgBuchung["SollKtoNr"] = DBNull.Value;
                        qryKgBuchung["SollKtoNrName"] = DBNull.Value;
                        qryKgBuchung["SollKontoartCode"] = DBNull.Value;
                        edtSollSaldo.EditValue = DBNull.Value;
                    }
                    else
                    {
                        qryKgBuchung["HabenKtoNr"] = DBNull.Value;
                        qryKgBuchung["HabenKtoNrName"] = DBNull.Value;
                        qryKgBuchung["HabenKontoartCode"] = DBNull.Value;
                        edtHabenSaldo.EditValue = DBNull.Value;
                    }
                    return false;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();

            if (DBUtil.IsEmpty(qryKgBuchung["BaPersonID"]))
            {
                cancel = !dlg.SearchData(@"
                  SELECT distinct
                         Konto   = KTO.KontoNr,
                         Name    = KTO.KontoName,
                         Klasse  = KLA.Text,
                         Konto$  = KTO.KontoNr + ' ' + KTO.KontoName,
                         KgKontoArtCode$ = KTO.KgKontoArtCode
                  FROM   KgKonto KTO
                         LEFT  JOIN XLOVCode     KLA ON KLA.LOVName = 'KgKontoKlasse' AND
                                                        KLA.Code = KTO.KgKontoKlasseCode
                  WHERE  KTO.KgPeriodeID IS NULL AND
                         KTO.KontoGruppe = 0 AND
                         KTO.KgKontoKlasseCode in (1,2,3,4) AND
                         (KTO.KontoName like '%' + {0} + '%' OR
                          KTO.KontoNr like {0} + '%')
                  ORDER BY KTO.KontoNr",
                  searchString,
                  buttonClicked, null, null, null);
            }
            else
            {
                cancel = !dlg.SearchData(@"
                  SELECT distinct
                         Konto   = KTO.KontoNr,
                         Name    = KTO.KontoName,
                         Klasse  = KLA.Text,
                         Konto$  = KTO.KontoNr + ' ' + KTO.KontoName,
                         KgKontoArtCode$ = KTO.KgKontoArtCode
                  FROM   FaLeistung LEI
                         INNER JOIN KgPeriode    PER ON PER.FaLeistungID = LEI.FaLeistungID AND
                                                        PER.KgPeriodeStatusCode = 1 --Aktiv
                         INNER JOIN KgKonto      KTO ON KTO.KgPeriodeID = PER.KgPeriodeID AND
                                                        KTO.KontoGruppe = 0 AND
                                                        KTO.KgKontoKlasseCode in (1,2,3,4)
                         LEFT  JOIN XLOVCode     KLA ON KLA.LOVName = 'KgKontoKlasse' AND
                                                        KLA.Code = KTO.KgKontoKlasseCode
                  WHERE  LEI.BaPersonID = " + qryKgBuchung["BaPersonID"] + @"  AND
                         (KTO.KontoName like '%' + {0} + '%' OR
                          KTO.KontoNr like {0} + '%')
                  ORDER BY KTO.KontoNr",
                  searchString,
                  buttonClicked, null, null, null);
            }

            if (!cancel)
            {
                if (soll)
                {
                    qryKgBuchung["SollKtoNr"] = dlg["Konto"];
                    qryKgBuchung["SollKtoNrName"] = dlg["Konto$"];
                    qryKgBuchung["SollKontoartCode"] = dlg["KgKontoArtCode$"];
                    DisplaySaldo(true);
                    SetEditMode();
                    qryKgBuchung.RefreshDisplay();
                    edtKontoHaben.Focus();
                }
                else
                {
                    qryKgBuchung["HabenKtoNr"] = dlg["Konto"];
                    qryKgBuchung["HabenKtoNrName"] = dlg["Konto$"];
                    qryKgBuchung["HabenKontoartCode"] = dlg["KgKontoArtCode$"];
                    DisplaySaldo(false);
                    SetEditMode();
                    qryKgBuchung.RefreshDisplay();
                    edtText.Focus();
                }
            }
            return cancel;
        }

        private bool KontoSucheUndGridUpdate(KissButtonEdit sender, bool buttonClicked)
        {
            bool soll = (sender == edtKontoSoll);
            bool returnValue = KontoSuche(sender, buttonClicked, soll);
            UpdateBuchungenGrid(soll, !soll);
            return returnValue;
        }

        private void LabelClick(object sender)
        {
            if (!(sender is KissLabel)) return;

            KissLabel lbl = (KissLabel)sender;
            lbl.Font = new Font(GuiConfig.LabelFontName,
                         GuiConfig.LabelFontSize,
                         lbl.Font.Underline ? FontStyle.Regular : FontStyle.Underline,
                         GuiConfig.LabelFontGraphicUnit);
        }

        /// <summary>
        /// (De-)selects all entries
        /// </summary>
        /// <param name="select">Selects all if true, deselects all if false</param>
        private void SelectAllOrNothing(bool select)
        {
            // zuerst speichern, damit wir nach der Selektionsänderung die Zeile als unverändert markieren können
            if (!qryKgBuchung.Post())
            {
                return;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                foreach (DataRow row in qryKgBuchung.DataTable.Rows)
                {
                    if (!DBUtil.IsEmpty(row["KgBuchungStatusCode"]) && (int)row["KgBuchungStatusCode"] != 2 && (int)row["KgBuchungStatusCode"] != 8)
                    {
                        row["Sel"] = select;
                        row.AcceptChanges();
                    }
                }
                qryKgBuchung.RowModified = false;
                btnStorno.Enabled = CountSelected() > 0;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SetEditMode()
        {
            if (qryKgBuchung.Count == 0) return;

            bool editable = true;
            int buchungTyp = (int)qryKgBuchung["KgBuchungTypCode"];

            int? status = qryKgBuchung["KgBuchungStatusCode"] as int?;

            if (!qryKgBuchung.CanUpdate || buchungTyp != 2 ||  // manuell
                (!DBUtil.IsEmpty(qryKgBuchung["KgPeriodeStatusCode"]) && (int)qryKgBuchung["KgPeriodeStatusCode"] != 1))  //aktive Periode
            {
                editable = false;
            }

            if (status.HasValue && status.Value == 8) //Storno
                editable = false;

            qryKgBuchung.EnableBoundFields(editable);

            int es = 0;
            if (!DBUtil.IsEmpty(qryKgBuchung["EinzahlungsscheinCode"]))
                es = (int)qryKgBuchung["EinzahlungsscheinCode"];

            int auszahlungsArt = 0;
            if (!DBUtil.IsEmpty(qryKgBuchung["KgAuszahlungsArtCode"]))
                auszahlungsArt = (int)qryKgBuchung["KgAuszahlungsArtCode"];

            int sollKontoart = 0;
            if (!DBUtil.IsEmpty(qryKgBuchung["SollKontoartCode"]))
                sollKontoart = (int)qryKgBuchung["SollKontoartCode"];

            int habenKontoart = 0;
            if (!DBUtil.IsEmpty(qryKgBuchung["HabenKontoartCode"]))
                habenKontoart = (int)qryKgBuchung["HabenKontoartCode"];

            tabZahlinfo.Visible = sollKontoart == 2 || habenKontoart == 3;
            edtDebitor.Visible = sollKontoart == 2 && habenKontoart != 3;
            lblDebitor.Visible = sollKontoart == 2 && habenKontoart != 3;
            edtKreditor.Visible = habenKontoart == 3;
            lblKreditor.Visible = habenKontoart == 3;

            edtKreditor.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;
            tpgZahlinfo.Title = (sollKontoart == 2) ? lblDebitor.Text : lblKreditor.Text;

            edtReferenzNummer.EditMode = (es == 1) && editable ? EditModeType.Normal : EditModeType.ReadOnly;
            edtReferenzNummer.Visible = (habenKontoart == 3);
            lblReferenzNummer.Visible = (habenKontoart == 3);

            lblMitteilung.Visible = (auszahlungsArt == 101) && ((es == 2) || (es == 3) || (es == 5)); //roter ES
            lblZahlbarAn.Visible = (auszahlungsArt == 103);

            edtMitteilungZeile1.Visible = (lblMitteilung.Visible || lblZahlbarAn.Visible);
            edtMitteilungZeile2.Visible = (lblMitteilung.Visible || lblZahlbarAn.Visible);
            edtMitteilungZeile3.Visible = (lblMitteilung.Visible || lblZahlbarAn.Visible);

            edtMitteilungZeile1.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;
            edtMitteilungZeile2.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;
            edtMitteilungZeile3.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;

            /*
            TODO: Edit Mode je nach Buchungsstatus
            {
                switch (status)
                {
                case BuchungDTAStatus.Unbekannt:
                                    qryBuchung.EnableBoundFields(true);
                                    break;

                                case BuchungDTAStatus.Fehlerhaft:
                                    qryBuchung.EnableBoundFields(true);
                                    break;

                                case BuchungDTAStatus.Bezahlt:
                                case BuchungDTAStatus.Übermittelt :
                                    qryBuchung.EnableBoundFields(false);

                                    // Datum, Mandant, SollKto und Buchungstext soll editierbar bleiben
                                    this.editDatum.EditMode = EditModeType.Normal ;
                                    this.editMandant.EditMode = EditModeType.Normal ;
                                    this.editText.EditMode = EditModeType.Normal ;
                                    this.editSoll.EditMode = EditModeType.Normal ;
                                    break;
                                }
                            }
                            else
                                qryBuchung.EnableBoundFields(false);
                        }
                        else
                            qryBuchung.EnableBoundFields(false);
            */

            //qryBuchung.RowModified = false;

            //if (qryBuchung.Row.RowState == System.Data.DataRowState.Modified)
            //	qryBuchung.Row.AcceptChanges();
        }

        private void SetKontoNames()
        {
            edtKontonameVon.Text = DBUtil.ExecuteScalarSQL(@"
                select	KontoName
                from	KgKonto
                where	(KgPeriodeID = {0} OR KgPeriodeID IS NULL AND {0} IS NULL) AND
                        KontoNr = {1}",
                qryPeriode["KgPeriodeID"],
                edtKontoVon.EditValue) as String;

            edtKontonameBis.Text = DBUtil.ExecuteScalarSQL(@"
                select	KontoName
                from	KgKonto
                where	(KgPeriodeID = {0} OR KgPeriodeID IS NULL AND {0} IS NULL) AND
                        KontoNr = {1}",
                qryPeriode["KgPeriodeID"],
                edtKontoBis.EditValue) as string;
        }

        private void StornoEnd()
        {
        }

        private void StornoStart()
        {
            int count = 0;
            int countSuccessful = 0;
            DlgProgressLog.AddLine("Start der Stornierung(en)");
            DlgProgressLog.AddLine(string.Empty);

            //DataTable tableCopy = qryKgBuchung.DataTable.Clone();
            HashSet<int> failedKbBuchungID = new HashSet<int>();
            foreach (DataRow row in qryKgBuchung.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                {
                    count++;

                    DlgProgressLog.UpdateLastLine(String.Format("Storniere Beleg {0} von {1}", count, _selectedCount));
                    ApplicationFacade.DoEvents();

                    try
                    {
                        DBUtil.ThrowExceptionOnOpenTransaction(); // Vorsichtsmassnahme : Es darf keine Umgebende Transaktion offen sein.
                        Session.BeginTransaction();
                        DBUtil.ExecSQLThrowingException("EXEC spKgBuchung_Storno {0}, {1}", row["KgBuchungID"], Session.User.UserID);
                        row["Sel"] = false;
                        row.AcceptChanges();
                        qryKgBuchung.RowModified = false;
                        Session.Commit();
                        countSuccessful += 1;
                    }
                    catch (Exception ex)
                    {
                        Session.Rollback();
                        failedKbBuchungID.Add((int)row["KgBuchungID"]);
                        DlgProgressLog.AddLine(string.Format("Fehler beim Stornieren des Beleges: {0}", ex.Message));
                        DlgProgressLog.AddLine("");
                    }

                    ApplicationFacade.DoEvents();
                }
            }
            DlgProgressLog.AddLine(String.Format("{0} von {1} Buchungen konnten storniert werden.", countSuccessful, count));

            qryKgBuchung.Refresh();
            // Die fehlerhaften Buchung erneut markieren
            foreach (DataRow row in qryKgBuchung.DataTable.Rows)
            {
                if (failedKbBuchungID.Count <= 0)
                {
                    break;
                }

                if (failedKbBuchungID.Contains((int)row["KgBuchungID"]))
                {
                    row["Sel"] = true;
                    row.AcceptChanges();
                    failedKbBuchungID.Remove((int)row["KgBuchungID"]);
                }
            }

            //            int KgPeriodeStatusCode = (int)DBUtil.ExecuteScalarSQL(@"
            //                select KgPeriodeStatusCode
            //                from   KgPeriode
            //                where  KgPeriodeID = {0}",
            //                qryKgBuchung["KgPeriodeID"]);

            //            if (KgPeriodeStatusCode != 1)
            //            {
            //                KissMsg.ShowInfo("Die Periode dieser Buchung ist nicht aktiv.");
            //                return;
            //            }

            //            DataRow row = qryKgBuchung.Row;
            //            qryKgBuchung.Insert();

            //            foreach (DataColumn col in qryKgBuchung.DataTable.Columns)
            //            {
            //                qryKgBuchung[col.ColumnName] = row[col.ColumnName];
            //            }

            //            qryKgBuchung["KgBuchungID"] = null;
            //            qryKgBuchung["KgBuchungTypCode"] = 2; //Manuell
            //            qryKgBuchung["KgPositionID"] = null;
            //            qryKgBuchung["KgBuchungStatusCode"] = 8; //Storno
            //            qryKgBuchung["PscdBelegNr"] = null;

            //            //Kontotausch Soll - Haben
            //            qryKgBuchung["SollKtoNr"] = row["HabenKtoNr"];
            //            qryKgBuchung["HabenKtoNr"] = row["SollKtoNr"];
            //            qryKgBuchung["SollKtoNrName"] = row["HabenKtoNrName"];
            //            qryKgBuchung["HabenKtoNrName"] = row["SollKtoNrName"];

            //            qryKgBuchung["Text"] = "STO " + row["KgBuchungID"].ToString() + ", " + row["Text"].ToString();
            //            qryKgBuchung["ErstelltUserID"] = Session.User.UserID;
            //            qryKgBuchung["ErstelltDatum"] = DateTime.Now;
            //            qryKgBuchung["MutiertUserID"] = Session.User.UserID;
            //            qryKgBuchung["MutiertDatum"] = DateTime.Now;
            //            qryKgBuchung["StorniertKgBuchungID"] = row["KgBuchungID"];

            //            qryKgBuchung.Post();
            //            SetEditMode();

            //            //Stornierte Buchung auch auf Status storniert setzen
            //            DBUtil.ExecSQL(@"
            //                update KgBuchung
            //                set    KgBuchungStatusCode = 8
            //                where  KgBuchungID = {0}",
            //                row["KgBuchungID"]);

            //            row["KgBuchungStatusCode"] = 8; //Storno
            //            row.AcceptChanges();
            //            qryKgBuchung.RowModified = false;

            //            SetEditMode();

            Cursor = Cursors.Default;
            DlgProgressLog.EndProgress();
            DlgProgressLog.ShowTopMost();
        }

        private void UpdateBuchungenGrid(bool updateSoll, bool updateHaben)
        {
            if (updateSoll)
            {
                qryKgBuchungSoll.Fill(qryKgBuchung["BaPersonID"], qryKgBuchung["SollKtoNr"]);
                KgBuchungshelper.CalculateSaldo(qryKgBuchungSoll.DataTable.Rows, "BetragSoll", "BetragHaben", "Saldo");
                qryKgBuchungSoll.RowModified = false;
            }
            if (updateHaben)
            {
                qryKgBuchungHaben.Fill(qryKgBuchung["BaPersonID"], qryKgBuchung["HabenKtoNr"]);
                KgBuchungshelper.CalculateSaldo(qryKgBuchungHaben.DataTable.Rows, "BetragSoll", "BetragHaben", "Saldo");
                qryKgBuchungHaben.RowModified = false;
            }
        }

        #endregion

        #endregion
    }
}