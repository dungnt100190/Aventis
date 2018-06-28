using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaArbeit
    {
        public int BaArbeit1 { get; set; }
        public int BaPersonId { get; set; }
        public int? BaInstitutionId { get; set; }
        public int? TypCode { get; set; }
        public int? PensumCode { get; set; }
        public int? BaSprachniveauCode { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string Bemerkung { get; set; }
        public string Adresse { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaArbeitTs { get; set; }

        public BaInstitution BaInstitution { get; set; }
    }
}
