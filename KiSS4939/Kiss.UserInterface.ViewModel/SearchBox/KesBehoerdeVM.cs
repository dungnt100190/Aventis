using System.Collections.Generic;

using Kiss.BusinessLogic.Kes;
using Kiss.Infrastructure.IoC;

namespace Kiss.UserInterface.ViewModel.SearchBox
{
    public class KesBehoerdeSearchBoxVM : StringSearchBoxVM
    {
        public override IList<object> Search(string searchString, object searchParam)
        {
            var kesbehoerdes = new List<object>();
            string kanton = (searchParam != null) ? searchParam.ToString() : string.Empty;

            var kesbehoerdeService = Container.Resolve<KesBehoerdeService>();
            var kesbehoerdeList = kesbehoerdeService.SearchKesBehoerde(searchString, kanton);
            kesbehoerdes.AddRange(kesbehoerdeList);

            return kesbehoerdes;
        }
    }
}