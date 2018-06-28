using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmBericht
    {
        public VmBericht()
        {
            VmMandBericht = new HashSet<VmMandBericht>();
        }

        public int VmBerichtId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? BerichtsperiodeVon { get; set; }
        public DateTime? BerichtsperiodeBis { get; set; }
        public DateTime? Erstellung { get; set; }
        public DateTime? Mahnung { get; set; }
        public DateTime? Mahnung2 { get; set; }
        public DateTime? Passation1 { get; set; }
        public DateTime? Passation2 { get; set; }
        public DateTime? Versand { get; set; }
        public string Bemerkung { get; set; }
        public byte[] VmBerichtTs { get; set; }
        public decimal? Entschaedigung { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public ICollection<VmMandBericht> VmMandBericht { get; set; }
    }
}
