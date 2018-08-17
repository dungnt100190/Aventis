using System;
using System.Linq;

using Kiss.DbContext.DTO.Ba;
using Kiss.Infrastructure.Utils;
using Kiss.Server.Einwohnerregister.OmegaAnfrageSimpleService;

namespace Kiss.Server.Einwohnerregister.Omega
{
    public class PersonAnfrageService
    {
        public BaEinwohnerregisterPersonAnfrageDTO CreatePersonAnfrageDTO(dataRequestResponse output)
        {
            // DEBUG
            //var objXml = Utils.SerializeObjectAsXml(output);
            //Logger.LogMessage(null, objXml);

            var dto = new BaEinwohnerregisterPersonAnfrageDTO();
            var baseDelivery = output.Item as dataRequestResponseBaseDelivery;
            var dataRequestError = output.Item as infoType;
            if (baseDelivery == null)
            {
                if (dataRequestError != null)
                {
                    throw new Exception(string.Format("Fehler beim Abholen einer Person: {0}  (Code {1})", dataRequestError.textGerman, dataRequestError.code));
                }

                throw new Exception();
            }

            var message = baseDelivery.messages[0];

            var personIdentification = message.baseDeliveryPerson.person.personIdentification;
            dto.IsActive = message.extension.coredata.personActive == yesNoType.Item1;
            dto.Name = personIdentification.officialName;
            dto.Vorname = personIdentification.firstName;
            dto.Geburtsdatum = Utils.GetDate(personIdentification.dateOfBirth);
            dto.GeschlechtCode = Convert.ToInt32(personIdentification.sex.GetXmlEnumAttributeValueFromEnum());
            dto.Versichertennummer = personIdentification.vnSpecified ? Utils.ConvertToVersichertennummer(personIdentification.vn.ToString()) : null;
            dto.PID = personIdentification.localPersonId.personId;

            if (personIdentification.OtherPersonId != null)
            {
                dto.ZEMISNr = Utils.GetOtherPersonId(personIdentification.OtherPersonId, "CH.ZEMIS");
                dto.ZARNr = Utils.GetOtherPersonId(personIdentification.OtherPersonId, "CH.ZAR");
                dto.ZhNr = Utils.GetOtherPersonId(personIdentification.OtherPersonId, "MU.261.ZHNR");
                dto.AHVNr = Utils.ConvertToAhvNr(Utils.GetOtherPersonId(personIdentification.OtherPersonId, "CH.AHV"));
            }

            var personCoreData = message.baseDeliveryPerson.person.coredata;
            dto.Aliasname = personCoreData.aliasName;
            dto.Rufname = personCoreData.callName;
            dto.ReligionCode = Utils.GetLovCodeByEchValue2("BaReligion", personCoreData.religion);
            dto.AndererName = personCoreData.otherName;
            dto.Todesdatum = personCoreData.dateOfDeathSpecified ? personCoreData.dateOfDeath : (DateTime?)null;

            // Nationalität: Staatsangehörigkeit bekannt
            if (personCoreData.nationality != null)
            {
                switch (personCoreData.nationality.nationalityStatus)
                {
                    case nationalityStatusType.Item0:
                        //unbekannt
                        dto.NationLandId = Utils.UNBEKANNT_ID;     // "1"
                        dto.NationLandIso2 = Utils.UNBEKANNT_ISO2; // "Z1"
                        dto.NationLand = "unbekannt / andere";
                        break;

                    case nationalityStatusType.Item1:
                        //staatenlos
                        dto.NationLandId = Utils.STAATENLOS_ID; ;   // "100000"
                        dto.NationLandIso2 = Utils.STAATENLOS_ISO2; // "XX"
                        dto.NationLand = "Staatenlos";
                        break;

                    case nationalityStatusType.Item2:
                        //Nationalität bekannt, ISO2 auswerten
                        dto.NationLandId = personCoreData.nationality.country.countryId;
                        dto.NationLandIso2 = personCoreData.nationality.country.countryIdISO2;
                        dto.NationLand = personCoreData.nationality.country.countryNameShort;
                        break;
                }
            }
            // aus extension
            var anyPerson = message.extension.anyPerson;
            if (anyPerson != null)
            {
                if (anyPerson.swiss != null)
                {
                    // Heimatorte
                    dto.Heimatorte = anyPerson.swiss
                        .Select(
                            placeOfOrigin => new BaEinwohnerregisterHeimatortDTO
                            {
                                BfsCode = placeOfOrigin.originIdSpecified ? placeOfOrigin.originId : (int?)null,
                                Heimatort = placeOfOrigin.originName,
                                Kanton = Enum.GetName(typeof(cantonAbbreviationType), placeOfOrigin.canton),
                            })
                        .ToArray();
                }

                // Ausländerstatus
                if (anyPerson.stay != null)
                {
                    dto.AuslaenderStatusCode = Utils.GetLovCodeByEchValue2("BaAufenthaltsstatus", anyPerson.stay.stayType1);
                    dto.AuslaenderStatusGueltigBis = anyPerson.stay.stayTypeTillDateSpecified ? Utils.ProcessValidDate(anyPerson.stay.stayTypeTillDate) : null;
                }
            }

            // Krankenkassenprämien (OKV/IPV)
            var okvNodes = message.extension.OKV;
            if (okvNodes != null)
            {
                dto.Krankenkassen = okvNodes.Select(
                    okv => new BaEinwohnerregisterKrankenkasseDTO
                    {
                        Jahr = Convert.ToInt32(okv.showYear),
                        Folgenummer = Convert.ToInt32(okv.sequenceNumber),
                        KrankenkasseNummer = okv.healthInsurance,
                        BetragAnspruch = okv.claimSpecified ? okv.claim : (decimal?)null,
                        BetragAuszahlung = okv.payOutSpecified ? okv.payOut : (decimal?)null,
                        LetzteMutation = okv.createDate
                    })
                    .ToArray();
            }

            var maritalData = personCoreData.maritalData;
            dto.ZivilstandCode = Utils.GetLovCodeByEchValue2("BaZivilstand", maritalData.maritalStatus.GetXmlEnumAttributeValueFromEnum());
            dto.ZivilstandDatum = maritalData.dateOfMaritalStatusSpecified ? maritalData.dateOfMaritalStatus : (DateTime?)null;

            var mainResidence = message.Item as mainResidenceType;
            if (mainResidence != null)
            {
                Logger.LogMessage(null, "CreatePersonAnfrageDTO.mainResidence");
                SetZuzugWegzugAdresse(dto, mainResidence.mainResidence.arrivalDate, mainResidence.mainResidence.comesFrom, mainResidence.mainResidence.departureDateSpecified, mainResidence.mainResidence.departureDate, mainResidence.mainResidence.goesTo, mainResidence.mainResidence.dwellingAddress);
            }
            else
            {
                var secondaryResidence = message.Item as secondaryResidenceType;
                if (secondaryResidence != null)
                {
                    Logger.LogMessage(null, "CreatePersonAnfrageDTO.secondaryResidence");
                    SetZuzugWegzugAdresse(dto, secondaryResidence.secondaryResidence.arrivalDate, secondaryResidence.secondaryResidence.comesFrom, secondaryResidence.secondaryResidence.departureDateSpecified, secondaryResidence.secondaryResidence.departureDate, secondaryResidence.secondaryResidence.goesTo, secondaryResidence.secondaryResidence.dwellingAddress);
                }
            }

            if (dto.Adressen == null && personCoreData.contact != null && personCoreData.contact.contactAddress != null && personCoreData.contact.contactAddress.addressInformation != null)
            {
                var address = personCoreData.contact.contactAddress.addressInformation;
                var addressDto = new BaEinwohnerregisterAdresseDTO
                {
                    Ort = address.town,
                    Strasse = address.street,
                    HausNr = address.houseNumber,
                    Kanton = address.locality,
                    Land = address.country,
                    Zusatz = Utils.JoinAdresseZusatz(address.addressLine1, address.addressLine2),
                    PostfachOhneNr = !address.postOfficeBoxNumberSpecified,
                    Postfach = address.postOfficeBoxNumberSpecified ? address.postOfficeBoxNumber.ToString() : address.postOfficeBoxText,
                };

                string plz;
                string plzZusatz;
                int? plzId;

                GetZipCodes(address, out plz, out plzZusatz, out plzId);

                addressDto.Plz = plz;
                addressDto.PlzZusatz = plzZusatz;
                addressDto.PlzId = plzId;

                dto.Adressen = new[] { addressDto };
            }

            return dto;
        }

