using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Bfsdossier
    {
        public Bfsdossier()
        {
            BfsdossierPerson = new HashSet<BfsdossierPerson>();
            Bfswert = new HashSet<Bfswert>();
        }

        public int BfsdossierId { get; set; }
        public int BfskatalogVersionId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public int LaufNr { get; set; }
        public int ZustaendigeGemeinde { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int Jahr { get; set; }
        public bool Stichtag { get; set; }
        public int? BfsdossierStatusCode { get; set; }
        public int BfsleistungsartCode { get; set; }
        public DateTime? ImportDatum { get; set; }
        public DateTime? PlausibilisierungDatum { get; set; }
        public DateTime? ExportDatum { get; set; }
        public string Xml { get; set; }
        public byte[] BfsdossierTs { get; set; }

        public BfskatalogVersion BfskatalogVersion { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
        public ICollection<BfsdossierPerson> BfsdossierPerson { get; set; }
        public ICollection<Bfswert> Bfswert { get; set; }
    }
}
