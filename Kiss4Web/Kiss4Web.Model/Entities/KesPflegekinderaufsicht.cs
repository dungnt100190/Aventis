using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesPflegekinderaufsicht
    {
        public int KesPflegekinderaufsichtId { get; set; }
        public int FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public int? BaInstitutionId { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int? KesPflegeartCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KesPflegekinderaufsichtTs { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
