using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KiSS4.DB;

namespace Kiss.Integration
{
    public class UserRight
    {
        public static bool UserHasRight(string className)
        {
            return DBUtil.UserHasRight(className);
        }
    }
}