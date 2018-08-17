using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

using KiSS.DBScheme;
using KiSS4.DB;
using log4net;
using log4net.Config;

namespace KiSS4.Schnittstellen.Abacus.Mitarbeiter
{
    /// <summary>
    /// KiSS-Abacus connection, write data from Abacus into KiSS-database
    /// </summary>
    public class KAConWrite
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog Logger = LogManager.GetLogger(typeof(KAConWrite));

        #endregion Private Static Fields

        #region Private Constant/Read-Only Fields

        private readonly IList<int> _listMaUpdated = new List<int>();
        private readonly TypeHelper _typeHelper = new TypeHelper();

        #endregion Private Constant/Read-Only Fields

        #region Private Fields

        /// <summary>
        /// Key ist mitarbeiternummer.
        /// </summary>
        private IDictionary<int, MitarbeiterDTO> _abaCoWorkerDs;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        static KAConWrite()
        {
            XmlConfigurator.Configure();
        }

        public KAConWrite()
        {
            // nothing to do yet
        }

        public KAConWrite(IDictionary<int, MitarbeiterDTO> ds)
            : this()
        {
            _abaCoWorkerDs = ds;
        }

        #endregion Constructors

        #region EventHandlers

        /// <summary>
        /// inserts a new Data Row for 'Ferienanspruch' in Table 'BDEFeriananspruch_XUser.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="year"></param>
        /// <param name="newDate"></param>
        /// <param name="newUnit"></param>
        private void InsertBDEFeriananspruch_XUser(Int32 userId, Int32 year, DateTime newDate, Double newUnit)
        {
            Logger.DebugFormat("InsertBDEFeriananspruch_XUser - userId:{0}, year:{1}, newDate:{2}, newUnit:{3}", userId, year, newDate, newUnit);

            DBUtil.ExecSQLThrowingException(
                @"
                    INSERT INTO dbo.BDEFerienanspruch_XUser (UserID, Jahr, DatumVon, FerienanspruchStdProJahr)
                    VALUES ({0}, {1}, {2}, {3});",
                userId, year, newDate, newUnit);

            KAConUtil.InsertAbaLog(Session.User.UserID, 0,
                                   "UserID '" + userId + "', Ferienanspruch '" + newUnit + "', Datum '" +
                                   newDate.ToShortDateString() + "'", null, null, "FerienAnspruch inserted");
        }

        /// <summary>
        /// takes the youngest unterminated row for this user but for the years before the current year and
        /// in case it founds one, it terminates it with '31.12.yyyy' where yyyy is the value of the field 'Jahr'.
        /// terminate = value in field 'DatumBis'. unterminated = field 'DatumBis' is NULL
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="currentYear"></param>
        private void TerminateBDEAusbezahlteUeberstunden_XUser(Int32 userId, Int32 currentYear)
        {
            //we just terminate the youngest row before with 31.12.yyyy where yyyy is the youngest year
            //encountered in the table for this user with unterminated DatumBis value
            SqlQuery sq =
                DBUtil.OpenSQL(
                    @"
                    SELECT *
                    FROM dbo.BDEAusbezahlteUeberstunden_XUser WITH (READUNCOMMITTED)
                    WHERE UserID = {0} AND
                          Jahr < {1} AND
                          DatumBis is NULL
                    ORDER BY Jahr DESC",
                    userId, currentYear);

            sq.First();

            if (sq.Count > 0)
            {
                if (!KAConUtil.IsDBNull(sq["Jahr"]))
                {
                    var key = Convert.ToInt32(sq["BDEAusbezahlteUeberstunden_XUserID"]);
                    var year = Convert.ToInt32(sq["Jahr"]);
                    var new31Dez = new DateTime(year, 12, 31);

                    DBUtil.ExecSQLThrowingException(
                        @"
                        UPDATE dbo.BDEAusbezahlteUeberstunden_XUser
                        SET DatumBis = {0}
                        WHERE BDEAusbezahlteUeberstunden_XUserID = {1} AND
                              Jahr = {2};",
                        new31Dez, key, year);
                }
            }
        }

        /// <summary>
        /// takes the youngest unterminated row for this user but for the years before the current year and
        /// in case it founds one, it terminates it with '31.12.yyyy' where yyyy is the value of the field 'Jahr'.
        /// terminate = value in field 'DatumBis'. unterminated = field 'DatumBis' is NULL
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="currentYear"></param>
        private void TerminateBDEFeriananspruch_XUser(Int32 userId, Int32 currentYear)
        {
            //we just terminate the youngest row before with 31.12.yyyy where yyyy es the youngest year
            //encountered in the table for this user with unterminated DatumBis value
            var sq =
                DBUtil.OpenSQL(
                    @"
                    SELECT *
                    FROM dbo.BDEFerienanspruch_XUser WITH (READUNCOMMITTED)
                    WHERE UserID = {0} AND
                          Jahr < {1} AND
                          DatumBis IS NULL
                    ORDER BY Jahr DESC",
                    userId, currentYear);

            sq.First();

            if (sq.Count > 0)
            {
                if (!KAConUtil.IsDBNull(sq["Jahr"]))
                {
                    var key = Convert.ToInt32(sq["BDEFerienanspruch_XUserID"]);
                    var year = Convert.ToInt32(sq["Jahr"]);
                    var new31Dez = new DateTime(year, 12, 31);

                    DBUtil.ExecSQLThrowingException(
                        @"
                        UPDATE dbo.BDEFerienanspruch_XUser
                        SET DatumBis = {0}
                        WHERE BDEFerienanspruch_XUserID = {1} AND
                              Jahr = {2};",
                        new31Dez, key, year);
                }
            }
        }

        #endregion EventHandlers

        #region Methods

        #region Public Methods

        public IDictionary<int, MitarbeiterDTO> GetAbaDataSet()
        {
            return _abaCoWorkerDs;
        }

        public int GetAmountNewMa()
        {
            return (KAConUtil.GetAmountCoWorkers(_abaCoWorkerDs) - _listMaUpdated.Count);
        }

        /// <summary>
        /// returns list of non inserted coworkers
        /// </summary>
        /// <returns>Liste mit Mitarbeiternummern</returns>
        public IList<int> GetListOfNonUpdatedMa()
        {
            var al = new List<int>();

            foreach (var mitarbeiter in _abaCoWorkerDs.Values)
            {
                var maNr = (int)mitarbeiter.MitarbeiterNummer;

                //#8924 Do not insert (new) Abacus-Mitarbeiter with an Austrittsdatum
                if (maNr != 0 && !mitarbeiter.AustrittsDatum.HasValue)
                {
                    if (!_listMaUpdated.Contains(maNr))
                    {
                        al.Add(maNr);
                    }
                }
            }

            return al;
        }

        public void Insert(IDictionary<int, MitarbeiterDTO> abaDS, Int32 mitarbeiterNr, Int32 selectedYear,
            Int32 selectedMonth)
        {
            if (abaDS != null)
            {
                _abaCoWorkerDs = abaDS;
            }

            if (_abaCoWorkerDs == null)
            {
                throw new NullReferenceException("AbaCoWorkerDs dataset is empty, cannot continue.");
            }

            MitarbeiterDTO mitarbeiter;
            abaDS.TryGetValue(mitarbeiterNr, out mitarbeiter);

            if (mitarbeiter == null)
            {
                throw new NullReferenceException(String.Format("No AbaWorker found with employee number '{0}'",
                                                               mitarbeiterNr));
            }

            var newLohnTyp = String.Empty;
            var userId = InsertXUser(mitarbeiter, mitarbeiterNr, out newLohnTyp, selectedYear, selectedMonth);

            if (newLohnTyp == "M")
            {
                UpdatePensum(mitarbeiter, userId);
                UpdateSollStunden(mitarbeiter, userId);
                UpdateFerienAnspruch(mitarbeiter, userId);
                UpdateAusbezUeberstunden(mitarbeiter, userId);
                UpdateFerienKuerzungen(mitarbeiter, userId);
                UpdateSollProMonatJahr(mitarbeiter, userId);
            }
        }

        public void InsertUpdatedMaIfExistingInAbacus(IDictionary<int, MitarbeiterDTO> mitarbeiterList, Int32 maNr)
        {
            MitarbeiterDTO mitarbeiter;
            mitarbeiterList.TryGetValue(maNr, out mitarbeiter);

            if (mitarbeiter != null)
            {
                if (_listMaUpdated.Contains(maNr))
                {
                    Logger.Error(maNr + " is twice in KiSS!");
                }

                _listMaUpdated.Add(maNr);
            }
        }

        public void ResetUpdatedMitarbeiterList()
        {
            _listMaUpdated.Clear();
        }

        public void SetAbaDataSet(IDictionary<int, MitarbeiterDTO> tds)
        {
            _abaCoWorkerDs = tds;
        }

