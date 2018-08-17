using System;
using System.Collections.Generic;

namespace Kiss.DbContext.DTO.Fa
{
    public class FaWeisungDTO
    {
        public int FaWeisungID { get; set; }
        public int FaLeistungID { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string Betreff { get; set; }
        public XUser VerantwortlichSar { get; set; }
        public IEnumerable<BaPerson> Empfaenger { get; set; }
        public IEnumerable<FaWeisungDokumentDTO> Dokumente { get; set; }
        public IEnumerable<FaWeisungProtokoll> Protokolle { get; set; }
    }
}
