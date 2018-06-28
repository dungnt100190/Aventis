using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmErbe
    {
        public int VmErbeId { get; set; }
        public int? VmSiegelungId { get; set; }
        public int? VmTestamentId { get; set; }
        public int? VmErbschaftsdienstId { get; set; }
        public int Position { get; set; }
        public int Level { get; set; }
        public string Titel { get; set; }
        public string Geburtsdatum { get; set; }
        public string Anrede { get; set; }
        public string FamilienNamen { get; set; }
        public string Vornamen { get; set; }
        public string Zusatz { get; set; }
        public string Strasse { get; set; }
        public string Ort { get; set; }
        public string Land { get; set; }
        public string Ergaenzung { get; set; }
        public string KontaktAdresse { get; set; }
        public bool? KontaktHinzufuegen { get; set; }
        public string TestamentEroeffnungStatus { get; set; }
        public int? TestamentEroeffnungNr { get; set; }
        public string TestamentEroeffnungVersandart { get; set; }
        public DateTime? TestamentEroeffnungVersandDatum { get; set; }
        public string ErbCodierung { get; set; }
        public int? ErbanteilDividend { get; set; }
        public int? ErbanteilDivisor { get; set; }
        public string Bemerkung { get; set; }
        public byte[] VmErbeTs { get; set; }
        public string Titel2 { get; set; }

        public VmErbschaftsdienst VmErbschaftsdienst { get; set; }
        public VmSiegelung VmSiegelung { get; set; }
        public VmTestament VmTestament { get; set; }
    }
}
