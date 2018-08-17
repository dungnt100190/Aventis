using System.Collections.Generic;

using Kiss.BusinessLogic.Sys;
using Kiss.Infrastructure.IoC;

namespace Kiss.UserInterface.ViewModel.SearchBox
{
    public class UserSearchBoxVM : StringSearchBoxVM
    {
        public override IList<object> Search(string searchString, object searchParam)
        {
            var users = new List<object>();

            var userService = Container.Resolve<XUserService>();
            var userList = userService.SearchUser(searchString);
            users.AddRange(userList);

            return users;
        }
    }
}