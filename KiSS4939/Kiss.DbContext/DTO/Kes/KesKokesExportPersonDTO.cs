using System.Collections.Generic;

using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Kes
{
    public class KesKokesExportPersonDTO : Bindable
    {
        private BaPerson _baPerson;
        private List<KesKokesExportMassnahmeDTO> _kesMassnahmen;

        public BaPerson BaPerson
        {
            get { return _baPerson; }
            set { SetProperty(ref _baPerson, value, () => BaPerson); }
        }

        public List<KesKokesExportMassnahmeDTO> KesMassnahmen
        {
            get { return _kesMassnahmen; }
            set { SetProperty(ref _kesMassnahmen, value, () => KesMassnahmen); }
        }
    }
}