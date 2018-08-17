using Kiss.Infrastructure;

namespace Kiss.Model
{
    public partial class KbuKonto
    {
        public KbuKonto()
        {
            //DisplayedName
            AddPropertyMapping(PropertyName.GetPropertyName(() => KontoNr),
                    PropertyName.GetPropertyName(() => DisplayedName));
            AddPropertyMapping(PropertyName.GetPropertyName(() => Name),
                                PropertyName.GetPropertyName(() => DisplayedName));
        }
        #region Properties

        public string DisplayedName
        {
            get
            {
                string template = @"{0} {1}";
                return string.Format(template, KontoNr, Name);
            }
        }

        #endregion
    }
}