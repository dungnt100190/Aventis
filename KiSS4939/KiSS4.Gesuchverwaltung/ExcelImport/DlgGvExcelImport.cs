using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Kiss.Infrastructure.Constant;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gesuchverwaltung.ExcelImport.DTO;
using KiSS4.Gui;

namespace KiSS4.Gesuchverwaltung.ExcelImport
{
    public partial class DlgGvExcelImport : KissDialog
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASS_NAME = "DlgGvExcelImport";
        private const string QRY_PERSON_DTO_ID = "DTOID";
        private const string QRY_PERSON_NEU_BAPERSONID = "NeuBaPersonID";
        private const string QRY_PERSON_OK = "OK";
        private const string QRY_PERSON_ZAHLUNGSWEG = "Zahlungsweg";

        private const string SQL_PERSON = @"
                 SELECT PRS.BaPersonID,
                   PRS.Name,
                   PRS.Vorname,
                   PRS.Versichertennummer,
                   PRS.Geburtsdatum,
                   ADR.BaLandID,
                   ADR.Strasse,
                   ADR.HausNr,
                   ADR.Zusatz,
                   ADR.Kanton,
                   ADR.Ort,
                   ADR.PLZ,
                   ADR.OrtschaftCode,
                   ADR.Bezirk,
                   BaRelationID  = NULL,
                   OK            = CONVERT(BIT, 0),
                   NeuBaPersonID = CONVERT(VARCHAR, NULL),
                   Zahlungsweg   = NULL,
                   DTOID         = NULL
            FROM dbo.BaPerson             PRS WITH(READUNCOMMITTED)
              -- aktueller Wohnsitz
              LEFT JOIN dbo.BaAdresse     ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
            WHERE
              NOT (
                  {0} IS NULL AND
                  {1} IS NULL AND
                  {2} IS NULL AND
                  {3} IS NULL AND
                  {4} IS NULL AND
                  {5} IS NULL
               ) AND (
                  ({0} IS NULL OR PRS.Name = {0})
                  AND ({1} IS NULL OR PRS.Vorname = {1})
                  AND ({2} IS NULL OR PRS.Versichertennummer = {2})
                  AND ({3} IS NULL OR ADR.Strasse = {3})
                  AND ({4} IS NULL OR ADR.PLZ = {4})
                  AND ({5} IS NULL OR ADR.ORT = {5})
               )
            ORDER BY BaRelationID, Name, Vorname;";

        private readonly GvExcelImporter _importer;

        #endregion

        #endregion

        #region Constructors

        public DlgGvExcelImport(string fileName)
        {
            InitializeComponent();

            SetupDataMember();
            SetupFieldName();

            double version = DBUtil.GetConfigDouble(@"System\Gesuchverwaltung\ExcelTemplateVersion", 0.0);

            _importer = new GvExcelImporter(fileName, version);
        }

        #endregion

        #region Properties

        public GvGesuchDTO GvGesuchDTO
        {
            get;
            set;
        }

        #endregion

