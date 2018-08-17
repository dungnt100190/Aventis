using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Kiss.BusinessLogic.Ba;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Ba;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Main.ZH
{
    public partial class CtlSuchePerson : KissUserControl
    {
        public int BaPersonID;
        public int FaFallID;
        private bool _onSearchInProgress;

        public CtlSuchePerson()
        {
            InitializeComponent();

            var qryGeschlecht = DBUtil.OpenSQL(@"SELECT Text = '', Code = NULL

                                                 UNION ALL

                                                 SELECT Text = ShortText, Code
                                                 FROM   XLOVCode
                                                 WHERE  LOVName = 'BaGeschlecht'");

            colGeschlecht.ColumnEdit = grdVwPerson.GetLOVLookUpEdit(qryGeschlecht);

            btnKIS.URL = DBUtil.GetConfigString(@"System\Schnittstellen\KIS\URL", null);
        }

        public object PersonOhneLeistung
        {
            get
            {
                return edtPersonOhneLeistung.Checked;
            }
        }

        public int SelectedTab
        {
            get
            {
                return tabPerson.SelectedTabIndex;
            }
        }

        public object SelectedVISFallNr
        {
            get
            {
                return tabPerson.SelectedTabIndex == 1 ? qryVISMandant["VIS_FallNr"] : null;
            }
        }

        public void Activate()
        {
            edtSucheNachname.Focus();
        }

        /// <returns>BaPersonID</returns>
        public int? GetPersonIDCreateIfNecessary(bool checkIfFallExist)
        {
            if (tabPerson.SelectedTabIndex == 0)
            {
                //Personensuche in Omega
                if (qryVwPerson["BaPersonID"] is int)
                {
                    var baPersonID = (int)qryVwPerson["BaPersonID"];
                    if (checkIfFallExist)
                    {
                        //Prüfen, ob schon eine aktive Fallführung besteht
                        var fallNr = DBUtil.ExecuteScalarSQL(@"
                            SELECT TOP 1 FaFallID FROM FaFall
                            WHERE  BaPersonID = {0} AND
                                   DatumBis IS NULL",
                            baPersonID) as int?;

                        if (!DBUtil.IsEmpty(fallNr))
                        {
                            throw new KissInfoException(KissMsg.GetMLMessage("CtlSuchePerson", "BereitsAktiveFallNr", "Für diese Person gibt es bereits den aktiven Fall {0}!", KissMsgCode.MsgInfo, fallNr));
                        }
                    }

                    return baPersonID;
                }

                if (qryVwPerson["IsOmegaPerson"] is bool && (bool)qryVwPerson["IsOmegaPerson"])
                {
                    // neue Person erfassen, deren ID zurückgeben
                    // Personen, die in Omega den Status passiv haben, dürfen nicht erfasst werden
                    bool? einwohnerregisterAktiv = (bool?)qryVwPerson["EinwohnerregisterAktiv"];
                    if (einwohnerregisterAktiv.HasValue && einwohnerregisterAktiv.Value == false)
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                "CtlSuchePerson",
                                "PersonIstOmegaPassiv",
                                "Es dürfen keine Personen erfasst werden, die in Omega den Status 'Passiv' haben!",
                                KissMsgCode.MsgInfo));
                    }

                    // Prüfen, ob bereits eine Person mit dieser PID in Kiss erfasst ist
                    var omegaId = (string)qryVwPerson["EinwohnerregisterID"];
                    var qryPersonWithPidInKiss = DBUtil.OpenSQL("SELECT Name, Vorname FROM dbo.BaPerson WHERE EinwohnerregisterID = {0};", omegaId);
                    if (qryPersonWithPidInKiss.Count > 0)
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                "CtlSuchePerson",
                                "PersonMitDieserPIDschonInKiss",
                                "Eine Person mit der PID '{0}' wird bereits in KiSS geführt: {1} {2}",
                                KissMsgCode.MsgInfo,
                                omegaId,
                                qryPersonWithPidInKiss["Vorname"],
                                qryPersonWithPidInKiss["Name"]));
                    }

                    //Cursor = Cursors.WaitCursor;
                    //Application.DoEvents();
                    return ImportOmegaPerson(omegaId);
                }

                return null;
            }

            if (tabPerson.SelectedTabIndex == 1)
            {
                if ((bool)qryVISMandant["ZipInKiss"])
                {
                    var qryPerson = DBUtil.OpenSQL(@"SELECT BaPersonID FROM BaPerson WHERE ZIPNr = {0}", qryVISMandant["ZIPNr"]);

                    if (qryPerson.Count == 0)
                    {
                        return null;
                    }

                    var baPersonID = 0;

                    if (checkIfFallExist)
                    {
                        baPersonID = Convert.ToInt32(qryPerson["BaPersonID"]);

                        //Prüfen, ob schon eine aktive Fallführung besteht
                        var fallNr = DBUtil.ExecuteScalarSQL(@"
                            SELECT TOP 1 FaFallID FROM FaFall
                            WHERE  BaPersonID = {0} AND
                                   DatumBis IS NULL",
                            baPersonID) as int?;

                        if (!DBUtil.IsEmpty(fallNr))
                        {
                            throw new KissInfoException(KissMsg.GetMLMessage("CtlSuchePerson", "BereitsAktiveFallNr", "Für diese Person gibt es bereits den aktiven Fall {0}!", KissMsgCode.MsgInfo, fallNr));
                        }
                    }

                    return baPersonID;
                }

                // neue Person erfassen, deren ID zurückgeben
                if (!DBUtil.IsEmpty(qryVISMandant["ZIPNr"]))
                {
                    var zipnr = Convert.ToInt32(qryVISMandant["ZIPNr"]);
                    string omegaId = zipnr.ToString(CultureInfo.InvariantCulture).PadLeft(10, '0');
                    return ImportOmegaPerson(omegaId);
                }

                var qry = DBUtil.OpenSQL(@"
                            INSERT BaPerson (Name, Vorname, AHVNummer, Geburtsdatum, GeschlechtCode, Bemerkung, Creator, Created, Modifier, Modified)
                            VALUES ({0}, {1}, {2}, {3},
                                            CASE {4}
                                                WHEN 'M' THEN 1
                                                WHEN 'W' THEN 2
                                                END,
                                            ISNULL('Heimatort: ' + {5} + char(13) + char(10),'') +
                                            ISNULL('Zivilstand: ' + {6} + char(13) + char(10),'') +
                                            ISNULL('Strasse: ' + {7} + char(13) + char(10),'') +
                                            ISNULL('Ort: ' + isnull({8} + ' ','') + {9},''),
                                    {10}, GetDate(), {10}, GetDate());
                        SELECT BaPersonID = @@IDENTITY;",
                        qryVISMandant["Nachname"],
                        qryVISMandant["Vorname"],
                        qryVISMandant["AHVNummer"],
                        qryVISMandant["Geburtsdatum"],
                        qryVISMandant["Geschlecht"],
                        qryVISMandant["Heimatort"],
                        qryVISMandant["Zivilstand"],
                        qryVISMandant["Strasse"],
                        qryVISMandant["PLZ"],
                        qryVISMandant["Ort"],
                        DBUtil.GetDBRowCreatorModifier());

                if (qry.Count == 0)
                {
                    return null;
                }

                return Convert.ToInt32(qry["BaPersonID"]);
            }

            if (tabPerson.SelectedTabIndex == 2)
            {
                //neue Person

                // neue Person erfassen, deren ID zurückgeben
                try
                {
                    DBUtil.CheckNotNullField(edtErfassenName);
                    DBUtil.CheckNotNullField(edtErfassenVorname);

                    if (!KissMsg.ShowQuestion("CtlSuchePerson", "IstInPersonenstamm", "Sind Sie sicher, dass '{0} {1}' nicht bereits im Personenstamm erfasst ist?", 0, 0, true, qryNeuePerson["Vorname"], qryNeuePerson["Name"]))
                    {
                        throw new KissCancelException();
                    }

                    if (qryNeuePerson.DataTable.Columns.Contains("Creator") &&
                        qryNeuePerson.DataTable.Columns.Contains("Created") &&
                        qryNeuePerson.DataTable.Columns.Contains("Modifier") &&
                        qryNeuePerson.DataTable.Columns.Contains("Modified"))
                    {
                        qryNeuePerson.SetCreator();
                        qryNeuePerson["Created"] = DateTime.Now;
                        qryNeuePerson.SetModifierModified();
                    }

                    if (!qryNeuePerson.Post())
                    {
                        throw new KissCancelException();
                    }

                    var baPersonID = (int)qryNeuePerson["BaPersonID"];
                    return baPersonID;
                }
                catch (KissCancelException ex)
                {
                    ex.ShowMessage();
                    throw;
                }
                catch (Exception ex)
                {
                    KissMsg.ShowInfo(ex.Message);
                    throw;
                }
            }

            return null;
        }

        public override void OnSearch()
        {
            if (_onSearchInProgress)
            {
                return;
            }

            try
            {
                _onSearchInProgress = true;

                switch (tabPerson.SelectedTabIndex)
                {
                    case 0:
                        if (tabSearch.SelectedTabIndex == 1)
                        {
                            RunSearch();
                            tabSearch.SelectedTabIndex = 0;
                            grdVwPerson.Focus();
                        }
                        else
                        {
                            tabSearch.SelectedTabIndex = 1;
                            foreach (Control c in UtilsGui.AllControls(tpgSuchen))
                            {
                                var baseEdit = c as BaseEdit;
                                if (baseEdit != null)
                                {
                                    (baseEdit).EditValue = null;
                                }
                            }

                            edtSearchInKiSS.Checked = true;
                            edtSearchInOmega.Checked = true;
                            edtSucheAuchAehnliche.Checked = true;
                            edtSucheNurAktive.Checked = false;
                            edtSucheNachname.Focus();
                        }
                        break;

                    case 1:
                        if (tabVISSearch.SelectedTabIndex == 1)
                        {
                            VISRunSearch();
                            tabVISSearch.SelectedTabIndex = 0;
                            grdVISMandant.Focus();
                        }
                        else
                        {
                            tabVISSearch.SelectedTabIndex = 1;
                            foreach (Control c in UtilsGui.AllControls(tpgVISSuchen))
                            {
                                var baseEdit = c as BaseEdit;
                                if (baseEdit != null)
                                {
                                    (baseEdit).EditValue = null;
                                }
                            }

                            edtSucheVISNachname.Focus();
                        }
                        break;
                }
            }
            finally
            {
                _onSearchInProgress = false;
            }
        }

        private bool AllowSearch()
        {
            var empty = DBUtil.IsEmpty(edtSuchePID.EditValue) &&
                        DBUtil.IsEmpty(edtSucheNachname.EditValue) &&
                        DBUtil.IsEmpty(edtSucheVorname.EditValue) &&
                        DBUtil.IsEmpty(edtSucheStrasse.EditValue) &&
                        DBUtil.IsEmpty(edtSucheHausNr.EditValue) &&
                        DBUtil.IsEmpty(edtSucheGebDatVon.EditValue) &&
                        DBUtil.IsEmpty(edtSucheGebDatBis.EditValue) &&
                        DBUtil.IsEmpty(edtSucheAHV13.EditValue) &&
                        DBUtil.IsEmpty(edtSucheAHV11.EditValue) &&
                        DBUtil.IsEmpty(edtSucheZemis.EditValue);
            return !empty;
        }

        private void CtlSuchePerson_Load(object sender, EventArgs e)
        {
            tabSearch.SelectedTabIndex = 0;
            tabVISSearch.SelectedTabIndex = 1;
            tabPerson.SelectedTabIndex = 0;

            tbpVIS.HideTab = !DBUtil.UserHasRight("CtlSuchePerson_VIS_Abfrage");

            //Neue Person vorbereiten
            qryNeuePerson.Fill("SELECT TOP 0 * FROM BaPerson");

            qryNeuePerson.Insert();
            qryNeuePerson.RowModified = true;

            edtPersonOhneLeistung.Checked = true;
            edtPersonOhneLeistung.Enabled = DBUtil.UserHasRight("CtlSuchePerson_NeuePersonMitLeistung");

            OnSearch();
        }

        private int? ImportOmegaPerson(string pid)
        {
            try
            {
                BaPerson baPerson;
                BaEinwohnerregisterPersonAnfrageDTO personDto;

                var einwohnerregisterService = Kiss.Infrastructure.IoC.Container.Resolve<BaEinwohnerregisterService>();
                var validationResult = einwohnerregisterService.ValidateAndGetImportPerson(
                    pid,
                    false,
                    null,
                    out baPerson,
                    out personDto);

                if (validationResult.IsQuestion && !KissMsg.ShowResult(validationResult))
                {
                    return null;
                }

                if (baPerson != null && personDto != null)
                {
                    IDictionary<string, string> changes;
                    var importResult = einwohnerregisterService.ImportPerson(baPerson, personDto, out changes);

                    if (importResult.IsOk)
                    {
                        return importResult.Result.BaPersonID;
                    }

                    KissMsg.ShowResult(importResult);
                }
                else
                {
                    KissMsg.ShowResult(validationResult);
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }

            return null;
        }

        private int? MapIsoLandToId(string landCode)
        {
            var baLandId = DBUtil.ExecuteScalarSQL(@"
                SELECT TOP 1 BaLandID
                FROM dbo.BaLand LND WITH (READUNCOMMITTED)
                WHERE Iso2Code = {0}
                ORDER BY DatumVon DESC, DatumBis ASC;", landCode);
            return (int?)(DBUtil.IsEmpty(baLandId) ? null : baLandId);
        }

        private void qryVISMandant_AfterFill(object sender, EventArgs e)
        {
            qryVISMassnahme.DataTable.Clear();
            if (!DBUtil.IsEmpty(qryVISMandant["VIS_FallNr"]))
            {
                qryVISMassnahme.Fill(qryVISMandant["VIS_FallNr"]);
            }
        }

        private void qryVISMandant_PositionChanged(object sender, EventArgs e)
        {
            qryVISMassnahme.Fill(qryVISMandant["VIS_FallNr"]);
        }

        private void qryVwPerson_PositionChanged(object sender, EventArgs e)
        {
            ctlGotoFall.BaPersonID = qryVwPerson["BaPersonID"];
            var zipNr = qryVwPerson["ZIPNr"] as int?;
            var ahvNr = qryVwPerson["AHVNummer"] as string;
            var ahvNotNull = !string.IsNullOrEmpty(ahvNr);

            if (zipNr.HasValue)
            {
                btnKIS.URL = string.Format("{0}?ZIP={1}", DBUtil.GetConfigString(@"System\Schnittstellen\KIS\URL", null), zipNr.Value);
            }
            else if (ahvNotNull)
            {
                btnKIS.URL = string.Format("{0}?AHV={1}", DBUtil.GetConfigString(@"System\Schnittstellen\KIS\URL", null), ahvNr);
            }

            btnKIS.Enabled = zipNr.HasValue || ahvNotNull;
        }

        private void RunSearch()
        {
            if ((edtSearchInKiSS.Checked || edtSearchInOmega.Checked) && !AllowSearch())
            {
                KissMsg.ShowInfo(typeof(CtlSuchePerson).Name, "OnSearch_DoNotAllow", "Bitte geben Sie mindestens ein Suchkriterium ein.");
                throw new KissCancelException();
            }

            try
            {
                qryVwPerson.UnbindControls();

                Cursor.Current = Cursors.WaitCursor;
                qryVwPerson.Fill(@"
                    SELECT TOP 0
                      *,
                      PLZ = WohnsitzPLZ,
                      Ort = WohnsitzOrt,
                      IsKiSSPerson = CONVERT(BIT, 1),
                      IsOmegaPerson = CONVERT(BIT, 0),
                      OrgUnitID = NULL,
                      IsFT = CONVERT(BIT, 0)
                    FROM dbo.vwPerson;");

                if (edtSearchInKiSS.Checked)
                {
                    string sqlStatement = @"
                        SELECT
                          *,
                          PLZ = WohnsitzPLZ,
                          Ort = WohnsitzOrt,
                          IsKiSSPerson = CONVERT(BIT, 1),
                          IsOmegaPerson = CONVERT(BIT, 0),
                          OrgUnitID,
                          IsFT = CONVERT(BIT, CASE
                                                WHEN EXISTS(SELECT
                                                              F.FaFallID
                                                            FROM dbo.FaFall F
                                                            WHERE F.BaPersonID = PRS.BaPersonID) THEN 1
                                                ELSE 0
                                              END)
                        FROM dbo.vwPerson      PRS
                          LEFT JOIN dbo.BaHaus HAU ON HAU.BaStrasseID = PRS.WohnsitzStrasseCode AND (CAST(HAU.Hausnummer AS VARCHAR) + ISNULL(HAU.Suffix, '')) = PRS.WohnsitzHausNr
                            WHERE  1 = 1 ";

                    // Vorname
                    if (!string.IsNullOrEmpty(edtSucheVorname.Text))
                    {
                        if (edtSucheAuchAehnliche.Checked)
                        {
                            sqlStatement += string.Format(" AND ( Vorname LIKE {0}) ", DBUtil.SqlLiteralLike(edtSucheVorname.Text + "%"));
                        }
                        else
                        {
                            sqlStatement += string.Format(" AND ( Vorname = {0}) ", DBUtil.SqlLiteral(edtSucheVorname.Text));
                        }
                    }

                    // Nachname
                    if (!string.IsNullOrEmpty(edtSucheNachname.Text))
                    {
                        if (edtSucheAuchAehnliche.Checked)
                        {
                            sqlStatement += string.Format(" AND ( Name LIKE {0}) ", DBUtil.SqlLiteralLike(edtSucheNachname.Text + "%"));
                        }
                        else
                        {
                            sqlStatement += string.Format(" AND ( Name = {0}) ", DBUtil.SqlLiteral(edtSucheNachname.Text));
                        }
                    }

                    // Strasse
                    if (!string.IsNullOrEmpty(edtSucheStrasse.Text))
                    {
                        sqlStatement += string.Format(" AND ( WohnsitzStrasse LIKE {0}) ", DBUtil.SqlLiteralLike(edtSucheStrasse.Text + "%"));
                    }

                    // Hausnummer
                    if (!string.IsNullOrEmpty(edtSucheHausNr.Text))
                    {
                        sqlStatement += string.Format(" AND ( WohnsitzHausNr LIKE {0}) ", DBUtil.SqlLiteralLike(edtSucheHausNr.Text + "%"));
                    }

                    // Geburtsdatum von
                    if (!DBUtil.IsEmpty(edtSucheGebDatVon.EditValue))
                    {
                        sqlStatement += string.Format(" AND ( Geburtsdatum > {0}) ", DBUtil.SqlLiteral(edtSucheGebDatVon.EditValue));
                    }

                    // Geburtsdatum bis
                    if (!DBUtil.IsEmpty(edtSucheGebDatBis.EditValue))
                    {
                        sqlStatement += string.Format(" AND ( Geburtsdatum < {0}) ", DBUtil.SqlLiteral(edtSucheGebDatBis.EditValue));
                    }

                    // Geschlecht
                    if (!DBUtil.IsEmpty(edtSucheGeschlecht.Text))
                    {
                        sqlStatement += string.Format(" AND ( GeschlechtCode = {0}) ", DBUtil.SqlLiteral(edtSucheGeschlecht.EditValue));
                    }

                    // AHV-Nummer
                    if (!string.IsNullOrEmpty(edtSucheAHV11.Text))
                    {
                        sqlStatement += string.Format(" AND ( AHVNummer LIKE {0}) ", DBUtil.SqlLiteralLike(edtSucheAHV11.Text + "%"));
                    }

                    // SVN-Nummer
                    if (!DBUtil.IsEmpty(edtSucheAHV13.EditValue))
                    {
                        sqlStatement += string.Format(" AND ( VersichertenNummer LIKE {0}) ", DBUtil.SqlLiteralLike(edtSucheAHV13.Text + "%"));
                    }

                    // ZEMIS
                    if (!DBUtil.IsEmpty(edtSucheZemis.EditValue))
                    {
                        sqlStatement += string.Format(" AND ( ZEMISNummer = {0}) ", DBUtil.SqlLiteral(edtSucheZemis.EditValue));
                    }

                    // PID
                    if (!DBUtil.IsEmpty(edtSuchePID.EditValue))
                    {
                        sqlStatement += string.Format(" AND ( RIGHT('0000000000' + EinwohnerregisterID, 10) LIKE {0}) ", DBUtil.SqlLiteralLike("%" + edtSuchePID.EditValue + "%"));
                    }

                    if (edtSucheNurAktive.Checked)
                    {
                        sqlStatement += " AND EXISTS(SELECT 1 FROM FaFall WHERE BaPersonID = PRS.BaPersonID AND DatumBis IS NULL) ";
                    }

                    sqlStatement += "ORDER BY Name, Vorname, Geburtsdatum;";
                    qryVwPerson.Fill(sqlStatement);
                    foreach (DataRow kissRow in qryVwPerson.DataTable.Rows)
                    {
                        kissRow["IsOmegaPerson"] = !DBUtil.IsEmpty(kissRow["EinwohnerregisterID"]);
                    }

                    qryVwPerson.DataTable.AcceptChanges();
                    qryVwPerson.RowModified = false;
                }

                if (edtSearchInOmega.Checked && edtSucheNurAktive.Checked == false)
                {
                    try
                    {
                        var strasseText = edtSucheStrasse.Text;
                        DateTime? geburtsDatum = null;
                        if (!String.IsNullOrEmpty(edtSucheGebDatVon.Text))
                        {
                            geburtsDatum = DateTime.Parse(edtSucheGebDatVon.Text);
                        }

                        // Omega aufrufen
                        var einwohnerregisterService = Kiss.Infrastructure.IoC.Container.Resolve<BaEinwohnerregisterService>();
                        var sucheDto = new BaEinwohnerregisterPersonSucheDTO
                        {
                            // Parameter abfüllen
                            AHV11 = edtSucheAHV11.Text,
                            AHV13 = edtSucheAHV13.Text,
                            Geburtsdatum = geburtsDatum,
                            GeschlechtCode = (int?)edtSucheGeschlecht.EditValue,
                            Hausnummer = edtSucheHausNr.Text,
                            Nachname = edtSucheNachname.Text,
                            PID = edtSuchePID.Text,
                            Strasse = strasseText,
                            Vorname = edtSucheVorname.Text,
                            ZEMISNr = edtSucheZemis.Text,
                        };

                        var serviceResult = einwohnerregisterService.PersonSuchen(sucheDto);

                        // Omega ResultSet füllen
                        if (serviceResult.IsOk && serviceResult.Result != null)
                        {
                            if (!serviceResult.Result.Any())
                            {
                                KissMsg.ShowInfo(
                                    "CtlSuchePerson",
                                    "KeinePersonInOmegaGefunden",
                                    "Für die Suchkriterien wurde keine Person in Omega gefunden.");
                            }
                            else
                            {
                                foreach (var omegaPerson in serviceResult.Result)
                                {
                                    var pid = einwohnerregisterService.PreparePid(omegaPerson.PID);

                                    var existing = qryVwPerson.DataTable.Rows.Cast<DataRow>()
                                        .FirstOrDefault(x => einwohnerregisterService.PreparePid(x["EinwohnerregisterID"] as string) == pid);

                                    if (existing != null)
                                    {
                                        existing["IsOmegaPerson"] = true;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            DataRow newRow = qryVwPerson.DataTable.NewRow();
                                            newRow["EinwohnerregisterID"] = omegaPerson.PID;
                                            newRow["EinwohnerregisterIDOhne0er"] = omegaPerson.PID.TrimStart('0');
                                            newRow["Name"] = omegaPerson.Name;
                                            newRow["Vorname"] = omegaPerson.Vorname;
                                            newRow["GeschlechtCode"] = omegaPerson.GeschlechtCode;
                                            newRow["NationalitaetCode"] = (object)MapIsoLandToId(omegaPerson.NationLandIso2) ?? DBNull.Value;
                                            newRow["EinwohnerregisterAktiv"] = omegaPerson.IsActive;
                                            newRow["Geburtsdatum"] = omegaPerson.Geburtsdatum == null
                                                ? DBNull.Value
                                                : (object)omegaPerson.Geburtsdatum;
                                            newRow["Versichertennummer"] = omegaPerson.Versichertennummer;
                                            newRow["AHVNummer"] = omegaPerson.AHVNr;
                                            newRow["IsKissPerson"] = false;
                                            newRow["IsOmegaPerson"] = true;

                                            // TODO streetCode

                                            if (omegaPerson.Adressen != null && omegaPerson.Adressen.Length > 0)
                                            {
                                                var adresse = omegaPerson.Adressen.FirstOrDefault(x => x.IsCurrent) ?? omegaPerson.Adressen[0];
                                                newRow["WohnsitzStrasseHausNr"] = adresse.Strasse;
                                                newRow["WohnsitzAdressZusatz"] = adresse.Zusatz;
                                                newRow["WohnsitzPLZOrt"] = adresse.Ort;
                                                newRow["WohnsitzPLZ"] = adresse.Plz;
                                                newRow["WohnsitzOrt"] = adresse.Ort;
                                                newRow["WohnsitzLandCode"] = (object)MapIsoLandToId(adresse.Land) ?? DBNull.Value;
                                            }

                                            qryVwPerson.DataTable.Rows.Add(newRow);
                                        }
                                        catch (Exception ex)
                                        {
                                            KissMsg.ShowError(
                                                "CtlSuchePerson",
                                                "FehlerInOmegaRow",
                                                "Fehler beim Übertragen einer Omega-Person in die Sammeltabelle",
                                                ex);
                                        }
                                    }
                                }
                                qryVwPerson.DataTable.AcceptChanges();
                                qryVwPerson.RowModified = false;
                            }
                        }
                        else if (serviceResult.IsError)
                        {
                            KissMsg.ShowError(
                                "CtlSuchePerson",
                                "FehlerOmegaAufruf",
                                "Fehler beim Abfragen der Omega-Schnittstelle.",
                                serviceResult.GetTechnicalDetails());
                        }
                        else
                        {
                            KissMsg.ShowResult(serviceResult);
                        }
                    }
                    catch (KissCancelException ex)
                    {
                        ex.ShowMessage();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Error during Omega query. Message: {0}\r\nStack: {1}", ex.Message, ex.StackTrace));
                    }
                }
            }
            finally
            {
                qryVwPerson.BindControls();
            }

            if (qryVwPerson.Count == 0)
            {
                btnKIS.Enabled = false;
                ctlGotoFall.BaPersonID = DBNull.Value;
            }

            Cursor.Current = Cursors.Default;
        }

        private void tabSearch_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            if (tabSearch.SelectedTabIndex == 1)    // Es wird von Search nach Liste umgeschaltet
            {
                OnSearch();
            }
        }

        private void tabVISSearch_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            if (tabVISSearch.SelectedTabIndex == 1)    // Es wird von Search nach Liste umgeschaltet
            {
                OnSearch();
            }
        }

        private void VISRunSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sqlStatement = @"
                    SELECT DISTINCT
                        VIS_FallNr     = VDOS.FALL_NR,
                        ZIPNr          = VDOS.ZIP_NR,
                        Nachname       = VDOS.NAME + ISNULL('-' + VDOS.ALLIANZNAME,''),
                        Vorname        = VDOS.Vorname,
                        Geburtsdatum   = VDOS.G_DAT,
                        Heimatort      = VDOS.H_ORT,
                        Zivilstand     = VDOS.ZIV,
                        AHVNummer      = VDOS.AHV_NR,
                        Geschlecht     = VDOS.SEX,
                        Strasse        = VDOS.WMA_STR,
                        PLZ            = VDOS.WMA_PLZ,
                        Ort            = VDOS.WMA_ORT,
                        ZipInKiss      = CONVERT(BIT, CASE WHEN PER.BaPersonID IS NULL THEN 0 ELSE 1 END)
                    FROM dbo.vwVIS_DOSSIER            VDOS
                      INNER JOIN dbo.vwVIS_MASSNAHMEN VMAS ON VMAS.DossierId = VDOS.Id
                      LEFT  JOIN dbo.BaPerson         PER  ON PER.ZIPNr = VDOS.ZIP_NR
                    WHERE GETDATE() BETWEEN VMAS.BESCH_A_ED AND ISNULL(VMAS.BESCH_A_AD, '99991231') ";

                if (!string.IsNullOrEmpty(edtSucheVISNachname.Text))
                {
                    sqlStatement += string.Format(
                        " AND VDOS.NAME + IsNull('-' + VDOS.ALLIANZNAME,'') LIKE {0} ",
                        DBUtil.SqlLiteralLike(edtSucheVISNachname.Text + "%"));
                }

                if (!string.IsNullOrEmpty(edtSucheVISVorname.Text))
                {
                    sqlStatement += string.Format(" AND VDOS.Vorname LIKE {0} ", DBUtil.SqlLiteralLike(edtSucheVISVorname.Text + "%"));
                }

                if (!DBUtil.IsEmpty(edtSucheVISGeburtsdatum.EditValue))
                {
                    sqlStatement += string.Format(" AND VDOS.G_DAT = {0} ", DBUtil.SqlLiteral(edtSucheVISGeburtsdatum.EditValue));
                }

                if (!DBUtil.IsEmpty(edtSucheVISZIPNr.EditValue))
                {
                    sqlStatement += string.Format(" AND VDOS.ZIP_NR = {0} ", edtSucheVISZIPNr.EditValue);
                }

                if (!DBUtil.IsEmpty(edtSucheVISFallNr.EditValue))
                {
                    sqlStatement += string.Format(" AND VDOS.FALL_NR = {0} ", edtSucheVISFallNr.EditValue);
                }

                sqlStatement += "ORDER BY VDOS.NAME + IsNull('-' + VDOS.ALLIANZNAME,''), VDOS.Vorname, VDOS.G_DAT";

                qryVISMandant.SelectStatement = sqlStatement;
                qryVISMandant.Fill();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}