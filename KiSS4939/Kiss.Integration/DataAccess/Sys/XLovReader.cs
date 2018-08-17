using System.Collections.Generic;
using System.Linq;
using Kiss.BusinessLogic.Sys;
using Kiss.Infrastructure.IoC;

namespace Kiss.Integration.DataAccess.Sys
{
    public class XLovReader
    {
        public static IDictionary<int, string> GetLovCodesByLovName(string lovName)
        {
            var xlovService = Container.Resolve<XLovService>();
            var lovCodes = xlovService.GetLovCodesByLovName(lovName, true);
            return lovCodes.ToDictionary(x => x.Code, x => x.Text);
        }
    }
}