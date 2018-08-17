using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;

using Kiss.Infrastructure;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Schnittstellen.Newod.DTO;

using KiSS.DBScheme;

namespace KiSS4.Schnittstellen.Newod.Service
{
    #region Delegates

    /// <summary>
    /// Delegate for processing newod state messages
    /// </summary>
    /// <param name="message">Import message</param>
    public delegate void ProcessNewodImportMessageDelegate(string message);

    #endregion

    public class BaPersonService
    {
        #region Fields

        #region Private Fields

        private ProcessNewodImportMessageDelegate _newodMessageDelegate;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Liefert eine Liste unterschiedlicher Properties zweier Personen
        /// </summary>
        /// <param name="prs1">BaPerson</param>
        /// <param name="prs2">NewodPerson</param>
        /// <returns></returns>
        public List<PropertyInfo> Diff(BaPerson prs1, NewodPerson prs2)
        {
            return Diff(prs1, prs2, null, false);
        }

        /// <summary>
        /// Liefert eine Liste unterschiedlicher Properties zweier Adressen
        /// </summary>
        /// <param name="adr1">Adresse 1</param>
        /// <param name="adr2">Adresse 2</param>
        /// <returns></returns>
        public List<PropertyInfo> Diff(PersonAdressDaten adr1, PersonAdressDaten adr2)
        {
            BaPerson prs1 = new BaPerson(new PersonBasisDaten(), adr1);
            NewodPerson prs2 = new NewodPerson(new PersonBasisDaten(), adr2);

            return Diff(prs1, prs2, null, false);
        }

        /// <summary>
        /// Liefert eine Liste unterschiedlicher Properties zweier Personen
        /// </summary>
        /// <param name="kissPerson">BaPerson</param>
        /// <param name="neuePerson">NewodPerson</param>
        /// <param name="filter">Properties Filter</param>
        /// <param name="invert">Wenn <c>true</c> invertiere Filter</param>
        /// <returns></returns>
        public List<PropertyInfo> Diff(BaPerson kissPerson, NewodPerson neuePerson, HashSet<string> filter, bool invert)
        {
            var fieldsAlwaysToIgnore = new List<string>
            {
                "ID",
                "Land",
                // TODO: is this required anymore? >> see #4167
                "LandCode",
                "BaLandID",
                "DatumVon",
                "DatumBis",
                "Nationalitaet",
                "Sprache",
                "ZivilstandDatum",
                "WegzugLandCode"
            };

            //Debugging purposes
            var fieldsToBreak = new HashSet<string>();
            //fieldsToBreak.Add("Sterbedatum");
            //fieldsToBreak.Add("Vorname");

            var differences = new List<PropertyInfo>();
            var properties = kissPerson.GetType().GetProperties();

            foreach (var prop in properties)
            {
                bool doCheckDiff = true;

                bool passthru = (fieldsAlwaysToIgnore.Contains(prop.Name));

                if (filter != null)
                {
                    doCheckDiff = (filter.Contains(prop.Name) && !invert) || (!filter.Contains(prop.Name) && invert);
                }

                if (prop.PropertyType == typeof(string))
                {
                    string kissValue = prop.GetValue(kissPerson, null) as string;
                    string newodValue = prop.GetValue(neuePerson, null) as string;

                    if (fieldsToBreak.Contains(prop.Name))
                    {
                        System.Diagnostics.Debugger.Break();
                    }

                    // wenn null kein update
                    // also kisswert zuweisen
                    if (newodValue == null && kissValue != null)
                    {
                        newodValue = kissValue;
                        prop.SetValue(neuePerson, newodValue, null);
                    }

                    if (!passthru && doCheckDiff && kissValue != newodValue)
                    {
                        differences.Add(prop);
                    }
                }
                else if (prop.PropertyType == typeof(ulong?))
                {
                    ulong? kissValue = prop.GetValue(kissPerson, null) as ulong?;
                    ulong? newodValue = prop.GetValue(neuePerson, null) as ulong?;

                    if (fieldsToBreak.Contains(prop.Name))
                    {
                        System.Diagnostics.Debugger.Break();
                    }

                    // wenn null kein update
                    // also kisswert zuweisen
                    if (newodValue == null && kissValue != null)
                    {
                        newodValue = kissValue;
                        prop.SetValue(neuePerson, newodValue, null);
                    }

                    if (!passthru && doCheckDiff && kissValue != newodValue)
                    {
                        differences.Add(prop);
                    }
                }
                else if (prop.PropertyType == typeof(int?))
                {
                    int? kissValue = prop.GetValue(kissPerson, null) as int?;
                    int? newodValue = prop.GetValue(neuePerson, null) as int?;

                    if (fieldsToBreak.Contains(prop.Name))
                    {
                        System.Diagnostics.Debugger.Break();
                    }

                    if (prop.Name == PropertyName.GetPropertyName(() => kissPerson.HeimatgemeindeBaGemeindeID) && kissValue.HasValue && neuePerson.HeimatgemeindeBaGemeindeIds.Contains(kissValue.Value))
                    {
                        // Hauptheimatort nicht ändern wenn es noch in der neuen Liste von Heimatorten vorhanden ist
                        newodValue = kissValue;
                        prop.SetValue(neuePerson, newodValue, null);
                    }
                    else if (prop.Name == PropertyName.GetPropertyName(() => kissPerson.ZivilstandCode) && kissValue == 6)
                    {
                        newodValue = kissValue;
                        prop.SetValue(neuePerson, newodValue, null);
                    }
                    else if (prop.Name == PropertyName.GetPropertyName(() => kissPerson.AuslaenderStatusCode))
                    {
                        // ist Ausländer
                        if (neuePerson.NationalitaetCode != 147)
                        {
                            // kein update
                            if (kissValue == 11 || kissValue == 15 || kissValue == 16 || kissValue == 17 || newodValue == null)
                            {
                                newodValue = kissValue;
                                prop.SetValue(neuePerson, newodValue, null);
                            }
                        }
                    }
                    else if (newodValue == null && kissValue != null)
                    {
                        newodValue = kissValue;
                        prop.SetValue(neuePerson, newodValue, null);
                    }

                    //Die Felder der Adresse interesieren uns nicht
                    if (!passthru && doCheckDiff && kissValue != newodValue)
                    {
                        differences.Add(prop);
                    }
                }
                else if (prop.PropertyType == typeof(DateTime?))
                {
                    DateTime? kissValue = (DateTime?)prop.GetValue(kissPerson, null);

                    if (kissValue == DateTime.MinValue)
                    {
                        kissValue = null;
                    }

                    DateTime? newodValue = (DateTime?)prop.GetValue(neuePerson, null);

                    if (fieldsToBreak.Contains(prop.Name))
                    {
                        System.Diagnostics.Debugger.Break();
                    }

                    // wenn null kein update
                    // Ausnahme AuslaenderStatusGueltigBis, ErteilungVA
                    // also kisswert zuweisen
                    if (!passthru && doCheckDiff && newodValue == null && kissValue != null && prop.Name != PropertyName.GetPropertyName(() => kissPerson.AuslaenderStatusGueltigBis) && prop.Name != PropertyName.GetPropertyName(() => kissPerson.ErteilungVA))
                    {
                        newodValue = kissValue;
                        prop.SetValue(neuePerson, newodValue, null);
                    }

                    //Die Felder der Adresse interesieren uns nicht
                    if (!passthru && doCheckDiff && kissValue != newodValue)
                    {
                        differences.Add(prop);
                    }
                }
                else if (prop.PropertyType == typeof(List<int>))
                {
                    var kissValue = prop.GetValue(kissPerson, null) as List<int>;
                    var newodValue = prop.GetValue(neuePerson, null) as List<int>;

                    if (fieldsToBreak.Contains(prop.Name))
                    {
                        System.Diagnostics.Debugger.Break();
                    }

                    // wenn null kein update
                    // also kisswert zuweisen
                    if (newodValue == null && kissValue != null && kissValue.Count > 0)
                    {
                        newodValue = kissValue;
                        prop.SetValue(neuePerson, newodValue, null);
                    }

                    // wenn newod einen wert hat, kiss aber nicht,
                    // update
                    if (newodValue != null && newodValue.Count > 0 && kissValue == null)
                    {
                        differences.Add(prop);
                    }
                    else if (!passthru && doCheckDiff && newodValue != null && kissValue != null && !newodValue.SequenceEqual(kissValue))
                    {
                        differences.Add(prop);
                    }
                }
            }

            return differences;
        }

