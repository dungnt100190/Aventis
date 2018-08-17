using System;

namespace Kiss.DbContext.DTO.Fa
{
    public class FaDokumentDTO
    {
        public DateTime DatumErstellung { get; set; }
        public string Stichwort { get; set; }
        public int? DocFormatCode { get; set; }
        public string FaThemaCodes { get; set; }
        public int FaLeistungID { get; set; }
        public int FaDokumentID { get; set; }
        public XUser Absender { get; set; }
        public BaPerson Adressat { get; set; }
    }
}
