using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess.Audit;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Infrastructure.ErrorHandling;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kiss4Web.Infrastructure.DataAccess.Validation
{
    public class EntityEntryValidator : IDbChangeAuditor
    {
        private readonly Validator _validator;

        public EntityEntryValidator(Validator validator)
        {
            _validator = validator;
        }

        public void AuditEntities(IEnumerable<EntityEntry> entities, IDbContext dbContext)
        {
            var results = entities.Where(ent => ent.State == EntityState.Added || ent.State == EntityState.Modified).Select(ent => _validator.Validate(ent.Entity).Result);
            var errors = results.Where(res => res?.IsValid == false)
                                .ToList();

            if (errors.Any())
            {
                throw new KissEntityValidationException(errors.SelectMany(err => err.Errors)
                                                              .Select(err => new KissEntityValidationResult { Message = err.ErrorMessage, PropertyName = err.PropertyName }));
            }
        }
    }
}