        /// <summary>
        /// Liefert Person nach ihrer ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public BaPerson GetPerson(string id)
        {
            int matches;

            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            var criteria = new PersonSearchCriteria();
            criteria.ID = id;

            var lst = SearchPerson(criteria, out matches);

            return lst[0];
        }

        /// <summary>
        /// Liefert die gemappten KiSS-Personen einer Liste von NewodPersonen
        /// </summary>
        /// <param name="lst">Liste von NewodPersonen</param>
        /// <returns></returns>
        public List<BaPerson> GetRelatedBaPersons(List<NewodPerson> lst)
        {
            int totalMatches;

            var criteria = new PersonSearchCriteria();
            criteria.ID = String.Join(",", lst.Select(x => x.ID));

            return SearchPerson(criteria, out totalMatches);
        }

        /// <summary>
        /// Fügt eine Person mit Wohnsitzadresse in die Datenbank
        /// </summary>
        /// <param name="prs">Person</param>
        /// <returns></returns>
        public BaPerson Insert(Person prs)
        {
            Session.BeginTransaction();

            try
            {
                DBUtil.NewHistoryVersion();
                var baPerson = Create(prs);
                InsertAddress(baPerson.ID, prs.AdressDaten);
                Session.Commit();
                return GetPerson(baPerson.ID);
            }
            catch (Exception ex)
            {
                Session.Rollback();
                throw new ApplicationException(ex.ToString());
            }
        }

