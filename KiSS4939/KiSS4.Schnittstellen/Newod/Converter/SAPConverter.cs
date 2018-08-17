using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using KiSS4.Schnittstellen.Newod.DTO;

using KiSS.Newod;

namespace KiSS4.Schnittstellen.Newod.Converter
{
    public static class SAPConverter
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        // SAP constant values
        private const string AS = "ZB13"; // Nation <> Schweiz und mind. 1 aktive Sozialhilfe

        private const string CHS = "ZB14"; // Nation = Schweiz und mind. 1 aktive Sozialhilfe
        private const string CHV = "ZB15"; // nur Aktive Vormundschaftliche Massnahme
        private const string JA = "ZBE00138";
        private const string KISS = "ZB16"; // KiSS relevant
        private const string NEIN = "ZBE00139";

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        public static Markflags ConvertFromSap(string personId, DT_CODE[] codes)
        {
            Markflags mark = new Markflags();
            foreach (DT_CODE code in codes)
            {
                if (code.PARTNER.Trim() != personId) continue;
                switch (code.CRA_CODE_TYPE)
                {
                    case AS:
                        mark.AS = ConvertCraCode(code.CRA_CODE);
                        break;

                    case CHS:
                        mark.CHS = ConvertCraCode(code.CRA_CODE);
                        break;

                    case CHV:
                        mark.CHV = ConvertCraCode(code.CRA_CODE);
                        break;

                    case KISS:
                        mark.KISS = ConvertCraCode(code.CRA_CODE);
                        break;
                }
            }

            return mark;
        }

        public static PersonAdressDaten ConvertFromSap(DT_eChRootPersonRootReportedPersonHasMainResidenceMainResidence mainresidence, int newodId)
        {
            DT_eChSwissAddressInformationType addr = mainresidence.dwellingAddress.address;
            PersonAdressDaten adressDaten = new PersonAdressDaten
            {
                Strasse = addr.street,
                HausNr = addr.houseNumber,
                Plz = addr.swissZipCode.ToString(CultureInfo.InvariantCulture),
                Ort = addr.town,
                Kanton = addr.locality,
                Land = addr.country,
            };
            // Felder in alphabetischer Reihenfolge
            var lovConverter = new LovConverter(newodId);
            adressDaten.LandId = lovConverter.MapIsoCountryCodeToBaLandId(adressDaten.Land, "Land");
            // DatumVon wird im Feld addressLine2 gesendet!
            try
            {
                int jahr = Int32.Parse(addr.addressLine2.Substring(0, 4));
                int monat = Int32.Parse(addr.addressLine2.Substring(4, 2));
                int tag = Int32.Parse(addr.addressLine2.Substring(6, 2));
                adressDaten.DatumVon = new DateTime(jahr, monat, tag);
            }
            catch
            {
                adressDaten.DatumVon = null;
            }

            return adressDaten;
        }

