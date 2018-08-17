using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using KiSS4.DB;
using log4net;
using log4net.Config;

namespace KiSS4.Schnittstellen.Abacus.Mitarbeiter
{
    public class KAConRead
    {
        #region Enumerations

        public enum CoWorkerStatus
        {
            /// <summary>
            /// this happens wenn routine could not check anything, in case of exception for example
            /// </summary>
            UNSET,

            UNCHANGED,
            CHANGED,
            NEW,
            DOES_NOT_EXIST_ANYMORE
        }

        #endregion

        #region Fields

        #region Private Static Fields

        private static readonly ILog Logger = LogManager.GetLogger(typeof(KAConRead));
        private static readonly TypeHelper Th = new TypeHelper();

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly ArrayList _listMaUpdated = new ArrayList();

        #endregion

        #region Private Fields

        private IDictionary<int, MitarbeiterDTO> _abaCoWorkerDs;
        private String _status = String.Empty;

        #endregion

        #endregion

        #region Constructors

        static KAConRead()
        {
            XmlConfigurator.Configure();
        }

        public KAConRead()
        {
        }

        public KAConRead(IDictionary<int, MitarbeiterDTO> ds)
        {
            _abaCoWorkerDs = ds;
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public Boolean CompareAdresse(MitarbeiterDTO adr, Int32 userId)
        {
            Boolean ret = false;

            if (adr == null)
            {
                throw new NullReferenceException("Abacus datarow is empty.");
            }

            bool abacusHasAdresse = !string.IsNullOrEmpty(adr.StrasseUndNummer)
                                    || !string.IsNullOrEmpty(adr.PostfachUndNr)
                                    || !string.IsNullOrEmpty(adr.StrasseZusatz)
                                    || !string.IsNullOrEmpty(adr.Land)
                                    || !string.IsNullOrEmpty(adr.Plz)
                                    || !string.IsNullOrEmpty(adr.Ort);

            SqlQuery sq =
                DBUtil.OpenSQL(
                    @"
                    SELECT *
                    FROM dbo.BaAdresse WITH (READUNCOMMITTED)
                    WHERE UserID = {0}",
                    userId);

            sq.First();

            if (abacusHasAdresse && sq.Count == 0)
            {
                return false;
            }

            if (sq.Count > 0)
            {
                //Split Strasse + Hausnummer
                string hausNr;
                string strasse;
                KAConUtil.SplitStrasseHausNr(adr.StrasseUndNummer, out strasse, out hausNr);

                string postfachNr;
                bool postfachOhneNr;
                KAConUtil.SplitPostfachUndNr(adr.PostfachUndNr, out postfachNr, out postfachOhneNr);

                if (Th.CompareStrings(strasse, sq["Strasse"], true) &&
                    Th.CompareStrings(hausNr, sq["HausNr"], true) &&
                    Th.CompareStrings(adr.StrasseZusatz, sq["Zusatz"], true) &&
                    Th.CompareStrings(adr.Plz, sq["PLZ"], true) &&
                    Th.CompareStrings(adr.Ort, sq["Ort"], true) &&
                    Th.CompareStrings(postfachNr, sq["Postfach"], true) &&
                    (Equals(postfachOhneNr, sq["PostfachOhneNr"] is bool && (bool)sq["PostfachOhneNr"])))
                {
                    ret = true;
                }

                if (!ret)
                {
                    _status += " 'Adresse'";
                }
            }

            return ret;
        }

        #endregion

        #region Public Methods

        public Boolean AreSollStundenMonatJahrEqual(MitarbeiterDTO adr, Int32 userId)
        {
            Boolean ret = false;

            //get data row from aba
            Int32 year = adr.StichJahr;

            if (adr == null)
            {
                throw new NullReferenceException("Abacus datarow is empty.");
            }

            SqlQuery sq =
                DBUtil.OpenSQL(
                    @"
                    SELECT *
                    FROM dbo.BDESollStundenProJahr_XUser WITH (READUNCOMMITTED)
                    WHERE Jahr = {0} AND
                          UserID = {1}",
                    year, userId);

            sq.First();

            if (sq.Count > 0)
            {
                if (Th.GetDouble(sq["JanuarStd"]) == adr.Januar &&
                    Th.GetDouble(sq["FebruarStd"]) == adr.Februar &&
                    Th.GetDouble(sq["MaerzStd"]) == adr.Maerz &&
                    Th.GetDouble(sq["AprilStd"]) == adr.April &&
                    Th.GetDouble(sq["MaiStd"]) == adr.Mai &&
                    Th.GetDouble(sq["JuniStd"]) == adr.Juni &&
                    Th.GetDouble(sq["JuliStd"]) == adr.Juli &&
                    Th.GetDouble(sq["AugustStd"]) == adr.August &&
                    Th.GetDouble(sq["SeptemberStd"]) == adr.September &&
                    Th.GetDouble(sq["OktoberStd"]) == adr.Oktober &&
                    Th.GetDouble(sq["NovemberStd"]) == adr.November &&
                    Th.GetDouble(sq["DezemberStd"]) == adr.Dezember &&
                    Th.GetDouble(sq["TotalStd"]) == adr.TotalJahr)
                {
                    ret = true;
                }
            }

            return ret;
        }

        /// <summary>
        /// cs if worker is differenct
        /// </summary>
        /// <param name="coWorkerNumber"></param>
        /// <returns>cs if worker is differenct</returns>
        public CoWorkerStatus CompareWorker(Int32 coWorkerNumber)
        {
            // reset current status information
            ResetStatus();

            var cwd = CoWorkerStatus.UNSET;

            if (_abaCoWorkerDs == null)
            {
                throw new NullReferenceException("Abacus dataset is empty, get abacus worker first please.");
            }

            MitarbeiterDTO dr;
            _abaCoWorkerDs.TryGetValue(coWorkerNumber, out dr);

            if (dr == null)
            {
                //********************************
                //worker not found in the Abacus Data Set
                //********************************
                cwd = CoWorkerStatus.DOES_NOT_EXIST_ANYMORE;
            }
            else
            {
                if (_listMaUpdated.Contains(coWorkerNumber))
                {
                    Logger.Error(coWorkerNumber + " is twice in KiSS!!!!");
                }

                _listMaUpdated.Add(coWorkerNumber);

                //get the kiss data set
                var kRow = KAConUtil.GetKissXUserWithMitarbeiterNr(coWorkerNumber);

                var sq = DBUtil.OpenSQL(@"
                    SELECT USR.*,
                           StundenansatzLA1 = USA.Lohnart1,
                           StundenansatzLA2 = USA.Lohnart2,
                           StundenansatzLA3 = USA.Lohnart3,
                           StundenansatzLA4 = USA.Lohnart4,
                           StundenansatzLA11 = USA.Lohnart11,
                           StundenansatzLA12 = USA.Lohnart12,
                           StundenansatzLA13 = USA.Lohnart13,
                           StundenansatzLA14 = USA.Lohnart14,
                           StundenansatzLA15 = USA.Lohnart15,
                           StundenansatzLA16 = USA.Lohnart16
                    FROM dbo.XUser                     USR WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.XUserStundenansatz USA ON USA.UserID = USR.UserID
                    WHERE MitarbeiterNr = {0};",
                    coWorkerNumber);

                if (sq.Count != 1)
                {
                    if (sq.Count == 0)
                    {
                        //*********************************
                        //this is a new mitarbeiter to import
                        cwd = CoWorkerStatus.NEW;
                    }
                    else if (sq.Count > 1)
                    {
                        throw new Exception("XUser not unique. " + sq.Count.ToString(CultureInfo.InvariantCulture) +
                                            " entries in XUser were found with MitarbetierNr = '" + coWorkerNumber +
                                            "'.");
                    }
                }
                else
                {
                    //here we have a worker in the abacus and in the kiss
                    //lets see if it is unchanged and already imported this month,
                    //changed but already imported this month,
                    //not imported this month and unchanged
                    //or not imported this month but did not change anything
                    var newAbaLohnTyp = String.Empty;
                    var userId = Th.GetInt32(sq.DataTable.Rows[0]["UserID"]);
                    var dataUserChanged = !AreUserDataEqual(dr, sq.DataTable.Rows[0], coWorkerNumber, out newAbaLohnTyp);

                    if (newAbaLohnTyp == "M")
                    {
                        var pensumChanged = !ArePensumDataEqual(dr, userId);
                        var sollStundenChanged = !AreSollStundenEqual(dr, userId);
                        var ferienAnspruchChanged = !AreFerienAnspruchEqual(dr, userId);
                        var ausbezUeberstundenChanged = !AreUeberstundenEqual(dr, userId);
                        var ferienKuerzungenChanged = !AreFerienKuerzungenEqual(dr, userId);
                        var sollStundenProJahrChanged = !AreSollStundenMonatJahrEqual(dr, userId);

                        if (dataUserChanged ||
                            pensumChanged ||
                            sollStundenChanged ||
                            ferienAnspruchChanged ||
                            ausbezUeberstundenChanged ||
                            ferienKuerzungenChanged ||
                            sollStundenProJahrChanged)
                        {
                            cwd = CoWorkerStatus.CHANGED;
                        }
                        else
                        {
                            cwd = CoWorkerStatus.UNCHANGED;
                        }
                    }
                    else
                    {
                        cwd = dataUserChanged ? CoWorkerStatus.CHANGED : CoWorkerStatus.UNCHANGED;
                    }
                }
            }

            // return status
            return cwd;
        }

        public IDictionary<int, MitarbeiterDTO> GetAbaDataSet()
        {
            return _abaCoWorkerDs;
        }

        public Int32 GetAmountNewMa()
        {
            return (KAConUtil.GetAmountCoWorkers(_abaCoWorkerDs) - _listMaUpdated.Count);
        }

        /// <summary>
        /// Get list of non inserted coworkers
        /// </summary>
        /// <returns>List of non inserted coworkers</returns>
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

        public String GetStatus()
        {
            return _status;
        }

        public void InsertUpdatedMaIfExistingInAbacus(IDictionary<int, MitarbeiterDTO> ds, Int32 maNr)
        {
            MitarbeiterDTO abaDataRow;
            ds.TryGetValue(maNr, out abaDataRow);
            if (abaDataRow != null)
            {
                if (_listMaUpdated.Contains(maNr))
                {
                    Logger.Error(maNr + " is twice in KiSS!!!!");
                }

                _listMaUpdated.Add(maNr);
            }
        }

        /// <summary>
        /// Create a string of the result set given from abacus
        /// </summary>
        /// <returns>The resultset as string for logging</returns>
        public String LogResultList(ICollection<MitarbeiterDTO> mitarbeiter)
        {
            var sb = new StringBuilder();

            foreach (var mitarbeiterDto in mitarbeiter)
            {
                sb.AppendLine(mitarbeiterDto.ToString());
            }

            return sb.ToString();
        }

        public void ResetStatus()
        {
            _status = String.Empty;
        }

        public void ResetUpdatedMitarbeiterList()
        {
            _listMaUpdated.Clear();
        }

        public void SetAbaDataSet(IDictionary<int, MitarbeiterDTO> tds)
        {
            _abaCoWorkerDs = tds;
        }

        /// <summary>
        /// Get amount of rows found
        /// </summary>
        /// <param name="adr"></param>
        /// <param name="userId"></param>
        /// <returns>Amount of rows found</returns>
        public Int32 SollStundenMonatJahrExist(MitarbeiterDTO adr, Int32 userId)
        {
            var ret = 0;
            var year = adr.StichJahr;

            if (adr != null)
            {
                var sq =
                    DBUtil.OpenSQL(
                        @"
                    SELECT COUNT(1) AS CNT
                    FROM dbo.BDESollStundenProJahr_XUser WITH (READUNCOMMITTED)
                    WHERE Jahr = {0} AND
                          UserID = {1};",
                        year, userId);

                ret = Convert.ToInt32(sq["CNT"]);
            }

            return ret;
        }

        #endregion

        #region Private Methods

        private Boolean AreFerienAnspruchEqual(MitarbeiterDTO adr, Int32 userId)
        {
            //BDEFerienanspruch_XUser
            var ret = false;
            var year = adr.StichJahr;

            var noNewDate = false;

            if (adr.GueltigkeitsDatumFerienanspruchProJahr.HasValue)
            {
                var newDate = adr.GueltigkeitsDatumFerienanspruchProJahr.Value;
            }
            else
            {
                noNewDate = true;
            }

            Double aferienanspurch = adr.FerienAnspruchAnzahlStunden;

            if (aferienanspurch == 0 && !noNewDate)
            {
                throw new Exception(
                    "Abacus, Feld FerienAnspruch (FerienAnspruchAnzahlStunden) und DatumAbWann (GueltigkeitsDatumFerienanspruchProJahr): Eines der beiden ist 0 und das geht nicht.");
            }

            var sq =
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

            if (sq.Count > 0)
            {
                var kferienanspruch = Th.GetDouble(sq["FerienanspruchStdProJahr"]);

                if ((kferienanspruch == aferienanspurch) || aferienanspurch == 0)
                {
                    ret = true;
                }
            }
            else
            {
                if (aferienanspurch == 0)
                {
                    ret = true;
                }
            }

            if (!ret)
            {
                _status += String.Format(" 'FerienAnspruch für das Jahr {0}'", year);
            }

            return ret;
        }

        private Boolean AreFerienKuerzungenEqual(MitarbeiterDTO adr, Int32 userId)
        {
            //BDEFerienkuerzungen_XUser
            var ret = false;
            var year = adr.StichJahr;
            Double aferienanspurch = adr.FerienKuerzungAnzahlStunden;

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
                var kferienanspruch = Th.GetDouble(sq["FerienkuerzungStd"]);

                if (kferienanspruch == aferienanspurch)
                {
                    ret = true;
                }
            }

            if (!ret)
            {
                _status += String.Format(" 'Ferienkuerzungen für das Jahr {0}'", year);
            }

            return ret;
        }