        #region EventHandlers

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnNeuAnlegen_Click(object sender, EventArgs e)
        {
            qryPersonExcel[QRY_PERSON_OK] = true;
            qryPersonExcel[QRY_PERSON_NEU_BAPERSONID] = KissMsg.GetMLMessage(CLASS_NAME, "Text_Neu", "Neu");
            AcceptChanges();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // prüfen, ob alle Personen OK sind
            bool klientZugewiesen = false;
            bool klientNeu = false;

            foreach (DataRow row in qryPersonExcel.DataTable.Rows)
            {
                if (!Utils.ConvertToBool(row[QRY_PERSON_OK]))
                {
                    KissMsg.ShowInfo(CLASS_NAME, "NotAllOK", "Es sind noch nicht alle Personen zugewiesen.");
                    return;
                }

                if (Utils.ConvertToInt(row[DBO.BaRelation.BaRelationID]) == BaPersonDTO.BA_RELATION_ID_KLIENT &&
                    !DBUtil.IsEmpty(row[QRY_PERSON_NEU_BAPERSONID]))
                {
                    klientZugewiesen = true;

                    if (!Utils.IsNumeric(row[QRY_PERSON_NEU_BAPERSONID].ToString()))
                    {
                        klientNeu = true;
                    }
                }
            }

            // Es muss eine Person mit BA_RELATION_ID_KLIENT geben
            if (!klientZugewiesen)
            {
                KissMsg.ShowInfo(CLASS_NAME, "Kein_Klient_Zugewiesen", "Es ist kein Fallträger zugewiesen.");
                return;
            }

            // Sicherheitsfrage, falls ein neuer Fall eröffnet werden soll (Klient wurde auf "Neu anlegen" gesetzt)
            if (klientNeu)
            {
                if (!KissMsg.ShowQuestion(CLASS_NAME, "Klient_Neu", "Sind Sie sicher, dass Sie einen neuen Fall eröffnen möchten?"))
                {
                    return;
                }
            }

            var dto = _importer.GvGesuchDTO;
            UpdateDto(dto);
            GvGesuchDTO = dto;
            DialogResult = DialogResult.OK;
        }

        private void btnSuche_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void btnZuweisen_Click(object sender, EventArgs e)
        {
            // Check rows
            if (qryPersonExcel.Row == null || qryPersonKiss.Row == null)
            {
                return;
            }

            // Ask user
            if (!KissMsg.ShowQuestion(
                CLASS_NAME,
                "Zuweisen_DatenÜberschreiben",
                "Sind Sie sicher, dass Sie die existierenden Daten dieser Person in KiSS modifizieren wollen?"))
            {
                return;
            }

            var baPersonId = qryPersonKiss[DBO.BaPerson.BaPersonID];
            qryPersonExcel[DBO.BaPerson.BaPersonID] = baPersonId;
            qryPersonExcel[QRY_PERSON_OK] = true;
            qryPersonExcel[QRY_PERSON_NEU_BAPERSONID] = baPersonId;

            AcceptChanges();
        }