        /// <summary>
        /// Suche nach KiSS-Personen gemäss Suchkriterien
        /// Liefert Liste mit BaPersonen zurück
        /// </summary>
        /// <param name="criteria">Suchkriterien</param>
        /// <param name="totalMatches">Anzahl Treffer.</param>
        /// <returns></returns>
        public List<BaPerson> SearchPerson(PersonSearchCriteria criteria, out int totalMatches)
        {
            criteria.Trim();

            String sqlBaPerson = @"SELECT
                                     NewodID                           =     BAN.NewodPersonID,
                                     AuslaenderAktiveSozialHilfe       =     BAN.[AuslaenderAktiveSozialHilfe],
                                     SchweizerAktiveSozialHilfe        =     BAN.[SchweizerAktiveSozialHilfe],
                                     SchweizerAktiveVormundschaft      =     BAN.[SchweizerAktiveVormundschaft],
                                     PLZOrt     = PRS.WohnsitzPLZOrt,
                                     [Alter]    = CONVERT(INT, ((DATEDIFF(dd, Geburtsdatum, GETDATE()) + .5) / 365.25)),
                                     Geschlecht = CASE GeschlechtCode WHEN 1 THEN 'm'
                                                         WHEN 2 THEN 'w'
                                                         ELSE ''
                                     END,
                                     FT         = CONVERT(BIT, CASE WHEN EXISTS(SELECT TOP 1 1
                                                                   FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                                                   WHERE BaPersonID = PRS.BaPersonID) THEN 1
                                                       ELSE 0
                                                  END),
                                     PRS.*,
                                     Nationalitaet      = CO1.Iso2Code,
                                     ZuzugGdeLand       = CO2.Iso2Code,
                                     WegzugLand         = CO3.Iso2Code
                                   FROM dbo.vwPerson PRS WITH (READUNCOMMITTED)
                                     LEFT JOIN BaLand CO1 WITH (READUNCOMMITTED) ON CO1.BaLandID = PRS.NationalitaetCode
                                     LEFT JOIN BaLand CO2 WITH (READUNCOMMITTED) ON CO2.BaLandID = PRS.ZuzugGdeLandCode
                                     LEFT JOIN BaLand CO3 WITH (READUNCOMMITTED) ON CO3.BaLandID = PRS.WegzugLandCode
                                     LEFT JOIN BaPerson_NewodPerson BAN ON PRS.BaPersonID = BAN.BaPersonID
                                   WHERE 1 = 1 ";

            // prepare sql
            if (criteria.IsMapped)
            {
                sqlBaPerson = @"SELECT BaPersonID                        =     BAN.BaPersoNID,
                                       NewodID                           =     BAN.NewodPersonID,
                                       AuslaenderAktiveSozialHilfe       =     BAN.[AuslaenderAktiveSozialHilfe],
                                       SchweizerAktiveSozialHilfe        =     BAN.[SchweizerAktiveSozialHilfe],
                                       SchweizerAktiveVormundschaft      =     BAN.[SchweizerAktiveVormundschaft]
                                FROM BaPerson_NewodPerson BAN";
            }
            else if (criteria.ID != null)
            {
                sqlBaPerson += @" AND PRS.BaPersonID in (" + criteria.ID + ")";
            }
            else if (criteria.NewodNummer != null)
            {
                sqlBaPerson += @" AND BAN.NewodPersonID in (" + criteria.NewodNummer + ")";
            }
            else
            {
                if (criteria.LastName != null)
                {
                    if (criteria.Soundex)
                    {
                        sqlBaPerson += " AND SOUNDEX(PRS.Name) = SOUNDEX(" + DBUtil.SqlLiteral(criteria.LastName) + ") ";
                    }
                    else
                    {
                        sqlBaPerson += " AND PRS.Name LIKE " + DBUtil.SqlLiteralLike(criteria.LastName + "%");
                    }
                }

                if (criteria.FirstName != null)
                {
                    if (criteria.Soundex)
                    {
                        sqlBaPerson += " AND SOUNDEX(PRS.Vorname) = SOUNDEX(" + DBUtil.SqlLiteral(criteria.FirstName) + ") ";
                    }
                    else
                    {
                        sqlBaPerson += " AND PRS.Vorname LIKE " + DBUtil.SqlLiteralLike(criteria.FirstName + "%");
                    }
                }

                // Geburt von
                if (criteria.BirthDayFrom.HasValue)
                {
                    sqlBaPerson += " AND PRS.Geburtsdatum >= " + DBUtil.SqlLiteral(criteria.BirthDayFrom);
                }

                // Geburt bis
                if (criteria.BirthDayTo.HasValue)
                {
                    sqlBaPerson += " AND PRS.Geburtsdatum <= " + DBUtil.SqlLiteral(criteria.BirthDayTo);
                }

                // TODO: Wildcard (gleicher Verhalten wie NewodService)
                if (criteria.Ahv11 != null)
                {
                    sqlBaPerson += " AND PRS.AHVNummer LIKE " + DBUtil.SqlLiteralLike(criteria.Ahv11 + "%");
                }

                if (criteria.Ahv13 != null)
                {
                    sqlBaPerson += " AND PRS.Versichertennummer LIKE " + DBUtil.SqlLiteralLike(criteria.Ahv13 + "%");
                }

                if (criteria.Strasse != null)
                {
                    sqlBaPerson += " AND PRS.WohnsitzStrasse LIKE " + DBUtil.SqlLiteralLike(criteria.Strasse + "%");
                }

                if (criteria.Plz != null)
                {
                    sqlBaPerson += " AND PRS.WohnsitzPLZ LIKE " + DBUtil.SqlLiteralLike(criteria.Plz + "%");
                }

                if (criteria.Ort != null)   // TODO mach Ort als Suchkriterium Sinn?
                {
                    sqlBaPerson += " AND PRS.WohnsitzOrt LIKE " + DBUtil.SqlLiteralLike(criteria.Ort + "%");
                }

                if (criteria.Country != null)
                {
                    sqlBaPerson += " AND PRS.NationalitaetCode = " + DBUtil.SqlLiteral(criteria.Country);
                }

                if (criteria.OnlyFT)
                {
                    sqlBaPerson += @" AND EXISTS(SELECT TOP 1 1
                       FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                       WHERE BaPersonID = PRS.BaPersonID)";
                }

                sqlBaPerson += " ORDER BY Name, Vorname, Geburtsdatum";
            }

