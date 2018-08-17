using System;
using System.Linq;

using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Model.DTO.KissSystem;

namespace Kiss.BL.KissSystem
{
    /// <summary>
    /// Service für Berechtigungsabfragen.
    /// </summary>
    public class BerechtigungsService : ServiceBase
    {
        #region Constructors

        private BerechtigungsService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Liefert die Rechte CanDelete, CanUpdate, CanInsert eines Users für eine Maske zurück.
        /// Für BiagAdmins und Admins wird immer true zurückgegeben.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="className">Name der Klasse</param>
        /// <returns></returns>
        public MaskenRechtDTO GetUserMaskenrecht(IUnitOfWork unitOfWork, string className)
        {
            var mRecht = new MaskenRechtDTO();
            var iuserService = Container.Resolve<ISessionService>();

            if (iuserService.AuthenticatedUser == null)
            {
                // kein User definiert
                mRecht.CanDelete = false;
                mRecht.CanInsert = false;
                mRecht.CanUpdate = false;
            }
            else if (string.IsNullOrEmpty(className))
            {
                // eine Maske, welche keine Rechte braucht (z.B. keine DB-Verbindung)
                mRecht.CanDelete = true;
                mRecht.CanInsert = true;
                mRecht.CanUpdate = true;
            }
            else if (iuserService.AuthenticatedUser.IsUserAdmin || iuserService.AuthenticatedUser.IsUserBIAGAdmin)
            {
                // User ist Admin
                mRecht.CanDelete = true;
                mRecht.CanInsert = true;
                mRecht.CanUpdate = true;
            }
            else
            {
                // Berechtigungen aus XUserGroup_Right und XUser_UserGroup holen
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
                var repositoryXUserGroupRight = UnitOfWork.GetRepository<XUserGroup_Right>(unitOfWork);
                var repositoryXUserUserGroup = UnitOfWork.GetRepository<XUser_UserGroup>(unitOfWork);

                var queryRecht = from x in repositoryXUserGroupRight
                                 join y in repositoryXUserUserGroup on x.UserGroupID equals y.UserGroupID
                                 where x.ClassName == className
                                 where y.UserID == iuserService.AuthenticatedUser.UserID
                                 select x;

                var listRecht = queryRecht.ToList().FirstOrDefault();
                if (listRecht == null)
                {
                    // Kein Recht existiert
                    mRecht.CanDelete = false;
                    mRecht.CanInsert = false;
                    mRecht.CanUpdate = false;
                }
                else
                {
                    // Recht existiert
                    mRecht.CanDelete = listRecht.MayDelete;
                    mRecht.CanInsert = listRecht.MayInsert;
                    mRecht.CanUpdate = listRecht.MayUpdate;
                }
            }

            return mRecht;
        }

