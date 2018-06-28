using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaAktennotizen
    {
        public int FaAktennotizId { get; set; }
        public int FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? Zeit { get; set; }
        public int? FaDauerCode { get; set; }
        public int? FaGespraechsStatusCode { get; set; }
        public string FaThemaCodes { get; set; }
        public int? FaGespraechstypCode { get; set; }
        public string Kontaktpartner { get; set; }
        public int? AlimentenstelleTypCode { get; set; }
        public string BaPersonIds { get; set; }
        public string Stichwort { get; set; }
        public string InhaltRtf { get; set; }
        public bool Vertraulich { get; set; }
        public bool? BesprechungThema1 { get; set; }
        public bool? BesprechungThema2 { get; set; }
        public bool? BesprechungThema3 { get; set; }
        public bool? BesprechungThema4 { get; set; }
        public string BesprechungThemaText1 { get; set; }
        public string BesprechungThemaText2 { get; set; }
        public string BesprechungThemaText3 { get; set; }
        public string BesprechungThemaText4 { get; set; }
        public string BesprechungZiel1 { get; set; }
        public string BesprechungZiel2 { get; set; }
        public string BesprechungZiel3 { get; set; }
        public string BesprechungZiel4 { get; set; }
        public int? BesprechungZielGrad1 { get; set; }
        public int? BesprechungZielGrad2 { get; set; }
        public int? BesprechungZielGrad3 { get; set; }
        public int? BesprechungZielGrad4 { get; set; }
        public int? FaKontaktartCode { get; set; }
        public string Pendenz1 { get; set; }
        public string Pendenz2 { get; set; }
        public string Pendenz3 { get; set; }
        public string Pendenz4 { get; set; }
        public bool? PendenzErledigt1 { get; set; }
        public bool? PendenzErledigt2 { get; set; }
        public bool? PendenzErledigt3 { get; set; }
        public bool? PendenzErledigt4 { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaAktennotizTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