            var qry = new SqlQuery();

            try
            {
                qry.Fill(sqlBaPerson);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Fehler bei Suche nach KiSSPersonen", ex);
            }

            var lst = new List<BaPerson>();

            foreach (DataRow row in qry.DataTable.Rows)
            {
                //Container für Basisdaten (Name,Vorname,AHV)
                var basisdaten = new PersonBasisDaten();

                //Container für Adressdaten
                var adresse = new PersonAdressDaten();

                basisdaten.ID = row[DBO.vwPerson.BaPersonID].ToString();

                if (!criteria.IsMapped)
                {
                    basisdaten.IsFT = Utils.ConvertToBool(row["FT"]);
                    basisdaten.AHVNummer = row[DBO.vwPerson.AHVNummer].ToString();

                    basisdaten.AuslaenderStatusCode = row[DBO.vwPerson.AuslaenderStatusCode] as int?;
                    basisdaten.AuslaenderStatusGueltigBis = Utils.ConvertToDateTime(row[DBO.vwPerson.AuslaenderStatusGueltigBis]);

                    basisdaten.Alter = row[DBO.vwPerson.Alter] as int?;
                    basisdaten.AnredeText = row[DBO.vwPerson.Titel].ToString();
                    basisdaten.ErteilungVA = Utils.ConvertToDateTime(row[DBO.vwPerson.ErteilungVA]);
                    basisdaten.FaxPrivat = row[DBO.vwPerson.Fax].ToString();
                    basisdaten.FruehererName = row[DBO.vwPerson.FruehererName].ToString();
                    basisdaten.Geburtsdatum = Utils.ConvertToDateTime(row[DBO.vwPerson.Geburtsdatum]);
                    basisdaten.GeschlechtCode = row[DBO.vwPerson.GeschlechtCode] as int?;
                    basisdaten.HeimatgemeindeBaGemeindeID = row[DBO.vwPerson.HeimatgemeindeBaGemeindeID] as int?;
                    if (!DBUtil.IsEmpty(row[DBO.vwPerson.HeimatgemeindeCodes]))
                    {
                        basisdaten.HeimatgemeindeBaGemeindeIds = new List<string>(row[DBO.vwPerson.HeimatgemeindeCodes].ToString().Split(',').Where(x => !string.IsNullOrEmpty(x))).ConvertAll(Convert.ToInt32);
                    }

                    basisdaten.KonfessionCode = row[DBO.vwPerson.KonfessionCode] as int?;
                    basisdaten.Name = row[DBO.vwPerson.Name].ToString();

                    basisdaten.NationalitaetCode = row[DBO.vwPerson.NationalitaetCode] as int?;
                    basisdaten.Nationalitaet = row[DBO.vwPerson.Nationalitaet].ToString();
                    basisdaten.Sterbedatum = Utils.ConvertToDateTime(row[DBO.vwPerson.Sterbedatum]);
                    basisdaten.SpracheCode = row[DBO.vwPerson.SprachCode] as int?;
                    basisdaten.TelefonPrivat = row[DBO.vwPerson.Telefon_P].ToString();
                    basisdaten.Versichertennummer = ParseVersichertenNummer(row[DBO.vwPerson.Versichertennummer] as string);
                    basisdaten.Vorname = row[DBO.vwPerson.Vorname].ToString();
                    basisdaten.ZivilstandCode = row[DBO.vwPerson.ZivilstandCode] as int?;
                    basisdaten.ZivilstandDatum = Utils.ConvertToDateTime(row[DBO.vwPerson.ZivilstandDatum]);
                    basisdaten.ZemisNummer = row[DBO.vwPerson.ZEMISNummer].ToString();

                    //Zuzug
                    try
                    {
                        basisdaten.ZuzugPlz = row[DBO.vwPerson.ZuzugGdePLZ].ToString();
                    }
                    catch
                    {
                        basisdaten.ZuzugPlz = null;
                    }

                    basisdaten.ZuzugOrt = row[DBO.vwPerson.ZuzugGdeOrt].ToString();
                    basisdaten.ZuzugOrtCode = row[DBO.vwPerson.ZuzugGdeOrtCode] as int?;
                    basisdaten.ZuzugKanton = row[DBO.vwPerson.ZuzugGdeKanton].ToString();
                    basisdaten.ZuzugLandCode = row[DBO.vwPerson.ZuzugGdeLandCode] as int?;
                    basisdaten.ZuzugLand = row[DBO.vwPerson.ZuzugGdeLandCode].ToString();
                    basisdaten.ZuzugDatum = Utils.ConvertToDateTime(row[DBO.vwPerson.ZuzugGdeDatum]);

                    //Wegzug
                    basisdaten.WegzugPlz = row[DBO.vwPerson.WegzugPLZ].ToString();
                    basisdaten.WegzugOrt = row[DBO.vwPerson.WegzugOrt].ToString();
                    basisdaten.WegzugOrtCode = row[DBO.vwPerson.WegzugOrtCode] as int?;
                    basisdaten.WegzugKanton = row[DBO.vwPerson.WegzugKanton].ToString();
                    basisdaten.WegzugLandCode = row[DBO.vwPerson.WegzugLandCode] as int?;
                    basisdaten.WegzugLand = row[DBO.vwPerson.WegzugLandCode].ToString();
                    basisdaten.WegzugDatum = Utils.ConvertToDateTime(row[DBO.vwPerson.WegzugDatum]);

                    //Adressdaten
                    adresse.Strasse = row[DBO.vwPerson.WohnsitzStrasse].ToString();
                    adresse.Zusatz = row[DBO.vwPerson.WohnsitzAdressZusatz].ToString();
                    adresse.Postfach = row[DBO.vwPerson.WohnsitzPostfach].ToString();
                    adresse.HausNr = row[DBO.vwPerson.WohnsitzHausNr].ToString();
                    adresse.Plz = row[DBO.vwPerson.WohnsitzPLZ].ToString();
                    adresse.Ort = row[DBO.vwPerson.WohnsitzOrt].ToString();
                    adresse.Kanton = row[DBO.vwPerson.WohnsitzKanton].ToString();
                    adresse.LandId = row[DBO.vwPerson.WohnsitzBaLandID] as int?;
                }

                BaPersonNewodFlags newodFlags = new BaPersonNewodFlags();

                newodFlags.NewodID = row["NewodID"].ToString();
                newodFlags.AuslaenderAktiveSozialHilfe = Utils.ConvertToBool(row[DBO.BaPerson_NewodPerson.AuslaenderAktiveSozialhilfe]);
                newodFlags.SchweizerAktiveSozialHilfe = Utils.ConvertToBool(row[DBO.BaPerson_NewodPerson.SchweizerAktiveSozialhilfe]);
                newodFlags.AktiveVormundschaft = Utils.ConvertToBool(row[DBO.BaPerson_NewodPerson.SchweizerAktiveVormundschaft]);

                BaPerson prs = new BaPerson(newodFlags, basisdaten, adresse);

                lst.Add(prs);
            }

