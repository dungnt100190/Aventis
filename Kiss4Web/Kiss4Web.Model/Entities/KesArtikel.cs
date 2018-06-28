using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesArtikel
    {
        public KesArtikel()
        {
            KesMassnahmeBssKesArtikelIdMassnahmegebundeneGeschaefteNavigation = new HashSet<KesMassnahmeBss>();
            KesMassnahmeBssKesArtikelIdNichtMassnahmegebundeneGeschaefteNavigation = new HashSet<KesMassnahmeBss>();
            KesMassnahmeKesArtikel = new HashSet<KesMassnahmeKesArtikel>();
        }

        public int KesArtikelId { get; set; }
        public string CodeKokes { get; set; }
        public string Artikel { get; set; }
        public string Absatz { get; set; }
        public string Ziffer { get; set; }
        public string Gesetz { get; set; }
        public string Bezeichnung { get; set; }
        public string BezeichnungKurz { get; set; }
        public int KesMassnahmeTypCode { get; set; }
        public bool IsMassnahmeGebunden { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KesArtikelTs { get; set; }

        public ICollection<KesMassnahmeBss> KesMassnahmeBssKesArtikelIdMassnahmegebundeneGeschaefteNavigation { get; set; }
        public ICollection<KesMassnahmeBss> KesMassnahmeBssKesArtikelIdNichtMassnahmegebundeneGeschaefteNavigation { get; set; }
        public ICollection<KesMassnahmeKesArtikel> KesMassnahmeKesArtikel { get; set; }
    }
}
