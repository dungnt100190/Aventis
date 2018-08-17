using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.DbContext.DTO.Ba;
using Kiss.Server.Einwohnerregister.OmegaAdresseHistService;
using Kiss.Server.Einwohnerregister.OmegaAnfrageSimpleService;

using datePartiallyKnownType = Kiss.Server.Einwohnerregister.OmegaAdresseHistService.datePartiallyKnownType;
using ItemChoiceType = Kiss.Server.Einwohnerregister.OmegaAdresseHistService.ItemChoiceType;
using ItemsChoiceType = Kiss.Server.Einwohnerregister.OmegaAdresseHistService.ItemsChoiceType;
using namedPersonIdType = Kiss.Server.Einwohnerregister.OmegaAdresseHistService.namedPersonIdType;
using personIdentificationType = Kiss.Server.Einwohnerregister.OmegaAdresseHistService.personIdentificationType;
using sexType = Kiss.Server.Einwohnerregister.OmegaAdresseHistService.sexType;
using yesNoType = Kiss.Server.Einwohnerregister.OmegaAdresseHistService.yesNoType;

namespace Kiss.Server.Einwohnerregister.Omega
{
    public class AdresseHistService
    {
        public knownAddressesRequest CreateAdresseInputDTO(dataRequestResponse personAnfrageResponse, string endUserId, string endUserName, string techUserId)
        {
            var baseDelivery = (dataRequestResponseBaseDelivery)personAnfrageResponse.Item;
            var personIdentification = baseDelivery.messages[0].baseDeliveryPerson.person.personIdentification;

            return new knownAddressesRequest
            {
                knownAddressesHeader = new knownAddressesRequestKnownAddressesHeader
                {
                    enduserId = endUserId,
                    enduserName = endUserName,
                    techuserId = techUserId
                },
                knownAddressesBody = new knownAddressesRequestKnownAddressesBody
                {
                    inputKnownAddressesParameters = new inputKnownAddressParametersType(),
                    inputKnownAddressesPerson = new inputKnownAddressesPersonType
                    {
                        personIdentification = new personIdentificationType
                        {
                            dateOfBirth = new datePartiallyKnownType
                            {
                                Item = personIdentification.dateOfBirth.Item,
                                ItemElementName = (ItemChoiceType)(int)personIdentification.dateOfBirth.ItemElementName
                            },
                            firstName = personIdentification.firstName,
                            localPersonId = new namedPersonIdType
                            {
                                personId = personIdentification.localPersonId.personId,
                                personIdCategory = personIdentification.localPersonId.personIdCategory
                            },
                            officialName = personIdentification.officialName,
                            sex = (sexType)(int)personIdentification.sex
                        }
                    }
                }
            };
        }

        public BaEinwohnerregisterAdresseDTO[] GetHistAdressen(knownAddressesResponse adresseOutput)
        {
            var result = new List<BaEinwohnerregisterAdresseDTO>();

            foreach (var address in adresseOutput.outputKnownAddresses)
            {
                var addressDto = new BaEinwohnerregisterAdresseDTO
                {
                    AdresseCode = Utils.GetLovCodeByEchValue2("BaAdresstyp", address.addressType.ToString()), // TODO wie sind die Codes definiert?
                    DatumBis = Utils.ProcessValidDate(address.validTo),
                    DatumVon = Utils.ProcessValidDate(address.validFrom),
                    Gesperrt = address.addressLock == yesNoType.Item1,
                    HausNr = address.address.houseNumber,
                    Kanton = address.address.locality,
                    Land = address.address.country,
                    Ort = address.address.town,
                    OrtCode = address.cityCodeSpecified ? address.cityCode : (int?)null,
                    Postfach = address.address.postOfficeBoxNumberSpecified ? address.address.postOfficeBoxNumber.ToString() : address.address.postOfficeBoxText,
                    PostfachOhneNr = !address.address.postOfficeBoxNumberSpecified,
                    Strasse = address.address.street,
                    StrasseCode = address.streetCodeSpecified ? address.streetCode : (int?)null, // TODO was für ein Code ist es?
                    Zusatz = Utils.JoinAdresseZusatz(address.address.addressLine1, address.address.addressLine2),
                };

                if (address.address.Items != null)
                {
                    for (int i = 0; i < address.address.Items.Length; i++)
                    {
                        switch (address.address.ItemsElementName[i])
                        {
                            case ItemsChoiceType.foreignZipCode:
                                addressDto.Plz = address.address.Items[i] as string;
                                break;

                            case ItemsChoiceType.swissZipCode:
                                var plzInt = address.address.Items[i] as uint?;
                                if (plzInt != null)
                                {
                                    addressDto.Plz = plzInt.ToString();
                                }

                                break;

                            case ItemsChoiceType.swissZipCodeAddOn:
                                addressDto.PlzZusatz = address.address.Items[i] as string;
                                break;

                            case ItemsChoiceType.swissZipCodeId:
                                addressDto.PlzId = address.address.Items[i] as int?;
                                break;
                        }
                    }
                }

                result.Add(addressDto);
            }

            return result.OrderBy(x => x.DatumVon ?? DateTime.MaxValue).ToArray();
        }
    }
}