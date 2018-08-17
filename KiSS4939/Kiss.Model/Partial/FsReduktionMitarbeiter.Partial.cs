
using Kiss.Infrastructure;

namespace Kiss.Model
{
    public partial class FsReduktionMitarbeiter
    {
        public FsReduktionMitarbeiter()
        {
            //GueltigeReduktionZeit
            AddPropertyMapping(PropertyName.GetPropertyName(() => AngepassteReduktionZeit),
                                PropertyName.GetPropertyName(() => GueltigeReduktionZeit));
            AddPropertyMapping(PropertyName.GetPropertyName(() => OriginalReduktionZeit),
                                PropertyName.GetPropertyName(() => GueltigeReduktionZeit));

            //IsReduktionManuallyChanged
            AddPropertyMapping(PropertyName.GetPropertyName(() => GueltigeReduktionZeit),
                    PropertyName.GetPropertyName(() => IsReduktionManuallyChanged));
        }

        /// <summary>
        /// Returns the Changed Value if it was changed. If not it returns the Original Value.
        /// </summary>
        public decimal? GueltigeReduktionZeit
        {
            get
            {
                if (AngepassteReduktionZeit.HasValue)
                {
                    return AngepassteReduktionZeit.Value;
                }
                return OriginalReduktionZeit;
            }

            set
            {
                if (value != OriginalReduktionZeit)
                {
                    AngepassteReduktionZeit = value;
                }
                else
                {
                    AngepassteReduktionZeit = null;
                }
            }
        }

        public bool IsReduktionManuallyChanged
        {
            get { return AngepassteReduktionZeit.HasValue && AngepassteReduktionZeit.Value != OriginalReduktionZeit; }
        }
    }
}
