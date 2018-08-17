using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.Ba;
using Kiss.Infrastructure.IoC;

namespace Kiss.UserInterface.ViewModel.SearchBox
{
    public class AdressatSearchBoxVM : StringSearchBoxVM
    {
        public int? BaPersonId
        {
            get;
            set;
        }

        public override IList<object> Search(string searchString, object searchParam)
        {
            var adressatService = Container.Resolve<BaAdressatService>();
            var result = adressatService.GetAdressatList(searchString, BaPersonId);
            return result.Result.Cast<object>().ToList();
        }
    }
}