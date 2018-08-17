using System;
using System.Collections.Generic;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess.Sys
{
    public class XLovCodeRepository : Repository<XLOVCode>
    {
        public XLovCodeRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        // nur für UnitTesting
        protected XLovCodeRepository()
        {
        }

        public virtual IList<XLOVCode> GetLovCodeByLovName(string lovName, int languageCode)
        {
            //RAT : In dieser Situation muss das Typ der Variable explicit spezifiziert werden
            //Sonst bekommen wir einen Convertierungsfehler in dem Query
            //http://stackoverflow.com/questions/10519008/how-do-i-convert-this-iqueryablepatient-to-dbsetpatient
            IQueryable<XLangText> xLangText = DbContext.Set<XLangText>();

            var tmp = DbSet
                    .Where(loc => loc.LOVName == lovName)
                    .OrderBy(loc => loc.SortKey)
                    .Select(loc => new
                    {
                        XLOVCode = loc,
                        LangText = loc.TextTID.HasValue ? xLangText.Where(x => x.TID == loc.TextTID.Value && x.LanguageCode == languageCode).Select(x => x.LargeText ?? x.Text).FirstOrDefault() : null,
                        LangValue1 = loc.Value1TID.HasValue ? xLangText.Where(x => x.TID == loc.Value1TID.Value && x.LanguageCode == languageCode).Select(x => x.LargeText ?? x.Text).FirstOrDefault() : null,
                        LangValue2 = loc.Value2TID.HasValue ? xLangText.Where(x => x.TID == loc.Value2TID.Value && x.LanguageCode == languageCode).Select(x => x.LargeText ?? x.Text).FirstOrDefault() : null,
                        LangValue3 = loc.Value3TID.HasValue ? xLangText.Where(x => x.TID == loc.Value3TID.Value && x.LanguageCode == languageCode).Select(x => x.LargeText ?? x.Text).FirstOrDefault() : null,
                    })
                    .ToList();

            tmp.ForEach(x => x.XLOVCode.Text = x.LangText ?? x.XLOVCode.Text);
            tmp.ForEach(x => x.XLOVCode.Value1 = x.LangValue1 ?? x.XLOVCode.Value1);
            tmp.ForEach(x => x.XLOVCode.Value2 = x.LangValue2 ?? x.XLOVCode.Value2);
            tmp.ForEach(x => x.XLOVCode.Value3 = x.LangValue3 ?? x.XLOVCode.Value3);

            var res = tmp.Select(x => x.XLOVCode).ToList();

            return res;
        }
    }
}