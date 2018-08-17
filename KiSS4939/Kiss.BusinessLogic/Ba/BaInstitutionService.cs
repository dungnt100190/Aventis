using System;
using System.Collections.Generic;

using Kiss.BusinessLogic.LocalResources.Ba;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Ba;

namespace Kiss.BusinessLogic.Ba
{
    public class BaInstitutionService : ServiceCRUD<BaInstitution>
    {
        public virtual BaInstitution[] GetAffectedInstitutions(int baPersonId)
        {
            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                return unitOfWork.BaInstitution.GetAffectedInstitutions(baPersonId);
            }
        }

        public string GetContactInfoMultiline(BaInstitution institution)
        {
            var lines = new List<string>();

            if (!string.IsNullOrEmpty(institution.Telefon))
            {
                lines.Add(BaAdresseRes.Telefon + ": " + institution.Telefon);
            }
            if (!string.IsNullOrEmpty(institution.Telefon2))
            {
                lines.Add(BaAdresseRes.Telefon2 + ": " + institution.Telefon2);
            }
            if (!string.IsNullOrEmpty(institution.Telefon3))
            {
                lines.Add(BaAdresseRes.Telefon3 + ": " + institution.Telefon3);
            }
            if (!string.IsNullOrEmpty(institution.Fax))
            {
                lines.Add(BaAdresseRes.Fax + ": " + institution.Fax);
            }
            if (!string.IsNullOrEmpty(institution.EMail))
            {
                lines.Add(institution.EMail);
            }

            return string.Join(Environment.NewLine, lines);
        }

        /// <summary>
        /// Searches for institutions with a searchstring.
        /// Keine Einschränkung, ob User gesperrt ist oder nicht.
        /// </summary>
        /// <param name="searchString">
        ///   - Teil des Vornamens
        ///   - Teil des Nachnamens
        ///   -  * oder empty string
        ///   -  "nachname, vorname"
        ///   -  oder Teil des Logonname
        /// </param>
        /// <returns>List of Users. Empty list if no user is found.</returns>
        public List<BaInstitution> SearchFachperson(string searchString)
        {
            List<BaInstitution> institutions;

            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                var firstOrLastname = searchString.ToUpper();
                var lastName = "";
                var firstName = "";

                var firstAndLast = false;

                //Searchstring analysieren
                if (firstOrLastname.Contains(","))
                {
                    var splitted = firstOrLastname.Split(',');
                    lastName = splitted[0].Trim();
                    firstName = splitted[1].Trim();
                    firstAndLast = true;
                }
                institutions = unitOfWork.BaInstitution.FindInstitutionsByNames(lastName, firstName, firstOrLastname, firstAndLast, BaInstitutionsart.Fachperson);
            }
            return institutions;
        }

        /// <summary>
        /// Searches for institutions with a searchstring.
        /// Keine Einschränkung, ob User gesperrt ist oder nicht.
        /// </summary>
        /// <param name="searchString">
        ///   - Teil des Vornamens
        ///   - Teil des Nachnamens
        ///   -  * oder empty string
        ///   -  "nachname, vorname"
        ///   -  oder Teil des Logonname
        /// </param>
        /// <returns>List of Users. Empty list if no user is found.</returns>
        public List<BaInstitution> SearchInstitution(string searchString)
        {
            List<BaInstitution> institutions;

            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                var firstOrLastname = searchString.ToUpper();
                var lastName = "";
                var firstName = "";

                var firstAndLast = false;

                //Searchstring analysieren
                if (firstOrLastname.Contains(","))
                {
                    var splitted = firstOrLastname.Split(',');
                    lastName = splitted[0].Trim();
                    firstName = splitted[1].Trim();
                    firstAndLast = true;
                }
                institutions = unitOfWork.BaInstitution.FindInstitutionsByNames(lastName, firstName, firstOrLastname, firstAndLast, null); //Suche alle Typen: Institutionen + Fachpersonen
            }
            return institutions;
        }
    }
}