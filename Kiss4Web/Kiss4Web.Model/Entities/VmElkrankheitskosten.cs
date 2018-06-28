using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmElkrankheitskosten
    {
        public int VmElkrankheitskostenId { get; set; }
        public int FaLeistungId { get; set; }
        public int? DocumentId { get; set; }
        public DateTime? Eingereicht { get; set; }
        public DateTime? AbrechnungenVom { get; set; }
        public DateTime? VerfuegungVom { get; set; }
        public decimal? Betrag { get; set; }
        public DateTime? AbrechnungenBis { get; set; }
        public decimal? VerfuegungLeistung { get; set; }
        public string Bemerkungen { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmElkrankheitskostenTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public VmElkrankheitskosten VmElkrankheitskostenNavigation { get; set; }
        public VmElkrankheitskosten InverseVmElkrankheitskostenNavigation { get; set; }
    }
}