        private Boolean ArePensumDataEqual(MitarbeiterDTO adr, Int32 userId)
        {
            //BDEPensum_XUser
            var ret = false;

            var pensum =
                DBUtil.OpenSQL(
                    @"
                SELECT *
                FROM dbo.BDEPensum_XUser WITH (READUNCOMMITTED)
                WHERE DatumBis IS NULL AND
                      UserID = {0}
                ORDER BY DatumVon DESC",
                    userId);

            pensum.First();

            if (pensum.Count > 0)
            {
                var kPensum = Th.GetInt32(pensum["PensumProzent"]);
                var oPensum = (Int32)adr.BeschaeftigungsGrad;

                if (kPensum == oPensum)
                {
                    ret = true;
                }
            }

            if (!ret)
            {
                _status += " 'Pensum (AMOUNT_3)'";
            }

            return ret;
        }

        private Boolean AreSollStundenEqual(MitarbeiterDTO adr, Int32 userId)
        {
            //BDESollProTag_XUser
            var ret = false;

            var solls =
                DBUtil.OpenSQL(
                    @"
                SELECT *
                FROM dbo.BDESollProTag_XUser WITH (READUNCOMMITTED)
                WHERE DatumBis IS NULL AND
                      UserID = {0}
                ORDER BY DatumVon DESC",
                    userId);

            solls.First();

            if (solls.Count > 0)
            {
                var ksoll = Th.GetDouble(solls["SollStundenProTag"]);
                var asoll = adr.SollStundenProTag;

                if (ksoll == asoll)
                {
                    ret = true;
                }
            }

            if (!ret)
            {
                _status += " 'SollStundenProTag (AMOUNT_71)'";
            }

            return ret;
        }

