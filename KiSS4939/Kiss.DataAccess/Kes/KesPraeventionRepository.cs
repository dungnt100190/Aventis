using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;

namespace Kiss.DataAccess.Kes
{
    public class KesPraeventionRepository : Repository<KesPraevention>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public KesPraeventionRepository()
        {
        }

        public KesPraeventionRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new KesPraeventionValidator());
        }

        /// <summary>
        /// Includes:
        /// - XUser
        /// </summary>
        /// <param name="faLeistungId"></param>
        /// <returns></returns>
        public virtual IList<KesPraevention> GetByFaLeistungId(int faLeistungId)
        {
            return DbSet
                .Where(prv => prv.FaLeistungID == faLeistungId)
                .Include(prv => prv.XUser)
                .OrderBy(prv => prv.DatumVon)
                .ToList();
        }
    }
}