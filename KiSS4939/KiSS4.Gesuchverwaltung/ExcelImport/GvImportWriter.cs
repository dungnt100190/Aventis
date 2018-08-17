using System;
using Kiss.Interfaces.Database;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gesuchverwaltung.ExcelImport.DTO;

namespace KiSS4.Gesuchverwaltung.ExcelImport
{
    public class GvImportWriter
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string SELECT_BA_ADRESSE = @"
            SELECT TOP 1
              BaAdresseID,
              BaPersonID,
              BaLandID,
              DatumVon,
              DatumBis,
              AdresseCode,
              Zusatz,
              Strasse,
              HausNr,
              PLZ,
              Ort,
              OrtschaftCode,
              Kanton,
              Bezirk,
              VerID,
              Creator,
              Created,
              Modifier,
              Modified,
              BaAdresseTS
            FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
            WHERE BaPersonID = {0}
                AND GETDATE() BETWEEN ISNULL(DatumVon, '17530101') AND ISNULL(DatumBis, '99991231')
            ORDER BY ISNULL(DatumVon, '17530101') DESC;";

        private const string SELECT_BA_PERSON = @"
            SELECT
              BaPersonID,
              Name,
              Vorname,
              Geburtsdatum,
              GeschlechtCode,
              Versichertennummer,
              RentenstufeCode,
              HilfslosenEntschaedigungCode,
              IVGrad,
              IntensivPflegeZuschlagCode,
              IVTaggeld,
              BeruflicheMassnahmeIV,
              MedizinischeMassnahmeIV,
              IVHilfsmittel,
              ErgaenzungsLeistungen,
              BVGRente,
              UVGRente,
              ALK,
              Sozialhilfe,
              KTG,
              UVGTaggeld,
              WittwenWittwerWaisenRente,
              ZivilstandCode,
              InCHSeitGeburt,
              AusbildungCode,
              NationalitaetCode,
              ErwerbssituationCode,
              AuslaenderStatusCode,
              InCHSeit,
              HauptBehinderungsartCode,
              Behinderungsart2Code,
              VormundMassnahmenCode,
              AndereSVLeistungen,
              Creator,
              Created,
              Modifier,
              Modified,
              BaPersonTS
            FROM dbo.BaPerson WITH(READUNCOMMITTED)
            WHERE BaPersonID = {0};";

        private const string SELECT_BA_PERSON_RELATION = @"
            SELECT
              BaPerson_RelationID,
              BaRelationID,
              BaPersonID_1,
              BaPersonID_2,
              BaPerson_RelationTS
            FROM dbo.BaPerson_Relation WITH(READUNCOMMITTED)
            WHERE (BaPersonID_1 = {0} AND BaPersonID_2 = {1})
                OR (BaPersonID_2 = {0} AND BaPersonID_1 = {1});";

        private const string SELECT_FA_LEISTUNG = @"
            SELECT TOP 0
              FaLeistungID,
              FaFallID,
              BaPersonID,
              UserID,
              ModulID,
              DatumVon,
              Creator,
              Created,
              Modifier,
              Modified
            FROM dbo.FaLeistung WITH(READUNCOMMITTED);";

        private const string SELECT_GV_ABKLAERENDE_STELLE = @"
            SELECT TOP 0
              GvAbklaerendeStelleID,
              GvGesuchID,
              BaZahlungswegID,
              BeantragendeStelle,
              Kontaktperson,
              Strasse,
              HausNr,
              Zusatz,
              Postfach,
              PostfachOhneNr,
              Region,
              PLZ,
              Ort,
              Kanton,
              Telefon,
              Email,
              Zahlungsinstruktion,
              Creator,
              Created,
              Modifier,
              Modified
            FROM dbo.GvAbklaerendeStelle WITH(READUNCOMMITTED);";

        private readonly GvGesuchDTO _gvGesuchDTO;
        private readonly SqlQuery _qryAbklaerendeStelle;
        private readonly SqlQuery _qryBaAdresse;
        private readonly SqlQuery _qryBaPerson;
        private readonly SqlQuery _qryBaPersonRelation;
        private readonly SqlQuery _qryFaLeistung;

        #endregion

        #endregion

        #region Constructors

