using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using KiSSSvc.Omega.Anmelden;
using KiSSSvc.Omega.DTO;

using namedPersonIdType = KiSSSvc.Omega.Suche.namedPersonIdType;
using yesNoType = KiSSSvc.Omega.Suche.yesNoType;

namespace KiSSSvc.Omega
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public IEnumerable<PersonKurzbeschreibung> SearchPerson(CompositeType composite)
        {
            var client = new Suche.SI_O102_Suche_sync_obClient();
            var par = new Suche.inputPersonSearch
            {

            };
            var result = client.SI_O102_Suche_sync_ob(par);
            return result.persons.Select(
                prs => new PersonKurzbeschreibung
                {
                    AHV13 = prs.searchResultPerson.personIdentification.vnSpecified ?
                              prs.searchResultPerson.personIdentification.vn.ToString() :
                              string.Empty,
                    AHV11 = ExtractPersonID(prs.searchResultPerson.personIdentification.OtherPersonId, "CH.AHV"),
                    Vorname = prs.searchResultPerson.personIdentification.firstName,
                    Nachname = prs.searchResultPerson.personIdentification.officialName,
                    Geburtsdatum = prs.searchResultPerson.personIdentification.dateOfBirth.Item is DateTime ?
                                     ((DateTime)prs.searchResultPerson.personIdentification.dateOfBirth.Item).ToString("yyyyMMdd") :
                                     prs.searchResultPerson.personIdentification.dateOfBirth.Item as string, // ToDo
                    Geschlecht = prs.searchResultPerson.personIdentification.sex.ToString(), //ToDo
                    Nationalitaet = prs.additionalData.nationality.country.countryNameShort,
                    AlphaAktiv = prs.additionalData.personActive == yesNoType.Item0,
                    QuellsystemID = prs.searchResultPerson.personIdentification.localPersonId.personId,
                    Adresszeile1 = prs.additionalData.address.addressLine1,
                    Adresszeile2 = prs.additionalData.address.addressLine2,
                    AdresseLand = prs.additionalData.address.country
                });
        }

        public IEnumerable<PersonKurzbeschreibung> ImportPerson(string quellsystemID)
        {
            var client = new Personendaten.SI_O101_Anfrage_sync_obClient();
            var request = new Personendaten.inputDataRequest { dataRequest = new Personendaten.eventDataRequest
            {
                requestPersonIdentification = new Personendaten.personIdentificationType
                {
                    localPersonId = new Personendaten.namedPersonIdType{personId = quellsystemID, personIdCategory = "MU.261"}
                }
            }};
            var result = client.SI_O101_Anfrage_sync_ob(request);
            //result.baseDelivery.messages[0].baseDeliveryPerson.person.coredata.
            var client2 = new Anmelden.SI_O13_Regist_sync_obClient();
            client2.SI_O13_Regist_sync_ob(new inputRegistration{ Items = new object[]{new registrationPersonType{personId="123"}}});

            var client3 = new Abmelden.SI_O13_deRegist_sync_obClient();
            client3.SI_O13_deRegist_sync_ob(new Abmelden.inputDeregistration { Items = new object[] { new Abmelden.deregistrationPersonType { personId = "123" } } });
        }


        private static string ExtractPersonID(IEnumerable<namedPersonIdType> personIds, string description)// oder enum?            
        {
            return personIds
                   .Where(id => id.personIdCategory == description)
                   .Select(id => id.personId)
                   .FirstOrDefault();
        }
    }
}