        private void DlgGvExcelImport_Load(object sender, EventArgs e)
        {
            // Load relation drop down
            var qryRelation = DBUtil.OpenSQL(@"
                SELECT Code = -1,
                       Text = 'Klient'

                UNION ALL

                SELECT Code = BaRelationID,
                       Text = NameGenerisch1
                FROM dbo.BaRelation WITH (READUNCOMMITTED)

                UNION ALL

                SELECT Code = BaRelationID + 100,
                       Text = NameGenerisch2
                FROM dbo.BaRelation WITH (READUNCOMMITTED)
                WHERE NameGenerisch1 <> NameGenerisch2
                ORDER BY 2;");

            edtExcelBeziehung.LoadQuery(qryRelation);
            colExcelBeziehung.ColumnEdit = grdPersonenExcel.GetLOVLookUpEdit(qryRelation);

            qryPersonExcel.Fill(SQL_PERSON, null, null, null, null, null, null);
            qryPersonKiss.Fill(SQL_PERSON, null, null, null, null, null, null);

            // Load data from the excel file
            try
            {
                if (_importer.Load() && ValidateAndFixZahlungswegDto())
                {
                    LoadZusatzAdresseInfoFromDb();
                    LoadPersonen();
                    PerformSearch();
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            finally
            {
                _importer.Dispose();
            }
        }

        private void edtExcelVersNr_EditValueChanged(object sender, EventArgs e)
        {
            UpdateQueryVersNr();
        }

        private void qryPersonExcel_PositionChanging(object sender, EventArgs e)
        {
            AcceptChanges();
        }

        #endregion

        #region Methods

        #region Private Methods

        private void AcceptChanges()
        {
            qryPersonExcel.RowModified = false;
            qryPersonExcel.DataSet.AcceptChanges();
        }

        private bool HasAdresse(DataRow row)
        {
            return !(DBUtil.IsEmpty(row[DBO.BaAdresse.Strasse]) &&
                     DBUtil.IsEmpty(row[DBO.BaAdresse.HausNr]) &&
                     DBUtil.IsEmpty(row[DBO.BaAdresse.PLZ]) &&
                     DBUtil.IsEmpty(row[DBO.BaAdresse.Ort]) &&
                     DBUtil.IsEmpty(row[DBO.BaAdresse.OrtschaftCode]) &&
                     DBUtil.IsEmpty(row[DBO.BaAdresse.Kanton]) &&
                     DBUtil.IsEmpty(row[DBO.BaAdresse.Bezirk]) &&
                     Utils.ConvertToInt(row[DBO.BaAdresse.BaLandID]) == 0 &&
                     DBUtil.IsEmpty(row[DBO.BaAdresse.Zusatz]));
        }

        private void LoadPersonen()
        {
            for (int i = 0; i < _importer.GvGesuchDTO.BaPersonDTOList.Count; i++)
            {
                var baPersonDTO = _importer.GvGesuchDTO.BaPersonDTOList[i];

                qryPersonExcel.Insert();
                qryPersonExcel[DBO.BaPerson.Name] = baPersonDTO.Name;
                qryPersonExcel[DBO.BaPerson.Vorname] = baPersonDTO.Vorname;
                qryPersonExcel[DBO.BaPerson.Geburtsdatum] = baPersonDTO.Geburtsdatum;
                qryPersonExcel[DBO.BaPerson.Versichertennummer] = baPersonDTO.Versichertennummer;
                qryPersonExcel[DBO.BaRelation.BaRelationID] = baPersonDTO.BaRelationId;

                var adresse = baPersonDTO.BaAdresseDTO;

                if (adresse != null)
                {
                    qryPersonExcel[DBO.BaAdresse.Strasse] = adresse.Strasse;
                    qryPersonExcel[DBO.BaAdresse.HausNr] = adresse.HausNr;
                    qryPersonExcel[DBO.BaAdresse.PLZ] = adresse.Plz;
                    qryPersonExcel[DBO.BaAdresse.Ort] = adresse.Ort;
                    qryPersonExcel[DBO.BaAdresse.OrtschaftCode] = adresse.OrtschaftCode;
                    qryPersonExcel[DBO.BaAdresse.Kanton] = adresse.Kanton;
                    qryPersonExcel[DBO.BaAdresse.Bezirk] = adresse.Bezirk;
                    qryPersonExcel[DBO.BaAdresse.BaLandID] = adresse.BaLandId;
                    qryPersonExcel[DBO.BaAdresse.Zusatz] = adresse.Zusatz;
                }

                // TODO Zahlungsweg

                // save DTO ID for use in UpdatePersonDTOsFromQuery()
                qryPersonExcel[QRY_PERSON_DTO_ID] = i;

                AcceptChanges();
            }

            qryPersonExcel.First();

            grvPersonenKiss.BestFitColumns();
        }

        private void LoadZusatzAdresseInfoFromDb()
        {
            var selectBaPlz =
                @"
                SELECT
                  PLZ.BaPLZID,
                  PLZ.PLZ,
                  PLZ.Kanton,
                  Bezirk = ISNULL(dbo.fnGetMLText(GDE.BezirkNameTID, {0}), GDE.BezirkName)
                FROM dbo.BaPLZ             PLZ WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.BaGemeinde GDE WITH (READUNCOMMITTED) ON GDE.BFSCode = PLZ.BFSCode
                WHERE PLZ.PLZ = {1}
                  AND PLZ.Name = {2}
                  AND GDE.GemeindeAufhebungDatum IS NULL";
            var qryBaPlz = new SqlQuery();

            foreach (var adresse in _importer.GvGesuchDTO.BaPersonDTOList.Select(x => x.BaAdresseDTO).Where(x => x != null).ToList())
            {
                qryBaPlz.Fill(selectBaPlz, Session.User.LanguageCode, adresse.Plz, adresse.Ort);
                if (!qryBaPlz.IsEmpty)
                {
                    adresse.OrtschaftCode = qryBaPlz[DBO.BaPLZ.BaPLZID].ToString();
                    adresse.Kanton = qryBaPlz[DBO.BaPLZ.Kanton].ToString();
                    adresse.Bezirk = qryBaPlz["Bezirk"].ToString();
                }
            }
        }

        private void PerformSearch()
        {
            var name = edtKriteriumName.Checked ? edtExcelName.EditValue : null;
            var vorname = edtKriteriumVorname.Checked ? edtExcelVorname.EditValue : null;
            var versNr = edtKriteriumVersNr.Checked ? edtExcelVersNr.EditValue : null;
            var strasse = edtKriteriumStrasse.Checked ? edtExcelStrasse.EditValue : null;
            var plz = edtKriteriumPlz.Checked ? edtExcelPlzOrt.PLZ : null;
            var ort = edtKriteriumOrt.Checked ? edtExcelPlzOrt.Ort : null;

            qryPersonKiss.Fill(SQL_PERSON, name, vorname, versNr, strasse, plz, ort);
            grvPersonenKiss.BestFitColumns();
        }

        private void SetupDataMember()
        {
            edtExcelBeziehung.DataMember = DBO.BaRelation.BaRelationID;
            edtExcelGeburtsdatum.DataMember = DBO.BaPerson.Geburtsdatum;
            edtExcelHausNr.DataMember = DBO.BaAdresse.HausNr;
            edtExcelName.DataMember = DBO.BaPerson.Name;
            edtExcelPlzOrt.DataMemberKanton = DBO.BaAdresse.Kanton;
            edtExcelPlzOrt.DataMemberOrt = DBO.BaAdresse.Ort;
            edtExcelPlzOrt.DataMemberPLZ = DBO.BaAdresse.PLZ;
            edtExcelStrasse.DataMember = DBO.BaAdresse.Strasse;
            edtExcelVersNr.DataMember = DBO.BaPerson.Versichertennummer;
            edtExcelVorname.DataMember = DBO.BaPerson.Vorname;
            edtExcelZahlweg.DataMember = QRY_PERSON_ZAHLUNGSWEG;

            edtKissBeziehung.DataMember = DBO.BaPerson_Relation.BaRelationID;
            edtKissGeburtsdatum.DataMember = DBO.BaPerson.Geburtsdatum;
            edtKissHausNr.DataMember = DBO.BaAdresse.HausNr;
            edtKissName.DataMember = DBO.BaPerson.Name;
            edtKissPlzOrt.DataMemberKanton = DBO.BaAdresse.Kanton;
            edtKissPlzOrt.DataMemberOrt = DBO.BaAdresse.Ort;
            edtKissPlzOrt.DataMemberPLZ = DBO.BaAdresse.PLZ;
            edtKissStrasse.DataMember = DBO.BaAdresse.Strasse;
            edtKissVersNr.DataMember = DBO.BaPerson.Versichertennummer;
            edtKissVorname.DataMember = DBO.BaPerson.Vorname;
        }

        private void SetupFieldName()
        {
            colExcelBeziehung.FieldName = DBO.BaPerson_Relation.BaRelationID;
            colExcelGeburtsdatum.FieldName = DBO.BaPerson.Geburtsdatum;
            colExcelName.FieldName = DBO.BaPerson.Name;
            colExcelOk.FieldName = QRY_PERSON_OK;
            colExcelVersNr.FieldName = DBO.BaPerson.Versichertennummer;
            colExcelVorname.FieldName = DBO.BaPerson.Vorname;
            colNeuBaPersonID.FieldName = QRY_PERSON_NEU_BAPERSONID;

            colKissGeburtsdatum.FieldName = DBO.BaPerson.Geburtsdatum;
            colKissName.FieldName = DBO.BaPerson.Name;
            colKissVersNr.FieldName = DBO.BaPerson.Versichertennummer;
            colKissVorname.FieldName = DBO.BaPerson.Vorname;
        }

        private void UpdateDto(GvGesuchDTO dto)
        {
            var personenDtos = dto.BaPersonDTOList;

            foreach (DataRow row in qryPersonExcel.DataTable.Rows)
            {
                var dtoId = (int)row[QRY_PERSON_DTO_ID];
                var personDto = personenDtos[dtoId];

                var baPersonId = row[DBO.BaPerson.BaPersonID];
                personDto.BaPersonId = DBUtil.IsEmpty(baPersonId) ? null : (int?)baPersonId;
                personDto.Name = Utils.ConvertToString(row[DBO.BaPerson.Name], null);
                personDto.Vorname = Utils.ConvertToString(row[DBO.BaPerson.Vorname], null);
                personDto.Versichertennummer = Utils.ConvertToString(row[DBO.BaPerson.Versichertennummer], null);
                var geburtsdatum = row[DBO.BaPerson.Geburtsdatum];
                personDto.Geburtsdatum = DBUtil.IsEmpty(geburtsdatum) ? null : (DateTime?)geburtsdatum;
                personDto.BaRelationId = Utils.ConvertToInt(row[DBO.BaRelation.BaRelationID]);

                if (HasAdresse(row))
                {
                    var adresse = personDto.BaAdresseDTO;

                    if (adresse == null)
                    {
                        personDto.BaAdresseDTO = adresse = new BaAdresseDTO();
                    }

                    adresse.Strasse = Utils.ConvertToString(row[DBO.BaAdresse.Strasse], null);
                    adresse.HausNr = Utils.ConvertToString(row[DBO.BaAdresse.HausNr], null);
                    adresse.Plz = Utils.ConvertToString(row[DBO.BaAdresse.PLZ], null);
                    adresse.Ort = Utils.ConvertToString(row[DBO.BaAdresse.Ort], null);
                    adresse.OrtschaftCode = Utils.ConvertToString(row[DBO.BaAdresse.OrtschaftCode], null);
                    adresse.Kanton = Utils.ConvertToString(row[DBO.BaAdresse.Kanton], null);
                    adresse.Bezirk = Utils.ConvertToString(row[DBO.BaAdresse.Bezirk], null);
                    adresse.BaLandId = Utils.ConvertToInt(row[DBO.BaAdresse.BaLandID], Session.BaLandCodeSchweiz);
                    adresse.Zusatz = Utils.ConvertToString(row[DBO.BaAdresse.Zusatz], null);
                }
                else
                {
                    // Für alle Personen die gleiche Adresse setzen, sofern nicht etwas anderes angegeben
                    // (sollten immer im gleichen Haushalt sein)
                    personDto.BaAdresseDTO = dto.BaPersonDtoKlient.BaAdresseDTO;
                }
            }
        }

        private void UpdateQueryVersNr()
        {
            qryPersonExcel[DBO.BaPerson.Versichertennummer] = edtExcelVersNr.EditValue;
        }

        /// <summary>
        /// Validiert das DTO. Bei ungültigen Daten wird der Benutzer via MessageBox informiert
        /// </summary>
        /// <returns>True: Dto ist gültig, false: ungültig</returns>
        private bool ValidateAndFixZahlungswegDto()
        {
            if (_importer.GvGesuchDTO.BaZahlungswegDTO == null)
            {
                // keine Zahlungsinfos in Excel-Vorlage, Validierung nicht nötig
                return true;
            }

            IList<string> inputNotValid = new List<string>();

            // Fix PostKontoNr
            if (!string.IsNullOrWhiteSpace(_importer.GvGesuchDTO.BaZahlungswegDTO.PostkontoNr))
            {
                string errorMessage;
                string tnNumber;
                if (Utils.CheckPCKontoNumber(_importer.GvGesuchDTO.BaZahlungswegDTO.PostkontoNr, out errorMessage, out tnNumber))
                {
                    _importer.GvGesuchDTO.BaZahlungswegDTO.PostkontoNr = tnNumber;
                }
                else
                {
                    inputNotValid.Add(KissMsg.GetMLMessage(
                         CLASS_NAME,
                         "PostKontoNrUngueltig",
                         "Postkonto-Nr. ungültig: {0}", errorMessage));
                }
            }
            if (_importer.GvGesuchDTO.BaZahlungswegDTO.EinzahlungsscheinCode == (int)LOVsGenerated.BgEinzahlungsschein.OrangerEinzahlungsschein ||
                _importer.GvGesuchDTO.BaZahlungswegDTO.EinzahlungsscheinCode == (int)LOVsGenerated.BgEinzahlungsschein.RoterEinzahlungsscheinPost)
            {
                // Postkonto muss ausgefüllt sein
                if (string.IsNullOrWhiteSpace(_importer.GvGesuchDTO.BaZahlungswegDTO.PostkontoNr))
                {
                    inputNotValid.Add(KissMsg.GetMLMessage(
                          CLASS_NAME,
                          "PostKontoNr",
                          "Postkonto-Nr."));
                }
                //für RoterEinzahlungsscheinPost noch IBAN generieren
                if (_importer.GvGesuchDTO.BaZahlungswegDTO.EinzahlungsscheinCode == (int)LOVsGenerated.BgEinzahlungsschein.RoterEinzahlungsscheinPost)
                {
                    // IBAN generieren für PC-Konti, Format ist "xx-yyyyyy-p"
                    string iban = Belegleser.IBANConvert(_importer.GvGesuchDTO.BaZahlungswegDTO.PostkontoNr, "9000");
                    _importer.GvGesuchDTO.BaZahlungswegDTO.BankIban = iban;
                }
            }
            // Bankkonto-Nr., IBAN, Clearing und Bankname muss ausgefüllt sein.
            else if (_importer.GvGesuchDTO.BaZahlungswegDTO.EinzahlungsscheinCode == (int)LOVsGenerated.BgEinzahlungsschein.BankzahlungSchweiz ||
                     _importer.GvGesuchDTO.BaZahlungswegDTO.EinzahlungsscheinCode == (int)LOVsGenerated.BgEinzahlungsschein.RoterEinzahlungsscheinBank)
            {
                if (!string.IsNullOrWhiteSpace(_importer.GvGesuchDTO.BaZahlungswegDTO.BankIban))
                {
                    string ibanValidationMessage;
                    if (!Utils.CheckIBAN(_importer.GvGesuchDTO.BaZahlungswegDTO.BankIban, out ibanValidationMessage))
                    {
                        inputNotValid.Add(
                            KissMsg.GetMLMessage(
                                CLASS_NAME,
                                "IbanNrUngueltig",
                                "IBAN-Nr. ungültig: {0}",
                                ibanValidationMessage));
                    }
                    //alles ok, setze Clearing und KontoNr
                    string iban = _importer.GvGesuchDTO.BaZahlungswegDTO.BankIban;
                    iban = iban.Replace(" ", "");
                    int bcl;

                    if (iban.StartsWith("CH") &&
                        iban.Length == 21 &&
                        int.TryParse(iban.Substring(4, 5), out bcl))
                    {
                        SqlQuery qryBcl =
                            DBUtil.OpenSQL(
                                @"
                                SELECT TOP 1
                                       BaBankID,
                                       ClearingNr,
                                       HauptsitzBCL,
                                       BankName = Name + ISNULL(', ' + Ort,''),
                                       BankPC = dbo.fnTnToPc(PCKontoNr)
                                FROM dbo.BaBank WITH (READUNCOMMITTED)
                                WHERE ClearingNr = {0};",
                                bcl.ToString());

                        if (qryBcl.Count == 0)
                        {
                            _importer.GvGesuchDTO.BaZahlungswegDTO.BankClearing = null;
                            _importer.GvGesuchDTO.BaZahlungswegDTO.BankName = null;
                            _importer.GvGesuchDTO.BaZahlungswegDTO.PostkontoNr = null;
                        }
                        else
                        {
                            _importer.GvGesuchDTO.BaZahlungswegDTO.BankClearing = qryBcl[DBO.BaBank.ClearingNr].ToString();
                            _importer.GvGesuchDTO.BaZahlungswegDTO.BankName = qryBcl["BankName"].ToString();
                            _importer.GvGesuchDTO.BaZahlungswegDTO.PostkontoNr = qryBcl["BankPC"].ToString();
                        }
                    }
                }

                // IBAN ist nicht vorhanden
                else
                {
                    // Wenn IBAN leer, dann schauen wir ob PostKonto-Nr. und Clearing vorhanden ist für die Generierung der IBAN
                    if (!string.IsNullOrWhiteSpace(_importer.GvGesuchDTO.BaZahlungswegDTO.PostkontoNr) &&
                        !string.IsNullOrWhiteSpace(_importer.GvGesuchDTO.BaZahlungswegDTO.BankClearing))
                    {
                        try
                        {
                            // IBAN generieren
                            _importer.GvGesuchDTO.BaZahlungswegDTO.BankIban =
                                Belegleser.IBANConvert(_importer.GvGesuchDTO.BaZahlungswegDTO.PostkontoNr,
                                                       _importer.GvGesuchDTO.BaZahlungswegDTO.BankClearing);
                        }
                        catch (Exception exp)
                        {
                            inputNotValid.Add(KissMsg.GetMLMessage(
                            CLASS_NAME,
                            "IbanNrUngueltig",
                            "IBAN-Nr. ungültig: {0}", exp.Message));
                        }
                    }
                    else
                    {
                        inputNotValid.Add(KissMsg.GetMLMessage(
                            CLASS_NAME,
                            "IbanNr",
                            "IBAN-Nr."));
                    }
                }

                // Bankname validieren
                if (string.IsNullOrWhiteSpace(_importer.GvGesuchDTO.BaZahlungswegDTO.BankName))
                {
                    inputNotValid.Add(KissMsg.GetMLMessage(
                          CLASS_NAME,
                          "BankName",
                          "Bank Name"));
                }
                // Bankkonto Nummer validieren, falls IBAN nicht angegeben
                if (string.IsNullOrWhiteSpace(_importer.GvGesuchDTO.BaZahlungswegDTO.BankkontoNr) && string.IsNullOrWhiteSpace(_importer.GvGesuchDTO.BaZahlungswegDTO.BankIban))
                {
                    inputNotValid.Add(KissMsg.GetMLMessage(
                          CLASS_NAME,
                          "BankKontoNr",
                          "Bankkonto-Nr."));
                }
                // Clearing Nummer validieren
                if (string.IsNullOrWhiteSpace(_importer.GvGesuchDTO.BaZahlungswegDTO.BankClearing))
                {
                    inputNotValid.Add(KissMsg.GetMLMessage(
                          CLASS_NAME,
                          "BankClearingNr",
                          "Clearing-Nr."));
                }

                // PostCheck-Konto auf leer setzen, da wir diese Info in der Bankstammdatenverwaltung gespeichert haben!
                _importer.GvGesuchDTO.BaZahlungswegDTO.PostkontoNr = null;
            }
            // Sind Validierungsnachrichten vorhanden, werden diese dem Benutzer angezeigt
            if (inputNotValid.Any())
            {
                KissMsg.ShowInfo(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "ExcelUngueltigeGesuchsvorlageDaten",
                        "Folgende Felder sind ungültig und müssen korrigiert resp. ausgefüllt werden: {0}",
                           Environment.NewLine + string.Join(Environment.NewLine, inputNotValid.ToArray())));
                return false;
            }
            return true;
        }

        #endregion

        #endregion
    }
}