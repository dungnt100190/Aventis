using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.Ba;
using Kiss.Infrastructure.IoC;

namespace Kiss.UserInterface.ViewModel.SearchBox
{
    public class InstitutionSearchBoxVM : StringSearchBoxVM
    {
        public override IList<object> Search(string searchString, object searchParam)
        {
            var institutionService = Container.Resolve<BaInstitutionService>();
            var result = institutionService.SearchInstitution(searchString);
            return result.Cast<object>().ToList();
        }
    }
}