        public static PersonBasisDaten ConvertFromSap(DT_eChRootPersonRootReportedPerson reportedPerson)
        {
            PersonBasisDaten basisDaten = new PersonBasisDaten();
            DT_eChRootPersonRootReportedPersonPerson person = reportedPerson.person;
            basisDaten.ID = person.personIdentification.localPersonId.personId;

            // Felder in alphabetischer Reihenfolge
            if (person.personIdentification.OtherPersonId != null)
            {
                foreach (DT_eChPersonIdentificationTypeOtherPersonId o in person.personIdentification.OtherPersonId)
                {
                    switch (o.personIdCategory)
                    {
                        case "CH.AHV":
                            // zwischenschritt über ahveditcontrol um die punkte zu setzen
                            Gui.KissAHVNrEdit ahvnr = new Gui.KissAHVNrEdit { EditValue = o.personId };
                            basisDaten.AHVNummer = ahvnr.Text;
                            break;

                        case "CH.ZEMIS":
                            basisDaten.ZemisNummer = o.personId;
                            break;
                    }
                }
            }

            var lovConverter = new LovConverter(Convert.ToInt32(basisDaten.ID));
            basisDaten.AnredeText = lovConverter.MapNewodToLovText("Anrede", person.coreData.mrMrs);
            if (reportedPerson.anyPerson.foreigner != null)
            {
                DT_eChRootPersonRootReportedPersonAnyPersonForeigner foreigner = reportedPerson.anyPerson.foreigner;
                basisDaten.AuslaenderStatusCode = lovConverter.MapNewodToLovCode("aufenthaltsstatus", foreigner.residencePermit);
                if (foreigner.residencePermitFromSpecified &&
                    !foreigner.residencePermitFrom.ToString(CultureInfo.InvariantCulture).Contains("30.11.0002") &&
                    !foreigner.residencePermitFrom.Equals(DateTime.MinValue))
                {
                    //nicht importieren da NEWOD nicht die korrekten Daten liefert
                    //basisDaten.ErteilungVA = foreigner.residencePermitFrom;
                }

                if (foreigner.residencePermitTillSpecified &&
                    !foreigner.residencePermitTill.ToString(CultureInfo.InvariantCulture).Contains("30.11.0002") &&
                    !foreigner.residencePermitTill.Equals(DateTime.MinValue))
                {
                    basisDaten.AuslaenderStatusGueltigBis = foreigner.residencePermitTill;
                }
            }

            DT_eChPersonIdentificationTypeDateOfBirth gb = person.personIdentification.dateOfBirth;
            if (gb.yearMonthDaySpecified && gb.yearMonthDay.Year != 0001)
            {
                basisDaten.Geburtsdatum = gb.yearMonthDay;
            }

            // Geschlecht wird hier hart codiert zugewiesen, da Newod-Webservice für den Geschlecht ein Enum überträgt
            // und eine Anpassung bei neuen Werten sowieso nötig ist.
            switch (person.personIdentification.sex)
            {
                // unbekannt
                case DT_eChPersonIdentificationTypeSex.Item0:
                    basisDaten.GeschlechtCode = null;
                    break;
                // männlich
                case DT_eChPersonIdentificationTypeSex.Item1:
                    basisDaten.GeschlechtCode = 1;
                    break;
                // weiblich
                case DT_eChPersonIdentificationTypeSex.Item2:
                    basisDaten.GeschlechtCode = 2;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Heimatort
            basisDaten.HeimatgemeindeBaGemeindeIds = new List<int>();
            if (reportedPerson.anyPerson.swiss != null)
            {
                var bfsCodes = reportedPerson.anyPerson.swiss.Where(x => !string.IsNullOrEmpty(x.originBfSNumber)).Select(x => x.originBfSNumber).ToList();

                bfsCodes.ForEach(bfsCode =>
                {
                    var gemeindeId = lovConverter.MapBfsCodeToBaGemeindeId(bfsCode, "BFSCode");
                    if (gemeindeId.HasValue)
                    {
                        basisDaten.HeimatgemeindeBaGemeindeIds.Add(gemeindeId.Value);
                    }
                });

                if (basisDaten.HeimatgemeindeBaGemeindeIds.Any())
                {
                    basisDaten.HeimatgemeindeBaGemeindeID = basisDaten.HeimatgemeindeBaGemeindeIds.First();
                }
            }

            basisDaten.Name = person.personIdentification.officialName;
            switch (person.coreData.nationality.nationalityStatus)
            {
                // Unbekannt
                case DT_eChRootPersonRootReportedPersonPersonCoreDataNationalityNationalityStatus.Item0:
                    // KiSS 1: Unbekannt
                    basisDaten.NationalitaetCode = 1;
                    break;
                // Staatenlos
                case DT_eChRootPersonRootReportedPersonPersonCoreDataNationalityNationalityStatus.Item1:
                    // KiSS 200: Staatenlos
                    basisDaten.NationalitaetCode = 200;
                    break;
                // Staatsangehörigkeit bekannt -> via Country-Iso Code mappen
                case DT_eChRootPersonRootReportedPersonPersonCoreDataNationalityNationalityStatus.Item2:
                    basisDaten.NationalitaetCode = GetBaLandId(person.coreData.nationality.country, "Nationalität", lovConverter);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Unbekannter Nationalitätsstatus von Newod");
            }

            basisDaten.SpracheCode = lovConverter.MapNewodToLovCode("sprache", person.coreData.languageOfCorrespondance);
            if (!person.coreData.dateOfDeath.Equals(DateTime.MinValue) &&
                !person.coreData.dateOfDeath.ToString(CultureInfo.InvariantCulture).Contains("30.11.0002"))
            {
                basisDaten.Sterbedatum = person.coreData.dateOfDeath;
            }

            if (person.personIdentification.vnSpecified)
            {
                basisDaten.Versichertennummer = person.personIdentification.vn;
            }

            if (basisDaten.Versichertennummer == 0)
            {
                basisDaten.Versichertennummer = null;
            }

            basisDaten.Vorname = person.personIdentification.firstName;
            // Zivilstand wird hier hart codiert zugewiesen, da Newod-Webservice für den Zivilstand ein Enum überträgt
            // und eine Anpassung bei neuen Werten sowieso nötig ist.
            switch (person.coreData.maritalData.maritalStatus)
            {
                // unbekannt
                case DT_eChRootPersonRootReportedPersonPersonCoreDataMaritalDataMaritalStatus.Item0:
                    // unbekannt mappen wir den Kiss-Wert nicht festgelegt.
                    basisDaten.ZivilstandCode = 99999;
                    break;
                // ledig
                case DT_eChRootPersonRootReportedPersonPersonCoreDataMaritalDataMaritalStatus.Item1:
                    basisDaten.ZivilstandCode = 1;
                    break;
                // verheiratet
                case DT_eChRootPersonRootReportedPersonPersonCoreDataMaritalDataMaritalStatus.Item2:
                    basisDaten.ZivilstandCode = 2;
                    break;
                // verwitwet
                case DT_eChRootPersonRootReportedPersonPersonCoreDataMaritalDataMaritalStatus.Item3:
                    basisDaten.ZivilstandCode = 4;
                    break;
                // geschieden
                case DT_eChRootPersonRootReportedPersonPersonCoreDataMaritalDataMaritalStatus.Item4:
                    basisDaten.ZivilstandCode = 5;
                    break;
                // unverheiratet
                case DT_eChRootPersonRootReportedPersonPersonCoreDataMaritalDataMaritalStatus.Item5:
                    // unverheiratet mappen wir den KiSS-Wert ledig
                    basisDaten.ZivilstandCode = 1;
                    break;
                // in eingetragener Partnerschaft
                case DT_eChRootPersonRootReportedPersonPersonCoreDataMaritalDataMaritalStatus.Item6:
                    basisDaten.ZivilstandCode = 7;
                    break;
                // aufgelöster Partnerschaft
                case DT_eChRootPersonRootReportedPersonPersonCoreDataMaritalDataMaritalStatus.Item7:
                    // aufgelöster Partnerschaft mappen wir den Kiss-Wert getrennt
                    basisDaten.ZivilstandCode = 3;
                    break;

                default:
                    throw new ArgumentException("Kein gültiger Zivilstand!");
            }

            // Setzen FruehererName nur wenn nicht gleich wie Nachnamen
            if (!basisDaten.Name.Equals(person.coreData.originalName))
            {
                basisDaten.FruehererName = person.coreData.originalName;
            }

            if (!person.coreData.maritalData.dateOfMaritalStatus.Equals(DateTime.MinValue))
            {
                basisDaten.ZivilstandDatum = person.coreData.maritalData.dateOfMaritalStatus;
            }

            SetWegzugAdresse(reportedPerson, lovConverter, basisDaten);
            SetZuzugAdresse(reportedPerson, lovConverter, basisDaten);
            return basisDaten;
        }

        public static NewodPerson ConvertFromSap(DT_eChRootPersonRoot res)
        {
            PersonBasisDaten basisDaten = ConvertFromSap(res.reportedPerson);
            PersonAdressDaten addressDaten = null;
            if (res.reportedPerson.hasMainResidence != null
                    && res.reportedPerson.hasMainResidence.mainResidence != null
                    && res.reportedPerson.hasMainResidence.mainResidence.dwellingAddress != null
                    && res.reportedPerson.hasMainResidence.mainResidence.dwellingAddress.address != null)
                addressDaten = ConvertFromSap(res.reportedPerson.hasMainResidence.mainResidence, Convert.ToInt32(basisDaten.ID));
            return new NewodPerson(basisDaten, addressDaten);
        }

        public static GetPersonRequest[] ConvertFromSap(DT_GetPersonRequestBpartners[] req)
        {
            if (req == null)
            {
                return null;
            }

            var listPersonRequest = new List<GetPersonRequest>();
            foreach (DT_GetPersonRequestBpartners bpartner in req)
            {
                var person = new GetPersonRequest
                {
                    ID = bpartner.Bpartner,
                    Mutationsart = bpartner.MutArt,
                    ValidFrom = bpartner.ValidFrom,
                    ValidFromSpecified = true
                };
                person.Trim();
                listPersonRequest.Add(person);
            }

            return listPersonRequest.ToArray();
        }

        public static GetPersonRequest[] ConvertFromSap(string[] ids)
        {
            if (ids == null)
            {
                return new GetPersonRequest[] { };
            }

            return ids.Select(id => new GetPersonRequest { ID = id, Mutationsart = null, ValidFromSpecified = false }).ToArray();
        }

        public static DT_CODE[] ConvertToSap(string personId, Markflags mark)
        {
            List<DT_CODE> codes = new List<DT_CODE>
                                      {
                                          CreateCode(personId, AS, mark.AS),
                                          CreateCode(personId, CHV, mark.CHV),
                                          CreateCode(personId, KISS, mark.KISS)
                                      };
            return codes.ToArray();
        }

        public static DT_CODE[] ConvertToSap(string[] ids, Markflags mark)
        {
            List<DT_CODE> codes = new List<DT_CODE>();
            foreach (string id in ids)
            {
                codes.Add(CreateCode(id, AS, mark.AS));
                codes.Add(CreateCode(id, CHV, mark.CHV));
                codes.Add(CreateCode(id, KISS, mark.KISS));
            }

            return codes.ToArray();
        }

        public static DT_SearchPerson_Request ConvertToSap(PersonSearchCriteria criteria, out int criteriaCount)
        {
            criteriaCount = 0;

            DT_SearchPerson_Request request = new DT_SearchPerson_Request();
            // prepare request
            if (criteria.LastName != null)
            {
                request.LASTNAME = criteria.LastName;
                criteriaCount++;        // TODO check auf Wildcards!
            }

            if (criteria.FirstName != null)
            {
                request.FIRSTNAME = criteria.FirstName;
                criteriaCount++;
            }

            if (criteria.BirthDayFrom.HasValue)
            {
                request.BIRTHDATE_FROM = criteria.BirthDayFrom.Value.Date;
                request.BIRTHDATE_FROMSpecified = true;
                request.BIRTHDATE_TO = criteria.BirthDayFrom.Value.Date;
                request.BIRTHDATE_TOSpecified = true;
                criteriaCount++;
            }

            if (criteria.BirthDayTo.HasValue)
            {
                request.BIRTHDATE_TO = criteria.BirthDayTo.Value.Date;
                request.BIRTHDATE_TOSpecified = true;
                criteriaCount++;
            }

            if (criteria.Ahv11 != null)
            {
                request.AHVN11 = criteria.Ahv11.Replace(".", "");
                criteriaCount++;
            }

            if (criteria.Ahv13 != null)
            {
                request.AHVN13 = criteria.Ahv13;
                criteriaCount++;
            }

            if (criteria.Strasse != null)
            {
                request.STREET = criteria.Strasse;
                criteriaCount++;
            }

            if (criteria.Hausnr != null)
            {
                request.HOUSE_NO = criteria.Hausnr;
                criteriaCount++;
            }

            if (criteria.Plz != null)
            {
                request.POSTL_COD1 = criteria.Plz;
                criteriaCount++;
            }

            if (criteria.Ort != null)   // TODO mach Ort als Suchkriterium Sinn?
            {
                request.CITY = criteria.Ort;
                criteriaCount++;
            }

            if (criteria.CountryIso2Code != null)   // TODO mach Ort als Suchkriterium Sinn?
            {
                request.COUNTRY = criteria.CountryIso2Code;
                criteriaCount++;
            }

            return request;
        }

        #endregion

        #region Private Static Methods

        private static bool ConvertCraCode(string val)
        {
            if (val == JA)
            {
                return true;
            }

            if (val == NEIN)
            {
                return false;
            }

            throw new ArgumentException("val");
        }

        private static DT_CODE CreateCode(string id, string codetype, bool value)
        {
            return new DT_CODE
            {
                CRA_CODE = value ? JA : NEIN,
                CRA_CODE_TYPE = codetype,
                PARTNER = id
            };
        }

        private static int? GetBaLandId(DT_eChCountryType country, string fieldName, LovConverter lovConverter)
        {
            if (country == null)
            {
                return null;
            }

            string countryIsoCode = !string.IsNullOrWhiteSpace(country.countryIdISO2) ? country.countryIdISO2 : country.countryId;
            return lovConverter.MapIsoCountryCodeToBaLandId(countryIsoCode, fieldName);
        }

        private static void SetWegzugAdresse(DT_eChRootPersonRootReportedPerson reportedPerson, LovConverter lovConverter,
            PersonBasisDaten basisDaten)
        {
            if (reportedPerson.hasMainResidence.mainResidence.goesTo == null) return;
            // Wegzug Swiss Town
            if (reportedPerson.hasMainResidence.mainResidence.goesTo.swissTown != null)
            {
                var wegzugInland = reportedPerson.hasMainResidence.mainResidence.goesTo.swissTown;
                if (!string.IsNullOrWhiteSpace(wegzugInland.municipalityName))
                {
                    basisDaten.WegzugOrt = wegzugInland.municipalityName;
                }

                if (reportedPerson.hasMainResidence.mainResidence.goesTo.mailAddress != null)
                {
                    var wegZugAdressDaten = reportedPerson.hasMainResidence.mainResidence.goesTo.mailAddress;
                    basisDaten.WegzugPlz = wegZugAdressDaten.swissZipCode.ToString(CultureInfo.InvariantCulture);
                    basisDaten.WegzugLandCode = lovConverter.MapIsoCountryCodeToBaLandId(wegZugAdressDaten.country, "WegzugLand");
                    // obwohl goesto.swissTown.municipalityName ein Mussfeld ist kommt es nicht immer, deshalb
                    // der Versuch den Ort über goesTo.mailAddress.town (optional) zu kriegen
                    if (string.IsNullOrWhiteSpace(basisDaten.WegzugOrt) && !string.IsNullOrWhiteSpace(wegZugAdressDaten.town))
                    {
                        basisDaten.WegzugOrt = wegZugAdressDaten.town;
                    }
                }

                basisDaten.WegzugOrtCode = lovConverter.MapOrtnameToBaGemeindeId(basisDaten.WegzugOrt, "WegzugOrt");
                basisDaten.WegzugKanton = wegzugInland.cantonAbbreviation;
                if (reportedPerson.hasMainResidence.mainResidence.departureDateSpecified &&
                    !reportedPerson.hasMainResidence.mainResidence.departureDate.Equals(DateTime.MinValue))
                {
                    basisDaten.WegzugDatum = reportedPerson.hasMainResidence.mainResidence.departureDate;
                }
            }
            // Wegzug Foreign Country
            else if (reportedPerson.hasMainResidence.mainResidence.goesTo.foreignCountry != null)
            {
                var wegzugAusland = reportedPerson.hasMainResidence.mainResidence.goesTo.foreignCountry;
                basisDaten.WegzugOrt = wegzugAusland.town;
                basisDaten.WegzugOrtCode = null;
                basisDaten.WegzugPlz = string.Empty;
                basisDaten.WegzugKanton = string.Empty;
                basisDaten.WegzugLandCode = GetBaLandId(wegzugAusland.country, "WegzugLand", lovConverter);
                if (reportedPerson.hasMainResidence.mainResidence.departureDateSpecified &&
                    !reportedPerson.hasMainResidence.mainResidence.departureDate.Equals(DateTime.MinValue))
                {
                    basisDaten.WegzugDatum = reportedPerson.hasMainResidence.mainResidence.departureDate;
                }
            }
        }

        private static void SetZuzugAdresse(DT_eChRootPersonRootReportedPerson reportedPerson, LovConverter lovConverter,
            PersonBasisDaten basisDaten)
        {
            if (reportedPerson.hasMainResidence.mainResidence.comesFrom == null) return;
            // Zuzug CH
            if (reportedPerson.hasMainResidence.mainResidence.comesFrom.swissTown != null)
            {
                var zuzugInland = reportedPerson.hasMainResidence.mainResidence.comesFrom.swissTown;
                if (!string.IsNullOrWhiteSpace(zuzugInland.municipalityName))
                {
                    basisDaten.ZuzugOrt = zuzugInland.municipalityName;
                }

                if (reportedPerson.hasMainResidence.mainResidence.comesFrom.mailAddress != null)
                {
                    var zuZugAdressDaten = reportedPerson.hasMainResidence.mainResidence.comesFrom.mailAddress;
                    basisDaten.ZuzugPlz = zuZugAdressDaten.swissZipCode.ToString(CultureInfo.InvariantCulture);
                    // obwohl comesFrom.swissTown.municipalityName ein Mussfeld ist kommt es nicht immer, deshalb
                    // der Versuch den Ort über comesFrom.mailAddress.town (optional) zu kriegen
                    if (string.IsNullOrWhiteSpace(basisDaten.ZuzugOrt) && !string.IsNullOrWhiteSpace(zuZugAdressDaten.town))
                    {
                        basisDaten.ZuzugOrt = zuZugAdressDaten.town;
                    }
                }

                basisDaten.ZuzugOrtCode = lovConverter.MapOrtnameToBaGemeindeId(basisDaten.ZuzugOrt, "ZuzugOrt");
                basisDaten.ZuzugKanton = zuzugInland.cantonAbbreviation;
                // Always switzerland is assigned!
                basisDaten.ZuzugLandCode = lovConverter.MapIsoCountryCodeToBaLandId("CH", "ZuzugLand");
                if (!reportedPerson.hasMainResidence.mainResidence.arrivalDate.Equals(DateTime.MinValue))
                {
                    basisDaten.ZuzugDatum = reportedPerson.hasMainResidence.mainResidence.arrivalDate;
                }
            }
            // Zuzug foreign country
            else if (reportedPerson.hasMainResidence.mainResidence.comesFrom.foreignCountry != null)
            {
                var zuzugAusland = reportedPerson.hasMainResidence.mainResidence.comesFrom.foreignCountry;
                basisDaten.ZuzugOrt = zuzugAusland.town;
                basisDaten.ZuzugOrtCode = null;
                basisDaten.ZuzugPlz = string.Empty;
                basisDaten.ZuzugKanton = string.Empty;
                basisDaten.ZuzugLandCode = GetBaLandId(zuzugAusland.country, "ZuzugLand", lovConverter);
                if (!reportedPerson.hasMainResidence.mainResidence.arrivalDate.Equals(DateTime.MinValue))
                {
                    basisDaten.ZuzugDatum = reportedPerson.hasMainResidence.mainResidence.arrivalDate;
                }
            }
        }

        #endregion

        #endregion
    }
}