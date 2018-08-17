using System.Collections.Generic;
using System.Linq;

using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.Constant;

namespace Kiss.BusinessLogic.Ba
{
    public class BaPersonService : ServiceCRUD<BaPerson>
    {
        public virtual BaPerson[] GetAffectedPersons(int baPersonId)
        {
            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                return unitOfWork.BaPerson.GetAffectedPersons(baPersonId);
            }
        }

        /// <summary>
        /// Searches for persons with a searchstring.
        /// Keine Einschränkung, ob User gesperrt ist oder nicht.
        /// </summary>
        /// <param name="searchString">
        ///   - Teil des Vornamens
        ///   - Teil des Nachnamens
        ///   -  * oder empty string
        ///   -  "nachname, vorname"
        ///   -  oder Teil des Logonname
        /// </param>
        /// <param name="nurFalltraeger">true, if you are looking only for Fallträger</param>
        /// <param name="modulId">Wenn <paramref name="nurFalltraeger"/> true ist, wird nur nach Personen mit Leistung in diesem Modul gesucht.</param>
        /// <returns>List of Users. Empty list if no user is found.</returns>
        public List<BaPerson> SearchPerson(string searchString, bool nurFalltraeger, int? modulId = null)
        {
            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                var firstOrLastname = searchString.ToUpper();
                var lastName = "";
                var firstName = "";

                var firstAndLast = false;

                if (firstOrLastname.Equals(string.Empty) || firstOrLastname.Equals(Constant.ASTERISK))
                {
                    return unitOfWork.BaPerson.GetAllEntities().ToList();
                }

                //Searchstring analysieren
                if (firstOrLastname.Contains(","))
                {
                    var splitted = firstOrLastname.Split(',');
                    lastName = splitted[0].Trim();
                    firstName = splitted[1].Trim();
                    firstAndLast = true;
                }

                return unitOfWork.BaPerson.FindPersonByNames(lastName, firstName, firstOrLastname, firstAndLast, nurFalltraeger, modulId);
            }
        }
    }
}