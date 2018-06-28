using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaJobtimal
    {
        public int KaJobtimalId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? ZuweiserId { get; set; }
        public int? AnmeldungCode { get; set; }
        public int? DocumentIdFaehigkeitsprofil { get; set; }
        public int? DocumentIdRahmenvertrag { get; set; }
        public DateTime? SozialhilfebezugAb { get; set; }
        public int? KaSozialhilfebezugCode { get; set; }
        public int? DocumentIdSchlussbericht { get; set; }
        public DateTime? AbschlussDatum { get; set; }
        public int? AustrittgrundCode { get; set; }
        public int? DossierRetourAnSdgrundCode { get; set; }
        public string Bemerkungen { get; set; }
        public bool SichtbarSdflag { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaJobtimalTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
