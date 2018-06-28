namespace Kiss4Web.Model.QueryTypes
{
    public class KostenartDisplayItem
    {
        public int BgKostenartId { get; set; }
        public int ModulId { get; set; }
        public string KontoNr { get; set; }
        public string Name { get; set; }
        public int? NameTid { get; set; }
        public bool Quoting { get; set; }
        public int? BgSplittingArtCode { get; set; }
        public int? BaWvzeileCode { get; set; }
        public byte[] BgKostenartTs { get; set; }
        public string NrName { get; set; }
    }
}
