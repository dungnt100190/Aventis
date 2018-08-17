using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Kes
{
    /// <summary>
    /// Wird für die Anzeige auf der Maske verwendet.
    /// </summary>
    public class KesKokesExportMassnahmeListDTO : Bindable
    {
        private string _fehler;
        private KesMassnahme _kesMassnahme;

        /// <summary>
        /// Falls beim Export ein Fehler bei dieser Massnahme generiert wird, wird er hier angezeigt.
        /// </summary>
        public string Fehler
        {
            get { return _fehler; }
            set { SetProperty(ref _fehler, value, () => Fehler); }
        }

        public KesMassnahme KesMassnahme
        {
            get { return _kesMassnahme; }
            set { SetProperty(ref _kesMassnahme, value, () => KesMassnahme); }
        }
    }
}