        public dataRequestRequestLight CreatePersonInputLightDTO(string pid, string endUserId, string endUserName, string techUserId)
        {
            return new dataRequestRequestLight
            {
                dataRequestHeader = new dataRequestRequestLightDataRequestHeader
                {
                    enduserId = endUserId,
                    enduserName = endUserName,
                    techuserId = techUserId
                },
                dataRequestBody = new eventDataRequestLight
                {
                    requestPersonIdentification = new eventDataRequestLightRequestPersonIdentification
                    {
                        personId = OmegaService.PreparePid(pid)
                    }
                }
            };
        }

        private void GetZipCodes(addressInformationType address, out string plz, out string plzZusatz, out int? plzId)
        {
            plz = null;
            plzZusatz = null;
            plzId = null;

            if (address == null || address.Items == null)
            {
                return;
            }

            for (int i = 0; i < address.Items.Length; i++)
            {
                Logger.LogMessage(null, "GetZipCodes.ElementName = {0}", address.ItemsElementName[i]);
                Logger.LogMessage(null, "GetZipCodes.Item = {0}", address.Items[i]);
                switch (address.ItemsElementName[i])
                {
                    case ItemsChoiceType.foreignZipCode:
                        plz = address.Items[i] as string;
                        Logger.LogMessage(null, "GetZipCodes.plz = {0}", plz);
                        break;

                    case ItemsChoiceType.swissZipCode:
                        var plzInt = address.Items[i] as uint?;
                        plz = plzInt.HasValue ? plzInt.ToString() : null;
                        Logger.LogMessage(null, "GetZipCodes.plz = {0}", plz);
                        break;

                    case ItemsChoiceType.swissZipCodeAddOn:
                        plzZusatz = address.Items[i] as string;
                        Logger.LogMessage(null, "GetZipCodes.plzZusatz = {0}", plzZusatz);
                        break;

                    case ItemsChoiceType.swissZipCodeId:
                        plzId = address.Items[i] as int?;
                        Logger.LogMessage(null, "GetZipCodes.plzId = {0}", plzId);
                        break;
                }
            }
        }

