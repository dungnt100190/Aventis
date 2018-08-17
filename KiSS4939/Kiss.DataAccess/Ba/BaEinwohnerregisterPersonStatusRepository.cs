using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.DbContext;
using Kiss.DbContext.DTO.Ba;

namespace Kiss.DataAccess.Ba
{
    public class BaEinwohnerregisterPersonStatusRepository : Repository<BaEinwohnerregisterPersonStatus>
    {
        public BaEinwohnerregisterPersonStatusRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public BaEinwohnerregisterPersonStatus GetByBaPersonId(int baPersonId)
        {
            return DbSet.SingleOrDefault(x => x.BaPersonID == baPersonId);
        }

        /// <summary>
        /// Holt eine Liste von DTOs mit Personen, welche entweder an- oder abgemeldet werden sollen.
        /// </summary>
        /// <returns></returns>
        public List<BaEinwohnerregisterPersonStatusDTO> GetStatusDTOList()
        {
            var baPersonSet = DbContext.Set<BaPerson>();

            var istBaPersonIds = from status in DbSet
                                 join person in baPersonSet on status.BaPersonID equals person.BaPersonID
                                 select new
                                 {
                                     person.BaPersonID,
                                     person.EinwohnerregisterID
                                 };

            var faFallPersonSet = DbContext.Set<FaFallPerson>();

            var sollBaPersonIds = from person in baPersonSet
                                  join faFallPerson in faFallPersonSet on person.BaPersonID equals faFallPerson.BaPersonID
                                  where person.EinwohnerregisterAktiv && person.EinwohnerregisterID != null &&
                                        (faFallPerson.DatumVon == null || faFallPerson.DatumVon <= DateTime.Now) &&
                                        (faFallPerson.DatumBis == null || faFallPerson.DatumBis >= DateTime.Now)
                                  select new
                                  {
                                      person.BaPersonID,
                                      person.EinwohnerregisterID
                                  };

            var anzumelden = sollBaPersonIds
                .Except(istBaPersonIds)
                .Select(
                    x => new BaEinwohnerregisterPersonStatusDTO
                    {
                        BaPersonId = x.BaPersonID,
                        Anmelden = true,
                        EinwohnerregisterId = x.EinwohnerregisterID
                    });
            var abzumelden = istBaPersonIds
                .Except(sollBaPersonIds)
                .Select(
                    x => new BaEinwohnerregisterPersonStatusDTO
                    {
                        BaPersonId = x.BaPersonID,
                        Anmelden = false,
                        EinwohnerregisterId = x.EinwohnerregisterID
                    });

            return anzumelden.Concat(abzumelden).ToList();
        }
    }
}