using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesMassnahmeBericht
    {
        public int KesMassnahmeBerichtId { get; set; }
        public int KesMassnahmeId { get; set; }
        public int? KesMassnahmeBerichtsartCode { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string Bemerkung { get; set; }
        public int? DocumentIdBericht { get; set; }
        public int? DocumentIdRechnung { get; set; }
        public int? DocumentIdVersand { get; set; }
        public int? DocumentIdVerfuegungKesb { get; set; }
        public DateTime? DatumVerfuegungKesb { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KesMassnahmeBerichtTs { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DatumVersand { get; set; }
        public DateTime? DatumBelegeZurueck { get; set; }

        public KesMassnahme KesMassnahme { get; set; }
    }
}