        private Boolean AreUeberstundenEqual(MitarbeiterDTO adr, Int32 userId)
        {
            //BDEAusbezahlteUeberstunden_XUser
            var ret = false;

            var noNewDate = false;

            if (adr.GueltigkeitsDatumAusbezahlteUeberstunden.HasValue)
            {
                var newDate = adr.GueltigkeitsDatumAusbezahlteUeberstunden.Value;
            }
            else
            {
                noNewDate = true;
            }

            var year = adr.StichJahr;
            Double aferienanspurch = adr.AusbezahlteUeberstunden;

            if ((aferienanspurch == 0 && !noNewDate) || (aferienanspurch != 0 && noNewDate))
            {
                throw new Exception(
                    "Abacus, Feld AusbezahlteUeberstunden (AMOUNT_76) und DatumAbWann (AMOUNT_77): Eines der beiden ist 0 und das geht nicht.");
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
                var kferienanspruch = Th.GetDouble(sq["AusbezahlteStd"]);

                if ((kferienanspruch == aferienanspurch) || aferienanspurch == 0)
                {
                    ret = true;
                }
            }
            else
            {
                if (aferienanspurch == 0)
                {
                    ret = true;
                }
            }

            if (!ret)
            {
                _status += String.Format(" 'Ausbezahlte Überstunden für das Jahr {0}'", year);
            }

            return ret;
        }

