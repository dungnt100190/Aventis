using System;
using System.Linq;
using System.Text.RegularExpressions;

using Kiss.DbContext.DTO.Ba;
using Kiss.Infrastructure.Utils;
using Kiss.Server.Einwohnerregister.OmegaSucheService;

namespace Kiss.Server.Einwohnerregister.Omega
{
    /// <summary>
    /// Helper-Service für Personen-Suchen
    /// </summary>
    public class PersonSucheService
    {
        public personSearchRequest CreateSearchInputDTO(BaEinwohnerregisterPersonSucheDTO personSucheDto, string endUserId, string endUserName, string techUserId)
        {
            ulong ahv11, ahv13;
            var ahv11Specified = GetAhvOrVersichertenNummer(personSucheDto.AHV11, out ahv11);
            var ahv13Specified = GetAhvOrVersichertenNummer(personSucheDto.AHV13, out ahv13);

            var result = new personSearchRequest
            {
                personSearchHeader = new personSearchRequestPersonSearchHeader
                {
                    enduserId = endUserId,
                    enduserName = endUserName,
                    techuserId = techUserId
                },
                personSearchBody = new personSearchRequestPersonSearchBody
                {
                    AHV11 = ahv11Specified ? ahv11.ToString() : null,
                    AHV13 = ahv13,
                    AHV13Specified = ahv13Specified,
                    birthDay = personSucheDto.Geburtsdatum.HasValue ? personSucheDto.Geburtsdatum.Value.Day.ToString() : null,
                    birthMonth = personSucheDto.Geburtsdatum.HasValue ? personSucheDto.Geburtsdatum.Value.Month.ToString() : null,
                    birthYear = personSucheDto.Geburtsdatum.HasValue ? personSucheDto.Geburtsdatum.Value.Year.ToString() : null,
                    firstName = personSucheDto.Vorname,
                    houseNr = personSucheDto.Hausnummer,
                    name = personSucheDto.Nachname,
                    personId = OmegaService.PreparePid(personSucheDto.PID),
                    sex = personSucheDto.GeschlechtCode.HasValue ? personSucheDto.GeschlechtCode.Value == 1 ? sexType.Item1 : sexType.Item2 : sexType.Item1,
                    sexSpecified = personSucheDto.GeschlechtCode.HasValue,
                    street = personSucheDto.Strasse,
                    ZARNr = personSucheDto.ZARNr,
                    ZEMISNr = personSucheDto.ZEMISNr,
                    ZHNr = personSucheDto.ZHNr
                }
            };
            return result;
        }

        /// <summary>
        /// Generiert ein Result-DTO auf Basis des Omega-Resultats.
        /// <see cref="searchResultPersonType"/> basiert auf http://www.ech.ch/vechweb/page?p=dossier&documentNumber=eCH-0044&documentVersion=2.00
        /// </summary>
        public BaEinwohnerregisterPersonResultDTO CreateSearchResultDTO(searchResultPersonsType searchResultPerson)
        {
            var dto = new BaEinwohnerregisterPersonResultDTO();

            var isActive = searchResultPerson.additionalData.personActive == yesNoType.Item1;
            var address = searchResultPerson.additionalData.address;
            var nationality = searchResultPerson.additionalData.nationality;
            var person = searchResultPerson.searchResultPerson.personIdentification;

            dto.IsActive = isActive;

            dto.Name = person.officialName;
            dto.Vorname = person.firstName;
            dto.Geburtsdatum = GetDate(person.dateOfBirth);
            dto.GeschlechtCode = Convert.ToInt32(person.sex.GetXmlEnumAttributeValueFromEnum());
            dto.Versichertennummer = person.vnSpecified ? Utils.ConvertToVersichertennummer(person.vn.ToString()) : null;
            dto.PID = person.localPersonId.personId;
            dto.ZEMISNr = GetOtherPersonId(person.OtherPersonId, "CH.ZEMIS");
            dto.ZARNr = GetOtherPersonId(person.OtherPersonId, "CH.ZAR");
            dto.AHVNr = Utils.ConvertToAhvNr(GetOtherPersonId(person.OtherPersonId, "CH.AHV"));

            if (address != null)
            {
                var addressDto = new BaEinwohnerregisterAdresseDTO
                {
                    Ort = address.town,
                    Strasse = address.street,
                    HausNr = address.houseNumber,
                    Plz = address.swissZipCodeSpecified ? address.swissZipCode.ToString() : address.foreignZipCode,
                    Land = address.country,
                    PlzId = address.swissZipCodeIdSpecified ? address.swissZipCodeId : (int?)null,
                    Zusatz = Utils.JoinAdresseZusatz(address.addressLine1, address.addressLine2),
                    PostfachOhneNr = !address.postOfficeBoxNumberSpecified,
                    Postfach = address.postOfficeBoxNumberSpecified ? address.postOfficeBoxNumber.ToString() : address.postOfficeBoxText
                    // TODO streetCode
                };

                dto.Adressen = new[] { addressDto };
            }

            if (nationality != null && nationality.country != null)
            {
                dto.NationLandId = nationality.country.countryId;
                dto.NationLandIso2 = nationality.country.countryIdISO2;
                dto.NationLand = nationality.country.countryNameShort;
            }

            return dto;
        }

        private static bool GetAhvOrVersichertenNummer(string str, out ulong nr)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                nr = 0;
                return false;
            }

            str = Regex.Replace(str, @"\.", "");
            return ulong.TryParse(str, out nr);
        }

        private static DateTime? GetDate(datePartiallyKnownType datePartiallyKnown)
        {
            if (datePartiallyKnown.Item != null)
            {
                int year;

                switch (datePartiallyKnown.ItemElementName)
                {
                    case ItemChoiceType.year: // YYYY
                        if (int.TryParse(datePartiallyKnown.Item as string, out year))
                        {
                            return new DateTime(year, 1, 1);
                        }
                        break;

                    case ItemChoiceType.yearMonth: // YYYY-MM
                        int month;
                        var str = datePartiallyKnown.Item as string;
                        if (str != null &&
                            str.Length == 7 &&
                            int.TryParse(str.Substring(0, 4), out year) &&
                            int.TryParse(str.Substring(5, 2), out month))
                        {
                            return new DateTime(year, month, 1);
                        }
                        break;

                    case ItemChoiceType.yearMonthDay:
                        return datePartiallyKnown.Item as DateTime?;
                }
            }

            return null;
        }

        private static string GetOtherPersonId(namedPersonIdType[] otherPersonIds, string name)
        {
            if (otherPersonIds != null)
            {
                var id = otherPersonIds.FirstOrDefault(x => x.personIdCategory.ToUpper() == name);
                return id != null ? id.personId : null;
            }
            return null;
        }
    }
}