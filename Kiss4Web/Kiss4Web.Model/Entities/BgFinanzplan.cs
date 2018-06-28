using System;
using System.Collections.Generic;
using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class BgFinanzplan : IEntity
    {
        public BgFinanzplan()
        {
            BgBewilligung = new HashSet<BgBewilligung>();
            BgBudget = new HashSet<BgBudget>();
            BgDokument = new HashSet<BgDokument>();
            BgFinanzplanBaPerson = new HashSet<BgFinanzplanBaPerson>();
        }

        public int BgFinanzplanId { get; set; }
        public int FaLeistungId { get; set; }
        public int BgBewilligungStatusCode { get; set; }
        public int? BgGrundEroeffnenCode { get; set; }
        public int? BgGrundAbschlussCode { get; set; }
        public int? WhHilfeTypCode { get; set; }
        public DateTime GeplantVon { get; set; }
        public DateTime? GeplantBis { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string Bemerkung { get; set; }
        public byte[] BgFinanzplanTs { get; set; }
        public int? WhGrundbedarfTypCode { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public ICollection<BgBewilligung> BgBewilligung { get; set; }
        public ICollection<BgBudget> BgBudget { get; set; }
        public ICollection<BgDokument> BgDokument { get; set; }
        public ICollection<BgFinanzplanBaPerson> BgFinanzplanBaPerson { get; set; }
        public int Id => BgFinanzplanId;
        public byte[] RowVersion => BgFinanzplanTs;
    }
}