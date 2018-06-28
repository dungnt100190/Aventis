using System;
using System.Collections.Generic;
using Kiss4Web.Model.Klientenbuchhaltung;

namespace Kiss4Web.Model
{
    public partial class KbPeriode
    {
        public KbPeriode()
        {
            KbBelegKreis = new HashSet<KbBelegKreis>();
            KbBuchung = new HashSet<KbBuchung>();
            KbKonto = new HashSet<KbKonto>();
            KbPeriodeUser = new HashSet<KbPeriodeUser>();
            KbWvlauf = new HashSet<KbWvlauf>();
        }

        public ICollection<KbBelegKreis> KbBelegKreis { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
        public ICollection<KbKonto> KbKonto { get; set; }
        public KbMandant KbMandant { get; set; }
        public int KbMandantId { get; set; }
        public int KbPeriodeId { get; set; }
        public byte[] KbPeriodeTs { get; set; }
        public ICollection<KbPeriodeUser> KbPeriodeUser { get; set; }
        public ICollection<KbWvlauf> KbWvlauf { get; set; }
        public DateTime PeriodeBis { get; set; }
        public KbPeriodeStatus PeriodeStatusCode { get; set; }
        public DateTime PeriodeVon { get; set; }
        public DateTime? VerbuchtBis { get; set; }
    }
}