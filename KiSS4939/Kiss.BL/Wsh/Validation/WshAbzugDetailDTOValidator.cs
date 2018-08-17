using Kiss.Model.DTO.Wsh;

using FluentValidation;

namespace Kiss.BL.Wsh.Validation
{
    public class WshAbzugDetailDTOValidator : ValidatorBase<WshAbzugDetailDTO, WshAbzugDetailDTOValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshAbzugDetailDTOValidator"/> class and validates the entity <see cref="WshAbzugDetailDTO"/> in memory.
        /// </summary>
        public WshAbzugDetailDTOValidator()
        {
            RuleFor(x => x.WshAbzugDetail).NotNull();
        }

        #endregion
    }
}