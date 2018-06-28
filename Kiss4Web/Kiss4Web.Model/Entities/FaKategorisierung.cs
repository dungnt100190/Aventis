using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaKategorisierung
    {
        public int FaKategorisierungId { get; set; }
        public int BaPersonId { get; set; }
        public int? FaKategorisierungEksProduktId { get; set; }
        public int UserId { get; set; }
        public DateTime Datum { get; set; }
        public int? FaKategorisierungEksOptionCode { get; set; }
        public int? FaKategorisierungKiStatusCode { get; set; }
        public int? FaKategorisierungIntakeCode { get; set; }
        public int? FaKategorisierungKooperationCode { get; set; }
        public int? FaKategorisierungRessourcenCode { get; set; }
        public int? FaKategorisierungAbschlussgrundCode { get; set; }
        public int? FaKategorieCode { get; set; }
        public DateTime? Abschlussdatum { get; set; }
        public string Begruendung { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaKategorisierungTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public FaKategorisierungEksProdukt FaKategorisierungEksProdukt { get; set; }
        public XUser User { get; set; }
    }
}
