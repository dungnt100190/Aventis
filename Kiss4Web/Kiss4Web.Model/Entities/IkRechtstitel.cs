using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkRechtstitel
    {
        public IkRechtstitel()
        {
            IkBetreibung = new HashSet<IkBetreibung>();
            IkEinkommen = new HashSet<IkEinkommen>();
            IkForderung = new HashSet<IkForderung>();
            IkGlaeubiger = new HashSet<IkGlaeubiger>();
            IkPosition = new HashSet<IkPosition>();
            IkRatenplanForderung = new HashSet<IkRatenplanForderung>();
            IkVerrechnungskonto = new HashSet<IkVerrechnungskonto>();
        }

        public int IkRechtstitelId { get; set; }
        public int FaLeistungId { get; set; }
        public int? IkBezugKinderzulagenCode { get; set; }
        public int? IkRechtstitelStatusCode { get; set; }
        public int? IkRechtstitelTypCode { get; set; }
        public string InkassoFallName { get; set; }
        public string RechtstitelInfo { get; set; }
        public DateTime? RechtstitelDatumVon { get; set; }
        public DateTime? RechtstitelRechtskraeftig { get; set; }
        public int? IkElterlicheSorgeCode { get; set; }
        public string ElterlicheSorgeBemerkung { get; set; }
        public int? BaPersonId { get; set; }
        public int? IkIndexTypCode { get; set; }
        public double? IndexStandPunkte { get; set; }
        public DateTime? IndexStandVom { get; set; }
        public int? IkIndexRundenCode { get; set; }
        public decimal? BasisKinderalimente { get; set; }
        public decimal? BasisEhegattenalimente { get; set; }
        public int? IkInkassoBemuehungCode { get; set; }
        public DateTime? VerjaehrungAm { get; set; }
        public string Bemerkung { get; set; }
        public bool? SchuldnerMahnen { get; set; }
        public int? IkAlimenteUnterartCode { get; set; }
        public int? IkRueckerstattungTypCode { get; set; }
        public DateTime? IkRechtstitelGueltigVon { get; set; }
        public DateTime? IkRechtstitelGueltigBis { get; set; }
        public byte[] IkRechtstitelTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public ICollection<IkBetreibung> IkBetreibung { get; set; }
        public ICollection<IkEinkommen> IkEinkommen { get; set; }
        public ICollection<IkForderung> IkForderung { get; set; }
        public ICollection<IkGlaeubiger> IkGlaeubiger { get; set; }
        public ICollection<IkPosition> IkPosition { get; set; }
        public ICollection<IkRatenplanForderung> IkRatenplanForderung { get; set; }
        public ICollection<IkVerrechnungskonto> IkVerrechnungskonto { get; set; }
    }
}