        /// <summary>
        /// Liefert das Zugriffsrecht eines Users.
        /// Für BiagAdmins und Admins wird immer true zurückgegeben.
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="faLeistungId">FaLeistungID</param>
        /// <param name="userId">UserID</param>
        /// <returns></returns>
        public ZugriffRechtDTO GetUserZugriffrecht(IUnitOfWork unitOfWork, int faLeistungId, int userId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repoFaLeistung = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            var repoFaLeistungArchiv = UnitOfWork.GetRepository<FaLeistungArchiv>(unitOfWork);
            var repoFaLeistungZugriff = UnitOfWork.GetRepository<FaLeistungZugriff>(unitOfWork);
            var repoXOrgUnitUser = UnitOfWork.GetRepository<XOrgUnit_User>(unitOfWork);
            var repoXUser = UnitOfWork.GetRepository<XUser>(unitOfWork);

            var zRecht = new ZugriffRechtDTO();
            zRecht.AllMembersTo(false);

            /*** Informationen aus XUser ***/
            var xUser = (from usr in repoXUser
                         where usr.UserID == userId
                         select new
                         {
                             usr.UserID,
                             usr.IsUserAdmin,
                             usr.IsUserBIAGAdmin
                         }).SingleOrDefault();

            if (xUser == null)
            {
                return zRecht;
            }

            /*** Informationen aus FaLeistung ***/
            var faLeistung = (from lei in repoFaLeistung
                              where lei.FaLeistungID == faLeistungId
                              select new
                              {
                                  lei.ModulID,
                                  lei.UserID,
                                  lei.DatumBis
                              }).SingleOrDefault();

            if (faLeistung == null)
            {
                return zRecht;
            }

            zRecht.IsOwner = faLeistung.UserID == userId;
            zRecht.ModulID = faLeistung.ModulID;
            zRecht.Closed = faLeistung.DatumBis != null; // Wenn ein Datum gesetzt ist, ist der Fall geschlossen.

            // Ist die Leistung archiviert
            if (repoFaLeistungArchiv.Any(x => x.FaLeistungID == faLeistungId && x.CheckOut == null))
            {
                zRecht.Archived = true;
            }

            /*** Informationen aus FaLeistungZugriff ***/
            var faLeistungZugriff = (from flz in repoFaLeistungZugriff
                                     where flz.FaLeistungID == faLeistungId
                                     where flz.UserID == userId
                                     where !flz.DatumVon.HasValue || flz.DatumVon.Value <= DateTime.Today
                                     where !flz.DatumBis.HasValue || flz.DatumBis.Value >= DateTime.Today
                                     select new
                                     {
                                         flz.FaLeistungID,
                                         flz.DarfMutieren
                                     }).FirstOrDefault();

            if (faLeistungZugriff != null) // Gastzugriff auf FaLeistung
            {
                zRecht.IsGuest = true; // FaLeistungID ist auch nicht null
            }

            /*** Informationen aus XOrgUnit_User ***/
            // Abteilung vom Besitzer
            var orgUnitUserLeistung = (from org in repoXOrgUnitUser
                                       where org.UserID == faLeistung.UserID
                                       where org.OrgUnitMemberCode == 2 // Mitglied
                                       select new
                                       {
                                           org.OrgUnitID
                                       }).SingleOrDefault();

            dynamic orgUnitUserMem = null;

            if (orgUnitUserLeistung != null)
            {
                // Abteilung vom User
                orgUnitUserMem = (from mem in repoXOrgUnitUser
                                  where mem.OrgUnitID == orgUnitUserLeistung.OrgUnitID
                                  where mem.UserID == userId
                                  select new
                                  {
                                      mem.MayDelete,
                                      mem.MayUpdate,
                                      mem.MayInsert
                                  }).FirstOrDefault();

                if (orgUnitUserMem != null) // Gastzugriff auf Gruppenbasis
                {
                    zRecht.IsMember = true; // UserID ist auch nicht null
                }
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

        /// <summary>
        /// Überprüft, ob der User das Spezialrecht besitzt.
        /// Es wird auch true zurückgegeben, wenn alle Flags
        /// (Insert, Update, Delete) auf false gesetzt sind.
        /// Für BiagAdmins und Admins gibt diese Funktion true zurück.
        /// Vorlage war fnUserHasRight.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userId"></param>
        /// <param name="spezialrecht">Name des Spezialrechts</param>
        /// <returns></returns>
        public bool HatUserSpezialrecht(IUnitOfWork unitOfWork, int userId, string spezialrecht)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repositoryXUser = UnitOfWork.GetRepository<XUser>(unitOfWork);

            var querySpezialrecht = from x in repositoryXUser
                                    where x.XUser_UserGroup.Any(y => y.XUserGroup.XUserGroup_Right.Any(z => z.XRight.RightName == spezialrecht))
                                    || x.IsUserBIAGAdmin || x.IsUserAdmin
                                    where x.UserID == userId
                                    select x;

            if (querySpezialrecht.Count() > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Überprüft, ob der angemeldete User das Spezialrecht besitzt.
        /// Es wird auch true zurückgegeben, wenn alle Flags
        /// (Insert, Update, Delete) auf false gesetzt sind.
        /// Für BiagAdmins und Admins gibt diese Funktion true zurück.
        /// Vorlage war fnUserHasRight.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="spezialrecht">Name des Spezialrechts</param>
        /// <returns></returns>
        public bool HatUserSpezialrecht(IUnitOfWork unitOfWork, string spezialrecht)
        {
            int userId = 0;
            var sessionService = Container.Resolve<ISessionService>();
            if (sessionService.AuthenticatedUser != null)
            {
                userId = sessionService.AuthenticatedUser.UserID;
            }
            return HatUserSpezialrecht(unitOfWork, userId, spezialrecht);
        }

        #endregion

        #endregion
    }
}