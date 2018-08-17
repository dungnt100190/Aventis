using System.Linq;

using Kiss.DbContext;

namespace Kiss.DataAccess.Sys
{
    public class XUserGroup_RightRepository : Repository<XUserGroup_Right>
    {
        public XUserGroup_RightRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public XUserGroup_Right GetRight(string className, int userID)
        {
            return DbSet
                   .FirstOrDefault(grr => grr.ClassName == className &&
                                          grr.XUserGroup.XUser_UserGroup.Any(uug => uug.UserID == userID));
        }

        public XUserGroup_Right GetRightByViewModelName(string classNameViewModel, int userID)
        {
            var grouped = (from grr in DbSet
                           where grr.XClass.ClassNameViewModel == classNameViewModel
                           where grr.MayInsert || grr.MayUpdate || grr.MayDelete
                           where grr.XUserGroup.XUser_UserGroup.Any(uug => uug.UserID == userID)
                           group grr by grr.ClassName
                               into grp
                               select new
                               {
                                   ClassName = grp.Key,
                                   Rights = grp,
                               }).ToList();

            var right = grouped.Select(
                grp => new XUserGroup_Right
                {
                    ClassName = grp.ClassName,
                    MayInsert = grp.Rights.Max(x => x.MayInsert),
                    MayUpdate = grp.Rights.Max(x => x.MayUpdate),
                    MayDelete = grp.Rights.Max(x => x.MayDelete),
                }).FirstOrDefault();

            return right;
        }
    }
}