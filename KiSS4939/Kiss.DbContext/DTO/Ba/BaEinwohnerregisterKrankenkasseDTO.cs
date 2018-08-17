using System;
using System.Runtime.Serialization;

namespace Kiss.DbContext.DTO.Ba
{
    [DataContract]
    public class BaEinwohnerregisterKrankenkasseDTO
    {
        [DataMember]
        public decimal? BetragAnspruch { get; set; }

        [DataMember]
        public decimal? BetragAuszahlung { get; set; }

        [DataMember]
        public int Folgenummer { get; set; }

        [DataMember]
        public int Jahr { get; set; }

        [DataMember]
        public string KrankenkasseNummer { get; set; }

        [DataMember]
        public DateTime LetzteMutation { get; set; }
    }
}