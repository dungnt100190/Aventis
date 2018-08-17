using System;

using Kiss.Infrastructure;

namespace Kiss.Model
{
    public partial class KbuBeleg
    {
        public KbuBeleg()
        {
            //TageValuta
            AddPropertyMapping(PropertyName.GetPropertyName(() => ValutaDatum),
                                PropertyName.GetPropertyName(() => TageValuta));
        }

        public int? TageValuta
        {
            get 
            {
                if (ValutaDatum == null)
                {
                    return null;
                }
                return (DateTime.Today - ValutaDatum.Value).Days;
            }

        }

    }
}
