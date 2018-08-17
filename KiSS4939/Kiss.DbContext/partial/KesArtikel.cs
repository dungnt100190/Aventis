using System;

namespace Kiss.DbContext
{
    partial class KesArtikel
    {
        public string ArtikelText
        {
            get
            {
                return Artikel
                    + (string.IsNullOrEmpty(Absatz) ? null : "." + Absatz)
                    + (string.IsNullOrEmpty(Ziffer) ? null : "." + Ziffer)
                    + " "
                    + Gesetz;
            }
        }

        public string ArtikelTextBezeichnung
        {
            get
            {
                return ArtikelText + (string.IsNullOrEmpty(Bezeichnung) ? null : " " + Bezeichnung);
            }
        }

        public string ArtikelTextBezeichnungKurz
        {
            get { return ArtikelText + (string.IsNullOrEmpty(BezeichnungKurz) ? null : " " + BezeichnungKurz); }
        }

        public bool IsActive
        {
            get { return ((DatumBis ?? DateTime.MaxValue) >= DateTime.Now) && ((DatumVon ?? DateTime.MinValue) <= DateTime.Now); }
        }

        public override string ToString()
        {
            return ArtikelTextBezeichnungKurz;
        }
    }
}