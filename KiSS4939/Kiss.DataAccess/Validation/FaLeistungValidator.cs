using FluentValidation;

using Kiss.DataAccess.LocalResources.Fa;
using Kiss.DataAccess.Properties;
using Kiss.DbContext;

namespace Kiss.DataAccess.Validation
{
    public class FaLeistungValidator : ValidatorBase<FaLeistung>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FaLeistungValidator"/> class and validates the entity <see cref="FaLeistung"/> in memory.
        /// </summary>
        public FaLeistungValidator()
        {
            // TODO wenn ID-Properties validiert werden, verhindert das das Speichern eines ganzen Objektgraphen mit neuen Entities.
            // kann das anders überprüft werden oder ist das überhaupt nötig?
            //RuleFor(x => x.BaPersonID).GreaterThan(0);
            //RuleFor(x => x.UserID).GreaterThan(0);

            RuleFor(x => x.DatumVon).NotEmpty().WithMessage(FaLeistungValidatorRes.EroeffnungsdatumNichtLeer);
            RuleFor(x => x.GemeindeCode).NotEmpty().WithMessage(FaLeistungValidatorRes.ZustaendigeGemeindeNichtLeer);
            RuleFor(x => x.DatumBis.Value)
                .GreaterThan(x => x.DatumVon)
                .When(x => x.DatumBis.HasValue)
                .WithMessage(Resources.LeistungDatumBisGroesserDatumVon);
        }
    }
}