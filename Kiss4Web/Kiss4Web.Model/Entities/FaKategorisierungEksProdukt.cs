using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaKategorisierungEksProdukt
    {
        public FaKategorisierungEksProdukt()
        {
            FaKategorisierung = new HashSet<FaKategorisierung>();
        }

        public int FaKategorisierungEksProduktId { get; set; }
        public int OrgUnitId { get; set; }
        public string Text { get; set; }
        public string ShortText { get; set; }
        public int FaKategorieCode { get; set; }
        public int? Frist { get; set; }
        public int FaKategorisierungEksProduktFristTypCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaKategorisierungEksProduktTs { get; set; }

        public XOrgUnit OrgUnit { get; set; }
        public ICollection<FaKategorisierung> FaKategorisierung { get; set; }
    }
}
