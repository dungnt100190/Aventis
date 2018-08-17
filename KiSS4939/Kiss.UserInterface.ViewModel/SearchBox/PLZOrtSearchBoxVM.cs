using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.Ba;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;

namespace Kiss.UserInterface.ViewModel.SearchBox
{
    public class PLZOrtSearchBoxVM
    {
        public static List<BaPLZ> SearchByOrt(string searchString)
        {
            var baPlzService = Container.Resolve<BaPlzService>();
            var allEntities = baPlzService.GetAllEntities();

            searchString = searchString.Replace('?', '*');
            searchString = searchString.Replace('%', '*');

            return allEntities.Where(plz => plz.Name.ToUpper().StartsWith(searchString.ToUpper())).ToList();
        }

        public static List<BaPLZ> SearchByPLZ(string searchString)
        {
            var baPlzService = Container.Resolve<BaPlzService>();
            var allEntities = baPlzService.GetAllEntities();

            searchString = searchString.Replace('?', '*');
            searchString = searchString.Replace('%', '*');

            return allEntities.Where(plz => plz.PLZ.ToString().StartsWith(searchString)).ToList();
        }
    }
}