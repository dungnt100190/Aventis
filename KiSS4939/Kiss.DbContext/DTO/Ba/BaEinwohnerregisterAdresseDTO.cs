using System;
using System.Runtime.Serialization;

namespace Kiss.DbContext.DTO.Ba
{
    [DataContract]
    public class BaEinwohnerregisterAdresseDTO
    {
        [DataMember]
        public int? AdresseCode { get; set; }

        [DataMember]
        public DateTime? DatumBis { get; set; }

        [DataMember]
        public DateTime? DatumVon { get; set; }

        [DataMember]
        public bool Gesperrt { get; set; }

        [DataMember]
        public string HausNr { get; set; }

        public bool IsCurrent
        {
            get { return (DatumVon ?? DateTime.MinValue) <= DateTime.Now && (DatumBis ?? DateTime.MaxValue) >= DateTime.Now; }
        }

        [DataMember]
        public string Kanton { get; set; }

        [DataMember]
        public string Land { get; set; }

        [DataMember]
        public string Ort { get; set; }

        [DataMember]
        public int? OrtCode { get; set; }

        [DataMember]
        public string Plz { get; set; }

        [DataMember]
        public int? PlzId { get; set; }

        [DataMember]
        public string PlzZusatz { get; set; }

        [DataMember]
        public string Postfach { get; set; }

        [DataMember]
        public bool PostfachOhneNr { get; set; }

        [DataMember]
        public string Strasse { get; set; }

        [DataMember]
        public int? StrasseCode { get; set; }

        [DataMember]
        public string Zusatz { get; set; }
    }
}