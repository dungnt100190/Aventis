using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesMassnahmeAuftrag
    {
        public int KesMassnahmeAuftragId { get; set; }
        public int KesMassnahmeId { get; set; }
        public int? DocumentIdBeschluss { get; set; }
        public DateTime? BeschlussVom { get; set; }
        public DateTime? ErledigungBis { get; set; }
        public string Auftrag { get; set; }
        public int? KesMassnahmeGeschaeftsartCode { get; set; }
        public int? DocumentIdBericht { get; set; }
        public int? DocumentIdVersand { get; set; }
        public int? DocumentIdVerfuegungKesb { get; set; }
        public DateTime? DatumVerfuegungKesb { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KesMassnahmeAuftragTs { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DatumVersand { get; set; }

        public KesMassnahme KesMassnahme { get; set; }
    }
}
