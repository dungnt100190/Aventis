using System.Collections.Generic;

using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Kes
{
    /// <summary>
    /// Dies ist das Resultat-DTO für den Export.
    /// </summary>
    public class KesKokesExportDTO : Bindable
    {
        private IList<KesKokesExportBehoerdeDTO> _behoerdeDTOs;
        private IList<KesKokesExportMassnahmeListDTO> _kesMassnahmeDTOs;

        /// <summary>
        /// Beinhaltet min. ein Behörde-DTO inklusive aller Massnahmen und an den Massnahmen angehängten Daten.
        /// Wird für die Durchführung des Exports benötigt.
        /// </summary>
        public IList<KesKokesExportBehoerdeDTO> BehoerdeDTOs
        {
            get { return _behoerdeDTOs; }
            set { SetProperty(ref _behoerdeDTOs, value, () => BehoerdeDTOs); }
        }

        /// <summary>
        /// Beinhaltet alle Massnahmen, die auch in <see cref="BehoerdeDTOs"/> abgelegt sind.
        /// Wird für die Anzeige auf der Maske benötigt.
        /// </summary>
        public IList<KesKokesExportMassnahmeListDTO> KesMassnahmeDTOs
        {
            get { return _kesMassnahmeDTOs; }
            set { SetProperty(ref _kesMassnahmeDTOs, value, () => KesMassnahmeDTOs); }
        }
    }
}