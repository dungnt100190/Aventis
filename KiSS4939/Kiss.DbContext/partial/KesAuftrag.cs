using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kiss.DbContext
{
    partial class KesAuftrag
    {
        [DataMember]
        private IEnumerable<int> _betroffenePersonenIds;

        public IEnumerable<int> BetroffenePersonenIds
        {
            get
            {
                return _betroffenePersonenIds;
            }
            set
            {
                if (_betroffenePersonenIds != value)
                {
                    _betroffenePersonenIds = value;
                    RaisePropertyChanged("BetroffenePersonenIds");
                }
            }
        }
    }
}