        public void Update(IDictionary<int, MitarbeiterDTO> abaDS, Int32 idNr, Int32 maNr)
        {
            if (abaDS != null)
            {
                _abaCoWorkerDs = abaDS;
            }

            if (_abaCoWorkerDs == null)
            {
                throw new NullReferenceException("AbaCoWorkerDs dataset is empty, cannot continue.");
            }

            DataRow kissXUserDataRow = KAConUtil.GetKissXUserWithId(idNr);

            if (kissXUserDataRow == null)
            {
                throw new NullReferenceException(String.Format("No KiSS user found with MitarbeiterNr '{0}'", maNr));
            }

            MitarbeiterDTO mitarbeiter;
            abaDS.TryGetValue(maNr, out mitarbeiter);

            if (mitarbeiter != null)
            {
                if (_listMaUpdated.Contains(maNr))
                {
                    Logger.Error(maNr + " is twice in KiSS!");
                }

                _listMaUpdated.Add(maNr);

                var newLohnTyp = String.Empty;
                var userID = UpdateXUser(mitarbeiter, maNr, out newLohnTyp);

                if (newLohnTyp == "M" && userID > 0)
                {
                    UpdatePensum(mitarbeiter, userID);
                    UpdateSollStunden(mitarbeiter, userID);
                    UpdateFerienAnspruch(mitarbeiter, userID);
                    UpdateAusbezUeberstunden(mitarbeiter, userID);
                    UpdateFerienKuerzungen(mitarbeiter, userID);
                    UpdateSollProMonatJahr(mitarbeiter, userID);
                }
            }
        }

