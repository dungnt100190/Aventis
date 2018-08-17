using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.Infrastructure;

namespace Kiss.Model.DTO.Fs
{
    public class FsDienstleistungAuswSearchParamDTO : DTO
    {
        [SearchField("Datum", FollowedBy="DatumBis")]
        public DateTime DatumVon { get; set; }
        public DateTime DatumBis { get; set; }

        private string _userNameLastname;

        [SearchField("SAR")]
        public string UserNameLastname
        {
            get { return _userNameLastname; }
            set
            {
                _userNameLastname = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => UserNameLastname);
            }
        }

        public int? UserID { get; set; }

    }
}
