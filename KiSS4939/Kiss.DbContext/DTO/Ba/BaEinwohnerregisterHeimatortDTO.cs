using System;
using System.Runtime.Serialization;

namespace Kiss.DbContext.DTO.Ba
{
    [DataContract]
    public class BaEinwohnerregisterHeimatortDTO
    {
        [DataMember]
        public int? BfsCode { get; set; }

        [DataMember]
        public string Heimatort { get; set; }

        [DataMember]
        public string Kanton { get; set; }
    }
}