        /// <summary>
        /// inserts or updates the soll Stunden for each month and the total for the current year provided by abacus
        /// </summary>
        /// <param name="adr"></param>
        /// <param name="userId"></param>
        public void UpdateSollProMonatJahr(MitarbeiterDTO adr, Int32 userId)
        {
            if (adr == null)
            {
                throw new NullReferenceException("Abacus datarow is empty.");
            }

            try
            {
                Int32 year = adr.StichJahr;

                // begin new histroy entry
                DBUtil.NewHistoryVersion();
                var kcr = new KAConRead(_abaCoWorkerDs);

                var amountSMJE = kcr.SollStundenMonatJahrExist(adr, userId);
                if (amountSMJE > 0)
                {
                    if (amountSMJE > 1)
                    {
                        //check, if there are more than one, error
                        throw new Exception(
                            String.Format(
                                "Es gibt mehrere Einträge SollStundenMonatJahr für UserID='{0}' und Jahr='{1}'.", userId,
                                year));
                    }
                    else
                    {
                        //update
                        if (!kcr.AreSollStundenMonatJahrEqual(adr, userId))
                        {
                            DBUtil.ExecuteScalarSQLThrowingException(
                                @"
                                UPDATE dbo.BDESollStundenProJahr_XUser
                                SET JanuarStd={0},
                                    FebruarStd={1},
                                    MaerzStd={2},
                                    AprilStd={3},
                                    MaiStd={4},
                                    JuniStd={5},
                                    JuliStd={6},
                                    AugustStd={7},
                                    SeptemberStd={8},
                                    OktoberStd={9},
                                    NovemberStd={10},
                                    DezemberStd={11},
                                    TotalStd={12}
                                WHERE Jahr = {13} AND
                                      UserID = {14};",
                                adr.Januar,
                                adr.Februar,
                                adr.Maerz,
                                adr.April,
                                adr.Mai,
                                adr.Juni,
                                adr.Juli,
                                adr.August,
                                adr.September,
                                adr.Oktober,
                                adr.November,
                                adr.Dezember,
                                adr.TotalJahr,
                                year,
                                userId);

                            KAConUtil.InsertAbaLog(Session.User.UserID, 0, "Userid '" + userId + "' Jahr '" + year + "'",
                                                   null, null, "Soll Stunden Jahr Monat updated");
                        }
                    }
                }
                else
                {
                    //insert
                    DBUtil.ExecuteScalarSQLThrowingException(
                        @"
                        INSERT INTO dbo.BDESollStundenProJahr_XUser (Jahr, UserID, JanuarStd, FebruarStd, MaerzStd, AprilStd, MaiStd, JuniStd, JuliStd, AugustStd, SeptemberStd, OktoberStd, NovemberStd, DezemberStd, TotalStd)
                        VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13},{14});",
                        year, userId,
                        adr.Januar,
                        adr.Februar,
                        adr.Maerz,
                        adr.April,
                        adr.Mai,
                        adr.Juni,
                        adr.Juli,
                        adr.August,
                        adr.September,
                        adr.Oktober,
                        adr.November,
                        adr.Dezember,
                        adr.TotalJahr);

                    KAConUtil.InsertAbaLog(Session.User.UserID, 0, "Userid '" + userId + "' Jahr '" + year + "'", null,
                                           null, "Soll Stunden Jahr Monat inserted");
                }
            }
            catch (Exception ex)
            {
                // failure
                var errTxt = String.Format("Error updating SollProMonat year data (UserID='{0}'). Exception: {1}",
                                              userId, ex.Message);

                Logger.Error(errTxt);
                throw new Exception(errTxt);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private static void InsertKostenstelleMembershipKiss4(int userid, int newOrgunitid)
        {
            // insert new membership for given user and OrgUnit
            DBUtil.ExecSQLThrowingException(@"
                INSERT INTO dbo.XOrgUnit_User (OrgUnitID, UserID, OrgUnitMemberCode)
                  VALUES ({0}, {1}, 2);",
                newOrgunitid, userid);
        }

        private static void InsertKostenstelleMembershipKiss5(int userid, int newOrgunitid)
        {
            // insert new membership for given user and OrgUnit
            DBUtil.ExecSQLThrowingException(@"
                INSERT INTO dbo.SysOrgUnit_SysUser (Creator, Created, Modifier, Modified, SysOrgUnit_ID, SysUser_ID, RoleEnum, MayDelete, MayInsert, MayRead, MayUpdate)
                  VALUES ({0}, GETDATE(), {0}, GETDATE(), {1}, {2}, 2, 0, 0, 1, 0);",
                DBUtil.GetDBRowCreatorModifier(), newOrgunitid, userid);
        }

        private static int InsertUpdateAddressKiss4(MitarbeiterDTO abaRow, int staAdresseID, int currentUserID)
        {
            SqlQuery sq =
                DBUtil.OpenSQL(
                    @"
                            SELECT *
                            FROM dbo.BaAdresse WITH (READUNCOMMITTED)
                            WHERE UserID = {0}",
                    currentUserID);

            sq.TableName = "BaAdresse";
            sq.CanInsert = true;
            sq.CanUpdate = true;

            if (sq.IsEmpty)
            {
                sq.IsIdentityInsert = staAdresseID != 0;
                sq.Insert();
                if (staAdresseID != 0)
                {
                    sq[DBO.BaAdresse.BaAdresseID] = staAdresseID;
                }
            }

            sq[DBO.BaAdresse.UserID] = currentUserID;
            sq[DBO.BaAdresse.Zusatz] = abaRow.StrasseZusatz;
            sq[DBO.BaAdresse.PLZ] = abaRow.Plz;
            sq[DBO.BaAdresse.Ort] = abaRow.Ort;

            string strasse;
            string hausNr;
            KAConUtil.SplitStrasseHausNr(abaRow.StrasseUndNummer, out strasse, out hausNr);

            sq[DBO.BaAdresse.Strasse] = strasse;
            sq[DBO.BaAdresse.HausNr] = hausNr;

            string postfachNr;
            bool postfachOhneNr;
            KAConUtil.SplitPostfachUndNr(abaRow.PostfachUndNr, out postfachNr, out postfachOhneNr);

            sq[DBO.BaAdresse.PostfachOhneNr] = postfachOhneNr;
            sq[DBO.BaAdresse.Postfach] = postfachNr;

            int? baPlzId;
            string kanton;
            string bezirk;
            if (KAConUtil.GetBaPlzId(abaRow.Plz, abaRow.Ort, out baPlzId, out kanton, out bezirk))
            {
                sq[DBO.BaAdresse.OrtschaftCode] = baPlzId;
                sq[DBO.BaAdresse.Kanton] = kanton;
                sq[DBO.BaAdresse.Bezirk] = bezirk;
            }

            int? baLandId;
            if (KAConUtil.GetBaLandId(abaRow.Land, out baLandId))
            {
                sq[DBO.BaAdresse.BaLandID] = baLandId;
            }

            sq.Post();

            return (int)sq["BaAdresseID"];
        }

        private static int InsertUpdateAddressKiss5(MitarbeiterDTO mitarbeiterDto, int currentUserId)
        {
            SqlQuery staAdresseQuery =
                DBUtil.OpenSQL(
                    @"
                            SELECT ADR.*
                            FROM dbo.StaAdresse ADR WITH (READUNCOMMITTED)
                              INNER JOIN dbo.SysUser_StaAdresse UAD WITH (READUNCOMMITTED) ON UAD.StaAdresse_ID = ADR.ID
                            WHERE UAD.SysUser_ID = {0}",
                    currentUserId);

            staAdresseQuery.TableName = "StaAdresse";
            staAdresseQuery.CanInsert = true;
            staAdresseQuery.CanUpdate = true;

            if (staAdresseQuery.IsEmpty)
            {
                staAdresseQuery.Insert();
            }

            string strasse;
            string hausNr;
            KAConUtil.SplitStrasseHausNr(mitarbeiterDto.StrasseUndNummer, out strasse, out hausNr);
            staAdresseQuery["Strasse"] = strasse;
            staAdresseQuery["HausNr"] = hausNr;

            staAdresseQuery["Zusatz"] = mitarbeiterDto.StrasseZusatz;
            staAdresseQuery["PLZ"] = mitarbeiterDto.Plz;
            staAdresseQuery["Ort"] = mitarbeiterDto.Ort;

            string postfachNr;
            bool postfachOhneNr;
            KAConUtil.SplitPostfachUndNr(mitarbeiterDto.PostfachUndNr, out postfachNr, out postfachOhneNr);
            staAdresseQuery["PostfachOhneNr"] = postfachOhneNr;
            staAdresseQuery["Postfach"] = postfachNr;

            int? baPlzId;
            string kanton;
            string bezirk;
            if (KAConUtil.GetBaPlzId(mitarbeiterDto.Plz, mitarbeiterDto.Ort, out baPlzId, out kanton, out bezirk))
            {
                //staAdresseQuery["OrtschaftCode"] = baPlzId;
                staAdresseQuery["Kanton"] = kanton;
                staAdresseQuery["Bezirk"] = bezirk;
            }

            int? staLandId;
            if (KAConUtil.GetBaLandId(mitarbeiterDto.Land, out staLandId))
            {
                staAdresseQuery["StaLand_ID"] = staLandId;
            }

            staAdresseQuery["GueltigVon"] = DateTime.MinValue;
            staAdresseQuery["GueltigBis"] = DateTime.MaxValue;
            staAdresseQuery["Typ"] = 99; //99: Sonstige (Enum: StaAdresseTyp)

            staAdresseQuery.Post();

            int staAdresseId = (int)staAdresseQuery["ID"];

            SqlQuery sysUserStaAdresseQuery =
                DBUtil.OpenSQL(
                    @"
                            SELECT *
                            FROM dbo.SysUser_StaAdresse WITH (READUNCOMMITTED)
                            WHERE SysUser_ID = {0}
                              AND StaAdresse_ID = {1}",
                            currentUserId,
                            staAdresseId);

            sysUserStaAdresseQuery.TableName = "SysUser_StaAdresse";
            sysUserStaAdresseQuery.CanInsert = true;
            sysUserStaAdresseQuery.CanUpdate = true;

            if (sysUserStaAdresseQuery.IsEmpty)
            {
                //Insert
                sysUserStaAdresseQuery.Insert();
                sysUserStaAdresseQuery["SysUser_ID"] = currentUserId;
                sysUserStaAdresseQuery["StaAdresse_ID"] = staAdresseId;
                sysUserStaAdresseQuery["ValidFrom"] = new DateTime(1, 1, 1);
                sysUserStaAdresseQuery["ValidTill"] = new DateTime(9999, 12, 31);
                sysUserStaAdresseQuery.Post();
            }

            return staAdresseId;
        }

        private static int InsertXUserKiss4(int? userID, string maNr, MitarbeiterDTO mitarbeiterDto)
        {
            var gender = 1;
            if (mitarbeiterDto.Geschlecht == "F")
            {
                gender = 2;
            }

            var lohntyp = 1;
            if (mitarbeiterDto.LohnTyp == "S")
            {
                lohntyp = 2;
            }

            var kdLanguageCode = 1;
            var asLanguageCode = mitarbeiterDto.LanguageCodeString;
            if (asLanguageCode == "F")
            {
                kdLanguageCode = 2;
            }
            else if (asLanguageCode == "I")
            {
                kdLanguageCode = 3;
            }
            else if (asLanguageCode == "E")
            {
                kdLanguageCode = 3;
            }

            string identityInsertOnOrEmpty = userID.HasValue ? "SET IDENTITY_INSERT dbo.XUser ON" : String.Empty;
            string identityInsertOffOrEmpty = userID.HasValue ? "SET IDENTITY_INSERT dbo.XUser OFF" : String.Empty;
            string userIDOrEmpty = userID.HasValue ? "UserID," : String.Empty;
            string userIDValueOrEmpty = userID.HasValue ? String.Format("{0},", userID) : String.Empty;

            string insertKiSS4Sql = string.Format(
                @"
                        {0}             --'IDENTITY INSERT ON' if necessary

                        INSERT INTO dbo.XUser ({1}          --userID, if necessary
                                               LogonName,
                                               MitarbeiterNr,
                                               Geburtstag,
                                               GenderCode,
                                               LanguageCode,
                                               LohntypCode,
                                               Eintrittsdatum,
                                               Austrittsdatum,
                                               LastName,
                                               FirstName,
                                               PhonePrivat,
                                               PhoneOffice,
                                               PhoneMobile,
                                               PhoneIntern,
                                               EMail,
                                               Kostentraeger,
                                               Kostenart,
                                               QualificationTitleCode,
                                               RoleTitleCode,
                                               Creator,
                                               Modifier)
                        VALUES ({2}       --userID if necessary
                                '_none_'+CONVERT(VARCHAR, (CAST(CAST(NEWID() AS BINARY(4)) AS INT))), -- LogonName
                                {{0}},    -- MitarbeiterNr,
                                {{1}},    -- Geburtstag,
                                {{2}},    -- GenderCode,
                                {{3}},    -- LanguageCode,
                                {{4}},    -- LohntypCode,
                                {{5}},    -- Eintrittsdatum,
                                {{6}},    -- Austrittsdatum,
                                {{7}},    -- LastName,
                                {{8}},    -- FirstName,
                                {{9}},    -- PhonePrivat,
                                {{10}},   -- PhoneOffice,
                                {{11}},   -- PhoneMobile,
                                {{12}},   -- PhoneIntern,
                                {{13}},   -- EMail,
                                {{14}},   -- Kostentraeger,
                                {{15}},   -- Kostenart,
                                {{26}},   -- QualificationTitleCode,
                                {{27}},   -- RoleTitleCode,
                                {{28}},   -- Creator,
                                {{28}}    -- Modifier
                                );

                        {3}          --'IDENTITY INSERT OFF' if necessary

                        DECLARE @UserID INT;
                        SELECT @UserID = SCOPE_IDENTITY()

                        INSERT INTO dbo.XUserStundenansatz
                                (UserID,
                                 Lohnart1,
                                 Lohnart2,
                                 Lohnart3,
                                 Lohnart4,
                                 Lohnart11,
                                 Lohnart12,
                                 Lohnart13,
                                 Lohnart14,
                                 Lohnart15,
                                 Lohnart16,
                                 Creator,
                                 Modifier)
                        VALUES  (@UserID, -- UserID
                                 {{16}},    -- Lohnart1
                                 {{17}},    -- Lohnart2
                                 {{18}},    -- Lohnart3
                                 {{19}},    -- Lohnart4
                                 {{20}},    -- Lohnart11
                                 {{21}},    -- Lohnart12
                                 {{22}},    -- Lohnart13
                                 {{23}},    -- Lohnart14
                                 {{24}},    -- Lohnart15
                                 {{25}},    -- Lohnart16
                                 {{28}},    -- Creator
                                 {{28}}     -- Modifier
                                 );", identityInsertOnOrEmpty, userIDOrEmpty, userIDValueOrEmpty,
                identityInsertOffOrEmpty);

            DBUtil.ExecSQLThrowingException(insertKiSS4Sql,
                maNr, // {0}
                mitarbeiterDto.GeburtsDatum, // {1}
                gender, // {2}
                kdLanguageCode, // {3}
                lohntyp, // {4}
                mitarbeiterDto.EintrittsDatum, // {5}
                mitarbeiterDto.AustrittsDatum, // {6}
                mitarbeiterDto.Name, // {7}
                mitarbeiterDto.VorName, // {8}
                mitarbeiterDto.TelefonNrPrivat, // {9}
                mitarbeiterDto.TelefonNrGesch, // {10}
                mitarbeiterDto.TelefonNrMobil, // {11}
                mitarbeiterDto.FaxNr, // {12}
                mitarbeiterDto.EMail, // {13}
                mitarbeiterDto.Kostentraeger, // {14}
                mitarbeiterDto.FibuKonto, // {15}
                mitarbeiterDto.StundenAnsatz1, // {16}
                mitarbeiterDto.StundenAnsatz2, // {17}
                mitarbeiterDto.StundenAnsatz3, // {18}
                mitarbeiterDto.StundenAnsatz4, // {19}
                mitarbeiterDto.StundenAnsatz11, // {20}
                mitarbeiterDto.StundenAnsatz12, // {21}
                mitarbeiterDto.StundenAnsatz13, // {22}
                mitarbeiterDto.StundenAnsatz14, // {23}
                mitarbeiterDto.StundenAnsatz15, // {24}
                mitarbeiterDto.StundenAnsatz16, // {25}
                mitarbeiterDto.Qualifikation, // {26}
                mitarbeiterDto.Funktion, // {27}
                DBUtil.GetDBRowCreatorModifier() // {28}
                );

            KAConUtil.InsertAbaLog(Session.User.UserID, 0, "MitarbeiterNr " + maNr, null, null, "XUser inserted");

            var userId =
                DBUtil.ExecuteScalarSQLThrowingException(
                    @"
                        SELECT UserID
                        FROM dbo.XUser  WITH (READUNCOMMITTED)
                        WHERE MitarbeiterNr = {0};",
                    maNr);

            return Convert.ToInt32(userId);
        }

        private static int? InsertXUserKiss5(string maNr, MitarbeiterDTO mitarbeiterDto)
        {
            int? userID;
            //Geschlecht: 1: Maennlich, 2: Weiblich, 3: Unbekannt
            var geschlechtCode = 3;
            if (mitarbeiterDto.Geschlecht == "M")
            {
                geschlechtCode = 1;
            }
            else if (mitarbeiterDto.Geschlecht == "F")
            {
                geschlechtCode = 2;
            }

            //Sprache (de-CH, fr-CH, it-CH)
            var locale = "de-CH";
            if (mitarbeiterDto.LanguageCodeString == "F")
            {
                locale = "fr-CH";
            }
            else if (mitarbeiterDto.LanguageCodeString == "I")
            {
                locale = "it-CH";
            }
            else if (mitarbeiterDto.LanguageCodeString == "E")
            {
                locale = "it-CH";
            }

            //Lohntyp (1: Monatslohn, 2: Stundenlohn)
            int? lohnTypCode = null;
            if (mitarbeiterDto.LohnTyp == "1")
            {
                lohnTypCode = 1;
            }
            else if (mitarbeiterDto.LohnTyp == "2")
            {
                lohnTypCode = 2;
            }

            //TODO: neuer Config-Wert für AutenticationModeEnum (KiSS oder Windows)
            //zuerst KiSS5-Entität erstellen
            DBUtil.ExecSQLThrowingException(
                @"
                      INSERT INTO dbo.SysLogin (AuthenticationModeEnum,
                                                Login,
                                                Creator,
                                                Created,
                                                Modifier,
                                                Modified)
                      VALUES (
                                                2,                  --AuthenticationModeEnum (KiSS),
                                                '_none_'+CONVERT(VARCHAR, (CAST(CAST(NEWID() AS BINARY(4)) AS INT))), --Login
                                                {0},                --Creator
                                                GETDATE(),          --Created
                                                {0},                --Modifier
                                                GETDATE()           --Modified
                                                );

                      DECLARE @LoginID INT;
                      SELECT @LoginID = SCOPE_IDENTITY()

                      INSERT INTO dbo.SysUser (Creator,
                                               Created,
                                               Modifier,
                                               Modified,
                                               Culture,
                                               EMail,
                                               FirstName,
                                               FunctionCode,
                                               IsLocked,
                                               LastName,
                                               MitarbeiterNr,
                                               PhoneIntern,
                                               PhoneMobile,
                                               PhoneOffice,
                                               PhonePrivat,
                                               QualificationTitleCode,
                                               SexEnum,
                                               SysLogin_ID)
                      VALUES ({0},              --Creator
                              GETDATE(),        --Created
                              {0},              --Modifier
                              GETDATE(),        --Modified
                              {1},              --Culture
                              {2},              --EMail
                              {3},              --FirstName
                              {4},              --FunctionCode
                              0,                --IsLocked
                              {5},              --LastName
                              {6},              --MitarbeiterNr
                              {7},              --PhoneIntern
                              {8},              --PhoneMobile
                              {9},              --PhoneOffice
                              {10},             --PhonePrivat
                              {11},             --QualificationTitleCode
                              {12},             --SexEnum
                              @LoginID          --SysLogin_ID
                      );

                      DECLARE @UserID INT;
                      SELECT @UserID = SCOPE_IDENTITY()

                      INSERT INTO dbo.ZleUser (Creator,
                                               Created,
                                               Modifier,
                                               Modified,
                                               Austrittsdatum,
                                               Eintrittsdatum,
                                               Geburtstag,
                                               KeinBDEExport,
                                               Kostenart,
                                               Kostentraeger,
                                               Lohnart1,
                                               Lohnart2,
                                               Lohnart3,
                                               Lohnart4,
                                               Lohnart11,
                                               Lohnart12,
                                               Lohnart13,
                                               Lohnart14,
                                               Lohnart15,
                                               Lohnart16,
                                               LohnartEnum,
                                               SysUser_ID)
                      VALUES ({0},         --Creator
                              GETDATE(),   --Created,
                              {0},         --Modifier,
                              GETDATE(),   --Modified,
                              {13},        --Austrittsdatum,
                              {14},        --Eintrittsdatum,
                              {15},        --Geburtstag,
                              0,           --KeinBDEExport,
                              {16},        --Kostenart,
                              {17},        --Kostentraeger,
                              {18},        --Lohnart1,
                              {19},        --Lohnart2,
                              {20},        --Lohnart3,
                              {21},        --Lohnart4,
                              {22},        --Lohnart11,
                              {23},        --Lohnart12,
                              {24},        --Lohnart13,
                              {25},        --Lohnart14,
                              {26},        --Lohnart15,
                              {27},        --Lohnart16,
                              {28},        --LohnartEnum,
                              @UserID      --SysUser_ID,
                      );
                     ",
                DBUtil.GetDBRowCreatorModifier(), //{0}
                locale, //{1}
                mitarbeiterDto.EMail, //{2}
                mitarbeiterDto.VorName, //{3}
                mitarbeiterDto.Funktion, //{4}
                mitarbeiterDto.Name, //{5}
                maNr, //{6}
                mitarbeiterDto.FaxNr, //{7}
                mitarbeiterDto.TelefonNrMobil, //{8}
                mitarbeiterDto.TelefonNrGesch, //{9}
                mitarbeiterDto.TelefonNrPrivat, //{10}
                mitarbeiterDto.Qualifikation, //{11}
                geschlechtCode, //{12}
                mitarbeiterDto.AustrittsDatum, //{13}
                mitarbeiterDto.EintrittsDatum, //{14}
                mitarbeiterDto.GeburtsDatum, //{15}
                mitarbeiterDto.FibuKonto, //{16}
                mitarbeiterDto.Kostentraeger, //{17}
                mitarbeiterDto.StundenAnsatz1, //{18}
                mitarbeiterDto.StundenAnsatz2, //{19}
                mitarbeiterDto.StundenAnsatz3, //{20}
                mitarbeiterDto.StundenAnsatz4, //{21}
                mitarbeiterDto.StundenAnsatz11, //{22}
                mitarbeiterDto.StundenAnsatz12, //{23}
                mitarbeiterDto.StundenAnsatz13, //{24}
                mitarbeiterDto.StundenAnsatz14, //{25}
                mitarbeiterDto.StundenAnsatz15, //{26}
                mitarbeiterDto.StundenAnsatz16, //{27}
                lohnTypCode //{28}
                );

            //dann KiSS4-Entität mit Identity Insert (UserID aus KiSS5)
            userID = DBUtil.ExecuteScalarSQLThrowingException(
                @"
                        SELECT ID
                        FROM dbo.SysUser  WITH (READUNCOMMITTED)
                        WHERE MitarbeiterNr = {0};", maNr) as int?;
            return userID;
        }

        private static void UpdateKostenstelleKiss4(int userid, int newOrgunitid, int currentOrgUnitIDOfUser)
        {
            // update with new OrgUnit
            DBUtil.ExecSQLThrowingException(
                @"
                            UPDATE OUU
                            SET OUU.OrgUnitID = {0}
                            FROM dbo.XOrgUnit_User OUU
                            WHERE OUU.UserID = {1} AND
                                  OUU.OrgUnitID = {2} AND
                                  OUU.OrgUnitMemberCode = 2",
                newOrgunitid, userid, currentOrgUnitIDOfUser);
        }

        private static void UpdateKostenstelleKiss5(int userid, int newOrgunitid, int currentOrgUnitIDOfUser)
        {
            // update with new OrgUnit
            DBUtil.ExecSQLThrowingException(
                @"
                            UPDATE OUU
                            SET OUU.Modifier = {0}, OUU.Modified = GETDATE(), OUU.SysOrgUnit_ID = {1}
                            FROM dbo.SysOrgUnit_SysUser OUU
                            WHERE OUU.SysUser_ID = {2} AND
                                  OUU.SysOrgUnit_ID = {3} AND
                                  OUU.RoleEnum = 2",
                DBUtil.GetDBRowCreatorModifier(), newOrgunitid, userid, currentOrgUnitIDOfUser);
        }

        private static void UpdateXUserKiss4(int? userId, string manr, MitarbeiterDTO abaRow)
        {
            var gender = 1;
            if (abaRow.Geschlecht == "F")
            {
                gender = 2;
            }

            var kdLanguageCode = 1;
            var asLanguageCode = abaRow.LanguageCodeString;
            if (asLanguageCode == "F")
            {
                kdLanguageCode = 2;
            }
            else if (asLanguageCode == "I")
            {
                kdLanguageCode = 3;
            }
            else if (asLanguageCode == "E")
            {
                kdLanguageCode = 4;
            }

            var lohntyp = 1;
            if (abaRow.LohnTyp == "S")
            {
                lohntyp = 2;
            }

            //DateTime dtin = Convert.ToDateTime(abaRow["DATE_IN"]);
            //DateTime dtout = Convert.ToDateTime(abaRow["DATE_OUT"]);
            DBUtil.ExecSQLThrowingException(
                @"
                        UPDATE dbo.XUser
                        SET MitarbeiterNr = {0},
                            Geburtstag={1},
                            GenderCode={2},
                            LohntypCode={3},
                            Eintrittsdatum={4},
                            Austrittsdatum={5},
                            LastName={6},
                            FirstName={7},
                            PhonePrivat={8},
                            PhoneOffice={9},
                            PhoneMobile={10},
                            PhoneIntern={11},
                            EMail={12},
                            Kostentraeger={13},
                            Kostenart = {14},
                            QualificationTitleCode={25},
                            RoleTitleCode={26},
                            LanguageCode={27},
                            Modifier={28}
                        WHERE UserID = {29};

                        IF NOT EXISTS(SELECT TOP 1 1
                                      FROM dbo.XUserStundenansatz USA WITH (READUNCOMMITTED)
                                      WHERE UserID = {29})
                        BEGIN
                          INSERT INTO dbo.XUserStundenansatz
                                  (UserID,
                                   Lohnart1,
                                   Lohnart2,
                                   Lohnart3,
                                   Lohnart4,
                                   Lohnart11,
                                   Lohnart12,
                                   Lohnart13,
                                   Lohnart14,
                                   Lohnart15,
                                   Lohnart16,
                                   Creator,
                                   Modifier)
                          VALUES  ({29}, -- UserID
                                   {15},    -- Lohnart1
                                   {16},    -- Lohnart2
                                   {17},    -- Lohnart3
                                   {18},    -- Lohnart4
                                   {19},    -- Lohnart11
                                   {20},    -- Lohnart12
                                   {21},    -- Lohnart13
                                   {22},    -- Lohnart14
                                   {23},    -- Lohnart15
                                   {24},    -- Lohnart16
                                   {28},    -- Creator
                                   {28}     -- Modifier
                                   );
                        END
                        ELSE
                        BEGIN
                          UPDATE dbo.XUserStundenansatz
                            SET Lohnart1 = {15},
                                Lohnart2 = {16},
                                Lohnart3 = {17},
                                Lohnart4 = {18},
                                Lohnart11 = {19},
                                Lohnart12 = {20},
                                Lohnart13 = {21},
                                Lohnart14 = {22},
                                Lohnart15 = {23},
                                Lohnart16 = {24},
                                Modifier = {28}
                          WHERE UserID = {29};
                        END;

                        ",
                manr, // {0}
                abaRow.GeburtsDatum, // {1}
                gender, // {2}
                lohntyp, // {3}
                abaRow.EintrittsDatum, // {4}
                abaRow.AustrittsDatum, // {5}
                abaRow.Name, // {6}
                abaRow.VorName, // {7}
                abaRow.TelefonNrPrivat, // {8}
                abaRow.TelefonNrGesch, // {9}
                abaRow.TelefonNrMobil, // {10}
                abaRow.FaxNr, // {11}
                abaRow.EMail, // {12}
                abaRow.Kostentraeger, // {13}
                abaRow.FibuKonto, // {14}
                abaRow.StundenAnsatz1, // {15}
                abaRow.StundenAnsatz2, // {16}
                abaRow.StundenAnsatz3, // {17}
                abaRow.StundenAnsatz4, // {18}
                abaRow.StundenAnsatz11, // {19}
                abaRow.StundenAnsatz12, // {20}
                abaRow.StundenAnsatz13, // {21}
                abaRow.StundenAnsatz14, // {22}
                abaRow.StundenAnsatz15, // {23}
                abaRow.StundenAnsatz16, // {24}
                abaRow.Qualifikation, // {25}
                abaRow.Funktion, // {26}
                kdLanguageCode, // {27}
                DBUtil.GetDBRowCreatorModifier(), // {28}
                userId // {29}
                );
        }

        private static void UpdateXUserKiss5(int userId, string manr, MitarbeiterDTO mitarbeiterDto)
        {
            //Geschlecht: 1: Maennlich, 2: Weiblich, 3: Unbekannt
            var geschlechtCode = 3;
            if (mitarbeiterDto.Geschlecht == "M")
            {
                geschlechtCode = 1;
            }
            else if (mitarbeiterDto.Geschlecht == "F")
            {
                geschlechtCode = 2;
            }

            //Sprache (de-CH, fr-CH, it-CH)
            var locale = "de-CH";
            if (mitarbeiterDto.LanguageCodeString == "F")
            {
                locale = "fr-CH";
            }
            else if (mitarbeiterDto.LanguageCodeString == "I")
            {
                locale = "it-CH";
            }
            else if (mitarbeiterDto.LanguageCodeString == "E")
            {
                locale = "it-CH";
            }

            //Lohntyp (M -> 1: Monatslohn, S -> 2: Stundenlohn)
            int? lohnTypCode = null;
            if (mitarbeiterDto.LohnTyp == "M")
            {
                lohnTypCode = 1;
            }
            else if (mitarbeiterDto.LohnTyp == "S")
            {
                lohnTypCode = 2;
            }

            //DateTime dtin = Convert.ToDateTime(abaRow["DATE_IN"]);
            //DateTime dtout = Convert.ToDateTime(abaRow["DATE_OUT"]);
            DBUtil.ExecSQLThrowingException(
                @"
                      UPDATE dbo.SysUser SET Modifier = {0},
                                             Modified = GETDATE(),
                                             MitarbeiterNr = {1},
                                             SexEnum={2},
                                             LastName={3},
                                             FirstName={4},
                                             PhonePrivat={5},
                                             PhoneOffice={6},
                                             PhoneMobile={7},
                                             PhoneIntern={8},
                                             EMail={9},
                                             QualificationTitleCode={10},
                                             Culture={11},
                                             FunctionCode={12}
                      WHERE ID = {29};

                      UPDATE dbo.ZleUser SET Modifier = {0},
                                             Modified = GETDATE(),
                                             LohnartEnum = {13},
                                             Geburtstag = {14},
                                             Eintrittsdatum = {15},
                                             Austrittsdatum = {16},
                                             Kostentraeger = {17},
                                             Kostenart = {18},
                                             Lohnart1 = {19},
                                             Lohnart2 = {20},
                                             Lohnart3 = {21},
                                             Lohnart4 = {22},
                                             Lohnart11 = {23},
                                             Lohnart12 = {24},
                                             Lohnart13 = {25},
                                             Lohnart14 = {26},
                                             Lohnart15 = {27},
                                             Lohnart16 = {28}
                          WHERE SysUser_ID = {29};
                        ",
                DBUtil.GetDBRowCreatorModifier(), // {0}
                manr, // {1}
                geschlechtCode, // {2}
                mitarbeiterDto.Name, // {3}
                mitarbeiterDto.VorName, // {4}
                mitarbeiterDto.TelefonNrPrivat, // {5}
                mitarbeiterDto.TelefonNrGesch, // {6}
                mitarbeiterDto.TelefonNrMobil, // {7}
                mitarbeiterDto.FaxNr, // {8}
                mitarbeiterDto.EMail, // {9}
                mitarbeiterDto.Qualifikation, // {10}
                locale, // {11}
                mitarbeiterDto.Funktion, // {12}
                lohnTypCode, // {13}
                mitarbeiterDto.GeburtsDatum, // {14}
                mitarbeiterDto.EintrittsDatum, // {15}
                mitarbeiterDto.AustrittsDatum, // {16}
                mitarbeiterDto.Kostentraeger, // {17}
                mitarbeiterDto.FibuKonto, // {18}
                mitarbeiterDto.StundenAnsatz1, // {19}
                mitarbeiterDto.StundenAnsatz2, // {20}
                mitarbeiterDto.StundenAnsatz3, // {21}
                mitarbeiterDto.StundenAnsatz4, // {22}
                mitarbeiterDto.StundenAnsatz11, // {23}
                mitarbeiterDto.StundenAnsatz12, // {24}
                mitarbeiterDto.StundenAnsatz13, // {25}
                mitarbeiterDto.StundenAnsatz14, // {26}
                mitarbeiterDto.StundenAnsatz15, // {27}
                mitarbeiterDto.StundenAnsatz16, // {28}
                userId // {29}
                );
        }

        private void InsertUpdateAddress(MitarbeiterDTO abaRow, int currentUserID)
        {
            try
            {
                var kcr = new KAConRead(_abaCoWorkerDs);
                if (!kcr.CompareAdresse(abaRow, currentUserID))
                {
                    //Insert HistoryVersion
                    DBUtil.NewHistoryVersion();
                    int staAdresseID = 0;

                    if (Session.IsKiss5Mode)
                    {
                        staAdresseID = InsertUpdateAddressKiss5(abaRow, currentUserID);
                    }
                    InsertUpdateAddressKiss4(abaRow, staAdresseID, currentUserID);
                }
            }
            catch (Exception ex)
            {
                // failure
                var errTxt = "Error updating Adresse (userid " + currentUserID + "). Exception: " + ex.Message;

                Logger.Error(errTxt);
                throw new Exception(errTxt);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="abaRow"></param>
        /// <param name="mitarbeiterNr"></param>
        /// <param name="newLohnTyp"></param>
        /// <param name="selectedYear"></param>
        /// <param name="selectedMonth"></param>
        /// <returns>Returns new User ID</returns>
        private Int32 InsertXUser(MitarbeiterDTO abaRow, Int32 mitarbeiterNr, out String newLohnTyp, Int32 selectedYear,
            Int32 selectedMonth)
        {
            int? userId = null;

            try
            {
                //first test if XUser with this mitarbeiter number is not already in. This happens if
                //it is in another Geschäftsstelle (XOrgUnit) or if it is in the root XOrgUnit.
                var sq =
                    DBUtil.OpenSQL(
                        @"
                    SELECT UserID,
                           Austrittsdatum
                    FROM dbo.XUser WITH (READUNCOMMITTED)
                    WHERE MitarbeiterNr = {0}",
                        mitarbeiterNr);

                sq.First();

                var amountWorkers = sq.Count;

                if (amountWorkers > 0)
                {
                    if (amountWorkers > 1)
                    {
                        throw new Exception(
                            String.Format("User with number '{0}' exists already {1} times in table XUser.",
                                          mitarbeiterNr, amountWorkers));
                    }
                    else
                    {
                        var oAustrittsdatum = sq["Austrittsdatum"];
                        var dtSelectedDate = new DateTime(selectedYear, selectedMonth, 1);

                        if (!KAConUtil.IsDBNull(oAustrittsdatum) &&
                            (Convert.ToDateTime(oAustrittsdatum) < dtSelectedDate))
                        {
                            userId = UpdateXUser(abaRow, mitarbeiterNr, out newLohnTyp);
                        }
                        else
                        {
                            throw new Exception("Mitarbeiter mit der Nummer '" + mitarbeiterNr + "' existiert bereits " +
                                                amountWorkers +
                                                " Mal in Tabelle XUser. Bitte Austrittsdatum im KiSS prüfen, und prüfen ob er nicht schon in einem anderen Geschäftsbereich ist.");
                        }
                    }
                }
                else
                {
                    var manr = abaRow.MitarbeiterNummer.ToString(CultureInfo.InvariantCulture);

                    newLohnTyp = abaRow.LohnTyp;
                    //DateTime dtin = Convert.ToDateTime(abaRow["DATE_IN"]);
                    //DateTime dtout = Convert.ToDateTime(abaRow["DATE_OUT"]);

                    if (Session.IsKiss5Mode)
                    {
                        userId = InsertXUserKiss5(manr, abaRow);
                    }

                    DBUtil.NewHistoryVersion();

                    userId = InsertXUserKiss4(userId, manr, abaRow);

                    //ab hier haben wir definitiv eine userId gesetzt.

                    KAConUtil.InsertAbaLog(Session.User.UserID, 0, "Userid '" + userId.Value + "' MitarbeiterNr '" + manr + "'",
                                           null, null, "new XUser ID");

                    UpdateKostenstelle(abaRow.Kostenstelle, userId.Value);

                    //insert/update address
                    InsertUpdateAddress(abaRow, userId.Value);
                }
            }
            catch (Exception ex)
            {
                // failure
                var errTxt = "Error inserting XUser '" + mitarbeiterNr + "'. Exception: " + ex.Message;

                Logger.Error(errTxt);
                throw new Exception(errTxt);
            }

            return userId.Value;
        }

        /// <summary>
        /// inserts or updates Ausbezahlte Ueberstunden Data. Whenn there is a new year, it will terminate the youngest year with 31.12.yyyy
        /// where yyyy is the value of the field 'Jahr'. Terminate = set a valid date in field 'DatumBis'.
        /// </summary>
        /// <param name="adr"></param>
        /// <param name="userId"></param>
        private void UpdateAusbezUeberstunden(MitarbeiterDTO adr, Int32 userId)
        {
            try
            {
                var noNewDate = false;
                var year = adr.StichJahr;
                var dontInsert = true;
                var newDate = new DateTime();
                if (adr.GueltigkeitsDatumAusbezahlteUeberstunden.HasValue)
                {
                    newDate = adr.GueltigkeitsDatumAusbezahlteUeberstunden.Value;
                }
                else
                {
                    noNewDate = true;
                }

                double newUnit = adr.AusbezahlteUeberstunden;

                if ((newUnit > 0 && noNewDate) || (newUnit == 0 && !noNewDate))
                {
                    throw new Exception(
                        "Ausbezahlte ueberstunden: wenn ein neuer Wert angegeben wird (AMOUNT_76), muss ein AbWannDAtum angegeben werden (AMOUNT_77). Eins von beiden hat 0");
                }

                var sq =
                    DBUtil.OpenSQL(
                        @"
                        SELECT *
                        FROM dbo.BDEAusbezahlteUeberstunden_XUser WITH (READUNCOMMITTED)
                        WHERE DatumBis IS NULL AND
                              UserID = {0} AND
                              Jahr = {1}
                        ORDER BY DatumVon DESC",
                        userId, year);

                sq.First();

                if (sq.Count > 0)
                {
                    var aUnit = _typeHelper.GetDouble(sq["AusbezahlteStd"]);
                    if ((aUnit != newUnit) && (noNewDate == false))
                    {
                        var oDateVon = sq["DatumVon"];
                        if (!KAConUtil.IsDBNull(oDateVon))
                        {
                            var oldDate = Convert.ToDateTime(oDateVon);

                            if (oldDate > newDate)
                            {
                                throw new Exception(
                                    "updateAusbehUeberstunden: neues DatumVon vom Abacus (AMOUNT_77) liegt hinter altes Datum vom Kiss");
                            }

                            if (oldDate != newDate)
                            {
                                dontInsert = false;
                            }
                        }

                        //update (set enddate)
                        var key = Convert.ToInt32(sq["BDEAusbezahlteUeberstunden_XUserID"]);

                        if (dontInsert)
                        {
                            DBUtil.ExecSQLThrowingException(
                                @"
                                    UPDATE dbo.BDEAusbezahlteUeberstunden_XUser
                                    SET AusbezahlteStd = {0}
                                    WHERE BDEAusbezahlteUeberstunden_XUserID = {1} AND
                                          Jahr = {2};",
                                newUnit, key, year);
                        }
                        else
                        {
                            if (newDate.Year == year)
                            {
                                DBUtil.ExecSQLThrowingException(
                                    @"
                                    UPDATE dbo.BDEAusbezahlteUeberstunden_XUser
                                    SET DatumBis = {0}
                                    WHERE BDEAusbezahlteUeberstunden_XUserID = {1} AND
                                          Jahr = {2};",
                                    KAConUtil.RemoveOneDay(newDate), key, year);
                            }
                            else
                            {
                                throw new Exception(
                                    "Year of new Date must be identical to current year of abacus (now wrong: year of new date = '" +
                                    newDate.Year + "', current abacus year = '" + year + "')");
                            }
                        }
                    }
                }
                else
                {
                    dontInsert = false;
                    TerminateBDEAusbezahlteUeberstunden_XUser(userId, year);
                }

                if (!dontInsert && !noNewDate)
                {
                    DBUtil.ExecSQLThrowingException(
                        @"
                        INSERT INTO dbo.BDEAusbezahlteUeberstunden_XUser (UserID, Jahr, DatumVon, AusbezahlteStd)
                        VALUES ({0},{1},{2},{3});",
                        userId, year, newDate, newUnit);

                    KAConUtil.InsertAbaLog(Session.User.UserID, 0,
                                           "Userid '" + userId + "' Ausbez. Ueberstunden '" + newUnit + "' Jahr '" +
                                           year + "' Datum '" + newDate.ToShortDateString() + "'", null, null,
                                           "Ausbezahlte Ueberstunden inserted");
                }
            }
            catch (Exception ex)
            {
                // failure
                var errTxt = "Error updating AusbezUeberstunden (userid " + userId + "). Exception: " + ex.Message;

                Logger.Error(errTxt);
                throw new Exception(errTxt);
            }
        }

        /// <summary>
        /// inserts or updates FerienAnspruch Data. Whenn there is a new year, it will terminate the youngest year with 31.12.yyyy
        /// where yyyy is the value of the field 'Jahr'. Terminate = set a valid date in field 'DatumBis'.
        /// </summary>
        /// <param name="adr"></param>
        /// <param name="userId"></param>
        private void UpdateFerienAnspruch(MitarbeiterDTO adr, Int32 userId)
        {
            try
            {
                var noNewDate = false;
                var year = adr.StichJahr;
                var newDate = new DateTime();
                if (adr.GueltigkeitsDatumFerienanspruchProJahr.HasValue)
                {
                    newDate = adr.GueltigkeitsDatumFerienanspruchProJahr.Value;
                }
                else
                {
                    noNewDate = true;
                }

                Logger.DebugFormat("newDate:{0}, year:{1}, userId:{2}, noNewDate:{3}", newDate, year, userId, noNewDate);

                //Wenn kein gültiges Datum gefundet wird, wird nichts eingetragen
                if (!noNewDate)
                {
                    double newUnit = adr.FerienAnspruchAnzahlStunden;

                    SqlQuery sq =
                        DBUtil.OpenSQL(
                            @"
                            SELECT *
                            FROM dbo.BDEFerienanspruch_XUser WITH (READUNCOMMITTED)
                            WHERE DatumBis IS NULL AND
                                  UserID = {0} AND
                                  Jahr = {1}
                            ORDER BY DatumVon DESC",
                            userId, year);

                    sq.First();

                    Logger.DebugFormat("newUnit:{0}, sq.Count:{1}", newUnit, sq.Count);

                    if (sq.Count > 0)
                    {
                        var oDateVon = sq["DatumVon"];

                        if (!KAConUtil.IsDBNull(oDateVon))
                        {
                            var oldDate = Convert.ToDateTime(oDateVon);

                            if (oldDate > newDate)
                            {
                                throw new Exception(
                                    "updateFerienAnspruch: neues DatumVon vom Abacus (AMOUNT_73) liegt hinter altes Datum vom Kiss");
                            }

                            var kUnit = _typeHelper.GetDouble(sq["FerienanspruchStdProJahr"]);
                            var key = Convert.ToInt32(sq["BDEFerienanspruch_XUserID"]);

                            if (oldDate == newDate && kUnit != newUnit)
                            {
                                //update old value if new value is different but date is the same.
                                DBUtil.ExecSQLThrowingException(
                                    @"
                                        UPDATE dbo.BDEFerienanspruch_XUser
                                        SET FerienanspruchStdProJahr = {0}
                                        WHERE BDEFerienanspruch_XUserID = {1} AND
                                              Jahr = {2};",
                                    newUnit, key, year);

                                KAConUtil.InsertAbaLog(Session.User.UserID, 0,
                                                       "Userid '" + userId + "' Ferienanspruch '" + newUnit +
                                                       "' Datum '" + newDate.ToShortDateString() + "'", null, null,
                                                       "FerienAnspruch updated");
                            }
                            else if (oldDate != newDate && kUnit != newUnit)
                            {
                                Logger.DebugFormat("oldDate != newDate && kUnit != newUnit - oldDate:{0}, newDate:{1}, kUnit:{2}, newUnit:{3}", oldDate, newDate, kUnit, newUnit);

                                //update for a new insert (set enddate) because date is different
                                //but we have to check: we don't allow the year of the new date to be higher or lesser than
                                //the field 'Year'
                                if (newDate.Year == year)
                                {
                                    DBUtil.ExecSQLThrowingException(
                                        @"
                                        UPDATE dbo.BDEFerienanspruch_XUser
                                        SET DatumBis = {0}
                                        WHERE BDEFerienanspruch_XUserID = {1} AND
                                              Jahr = {2};",
                                        KAConUtil.RemoveOneDay(newDate), key, year);

                                    InsertBDEFeriananspruch_XUser(userId, year, newDate, newUnit);
                                    KAConUtil.InsertAbaLog(Session.User.UserID, 0,
                                                           "Userid '" + userId + "' '  Termination Date '" +
                                                           oldDate.ToShortDateString() + "'", null, null,
                                                           "FerienAnspruch terminated");
                                }
                                else
                                {
                                    throw new Exception(
                                        "Year of new Date must be identical to current year of abacus (now wrong: year of new date = '" +
                                        newDate.Year + "', current abacus year = '" + year + "')");
                                }
                            }
                        }
                        else
                        {
                            throw new Exception(
                                "Field 'DatumVon' is empty in KiSS DB, Table 'BDEFerienanspruch_XUser', UserID '" +
                                userId + "'");
                        }
                    }
                    else
                    {
                        Logger.Debug("Offenbar wurde kein Ferienanspruch-Eintrag gefunden!");

                        //soll ein neuer Eintrag gemacht werden? (sprich: newDate liegt im Stichjahr)
                        if (newDate.Year == year)
                        {
                            //check if there is a year before to terminate
                            TerminateBDEFeriananspruch_XUser(userId, year);

                            //no value for this user in this current year so we have to make an insert anyway
                            InsertBDEFeriananspruch_XUser(userId, year, newDate, newUnit);
                        }
                        else
                        {
                            Logger.Debug("Der Ferienanspruch wurde nicht terminiert da das neue Datum nicht im Stichjahr liegt.");
                        }
                    }
                }
                else
                {
                    //das sollte nicht passieren, seit am 1.7.2008 von Herr Damir Herceg befohlen worden ist, dass wenn
                    //es kein Datum gibt, wird der 1. 1. vom BearbeitungsJahr genommen.
                }
            }
            catch (Exception ex)
            {
                // failure
                var errTxt = "Error updating FerienAnspruch (userid " + userId + "). Exception: " + ex.Message;

                Logger.Error(errTxt);
                throw new Exception(errTxt);
            }
        }

        /// <summary>
        /// inserts or updates FerienKuerzungen Data.
        /// </summary>
        /// <param name="adr"></param>
        /// <param name="userId"></param>
        private void UpdateFerienKuerzungen(MitarbeiterDTO adr, Int32 userId)
        {
            try
            {
                var year = adr.StichJahr;
                var dontInsert = true;
                double newUnit = adr.FerienKuerzungAnzahlStunden;

                var sq =
                    DBUtil.OpenSQL(
                        @"
                        SELECT *
                        FROM dbo.BDEFerienkuerzungen_XUser WITH (READUNCOMMITTED)
                        WHERE UserID = {0} AND
                              Jahr = {1}",
                        userId, year);

                sq.First();
                if (sq.Count > 0)
                {
                    double aUnit = _typeHelper.GetDouble(sq["FerienkuerzungStd"]);
                    if (aUnit != newUnit)
                    {
                        //update (set enddate)
                        DBUtil.NewHistoryVersion();
                        DBUtil.ExecSQLThrowingException(
                            @"UPDATE dbo.BDEFerienkuerzungen_XUser SET FerienkuerzungStd = {0} WHERE UserID = {1}
                                            and Jahr = {2};",
                            newUnit, userId, year);
                    }
                }
                else
                {
                    dontInsert = false;
                }

                if (!dontInsert)
                {
                    DBUtil.NewHistoryVersion();
                    DBUtil.ExecSQLThrowingException(
                        @"INSERT INTO dbo.BDEFerienkuerzungen_XUser (UserID,Jahr,FerienkuerzungStd)
                            VALUES ({0},{1},{2});",
                        userId, year, newUnit);
                    KAConUtil.InsertAbaLog(Session.User.UserID, 0,
                                           "Userid '" + userId + "' Ferien Kuerzungen '" + newUnit + "' Jahr '" + year +
                                           "'", null, null, "FerienKürzungen inserted");
                }
            }
            catch (Exception ex)
            {
                // failure
                var errTxt = "Error updating FerienKuerzungen (userid " + userId + "). Exception: " + ex.Message;

                Logger.Error(errTxt);
                throw new Exception(errTxt);
            }
        }

        private void UpdateKostenstelle(Object oKst, Int32 userid)
        {
            try
            {
                var kcr = new KAConRead(_abaCoWorkerDs);
                var akst = Convert.ToInt32(oKst);

                // get data for given cost center
                var sq =
                    DBUtil.OpenSQL(
                        @"
                    SELECT ORG.OrgUnitID
                    FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                    WHERE ORG.Kostenstelle = {0}",
                        akst);

                // check if cost center exists once
                if (sq.Count == 1)
                {
                    // get OrgUnitID for orgunit with given cost center
                    var newOrgunitid = Convert.ToInt32(sq["OrgUnitID"]);

                    // get orgunit where user is member by now
                    var currentOrgUnitIDOfUser =
                        Convert.ToInt32(
                            DBUtil.ExecuteScalarSQLThrowingException(
                                @"
                        SELECT OrgUnitID = ISNULL(CONVERT(INT, dbo.fnOrgUnitOfUser({0}, 1)), -1)",
                                userid));

                    // check if user is member in any OrgUnit (has valid OrgUnitID)
                    if (currentOrgUnitIDOfUser > 0)
                    {
                        if (Session.IsKiss5Mode)
                        {
                            UpdateKostenstelleKiss5(userid, newOrgunitid, currentOrgUnitIDOfUser);
                        }

                        // create new HistoryVersion
                        DBUtil.NewHistoryVersion();

                        UpdateKostenstelleKiss4(userid, newOrgunitid, currentOrgUnitIDOfUser);

                        KAConUtil.InsertAbaLog(Session.User.UserID, 0,
                                               "UserID '" + userid + "', Kostenstelle '" + akst + "'", null, null,
                                               "Kostenstelle updated");
                    }
                    else
                    {
                        // user has no membership in any OrgUnit

                        if (Session.IsKiss5Mode)
                        {
                            InsertKostenstelleMembershipKiss5(userid, newOrgunitid);
                        }

                        // create new HistoryVersion
                        DBUtil.NewHistoryVersion();

                        InsertKostenstelleMembershipKiss4(userid, newOrgunitid);

                        KAConUtil.InsertAbaLog(Session.User.UserID, 0,
                                               "UserID '" + userid + "', Kostenstelle '" + akst + "'", null, null,
                                               "Kostenstelle inserted");
                    }
                }
                else if (sq.Count == 0)
                {
                    // desired cost center does not exist, throw error
                    throw new Exception(String.Format("The given cost center '{0}' does not exist within KiSS.", akst));
                }
                else
                {
                    throw new Exception(String.Format("The given cost center '{0}' exists more than once within KiSS.",
                                                      akst));
                }
            }
            catch (Exception ex)
            {
                // create an error message to log and throw further on
                var errTxt = String.Format(
                    "Error updating cost center for given user (UserID='{0}'). Exception: {1}", userid, ex.Message);

                Logger.Error(errTxt);
                throw new Exception(errTxt);
            }
        }

        /// <summary>
        /// inserts or updates Pensum Data
        /// </summary>
        /// <param name="adr"></param>
        /// <param name="userId"></param>
        private void UpdatePensum(MitarbeiterDTO adr, Int32 userId)
        {
            try
            {
                var noNewDate = false;
                var dontInsert = true;
                var newDate = new DateTime();

                if (adr.GueltigkeitsDatumBeschaeftigungsgradAenderung.HasValue)
                {
                    newDate = adr.GueltigkeitsDatumBeschaeftigungsgradAenderung.Value;
                }
                else
                {
                    noNewDate = true;
                }

                var newPensum = (int)adr.BeschaeftigungsGrad;
                var sq =
                    DBUtil.OpenSQL(
                        @"
                        SELECT *
                        FROM dbo.BDEPensum_XUser WITH (READUNCOMMITTED)
                        WHERE DatumBis IS NULL AND
                              UserID = {0}
                        ORDER BY DatumVon DESC",
                        userId);

                sq.First();

                if (sq.Count > 0)
                {
                    Int32 aPensum = _typeHelper.GetInt32(sq["PensumProzent"]);

                    if (aPensum != newPensum)
                    {
                        if (noNewDate)
                        {
                            throw new Exception(
                                "Pensum (AMOUNT_3) hat im Abacus geändert aber Feld DatumAbWann (AMOUNT_70) fehlt");
                        }

                        var oDateVon = sq["DatumVon"];

                        if (!KAConUtil.IsDBNull(oDateVon))
                        {
                            var oldDate = Convert.ToDateTime(oDateVon);

                            if (oldDate > newDate)
                            {
                                throw new Exception(
                                    "UpdatePensum: Neues DatumVon vom Abacus (AMOUNT_70) liegt hinter altem Datum vom KiSS");
                            }
                            if (oldDate != newDate)
                            {
                                dontInsert = false;
                            }
                        }
                        else
                        {
                            throw new Exception("Kiss Field 'DatumVon' of BDEPensum_XUser is null.");
                        }

                        //update
                        var key = Convert.ToInt32(sq["BDEPensum_XUserID"]);

                        if (dontInsert)
                        {
                            DBUtil.ExecSQLThrowingException(
                                @"
                                UPDATE dbo.BDEPensum_XUser
                                SET PensumProzent = {0}
                                WHERE BDEPensum_XUserID = {1};",
                                newPensum, key);
                        }
                        else
                        {
                            DBUtil.ExecSQLThrowingException(
                                @"
                                UPDATE dbo.BDEPensum_XUser
                                SET DatumBis = {0}
                                WHERE BDEPensum_XUserID = {1};",
                                KAConUtil.RemoveOneDay(newDate), key);
                        }

                        KAConUtil.InsertAbaLog(Session.User.UserID, 0,
                                               "Userid '" + userId + "' Pensum '" + newPensum + "'", null, null,
                                               "Pensum updated");
                    }
                }
                else
                {
                    dontInsert = false;
                }

                if (noNewDate)
                {
                    newDate = adr.EintrittsDatum;
                }

                if (!dontInsert)
                {
                    DBUtil.ExecSQLThrowingException(
                        @"
                        INSERT INTO dbo.BDEPensum_XUser (UserID, DatumVon, PensumProzent)
                        VALUES ({0},{1},{2});",
                        userId, newDate, newPensum);

                    KAConUtil.InsertAbaLog(Session.User.UserID, 0, "Userid '" + userId + "' Pensum '" + newPensum + "'",
                                           null, null, "Pensum inserted");
                }
            }
            catch (Exception ex)
            {
                // failure
                var errTxt = "Error updating Pensum (userid " + userId + "). Exception: " + ex.Message;

                Logger.Error(errTxt);
                throw new Exception(errTxt);
            }
        }

        /// <summary>
        /// updates or inserts new soll Stunden pro Tag
        /// </summary>
        /// <param name="adr"></param>
        /// <param name="userId"></param>
        private void UpdateSollStunden(MitarbeiterDTO adr, Int32 userId)
        {
            try
            {
                var noNewDate = false;

                var dontInsert = true;

                var newDate = new DateTime();
                if (adr.GueltigkeitsDatumSollStundenProTag.HasValue)
                {
                    newDate = adr.GueltigkeitsDatumSollStundenProTag.Value;
                }
                else
                {
                    noNewDate = true; //kein Datum angegeben, kann sein je nach dem...
                }

                double newUnit = adr.SollStundenProTag;
                var sq =
                    DBUtil.OpenSQL(
                        @"
                        SELECT *
                        FROM dbo.BDESollProTag_XUser WITH (READUNCOMMITTED)
                        where DatumBis IS NULL AND
                              UserID = {0}
                        ORDER BY DatumVon DESC",
                        userId);
                sq.First();
                if (sq.Count > 0)
                {
                    var aUnit = _typeHelper.GetDouble(sq["SollStundenProTag"]);
                    if (aUnit != newUnit)
                    {
                        if (noNewDate)
                            throw new Exception(
                                "SollStundenProTag (AMOUNT_71) hat im Abacus geaendert aber Feld DatumAbWann (AMOUNT_72) fehlt");

                        var oDateVon = sq["DatumVon"];
                        if (!KAConUtil.IsDBNull(oDateVon))
                        {
                            var oldDate = Convert.ToDateTime(oDateVon);
                            if (oldDate > newDate)
                                throw new Exception(
                                    "UpdateSollStunden: Neues DatumVon vom Abacus (AMOUNT_72) liegt hinter altem Datum vom KiSS");
                            if (oldDate != newDate)
                                dontInsert = false;
                        }
                        else
                        {
                            throw new Exception("Feld 'DatumVon' ist in Kiss, Tabelle BDESollProTag_XUser null.");
                        }

                        //update (set enddate)
                        var key = Convert.ToInt32(sq["BDESollProTag_XUserID"]);

                        if (dontInsert)
                            DBUtil.ExecSQLThrowingException(
                                @"UPDATE dbo.BDESollProTag_XUser SET SollStundenProTag = {0} WHERE BDESollProTag_XUserID = {1};",
                                newUnit, key);
                        else
                            DBUtil.ExecSQLThrowingException(
                                @"UPDATE dbo.BDESollProTag_XUser SET DatumBis = {0} WHERE BDESollProTag_XUserID = {1};",
                                KAConUtil.RemoveOneDay(newDate), key);
                    }
                }
                else
                {
                    dontInsert = false;
                }

                if (!dontInsert)
                {
                    if (noNewDate)
                        newDate = adr.EintrittsDatum;

                    DBUtil.ExecSQLThrowingException(
                        @"INSERT INTO BDESollProTag_XUser (UserID,DatumVon,SollStundenProTag)
                            VALUES ({0},{1},{2});",
                        userId, newDate, newUnit);
                    KAConUtil.InsertAbaLog(Session.User.UserID, 0,
                                           "Userid '" + userId + "' Soll Stunden '" + newUnit + "' Datum '" +
                                           newDate.ToShortDateString() + "'", null, null, "SollStunden inserted");
                }
            }
            catch (Exception ex)
            {
                // failure
                var errTxt = "Error updating SollStunden (userid " + userId + "). Exception: " + ex.Message;
                Logger.Error(errTxt);
                throw new Exception(errTxt);
            }
        }

        //return user id
        private Int32 UpdateXUser(MitarbeiterDTO abaRow, Int32 mitarbeiterNummer, out String newLohnTyp)
        {
            var userId = -1;

            try
            {
                userId = Convert.ToInt32(
                        DBUtil.ExecuteScalarSQLThrowingException(
                            @"
                        SELECT UserID
                        FROM dbo.XUser WITH (READUNCOMMITTED)
                        WHERE MitarbeiterNr = {0};",
                            mitarbeiterNummer));

                var manr = abaRow.MitarbeiterNummer.ToString(CultureInfo.InvariantCulture);

                newLohnTyp = abaRow.LohnTyp;

                if (Session.IsKiss5Mode)
                {
                    UpdateXUserKiss5(userId, manr, abaRow);
                }

                DBUtil.NewHistoryVersion();

                UpdateXUserKiss4(userId, manr, abaRow);

                // update cost center membership of user
                UpdateKostenstelle(abaRow.Kostenstelle, userId);

                // insert/update address
                InsertUpdateAddress(abaRow, userId);
            }
            catch (Exception ex)
            {
                // failure
                var errTxt = "Error updating XUser with MitarbeiterNr='" + mitarbeiterNummer + "'. Exception: " +
                                ex.Message;

                Logger.Error(errTxt);
                throw new Exception(errTxt);
            }

            return userId;
        }

        #endregion Private Methods

        #endregion Methods
    }
}