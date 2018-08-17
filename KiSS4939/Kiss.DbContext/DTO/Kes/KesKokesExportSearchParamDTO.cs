using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Kes
{
    public class KesKokesExportSearchParamDTO : Bindable
    {
        private BaPerson _baPerson;
        private int _jahr;
        private KesBehoerde _kesBehoerde;
        private XUser _xUser;

        public BaPerson BaPerson
        {
            get { return _baPerson; }
            set { SetProperty(ref _baPerson, value, () => BaPerson); }
        }

        [SearchField("Person", ResourceName = "Person")]
        public string BaPersonName
        {
            get { return BaPerson != null ? BaPerson.LastNameFirstName : null; }
        }

        [SearchField("Jahr", ResourceName = "Jahr")]
        public int Jahr
        {
            get { return _jahr; }
            set { SetProperty(ref _jahr, value, () => Jahr); }
        }

        public KesBehoerde KesBehoerde
        {
            get { return _kesBehoerde; }
            set { SetProperty(ref _kesBehoerde, value, () => KesBehoerde); }
        }

        [SearchField("KESB", ResourceName = "KESB")]
        public string KesBehoerdeText
        {
            get { return KesBehoerde != null ? KesBehoerde.DisplayText : null; }
        }

        public XUser XUser
        {
            get { return _xUser; }
            set { SetProperty(ref _xUser, value, () => XUser); }
        }

        [SearchField("SAR", ResourceName = "SAR")]
        public string XUserName
        {
            get { return XUser != null ? XUser.LastNameFirstName : null; }
        }
    }
}