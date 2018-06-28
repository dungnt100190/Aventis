using System;
using System.Collections.Generic;
using Kiss4Web.Model.Entities;
using Kiss4Web.Model.Sozialhilfe;

namespace Kiss4Web.Model
{
    public partial class BgSpezkonto : IEntity
    {
        public BgSpezkonto()
        {
            BgPosition = new HashSet<BgPosition>();
            BgSpezkontoAbschluss = new HashSet<BgSpezkontoAbschluss>();
            ShEinzelzahlung = new HashSet<ShEinzelzahlung>();
        }

        public int BgSpezkontoId { get; set; }
        public int FaLeistungId { get; set; }
        public BgSpezkontoTyp BgSpezkontoTypCode { get; set; }
        public string NameSpezkonto { get; set; }
        public decimal StartSaldo { get; set; }
        public bool OhneEinzelzahlung { get; set; }
        public decimal? BetragProMonat { get; set; }
        public int? BgPositionsartId { get; set; }
        public DateTime? ErsterMonat { get; set; }
        public int? BgKostenartId { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string Bemerkung { get; set; }
        public int? OldId { get; set; }
        public byte[] BgSpezkontoTs { get; set; }
        public int? BaInstitutionId { get; set; }
        public int? BaPersonId { get; set; }
        public bool Inaktiv { get; set; }
        public int? KuerzungLaufzeitMonate { get; set; }
        public decimal? KuerzungAnteilGbl { get; set; }
        public string AbschlussBegruendung { get; set; }
        public int? AbzahlungskontoRueckerstattungCode { get; set; }
        public int? AbschlussgrundCode { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public BaPerson BaPerson { get; set; }
        public BgKostenart BgKostenart { get; set; }
        public BgPositionsart BgPositionsart { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public ICollection<BgPosition> BgPosition { get; set; }
        public ICollection<BgSpezkontoAbschluss> BgSpezkontoAbschluss { get; set; }
        public ICollection<ShEinzelzahlung> ShEinzelzahlung { get; set; }
        public int Id => BgSpezkontoId;
        public byte[] RowVersion => BgSpezkontoTs;
    }
}