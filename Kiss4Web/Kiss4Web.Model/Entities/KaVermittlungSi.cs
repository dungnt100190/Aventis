using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaVermittlungSi
    {
        public int KaVermittlungSiid { get; set; }
        public int? FaLeistungId { get; set; }
        public int? ZuweiserId { get; set; }
        public int? AnmeldungCode { get; set; }
        public bool Vermittelt { get; set; }
        public int? KaSiKategorieCode { get; set; }
        public int? DocumentIdSchlussbericht { get; set; }
        public DateTime? AbschlussDatum { get; set; }
        public bool WechselKaintern { get; set; }
        public int? WechselKainternGrundCode { get; set; }
        public bool DossierRetourAnSd { get; set; }
        public int? DossierRetourAnSdgrundCode { get; set; }
        public string Bemerkungen { get; set; }
        public bool MigrationKa { get; set; }
        public bool SichtbarSdflag { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaVermittlungSits { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
