using System;
using System.Data;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    public partial class CtlRueckläuferKorrigieren : Common.KissQueryControl
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CtlRueckläuferKorrigieren()
        {
            InitializeComponent();

            gridView2.OptionsBehavior.Editable = true;
        }

        #endregion

        #region Public Methods

        public override void OnSearch()
        {
            // Workaround um F3 weiter zu reichen, da das FrameWork das OrgUnitTeamUser UserControl nicht kennt
            if (ActiveControl is ContainerControl && ((ContainerControl)ActiveControl).ActiveControl.Equals(ctlOrgUnitTeamUser))
            {
                searchTitle.Focus();
            }

            base.OnSearch();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            ctlOrgUnitTeamUser.NewSearch();
            edtErledigteAnzeigen.EditValue = false;
        }

        #endregion

        #region Private Methods

        private bool AuswahlKreditor(string searchString, bool buttonClicked)
        {
            bool cancel = false;
            searchString = searchString.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (buttonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryQuery["Kreditor"] = DBNull.Value;
                    qryQuery["ZusatzInfo"] = DBNull.Value;
                    qryQuery["BaZahlungswegID"] = DBNull.Value;
                    qryQuery["Referenznummer"] = DBNull.Value;
                    return false;
                }
            }

            if (searchString == ".")
            // Auszahlung an
            // Klientensystem       - FaFallPerson
            // Involvierte Stellen  - FaInvolvierteInstitution
            // Krankenkasse         - BaKrankenversicherung
            // Vermieter            - BaWohnsituation
            // Arbeitgeber          - BaArbeit
            {
                KissLookupDialog dlg = new KissLookupDialog();
                cancel = !dlg.SearchData(
                    @"
                    -- Personen im Haushalt
                    SELECT ID$              = KRE.BaZahlungswegID,
                           Typ              = 'Klientensystem',
                           Name             = KRE.PersonNameVorname,
                           Verwendungszweck = KRE.Verwendungszweck,
                           Zahlungsweg      = KRE.Zahlungsweg,
                           ESCode$          = KRE.EinzahlungsscheinCode,
                           Kreditor$        = KRE.Kreditor,
                           ZusatzInfo$      = KRE.ZUsatzInfo,
                           BaPersonID$      = KRE.BaPersonID,
                           BaInstitutionID$ = KRE.BaInstitutionID,
                           SortKey$         = 1
                    FROM   FaFallPerson FAP
                           INNER JOIN vwKreditor KRE ON KRE.BaPersonID = FAP.BaPersonID
                    WHERE  FAP.FaFallID = {0}
               				AND GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate())
                            AND GetDate() BETWEEN ISNULL(FAP.DatumVon, CONVERT(DateTime, '1900-01-01')) AND ISNULL(FAP.DatumBis, CONVERT(DateTime, '2079-06-06'))

                    UNION

                    -- Involvierte Stellen
                    SELECT ID$              = KRE.BaZahlungswegID,
                           Typ              = 'involvierte Stelle',
                           Name             = KRE.InstitutionName,
                           Verwendungszweck = KRE.Verwendungszweck,
                           Zahlungsweg      = KRE.Zahlungsweg,
                           ESCode$          = KRE.EinzahlungsscheinCode,
                           Kreditor$        = KRE.Kreditor,
                           ZusatzInfo$      = KRE.ZusatzInfo,
                           BaPersonID$      = KRE.BaPersonID,
                           BaInstitutionID$ = KRE.BaInstitutionID,
                           SortKey$         = 2
                    FROM   FaInvolvierteInstitution INV
                           INNER JOIN vwKreditor    KRE ON KRE.BaInstitutionID = INV.BaInstitutionID
                    WHERE  INV.FaFallID = {0} AND
                           GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                           KRE.BaFreigabeStatusCode = 2 AND
                           KRE.InstitutionIstKreditor = 1

                    UNION

                    -- Krankenkasse
                    SELECT ID$              = KRE.BaZahlungswegID,
                           Typ              = 'Krankenkasse',
                           Name             = KRE.InstitutionName,
                           Verwendungszweck = KRE.Verwendungszweck,
                           Zahlungsweg      = KRE.Zahlungsweg,
                           ESCode$          = KRE.EinzahlungsscheinCode,
                           Kreditor$        = KRE.Kreditor,
                           ZusatzInfo$      = KRE.ZusatzInfo,
                           BaPersonID$      = KRE.BaPersonID,
                           BaInstitutionID$ = KRE.BaInstitutionID,
                           SortKey$         = 3
                    FROM   FaFallPerson FAP
                           INNER JOIN BaKrankenversicherung KKV ON KKV.BaPersonID = FAP.BaPersonID
                           INNER JOIN vwKreditor            KRE ON KRE.BaInstitutionID = KKV.BaInstitutionID
                    WHERE  FAP.FaFallID = {0} AND
                           GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                           KRE.BaFreigabeStatusCode = 2 AND
                           KRE.InstitutionIstKreditor = 1

                    UNION

                    -- Vermieter
                    SELECT ID$              = KRE.BaZahlungswegID,
                           Typ              = 'Vermieter',
                           Name             = KRE.InstitutionName,
                           Verwendungszweck = KRE.Verwendungszweck,
                           Zahlungsweg      = KRE.Zahlungsweg,
                           ESCode$          = KRE.EinzahlungsscheinCode,
                           Kreditor$        = KRE.Kreditor,
                           ZusatzInfo$      = KRE.ZusatzInfo,
                           BaPersonID$      = KRE.BaPersonID,
                           BaInstitutionID$ = KRE.BaInstitutionID,
                           SortKey$         = 4
                    FROM   FaFallPerson FAP
                           INNER JOIN BaWohnsituationPerson WOP ON WOP.BaPersonID = FAP.BaPersonID
                           INNER JOIN BaWohnsituation       WOH ON WOH.BaWohnsituationID = WOP.BaWohnsituationID
                           INNER JOIN vwKreditor            KRE ON KRE.BaInstitutionID = WOH.BaInstitutionID
                    WHERE  FAP.FaFallID = {0} AND
                           GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                           KRE.BaFreigabeStatusCode = 2 AND
                           KRE.InstitutionIstKreditor = 1

                    UNION

                    -- Abeitgeber
                    SELECT ID$              = KRE.BaZahlungswegID,
                           Typ              = 'Arbeitgeber',
                           Name             = KRE.InstitutionName,
                           Verwendungszweck = KRE.Verwendungszweck,
                           Zahlungsweg      = KRE.Zahlungsweg,
                           ESCode$          = KRE.EinzahlungsscheinCode,
                           Kreditor$        = KRE.Kreditor,
                           ZusatzInfo$      = KRE.ZusatzInfo,
                           BaPersonID$      = KRE.BaPersonID,
                           BaInstitutionID$ = KRE.BaInstitutionID,
                           SortKey$         = 5
                    FROM   FaFallPerson FAP
                           INNER JOIN BaArbeit   ARB ON ARB.BaPersonID = FAP.BaPersonID
                           INNER JOIN vwKreditor KRE ON KRE.BaInstitutionID = ARB.BaInstitutionID
                    WHERE  FAP.FaFallID = {0} AND
                           GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                           KRE.BaFreigabeStatusCode = 2 AND
                           KRE.InstitutionIstKreditor = 1
                    ORDER BY SortKey$,Name,Zahlungsweg",
                    qryQuery["FaFallID"].ToString(),
                    buttonClicked,
                    null,
                    null,
                    null);

                if (!cancel)
                {
                    RefreshZahlungsweg(dlg["BaPersonID$"] as int?, dlg["BaInstitutionID$"] as int?);
                    UpdateZahlungsweg(dlg["ID$"] as int?, dlg["Kreditor$"] as string, dlg["ZusatzInfo$"] as string, dlg["ESCode$"] as int?);
                }
            }
            else
            {
                var dlg2 = new Common.ZH.DlgAuswahlBaZahlungsweg();
                Application.DoEvents();

                dlg2.SucheBaZahlungsweg(searchString);

                bool setNewZahlungsweg = false;
                switch (dlg2.Count)
                {
                    case 0:
                        KissMsg.ShowInfo("Keine zutreffenden Kreditor-Einträge gefunden!");
                        break;

                    case 1:
                        setNewZahlungsweg = true;
                        break;

                    default:
                        setNewZahlungsweg = dlg2.ShowDialog(this) == DialogResult.OK;
                        break;
                }

                if (setNewZahlungsweg)
                {
                    RefreshZahlungsweg(dlg2["BaPersonID$"] as int?, dlg2["BaInstitutionID$"] as int?);
                    UpdateZahlungsweg(dlg2["BaZahlungswegID"] as int?, dlg2["Kreditor"] as string, dlg2["Zusatzinfo"] as string, dlg2["EinzahlungsscheinCode"] as int?);
                }
            }

            return cancel;
        }

        private void btnJumpZahlungsweg_Click(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryQuery["BaPersonID"]))
            {
                // Sprung zur Zahlungsinfo
                FormController.OpenForm("FrmFall", "Action", "JumpToZahlungsweg",
                                        "BaPersonID", qryQuery["Falltraeger"],
                                        "ModulID", 1,
                                        "FieldValue", string.Format(@"P{0}", qryQuery["BaPersonID"]),
                                        "BaZahlungswegID", qryQuery["BaZahlungswegID"]);
            }
            else
            {
                // Sprung zum InstitutionenStamm
                FormController.OpenForm("FrmInstitutionenStamm", "Action", "ShowZahlweg",
                                        "BaInstitutionID", qryQuery["BaInstitutionID"],
                                        "BaZahlungswegID", qryQuery["BaZahlungswegID"]);
            }
        }

        private void btnKorrigiert_Click(object sender, EventArgs e)
        {
            var userText = "Buchung {0}/CHF {1:N2}; Status auf '{2}' setzen";
            var statusText = "";

            try
            {
                Cursor = Cursors.WaitCursor;
                if ((int)qryQuery["KbBuchungStatusCode"] == 9)
                {
                    if (!KissMsg.ShowQuestion("Haben Sie die notwendigen Aenderungen vorgenommen. Wollen Sie die Zahlung jetzt wieder freigeben?"))
                    {
                        Cursor = Cursors.Default;
                        return;
                    }

                    var qryZW = (SqlQuery)edtZahlungsweg.Properties.DataSource;
                    foreach (DataRow row in qryZW.DataTable.Rows)
                    {
                        try
                        {
                            if ((int)row["Code"] == (int)edtZahlungsweg.EditValue)
                            {
                                qryQuery["KbBuchungStatusCode"] = 16;
                                qryQuery["PscdZahlwegArt"] = row["PscdZahlwegArt"];
                                qryQuery["PCKontoNr"] = row["PCKontoNr"];
                                qryQuery["BaBankID"] = row["BaBankID"];
                                qryQuery["BankKontoNr"] = row["BankKontoNr"];
                                qryQuery["IBAN"] = row["IBAN"];
                                qryQuery["BeguenstigtName"] = row["BeguenstigtName"];
                                qryQuery["BeguenstigtPostfach"] = row["BeguenstigtPostfach"];
                                qryQuery["BeguenstigtStrasse"] = row["BeguenstigtStrasse"];
                                qryQuery["BeguenstigtHausNr"] = row["BeguenstigtHausNr"];
                                qryQuery["BeguenstigtPLZ"] = row["BeguenstigtPLZ"];
                                qryQuery["BeguenstigtOrt"] = row["BeguenstigtOrt"];
                                qryQuery["BeguenstigtLandCode"] = row["BeguenstigtLandCode"];
                                qryQuery["BankName"] = row["BankName"];
                                qryQuery["BankStrasse"] = row["BankStrasse"];
                                qryQuery["BankPLZ"] = row["BankPLZ"];
                                qryQuery["BankOrt"] = row["BankOrt"];
                                qryQuery["BankBCN"] = row["BankBCN"];
                                statusText = "Rückläufer korrigiert";
                                break;
                            }
                        }
                        catch { }
                    }
                }
                else
                {
                    qryQuery["KbBuchungStatusCode"] = 9;
                    statusText = "Rückläufer";
                }

                userText = string.Format(userText, qryQuery["KbBuchungID"], qryQuery["Betrag"], statusText);

                var postSucceeded = qryQuery.Post();
                // Meldung wird nicht ausgegeben falls der Datensatz in der Zwischenzeit schon geändert wurde.
                if (postSucceeded)
                {
                    KissMsg.ShowInfo(userText + ": erfolgreich");

                    //update AuszahlungsPositionen im Budget
                    DBUtil.ExecSQLThrowingException(@"
UPDATE AZP SET BaZahlungswegID = {1}, ReferenzNummer = {2}
FROM dbo.BgAuszahlungPerson AZP
  INNER JOIN dbo.KbBuchungKostenart BKO ON BKO.BgPositionID = AZP.BgPositionID
WHERE BKO.KbBuchungID = {0}", qryQuery["KbBuchungID"], qryQuery["BaZahlungswegID"], edtESR.EditValue);
                }

                qryQuery.Refresh();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(userText + ": " + ex.Message);
                Cursor = Cursors.Default;
            }
        }

        private void CtlRueckläuferKorrigieren_Load(object sender, EventArgs e)
        {
            //Buchungsstati laden
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KbBuchungsStatus' order by SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    (int)row["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }
        }

        private void edtKreditor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = AuswahlKreditor(edtKreditor.EditValue.ToString(), e.ButtonClicked);
        }

        private void edtZahlungsweg_EditValueChanged(object sender, EventArgs e)
        {
            var qry = DBUtil.OpenSQL(@"SELECT ZI = ZusatzInfo FROM vwKreditor KRE WHERE KRE.BaZahlungswegID = {0}", edtZahlungsweg.EditValue);
            if (qry.Count > 0)
            {
                edtZusatzinfo.Text = qry["ZI"].ToString();
                //qryQuery["PscdZahlwegArt"] = DBUtil.OpenSQL(@"SELECT ZI = ZusatzInfo FROM vwKreditor KRE WHERE KRE.BaZahlungswegID = {0}", edtZahlungsweg.EditValue);
            }
        }

        private void edtZahlungsweg_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var esCode = ((SqlQuery)edtZahlungsweg.Properties.DataSource).DataTable
                .Select(string.Format("Code = {0}", edtZahlungsweg.EditValue))[0]["ESCode"] as int?;
            UpdateZahlungsweg(edtZahlungsweg.EditValue as int?, qryQuery["Kreditor"] as string, qryQuery["Zusatzinfo"] as string, esCode);
        }

        private void qryQuery_BeforePost(object sender, EventArgs e)
        {
            SqlQuery qry = DBUtil.OpenSQL("select PostKontoNummer, EinzahlungsscheinCode from BaZahlungsweg where BaZahlungswegID = {0}", qryQuery["BaZahlungswegID"]);

            if (qry.Count == 1 && (int)qry["EinzahlungsscheinCode"] == 1)
            {
                DBUtil.CheckNotNullField(edtESR, "Referenznummer");

                if (qry.Count == 1 && !edtESR.ValidateReferenzNummer(qry["PostKontoNummer"].ToString()))
                {
                    edtESR.Focus();
                    throw new KissCancelException();
                }
            }
        }

        private void qryQuery_PositionChanged(object sender, EventArgs e)
        {
            if (qryQuery.Count <= 0)
            {
                edtZahlungsweg.EditMode = EditModeType.ReadOnly;
                edtESR.EditMode = EditModeType.ReadOnly;
                return;
            }

            edtZahlungsweg.EditMode = EditModeType.Normal;

            RefreshZahlungsweg(qryQuery["BaPersonID"] as int?, qryQuery["BaInstitutionID"] as int?);
            SetEsrMode(Convert.ToInt32(qryQuery["EinzahlungsscheinCode"]));
        }

        private void RefreshZahlungsweg(int? baPersonID, int? baInstitutionID)
        {
            if (!baPersonID.HasValue && !baInstitutionID.HasValue)
            {
                KissMsg.ShowError(typeof(CtlRueckläuferKorrigieren).Name, "BaPersonIdAndBaInstitutionIdEmpty", "Es muss entweder die BaPersonID oder die BaInstitutionID gesetzt sein.");
                throw new KissCancelException();
            }

            SqlQuery qry;
            const string sql = @"
                SELECT Code                = KIN.BaZahlungswegID,
                       Text                = KRE.Zahlungsweg,
                       PscdZahlwegArt      = XLC.Value1,
                       Zahlungsweg         = KRE.Zahlungsweg,
                --     ReferenzNummer      = ,
                       BeguenstigtName     = KIN.Name,
                       BeguenstigtPostfach = KIN.Postfach,
                       BeguenstigtStrasse  = KIN.Strasse,
                       BeguenstigtHausNr   = KIN.HausNr,
                       BeguenstigtPLZ      = KIN.PLZ,
                       BeguenstigtOrt      = KIN.Ort,
                       BeguenstigtLandCode = KIN.LandCode,
                       PCKontoNr           = KIN.PCKontoNr,
                       BaBankID            = KIN.BaBankID,
                       BankKontoNr         = KIN.BankKontoNr,
                       IBAN                = KIN.IBAN,
                       BankName            = KIN.BankName,
                       BankStrasse         = KIN.BankStrasse,
                       BankPLZ             = KIN.BankPLZ,
                       BankOrt             = KIN.BankOrt,
                       BankBCN             = KIN.Bank_BCN,
                       ESCode              = KRE.EinzahlungsscheinCode,
                       Kreditor            = KRE.Kreditor,
                       ZusatzInfo          = KRE.ZusatzInfo,
                       SortKey             = 1
                FROM   dbo.vwKreditorInfo   KIN
                  INNER JOIN dbo.vwKreditor KRE ON KRE.BaZahlungswegID = KIN.BaZahlungswegID
                  INNER JOIN dbo.XLOVCode   XLC ON XLC.LOVName = 'BgEinzahlungsschein' AND XLC.Code = KRE.EinzahlungsscheinCode
                WHERE GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, CONVERT(DateTime, '1900-01-01')) AND ISNULL(KRE.ZahlungswegDatumBis, CONVERT(DateTime, '2079-06-06'))
                ";

            qry = baPersonID.HasValue ? DBUtil.OpenSQL(sql + @" AND KRE.BaPersonID = {0}", baPersonID) : DBUtil.OpenSQL(sql + @" AND KRE.BaInstitutionID = {0}", baInstitutionID);

            edtZahlungsweg.LoadQuery(qry);
        }

        private void SetEsrMode(int? code)
        {
            if (code.HasValue && code.Value == 1)
            {
                edtESR.EditMode = EditModeType.Normal;
            }
            else
            {
                edtESR.EditMode = EditModeType.ReadOnly;
                qryQuery["Referenznummer"] = DBNull.Value;
            }
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            btnJumpZahlungsweg.Visible = (qryQuery.Count > 0);
            btnKorrigiert.Visible = (qryQuery.Count > 0);
        }

        private void UpdateZahlungsweg(int? baZahlungswegID, string kreditor, string zusatzinfo, int? einzahlungsscheinCode)
        {
            qryQuery["BaZahlungswegID"] = baZahlungswegID;
            qryQuery["Kreditor"] = kreditor;
            qryQuery["Zusatzinfo"] = zusatzinfo;

            SetEsrMode(einzahlungsscheinCode);
        }

        #endregion
    }
}