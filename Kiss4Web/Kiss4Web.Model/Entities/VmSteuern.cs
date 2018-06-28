using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmSteuern
    {
        public int VmSteuernId { get; set; }
        public int FaLeistungId { get; set; }
        public int? DocumentId { get; set; }
        public int? SteuerJahr { get; set; }
        public bool SteuererklaerungExternErledigt { get; set; }
        public bool SteuererklaerungInternErledigt { get; set; }
        public string ErledigungDurch { get; set; }
        public DateTime? SteuererklaerungEingereicht { get; set; }
        public bool Artikel41 { get; set; }
        public DateTime? FristverlaengerungBeantragt { get; set; }
        public DateTime? EingangDefVeranlagung { get; set; }
        public DateTime? DatumEntscheidErlass { get; set; }
        public bool Erlass { get; set; }
        public bool Teilerlass { get; set; }
        public bool Abelehnt { get; set; }
        public string Bemerkungen { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmSteuernTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
