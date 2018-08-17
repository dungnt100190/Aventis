using System;
using System.Collections.Generic;

using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Fa
{
    public class FaDokumentAblageSearchParamDto : Bindable
    {
        #region Fields

        #region Private Fields

        private string _dokumentStichworte;

        #endregion

        #endregion

        #region Properties

        public int? DokumentAdressat { get; set; }

        // TODO Mehrsprachigkeit
        [SearchField("Adressat")]
        public string DokumentAdressatName { get; set; }

        /// <summary>
        /// 0 BaPerson
        /// 1 BaInstitution
        /// </summary>
        public bool DokumentAdressatIstInstitution { get; set; }

        public int? DokumentArt { get; set; }

        public int? DokumentAutor { get; set; }

        [SearchField("Autor")]
        public string DokumentAutorName { get; set; }

        [SearchField("Betroffene Person")]
        public string DokumentBetroffenePerson { get; set; }

        public int? DokumentBetroffenePersonId { get; set; }

        public IList<BaPerson> DokumentBetrPersonen { get; set; }

        public DateTime? DokumentDatumBis { get; set; }

        [SearchField("Dokument gültig", FollowedBy = "DokumentDatumBis")]
        public DateTime? DokumentDatumVon { get; set; }

        [SearchField("Fallträger")]
        public string DokumentFalltraeger { get; set; }

        public int? DokumentFalltraegerId { get; set; }

        public string DokumentStichworte
        {
            get
            {
                return _dokumentStichworte;
            }
            set
            {
                _dokumentStichworte = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => _dokumentStichworte);
            }
        }

        public IList<int> DokumentThemen { get; set; }

        public int? FaLeistungId { get; set; }

        public bool NurAktiveFaelle { get; set; }

        #endregion
    }
}