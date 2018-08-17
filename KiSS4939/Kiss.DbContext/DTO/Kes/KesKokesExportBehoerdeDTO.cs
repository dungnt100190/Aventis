using System.Collections.Generic;

using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Kes
{
    public class KesKokesExportBehoerdeDTO : Bindable
    {
        private KesBehoerde _kesBehoerde;
        private List<KesKokesExportPersonDTO> _personDtoList;

        public KesBehoerde KesBehoerde
        {
            get { return _kesBehoerde; }
            set { SetProperty(ref _kesBehoerde, value, () => KesBehoerde); }
        }

        public List<KesKokesExportPersonDTO> PersonDtoList
        {
            get { return _personDtoList; }
            set { SetProperty(ref _personDtoList, value, () => PersonDtoList); }
        }
    }
}