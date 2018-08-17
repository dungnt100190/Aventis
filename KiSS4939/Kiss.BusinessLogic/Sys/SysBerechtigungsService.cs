using System;

using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.DTO.KissSystem;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Sys
{
    /// <summary>
    /// Service für Berechtigungsabfragen.
    /// </summary>
    public class SysBerechtigungsService : Service
    {
        #region Constructors

        private SysBerechtigungsService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Liefert die Rechte CanDelete, CanUpdate, CanInsert eines Users für eine Maske zurück.
        /// Für BiagAdmins und Admins wird immer true zurückgegeben.
        /// </summary>
        /// <param name="viewModelType">Typ der ViewModel-Klasse</param>
        /// <returns></returns>
        public MaskenRechtDTO GetUserMaskenrechtByViewModel(Type viewModelType)
        {
            var maskRight = new MaskenRechtDTO();
            var sessionService = Container.Resolve<ISessionService>();
            var authenticatedUser = sessionService.AuthenticatedUser;

            if (authenticatedUser == null)
            {
                // kein User definiert
                maskRight.CanDelete = false;
                maskRight.CanInsert = false;
                maskRight.CanUpdate = false;
            }
            else if (viewModelType == null)
            {
                // eine Maske, welche keine Rechte braucht (z.B. keine DB-Verbindung)
                maskRight.CanDelete = true;
                maskRight.CanInsert = true;
                maskRight.CanUpdate = true;
            }
            else if (authenticatedUser.IsUserAdmin || authenticatedUser.IsUserBIAGAdmin)
            {
                // User ist Admin
                maskRight.CanDelete = true;
                maskRight.CanInsert = true;
                maskRight.CanUpdate = true;
            }
            else
            {
                // Berechtigungen aus XUserGroup_Right und XUser_UserGroup holen
                using (var unitOfWork = CreateNewKissUnitOfWork())
                {
                    var typeString = string.Format("{0},{1}", viewModelType.FullName, viewModelType.Assembly.GetName().Name);
                    var right = unitOfWork.XUserGroup_Right.GetRightByViewModelName(typeString, authenticatedUser.UserID);
                    if (right == null)
                    {
                        // Kein Recht existiert
                        maskRight.CanDelete = false;
                        maskRight.CanInsert = false;
                        maskRight.CanUpdate = false;
                    }
                    else
                    {
                        // Recht existiert
                        maskRight.CanDelete = right.MayDelete;
                        maskRight.CanInsert = right.MayInsert;
                        maskRight.CanUpdate = right.MayUpdate;
                    }
                }
            }

            return maskRight;
        }

        /// <summary>
        /// Liefert das Zugriffsrecht eines Users.
        /// Für BiagAdmins und Admins wird immer true zurückgegeben.
        /// </summary>
        /// <param name="faLeistungId">FaLeistungID</param>
        /// <param name="userId">UserID</param>
        /// <returns></returns>
        public ZugriffRechtDTO GetUserZugriffrecht(int faLeistungId, int userId)
        {
            using (var unitOfWork = CreateNewKissUnitOfWork())
            {
                var zRecht = new ZugriffRechtDTO();
                zRecht.AllMembersTo(false);

                /*** Informationen aus XUser ***/
                var xUser = unitOfWork.XUser.GetById(userId);
                /*** Informationen aus FaLeistung ***/
                var faLeistung = unitOfWork.FaLeistung.GetById(faLeistungId);
                if (xUser == null || faLeistung == null)
                {
                    return zRecht;
                }

                zRecht.IsOwner = faLeistung.UserID == userId;
                zRecht.ModulID = faLeistung.ModulID;
                zRecht.Closed = faLeistung.DatumBis != null; // Wenn ein Datum gesetzt ist, ist der Fall geschlossen.

                // Ist die Leistung archiviert
                if (unitOfWork.FaLeistungArchiv.IsLeistungArchiviert(faLeistungId))
                {
                    zRecht.Archived = true;
                }

                /*** Informationen aus FaLeistungZugriff ***/
                var faLeistungZugriff = unitOfWork.FaLeistungZugriff.GetByFaLeistungAndUser(faLeistungId, userId);
                if (faLeistungZugriff != null) // Gastzugriff auf FaLeistung
                {
                    zRecht.IsGuest = true; // FaLeistungID ist auch nicht null
                    // ToDo: Wird DarfMutieren nicht ausgewertet?
                }

                /*** Informationen aus XOrgUnit_User ***/
                // Abteilung vom Besitzer
                var orgUnitUserLeistung = unitOfWork.XOrgUnit_User.GetMembershipOrgUnitIdOfUser(faLeistung.UserID);

                // Abteilung vom User
                XOrgUnit_User orgUnitUserMem = null;
                if (orgUnitUserLeistung.HasValue)
                {
                    orgUnitUserMem = unitOfWork.XOrgUnit_User.GetByUserAndOrgUnit(userId, orgUnitUserLeistung.Value);
                }

                if (orgUnitUserMem != null) // Gastzugriff auf Gruppenbasis
                {
                    zRecht.IsMember = true; // UserID ist auch nicht null
                }

                /******** Berechtigungen setzen ********/
                if (xUser.IsUserAdmin || xUser.IsUserBIAGAdmin)
                {
                    // User ist Admin
                    zRecht.IsUserAdmin = true;
                    zRecht.MayRead = true;
                    zRecht.MayInsert = true;
                    zRecht.MayUpdate = true;
                    zRecht.MayDelete = true;

                    return zRecht;
                }

                /* Check aus fnUserMayReadFall */
                if (faLeistung.ModulID == 2)
                {
                    zRecht.MayRead = true;
                }

                // Besitzer
                if (zRecht.IsOwner)
                {
                    zRecht.MayRead = true;
                    zRecht.MayInsert = true;
                    zRecht.MayUpdate = true;
                    zRecht.MayDelete = true;
                }

                // Gastzugriff auf FaLeistung
                if (faLeistungZugriff != null)
                {
                    zRecht.MayRead = true; // FaLeistungID ist auch nicht null

                    if (faLeistungZugriff.DarfMutieren)
                    {
                        zRecht.MayInsert = true;
                        zRecht.MayUpdate = true;
                        zRecht.MayDelete = true;
                    }
                }

                // Gastzugriff auf Gruppenbasis
                if (orgUnitUserMem != null)
                {
                    zRecht.MayRead = true; // UserID ist auch nicht null
                    zRecht.MayInsert = zRecht.MayInsert || orgUnitUserMem.MayInsert;
                    zRecht.MayUpdate = zRecht.MayUpdate || orgUnitUserMem.MayUpdate;
                    zRecht.MayDelete = zRecht.MayDelete || orgUnitUserMem.MayDelete;
                }

                return zRecht;
            }
        }

        ///// <summary>
        ///// Überprüft, ob der User das Spezialrecht besitzt.
        ///// Es wird auch true zurückgegeben, wenn alle Flags
        ///// (Insert, Update, Delete) auf false gesetzt sind.
        ///// Für BiagAdmins und Admins gibt diese Funktion true zurück.
        ///// Vorlage war fnUserHasRight.
        ///// </summary>
        ///// <param name="unitOfWork"></param>
        ///// <param name="userId"></param>
        ///// <param name="spezialrecht">Name des Spezialrechts</param>
        ///// <returns></returns>
        //public bool HatUserSpezialrecht(IUnitOfWork unitOfWork, int userId, string spezialrecht)
        //{
        //    unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

        //    var repositoryXUser = UnitOfWork.GetRepository<XUser>(unitOfWork);

        //    var querySpezialrecht = from x in repositoryXUser
        //                            where x.XUser_UserGroup.Any(y => y.XUserGroup.XUserGroup_Right.Any(z => z.XRight.RightName == spezialrecht))
        //                            || x.IsUserBIAGAdmin || x.IsUserAdmin
        //                            where x.UserID == userId
        //                            select x;

        //    if (querySpezialrecht.Count() > 0)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        ///// <summary>
        ///// Überprüft, ob der angemeldete User das Spezialrecht besitzt.
        ///// Es wird auch true zurückgegeben, wenn alle Flags
        ///// (Insert, Update, Delete) auf false gesetzt sind.
        ///// Für BiagAdmins und Admins gibt diese Funktion true zurück.
        ///// Vorlage war fnUserHasRight.
        ///// </summary>
        ///// <param name="unitOfWork"></param>
        ///// <param name="spezialrecht">Name des Spezialrechts</param>
        ///// <returns></returns>
        //public bool HatUserSpezialrecht(IUnitOfWork unitOfWork, string spezialrecht)
        //{
        //    int userId = 0;
        //    var sessionService = Container.Resolve<ISessionService>();
        //    if (sessionService.AuthenticatedUser != null)
        //    {
        //        userId = sessionService.AuthenticatedUser.UserID;
        //    }
        //    return HatUserSpezialrecht(unitOfWork, userId, spezialrecht);
        //}

        #endregion

        protected IKissUnitOfWork CreateNewKissUnitOfWork()
        {
            return (IKissUnitOfWork)CreateNewUnitOfWork();
        }

        #endregion
    }
}