        /// <summary>
        /// checks if they are different or if they are identical.
        /// identical means: it was already imported from abac to kiss and it is up to date
        /// </summary>
        /// <param name="abacRow"></param>
        /// <param name="kissRow"></param>
        /// <param name="workerNr"></param>
        /// <param name="newLohnTyp"></param>
        /// <returns></returns>
        private Boolean AreUserDataEqual(MitarbeiterDTO abacRow, DataRow kissRow, Int32 workerNr, out String newLohnTyp)
        {
            var ret = false;

            if (abacRow != null && kissRow != null)
            {
                newLohnTyp = abacRow.LohnTyp;

                if (CompareBirthDate(abacRow.GeburtsDatum, kissRow["Geburtstag"]) &&
                    CompareGender(abacRow.Geschlecht, kissRow["GenderCode"]) &&
                    CompareLanguage(abacRow.LanguageCodeString, kissRow["LanguageCode"]) &&
                    CompareLohnTyp(abacRow.LohnTyp, kissRow["LohntypCode"]) &&
                    CompareEintrittsdatum(abacRow.EintrittsDatum, kissRow["Eintrittsdatum"]) &&
                    CompareAustrittsdatum(abacRow.AustrittsDatum, kissRow["Austrittsdatum"]) &&
                    CompareName(abacRow.Name, kissRow["LastName"]) &&
                    CompareVorname(abacRow.VorName, kissRow["FirstName"]) &&
                    CompareTelefon(abacRow.TelefonNrPrivat, kissRow["PhonePrivat"], "PhonePrivat") &&
                    CompareTelefon(abacRow.TelefonNrGesch, kissRow["PhoneOffice"], "PhoneOffice") &&
                    CompareTelefon(abacRow.TelefonNrMobil, kissRow["PhoneMobile"], "PhoneMobile") &&
                    CompareTelefon(abacRow.FaxNr, kissRow["PhoneIntern"], "PhoneIntern") &&
                    CompareEmail(abacRow.EMail, kissRow["EMail"]) &&
                    CompareKostenstelle(abacRow.Kostenstelle, kissRow["UserID"]) &&
                    CompareKostentraeger(abacRow.Kostentraeger, kissRow["Kostentraeger"]) &&
                    CompareStundenansatz(abacRow.StundenAnsatz1, kissRow["StundenansatzLA1"], " 'Studenansatz1 (Monat)'") &&
                    CompareStundenansatz(abacRow.StundenAnsatz2, kissRow["StundenansatzLA2"], " 'Studenansatz2'") &&
                    CompareStundenansatz(abacRow.StundenAnsatz3, kissRow["StundenansatzLA3"], " 'Studenansatz3'") &&
                    CompareStundenansatz(abacRow.StundenAnsatz4, kissRow["StundenansatzLA4"], " 'Studenansatz4 (Reinigung)'") &&
                    CompareStundenansatz(abacRow.StundenAnsatz11, kissRow["StundenansatzLA11"], " 'Studenansatz11'") &&
                    CompareStundenansatz(abacRow.StundenAnsatz12, kissRow["StundenansatzLA12"], " 'Studenansatz12'") &&
                    CompareStundenansatz(abacRow.StundenAnsatz13, kissRow["StundenansatzLA13"], " 'Studenansatz13'") &&
                    CompareStundenansatz(abacRow.StundenAnsatz14, kissRow["StundenansatzLA14"], " 'Studenansatz14'") &&
                    CompareStundenansatz(abacRow.StundenAnsatz15, kissRow["StundenansatzLA15"], " 'Studenansatz15'") &&
                    CompareStundenansatz(abacRow.StundenAnsatz16, kissRow["StundenansatzLA16"], " 'Studenansatz16'") &&
                    CompareKostenArt(abacRow.FibuKonto, kissRow["Kostenart"]) &&
                    CompareQualificationTitle(abacRow.Qualifikation, kissRow["QualificationTitleCode"]) &&
                    CompareRoleTitle(abacRow.Funktion, kissRow["RoleTitleCode"]) &&
                    CompareAdresse(abacRow, (int)kissRow["UserID"]))
                {
                    ret = true;
                }
            }
            else
            {
                throw new NullReferenceException(
                    String.Format("Problems comparing user '{0}', one of the datasets is null.", workerNr));
            }

            return ret;
        }

