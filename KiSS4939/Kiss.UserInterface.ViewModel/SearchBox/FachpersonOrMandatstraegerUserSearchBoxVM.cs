using System.Collections.Generic;

using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext.DTO.Kes;
using Kiss.Infrastructure.IoC;

namespace Kiss.UserInterface.ViewModel.SearchBox
{
    public class FachpersonOrMandatstraegerUserSearchBoxVM : StringSearchBoxVM
    {
        public override IList<object> Search(string searchString, object searchParam)
        {
            var users = new List<object>();

            var userService = Container.Resolve<XUserService>();
            var userList = userService.SearchUser(searchString, true, false);
            users.AddRange(userList.ConvertAll(u => new KesMandatsfuehrendePersonDTO.FachpersonOrMandatstraeger(u)));

            var baInstitutionService = Container.Resolve<BaInstitutionService>();
            var fachpersonList = baInstitutionService.SearchFachperson(searchString);
            users.AddRange(fachpersonList.ConvertAll(f => new KesMandatsfuehrendePersonDTO.FachpersonOrMandatstraeger(f)));

            return users;
        }
    }
}