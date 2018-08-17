using System;
using System.Runtime.Serialization;

namespace Kiss.DbContext.DTO.Ba
{
    [DataContract]
    public class BaEinwohnerregisterPersonResultDTO
    {
        [DataMember]
        public BaEinwohnerregisterAdresseDTO[] Adressen { get; set; }

        [DataMember]
        public string AHVNr { get; set; }

        [DataMember]
        public string[] EuPersonIds { get; set; }

        [DataMember]
        public DateTime? Geburtsdatum { get; set; }

        [DataMember]
        public int GeschlechtCode { get; set; }

        [DataMember]
        public BaEinwohnerregisterHeimatortDTO[] Heimatorte { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string NationLand { get; set; }

        [DataMember]
        public string NationLandId { get; set; }

        [DataMember]
        public string NationLandIso2 { get; set; }

        [DataMember]
        public string PID { get; set; }

        [DataMember]
        public string Versichertennummer { get; set; }

        [DataMember]
        public string Vorname { get; set; }

        [DataMember]
        public string ZARNr { get; set; }

        [DataMember]
        public string ZEMISNr { get; set; }

        [DataMember]
        public string ZhNr { get; set; }
    }
}