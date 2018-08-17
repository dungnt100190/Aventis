using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Schnittstellen.Newod.BO;
using KiSS4.Schnittstellen.Newod.DTO;

namespace KiSS4.Schnittstellen.Newod.Service
{
    public class PersonService
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly BaPersonService _svcBaPerson = new BaPersonService();
        private readonly NewodService _svcNewod;

        #endregion

        #region Private Fields

        private List<Person> _allPersons = new List<Person>();
        private List<BaPerson> _kissPersons = new List<BaPerson>();
        private List<NewodPerson> _newodPersons = new List<NewodPerson>();

        #endregion

        #endregion

        #region Constructors

        public PersonService()
        {
            var asr = new AppSettingsReader();

            string proxy;
            try
            {
                proxy = (string)asr.GetValue("NewodProxy", typeof(string));
            }
            catch
            {
                proxy = "";
            }

            _svcNewod = new NewodService(
                DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\URL", null),
                DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\Username", null),
                DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\Passwort", null),
                proxy,
                0);
        }

        #endregion

        #region Properties

        public List<Person> AllPersons
        {
            get { return _allPersons; }
        }

        public List<BaPerson> KissPersons
        {
            get { return _kissPersons; }
        }

        public List<NewodPerson> NewodPersons
        {
            get { return _newodPersons; }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static string GetLogString(object person)
        {
            if (person == null)
            {
                return null;
            }

            var output = new StringBuilder();

            var personType = person.GetType();
            var personProperties = personType.GetProperties(BindingFlags.Public);

            foreach (var property in personProperties)
            {
                output.AppendFormat("[{0}={1}];", property.Name, property.GetValue(person, null));
            }

            return output.ToString();
        }

        #endregion

        #region Public Methods

        public BaPersonNewodFlags CalculateNewodFlags(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var qry = DBUtil.OpenSQL("EXEC dbo.spSSTCalculateNewodFlags {0};", id);
            var flags = new BaPersonNewodFlags();

            if (qry.Count != 1)
            {
                return flags;
            }

            flags.NewodID = qry.DataTable.Rows[0]["NewodPersonID"].ToString();
            flags.SchweizerAktiveSozialHilfe = Utils.ConvertToBool(qry.DataTable.Rows[0]["SchweizerAktiveSozialhilfe"]);
            flags.AuslaenderAktiveSozialHilfe = Utils.ConvertToBool(qry.DataTable.Rows[0]["AuslaenderAktiveSozialhilfe"]);
            flags.AktiveVormundschaft = Utils.ConvertToBool(qry.DataTable.Rows[0]["SchweizerAktiveVormundschaft"]);

            return flags;
        }

        public void ClearNewodBinding(string newodid)
        {
            var markflags = new Markflags
            {
                AS = false,
                CHS = false,
                CHV = false,
                KISS = false
            };
            _svcNewod.Mark(newodid, markflags);
        }

        /// <summary>
        /// Gets a Person by ID from Result List
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person GetByID(string id)
        {
            if (_allPersons.Count > 0 && !string.IsNullOrEmpty(id))
            {
                return _allPersons.FirstOrDefault(x => x.ID == id);
            }

            throw new InvalidOperationException(string.Format("Person not found! _allPersons.Count: {0}, ID: {1}", _allPersons.Count, id));
        }

        /// <summary>
        /// Returns true if BaPerson is found in mapping table (baperson_newodperson)
        /// </summary>
        /// <param name="prs"></param>
        /// <returns></returns>
        public bool IsMapped(BaPerson prs)
        {
            var qry = DBUtil.OpenSQL(@"
                SELECT NewodPersonID
                FROM dbo.BaPerson_NewodPerson
                WHERE BaPersonID = {0};", prs.ID);

            return !qry.IsEmpty;
        }

        /// <summary>
        /// Returns true if NewodPerson is found in mapping table (baperson_newodperson)
        /// </summary>
        /// <param name="prs"></param>
        /// <returns></returns>
        public bool IsMapped(NewodPerson prs)
        {
            var qry = DBUtil.OpenSQL(@"
                SELECT BaPersonID
                FROM dbo.BaPerson_NewodPerson
                WHERE NewodPersonID = {0};", prs.ID);

            return !qry.IsEmpty;
        }

        /// <summary>
        /// Relates a BaPerson to a NewodPerson
        /// Without Webservice Call
        /// </summary>
        /// <param name="kissPerson">The BaPerson to map</param>
        /// <param name="newodPerson">The NewodPerson to map</param>
        /// <returns></returns>
        public ServiceResult MapPerson2NewodPerson(Person kissPerson, Person newodPerson)
        {
            var result = new ServiceResult();

            if (kissPerson == null || newodPerson == null)
            {
                result.AppendError("Bitte wählen Sie auf beiden Seiten eine Person aus");
                return result;
            }

            try
            {
                DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO dbo.BaPerson_NewodPerson (BaPersonID, NewodPersonID)
                    VALUES ({0}, {1});", kissPerson.ID, newodPerson.ID);
            }
            catch
            {
                var qry = DBUtil.OpenSQL(@"
                    SELECT
                      PRS.BaPersonID,
                      PRS.Name,
                      PRS.Vorname
                    FROM dbo.BaPerson PRS
                      INNER JOIN dbo.BaPerson_NewodPerson BAN ON PRS.BaPersonID = BAN.BaPersonID
                    WHERE NewodPersonID = {0};", newodPerson.ID);

                result.AppendError(
                    string.Format(@"Diese NEWOD Person ist bereits mit {0},{1} ({2}) verknüpft!", qry["Name"], qry["Vorname"], qry["BaPersonID"]));
            }

            return result;
        }

        public ServiceResult SearchPerson(bool kissLookup, bool remoteLookup, PersonSearchCriteria criteria)
        {
            int count;

            try
            {
                count = DBUtil.GetConfigInt(@"System\Schnittstelle\NEWOD\Services\SearchPerson\MaximaleTrefferZahl", 50);
            }
            catch
            {
                count = 50;
            }

            return SearchPerson(kissLookup, remoteLookup, criteria, count);
        }

        public void SetKissFlag(string[] ids)
        {
            var kissok = new Markflags();
            kissok.KISS = true;
            _svcNewod.MarkKiss(ids, kissok);
        }

        /// <summary>
        /// Relates a BaPerson to a NewodPerson
        /// This includes insert in mappping table and Webservice Call to
        /// send mapping information (flags) to NEWOD
        /// </summary>
        /// <param name="baperson">The BaPerson to map</param>
        /// <param name="newodperson">The NewodPerson to map</param>
        /// <returns></returns>
        public ServiceResult SetNewodBinding(BaPerson baperson, NewodPerson newodperson)
        {
            var result = new ServiceResult();

            if (baperson == null || newodperson == null)
            {
                result.AppendError("Bitte wählen auf beiden Seiten eine Person aus");
                return result;
            }

            var flags = CalculateNewodFlags(baperson.ID);
            flags.kiSS = true;
            flags.NewodID = newodperson.ID;

            try
            {
                DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO dbo.BaPerson_NewodPerson (BaPersonID, NewodPersonID)
                    VALUES ({0}, {1});", baperson.ID, newodperson.ID);
            }
            catch
            {
                var qry = DBUtil.OpenSQL(@"
                    SELECT
                      PRS.BaPersonID,
                      PRS.Name,
                      PRS.Vorname
                    FROM dbo.BaPerson                     PRS
                      INNER JOIN dbo.BaPerson_NewodPerson BAN ON PRS.BaPersonID = BAN.BaPersonID
                    WHERE NewodPersonID = {0};", newodperson.ID);

                result.AppendError(
                    string.Format(@"Diese NEWOD Person ist bereits mit {0},{1} ({2}) verknüpft!", qry["Name"], qry["Vorname"], qry["BaPersonID"]));

                return result;
            }

            try
            {
                UpdateNewodFlags(baperson.ID, flags, true, true);
            }
            catch
            {
                result.AppendError(string.Format(@"Die Verbindung zu NEWOD konnte nicht hergestellt werden. Bitte versuchen Sie es nochmals."));

                DBUtil.ExecSQL(@"DELETE FROM dbo.BaPerson_NewodPerson WHERE BaPersonID = {0}", baperson.ID);
                return result;
            }

            // get data
            // Basidaten
            var differences = new List<PropertyInfo>();

            var item = new GetPersonRequest();
            item.ID = baperson.ID;
            item.ValidFrom = Convert.ToDateTime(newodperson.DatumVon);

            var loglevel = LogLevel.INFO;
            string logComment = "Keine Änderung vorgenommen";
            string logMessage = "Basisdaten";

            var adrFields = new HashSet<string>
            {
                "Strasse",
                "Zusatz",
                "Postfach",
                "HausNr",
                "Plz",
                "Ort",
                "Kanton",
                // TODO: is this required anymore? >> see #4167
                "LandCode",
                "BaLandID"
            };

            try
            {
                differences.Clear();
                differences = _svcBaPerson.Diff(baperson, newodperson, adrFields, true);
                if (differences.Count > 0)
                {
                    _svcBaPerson.UpdateBasisDaten(item, newodperson);
                    logComment = "geänderte Daten: ";
                    foreach (var info in differences)
                    {
                        logComment += info.Name + " Newod: " + _svcBaPerson.GetStringRepresentation(info, info.GetValue(newodperson, null))
                                                + " KiSS: " + _svcBaPerson.GetStringRepresentation(info, info.GetValue(baperson, null)) + " /";
                    }

                    logComment = logComment.Remove(logComment.Length - 1, 1);
                }
            }
            catch (Exception ex)
            {
                loglevel = LogLevel.ERROR;
                logMessage = "Fehler beim Aktualisieren der Personendaten";
                logComment = ex.Message;
            }

            // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
            XLog.Create(GetType().FullName, 3, loglevel, logMessage, logComment, "BaPerson", Convert.ToInt32(item.ID));

            // Adressen

            logComment = "Keine Änderung vorgenommen";
            logMessage = "Adressdaten";

            try
            {
                _svcBaPerson.UpdateAdressDaten(item, baperson, newodperson);
                differences = _svcBaPerson.Diff(baperson, newodperson, adrFields, false);

                if (differences.Count > 0)
                {
                    logComment = "geänderte Daten: ";
                    foreach (var info in differences)
                    {
                        logComment += info.Name + " Newod: " + _svcBaPerson.GetStringRepresentation(info, info.GetValue(newodperson, null))
                                                + " KiSS: " + _svcBaPerson.GetStringRepresentation(info, info.GetValue(baperson, null)) + " /";
                    }

                    logComment = logComment.Remove(logComment.Length - 1, 1);
                }
            }
            catch (ApplicationException ex)
            {
                loglevel = LogLevel.ERROR;
                logMessage = "Fehler Adresse";
                logComment = ex.Message;
            }

            // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
            XLog.Create(GetType().FullName, 3, loglevel, logMessage, logComment, "BaPerson", Convert.ToInt32(item.ID));

            return result;
        }

        public ServiceResult UnMapPerson(Person p1)
        {
            var result = new ServiceResult();

            if (p1 == null)
            {
                result.AppendError("Bitte eine KiSS-Person auswählen");
                return result;
            }

            try
            {
                DBUtil.ExecSQLThrowingException(@"
                    DELETE FROM dbo.BaPerson_NewodPerson
                    WHERE BaPersonID = {0};", p1.ID);
            }
            catch
            {
                result.AppendError("Fehler beim löschen des Mappings");
            }

            return result;
        }

        public bool UpdateNewodFlags(string id, BaPersonNewodFlags flags, bool doDBUpdate, bool doServiceCall)
        {
            Session.BeginTransaction();

            try
            {
                if (doDBUpdate)
                {
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE dbo.BaPerson_NewodPerson
                        SET Aktualisiert                 = GETDATE(),
                            SchweizerAktiveSozialhilfe   = {0},
                            AuslaenderAktiveSozialhilfe  = {1},
                            SchweizerAktiveVormundschaft = {2}
                        WHERE BaPersonID = {3};",
                        flags.SchweizerAktiveSozialHilfe,
                        flags.AuslaenderAktiveSozialHilfe,
                        flags.AktiveVormundschaft,
                        id
                    );
                }

                if (doServiceCall)
                {
                    var markflags = new Markflags();
                    markflags.AS = flags.AuslaenderAktiveSozialHilfe;
                    markflags.CHS = flags.SchweizerAktiveSozialHilfe;
                    markflags.CHV = flags.AktiveVormundschaft;

                    markflags.KISS = flags.kiSS;

                    _svcNewod.Mark(flags.NewodID, markflags);
                }

                Session.Commit();
            }
            catch (Exception)
            {
                Session.Rollback();
                throw;
            }

            return true;
        }

        #endregion

        #region Private Methods

        /// TODO: Refactor (Missing Addrange on IBindableList)
        private List<Person> CombinePersonLists(List<BaPerson> pl1, List<NewodPerson> pl2)
        {
            var returnContainer = new List<Person>();

            if (pl1 != null)
            {
                foreach (var person in pl1)
                {
                    returnContainer.Add(person);
                }
            }

            if (pl2 != null)
            {
                foreach (var person in pl2)
                {
                    returnContainer.Add(person);
                }
            }

            return returnContainer;
        }

        private ServiceResult SearchPerson(bool kissLookup, bool remoteLookup, PersonSearchCriteria criteria, int count)
        {
            var result = new ServiceResult();

            int matches;

            // Reset Values
            _allPersons.Clear();
            _kissPersons.Clear();
            _newodPersons.Clear();

            if (remoteLookup)
            {
                // do search
                _newodPersons = _svcNewod.SearchPerson(criteria, count, out matches);
                _allPersons = CombinePersonLists(null, _newodPersons);
            }

            // TODO: Make Class BaPersonWrapper
            if (kissLookup)
            {
                _kissPersons = _svcBaPerson.SearchPerson(criteria, out matches);
                _allPersons = CombinePersonLists(_kissPersons, null);
            }

            if (kissLookup && remoteLookup)
            {
                // combine
                _allPersons = CombinePersonLists(_kissPersons, _newodPersons);
            }

            return result;
        }

        #endregion

        #endregion
    }
}