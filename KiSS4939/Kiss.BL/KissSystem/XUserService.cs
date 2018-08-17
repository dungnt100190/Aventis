using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using Kiss.BL.LocalResources.KissSystem;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.KissSystem
{
    public class XUserService : ServiceCRUDBase<XUser>
    {
        private XUserService()
        {
        }

        /// <summary>
        /// Prüft ob das mitgegebene Passwort mit dem aus der Datenbank übereinstimmt.
        /// </summary>
        /// <param name="currentUser">CurrentUser.</param>
        /// <param name="password">Das zu überprüfende Passwort im Klartext.</param>
        /// <returns></returns>
        public KissServiceResult CheckUserPassword(XUser currentUser, string password)
        {
            var pwdOldHash = new Scrambler("KiSS4").EncryptString(password);

            // User herausfiltern mit Hilfe des Logonnames
            var isAuthenticated = currentUser != null && currentUser.PasswordHash.Equals(pwdOldHash);

            if (!isAuthenticated)
            {
                return new KissServiceResult(ServiceResultType.Error, XUserServiceRes.PasswortIstFalsch);
            }

            return KissServiceResult.Ok();
        }

        public IAuthenticatedUser GetAuthenticatedSystemUser()
        {
            var user = GetUser(null, "kiss_sys");
            return new AuthenticatedUser
            {
                CreatorModifier = string.Format("{0}, {1} ({2})", user.LastName, user.FirstName, user.LogonName),
                FirstName = user.FirstName,
                IsUserAdmin = user.IsUserAdmin,
                IsUserBIAGAdmin = user.IsUserBIAGAdmin,
                LanguageCode = user.LanguageCode ?? 1,
                LastName = user.LastName,
                LogonName = user.LogonName,
                UserID = user.UserID
            };
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override XUser GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<XUser>(unitOfWork);

            var returnValue = repository.SingleOrDefault(user => user.UserID == id);

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'XUser' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Gets the currently logged in user.
        /// </summary>
        /// <returns>The user. Null if the session has no associated user.</returns>
        public XUser GetCurrentUser(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var sessionService = Container.Resolve<ISessionService>();

            if (sessionService.AuthenticatedUser == null)
            {
                return null;
            }

            return GetById(unitOfWork, sessionService.AuthenticatedUser.UserID);
        }

        /// <summary>
        /// Gets the user. If the user does not exist, it will return null.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="logonName"></param>
        /// <returns>The user. Null if no user exists with that logonname.</returns>
        public XUser GetUser(IUnitOfWork unitOfWork, string logonName)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<XUser>(unitOfWork);
            var query = from user in repository
                        where user.LogonName == logonName
                        select user;

            var returnValue = query.FirstOrDefault();

            if (returnValue != null)
            {
                SetEntityValidator(returnValue);
                unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            }

            return returnValue;
        }

        /// <summary>
        /// Checks the password strenght.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="hasSecondPassword">True if there has to be checked if the first and second password are equal.</param>
        /// <param name="passwordRetype">The second password.</param>
        /// <returns></returns>
        public KissServiceResult IsPasswordComplexCheck(string password, bool hasSecondPassword, string passwordRetype = null)
        {
            var result = KissServiceResult.Ok();

            // no empty password
            if (string.IsNullOrEmpty(password))
            {
                return new KissServiceResult(
                    ServiceResultType.Error,
                    XUserServiceRes.PasswortEingeben);
            }

            // validate password with 2nd
            if (hasSecondPassword && password != passwordRetype)
            {
                return new KissServiceResult(
                    ServiceResultType.Error,
                    XUserServiceRes.PasswoerterStimmenNichtUeberein);
            }

            // Passwortregex aus der Konfiguration lesen
            var xConfigService = Container.Resolve<XConfigService>();
            var configRegex = xConfigService.GetConfigValue(@"System\Allgemein\Passwortregex", DateTime.Now, "");
            var regex = new Regex(configRegex);
            if (!regex.IsMatch(password))
            {
                return new KissServiceResult(
                    ServiceResultType.Error,
                    XUserServiceRes.PasswortErfuelltKomplexitaetsregelnNicht);
            }

            return result;
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork, XUser dataToSave)
        {
            SystemService.NewHistoryVersion(null);
            return base.SaveData(unitOfWork, dataToSave);
        }

        /// <summary>
        /// Speichert das neue Passwort für den gegebenen User.
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="passwordOld">Altes Passwort zum prüfen obs mit der DB übereinstimmt.</param>
        /// <param name="passwordNew">Neues Passwort zum speichern im Klartext.</param>
        /// <param name="passwordRetype">Wiederholtes, neues Passwort zum speichern im Klartext. </param>
        /// <returns></returns>
        public KissServiceResult SaveNewPassword(IUnitOfWork unitOfWork, string passwordOld, string passwordNew, string passwordRetype)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var currentUser = GetCurrentUser(unitOfWork);

            // Ob das alte passwort übereinstimmt
            var serviceResult = CheckUserPassword(currentUser, passwordOld);

            // Ob die neuen Passwörter übereinstimmen und die Komplexität erfüllt ist
            if (serviceResult.IsOk)
            {
                serviceResult = IsPasswordComplexCheck(passwordNew, true, passwordRetype);
            }

            // Speichern des neuen Passwortes
            if (serviceResult.IsOk)
            {
                try
                {
                    currentUser.PasswordHash = new Scrambler("KiSS4").EncryptString(passwordNew);
                    SaveData(unitOfWork, currentUser);
                }
                catch (Exception ex)
                {
                    return new KissServiceResult(
                        ex,
                        PropertyName.GetPropertyName(() => XUserServiceRes.FehlerBeimSpeichernNeuesPasswort),
                        XUserServiceRes.FehlerBeimSpeichernNeuesPasswort);
                }
            }

            return serviceResult;
        }

        /// <summary>
        /// Searches for users with a searchstring.
        /// Keine Einschränkung, ob User gesperrt ist oder nicht.
        /// Vorlage war MitarbeiterSuchen (Klasse DlgAuswahl)
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="searchString">
        ///   - Teil des Vornamens
        ///   - Teil des Nachnamens
        ///   -  * oder empty string
        ///   -  "nachname, vorname"
        ///   -  oder Teil des Logonname
        /// </param>
        /// <returns>List of Users. Empty list if no user is found.</returns>
        public List<XUser> SearchUser(IUnitOfWork unitOfWork, string searchString)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var userRepository = UnitOfWork.GetRepository<XUser>(unitOfWork);

            string firstOrLastname = searchString.ToUpper();
            string lastName = "";
            string firstName = "";

            bool firstAndLast = false;

            //Searchstring analysieren
            if (firstOrLastname.Contains(","))
            {
                string[] splitted = firstOrLastname.Split(',');
                lastName = splitted[0].Trim();
                firstName = splitted[1].Trim();
                firstAndLast = true;
            }

            var query = from user in userRepository

                        //User gibt entweder Vorname, Nachname oder Logonname an
                        where firstAndLast || (user.FirstName.ToUpper().StartsWith(firstOrLastname)
                            || user.LastName.ToUpper().StartsWith(firstOrLastname)
                            || user.LogonName.ToUpper().StartsWith(firstOrLastname)
                            || searchString == "*")

                        //User gibt Vor und Nachnahme an.
                        where !firstAndLast || (user.FirstName.ToUpper().StartsWith(firstName) && user.LastName.ToUpper().StartsWith(lastName))

                        select user;

            var users = query.ToList(); //geht besser zum debuggen ObjectQuery.ToTranceString();

            users.ForEach(SetEntityValidator);
            users = new List<XUser>(users.OrderBy(x => x.LastNameFirstName));

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return users;
        }
    }
}