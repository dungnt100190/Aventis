using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;
using Kiss.DbContext.Constant;
using Kiss.Infrastructure.Utils;
using log4net;

namespace Kiss.DataAccess.Fa
{
    public partial class FaLeistungRepository : Repository<FaLeistung>
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public FaLeistungRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new FaLeistungValidator());
        }

        public FaLeistungRepository()
        {
        }

        public virtual List<FaLeistung> GetByFaFallIds(List<int> faFallIds)
        {
            return DbSet
                .Where(lei => faFallIds.Contains(lei.FaFallID))
                .ToList();
        }

        public FaLeistung GetFaLeistungByBaPersonId(int baPersonId, bool active)
        {
            // Person ist Fallträger
            var faFallSet = DbContext.Set<FaFall>().AsQueryable();
            var fallLeistung = (from lei in DbSet
                                join fal in faFallSet on lei.FaFallID equals fal.FaFallID
                                where fal.BaPersonID == baPersonId
                                where lei.FaProzessCode == (int)LOVsGenerated.FaProzess.Fallfuehrung
                                where !active || lei.DatumBis == null
                                orderby lei.DatumVon descending
                                select lei).FirstOrDefault();

            if (fallLeistung != null)
            {
                return fallLeistung;
            }

            // Person ist Leistungsträger
            var ltLeistung = (from lei in DbSet
                              where lei.BaPersonID == baPersonId
                              where !active || lei.DatumBis == null
                              orderby lei.DatumVon descending
                              select lei).FirstOrDefault();

            if (ltLeistung != null)
            {
                return ltLeistung;
            }

            // Person ist in einem Fall
            var faFallPersonSet = DbContext.Set<FaFallPerson>().AsQueryable();

            var ffLeistung = (from ffp in faFallPersonSet
                              where ffp.BaPersonID == baPersonId
                              select
                                  ffp.FaFall.FaLeistung.Where(x => x.FaProzessCode == (int)LOVsGenerated.FaProzess.Fallfuehrung && (!active || x.DatumBis == null))
                                      .OrderByDescending(x => x.DatumVon)
                                      .FirstOrDefault()).FirstOrDefault();

            return ffLeistung;
        }

        public List<FaLeistung> GetFaLeistungProUserByBaPersonId(int baPersonId)
        {
            try
            {
                var faLeistungList = new List<FaLeistung>();

                // Person ist Fallträger
                var faFallSet = DbContext.Set<FaFall>().AsQueryable();
                var fallLeistung = (from lei in DbSet
                                    join fal in faFallSet on lei.FaFallID equals fal.FaFallID
                                    where fal.BaPersonID == baPersonId
                                    where lei.FaProzessCode == (int)LOVsGenerated.FaProzess.Fallfuehrung
                                    where lei.DatumBis == null
                                    orderby lei.DatumVon descending
                                    select lei).FirstOrDefault();

                if (fallLeistung != null)
                {
                    faLeistungList.Add(fallLeistung);
                }

                // Person ist Leistungsträger
                var ltLeistung = (from lei in DbSet
                                  where lei.BaPersonID == baPersonId
                                  where lei.DatumBis == null
                                  orderby lei.DatumVon descending
                                  select lei).ToList();

                faLeistungList.AddRange(ltLeistung.Except(faLeistungList, (lt, fa) => lt.UserID == fa.UserID)); // Leistungen mit gleichem Benutzer nicht dopplet auflisten

                // Person ist in einem Fall
                var faFallPersonSet = DbContext.Set<FaFallPerson>().AsQueryable();
                var ffLeistung = (from ffp in faFallPersonSet
                                  where ffp.BaPersonID == baPersonId
                                  select ffp.FaFall.FaLeistung
                                         .Where(x => x.FaProzessCode == (int)LOVsGenerated.FaProzess.Fallfuehrung && (x.DatumBis == null))
                                         .OrderByDescending(x => x.DatumVon)
                                         .FirstOrDefault()).Where(l => l != null).ToList();

                faLeistungList.AddRange(ffLeistung.Except(faLeistungList, (ff, fa) => ff.UserID == fa.UserID)); // Leistungen mit gleichem Benutzer nicht dopplet auflisten

                return faLeistungList;
            }
            catch (Exception ex)
            {
                _log.Debug(ex);
                throw;
            }
        }

        public FaLeistung[] GetFallfuehrungen(int baPersonId, int? modulId = null)
        {
            modulId = modulId ?? 2;

            return DbSet
                   .Where(lei => lei.BaPersonID == baPersonId && lei.ModulID == modulId) //ToDo: enum für ModulID
                   .OrderBy(lei => lei.DatumVon)
                   .ToArray();
        }

        public bool IsUserFallfuehrer(int userId, int baPersonId, int modulId)
        {
            return DbSet
                   .Any(lei => lei.BaPersonID == baPersonId
                            && lei.ModulID == modulId
                            && lei.UserID == userId
                            && (!lei.DatumBis.HasValue || lei.DatumBis.Value >= DateTime.Today));
        }
    }
}