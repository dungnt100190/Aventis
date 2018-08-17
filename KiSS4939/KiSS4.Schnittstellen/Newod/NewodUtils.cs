using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiSS4.DB;
using KiSS4.Schnittstellen.Newod.Service;

namespace KiSS4.Schnittstellen.Newod
{
    public class NewodUtils
    {
        public static void ClearNewodMapping(int baPersonID, int newodPersonID)
        {
            PersonService svc = new PersonService();

            DBUtil.ExecSQLThrowingException(@"
                    DELETE FROM BaPerson_NewodPerson
                    WHERE BaPersonID = {0};", baPersonID);

            svc.ClearNewodBinding(newodPersonID.ToString());
        }
    }
}