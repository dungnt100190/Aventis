using System.Collections.Generic;

using Kiss.BusinessLogic.Ba;
using Kiss.Infrastructure.IoC;

namespace Kiss.UserInterface.ViewModel.SearchBox
{
    public class BaPersonSearchBoxVM : StringSearchBoxVM
    {
        public int? ModulId
        {
            get;
            set;
        }

        public bool NurFalltraeger
        {
            get;
            set;
        }

        public override IList<object> Search(string searchString, object searchParam)
        {
            var result = new List<object>();
            var personService = Container.Resolve<BaPersonService>();
            var persons = personService.SearchPerson(searchString, NurFalltraeger, ModulId);
            result.AddRange(persons);
            return result;
        }
    }
}