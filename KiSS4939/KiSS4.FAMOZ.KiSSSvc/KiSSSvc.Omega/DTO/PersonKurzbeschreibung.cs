using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace KiSSSvc.Omega.DTO
{
    [DataContract]
    public class PersonKurzbeschreibung
    {
        [DataMember]
        public string AHV11 { get; set; }
        [DataMember]
        public string AHV13 { get; set; }

        [DataMember]
        public string Vorname { get; set; }
        [DataMember]
        public string Nachname { get; set; }
        [DataMember]
        public string Geburtsdatum { get; set; }

        [DataMember]
        public string QuellsystemID { get; set; }

        [DataMember]
        public string Geschlecht { get; set; }
        [DataMember]
        public string Nationalitaet { get; set; }
        [DataMember]
        public bool? AlphaAktiv { get; set; }

        [DataMember]
        public string Adresszeile1 { get; set; }
        [DataMember]
        public string Adresszeile2 { get; set; }
        [DataMember]
        public string AdresseLand { get; set; }
        [DataMember]
        public int? OrgUnitID { get; set; }

        //public string Adresszusatz { get; set; }
        //public string StrasseHausNr { get; set; }
        //public int? StrasseCode { get; set; }
        //public string HausNr { get; set; }
        //public string Postfach { get; set; }
        //public string PLZOrt { get; set; }
        //public string PLZ { get; set; }
        //public int? OrtCode { get; set; }
        //public string Ort { get; set; }
        //public string Kanton { get; set; }
        //public int? LandCode { get; set; }
    }
}
