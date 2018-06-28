using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaZuteilFachbereich
    {
        public int KaZuteilFachbereichId { get; set; }
        public int BaPersonId { get; set; }
        public DateTime? ZuteilungVon { get; set; }
        public DateTime? ZuteilungBis { get; set; }
        public int? FachbereichId { get; set; }
        public int? NiveauCode { get; set; }
        public int? ZustaendigKaId { get; set; }
        public int? FachleitungId { get; set; }
        public int? ZuteilDokId { get; set; }
        public bool? SichtbarSdflag { get; set; }
        public byte[] KaZuteilFachbereichTs { get; set; }

        public BaPerson BaPerson { get; set; }
    }
}
