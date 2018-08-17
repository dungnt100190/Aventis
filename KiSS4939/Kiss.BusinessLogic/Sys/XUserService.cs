using System;
using System.Collections.Generic;

using Kiss.BusinessLogic.LocalResources.System;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Sys
{
    /// <summary>
    /// Service to manage users
    /// </summary>
    public class XUserService : ServiceCRUD<XUser>
    {
        private XUserService()
        {
        }

        public string GetContactInfoMultiline(XUser user)
        {
            var lines = new List<string>();

            lines.Add(XUserRes.Geschaeftlich + ": " + (string.IsNullOrEmpty(user.Phone) ? "-" : user.Phone));
            lines.Add(XUserRes.Privat + ": " + (string.IsNullOrEmpty(user.PhonePrivat) ? "-" : user.PhonePrivat));
            lines.Add(XUserRes.Mobile + ": " + (string.IsNullOrEmpty(user.PhoneMobile) ? "-" : user.PhoneMobile));

            if (!string.IsNullOrEmpty(user.EMail))
            {
                lines.Add(user.EMail);
            }

            return string.Join(Environment.NewLine, lines);
        }

        /// <summary>
        /// Searches for users with a searchstring.
        /// Keine Einschränkung, ob User gesperrt ist oder nicht.
        /// Vorlage war MitarbeiterSuchen (Klasse DlgAuswahl)
        /// </summary>
        /// <param name="searchString">
        ///   - Teil des Vornamens
        ///   - Teil des Nachnamens
        ///   -  * oder empty string
        ///   -  "nachname, vorname"
        ///   -  oder Teil des Logonname
        /// </param>
        /// <returns>List of Users. Empty list if no user is found.</returns>
        public List<XUser> SearchUser(string searchString)
        {
            return SearchUser(searchString, false, false);
        }

        /// <summary>
        /// Sucht nach Benutzern.
        /// Vorlage war MitarbeiterSuchen (Klasse DlgAuswahl)
        /// </summary>
        /// <param name="searchString">
        ///   - Teil des Vornamens
        ///   - Teil des Nachnamens
        ///   -  * oder empty string
        ///   -  "nachname, vorname"
        ///   -  oder Teil des Logonname
        /// </param>
        /// <param name="onlyMandatstraeger">Wenn true wird nur nach Benutzern mit gesetztem IsMandatstraeger-Flag gesucht.</param>
        /// <param name="includeLocked">Wenn true wird auch nach gesperrten Benutzern gesucht.</param>
        /// <returns>Liste von Benutzern. Leere Liste, falls kein Benutzer gefunden wurde.</returns>
        public List<XUser> SearchUser(string searchString, bool onlyMandatstraeger, bool includeLocked)
        {
            List<XUser> users;

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

                var sessionService = Container.Resolve<ISessionService>();
                var isBiagAdmin = sessionService.AuthenticatedUser != null && sessionService.AuthenticatedUser.IsUserBIAGAdmin;

                users = unitOfWork.XUser.FindUsersByNames(lastName, firstName, firstOrLastname, firstAndLast, onlyMandatstraeger, includeLocked, isBiagAdmin);
            }

            return users;
        }

        public XUser SearchUser(int faLeistungID)
        {
            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                return unitOfWork.XUser.GetUserByFaLeistungID(faLeistungID);
            }
        }
    }
}