using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaPraemienverbilligung
    {
        public int BaPraemienverbilligungId { get; set; }
        public int BaPersonId { get; set; }
        public int? Jahr { get; set; }
        public int? Folgenummer { get; set; }
        public decimal? BetragAnspruch { get; set; }
        public decimal? BetragAuszahlung { get; set; }
        public string ZahlungAn { get; set; }
        public string ZahlungAnKrankenkassennummer { get; set; }
        public DateTime? LetzteMutation { get; set; }
        public string Grund { get; set; }
        public byte[] BaPraemienverbilligungTs { get; set; }

        public BaPerson BaPerson { get; set; }
    }
}
