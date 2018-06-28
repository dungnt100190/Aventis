using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaRelation
    {
        public BaRelation()
        {
            BaPersonRelation = new HashSet<BaPersonRelation>();
        }

        public int BaRelationId { get; set; }
        public string NameRelation { get; set; }
        public string NameGenerisch1 { get; set; }
        public string NameGenerisch2 { get; set; }
        public string NameMaennlich1 { get; set; }
        public string NameWeiblich1 { get; set; }
        public string NameMaennlich2 { get; set; }
        public string NameWeiblich2 { get; set; }
        public bool Symmetrisch { get; set; }
        public int BfsCode12 { get; set; }
        public int BfsCode21 { get; set; }
        public int SortKey { get; set; }
        public byte[] BaRelationTs { get; set; }

        public ICollection<BaPersonRelation> BaPersonRelation { get; set; }
    }
}