        /// <summary>
        /// kontrolliert ob die Relation 'User-Kostenstelle' mehrmals existiert
        /// </summary>
        /// <param name="aoKostenstelle"></param>
        /// <param name="koUserID"></param>
        /// <returns></returns>
        private Boolean CheckKostenstelle(long aoKostenstelle, Object koUserID)
        {
            var ret = false;

            //UserID is an int;
            if (koUserID != null && aoKostenstelle != 0)
            {
                var doKost = (Int32)aoKostenstelle;
                var doUserID = Convert.ToInt32(koUserID);

                var cko =
                    DBUtil.OpenSQL(
                        @"
                    SELECT 1
                    FROM dbo.XUser XU WITH (READUNCOMMITTED)
                      INNER JOIN dbo.XOrgUnit_User XOU WITH (READUNCOMMITTED) ON XOU.UserID = XU.UserID AND
                                                                                 XOU.OrgUnitMemberCode = 2
                      INNER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = XOU.OrgUnitID AND
                                                                                 ORG.Kostenstelle = {1}
                    WHERE XU.UserID = {0};",
                        doUserID, doKost);

                if (cko.Count == 0)
                {
                    ret = false;
                }
                else if (cko.Count == 1)
                {
                    ret = true;
                }
                else
                {
                    throw new Exception(
                        String.Format("The user with id='{0}' and costcenter '{1}' exists more than one times.",
                                      doUserID, doKost));
                }
            }

            return ret;
        }

