using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaKantonalerZuschuss
    {
        public BaKantonalerZuschuss()
        {
            BaPersonKantonalerZuschuss = new HashSet<BaPersonKantonalerZuschuss>();
        }

        public int BaKantonalerZuschussId { get; set; }
        public string Bezeichnung { get; set; }
        public int? BezeichnungTid { get; set; }
        public int KantonCode { get; set; }
        public bool Aktiv { get; set; }
        public string Bemerkungen { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public byte[] BaKantonalerZuschussTs { get; set; }

        public ICollection<BaPersonKantonalerZuschuss> BaPersonKantonalerZuschuss { get; set; }
    }
}
