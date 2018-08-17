using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Kes
{
    /// <summary>
    /// Entspricht einer Massnahme und beinhaltet zusätzliche Daten für den Export.
    /// </summary>
    public class KesKokesExportMassnahmeDTO : Bindable
    {
        private string _gefaehrdungsmeldungCode;
        private KesMassnahme _kesMassnahme;

        public string GefaehrdungsmeldungCode
        {
            get { return _gefaehrdungsmeldungCode; }
            set { SetProperty(ref _gefaehrdungsmeldungCode, value, () => GefaehrdungsmeldungCode); }
        }

        public KesMassnahme KesMassnahme
        {
            get { return _kesMassnahme; }
            set { SetProperty(ref _kesMassnahme, value, () => KesMassnahme); }
        }
    }
}