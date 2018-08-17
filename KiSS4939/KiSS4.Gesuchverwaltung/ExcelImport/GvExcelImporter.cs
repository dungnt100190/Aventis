using System;

using Kiss.Infrastructure.Constant;

using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gesuchverwaltung.ExcelImport.DTO;
using KiSS4.Gui;

namespace KiSS4.Gesuchverwaltung.ExcelImport
{
    public class GvExcelImporter : ExcelImporter
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly double _version;

        private const string CLASS_NAME = "ExcelImporter";

        #endregion

        #region Private Fields

        private GvGesuchDTO _gvGesuchDTO;

        #endregion

        #endregion

        #region Constructors

        public GvExcelImporter(string fileName, double version)
            : base(fileName)
        {
            _version = version;
        }

        #endregion

        #region Properties

        public GvGesuchDTO GvGesuchDTO
        {
            get { return _gvGesuchDTO; }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override bool ProcessDocument()
        {
            try
            {
                _gvGesuchDTO = new GvGesuchDTO();

                ValidateExcel();
                ImportKlient();
                ImportAntrag();
                ImportAbklaerendeStelle();
                ImportBegruendung();
                ImportZahlungsweg();
                ImportPersonen();

                return true;
            }
            catch (KissInfoException ex)
            {
                KissMsg.ShowInfo(ex.Message);
                return false;
            }
            catch (KissCancelException)
            {
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(
                    CLASS_NAME,
                    "Error_OpenDocument",
                    "Fehler beim Lesen des Dokuments. (Das Dokument darf in Excel nicht geöffnet sein!)",
                    ex);
                return false;
            }
        }

        #endregion

        #region Private Methods

        private void ImportAbklaerendeStelle()
        {
            bool postfachOhneNr;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.POSTFACH_OHNENR), out postfachOhneNr);