        private void GetZuzugOrWegzug(destinationType destination, out string plz, out string plzZusatz, out int? plzId, out string ort, out string kanton, out string land)
        {
            plz = null;
            plzZusatz = null;
            plzId = null;
            ort = null;
            kanton = null;
            land = null;

            if (destination == null || destination.Item == null)
            {
                return;
            }

            var swissTown = destination.Item as swissMunicipalityType;
            if (swissTown != null)
            {
                Logger.LogMessage(null, "swissTown");
                plzId = swissTown.municipalityIdSpecified ? swissTown.municipalityId : (int?)null;
                ort = swissTown.municipalityName;
                kanton = swissTown.cantonAbbreviationSpecified ? Enum.GetName(typeof(cantonAbbreviationType), swissTown.cantonAbbreviation) : null;
                land = Utils.SCHWEIZ_ISO2;
                Logger.LogMessage(null, "GetZuzugOrWegzug.swissTown.plzId = {0}", plzId);
                Logger.LogMessage(null, "GetZuzugOrWegzug.swissTown.ort = {0}", ort);
                Logger.LogMessage(null, "GetZuzugOrWegzug.swissTown.land = {0}", land);
            }
            else
            {
                var foreignCountry = destination.Item as destinationTypeForeignCountry;
                if (foreignCountry != null)
                {
                    Logger.LogMessage(null, "foreignCountry");
                    ort = foreignCountry.town;
                    land = foreignCountry.country.countryIdISO2;
                    Logger.LogMessage(null, "GetZuzugOrWegzug.foreignCountry.ort = {0}", ort);
                    Logger.LogMessage(null, "GetZuzugOrWegzug.foreignCountry.land = {0}", land);
                }
            }

            if (destination.mailAddress != null)
            {
                Logger.LogMessage(null, "destination.mailAddress");
                string plzAdresse;
                string plzZusatzAdresse;
                int? plzIdAdresse;
                GetZipCodes(destination.mailAddress, out plzAdresse, out plzZusatzAdresse, out plzIdAdresse);
                plz = plz ?? plzAdresse;
                plzZusatz = plzZusatz ?? plzZusatzAdresse;
                plzId = plzId ?? plzIdAdresse;
                kanton = kanton ?? destination.mailAddress.locality;
                land = land ?? destination.mailAddress.country;
                ort = ort ?? destination.mailAddress.town;
                Logger.LogMessage(null, "GetZuzugOrWegzug.destination.mailAddress.plzId = {0}", plzId);
                Logger.LogMessage(null, "GetZuzugOrWegzug.destination.mailAddress.ort = {0}", ort);
                Logger.LogMessage(null, "GetZuzugOrWegzug.destination.mailAddress.land = {0}", land);
            }

            Logger.LogMessage(null, "GetZuzugOrWegzug.plzId = {0}", plzId);
            Logger.LogMessage(null, "GetZuzugOrWegzug.ort = {0}", ort);
            Logger.LogMessage(null, "GetZuzugOrWegzug.land = {0}", land);
        }