            totalMatches = lst.Count;
            return lst;
        }

        public void StartKomplettImport(ProcessNewodImportMessageDelegate messageDelegate, int baPersonId = 0)
        {
            _newodMessageDelegate = messageDelegate;
            var startTime = DateTime.Now;
            // Newod-Personen von DB bestimmen
            var newodPersonen = DBUtil.OpenSQL(@"SELECT MAP.BaPersonID, MAP.NewodPersonID
                                               FROM dbo.BaPerson PRS
                                                 INNER JOIN dbo.BaPerson_NewodPerson MAP ON MAP.BaPersonID = PRS.BaPersonID
                                               WHERE {0} != 0 AND PRS.BaPersonID = {0} OR {0} = 0;", baPersonId);

            SetNewodStatusMessage(string.Format("{0} Personen für Import bestimmt", newodPersonen.Count));
            //initialize service
            var svcNewod = new NewodService(DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\URL", null), DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\Username", null), DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\Passwort", null), GetProxySetting(), 0);
            var successfulImports = 0;
            var count = 0;
            var total = newodPersonen.Count;

            // get mutationen
            foreach (var newodPerson in newodPersonen.DataTable.Select())
            {
                count++;
                try
                {
                    SetNewodStatusMessage(
                        string.Format("Importiere Person aus Newod: BaPersonID {0}, Newod-ID {1} ({2} von {3})",
                                      newodPerson["BaPersonID"], newodPerson["NewodPersonID"], count, total));
                    var request = new GetPersonRequest { ID = newodPerson["NewodPersonID"].ToString() };
                    int countRetryCallingService = 0;
                    int totalCallsAllowed = 3;
                    NewodPerson person = null;
                    do
                    {
                        countRetryCallingService++;
                        try
                        {
                            person = svcNewod.GetPerson(request, true);
                            break;
                        }
                        catch (Exception)
                        {
                            SetNewodStatusMessage(string.Format("Fehler bei Newod-Service-Aufruf GetPerson, Versuch {0} / {1}", countRetryCallingService, totalCallsAllowed));
                            if (countRetryCallingService >= totalCallsAllowed)
                            {
                                throw;
                            }

                            // Wait 150 ms for next service call
                            Thread.Sleep(150);
                        }
                    }
                    while (countRetryCallingService < totalCallsAllowed);
                    UpdateBasisDaten(new GetPersonRequest { ID = newodPerson["BaPersonID"].ToString() }, person);
                    XLog.Create(GetType().FullName, 1, LogLevel.INFO, "Person per Batchlauf importiert", string.Format("NewodID {0}", newodPerson["BaPersonID"]), "BaPerson", Convert.ToInt32(newodPerson["BaPersonID"]));
                    successfulImports++;
                }
                catch (Exception ex)
                {
                    var msg = string.Format("Fehler beim Importieren der Newod-Person {0} (BaPersonID {1}): {2}", newodPerson["NewodPersonID"], newodPerson["BaPersonID"], ex.Message);
                    XLog.Create(GetType().FullName, 1, LogLevel.ERROR, "Fehler", msg, "BaPerson", 0);
                    SetNewodStatusMessage(msg);
                }
            }

            var duration = (DateTime.Now - startTime);
            SetNewodStatusMessage(string.Format("Ende Import, Dauer {0:00}:{1:00}:{2:00}, {3} von {4} Personen erfolgreich importiert", duration.Hours, duration.Minutes, duration.Seconds, successfulImports, total));
        }

        /// <summary>
        /// Aktualisiert die Adressdaten einer KiSSPerson
        /// Schliesst bestehende Adressen entsprechend ab (DatumVon/Bis)
        /// </summary>
        /// <param name="request">Das Requestobjekt.</param>
        /// <param name="kissPerson">BaPerson</param>
        /// <param name="newPerson">NewodPerson</param>
        public void UpdateAdressDaten(GetPersonRequest request, BaPerson kissPerson, NewodPerson newPerson)
        {
            // Existiert bereits ein Record mit gleichem DatumVon?
            var qry = DBUtil.OpenSQL(@"
                SELECT BaAdresseID,
                       Strasse,
                       Zusatz,
                       HausNr,
                       PLZ,
                       Ort,
                       Kanton,
                       BaLandID
                FROM dbo.BaAdresse
                WHERE AdresseCode = 1
                  AND BaPersonID = {0}
                  AND DatumVon = {1}",
                Convert.ToInt32(request.ID),
                request.ValidFrom);

            if (qry.Count != 0)
            {
                kissPerson.Strasse = qry.DataTable.Rows[0][DBO.BaAdresse.Strasse].ToString();
                kissPerson.Zusatz = qry.DataTable.Rows[0][DBO.BaAdresse.Zusatz].ToString();
                kissPerson.HausNr = qry.DataTable.Rows[0][DBO.BaAdresse.HausNr].ToString();
                kissPerson.Plz = qry.DataTable.Rows[0][DBO.BaAdresse.PLZ].ToString();
                kissPerson.Ort = qry.DataTable.Rows[0][DBO.BaAdresse.Ort].ToString();
                kissPerson.Kanton = qry.DataTable.Rows[0][DBO.BaAdresse.Kanton].ToString();
                kissPerson.LandId = qry.DataTable.Rows[0][DBO.BaAdresse.BaLandID] as int?;

                var diffs = Diff(kissPerson, newPerson);

                //Wenn Unterschiede Update der Adresse
                if (diffs.Count != 0)
                {
                    UpdateSingleAddress(qry.DataTable.Rows[0]["BaAdresseID"].ToString(), newPerson.AdressDaten);
                }
            }
            else
            {
                // neue Adresse muss eingefügt werden
                newPerson.DatumVon = request.ValidFrom;

                // existieren Adressen in der Vergangenheit?
                // nimmt die Adresse mit dem aktuellsten DatumVon
                string pastrecords = @"
                    SELECT TOP 1 BaAdresseID
                    FROM dbo.BaAdresse ADR
                    WHERE AdresseCode = 1
                      AND BaPersonID = {0}
                      AND (DatumVon IS NULL OR DatumVon < {1})
                    ORDER BY DatumVon DESC";

                qry.Fill(pastrecords, Convert.ToInt32(request.ID), request.ValidFrom);

                if (qry.Count != 0)
                {
                    DateTime previousDay = request.ValidFrom.AddDays(-1);

                    // setze DatumBis Datum der vergangenen Adresse (DatumVon-1 der neuen Adresse)
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE BaAdresse
                        SET DatumBis = {0}
                        WHERE BaAdresseID = {1} ", previousDay, Convert.ToInt32(qry["BaAdresseID"]));
                }

                newPerson.DatumBis = null;
                DateTime? abschlussdatum = null;

                // existieren Adressen in der Zukunft?
                // nimmt den record mit dem nächsten DatumVon
                string futurerecords = @"
                    SELECT TOP 1
                           BaAdresseID,
                           DatumVon
                    FROM dbo.BaAdresse ADR
                    WHERE AdresseCode = 1
                      AND BaPersonID = {0}
                      AND DatumVon > {1}
                    ORDER BY DatumVon ASC";

                qry.Fill(futurerecords, Convert.ToInt32(request.ID), request.ValidFrom);

                if (qry.Count != 0)
                {
                    if (qry.DataTable.Rows[0]["DatumVon"].ToString() != "")
                        abschlussdatum = Utils.ConvertToDateTime(qry.DataTable.Rows[0]["DatumVon"]).AddDays(-1);

                    // setzte DatumBis bei neuer Adresse (DatumVon-1 der zukünftigen Adresse)
                    newPerson.DatumBis = abschlussdatum;
                }

                //Damit die neue Adresse einen eigenen Eintrag im History-Dialog hat, muss hier
                //ein neuer HistoryVersion-Eintrag erstellt werden
                DBUtil.NewHistoryVersion();

                // Erstelle neue Adresse
                InsertAddress(request.ID, newPerson.AdressDaten);
            }
        }

        /// <summary>
        /// Aktualisiert die Basidaten einer KiSSPerson
        /// </summary>
        /// <param name="request">Das Requestobjekt.</param>
        /// <param name="neuePerson">Person</param>
        public void UpdateBasisDaten(GetPersonRequest request, Person neuePerson)
        {
            Update(request.ID, neuePerson);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Speichert eine Person in der Datenbank (BaPerson)
        /// </summary>
        /// <param name="prs">Person</param>
        /// <returns></returns>
        private BaPerson Create(Person prs)
        {
            string anrede = prs.AnredeText;

            string sqlBaPerson = @"
                    INSERT INTO dbo.BaPerson (
                        Name,
                        Vorname,
                        FruehererName,
                        Geburtsdatum,
                        SterbeDatum,
                        AHVNummer,
                        Versichertennummer,
                        Titel,
                        GeschlechtCode,
                        ZivilstandCode,
                        ZivilstandDatum,
                        SprachCode,
                        AuslaenderStatusCode,
                        AuslaenderStatusGueltigBis,
                        ErteilungVA,
                        HeimatgemeindeBaGemeindeID,
                        HeimatgemeindeCodes,
                        Telefon_P,
                        NationalitaetCode,
                        ZuzugGdePLZ,
                        ZuzugGdeOrt,
                        ZuzugGdeOrtCode,
                        ZuzugGdeKanton,
                        ZuzugGdeLandCode,
                        ZuzugGdeDatum,
                        WegzugPLZ,
                        WegzugOrt,
                        WegzugOrtCode,
                        WegzugKanton,
                        WegzugLandCode,
                        WegzugDatum,
                        ZemisNummer,
                        Creator,
                        Created,
                        Modifier,
                        Modified
                    )
                    VALUES (
                        {0},
                        {1},
                        {2},
                        {3},
                        {4},
                        {5},
                        {6},
                        {7},
                        {8},
                        {9},
                        {10},
                        {11},
                        {12},
                        {13},
                        {14},
                        {15},
                        {16},
                        {17},
                        {18},
                        {19},
                        {20},
                        {21},
                        {22},
                        {23},
                        {24},
                        {25},
                        {26},
                        {27},
                        {28},
                        {29},
                        {30},
                        {31},
                        {32},
                        GetDate(),
                        {32},
                        GetDate()
                    );

                    SELECT SCOPE_IDENTITY();";

            object result = DBUtil.ExecuteScalarSQLThrowingException(sqlBaPerson,
                prs.Name,
                prs.Vorname,
                prs.FruehererName,
                prs.Geburtsdatum,
                prs.Sterbedatum,
                prs.AHVNummer,
                FormatVersichertenNummer(prs.Versichertennummer),
                anrede,
                prs.GeschlechtCode,
                prs.ZivilstandCode,
                prs.ZivilstandDatum,
                prs.SpracheCode,
                prs.AuslaenderStatusCode,
                prs.AuslaenderStatusGueltigBis,
                prs.ErteilungVA,
                prs.HeimatgemeindeBaGemeindeID,
                string.Join(",", prs.HeimatgemeindeBaGemeindeIds),
                prs.TelefonPrivat,
                prs.NationalitaetCode,
                prs.ZuzugPlz,
                prs.ZuzugOrt,
                prs.ZuzugOrtCode,
                prs.ZuzugKanton,
                prs.ZuzugLandCode,
                prs.ZuzugDatum,
                prs.WegzugPlz,
                prs.WegzugOrt,
                prs.WegzugOrtCode,
                prs.WegzugKanton,
                prs.WegzugLandCode,
                prs.WegzugDatum,
                prs.ZemisNummer,
                DBUtil.GetDBRowCreatorModifier()
            );

            string baPersonID = string.Empty;
            if (result != null)
            {
                baPersonID = Convert.ToString(result);
            }

            return GetPerson(baPersonID);
        }

        private string FormatVersichertenNummer(ulong? versichertenNummer)
        {
            if (!versichertenNummer.HasValue)
                return null;

            return versichertenNummer.Value.ToString("###'.'####'.'####'.'##", System.Globalization.CultureInfo.InvariantCulture);
        }

        private string GetProxySetting()
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

            return proxy;
        }

        /// <summary>
        /// Fügt einen neuen Wohnsitz hinzu.
        /// </summary>
        /// <param name="baPersonID">BaPersonID</param>
        /// <param name="adresse">Adressdaten</param>
        private void InsertAddress(string baPersonID, PersonAdressDaten adresse)
        {
            string sqlBaAdresse = @"
                    INSERT INTO dbo.BaAdresse (
                        [BaPersonID],
                        [DatumVon],
                        [DatumBis],
                        [AdresseCode],
                        [Strasse],
                        [HausNr],
                        [PLZ],
                        [Ort],
                        [Kanton],
                        [BaLandID],
                        [Creator],
                        [Modifier]
                    )
                    VALUES (
                        {0},
                        {1},
                        {2},
                        {3},
                        {4},
                        {5},
                        {6},
                        {7},
                        {8},
                        {9},
                        {10},
                        {10}
                     );";

            DBUtil.ExecSQLThrowingException(
                sqlBaAdresse,
                baPersonID,
                adresse.DatumVon,
                adresse.DatumBis,
                1,
                adresse.Strasse,
                adresse.HausNr,
                adresse.Plz,
                adresse.Ort,
                adresse.Kanton,
                adresse.LandId,
                DBUtil.GetDBRowCreatorModifier());
        }

        private ulong? ParseVersichertenNummer(string versichertenNummerString)
        {
            if (string.IsNullOrEmpty(versichertenNummerString))
            {
                return null;
            }

            ulong versichertenNummer;

            if (ulong.TryParse(versichertenNummerString.Replace(".", ""), out versichertenNummer))
            {
                if (versichertenNummer == 0)
                {
                    return null;
                }

                return versichertenNummer;
            }

            return null;
        }

        private void SetNewodStatusMessage(string message)
        {
            if (_newodMessageDelegate != null)
            {
                _newodMessageDelegate(message);
            }
        }

        /// <summary>
        /// Aktualisiert eine Person in der Datenbank (BaPerson)
        /// </summary>
        /// <param name="baPersonID">BaPersonID</param>
        /// <param name="prs">Person</param>
        private void Update(string baPersonID, Person prs)
        {
            string sqlBaPerson = @"
                    UPDATE dbo.BaPerson
                        SET
                        Name                            = {0},
                        Vorname                         = {1},
                        FruehererName                   = {2},
                        Geburtsdatum                    = {3},
                        SterbeDatum                     = {4},
                        AHVNummer                       = {5},
                        Versichertennummer              = {6},
                        Titel                           = {7},
                        GeschlechtCode                  = {8},
                        ZivilstandCode                  = {9},
                        ZivilstandDatum                 = {10},
                        SprachCode                      = {11},
                        AuslaenderStatusCode            = {12},
                        AuslaenderStatusGueltigBis      = {13},
                        --ErteilungVA                     = {14}, --KBE-1486
                        HeimatgemeindeBaGemeindeID      = {15},
                        HeimatgemeindeCodes             = {16},
                        NationalitaetCode               = {17},
                        ZuzugGdePLZ                     = {18},
                        ZuzugGdeOrt                     = {19},
                        ZuzugGdeOrtCode                 = {20},
                        ZuzugGdeKanton                  = {21},
                        ZuzugGdeLandCode                = {22},
                        ZuzugGdeDatum                   = {23},
                        WegzugPLZ                       = {24},
                        WegzugOrt                       = {25},
                        WegzugOrtCode                   = {26},
                        WegzugKanton                    = {27},
                        WegzugLandCode                  = {28},
                        WegzugDatum                     = {29},
                        ZemisNummer                     = {30},
                        Modifier                        = {31},
                        Modified                        = GETDATE()
                      WHERE BaPersonID = {32};
                    ";

            DBUtil.NewHistoryVersion();

            DBUtil.ExecSQLThrowingException(sqlBaPerson,
                prs.Name,
                prs.Vorname,
                prs.FruehererName,
                prs.Geburtsdatum,
                prs.Sterbedatum,
                prs.AHVNummer,
                FormatVersichertenNummer(prs.Versichertennummer),
                prs.AnredeText,
                prs.GeschlechtCode,
                prs.ZivilstandCode,
                prs.ZivilstandDatum,
                prs.SpracheCode,
                prs.AuslaenderStatusCode,
                prs.AuslaenderStatusGueltigBis,
                prs.ErteilungVA,
                prs.HeimatgemeindeBaGemeindeID,
                string.Join(",", prs.HeimatgemeindeBaGemeindeIds),
                prs.NationalitaetCode,
                prs.ZuzugPlz,
                prs.ZuzugOrt,
                prs.ZuzugOrtCode,
                prs.ZuzugKanton,
                prs.ZuzugLandCode,
                prs.ZuzugDatum,
                prs.WegzugPlz,
                prs.WegzugOrt,
                prs.WegzugOrtCode,
                prs.WegzugKanton,
                prs.WegzugLandCode,
                prs.WegzugDatum,
                prs.ZemisNummer,
                DBUtil.GetDBRowCreatorModifier(),
                Convert.ToInt32(baPersonID));
        }

        /// <summary>
        /// Aktualisiert eine einzelne Adresse in der Datenbank
        /// </summary>
        /// <param name="baAdressID">BaAdressID</param>
        /// <param name="adresse">Adressedaten</param>
        private void UpdateSingleAddress(string baAdressID, PersonAdressDaten adresse)
        {
            string sqlBaAdresse = @"
                UPDATE dbo.BaAdresse
                SET [Strasse]     = {0},
                    [HausNr]      = {1},
                    [PLZ]         = {2},
                    [Ort]         = {3},
                    [Kanton]      = {4},
                    [Zusatz]      = {5},
                    [BaLandID]    = {6},
                    [Modifier]    = {8}
                WHERE BaAdresseID = {7};";

            DBUtil.ExecSQLThrowingException(sqlBaAdresse,
                adresse.Strasse,
                adresse.HausNr,
                adresse.Plz,
                adresse.Ort,
                adresse.Kanton,
                adresse.Zusatz,
                adresse.LandId,
                baAdressID,
                DBUtil.GetDBRowCreatorModifier());
        }

        #endregion

        #endregion

        public string GetStringRepresentation(PropertyInfo info, object elements)
        {
            if (elements == null)
            {
                return "-";
            }

            if (info.PropertyType == typeof(List<int>))
            {
                var intList = (List<int>)elements;
                if (intList.Count == 0)
                {
                    return "-";
                }

                return string.Join(",", intList);
            }

            return elements.ToString();
        }
    }
}