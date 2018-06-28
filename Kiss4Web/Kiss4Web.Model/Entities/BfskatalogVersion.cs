using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BfskatalogVersion
    {
        public BfskatalogVersion()
        {
            Bfsdossier = new HashSet<Bfsdossier>();
            Bfsfrage = new HashSet<Bfsfrage>();
        }

        public int BfskatalogVersionId { get; set; }
        public int? Jahr { get; set; }
        public string PlausexVersion { get; set; }
        public string DossierXml { get; set; }

        public ICollection<Bfsdossier> Bfsdossier { get; set; }
        public ICollection<Bfsfrage> Bfsfrage { get; set; }
    }
}
