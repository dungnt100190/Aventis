using Kiss.Model.DTO.BA;

namespace Kiss.Model.DTO.Wsh
{
    public class WshAuszahlvorschlagKreditorDTO
    {
        public string Name { get; set; }
        public string KontoNr { get; set; }
        public string BankKontoNr { get; set; }
        public string PostKontoNr { get; set; }
        public string BankName { get; set; }             
        public BaZahlungsweg BaZahlungsweg { get; set; }
        public KreditorType Type { get; set; }
    }

   
}