            var dto = new GvAbklaerendeStelleDTO
            {
                BeantragendeStelle = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.BEANTRAGENDE_STELLE),
                Kontaktperson = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.KONTAKTPERSON),
                Strasse = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.STRASSE),
                HausNr = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.HAUSNR),
                Zusatz = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.ZUSATZ),
                Postfach = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.POSTFACH),
                PostfachOhneNr = postfachOhneNr,
                Plz = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.PLZ),
                Ort = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.ORT),
                Kanton = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.KANTON),
                RegionBezirk = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.BEZIRK),
                Telefon = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.TELEFON),
                Email = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.EMAIL),
                Zahlungsinstruktionen = _excelDocument.GetValueByNamedRange(NamedRange.AbklaerendeStelle.ZAHLUNGSINSTRUKTIONEN),
            };

            _gvGesuchDTO.GvAbklaerendeStelleDTO = dto;
        }

        private void ImportAntrag()
        {
            // Kosten
            ImportAntragPosition(
                LOVsGenerated.GvAntragPositionTyp.Kosten,
                NamedRange.AntragKosten.ZEILE1_BEZEICHNUNG,
                NamedRange.AntragKosten.ZEILE1_BETRAG);

            ImportAntragPosition(
                LOVsGenerated.GvAntragPositionTyp.Kosten,
                NamedRange.AntragKosten.ZEILE2_BEZEICHNUNG,
                NamedRange.AntragKosten.ZEILE2_BETRAG);

            ImportAntragPosition(
                LOVsGenerated.GvAntragPositionTyp.Kosten,
                NamedRange.AntragKosten.ZEILE3_BEZEICHNUNG,
                NamedRange.AntragKosten.ZEILE3_BETRAG);

            ImportAntragPosition(
                LOVsGenerated.GvAntragPositionTyp.Kosten,
                NamedRange.AntragKosten.ZEILE4_BEZEICHNUNG,
                NamedRange.AntragKosten.ZEILE4_BETRAG);

            ImportAntragPosition(
                LOVsGenerated.GvAntragPositionTyp.Kosten,
                NamedRange.AntragKosten.ZEILE5_BEZEICHNUNG,
                NamedRange.AntragKosten.ZEILE5_BETRAG);

            // Finanzierung
            _gvGesuchDTO.Gesuchsgrund = _excelDocument.GetValueByNamedRange(NamedRange.AntragFinanzierung.GESUCHSGRUND);

            ImportAntragPosition(
                LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag,
                null,
                NamedRange.AntragFinanzierung.FLB_BETRAG,
                true);

            ImportAntragPosition(
                LOVsGenerated.GvAntragPositionTyp.Finanzierung,
                NamedRange.AntragFinanzierung.ZEILE1_BEZEICHNUNG,
                NamedRange.AntragFinanzierung.ZEILE1_BETRAG);

            ImportAntragPosition(
                LOVsGenerated.GvAntragPositionTyp.Finanzierung,
                NamedRange.AntragFinanzierung.ZEILE2_BEZEICHNUNG,
                NamedRange.AntragFinanzierung.ZEILE2_BETRAG);

            ImportAntragPosition(
                LOVsGenerated.GvAntragPositionTyp.Finanzierung,
                NamedRange.AntragFinanzierung.ZEILE3_BEZEICHNUNG,
                NamedRange.AntragFinanzierung.ZEILE3_BETRAG);

            ImportAntragPosition(
                LOVsGenerated.GvAntragPositionTyp.Finanzierung,
                NamedRange.AntragFinanzierung.ZEILE4_BEZEICHNUNG,
                NamedRange.AntragFinanzierung.ZEILE4_BETRAG);
        }

        private void ImportAntragPosition(LOVsGenerated.GvAntragPositionTyp typ, string rangeBezeichnung, string rangeBetrag, bool beantragterBetrag = false)
        {
            decimal betrag;
            decimal.TryParse(_excelDocument.GetValueByNamedRange(rangeBetrag), out betrag);

            string bezeichnung = null;

            if (rangeBezeichnung != null)
            {
                bezeichnung = _excelDocument.GetValueByNamedRange(rangeBezeichnung);
            }
            else if (beantragterBetrag)
            {
                bezeichnung = "beantragter Betrag";
            }

            // do not add if there is no data
            if (!beantragterBetrag && (betrag == 0 || string.IsNullOrWhiteSpace(bezeichnung)))
            {
                return;
            }

            var dto = new GvAntragPositionDTO
            {
                Bezeichnung = bezeichnung,
                Betrag = betrag,
                GvAntragPositionTyp = typ
            };

            _gvGesuchDTO.GvAntragPositionDTOList.Add(dto);
        }

        private void ImportBegruendung()
        {
            var plainText = _excelDocument.GetValueByNamedRange(NamedRange.Begruendung.BEGRUENDUNG);

            // convert to RTF
            using (var rtfEdit = new KissRTFEdit { Text = plainText })
            {
                _gvGesuchDTO.Begruendung = Common.Utils.ConvertToString(rtfEdit.EditValue, null);
            }
        }

        private void ImportKlient()
        {
            // Import Person
            var personDto = ImportPerson(NamedRange.Klient.NAME, NamedRange.Klient.VORNAME, NamedRange.Klient.GEBURTSDATUM, NamedRange.Klient.GESCHLECHT);

            if (personDto == null)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(CLASS_NAME, "Kein_Klient", "Daten zur Person sind nicht vollständig ausgefüllt!"));
            }

            // Parse non-nullables
            var versNr = _excelDocument.GetValueByNamedRange(NamedRange.Klient.VERSNR);
            personDto.Versichertennummer = versNr;

            bool inChSeitGeburt;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Klient.IN_CH_SEIT_GEBURT), out inChSeitGeburt);
            personDto.InChSeitGeburt = inChSeitGeburt;

            // Parse nullables
            int zivilstandCode;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Klient.ZIVILSTAND), out zivilstandCode))
            {
                personDto.ZivilstandCode = zivilstandCode;
            }

            int ausbildungCode;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Klient.AUSBILDUNG), out ausbildungCode))
            {
                personDto.AusbildungCode = ausbildungCode;
            }

            int nationalitaetCode;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Klient.NATIONALITAET), out nationalitaetCode))
            {
                personDto.NationalitaetCode = nationalitaetCode;
            }

            int erwerbssituationCode;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Klient.ERWERBSSITUATION), out erwerbssituationCode))
            {
                personDto.ErwerbssituationCode = erwerbssituationCode;
            }

            int auslaenderStatusCode;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Klient.AUSLAENDER_STATUS), out auslaenderStatusCode))
            {
                personDto.AuslaenderStatusCode = auslaenderStatusCode;
            }

            DateTime inChSeit;
            if (DateTime.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Klient.IN_CH_SEIT), out inChSeit))
            {
                personDto.InChSeit = inChSeit;
            }

            int hauptbehinderungsartCode;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Klient.HAUPTBEHINDERUNGSART), out hauptbehinderungsartCode))
            {
                personDto.HauptbehinderungsartCode = hauptbehinderungsartCode;
            }

            int behinderungsart2Code;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Klient.BEHINDERUNGSART2), out behinderungsart2Code))
            {
                personDto.Behinderungsart2Code = behinderungsart2Code;
            }

            int vormundMassnahmenCode;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Klient.VORMUND_MASSNAHME), out vormundMassnahmenCode))
            {
                personDto.VormundMassnahmenCode = vormundMassnahmenCode;
            }

            // Adresse
            var strasse = _excelDocument.GetValueByNamedRange(NamedRange.Klient.STRASSE);
            var hausNr = _excelDocument.GetValueByNamedRange(NamedRange.Klient.HAUSNR);
            var zusatz = _excelDocument.GetValueByNamedRange(NamedRange.Klient.ZUSATZ);
            var plz = _excelDocument.GetValueByNamedRange(NamedRange.Klient.PLZ);
            var ort = _excelDocument.GetValueByNamedRange(NamedRange.Klient.ORT);

            var adresseDto = new BaAdresseDTO
            {
                Strasse = strasse,
                HausNr = hausNr,
                Zusatz = zusatz,
                Plz = plz,
                Ort = ort,
                BaLandId = Session.BaLandCodeSchweiz,
            };
            personDto.BaAdresseDTO = adresseDto;

            // Sozialversicherung
            ImportSozialversicherung(personDto);
        }

        private BaPersonDTO ImportPerson(string nameRange, string vornameRange, string geburtsdatumRange, string geschlechtRange, string relationRange = null)
        {
            int baRelationId = -1;
            if (relationRange != null)
            {
                int.TryParse(_excelDocument.GetValueByNamedRange(relationRange), out baRelationId);
            }

            int geschlechtCode;
            int.TryParse(_excelDocument.GetValueByNamedRange(geschlechtRange), out geschlechtCode);

            var name = _excelDocument.GetValueByNamedRange(nameRange);
            var vorname = _excelDocument.GetValueByNamedRange(vornameRange);

            // do not add if there is not enough data
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(vorname))
            {
                return null;
            }

            var dto = new BaPersonDTO
            {
                Name = name,
                Vorname = vorname,
                GeschlechtCode = geschlechtCode,
                BaRelationId = baRelationId
            };

            DateTime geburtsdatum;
            if (DateTime.TryParse(_excelDocument.GetValueByNamedRange(geburtsdatumRange), out geburtsdatum))
            {
                dto.Geburtsdatum = geburtsdatum;
            }

            _gvGesuchDTO.BaPersonDTOList.Add(dto);

            return dto;
        }

        private void ImportPersonen()
        {
            ImportPerson(
                NamedRange.Personen.PERSON1_NAME,
                NamedRange.Personen.PERSON1_VORNAME,
                NamedRange.Personen.PERSON1_GEBURTSDATUM,
                NamedRange.Personen.PERSON1_GESCHLECHT,
                NamedRange.Personen.PERSON1_RELATION);

            ImportPerson(
                NamedRange.Personen.PERSON2_NAME,
                NamedRange.Personen.PERSON2_VORNAME,
                NamedRange.Personen.PERSON2_GEBURTSDATUM,
                NamedRange.Personen.PERSON2_GESCHLECHT,
                NamedRange.Personen.PERSON2_RELATION);

            ImportPerson(
                NamedRange.Personen.PERSON3_NAME,
                NamedRange.Personen.PERSON3_VORNAME,
                NamedRange.Personen.PERSON3_GEBURTSDATUM,
                NamedRange.Personen.PERSON3_GESCHLECHT,
                NamedRange.Personen.PERSON3_RELATION);

            ImportPerson(
                NamedRange.Personen.PERSON4_NAME,
                NamedRange.Personen.PERSON4_VORNAME,
                NamedRange.Personen.PERSON4_GEBURTSDATUM,
                NamedRange.Personen.PERSON4_GESCHLECHT,
                NamedRange.Personen.PERSON4_RELATION);

            ImportPerson(
                NamedRange.Personen.PERSON5_NAME,
                NamedRange.Personen.PERSON5_VORNAME,
                NamedRange.Personen.PERSON5_GEBURTSDATUM,
                NamedRange.Personen.PERSON5_GESCHLECHT,
                NamedRange.Personen.PERSON5_RELATION);

            ImportPerson(
                NamedRange.Personen.PERSON6_NAME,
                NamedRange.Personen.PERSON6_VORNAME,
                NamedRange.Personen.PERSON6_GEBURTSDATUM,
                NamedRange.Personen.PERSON6_GESCHLECHT,
                NamedRange.Personen.PERSON6_RELATION);

            ImportPerson(
                NamedRange.Personen.PERSON7_NAME,
                NamedRange.Personen.PERSON7_VORNAME,
                NamedRange.Personen.PERSON7_GEBURTSDATUM,
                NamedRange.Personen.PERSON7_GESCHLECHT,
                NamedRange.Personen.PERSON7_RELATION);

            ImportPerson(
                NamedRange.Personen.PERSON8_NAME,
                NamedRange.Personen.PERSON8_VORNAME,
                NamedRange.Personen.PERSON8_GEBURTSDATUM,
                NamedRange.Personen.PERSON8_GESCHLECHT,
                NamedRange.Personen.PERSON8_RELATION);

            ImportPerson(
                NamedRange.Personen.PERSON9_NAME,
                NamedRange.Personen.PERSON9_VORNAME,
                NamedRange.Personen.PERSON9_GEBURTSDATUM,
                NamedRange.Personen.PERSON9_GESCHLECHT,
                NamedRange.Personen.PERSON9_RELATION);

            ImportPerson(
                NamedRange.Personen.PERSON10_NAME,
                NamedRange.Personen.PERSON10_VORNAME,
                NamedRange.Personen.PERSON10_GEBURTSDATUM,
                NamedRange.Personen.PERSON10_GESCHLECHT,
                NamedRange.Personen.PERSON10_RELATION);
        }

        private void ImportSozialversicherung(BaPersonDTO personDto)
        {
            var dto = new BaPersonSozialversicherungDTO();

            // Invalidenversicherung
            int rentenstufeCode;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.RENTENSTUFE), out rentenstufeCode))
            {
                dto.RentenstufeCode = rentenstufeCode;
            }

            int ivGrad;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.IV_GRAD), out ivGrad))
            {
                dto.IvGrad = ivGrad;
            }

            int hilflosenentschaedigungCode;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.HILFLOSENENTSCHAEDIGUNG), out hilflosenentschaedigungCode))
            {
                dto.HilflosenentschaedigungCode = hilflosenentschaedigungCode;
            }

            int intensivpflegezuschlagCode;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.INTENSIVPFLEGEZUSCHLAG), out intensivpflegezuschlagCode))
            {
                dto.IntensivpflegezuschlagCode = intensivpflegezuschlagCode;
            }

            bool ivTaggeld;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.IV_TAGGELD), out ivTaggeld);
            dto.IvTaggeld = ivTaggeld;

            bool beruflicheMassnahmeIv;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.BERUFLICHE_MASSNAHMEN_IV), out beruflicheMassnahmeIv);
            dto.BeruflicheMassnahmeIv = beruflicheMassnahmeIv;

            bool medizinischeMassnahmeIv;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.MEDIZINISCHE_MASSNAHMEN_IV), out medizinischeMassnahmeIv);
            dto.MedizinischeMassnahmeIv = medizinischeMassnahmeIv;

            bool ivHilfsmittel;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.IV_HILFSMITTEL), out ivHilfsmittel);
            dto.IvHilfsmittel = ivHilfsmittel;

            bool ergaenzungsleistungen;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.ERGAENZUNGSLEISTUNGEN), out ergaenzungsleistungen);
            dto.Ergaenzungsleistungen = ergaenzungsleistungen;

            // weitere Versicherungsleistungen
            bool bvgRente;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.BVG_RENTE), out bvgRente);
            dto.BvgRente = bvgRente;

            bool uvgRente;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.UVG_RENTE), out uvgRente);
            dto.UvgRente = uvgRente;

            bool arbeitslosenkasse;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.ARBEITSLOSENKASSE), out arbeitslosenkasse);
            dto.Arbeitslosenkasse = arbeitslosenkasse;

            bool sozialhilfe;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.SOZIALHILFE), out sozialhilfe);
            dto.Sozialhilfe = sozialhilfe;

            bool krankentaggeld;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.KRANKENTAGGELD), out krankentaggeld);
            dto.Krankentaggeld = krankentaggeld;

            bool uvgTaggeld;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.UVG_TAGGELD), out uvgTaggeld);
            dto.UvgTaggeld = uvgTaggeld;

            bool wittwenWittwerWaisenRente;
            bool.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.WITTWEN_WITTWER_WAISEN_RENTE), out wittwenWittwerWaisenRente);
            dto.WittwenWittwerWaisenRente = wittwenWittwerWaisenRente;

            // Andere Sozialversicherungsleistungen
            dto.AndereSozialversicherungsleistungen = _excelDocument.GetValueByNamedRange(NamedRange.Sozialversicherung.ANDERE_SOZIALVERSICHERUNGSLEISTUNGEN);

            // an der Person anhängen
            personDto.SozialversicherungDTO = dto;
        }

        private void ImportZahlungsweg()
        {
            var dto = new BaZahlungswegDTO
            {
                BankName = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.BANK_NAME),
                BankkontoNr = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.BANKKONTONR),
                BankClearing = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.BANK_CLEARING),
                BankIban = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.BANK_IBAN),
                InhaberName = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.NAME_VORNAME_KONTO_INHABER),
                Zusatz = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.ZUSATZ),
                Strasse = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.STRASSE),
                HausNr = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.HAUSNR),
                Plz = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.PLZ),
                Ort = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.ORT),
                PostkontoNr = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.POSTKONTONR),
                ReferenzNr = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.REFERENZNR),
                Zahlungsinstruktionen = _excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.ZAHLUNGSINSTRUKTIONEN),
            };

            int einzahlungsscheinCode;
            if (int.TryParse(_excelDocument.GetValueByNamedRange(NamedRange.Zahlweg.ZAHLUNGSWEGTYP), out einzahlungsscheinCode))
            {
                dto.EinzahlungsscheinCode = einzahlungsscheinCode;
            }

            if (string.IsNullOrEmpty(dto.BankName) &&
                string.IsNullOrEmpty(dto.BankkontoNr) &&
                string.IsNullOrEmpty(dto.BankIban) &&
                string.IsNullOrEmpty(dto.PostkontoNr) &&
                string.IsNullOrEmpty(dto.InhaberName) &&
                string.IsNullOrEmpty(dto.BankClearing))
            {
                //falls keine Zahlungsinformationen im Excel hinterlegt sind, setze dto = null
                dto = null;
            }

            _gvGesuchDTO.BaZahlungswegDTO = dto;
        }

        private void ValidateExcel()
        {
            var excelVersion = _excelDocument.GetValueByNamedRange(NamedRange.Version.NUMMER);
            double excelVersionDouble;
            if (excelVersion == null
                || !Double.TryParse(excelVersion, out excelVersionDouble))
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "VersionNummerNichtVorhanden",
                        "Die Datei ist keine gültige Excel-Vorlage"));
            }

            if (excelVersionDouble != _version)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "VersionNummerUngueltig",
                        "Die Version der Excel-Vorlage ist ungültig. (ist:{0}, soll:{1})",
                        excelVersion,
                        _version));
            }
        }

        #endregion

        #endregion
    }
}