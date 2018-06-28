namespace Kiss4Web.Model.QueryTypes
{
    public class TreeDisplayItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Type { get; set; }
        public int IconId { get; set; }
        public string Name { get; set; }
        public int BaPersonId { get; set; }
        public int UserId { get; set; }
        public int? OrgUnitId { get; set; }
        public int? FallTaskCount { get; set; }
        public int B { get; set; }
        public int F { get; set; }
        public int S { get; set; }
        public int I { get; set; }
        public int M { get; set; }
        public int A { get; set; }
        public int K { get; set; }
        public string AhvNummer { get; set; }
        public string NNummer { get; set; }
        public string NavigatorZusatz { get; set; }
        public string Versichertennummer { get; set; }
        public int? FaLeistungId { get; set; }
        public string Gemeinde { get; set; }
        public string Kategorie { get; set; }
        public string Farbe { get; set; }
        public int PersonCount { get; set; }
        public int TaskCount { get; set; }
    }
}