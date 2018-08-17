using System.Collections.Generic;

using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Validation;
using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Kbu.Validation
{
    public class KbuBelegValidator : ValidatorBase<KbuBeleg, KbuBelegValidator>
    {
        #region Constructors

        /// <summary>
        /// Validator für KbuBeleg.
        /// </summary>
        public KbuBelegValidator()
        {
            //Belegartcode
            RuleFor(x => x.KbuBelegartCode).NotNull().IsIn(
                new List<int>
                {
                    (int)LOVsGenerated.KbuBelegart.Auszahlung,
                    (int)LOVsGenerated.KbuBelegart.Einzahlung,
                    (int)LOVsGenerated.KbuBelegart.Storno,
                    (int)LOVsGenerated.KbuBelegart.Umbuchung,                   
                });
            
            //Belegstatuscode
            RuleFor(x => x.KbuBelegstatusCode).NotNull().IsIn(            
                new List<int>
                {
                    (int)LOVsGenerated.KbuBelegstatus.Freigegeben,
                    (int)LOVsGenerated.KbuBelegstatus.Vorschlag,
                    (int)LOVsGenerated.KbuBelegstatus.Verbucht,            
                });

        }

        #endregion
    }
}