using System;
using System.Runtime.Serialization;

namespace Kiss.DbContext.DTO.Ba
{
    [DataContract]
    public class BaEinwohnerregisterPersonSucheDTO
    {
        [DataMember]
        public string AHV11 { get; set; }

        [DataMember]
        public string AHV13 { get; set; }

        [DataMember]
        public DateTime? Geburtsdatum { get; set; }

        [DataMember]
        public int? GeschlechtCode { get; set; }

        [DataMember]
        public string Hausnummer { get; set; }

        [DataMember]
        public string Nachname { get; set; }

        [DataMember]
        public string PID { get; set; }

        [DataMember]
        public string Strasse { get; set; }

        [DataMember]
        public string Vorname { get; set; }

        [DataMember]
        public string ZARNr { get; set; }

        [DataMember]
        public string ZEMISNr { get; set; }

        [DataMember]
        public string ZHNr { get; set; }
    }
}