        private Boolean CompareAustrittsdatum(DateTime? a, Object k)
        {
            var ret = Th.CompareDates(a, k);

            if (!ret)
            {
                _status += " 'DateOut'";
            }

            return ret;
        }

        private Boolean CompareBirthDate(DateTime? a, Object k)
        {
            var ret = Th.CompareDates(a, k);

            if (!ret)
            {
                _status += " 'BirthDate'";
            }

            return ret;
        }

        private Boolean CompareEintrittsdatum(DateTime a, Object k)
        {
            Boolean ret = Th.CompareDates(a, k);

            if (!ret)
            {
                _status += " 'DateIn'";
            }

            return ret;
        }

        private Boolean CompareEmail(string a, Object k)
        {
            var ret = Th.CompareStrings(a, k, true);

            if (!ret)
            {
                _status += " 'Email'";
            }

            return ret;
        }

        private Boolean CompareGender(string a, Object k)
        {
            var abaSex = a;
            var kissSex = Convert.ToInt32(k);

            var ret = ((abaSex == "M" && kissSex == 1) || (abaSex == "F" && kissSex == 2));

            if (!ret)
            {
                _status += " 'Gender'";
            }

            return ret;
        }

        private Boolean CompareKostenArt(long a, Object k)
        {
            var ret = false;

            if (a == 0 && KAConUtil.IsDBNull(k))
            {
                ret = true;
            }
            else
            {
                if (!KAConUtil.IsDBNull(k))
                {
                    if (((int)a) == Th.GetInt32(k))
                    {
                        ret = true;
                    }
                }
            }

            if (!ret)
            {
                _status += " 'Kostenart (ACCOUNT_A1)'";
            }

            return ret;
        }

        private Boolean CompareKostenstelle(long a, Object k)
        {
            var ret = CheckKostenstelle(a, k);

            if (!ret)
            {
                _status += " 'Kostenstelle (CCENTER1)'";
            }

            return ret;
        }

