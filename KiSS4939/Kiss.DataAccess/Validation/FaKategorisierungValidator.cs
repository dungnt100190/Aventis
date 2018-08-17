using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using FluentValidation;
using Kiss.DbContext;

namespace Kiss.DataAccess.Validation
{
    public class FaKategorisierungValidator : ValidatorBase<FaKategorisierung>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FaKategorisierungValidator"/> class and validates the entity <see cref="FaKategorisierung"/> in memory.
        /// </summary>
        public FaKategorisierungValidator()
        {
            RuleFor(x => x.Abschlussdatum)
                .GreaterThanOrEqualTo(x => x.Datum)
                .When(x => x.Abschlussdatum != null)
                .WithMessage("Das Abschlussdatum darf nicht vor dem Anfangsdatum liegen.");

            RuleFor(x => x.FaKategorisierungRessourcenCode).Must(ValidateFaKategorisierungRessourcenCode).WithMessage("Es müssen sowohl Kooperation als auch Ressourcen gesetzt sein.");
        }

        protected override IEnumerable<DbValidationError> ValidateOnDB(System.Data.Entity.Infrastructure.DbEntityEntry<FaKategorisierung> entityEntry, System.Data.Entity.DbContext context)
        {
            var isNew = entityEntry.State == EntityState.Added;
            var entity = entityEntry.Entity;
            var temp = context.Set<FaKategorisierung>()
                              .Where(kat => kat.BaPersonID == entity.BaPersonID
                                         && kat.FaKategorisierungID != entity.FaKategorisierungID
                                         && entity.Datum <= (kat.Abschlussdatum ?? (isNew ? kat.Datum : DateTime.MaxValue))
                                         && (entity.Abschlussdatum ?? DateTime.MaxValue) >= kat.Datum).ToArray();
            if (temp.Length > 0)
            {
                return new[] { new DbValidationError("DatumVon", "Es gibt Kategorien, die sich überschneiden. Es darf immer nur eine gültige Kategorie geben.") };
            }

            return null;
        }

        private bool ValidateFaKategorisierungRessourcenCode(FaKategorisierung faKategorisierung, int? faKategorisierungRessourcenCode)
        {
            return faKategorisierungRessourcenCode.HasValue && faKategorisierung.FaKategorisierungKooperationCode.HasValue
                   || (!faKategorisierungRessourcenCode.HasValue && !faKategorisierung.FaKategorisierungKooperationCode.HasValue);
        }

        #endregion
    }
}