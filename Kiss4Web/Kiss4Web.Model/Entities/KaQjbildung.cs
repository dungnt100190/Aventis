using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaQjbildung
    {
        public int KaQjbildungId { get; set; }
        public int FaLeistungId { get; set; }
        public bool KursBewerbungFlag { get; set; }
        public bool KursInformatikFlag { get; set; }
        public bool KursVideoFlag { get; set; }
        public bool KursWissenFlag { get; set; }
        public bool KursCustom1Flag { get; set; }
        public string KursCustom1Text { get; set; }
        public bool KursCustom2Flag { get; set; }
        public string KursCustom2Text { get; set; }
        public bool KursCustom3Flag { get; set; }
        public string KursCustom3Text { get; set; }
        public bool KursCustom4Flag { get; set; }
        public string KursCustom4Text { get; set; }
        public bool KursCustom5Flag { get; set; }
        public string KursCustom5Text { get; set; }
        public bool KursCustom6Flag { get; set; }
        public string KursCustom6Text { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public bool SichtbarSdflag { get; set; }
        public byte[] KaQjbildungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
