using Kiss.Infrastructure;

namespace Kiss.Model
{
    public partial class KbuZahlungseingang
    {
        public KbuZahlungseingang()
        {
            AddPropertyMapping(PropertyName.GetPropertyName(() => SstZahlungseingang),
                                PropertyName.GetPropertyName(() => SstZahlungseingangSingleItem));
        }

        public SstZahlungseingang SstZahlungseingangSingleItem
        {
            get
            {
                var zahlungseingaenge = SstZahlungseingang;
                if (zahlungseingaenge == null || zahlungseingaenge.Count == 0)
                {
                    return null;
                }

                return zahlungseingaenge[0];
            }
        }
    }
}
