using System;
using System.Runtime.Serialization;

namespace Kiss.DbContext.DTO.Ba
{
    [DataContract]
    public class BaEinwohnerregisterPersonAnfrageDTO : BaEinwohnerregisterPersonResultDTO
    {
        [DataMember]
        public string Aliasname { get; set; }

        [DataMember]
        public string AndererName { get; set; }

        [DataMember]
        public int? AuslaenderStatusCode { get; set; }

        [DataMember]
        public DateTime? AuslaenderStatusGueltigBis { get; set; }

        [DataMember]
        public BaEinwohnerregisterKrankenkasseDTO[] Krankenkassen { get; set; }

        [DataMember]
        public int? ReligionCode { get; set; }

        [DataMember]
        public string Rufname { get; set; }

        [DataMember]
        public DateTime? Todesdatum { get; set; }

        [DataMember]
        public DateTime? WegzugDatum { get; set; }

        [DataMember]
        public string WegzugKanton { get; set; }

        [DataMember]
        public string WegzugLandIso2 { get; set; }

        [DataMember]
        public string WegzugOrt { get; set; }

        [DataMember]
        public int? WegzugOrtCode { get; set; }

        [DataMember]
        public string WegzugPlz { get; set; }

        [DataMember]
        public int? ZivilstandCode { get; set; }

        [DataMember]
        public DateTime? ZivilstandDatum { get; set; }

        [DataMember]
        public DateTime? ZuzugDatum { get; set; }

        [DataMember]
        public string ZuzugKanton { get; set; }

        [DataMember]
        public string ZuzugLandIso2 { get; set; }

        [DataMember]
        public string ZuzugOrt { get; set; }

        [DataMember]
        public int? ZuzugOrtCode { get; set; }

        [DataMember]
        public string ZuzugPlz { get; set; }
    }
}