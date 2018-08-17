using System;
using Kiss.DbContext.Enums.Fa;
using Kiss.DbContext.Enums.Sys;

namespace Kiss.DbContext.DTO.Fa
{
    public class FaWeisungDokumentDTO
    {
        public DateTime Datum { get; set; }
        public WeisungDokument Typ { get; set; }
        public DocumentFormat Format { get; set; }
    }
}
