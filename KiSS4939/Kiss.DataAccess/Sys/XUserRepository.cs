using System.Collections.Generic;
using System.Linq;

using Kiss.DbContext;
using Kiss.DbContext.DTO.Fs;
using Kiss.Infrastructure;

namespace Kiss.DataAccess.Sys
{
    public class XUserRepository : Repository<XUser>
    {
        #region Constructors

        public XUserRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        // nur für UnitTesting
        protected XUserRepository()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Searches a User by its Name.
        /// </summary>
        /// <param name="lastName">lastName</param>
        /// <param name="firstName">firstName</param>
        /// <param name="firstOrLastname">firstOrLastname</param>
        /// <param name="firstAndLast">firstAndLast</param>
        /// <param name="onlyMandatstraeger"></param>
        /// <param name="includeLocked"></param>
        /// <param name="includeBiagAdmins"></param>
        /// <returns></returns>
        public List<XUser> FindUsersByNames(string lastName, string firstName, string firstOrLastname, bool firstAndLast, bool onlyMandatstraeger, bool includeLocked, bool includeBiagAdmins)
        {
            return DbSet.Where(usr => (firstAndLast || usr.FirstName.ToUpper().StartsWith(firstOrLastname)
                                            || usr.LastName.ToUpper().StartsWith(firstOrLastname)
                                            || usr.LogonName.ToUpper().StartsWith(firstOrLastname)
                                            || firstOrLastname == "*"))
                        .Where(usr => (!firstAndLast || (usr.FirstName.ToUpper().StartsWith(firstName) && usr.LastName.ToUpper().StartsWith(lastName))))
                        .Where(x => includeLocked || !x.IsLocked)
                        .Where(x => includeBiagAdmins || !x.IsUserBIAGAdmin)
                        .WhereIf(onlyMandatstraeger, x => x.IsMandatsTraeger)
                        .OrderBy(x => x.LastName)
                        .ThenBy(x => x.FirstName)
                        .ToList();
        }

        public FsMitarbeiterVefuegbareArbeitszeitDTO[] GetMitarbeiterArbeitszeit(MonthYear month, int? userID)
        {
            var timePeriod = new TimePeriod(month);

            return DbSet
                .Where(
                    usr => userID.HasValue
                               ? //wenn eine UserID übergeben wurde, filtern auf diese UserID
                           userID.Value == usr.UserID
                               : // wurde keine UserID übergeben, nur Benutzer anzeigen mit einer zugewiesenen Phase im Abfrage-Zeitraum
                           usr.FaPhase.Any(
                               pha =>
                               pha.DatumVon <= timePeriod.From &&
                               (!pha.DatumBis.HasValue || pha.DatumBis.Value >= timePeriod.To)))
                .Where(usr => !usr.IsLocked)
                .Select(
                    usr => new FsMitarbeiterVefuegbareArbeitszeitDTO
                    {
                        User = usr,
                        Reduktionen = usr.FsReduktionMitarbeiter.Where(red => red.Jahr == month.Year && red.Monat == month.Month),
                        Sollstunden = usr.BDESollStundenProJahr_XUser.Where(std => std.Jahr == month.Year),
                        Pensen =
                            usr.BDEPensum_XUser.Where(
                                pns => pns.DatumVon <= timePeriod.From && (!pns.DatumBis.HasValue || pns.DatumBis.Value >= timePeriod.To)),
                        OrgName = usr.XOrgUnit_User.FirstOrDefault(ouu => ouu.OrgUnitMemberCode == 2) == null
                                      ? null
                                      : usr.XOrgUnit_User.FirstOrDefault(ouu => ouu.OrgUnitMemberCode == 2).XOrgUnit.ItemName
                    })
                .ToArray();
        }

        /// <summary>
        /// Searches a User by FaleistungID.
        /// </summary>
        /// <param name="faLeistungID">faLeistungID</param>
        /// <returns>XUser</returns>
        public XUser GetUserByFaLeistungID(int faLeistungID)
        {
            var faLeistungSet = DbContext.Set<FaLeistung>().AsQueryable();
            int userID = faLeistungSet.Single(fal => fal.FaLeistungID == faLeistungID).UserID;
            return DbSet.Single(usr => usr.UserID == userID);
        }

        #endregion

        #endregion
    }
}