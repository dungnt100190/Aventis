using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmMassnahme
    {
        public VmMassnahme()
        {
            VmErnennung = new HashSet<VmErnennung>();
        }

        public int VmMassnahmeId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string Zgbcodes { get; set; }
        public string WeitereZgb { get; set; }
        public int? ElterlicheSorgeCode { get; set; }
        public string Bemerkung { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmMassnahmeTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public ICollection<VmErnennung> VmErnennung { get; set; }
    }
}
