using System;
using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Fs
{
    public class FsDienstleistungAuswSearchParamDTO : Infrastructure.Bindable
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