        private void SetZuzugWegzugAdresse(BaEinwohnerregisterPersonAnfrageDTO dto, DateTime arrivalDate, destinationType comesFrom, bool departureDateSpecified, DateTime departureDate, destinationType goesTo, dwellingAddressType dwellingAddress)
        {
            string plz;
            string plzZusatz;
            int? plzId;
            string ort;
            string kanton;
            string land;

            dto.ZuzugDatum = arrivalDate;
            if (comesFrom != null)
            {
                Logger.LogMessage(null, "comesFrom");
                GetZuzugOrWegzug(comesFrom, out plz, out plzZusatz, out plzId, out ort, out kanton, out land);
                dto.ZuzugOrtCode = plzId;
                dto.ZuzugKanton = kanton;
                dto.ZuzugLandIso2 = land;
                dto.ZuzugOrt = ort;
                dto.ZuzugPlz = plz;
            }

            dto.WegzugDatum = departureDateSpecified ? departureDate : (DateTime?)null;
            if (goesTo != null)
            {
                Logger.LogMessage(null, "goesTo");
                GetZuzugOrWegzug(goesTo, out plz, out plzZusatz, out plzId, out ort, out kanton, out land);
                dto.WegzugOrtCode = plzId;
                dto.WegzugKanton = kanton;
                dto.WegzugLandIso2 = land;
                dto.WegzugOrt = ort;
                dto.WegzugPlz = plz;

                Logger.LogMessage(null, "dto.WegzugOrtCode = {0}", dto.WegzugOrtCode);
                Logger.LogMessage(null, "dto.WegzugLandIso2 = {0}", dto.WegzugLandIso2);
                Logger.LogMessage(null, "dto.WegzugOrt = {0}", dto.WegzugOrt);
                Logger.LogMessage(null, "dto.WegzugPlz = {0}", dto.WegzugPlz);
            }

            if (dwellingAddress != null)
            {
                Logger.LogMessage(null, "dwellingAddress");
                var address = dwellingAddress.address;
                var addressDto = new BaEinwohnerregisterAdresseDTO
                {
                    Ort = address.town,
                    Strasse = address.street,
                    HausNr = address.houseNumber,
                    Kanton = address.locality,
                    Land = Utils.SCHWEIZ_ISO2,
                    Zusatz = Utils.JoinAdresseZusatz(address.addressLine1, address.addressLine2)
                };

                addressDto.Plz = address.swissZipCode.ToString();
                addressDto.PlzZusatz = address.swissZipCodeAddOn;
                addressDto.PlzId = address.swissZipCodeIdSpecified ? address.swissZipCodeId : (int?)null;

                dto.Adressen = new[] { addressDto };
                Logger.LogMessage(null, "addressDto = {0}", addressDto);
            }
        }
    }
}