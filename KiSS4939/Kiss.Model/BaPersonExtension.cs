using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiss.Model
{
    public static class BaPersonExtension
    {
        public static IQueryable<BaPerson> WhereNameVornameContains(this IQueryable<BaPerson> query, string searchString)
        {
            var result = query.Where(p => (p.Name + (!string.IsNullOrEmpty(p.Vorname) ? ", " + p.Vorname : "")).Contains(searchString));
            return result;
        }

        public static IOrderedQueryable<BaPerson> OrderByNameVorname(this IQueryable<BaPerson> query)
        {
            var result = query.OrderBy(p => p.Name + (!string.IsNullOrEmpty(p.Vorname) ? ", " + p.Vorname : ""));
            return result;
        }

        public static BaAdresse SelectWohnadresse(this IEnumerable<BaAdresse> query)
        {
            var result = query.Where(
                a => a.AdresseCode == 1
                     && ((a.DatumVon ?? DateTime.Today) <= DateTime.Today)
                     && ((a.DatumBis ?? DateTime.Today) >= DateTime.Today)).First();
            return result;
        }
    }
}