        public GvImportWriter(GvGesuchDTO dto)
        {
            _gvGesuchDTO = dto;

            // Init queries
            _qryBaPerson = new SqlQuery
            {
                SelectStatement = SELECT_BA_PERSON,
                CanInsert = true,
                CanUpdate = true,
                TableName = DBO.BaPerson.DBOName
            };

            _qryBaPersonRelation = new SqlQuery
            {
                SelectStatement = SELECT_BA_PERSON_RELATION,
                CanInsert = true,
                CanUpdate = true,
                CanDelete = true,
                TableName = DBO.BaPerson_Relation.DBOName
            };

            _qryBaAdresse = new SqlQuery
            {
                SelectStatement = SELECT_BA_ADRESSE,
                CanInsert = true,
                CanUpdate = true,
                TableName = DBO.BaAdresse.DBOName
            };

            _qryAbklaerendeStelle = new SqlQuery
            {
                SelectStatement = SELECT_GV_ABKLAERENDE_STELLE,
                CanInsert = true,
                CanUpdate = true,
                TableName = DBO.GvAbklaerendeStelle.DBOName
            };

            _qryFaLeistung = new SqlQuery
            {
                SelectStatement = SELECT_FA_LEISTUNG,
                CanInsert = true,
                TableName = DBO.FaLeistung.DBOName
            };
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Creates data in BaPerson, KbKostenstelle, FaLeistung.
        /// </summary>
        /// <param name="personDto"></param>
        public void CreateFall(BaPersonDTO personDto)
        {
            // Create BaPerson
            DBUtil.NewHistoryVersion();

            _qryBaPerson.Fill(0);
            _qryBaPerson.Insert();
            SetBaPersonValues(personDto);
            _qryBaPerson.RowModified = true;
            _qryBaPerson.Post();

            var baPersonId = Utils.ConvertToInt(_qryBaPerson[DBO.BaPerson.BaPersonID]);
            personDto.BaPersonId = baPersonId;

            // Create KbKostenstelle
            var userId = Session.User.UserID;
            DBUtil.ExecSQL("EXEC dbo.spKbKostenstelleAnlegen {0}, {1};", baPersonId, userId);

            // Create FaLeistung
            _qryFaLeistung.Fill(0);
            _qryFaLeistung.Insert();
            _qryFaLeistung[DBO.FaLeistung.BaPersonID] = baPersonId;
            _qryFaLeistung[DBO.FaLeistung.FaFallID] = baPersonId;
            _qryFaLeistung[DBO.FaLeistung.DatumVon] = DateTime.Today;
            _qryFaLeistung[DBO.FaLeistung.UserID] = userId;
            _qryFaLeistung[DBO.FaLeistung.ModulID] = 2;
            _qryFaLeistung.RowModified = true;
            _qryFaLeistung.Post();
        }

        public void WriteToDatabase()
        {
            int? baZahlungswegId = null;
            if (_gvGesuchDTO.BaZahlungswegDTO != null)
            {
                baZahlungswegId = InsertBaZahlungsweg();
            }

            InsertGvAntragPosition();
            InsertGvAbklaerendeStelle(baZahlungswegId);
            InsertUpdateBaPerson();
        }

        #endregion

        #region Private Static Methods

        private static void SetValueIfNotEmpty(IDataSource qry, string column, object value)
        {
            if (!DBUtil.IsEmpty(value) && Utils.ConvertToInt(value) >= 0)
            {
                qry[column] = value;
            }
        }

        #endregion

        #region Private Methods

        private void InsertBaAdresse(BaPersonDTO personDto, DateTime datumVon)
        {
            var adresseDto = personDto.BaAdresseDTO;

            if (adresseDto == null)
            {
                return;
            }

            _qryBaAdresse.Insert();
            _qryBaAdresse[DBO.BaAdresse.BaPersonID] = personDto.BaPersonId;
            _qryBaAdresse[DBO.BaAdresse.AdresseCode] = 1; // Wohnsitz
            _qryBaAdresse[DBO.BaAdresse.BaLandID] = adresseDto.BaLandId;
            _qryBaAdresse[DBO.BaAdresse.DatumVon] = datumVon;
            _qryBaAdresse[DBO.BaAdresse.Zusatz] = adresseDto.Zusatz;
            _qryBaAdresse[DBO.BaAdresse.Strasse] = adresseDto.Strasse;
            _qryBaAdresse[DBO.BaAdresse.HausNr] = adresseDto.HausNr;
            _qryBaAdresse[DBO.BaAdresse.PLZ] = adresseDto.Plz;
            _qryBaAdresse[DBO.BaAdresse.Ort] = adresseDto.Ort;
            _qryBaAdresse[DBO.BaAdresse.OrtschaftCode] = adresseDto.OrtschaftCode;
            _qryBaAdresse[DBO.BaAdresse.Kanton] = adresseDto.Kanton;
            _qryBaAdresse[DBO.BaAdresse.Bezirk] = adresseDto.Bezirk;
            _qryBaAdresse.Post();
        }

        private int? InsertBaZahlungsweg()
        {
            var dto = _gvGesuchDTO.BaZahlungswegDTO;

            var bankId =
                DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT BaBankID
                    FROM dbo.BaBank WITH (READUNCOMMITTED)
                    WHERE ClearingNr = {0}
                      AND FilialeNr = 0; -- Hauptsitz",
                    dto.BankClearing);

            var qryBaZahlungsweg =
                DBUtil.OpenSQL(@"
                    SELECT TOP 0 *
                    FROM dbo.BaZahlungsweg WITH(READUNCOMMITTED);");

            // TODO check if BaZahlungsweg already exists for this person with this BaBankID

            qryBaZahlungsweg.Insert(DBO.BaZahlungsweg.DBOName);
            qryBaZahlungsweg[DBO.BaZahlungsweg.BaPersonID] = _gvGesuchDTO.BaPersonIdKlient;
            qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID] = bankId;
            qryBaZahlungsweg[DBO.BaZahlungsweg.IBANNummer] = dto.BankIban;
            qryBaZahlungsweg[DBO.BaZahlungsweg.BankKontoNummer] = dto.BankkontoNr;
            qryBaZahlungsweg[DBO.BaZahlungsweg.AdresseName] = dto.InhaberName;
            qryBaZahlungsweg[DBO.BaZahlungsweg.AdresseOrt] = dto.Ort;
            qryBaZahlungsweg[DBO.BaZahlungsweg.AdressePLZ] = dto.Plz;
            qryBaZahlungsweg[DBO.BaZahlungsweg.PostKontoNummer] = dto.PostkontoNr;
            qryBaZahlungsweg[DBO.BaZahlungsweg.ReferenzNummer] = dto.ReferenzNr;
            qryBaZahlungsweg[DBO.BaZahlungsweg.AdresseStrasse] = dto.Strasse;
            qryBaZahlungsweg[DBO.BaZahlungsweg.AdresseHausNr] = dto.HausNr;
            qryBaZahlungsweg[DBO.BaZahlungsweg.AdresseName2] = dto.Zusatz;
            qryBaZahlungsweg[DBO.BaZahlungsweg.DatumVon] = DateTime.Today;
            qryBaZahlungsweg[DBO.BaZahlungsweg.EinzahlungsscheinCode] = dto.EinzahlungsscheinCode;
            qryBaZahlungsweg.Post();

            return qryBaZahlungsweg[DBO.BaZahlungsweg.BaZahlungswegID] as int?;
        }

