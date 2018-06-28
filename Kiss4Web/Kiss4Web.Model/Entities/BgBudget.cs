using System.Collections.Generic;
using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class BgBudget : IEntity
    {
        public BgBudget()
        {
            BgBewilligung = new HashSet<BgBewilligung>();
            BgDokument = new HashSet<BgDokument>();
            BgPosition = new HashSet<BgPosition>();
            KbBuchung = new HashSet<KbBuchung>();
            ShEinzelzahlung = new HashSet<ShEinzelzahlung>();
        }

        public int BgBudgetId { get; set; }
        public int BgBewilligungStatusCode { get; set; }
        public int? BgFinanzplanId { get; set; }
        public int? Jahr { get; set; }
        public int? Monat { get; set; }
        public string Bemerkung { get; set; }
        public int? OldId { get; set; }
        public byte[] BgBudgetTs { get; set; }
        public bool MasterBudget { get; set; }

        public BgFinanzplan BgFinanzplan { get; set; }
        public ICollection<BgBewilligung> BgBewilligung { get; set; }
        public ICollection<BgDokument> BgDokument { get; set; }
        public ICollection<BgPosition> BgPosition { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
        public ICollection<ShEinzelzahlung> ShEinzelzahlung { get; set; }
        public int Id => BgBudgetId;
        public byte[] RowVersion => BgBudgetTs;
    }
}