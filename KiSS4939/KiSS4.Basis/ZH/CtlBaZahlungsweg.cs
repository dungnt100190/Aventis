using System;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis.ZH
{
    public partial class CtlBaZahlungsweg : KissUserControl, IBelegleser
    {
        #region Fields

        private int _baInstitutionID;
        private int _baPersonID;
        private bool _enableBoundFields = true;
        private bool _isPersonZahlungsweg;

        #endregion

        #region Constructors

        public CtlBaZahlungsweg()
        {
            InitializeComponent();

            HasRightDefinitivSetzen = DBUtil.UserHasRight("CtlBaZahlungsweg_DefinitivSetzen");

            edtPostkontoNr.Location = edtBankPC.Location;
            edtPostkontoNr.Size = edtBankPC.Size;
        }

        #endregion

        #region Public Properties

        public int BaInstitutionID
        {
            set
            {
                _baInstitutionID = value;
                _isPersonZahlungsweg = false;
                Visible = value > 0;
                pnPersonOnly.Visible = false;
                tpgZahlungsempfaenger.HideTab = true;

                if (value != 0)
                {
                    BewilligungControlsVisible(true);
                }

                qryBaZahlungsweg.Fill(@"
                    SELECT
                      Z.BaZahlungswegID,
                      Z.BaPersonID,
                      Z.BaInstitutionID,
                      Z.DatumVon,
                      Z.DatumBis,
                      Z.EinzahlungsscheinCode,
                      Z.ZahlinformationAktiv,
                      Z.BaBankID,
                      Z.BankKontoNummer,
                      Z.IBANNummer,
                      Z.PostKontoNummer,
                      Z.ESRTeilnehmer,
                      Z.AdresseName,
                      Z.AdresseName2,
                      Z.AdresseStrasse,
                      Z.AdresseHausNr,
                      Z.AdressePostfach,
                      Z.AdressePLZ,
                      Z.AdresseOrt,
                      Z.AdresseLandCode,
                      Z.BaZahlwegModulStdCodes,
                      Z.BaZahlungswegTS,
                      Z.IsZkbVmKonto,
                      Z.WMAVerwenden,
                      Z.BaKontoartCode,
                      Z.Verwendungszweck,
                      Z.BaFreigabeStatusCode,
                      Z.DefinitivUserID,
                      Z.DefinitivDatum,
                      Definitiv = USR.LogonName + ', ' + CONVERT(VARCHAR(MAX), Z.DefinitivDatum, 104),
                      Z.ErstelltUserID,
                      Z.MutiertUserID,
                      Z.Creator,
                      Z.Created,
                      Z.Modifier,
                      Z.Modified,
                      WMA_Name = convert(varchar, null),
                      WMA_Name2 = convert(varchar, null),
                      WMA_Strasse = convert(varchar, null),
                      WMA_HausNr = convert(varchar, null),
                      WMA_PLZ = convert(varchar, null),
                      WMA_Ort = convert(varchar, null),
                      PcNr = dbo.fnTnToPc(Z.PostKontoNummer),
                      B.ClearingNr,
                      Bankname = B.Name + ', ' + B.Ort,
                      B.Strasse,
                      BankPC = dbo.fnTnToPc(B.PCKontoNr)
                    FROM dbo.BaZahlungsweg Z
                      LEFT JOIN dbo.BaBank B   ON B.baBankID = Z.baBankID
                      LEFT JOIN dbo.vwUser USR ON USR.UserID = Z.DefinitivUserID
                    WHERE Z.BaInstitutionID = {0}
                    ORDER BY Z.DatumVon",
                    value);

                pnlAdresse.Visible = false;
            }

            get
            {
                return _baInstitutionID;
            }
        }

        public int BaPersonID
        {
            set
            {
                _baPersonID = value;
                _isPersonZahlungsweg = true;
                Visible = value > 0;
                pnPersonOnly.Visible = true;
                tpgZahlungsempfaenger.HideTab = false;

                if (value != 0)
                {
                    BewilligungControlsVisible(false);
                }

                tabZusatz.SelectedTabIndex = 0;
                qryBaZahlungsweg.Fill(@"
                    SELECT
                      Z.BaZahlungswegID,
                      Z.BaPersonID,
                      Z.BaInstitutionID,
                      Z.DatumVon,
                      Z.DatumBis,
                      Z.EinzahlungsscheinCode,
                      Z.ZahlinformationAktiv,
                      Z.BaBankID,
                      Z.BankKontoNummer,
                      Z.IBANNummer,
                      Z.PostKontoNummer,
                      Z.ESRTeilnehmer,
                      Z.AdresseName,
                      Z.AdresseName2,
                      Z.AdresseStrasse,
                      Z.AdresseHausNr,
                      Z.AdressePostfach,
                      Z.AdressePLZ,
                      Z.AdresseOrt,
                      Z.AdresseLandCode,
                      Z.BaZahlwegModulStdCodes,
                      Z.BaZahlungswegTS,
                      Z.IsZkbVmKonto,
                      Z.WMAVerwenden,
                      Z.BaKontoartCode,
                      Z.Verwendungszweck,
                      Z.BaFreigabeStatusCode,
                      Z.DefinitivUserID,
                      Z.DefinitivDatum,
                      Definitiv = USR.LogonName + ', ' + CONVERT(VARCHAR(MAX), Z.DefinitivDatum, 104),
                      Z.ErstelltUserID,
                      Z.MutiertUserID,
                      Z.Creator,
                      Z.Created,
                      Z.Modifier,
                      Z.Modified,
                      WMA_Name = P.VornameName,
                      WMA_Name2 = P.WohnsitzAdressZusatz,
                      WMA_Strasse = P.WohnsitzStrasse,
                      WMA_HausNr = P.WohnsitzHausNr,
                      WMA_PLZ = P.WohnsitzPLZ,
                      WMA_Ort = P.WohnsitzOrt,
                      PcNr = dbo.fnTnToPc(Z.PostKontoNummer),
                      B.ClearingNr,
                      Bankname = B.Name + ', ' + B.Ort,
                      B.Strasse,
                      BankPC = dbo.fnTnToPc(B.PCKontoNr)
                    FROM dbo.BaZahlungsweg   Z
                      LEFT JOIN dbo.BaBank   B   ON B.baBankID = Z.baBankID
                      LEFT JOIN dbo.vwPerson P   ON P.baPersonID = Z.baPersonID
                      LEFT JOIN dbo.vwUser   USR ON USR.UserID = Z.DefinitivUserID
                    WHERE Z.BaPersonID = {0}
                    ORDER BY Z.DatumVon",
                    value);
            }

            get
            {
                return _baPersonID;
            }
        }

        public bool HasRightDefinitivSetzen { get; set; }

        private void BewilligungControlsVisible(bool visible)
        {
            lblStatus.Visible = visible;
            edtBaFreigabeStatus.Visible = visible;
            btnDefinitiv.Visible = visible && HasRightDefinitivSetzen && qryBaZahlungsweg["BaFreigabeStatusCode"] as int? == 1;
            lblDefinitiv.Visible = visible;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="param">Containing all necessary parameters as key/value pairs</param>
        /// <returns>True, if successfully handles message or nothing done, false if something went wrong</returns>
        public override bool ReceiveMessage(HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "JumpToZahlungsweg":
                    if (param["BaZahlungswegID"] != null)
                    {
                        qryBaZahlungsweg.Find("BaZahlungswegID = " + param["BaZahlungswegID"]);
                        //find row with the ID
                        //set Focus to row
                        return true;
                    }

                    return false;
            }

            // did not understand message
            return base.ReceiveMessage(param);
        }

        public void SetAllZahlungsverbindungenDefinitiv()
        {
            if (qryBaZahlungsweg.IsEmpty)
            {
                return;
            }

            qryBaZahlungsweg.Post();

            qryBaZahlungsweg.First();
            do
            {
                ZahlungsverbindungDefinitivSetzen();
                qryBaZahlungsweg.Post();
            } while (qryBaZahlungsweg.Next());
        }

        public void SetRights(bool hasEditRightsIns, bool hasEditRightsDel, bool hasEditRightsUpd)
        {
            qryBaZahlungsweg.CanInsert = hasEditRightsIns;
            qryBaZahlungsweg.CanDelete = hasEditRightsDel;
            qryBaZahlungsweg.CanUpdate = hasEditRightsUpd;
            qryBaZahlungsweg_PositionChanged(null, null);

            qryBaZahlungswegDokumente.CanInsert = hasEditRightsIns;
            qryBaZahlungswegDokumente.CanDelete = hasEditRightsDel;
            qryBaZahlungswegDokumente.CanUpdate = hasEditRightsUpd;
            qryBaZahlungswegDokumente_PositionChanged(null, null);
        }

        #endregion

        #region Private Methods

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            if (!qryBaZahlungsweg.CanInsert || qryBaZahlungsweg.Insert() == null)
            {
                return;
            }

            qryBaZahlungsweg["EinzahlungsscheinCode"] = (int)beleg.BelegTyp;
            switch (beleg.BelegTyp)
            {
                case BelegTyp.ESR:
                case BelegTyp.Post:
                    qryBaZahlungsweg["PostKontoNummer"] = beleg.KontoNummer;
                    qryBaZahlungsweg["PcNr"] = DBUtil.ExecuteScalarSQL("SELECT dbo.fnTnToPc({0})", beleg.KontoNummer);
                    break;

                case BelegTyp.Bank:
                    SqlQuery qryBaBank = DBUtil.OpenSQL(@"
                        SELECT BaBankID, BankName = Name + ', ' + Ort
                        FROM BaBank
                        WHERE ClearingNr = {0}
                        ORDER BY FilialeNr",
                        beleg.ClearingNummer);
                    try
                    {
                        qryBaZahlungsweg["BaBankID"] = qryBaBank["BaBankID"];
                        qryBaZahlungsweg["ClearingNr"] = beleg.ClearingNummer;
                        qryBaZahlungsweg["BankName"] = qryBaBank["BankName"];

                        qryBaZahlungsweg["IBANNummer"] = Belegleser.IBANConvert(beleg.ReferenzNummer, beleg.ClearingNummer);
                    }
                    catch
                    {
                    }

                    break;
            }
        }

        private void btnDefinitiv_Click(object sender, System.EventArgs e)
        {
            if (!qryBaZahlungsweg.Post()) return;

            Session.BeginTransaction();

            try
            {
                if (ZahlungsverbindungDefinitivSetzen())
                {
                    btnDefinitiv.Visible = false;
                }

                Session.Commit();
            }
            catch (Exception)
            {
                Session.Rollback();
                tabZusatz.SelectTab(tpgDokumente);
                KissMsg.ShowInfo(typeof(CtlBaZahlungsweg).Name, "DefinitivsetzenNichtErlaubtKeinDokument", "Der Zahlweg kann nicht definitiv gesetzt werden, da kein zugehöriges Dokument erfasst wurde.");
            }
        }

        private void CheckEditsBeforePost()
        {
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
            DBUtil.CheckNotNullField(edtEinzahlungsschein, lblEinzahlungsschein.Text);
            int esTyp = Utils.ConvertToInt(edtEinzahlungsschein.EditValue);

            // Bis-Datum darf nicht vor Von-Datum liegen
            DateTime? von = edtDatumVon.EditValue as DateTime?;
            DateTime? bis = edtDatumBis.EditValue as DateTime?;
            if (von.HasValue && bis.HasValue && von.Value >= bis.Value)
            {
                throw new KissInfoException("Das Von-Datum muss vor dem Bis-Datum liegen!");
            }

            // Kontrollieren, ab der neue Gültigkeitzeitraum alle Buchungen abdeckt, die den Zahlweg verwenden
            SqlQuery qryDates = DBUtil.OpenSQL(@"
                SELECT
                  [Min] = CASE WHEN MIN([Min]) < {0} THEN 1 ELSE 0 END,
                  [Max] = CASE WHEN MAX([Max]) > {1} THEN 1 ELSE 0 END,
                  MinDatum = MIN([Min]),
                  MaxDatum = MAX([Max])
                FROM (
                  SELECT [Min] = MIN(ValutaDatum), [Max] = MAX(ValutaDatum)
                  FROM KgBuchung
                  WHERE BaZahlungswegID = {2}
                  UNION
                  SELECT [Min] = MIN(ValutaDatum), [Max] = MAX(ValutaDatum)
                  FROM KbBuchung
                  WHERE BaZahlungswegID = {2}
                ) TMP",
                edtDatumVon.EditValue,
                edtDatumBis.EditValue,
                qryBaZahlungsweg["BaZahlungswegID"]);

            if ((int)qryDates["Min"] == 1)
            {
                throw new KissInfoException(
                    string.Format(
                        "Für diesen Zahlungsweg gibt es eine Buchung mit Valuta {0:dd.MM.yyyy}. Das Von-Datum muss früher festgelegt werden",
                        qryDates["MinDatum"]));
            }

            if ((int)qryDates["Max"] == 1)
            {
                throw new KissInfoException(
                    string.Format(
                        "Für diesen Zahlungsweg gibt es eine Buchung mit Valuta {0:dd.MM.yyyy}. Das Bis-Datum muss später festgelegt werden",
                        qryDates["MaxDatum"]));
            }

            // Felder kontrollieren gemäss ausgewähltem Einzahlungsscheintyps:
            // Postkonto-Nr.:
            if (esTyp == 1 || esTyp == 2)
            {
                DBUtil.CheckNotNullField(edtPostkontoNr, lblPostKonto.Text);
                CheckPCNr();
            }

            // Bankkonto, Bank/Post, IBAN Feld und Schalter
            if (esTyp == 3 || esTyp == 4 || esTyp == 5)
            {
                if (DBUtil.IsEmpty(edtIBAN.EditValue))
                {
                    DBUtil.CheckNotNullField(edtBankPost, lblBankPost.Text);
                    DBUtil.CheckNotNullField(edtBankkontoNr, lblBankkontoNr.Text);
                }
                else if (DBUtil.IsEmpty(edtBankPost.EditValue))
                {
                    // IBAN vorhanden, ClearingNr nicht. Da Mussfeld in PSCD, probieren wir nun, sie zu generieren
                    SqlQuery qryBcl = TryToGetClearingNR();
                    if (qryBcl == null || qryBcl.Count == 0)
                    {
                        qryBaZahlungsweg["BaBankID"] = DBNull.Value;
                        qryBaZahlungsweg["ClearingNr"] = DBNull.Value;
                        qryBaZahlungsweg["BankName"] = DBNull.Value;
                        qryBaZahlungsweg["BankPC"] = DBNull.Value;
                    }
                    else
                    {
                        qryBaZahlungsweg["BaBankID"] = qryBcl["BaBankID"];
                        qryBaZahlungsweg["ClearingNr"] = qryBcl["ClearingNr"];
                        qryBaZahlungsweg["BankName"] = qryBcl["BankName"];
                        qryBaZahlungsweg["BankPC"] = qryBcl["BankPC"];
                    }
                }
                else
                {
                    SqlQuery qryBcl = TryToGetClearingNR();
                    if (qryBcl != null && qryBcl.Count > 0 && !qryBcl.Find(string.Format(" ClearingNr = {0}", qryBaZahlungsweg["ClearingNR"])))
                    {
                        throw new KissInfoException("Fehler: Die Clearing-Nummer der IBAN-Nummer stimmt nicht mit der Clearing-Nummer der Bank überein.");
                    }
                }

                // Kontonummer darf höchstens 18 Zeichen lang sein
                if (!DBUtil.IsEmpty(edtBankkontoNr.EditValue))
                {
                    string kontoNr = (string)edtBankkontoNr.EditValue;
                    if (kontoNr.Length > 18)
                    {
                        throw new KissInfoException("Die Bankkontonummer darf höchstens 18 Zeichen lang sein");
                    }
                }
            }

            // IBAN Nummer ist bei Bankzahlungen Ausland obligatorisch
            if (esTyp == 4)
            {
                DBUtil.CheckNotNullField(edtIBAN, lblIBAN.Text);
                DBUtil.CheckNotNullField(edtBankPost, lblBankPost.Text);
            }

            // IBAN Nummer prüfen, falls vorhanden
            if (!DBUtil.IsEmpty(edtIBAN.EditValue))
            {
                string errorMsg;
                string sIBAN = edtIBAN.EditValue.ToString();
                if (!Utils.CheckIBAN(sIBAN, out errorMsg))
                {
                    // Achtung: Der Fokus darf nicht gesetzt werden,
                    // da sonst beim Wechsel zu einem anderen Fenster eine Endlosschlaufe produziert wird:
                    //edtIBAN.Focus();
                    throw new KissInfoException(errorMsg);
                }
            }

            if (esTyp == 1 || esTyp == 2)
            {
                qryBaZahlungsweg["BaBankID"] = DBNull.Value;
                qryBaZahlungsweg["BankName"] = DBNull.Value;
                qryBaZahlungsweg["BankKontoNummer"] = DBNull.Value;
            }

            if (esTyp == 2)
            {
                qryBaZahlungsweg["ESRTeilnehmer"] = DBNull.Value;
            }

            if (esTyp == 3 || esTyp == 5)
            {
                qryBaZahlungsweg["PostKontoNummer"] = DBNull.Value;
                qryBaZahlungsweg["ESRTeilnehmer"] = DBNull.Value;
            }

            if (esTyp == 4)
            {
                qryBaZahlungsweg["BankKontoNummer"] = DBNull.Value;
                qryBaZahlungsweg["PostKontoNummer"] = DBNull.Value;
                qryBaZahlungsweg["ESRTeilnehmer"] = DBNull.Value;
            }

            if (esTyp == 6)
            {
                qryBaZahlungsweg["BaBankID"] = DBNull.Value;
                qryBaZahlungsweg["BankName"] = DBNull.Value;
                qryBaZahlungsweg["BankKontoNummer"] = DBNull.Value;
                qryBaZahlungsweg["IBANNummer"] = DBNull.Value;
                qryBaZahlungsweg["PostKontoNummer"] = DBNull.Value;
                qryBaZahlungsweg["ESRTeilnehmer"] = DBNull.Value;
            }
        }

        // Kontrolle der Eingabe:
        // zusätzlich soll die PC-Nummer zu einer TN-Nummer umgewandelt werden:
        private void CheckPCNr()
        {
            string pcNr = edtPostkontoNr.EditValue.ToString();
            int esTyp = Utils.ConvertToInt(edtEinzahlungsschein.EditValue);

            if (pcNr.Contains("-") || esTyp == 2)
            {
                string errorMsg;
                string tnNumber;
                if (!Utils.CheckPCKontoNumber(pcNr, out errorMsg, out tnNumber))
                {
                    // Achtung: Der Fokus darf nicht gesetzt werden,
                    // da sonst beim Wechsel zu einem anderen Fenster eine Endlisschlaufe produziert wird:
                    //edtPostkontoNr.Focus();
                    KissMsg.ShowInfo(errorMsg);
                    throw new KissCancelException();
                }

                // Falls kein Fehler: Datenfeld füllen:
                qryBaZahlungsweg["PcNr"] = pcNr;
                qryBaZahlungsweg["PostKontoNummer"] = tnNumber;
                qryBaZahlungsweg.RefreshDisplay();
            }
            else
            {
                // Bei Typ 1 soll 5-stellige Nummer zugelassen sein
                if (pcNr.Length != 5)
                {
                    KissMsg.ShowInfo("Wenn keine PC-Nummer definiert wird, muss die Nummer 5 Zeichen enthalten.");
                    throw new KissCancelException();
                }

                // Falls kein Fehler: Datenfeld füllen:
                qryBaZahlungsweg["PcNr"] = pcNr;
                qryBaZahlungsweg["PostKontoNummer"] = pcNr;
                qryBaZahlungsweg.RefreshDisplay();
            }
        }

        private void CtlBaZahlungsweg_Load(object sender, EventArgs e)
        {
            //Anzeigen im Gitter:
            if (!DesignMode)
            {
                colEZ.ColumnEdit = grdBaZahlungsweg.GetLOVLookUpEdit(edtEinzahlungsschein.LOVName); //Werteliste ist gefiltert, im Grid wollen wir aber die ungefilterte Liste
                colKontoart.ColumnEdit = grdBaZahlungsweg.GetLOVLookUpEdit((SqlQuery)edtBaKontoart.Properties.DataSource);
                colDocTyp.ColumnEdit = grdDoc.GetLOVLookUpEdit("BaZahlungswegDokumentTyp");
            }

            // Fokus setzen
            edtDatumVon.Focus();
        }

        private void edtBankPost_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtBankPost.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBaZahlungsweg["BaBankID"] = DBNull.Value;
                    qryBaZahlungsweg["BankName"] = DBNull.Value;
                    qryBaZahlungsweg["BankPC"] = DBNull.Value;
                    qryBaZahlungsweg["ClearingNr"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new DlgAuswahl();
            if (dlg.SearchBank(searchString, e.ButtonClicked))
            {
                qryBaZahlungsweg["BaBankID"] = dlg["BaBankID"];
                qryBaZahlungsweg["BankName"] = dlg["Name"] + ", " + dlg["Ort"];
                qryBaZahlungsweg["ClearingNr"] = dlg["ClearingNr"];
                qryBaZahlungsweg["BankPC"] = dlg["PCKontoNr"];
            }

            qryBaZahlungsweg.RefreshDisplay();
            dlg.Dispose();
        }

        private void edtDocument_DocumentCreated(object sender, EventArgs e)
        {
            // damit DateCreation und DateLastSave im Gitter korrekt angezeigt werden
            qryBaZahlungswegDokumente["DateCreation"] = edtDocument.DateCreation;
            qryBaZahlungswegDokumente["DateLastSave"] = edtDocument.DateLastSave;
        }

        private void edtDocument_DocumentImported(object sender, EventArgs e)
        {
            // damit DateCreation und DateLastSave im Gitter korrekt angezeigt werden
            qryBaZahlungswegDokumente["DateCreation"] = edtDocument.DateCreation;
            qryBaZahlungswegDokumente["DateLastSave"] = edtDocument.DateLastSave;
        }

        private void edtDocument_DocumentSaved(object sender, EventArgs e)
        {
            qryBaZahlungswegDokumente.Refresh();
        }

        private void edtEinzahlungsschein_CloseUp(object sender, CloseUpEventArgs e)
        {
            /*
                       Specifies that the dropdown window was closed because an end user:
              ButtonClick  clicked the editor's dropdown button.
              Cancel       pressed the ESC key or clicked the close button
                       (available for LookUpEdit, CalcEdit and PopupContainerEdit controls).
              CloseUpKey   pressed a shortcut used to close the dropdown (the ALT+DOWN ARROW or RepositoryItemPopupBase.CloseUpKey).
              Immediate    clicked outside the editor.
              Normal       selected an option from the editor's dropdown.
              */

            e.AcceptValue = true;
            if (!e.CloseMode.Equals(PopupCloseMode.Normal))
            {
                return;
            }

            // Alter Code holen und vergleichen:
            int oldValue = 0;
            if (!DBUtil.IsEmpty(edtEinzahlungsschein.EditValue))
            {
                oldValue = (int)edtEinzahlungsschein.EditValue;
            }

            if ((oldValue == 0) || (oldValue == (int)e.Value))
            {
                return;
            }

            // Kontrollieren, ob eine Abfrage notwendig ist:
            bool hasToAsk = false;
            int newValue = (int)e.Value;
            if (((newValue == 1) &&
                 (!DBUtil.IsEmpty(qryBaZahlungsweg["BankKontoNummer"]) ||
                  !DBUtil.IsEmpty(qryBaZahlungsweg["BaBankID"]) ||
                  !DBUtil.IsEmpty(qryBaZahlungsweg["IBANNummer"]))
                ) ||
                ((newValue == 2) &&
                 // 21.09.2007 : sozheo : provisorisch wird Feld Referenznummer gesperrt:
                 //(!DBUtil.IsEmpty(qryBaZahlungsweg["ESRTeilnehmer"]) ||
                 (!DBUtil.IsEmpty(qryBaZahlungsweg["BankKontoNummer"]) ||
                  !DBUtil.IsEmpty(qryBaZahlungsweg["BaBankID"]) ||
                  !DBUtil.IsEmpty(qryBaZahlungsweg["IBANNummer"])
                 )
                ) ||
                ((newValue == 3 || newValue == 5) &&
                 // 21.09.2007 : sozheo : provisorisch wird Feld Referenznummer gesperrt:
                 //(!DBUtil.IsEmpty(qryBaZahlungsweg["ESRTeilnehmer"]) ||
                 !DBUtil.IsEmpty(qryBaZahlungsweg["PostKontoNummer"])
                ) ||
                ((newValue == 4) &&
                 // 21.09.2007 : sozheo : provisorisch wird Feld Referenznummer gesperrt:
                 //(!DBUtil.IsEmpty(qryBaZahlungsweg["ESRTeilnehmer"]) ||
                 (!DBUtil.IsEmpty(qryBaZahlungsweg["PostKontoNummer"]) ||
                  !DBUtil.IsEmpty(qryBaZahlungsweg["BankKontoNummer"]) ||
                  !DBUtil.IsEmpty(qryBaZahlungsweg["BaBankID"])
                 )
                ) ||
                ((newValue == 6) &&
                 // 21.09.2007 : sozheo : provisorisch wird Feld Referenznummer gesperrt:
                 //(!DBUtil.IsEmpty(qryBaZahlungsweg["ESRTeilnehmer"]) ||
                 (!DBUtil.IsEmpty(qryBaZahlungsweg["PostKontoNummer"]) ||
                  !DBUtil.IsEmpty(qryBaZahlungsweg["BankKontoNummer"]) ||
                  !DBUtil.IsEmpty(qryBaZahlungsweg["BaBankID"]) ||
                  !DBUtil.IsEmpty(qryBaZahlungsweg["IBANNummer"]))
                ))
            {
                hasToAsk = true;
            }

            if (hasToAsk)
            {
                // Jetzt abfragen, ob die alten Daten gelöscht werden sollen oder nicht:
                if (!KissMsg.ShowQuestion(
                    "Sie haben den Typ Einzahlungsschein gewechselt.\r\n" +
                    "Somit werden bereits erfasste Daten ungültig und werden automatisch gelöscht.\r\n\r\n" +
                    "Wollen Sie fortfahren und erfasste Daten löschen?"))
                {
                    // Nein, erfasste Daten sollen nicht gelöscht werden,
                    // Also soll der neue Code nicht gesetzt werden:
                    e.AcceptValue = false;
                    return;
                }
            }

            // Ja, erfasste Daten sollen gelöscht werden:
            if (newValue == 1 || newValue == 2)
            {
                qryBaZahlungsweg["BaBankID"] = DBNull.Value;
                qryBaZahlungsweg["BankName"] = DBNull.Value;
                qryBaZahlungsweg["BankKontoNummer"] = DBNull.Value;
                qryBaZahlungsweg["BankPC"] = DBNull.Value;
                qryBaZahlungsweg["IBANNummer"] = DBNull.Value;
                qryBaZahlungsweg["ClearingNr"] = DBNull.Value;
            }

            if (newValue == 2)
            {
                qryBaZahlungsweg["ESRTeilnehmer"] = DBNull.Value;
            }

            if (newValue == 3 || newValue == 5)
            {
                qryBaZahlungsweg["PostKontoNummer"] = DBNull.Value;
                qryBaZahlungsweg["PcNr"] = DBNull.Value;
                qryBaZahlungsweg["ESRTeilnehmer"] = DBNull.Value;
            }

            if (newValue == 4)
            {
                qryBaZahlungsweg["BaBankID"] = DBNull.Value;
                qryBaZahlungsweg["BankName"] = DBNull.Value;
                qryBaZahlungsweg["BankKontoNummer"] = DBNull.Value;
                qryBaZahlungsweg["BankPC"] = DBNull.Value;
                qryBaZahlungsweg["ClearingNr"] = DBNull.Value;
                qryBaZahlungsweg["PostKontoNummer"] = DBNull.Value;
                qryBaZahlungsweg["PcNr"] = DBNull.Value;
                qryBaZahlungsweg["ESRTeilnehmer"] = DBNull.Value;
            }

            if (newValue == 6)
            {
                qryBaZahlungsweg["BaBankID"] = DBNull.Value;
                qryBaZahlungsweg["BankName"] = DBNull.Value;
                qryBaZahlungsweg["BankKontoNummer"] = DBNull.Value;
                qryBaZahlungsweg["IBANNummer"] = DBNull.Value;
                qryBaZahlungsweg["BankPC"] = DBNull.Value;
                qryBaZahlungsweg["ClearingNr"] = DBNull.Value;
                qryBaZahlungsweg["PostKontoNummer"] = DBNull.Value;
                qryBaZahlungsweg["PcNr"] = DBNull.Value;
                qryBaZahlungsweg["ESRTeilnehmer"] = DBNull.Value;
            }

            qryBaZahlungsweg.RefreshDisplay();
        }

        private void edtEinzahlungsschein_EditValueChanged(object sender, EventArgs e)
        {
            // Editieren der Felder einstellen
            SetAllFields_ES();
        }

        private void edtEinzahlungsschein_EnterKey(object sender, KeyEventArgs e)
        {
            if (edtPostkontoNr.Visible)
            {
                edtPostkontoNr.Focus();
            }
            else
            {
                edtBankPost.Focus();
            }
        }

        private void edtWMAVerwenden_EditValueChanged(object sender, EventArgs e)
        {
            SetWMA();
        }

        private bool IsDefinitivSetzenAllowed()
        {
            //Validierung: Hat es mindestens ein nicht-definitives Dokument?
            int baZahlungswegId = Utils.ConvertToInt(qryBaZahlungsweg["BaZahlungswegID"]);

            int nbrOfNewDocuments = DBUtil.ExecuteScalarSQL(@"
SELECT COUNT(1)
FROM BaZahlungswegDokument
WHERE BaZahlungswegID = {0}
  AND DocumentID IS NOT NULL
  AND Definitiv = 0;", baZahlungswegId) as int? ?? 0;

            return nbrOfNewDocuments > 0;
        }

        private bool IsZahlwegModified()
        {
            if (qryBaZahlungsweg.CurrentRowState == DataRowState.Added)
            {
                return true;
            }

            if (qryBaZahlungsweg.ColumnModified("BaBankID")
                || qryBaZahlungsweg.ColumnModified("IBANNummer")
                || qryBaZahlungsweg.ColumnModified("BankKontoNummer")
                || qryBaZahlungsweg.ColumnModified("PostKontoNummer")
                || qryBaZahlungsweg.ColumnModified("ESRTeilnehmer")
                || qryBaZahlungsweg.ColumnModified("AdresseName")
                || qryBaZahlungsweg.ColumnModified("AdresseName2")
                || qryBaZahlungsweg.ColumnModified("AdresseStrasse")
                || qryBaZahlungsweg.ColumnModified("AdresseHausNr")
                || qryBaZahlungsweg.ColumnModified("AdressePostfach")
                || qryBaZahlungsweg.ColumnModified("AdressePLZ")
                || qryBaZahlungsweg.ColumnModified("AdresseOrt")
                || qryBaZahlungsweg.ColumnModified("AdresseLandCode"))
            {
                return true;
            }

            return false;
        }

        private void qryBaZahlungsweg_AfterFill(object sender, EventArgs e)
        {
            if (_isPersonZahlungsweg)
            {
                qryBaPerson.Fill(_baPersonID);
            }

            if (qryBaZahlungsweg.Count == 0)
            {
                qryBaZahlungsweg_PositionChanged(sender, e);
            }
            else
            {
                // Wenn Daten vorhanden, auf die letzte Zeile springen:
                qryBaZahlungsweg.Last();
            }
        }

        private void qryBaZahlungsweg_AfterInsert(object sender, EventArgs e)
        {
            // Defaultwerte:
            if (_isPersonZahlungsweg)
            {
                qryBaZahlungsweg["BaPersonID"] = _baPersonID;
            }
            else
            {
                qryBaZahlungsweg["BaInstitutionID"] = _baInstitutionID;
            }

            qryBaZahlungsweg["ZahlinformationAktiv"] = true;
            qryBaZahlungsweg["WMAVerwenden"] = true;
            SetWMA();
            qryBaZahlungsweg["DatumVon"] = DateTime.Today;

            qryBaZahlungsweg["BaFreigabeStatusCode"] = 1; //Vorschlag

            ctlErfassungMutation.ShowInfo();

            edtDatumVon.Focus();
        }

        private void qryBaZahlungsweg_BeforePost(object sender, EventArgs e)
        {
            ctlErfassungMutation.SetFields();

            // Kontrolle der Muss-Felder:
            CheckEditsBeforePost();
            TryGenerateIBAN();

            if (IsZahlwegModified())
            {
                qryBaZahlungsweg["BaFreigabeStatusCode"] = 1; //Vorschlag
                BewilligungControlsVisible(BaInstitutionID != 0); //nur bei Institutionen
            }

            try
            {
                if (!DBUtil.IsEmpty(qryBaZahlungsweg["EinzahlungsscheinCode"]))
                {
                    // Prüfen, ob gleiche Bankverbindung bereits besteht
                    DataRow[] rows = qryBaZahlungsweg.DataTable.Select(string.Format(@"
                             ({0} = 1          AND EinzahlungsscheinCode = 1          AND PostKontoNummer = '{1}')
                          OR ({0} = 2          AND EinzahlungsscheinCode = 2          AND PostKontoNummer = '{1}')
                          OR ({0} IN (3,5)     AND EinzahlungsscheinCode IN (3,5)     AND BankKontoNummer = '{2}')
                          OR ({0} IN (2,3,4,5) AND EinzahlungsscheinCode IN (2,3,4,5) AND IBANNummer = '{3}')",
                        qryBaZahlungsweg["EinzahlungsscheinCode"],
                        qryBaZahlungsweg["PostKontoNummer"],
                        qryBaZahlungsweg["BankKontoNummer"],
                        qryBaZahlungsweg["IBANNummer"]));
                    if (rows.Length > 1)
                    {
                        throw new KissCancelException("Dieser Zahlweg ist bereits erfasst. Bitte korrigieren Sie die Eingabe oder verwenden Sie den bestehenden Zahlungsweg (ev mit Anpassung des Verwendungsdatums).");
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
                throw;
            }

            if (!(bool)qryBaZahlungsweg["WMAVerwenden"])
            {
                DBUtil.CheckNotNullField(edtName, "Name");
                DBUtil.CheckNotNullField(edtPLZ, "PLZ");
                DBUtil.CheckNotNullField(edtOrt, "Ort");
            }
            else
            {
                qryBaZahlungsweg["AdresseName"] = null;
                qryBaZahlungsweg["AdresseName2"] = null;
                qryBaZahlungsweg["AdresseStrasse"] = null;
                qryBaZahlungsweg["AdresseHausNr"] = null;
                qryBaZahlungsweg["AdressePLZ"] = null;
                qryBaZahlungsweg["AdresseOrt"] = null;
            }
        }

        private void qryBaZahlungsweg_PositionChanged(object sender, EventArgs e)
        {
            ctlErfassungMutation.ShowInfo();
            SetEditMainFields();
            edtEinzahlungsschein_EditValueChanged(sender, e);
            SetWMA();
            edtIBANErrorMsg.Text = "";

            if (qryBaZahlungsweg.CanUpdate && qryBaZahlungsweg.Count > 0
                && qryBaZahlungsweg.Row.RowState != DataRowState.Added
                && !DBUtil.UserHasRight("CtlBaZahlungsweg_Bearbeiten"))
            {
                //Benutzer hat kein Recht, daten zu bearbeiten, Maske deaktivieren
                qryBaZahlungsweg.EnableBoundFields(false);
                _enableBoundFields = false;

                if (ZahlwegTypIsActive())
                {
                    //aktive Zahlwege (mit aktiven Zahlwegtypen) dürfen deaktiviert werden
                    ((IKissBindableEdit)edtDatumBis).AllowEdit(true);
                }
            }

            var freigabe = qryBaZahlungsweg["BaFreigabeStatusCode"] as int? ?? 1;
            btnDefinitiv.Visible = BaInstitutionID != 0 && (freigabe is int && (int)freigabe == 1 && HasRightDefinitivSetzen && qryBaZahlungsweg.Count > 0);

            qryBaZahlungswegDokumente.Fill(qryBaZahlungsweg["BaZahlungswegID"]);
        }

        private void qryBaZahlungswegDokumente_AfterDelete(object sender, EventArgs e)
        {
            Session.Commit();
        }

        private void qryBaZahlungswegDokumente_AfterInsert(object sender, EventArgs e)
        {
            qryBaZahlungswegDokumente["BaZahlungswegID"] = qryBaZahlungsweg["BaZahlungswegID"];
        }

        private void qryBaZahlungswegDokumente_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            try
            {
                DBUtil.ExecSQLThrowingException(@"DELETE FROM dbo.XDocument WHERE DocumentID = {0}", qryBaZahlungswegDokumente["DocumentID"]);
            }
            catch (Exception)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        private void qryBaZahlungswegDokumente_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if (qryBaZahlungswegDokumente["Definitiv"] as bool? ?? false)
            {
                throw new KissInfoException("Dieses Dokument wurde definitiv gesetzt und kann deswegen nicht gelöscht werden.");
            }
        }

        private void qryBaZahlungswegDokumente_PositionChanged(object sender, EventArgs e)
        {
            qryBaZahlungswegDokumente.EnableBoundFields(!(qryBaZahlungswegDokumente["Definitiv"] as bool? ?? false));
            BewilligungControlsVisible(BaInstitutionID != 0);
        }

        private void SetAllFields_ES()
        {
            bool canEdit = qryBaZahlungsweg.CanUpdate;
            // Felder Einstellen gemäss ausgewähltem Einzahlungsscheintyps:
            if (DBUtil.IsEmpty(edtEinzahlungsschein.EditValue) || !canEdit)
            {
                // Wenn nichts gewählt ist, dann soll alles gesperrt sein:
                edtPostkontoNr.EditMode = EditModeType.ReadOnly;
                edtBankkontoNr.EditMode = EditModeType.ReadOnly;
                edtBankPost.EditMode = EditModeType.ReadOnly;
                edtIBAN.EditMode = EditModeType.ReadOnly;
                pnPersonOnly.Visible = false;
            }
            else
            {
                int ezCode = (int)edtEinzahlungsschein.EditValue;
                // Postkonto-Nr.:
                if (canEdit && (ezCode == 1 || ezCode == 2))
                {
                    edtPostkontoNr.EditMode = EditModeType.Required;
                }
                else
                {
                    edtPostkontoNr.EditMode = EditModeType.ReadOnly;
                }

                edtPostkontoNr.Visible = (ezCode == 1 || ezCode == 2);
                edtBankPC.Visible = !edtPostkontoNr.Visible;

                pnPersonOnly.Visible = (ezCode != 1) && _isPersonZahlungsweg;

                // Bankkonto, Bank/Post, IBAN Feld und Schalter
                if (canEdit && (ezCode == 3 || ezCode == 4 || ezCode == 5))
                {
                    edtBankkontoNr.EditMode = ezCode == 4 ? EditModeType.ReadOnly : EditModeType.Normal;
                    edtBankPost.EditMode = EditModeType.Required;
                }
                else
                {
                    edtBankkontoNr.EditMode = EditModeType.ReadOnly;
                    edtBankPost.EditMode = EditModeType.ReadOnly;
                }

                // IBAN Feld
                if (canEdit && (ezCode == 3 || ezCode == 4 || ezCode == 5))
                {
                    edtIBAN.EditMode = EditModeType.Required;
                }
                else
                {
                    edtIBAN.EditMode = EditModeType.ReadOnly;
                }

                //Zahlwegtyp ist inaktiv -> Maske deaktivieren
                if (!ZahlwegTypIsActive())
                {
                    qryBaZahlungsweg.EnableBoundFields(false);
                }
                else
                {
                    //Zahlwegtyp ist aktiv -> Maske aktivieren, wenn sie vorher aktiv war
                    qryBaZahlungsweg.EnableBoundFields(_enableBoundFields);
                }
            }
        }

        private void SetEditMainFields()
        {
            bool canEdit = (qryBaZahlungsweg.CanUpdate && qryBaZahlungsweg.Count > 0);
            if (canEdit)
            {
                edtDatumVon.EditMode = EditModeType.Required;
                edtDatumBis.EditMode = EditModeType.Optional;
                edtEinzahlungsschein.EditMode = EditModeType.Required;
            }
            else
            {
                edtDatumVon.EditMode = EditModeType.ReadOnly;
                edtDatumBis.EditMode = EditModeType.ReadOnly;
                edtEinzahlungsschein.EditMode = EditModeType.ReadOnly;
            }
        }

        private void SetWMA()
        {
            if (!_isPersonZahlungsweg)
            {
                return;
            }

            pnlAdresse.Visible = edtWMAVerwenden.Checked;
        }

        private void tabZusatz_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page == tpgDokumente)
            {
                ActiveSQLQuery = qryBaZahlungswegDokumente;
            }
            else
            {
                ActiveSQLQuery = qryBaZahlungsweg;
            }
        }

        private void TryGenerateIBAN()
        {
            int ezCode = Utils.ConvertToInt(edtEinzahlungsschein.EditValue);
            if (ezCode == 0)
            {
                return;
            }

            edtIBANErrorMsg.Text = "";

            try
            {
                string iban;
                if (ezCode == 2) // Postkonto
                {
                    iban = Belegleser.IBANConvert(edtPostkontoNr.Text, "9000");
                    qryBaZahlungsweg["IBANNummer"] = iban;
                }
                else if (ezCode == 3 || ezCode == 5)
                {
                    if (!string.IsNullOrEmpty(edtBankkontoNr.Text) && !string.IsNullOrEmpty(edtClearingNummer.Text))
                    {
                        // KontoNr und BCL vorhanden
                        // IBAN aus Bankkontonummer und Bank (Clearingnummer)
                        iban = Belegleser.IBANConvert(edtBankkontoNr.Text, edtClearingNummer.Text);
                        string ibanBefore = qryBaZahlungsweg["IBANNummer"] as string;
                        if (string.IsNullOrEmpty(ibanBefore))
                        {
                            // neue IBAN speichern
                            qryBaZahlungsweg["IBANNummer"] = iban;
                        }
                        else
                        {
                            // neue IBAN mit bestehender vergleichen
                            if (iban.ToUpper().Replace(" ", "") != ibanBefore.ToUpper().Replace(" ", ""))
                            {
                                throw new KissInfoException(
                                    string.Format(
                                        "Generierte IBAN {0} stimmt nicht mir bisheriger ({1}) überein. Löschen Sie die bestehende IBAN oder korrigieren Sie die Kontonummer / Clearingnummer.{2}{2}Für einen neuen Zahlweg erfassen Sie bitte eine neue Zeile.",
                                        iban,
                                        ibanBefore,
                                        Environment.NewLine));
                            }

                            // sonst stimmts ja, also kein Speichern der IBAN nötig
                        }
                    }
                }

                qryBaZahlungsweg["IBANNummer"] = qryBaZahlungsweg["IBANNummer"].ToString().ToUpper();
            }
            catch (Exception ex)
            {
                edtIBANErrorMsg.Text = ex.Message;
                // Tab mit Fehlermeldung zeigen, sonst merkts niemand
                tabZusatz.SelectedTabIndex = 1;
                throw new KissCancelException(ex.Message, ex); // Weiter werfen, damit die Zahlinfo nicht gespeichert wird. Sonst könnten inkonsistente Daten abgelegt werden
            }
        }

        private SqlQuery TryToGetClearingNR()
        {
            SqlQuery qryBcl = null;
            string iban = edtIBAN.EditValue.ToString();
            if (!string.IsNullOrEmpty(iban))
            {
                iban = iban.Replace(" ", "");
                int bcl;
                if (iban.StartsWith("CH") && iban.Length == 21 && int.TryParse(iban.Substring(4, 5), out bcl))
                {
                    qryBcl = DBUtil.OpenSQL(@"
                        SELECT TOP 1 BaBankID, ClearingNr, HauptsitzBCL, BankName = Name + IsNull(', ' + Ort,''), BankPC = dbo.fnTnToPc(PCKontoNr)
                        FROM BaBank
                        WHERE ClearingNr = {0}",
                        bcl.ToString());
                }
            }

            return qryBcl;
        }

        private bool ZahlungsverbindungDefinitivSetzen()
        {
            var status = qryBaZahlungsweg["BaFreigabeStatusCode"] as int? ?? 0;
            if (status == 2)
            {
                //wenn bereits definitiv, muss nichts gemacht werden
                return true;
            }

            if (!IsDefinitivSetzenAllowed())
            {
                tabZusatz.SelectTab(tpgDokumente);
                throw new KissCancelException("Der Zahlweg kann nicht definitiv gesetzt werden, da  kein zugehöriges Dokument erfasst wurde.");
            }

            if (!qryBaZahlungsweg.Post()) return false;

            qryBaZahlungsweg["BaFreigabeStatusCode"] = 2; //definitiv
            qryBaZahlungsweg["DefinitivUserID"] = Session.User.UserID;
            qryBaZahlungsweg["DefinitivDatum"] = DateTime.Now;
            qryBaZahlungsweg["Definitiv"] = Session.User.LogonName + ", " + DateTime.Now.ToString("dd.MM.yyyy");

            int baZahlungswegId = qryBaZahlungsweg["BaZahlungswegID"] as int? ?? 0;

            qryBaZahlungswegDokumente.Post();

            DBUtil.ExecSQLThrowingException(@"UPDATE BaZahlungswegDokument SET Definitiv = 1 WHERE BaZahlungswegID = {0} AND Definitiv = 0",
                baZahlungswegId);
            qryBaZahlungswegDokumente.Refresh();

            return qryBaZahlungsweg.Post();
        }

        private bool ZahlwegTypIsActive()
        {
            var qry = edtEinzahlungsschein.Properties.DataSource as SqlQuery;
            if (qry != null && qry.DataTable.Columns.Contains("IsActive") && !DBUtil.IsEmpty(edtEinzahlungsschein.EditValue))
            {
                //Ermitteln ob der aktuelle Zahlwegtyp aktiv ist oder nicht
                DataRow[] rows = qry.DataTable.Select(string.Format("Code = {0}", edtEinzahlungsschein.EditValue));
                return rows.Length > 0 && (rows[0]["IsActive"] as bool? ?? false);
            }
            return true;
        }

        #endregion

        public override bool OnSaveData()
        {
            //sicherstellen, dass immer beide Queries (qryBaZahlungsweg und qryBaZahlungswegDokumente) gespeichert werden
            //damit exakt das gleiche gemacht wird, wie wenn F2 gedrückt würde, wird der Umweg gemacht über base.OnSaveData() mit vorgängigem expliziten ActiveSQLQuery.
            var previousActiveSqlQuery = ActiveSQLQuery;
            var result = false;
            try
            {
                //qrybaZahlungsweg.Post()
                ActiveSQLQuery = qryBaZahlungsweg;
                result = base.OnSaveData();

                if (result)
                {
                    //qryBaZahlungswegDokumente.Post()
                    ActiveSQLQuery = qryBaZahlungswegDokumente;

                    result = base.OnSaveData();
                }
            }
            finally
            {
                //jetzt wieder das Query setzen, das zuvor aktiv war
                ActiveSQLQuery = previousActiveSqlQuery;
            }
            return result;
        }

        private void edtDocument_DocumentDeleted(object sender, EventArgs e)
        {
            // damit DateCreation und DateLastSave im Gitter korrekt angezeigt werden
            qryBaZahlungswegDokumente["DateCreation"] = null;
            qryBaZahlungswegDokumente["DateLastSave"] = null;
            qryBaZahlungswegDokumente["DocumentID"] = null;
            qryBaZahlungswegDokumente.Post();
        }

        private void qryBaZahlungsweg_AfterDelete(object sender, EventArgs e)
        {
            Session.Commit();
        }

        private void qryBaZahlungsweg_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            try
            {
                DBUtil.ExecSQLThrowingException(@"DELETE dbo.XDocument WHERE DocumentID IN (SELECT DocumentID FROM BaZahlungswegDokument WHERE BaZahlungswegID = {0})", qryBaZahlungsweg["BaZahlungswegID"]);
                DBUtil.ExecSQLThrowingException(@"DELETE dbo.BaZahlungswegDokument WHERE BaZahlungswegID = {0}", qryBaZahlungsweg["BaZahlungswegID"]);
            }
            catch (Exception)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        private void qryBaZahlungswegDokumente_BeforeInsert(object sender, EventArgs e)
        {
            if (qryBaZahlungsweg.IsEmpty)
            {
                tabZusatz.SelectTab(tpgStandard);
                KissMsg.ShowInfo(typeof(CtlBaZahlungsweg).Name, "DokumentOhneZahlweg", "Ohne Zahlweg kann kein neues Dokument gespeichert werden. Bitte erfassen Sie zuerst einen Zahlweg.");
                throw new KissCancelException();
            }
        }

        private void qryBaZahlungswegDokumente_BeforePost(object sender, EventArgs e)
        {
            //sicherstellen, dass der BaZahlungsweg-Datensatz gespeichert ist
            qryBaZahlungsweg.Post();

            if (DBUtil.IsEmpty(qryBaZahlungswegDokumente["BaZahlungswegID"]))
            {
                qryBaZahlungswegDokumente["BaZahlungswegID"] = qryBaZahlungsweg["BaZahlungswegID"] as int?;
            }
        }
    }
}