        private void InsertGvAbklaerendeStelle(int? baZahlungswegId)
        {
            var dto = _gvGesuchDTO.GvAbklaerendeStelleDTO;

            _qryAbklaerendeStelle.Fill();
            _qryAbklaerendeStelle.Insert();
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.GvGesuchID] = _gvGesuchDTO.GvGesuchId;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.BaZahlungswegID] = baZahlungswegId;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.BeantragendeStelle] = dto.BeantragendeStelle;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.Kontaktperson] = dto.Kontaktperson;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.Strasse] = dto.Strasse;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.HausNr] = dto.HausNr;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.Zusatz] = dto.Zusatz;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.Postfach] = dto.Postfach;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.PostfachOhneNr] = dto.PostfachOhneNr;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.PLZ] = dto.Plz;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.Ort] = dto.Ort;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.Kanton] = dto.Kanton;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.Telefon] = dto.Telefon;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.Email] = dto.Email;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.Zahlungsinstruktion] = dto.Zahlungsinstruktionen;
            _qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.Region] = dto.RegionBezirk;
            _qryAbklaerendeStelle.Post();
        }

        private void InsertGvAntragPosition()
        {
            var sqlAntrag = string.Empty;

            foreach (var dto in _gvGesuchDTO.GvAntragPositionDTOList)
            {
                sqlAntrag +=
                    string.Format(@"
                        INSERT INTO dbo.GvAntragPosition (GvGesuchID, Bezeichnung, Betrag, GvAntragPositionTypCode, Creator, Modifier)
                        VALUES ({0}, {1}, {2}, {3}, {4}, {4});",
                        DBUtil.SqlLiteral(_gvGesuchDTO.GvGesuchId),
                        DBUtil.SqlLiteral(dto.Bezeichnung),
                        DBUtil.SqlLiteral(dto.Betrag),
                        DBUtil.SqlLiteral((int)dto.GvAntragPositionTyp),
                        DBUtil.SqlLiteral(DBUtil.GetDBRowCreatorModifier()));
            }

            if (!string.IsNullOrEmpty(sqlAntrag))
            {
                DBUtil.ExecSQLThrowingException(sqlAntrag);
            }
        }

        private void InsertOrUpdateBaPersonRelation(BaPersonDTO personDto)
        {
            if (!personDto.BaPersonId.HasValue)
            {
                return;
            }

            if (personDto.BaRelationId > 0)
            {
                _qryBaPersonRelation.Fill(personDto.BaPersonId, _gvGesuchDTO.BaPersonIdKlient);

                // Relation löschen wenn vorhanden
                if (!_qryBaPersonRelation.IsEmpty)
                {
                    _qryBaPersonRelation.DeleteQuestion = "";
                    _qryBaPersonRelation.Delete();
                    _qryBaPersonRelation.Post();
                }

                // Relation neu erstellen
                int baPersonId1;
                int baPersonId2;
                var baRelationId = personDto.BaRelationId;

                if (baRelationId < 100)
                {
                    baPersonId1 = personDto.BaPersonId.Value;
                    baPersonId2 = _gvGesuchDTO.BaPersonIdKlient;
                }
                else
                {
                    baPersonId1 = _gvGesuchDTO.BaPersonIdKlient;
                    baPersonId2 = personDto.BaPersonId.Value;
                    baRelationId -= 100;
                }

                _qryBaPersonRelation.Insert();
                _qryBaPersonRelation[DBO.BaPerson_Relation.BaRelationID] = baRelationId;
                _qryBaPersonRelation[DBO.BaPerson_Relation.BaPersonID_1] = baPersonId1;
                _qryBaPersonRelation[DBO.BaPerson_Relation.BaPersonID_2] = baPersonId2;
                _qryBaPersonRelation.Post();
            }
        }

        private void InsertUpdateBaPerson()
        {
            foreach (var personDto in _gvGesuchDTO.BaPersonDTOList)
            {
                // create history version
                DBUtil.NewHistoryVersion();

                _qryBaPerson.Fill(personDto.BaPersonId);

                if (!_qryBaPerson.IsEmpty)
                {
                    // update BaPerson
                    SetBaPersonValues(personDto);
                    _qryBaPerson.Post();

                    // update BaRelation
                    InsertOrUpdateBaPersonRelation(personDto);

                    // insert or update BaAdresse
                    UpdateBaAdresse(personDto);
                }
                else
                {
                    // insert BaPerson
                    _qryBaPerson.Insert();
                    SetBaPersonValues(personDto);
                    _qryBaPerson.RowModified = true;
                    _qryBaPerson.Post();

                    personDto.BaPersonId = Utils.ConvertToInt(_qryBaPerson[DBO.BaPerson.BaPersonID]);

                    // insert KbKostenstelle
                    DBUtil.ExecSQL(@"EXEC dbo.spKbKostenstelleAnlegen {0}, {1}", personDto.BaPersonId, Session.User.UserID);

                    // insert BaRelation
                    InsertOrUpdateBaPersonRelation(personDto);

                    // insert BaAdresse
                    InsertBaAdresse(personDto, DateTime.Today);
                }

                if (personDto.SozialversicherungDTO != null)
                {
                    UpdateSozialversicherung(personDto);
                }
            }
        }

        private bool IsAdresseIdentisch(BaAdresseDTO adresseDto)
        {
            return _qryBaAdresse[DBO.BaAdresse.PLZ].ToString() == adresseDto.Plz &&
                   _qryBaAdresse[DBO.BaAdresse.Ort].ToString() == adresseDto.Ort &&
                   _qryBaAdresse[DBO.BaAdresse.Strasse].ToString() == adresseDto.Strasse &&
                   _qryBaAdresse[DBO.BaAdresse.HausNr].ToString() == adresseDto.HausNr;
        }

        private void SetBaPersonValues(BaPersonDTO personDto)
        {
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.Name, personDto.Name);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.Vorname, personDto.Vorname);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.Geburtsdatum, personDto.Geburtsdatum);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.GeschlechtCode, personDto.GeschlechtCode);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.Versichertennummer, personDto.Versichertennummer);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.ZivilstandCode, personDto.ZivilstandCode);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.InCHSeitGeburt, personDto.InChSeitGeburt);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.InCHSeit, personDto.InChSeit);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.AusbildungCode, personDto.AusbildungCode);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.NationalitaetCode, personDto.NationalitaetCode);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.ErwerbssituationCode, personDto.ErwerbssituationCode);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.AuslaenderStatusCode, personDto.AuslaenderStatusCode);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.HauptBehinderungsartCode, personDto.HauptbehinderungsartCode);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.Behinderungsart2Code, personDto.Behinderungsart2Code);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.VormundMassnahmenCode, personDto.VormundMassnahmenCode);
        }

        private void UpdateBaAdresse(BaPersonDTO personDto)
        {
            var adresseDto = personDto.BaAdresseDTO;

            if (adresseDto != null)
            {
                _qryBaAdresse.Fill(personDto.BaPersonId);

                if (_qryBaAdresse.IsEmpty)
                {
                    InsertBaAdresse(personDto, DateTime.Today);
                }
                else if (!IsAdresseIdentisch(adresseDto))
                {
                    DateTime datumVonNeu;
                    var datumBis = _qryBaAdresse[DBO.BaAdresse.DatumBis] as DateTime?;

                    if (datumBis.HasValue)
                    {
                        datumVonNeu = datumBis.Value.AddDays(1);
                    }
                    else
                    {
                        datumVonNeu = DateTime.Today;
                        _qryBaAdresse[DBO.BaAdresse.DatumBis] = datumVonNeu.AddDays(-1);
                        _qryBaAdresse.Post();
                    }

                    InsertBaAdresse(personDto, datumVonNeu);
                }
            }
        }

        private void UpdateSozialversicherung(BaPersonDTO personDto)
        {
            var sozialversicherungDto = personDto.SozialversicherungDTO;
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.RentenstufeCode, sozialversicherungDto.RentenstufeCode);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.HilfslosenEntschaedigungCode, sozialversicherungDto.HilflosenentschaedigungCode);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.IVGrad, sozialversicherungDto.IvGrad);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.IntensivPflegeZuschlagCode, sozialversicherungDto.IntensivpflegezuschlagCode);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.IVTaggeld, sozialversicherungDto.IvTaggeld);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.BeruflicheMassnahmeIV, sozialversicherungDto.BeruflicheMassnahmeIv);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.MedizinischeMassnahmeIV, sozialversicherungDto.MedizinischeMassnahmeIv);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.IVHilfsmittel, sozialversicherungDto.IvHilfsmittel);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.ErgaenzungsLeistungen, sozialversicherungDto.Ergaenzungsleistungen);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.BVGRente, sozialversicherungDto.BvgRente);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.UVGRente, sozialversicherungDto.UvgRente);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.ALK, sozialversicherungDto.Arbeitslosenkasse);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.Sozialhilfe, sozialversicherungDto.Sozialhilfe);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.KTG, sozialversicherungDto.Krankentaggeld);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.UVGTaggeld, sozialversicherungDto.UvgTaggeld);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.WittwenWittwerWaisenrente, sozialversicherungDto.WittwenWittwerWaisenRente);
            SetValueIfNotEmpty(_qryBaPerson, DBO.BaPerson.AndereSVLeistungen, sozialversicherungDto.AndereSozialversicherungsleistungen);
            _qryBaPerson.Post();
        }

        #endregion

        #endregion
    }
}