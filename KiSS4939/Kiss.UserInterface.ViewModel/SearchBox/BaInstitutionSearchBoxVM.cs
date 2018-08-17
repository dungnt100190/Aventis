using System.Collections.Generic;
using System.Linq;
using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Kes;
using Kiss.Infrastructure.IoC;

namespace Kiss.UserInterface.ViewModel.SearchBox
{
    public class BaInstitutionSearchBoxVM : StringSearchBoxVM
    {
        public override IList<object> Search(string searchString, object searchParam)
        {
            var baInstitutions = new List<object>();

            var service = Container.Resolve<BaAdressatService>();
            var serviceResult = service.GetAdressatList(searchString, null, true);

            return serviceResult.Result.OfType<object>().ToList();
        }
    }
}