        private Boolean CompareKostentraeger(long a, Object k)
        {
            var ret = false;

            if (a == 0 && KAConUtil.IsDBNull(k))
            {
                ret = true;
            }
            else
            {
                if (!KAConUtil.IsDBNull(k))
                {
                    if (((int)a) == Th.GetInt32(k))
                    {
                        ret = true;
                    }
                }
            }

            if (!ret)
            {
                _status += " 'Kostenträger (PROJECT_1)'";
            }

            return ret;
        }

        private Boolean CompareLanguage(String a, Object k)
        {
            var ret = false;

            if (a == null && KAConUtil.IsDBNull(k))
            {
                ret = true;
            }
            else if (a != null && !KAConUtil.IsDBNull(k))
            {
                var alanguage = a;
                var klanguageCode = Convert.ToInt32(k);

                if ((klanguageCode == 1 && alanguage == "D") ||
                    (klanguageCode == 2 && alanguage == "F") ||
                    (klanguageCode == 3 && alanguage == "I") ||
                    (klanguageCode == 4 && alanguage == "E"))
                {
                    ret = true;
                }

                if (!ret)
                {
                    _status += String.Format(" 'Language not identical Abac: {0}, KiSS: {1}'", alanguage, klanguageCode);
                }
            }
            else
            {
                _status += " 'One of the language fields is null'";
            }

            return ret;
        }

        private Boolean CompareLohnTyp(string a, Object k)
        {
            var ret = false;

            if (a != null && k != null)
            {
                var alohn = a;
                var klohn = Th.GetInt32(k);

                if ((klohn == 1 && alohn == "M") ||
                    (klohn == 2 && alohn == "S"))
                {
                    ret = true;
                }

                if (!ret)
                {
                    _status += String.Format(" 'LohnTyp Aba: {0}, KiSS: {1}'", alohn, klohn);
                }
            }
            else
            {
                _status += " 'LohnTyp: KiSS has null value'";
            }

            return ret;
        }

        private Boolean CompareName(string a, Object k)
        {
            var ret = Th.CompareStrings(a, k, true);

            if (!ret)
            {
                _status += " 'LastName'";
            }

            return ret;
        }

        private Boolean CompareQualificationTitle(int a, Object k)
        {
            var ret = false;

            if (a == 0 && KAConUtil.IsDBNull(k))
            {
                ret = true;
            }
            else
            {
                if (!KAConUtil.IsDBNull(k))
                {
                    if (a == Th.GetInt32(k))
                    {
                        ret = true;
                    }
                }
            }

            if (!ret)
            {
                _status += " 'QualificationTitle (NR_3)'";
            }

            return ret;
        }

        private Boolean CompareRoleTitle(int a, Object k)
        {
            var ret = false;

            if (a == 0 && KAConUtil.IsDBNull(k))
            {
                ret = true;
            }
            else
            {
                if (!KAConUtil.IsDBNull(k))
                {
                    if (a == Th.GetInt32(k))
                    {
                        ret = true;
                    }
                }
            }

            if (!ret)
            {
                _status += " 'RoleTitle (CODE_1)'";
            }

            return ret;
        }

        private bool CompareStundenansatz(float a, object k, string statusmeldung)
        {
            var ret = Th.CompareDoubles(a, k);

            if (!ret)
            {
                _status += statusmeldung;
            }

            return ret;
        }

        /// <summary>
        /// Telefon is new PhonePrivat
        /// </summary>
        private Boolean CompareTelefon(string a, Object k, string status)
        {
            var ret = Th.CompareStrings(a, k, true);

            if (!ret)
            {
                _status += string.Format(" '{0}'", status);
            }

            return ret;
        }

        private Boolean CompareVorname(string a, Object k)
        {
            var ret = Th.CompareStrings(a, k, true);

            if (!ret)
            {
                _status += " 'FirstName'";
            }

            return ret;
        }

        private Int32 GetYear(DataRow dr)
        {
            var year = 0;

            if (dr != null)
            {
                year = Th.GetInt32(dr["YEAR"]);
            }

            return year;
        }

        #endregion

        #endregion
    }
}