using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Messages;

namespace KiSS4.Sostat
{
    /// <summary>
    /// Summary description for Plausi.
    /// </summary>
    public class Plausi : IDisposable
    {
        #region Fields

        #region Private Static Fields

        private static readonly Boolean HeavyDebug = false; // flag to write out even more logging-entries to logger

        /// The Log4Net logger.
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly string ExportDir;
        private readonly string ExportDirXml;

        #endregion

        #region Private Fields

        private string DSN;
        private bool ExportSuccess = false;
        private String _plausiFehler = String.Empty;
        private int[] _arrayBfsDossierID;
        private int _erhebungsJahr;
        private Interop.SoStat.PlausExClass _plausEx;
        private bool _enablePlausiDuringExport;
        private bool _enableVorbereiten;
        private int _anzahlStichtage = 0;
        private int _anzahlAnfangszustaende = 0;

        #endregion

        #endregion

        #region Constructors

        public Plausi()
            : this(DBUtil.GetConfigInt(@"System\Sostat\Erhebungsjahr", DateTime.Now.Year),
            DBUtil.GetConfigString(@"System\Sostat\DSN", "plausexsql"))
        {
        }

        public Plausi(int Jahr)
            : this(Jahr, DBUtil.GetConfigString(@"System\Sostat\DSN", "plausexsql"))
        {
        }

        public Plausi(int Jahr, string DSN)
        {
            // logging
            logger.Debug(String.Format("Plausi. Jahr='{0}', DSN='{1}', HeavyDebug='{2}'", Jahr, DSN, HeavyDebug));

            this._erhebungsJahr = Jahr;
            this.DSN = DSN;

            this.ExportDir = DBUtil.GetConfigString(@"System\Sostat\Exportpfad", "");
            this.ExportDirXml = DBUtil.GetConfigString(@"System\Sostat\ExportpfadXml", "");

            try
            {
                // try to create dir if not existing yet
                if (!Directory.Exists(this.ExportDir))
                {
                    Directory.CreateDirectory(this.ExportDir);
                }

                // try to create dir if not existing yet
                if (!Directory.Exists(this.ExportDirXml))
                {
                    Directory.CreateDirectory(this.ExportDirXml);
                }
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError("<ClassName>", "ErrorCheckingCreatingDirs", "Es ist ein Fehler beim Prüfen oder Erstellen der PlausEx-Verzeichnisse aufgetreten.", ex);
            }

            // logging
            logger.Debug(String.Format("ExportDir='{0}', ExportDirXml='{1}'", this.ExportDir, this.ExportDirXml));
        }

        #endregion

        #region EventHandlers

        private void plausEx_OnError(VBA.ErrObject error)
        {
            logger.Warn(String.Format("error.Number='{0}', error.Description='{1}'", error.Number, error.Description));

            // add error to string
            _plausiFehler = String.Format("Error '{0}': '{1}'; {2}", error.Number, error.Description, _plausiFehler);
        }

        #endregion

        #region Methods

        #region Public Methods

        private void DeleteAll()
        {
            CreatePlausEx();
            _plausEx.DeleteAll();
        }

        public bool ExportDossier(int bfsDossierID)
        {
            return this.ExportDossier(new int[] { bfsDossierID }, true, true);
        }

        public bool ExportDossier(int[] BfsDossierID, bool enableVorbereiten, bool enablePlausiDuringExport)
        {
            _arrayBfsDossierID = BfsDossierID;
            _enableVorbereiten = enableVorbereiten;
            _enablePlausiDuringExport = enablePlausiDuringExport;

            DlgProgressLog.Show(KissMsg.GetMLMessage("Plausi", "FortschrittSostat", "Fortschritt: Sostat"),
                700, 300,
                new ProgressEventHandler(StartExport),
                null,
                Session.MainForm
            );

            return ExportSuccess;
        }

        #endregion

        #region Private Static Methods

        private static void DeleteEmptyPersons(XmlDocument dossier)
        {
            XmlNamespaceManager ns = new XmlNamespaceManager(dossier.NameTable);
            ns.AddNamespace("z", "#RowsetSchema");

            foreach (XmlNode node in dossier.SelectNodes(@"/xml/dossier/ue/person/z:row[@ausbildung_id='' and @geschlecht_id='' and @zivilstand_id='' and @verwandtschaftsgrad_id='' and @nationalitaet_land_id='' and @geburtsjahr='' and @versichertennummer='']", ns))
            {
                node.ParentNode.RemoveChild(node);

                foreach (XmlNode nodeDel in dossier.SelectNodes(string.Format(@"/xml/dossier/ue/*/*[@ue_person_id='{0}']", node.Attributes["ue_person_id"].Value)))
                {
                    nodeDel.ParentNode.RemoveChild(nodeDel);
                }
            }

            foreach (XmlNode node in dossier.SelectNodes(@"/xml/dossier/hh/person/z:row[@ausbildung_id='' and @geschlecht_id='' and @zivilstand_id='' and @verwandtschaftsgrad_id='' and @nationalitaet_land_id='' and @geburtsjahr='' and @versichertennummer='']", ns))
            {
                node.ParentNode.RemoveChild(node);
            }
        }

        #endregion

        #region Private Methods

        private void CreatePlausEx()
        {
            if (_plausEx != null)
            {
                // cancel
                return;
            }
            _plausEx = new Interop.SoStat.PlausExClass();
            _plausEx.OnError += new Interop.SoStat.__PlausEx_OnErrorEventHandler(plausEx_OnError);
            InitPlausExAndClearSostatDB();
        }

        private void DisposePlausEx()
        {
            if (_plausEx == null)
            {
                // cancel
                return;
            }

            _plausEx.Terminate();
            _plausEx = null;
        }

        private void InitPlausExAndClearSostatDB()
        {
            CreatePlausEx();
            Interop.SoStat.InitParamClass oInitParam = new Interop.SoStat.InitParamClass();

            oInitParam.sFFSVer = String.Format("[KiSS] {0}", Utils.RevisionVersion);
            oInitParam.sDSN = this.DSN;
            oInitParam.sExportDatei = ExportDir + @"SOSTAT.exp";
            oInitParam.lErhebungsJahr = _erhebungsJahr;
            _plausEx.Init(oInitParam);
        }

        private void FillBfsValues(XmlDocument dossier, int dossierID)
        {
            XmlNamespaceManager ns = new XmlNamespaceManager(dossier.NameTable);
            ns.AddNamespace("z", "#RowsetSchema");

            // 2: Text
            // 4: Zahl
            // 5: Datum
            // 7: Bit
            // 8: Auswahl
            SqlQuery qryBFSWert = DBUtil.OpenSQL(@"
            SELECT FRA.Variable,
               FRA.ExportNode,
               FRA.ExportAttribute,
               FRA.ExportPredicate,
               FRA.Vorgabewert,
                           Wert = ISNULL(
               			CASE
                   WHEN 1 = 2 THEN 'NEVERHERE'
                   ELSE CASE WHEN LOV.Code IS NULL THEN
                                  CASE FRA.BFSFeldCode WHEN 2 THEN CONVERT(VARCHAR, VAL.Wert)
                                                                           WHEN 4 THEN CONVERT(BIGINT, CONVERT(FLOAT, CASE WHEN IsNumeric(CONVERT(VARCHAR, VAL.Wert)) = 1 THEN VAL.Wert END))  --numbers ints
                                                       WHEN 5 THEN
                                                              CASE WHEN VAL.Wert = CONVERT(DATETIME, '17530101')
                                                                                            THEN CASE LOWER(FRA.BFSFormat)
                                                                                                      WHEN 'yyyy'  THEN '1' -- Seit Geburt
                                                                                  ELSE ''
                                                                             END
                                                                   WHEN VAL.Wert IS NOT NULL
                                                                                            THEN CASE LOWER(FRA.BFSFormat)
                                                                                                     WHEN 'dd.mm'      THEN SUBSTRING(CONVERT(VARCHAR, VAL.Wert, 104), 1, 5)
                                                                                                     WHEN 'mm.yyyy'    THEN SUBSTRING(CONVERT(VARCHAR, VAL.Wert, 104), 4, 7)
                                                                                                     WHEN 'dd.mm.yyyy' THEN CONVERT(VARCHAR, VAL.Wert, 104)
                                                                                 WHEN 'yyyy'       THEN SUBSTRING(CONVERT(VARCHAR, VAL.Wert, 104), 7, 4)
                                                                                 ELSE CONVERT(VARCHAR,VAL.Wert,104)
                                                                             END
                                                              END
                                                       WHEN 7 THEN
                                                              CASE WHEN SQL_VARIANT_PROPERTY(VAL.Wert, 'BaseType') = 'bit'
                                                                        THEN ((CONVERT(INT, VAL.Wert) + 1 ) % 2) +1 -- true=1 --> 2 für bfs; false=0 --> 2 für BFS
                                                                   ELSE VAL.Wert
                                                              END
                                                                           WHEN 8 THEN
                                                                                  CONVERT(INT, CASE WHEN IsNumeric(CONVERT(VARCHAR, VAL.Wert)) = 1 THEN VAL.Wert END)
                                                       ELSE VAL.Wert
                                  END
                             ELSE CASE WHEN LOV.LOVName = 'BFSLand'  THEN LOV.KurzText
                                       WHEN LOV.LOVName = 'BFSBranche' THEN LOV.KurzText
                                       ELSE CONVERT(varchar, LOV.Code)
                                  END
                        END
              END,
              FRA.VorgabeWert)
            FROM dbo.BfsDossier                DOS WITH (READUNCOMMITTED)
              INNER JOIN dbo.BFSDossierPerson  PRS WITH (READUNCOMMITTED)                                ON PRS.BFSDossierID = DOS.BFSDossierID
              INNER JOIN dbo.BFSFrage          FRA WITH (READUNCOMMITTED)                              ON FRA.BFSKatalogVersionID = DOS.BFSKatalogVersionID AND
              					 FRA.BFSPersonCode = PRS.BFSPersonCode AND
              					  FRA.PersonIndex = PRS.PersonIndex
              LEFT  JOIN dbo.BFSWert           VAL WITH (READUNCOMMITTED) ON VAL.BFSDossierID = DOS.BFSDossierID AND
               VAL.BFSFrageID = FRA.BFSFrageID
              LEFT  JOIN dbo.BFSLOVCode        LOV WITH (READUNCOMMITTED) ON LOV.LOVName = FRA.BFSLOVName             AND
                                                                                     LOV.Code = CASE WHEN FRA.BFSLOVName IS NOT NULL THEN CONVERT(INT, VAL.Wert) END
            WHERE DOS.BFSDossierID = {0}
                    ORDER BY CASE WHEN CHARINDEX('.', FRA.Variable) = 2 THEN '0'
                                  ELSE ''
                             END + FRA.Variable", dossierID);

            XmlNode node;
            foreach (DataRow row in qryBFSWert.DataTable.Rows)
            {
                object value = (row["Wert"]);
                if (DBUtil.IsEmpty(value))
                {
                    value = (row["Vorgabewert"]);
                }

                if (!DBUtil.IsEmpty(row["ExportAttribute"]) && !DBUtil.IsEmpty(value))
                {
                    string xpath = @"/xml";

                    if (!DBUtil.IsEmpty(row["ExportNode"]))
                    {
                        xpath += row["ExportNode"].ToString();
                    }

                    if (!DBUtil.IsEmpty(row["ExportPredicate"]))
                    {
                        xpath += row["ExportPredicate"].ToString();
                    }

                    try
                    {
                        node = dossier.SelectSingleNode(xpath, ns); //XPath könnte falsch formatiert sein
                        if (node != null)
                            node.Attributes[row["ExportAttribute"].ToString()].Value = row["Wert"].ToString(); //Attribut könnte nicht existieren
                    }
                    catch
                    {
                        DlgProgressLog.AddLine(KissMsg.GetMLMessage("Plausi", "XMLFehler", "- XML-Fehler: {0} - {1}", KissMsgCode.Text, xpath, row["ExportAttribute"].ToString()));
                    }
                }
            }
        }

        private void SavePlausiFehler(string xmlFehlerliste, int bfsDossierID)
        {

            // validate
            if (xmlFehlerliste == null || !_enablePlausiDuringExport)
            {
                // logging
                logger.Debug(String.Format("cancel: xmlFehlerliste is null='{0}', plausi='{1}'", (xmlFehlerliste == null), _plausEx));

                // cancel
                return;
            }

            // logging (only for heavy-debug)
            if (HeavyDebug)
            {
                logger.Debug(String.Format("xmlFehlerliste='{0}'", xmlFehlerliste));
            }

            XslCompiledTransform transform = new XslCompiledTransform();

            MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(DBUtil.GetConfigString(@"System\Sostat\RecordSetCleaner", "")));
            XmlTextReader xtr = new XmlTextReader(stream);

            transform.Load(xtr);
            DataSet ds = new DataSet();

            // logging (only for heavy-debug)
            if (HeavyDebug)
            {
                logger.Debug(String.Format("check before ReadXml: transform==null: '{0}', xmlFehlerliste==null: '{1}'", (transform == null), (xmlFehlerliste == null)));
            }

            StringWriter stringWriter = new StringWriter();
            transform.Transform(new XmlTextReader(new StringReader(xmlFehlerliste)), null, stringWriter);
            ds.ReadXml(new StringReader(stringWriter.ToString()));

            // start new transaction
            Session.BeginTransaction();
            try
            {

                // Clear BFSWert PlausiFehler
                DBUtil.ExecSQLThrowingException(String.Format(@"
                        UPDATE dbo.BFSWert
                        SET PlausiFehler = NULL
                        WHERE BFSDossierID = {0}", bfsDossierID));

                if (ds.Tables.Count > 0)
                {
                    // logging
                    if (ds.Tables == null || ds.Tables.Count < 1)
                    {
                        logger.Debug("ds.Tables == null || ds.Tables.Count < 1");
                    }
                    else
                    {
                        if (ds.Tables[0].Rows == null)
                        {
                            logger.Debug("ds.Tables[0].Rows == null!!");
                        }
                        else
                        {
                            logger.Debug(String.Format("ds.Tables[0].Rows.Count='{0}'", ds.Tables[0].Rows.Count));
                        }
                    }

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        // logging (only for heavy-debug)
                        if (HeavyDebug)
                        {
                            logger.Debug(String.Format("row['Text']='{0}', bfsDossierID='{1}', row['VarNo']='{2}'", row["Text"], bfsDossierID, row["VarNo"]));
                        }

                        if (string.IsNullOrEmpty(row["VarNo"] as string))
                        {
                            continue;
                        }

                        //if entry of frage exists, update plausifehler
                        //else make new entry
                        foreach (string varName in ((string)row["VarNo"]).Split(','))
                        {
                            DBUtil.ExecSQLThrowingException(@"
                                DECLARE @BFSDossierPersonID INT
                                DECLARE @BFSFrageID         INT

                                SELECT @BFSDossierPersonID = DOP.BFSDossierPersonID,
                                       @BFSFrageID = FRG.BFSFrageID
                                FROM dbo.BFSDossier DOS WITH (READUNCOMMITTED)
                                  INNER JOIN dbo.BFSDossierPerson DOP WITH (READUNCOMMITTED) ON DOP.BFSDossierID = DOS.BFSDossierID
                                  INNER JOIN dbo.BFSFrage FRG WITH (READUNCOMMITTED) ON FRG.BFSPersonCode = DOP.BFSPersonCode 
                                                                                    AND FRG.PersonIndex = ISNULL(DOP.PersonIndex, 0)
                                                                                    AND FRG.BFSKatalogVersionID = DOS.BFSKatalogVersionID
                                WHERE DOS.BFSDossierID = {1} 
                                  AND FRG.Variable = {2}

                                IF EXISTS(SELECT TOP 1 1
                                          FROM dbo.BFSWert WITH (READUNCOMMITTED)
                                          WHERE BFSDossierID = {1} AND
                                                BFSFrageID = @BFSFrageID)
                                BEGIN
                                  -- update existing entry
                                  UPDATE dbo.BFSWert
                                    SET PlausiFehler = {0}
                                  WHERE BFSDossierID = {1} AND
                                        BFSFrageID = @BFSFrageID
                                END
                                ELSE IF (@BFSFrageID IS NOT NULL)
                                BEGIN
                                  -- insert new entry
                                  INSERT INTO dbo.BFSWert (BFSDossierID, BFSDossierPersonID, BFSFrageID, PlausiFehler)
                                    VALUES ({1}, @BFSDossierPersonID, @BFSFrageID, {0})
                                END", row["Text"], bfsDossierID, varName.Trim());
                        }
                    }
                }

                // logging
                logger.Debug("do commit");

                // commit changes
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();

                // logging
                logger.Debug(String.Format("do rollback: ex.Message='{0}'", ex.Message));

                // show info to user
                DlgProgressLog.AddLine(KissMsg.GetMLMessage("Plausi", "FehlerSpeichernPlausifehler", "- Fehler beim Speichern der Plausifehler"));
            }

            // logging
            logger.Debug("done");
        }


        private void StartExport()
        {
            ExportSuccess = false;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // 1. Schritt: XML der Dossiers erstellen und in der KiSS-DB (Tabelle BFSDossier) ablegen
                DlgProgressLog.AddLine(KissMsg.GetMLMessage(
                    "Plausi", 
                    "InitialisierungExport", 
                    "Der Export von {0} Fällen wird initialisiert", 
                    KissMsgCode.Text, 
                    _arrayBfsDossierID.Length
                ));

                // Erstelle Plausex
                CreatePlausEx();

                if (_enableVorbereiten)
                {
                    XmlDocument xmlDoc = null;
                    XmlDocument xmlDocExportDefinition = new XmlDocument();

                    // XML Export Definition laden
                    string dossierXML = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                            SELECT VER.DossierXML
                            FROM dbo.BfsDossier                 DOS WITH (READUNCOMMITTED)
                              INNER JOIN dbo.BfsKatalogVersion  VER WITH (READUNCOMMITTED) ON VER.BfsKatalogVersionID = DOS.BfsKatalogVersionID
                                WHERE DOS.BfsDossierID = {0}", _arrayBfsDossierID[0]));

                    xmlDocExportDefinition.LoadXml(dossierXML == null ? string.Empty : dossierXML);

                    for (Int32 i = 0; i < _arrayBfsDossierID.Length; i++)
                    {
                        // logging
                        logger.Debug(String.Format("---- prepare export for BfsDossierID='{0}'", _arrayBfsDossierID[i].ToString()));

                        // add line to dialog
                        DlgProgressLog.AddLine(KissMsg.GetMLMessage("Plausi", "VorbereitungFall", "Fall {0}: Vorbereitung", KissMsgCode.Text, i + 1));

                        //Neue Kopie der XML Export Definition erzeugen
                        xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xmlDocExportDefinition.OuterXml);

                        // Werte einfüllen aus BfsWert
                        this.FillBfsValues(xmlDoc, _arrayBfsDossierID[i]);

                        // Überzählige UE und HH Personen entfernen
                        DeleteEmptyPersons(xmlDoc);

                        // XML in der KiSS-DB Tabelle BFSDossier ablegen
                        this.UpdateDossier(_arrayBfsDossierID[i], xmlDoc);
                    }
                }

                // 2. Schritt: Plausibilisierung und Export
                DateTime startTime;
                TimeSpan duration;
                string xmlFehlerliste;
                string userText;

                // Lösche alle Daten aus der SoStat-DB
                DeleteAll();

                _anzahlStichtage = 0;
                _anzahlAnfangszustaende = 0;

                for (Int32 i = 0; i < _arrayBfsDossierID.Length; i++)
                {
                    startTime = DateTime.Now;

                    // logging
                    logger.Debug(String.Format("---- do export for BfsDossierID='{0}'", _arrayBfsDossierID[i].ToString()));

                    if (_enablePlausiDuringExport)
                    {
                        // add line to dialog
                        userText = KissMsg.GetMLMessage("Plausi", "PlausiUndExportFall", "Fall {0}: Plausibilisieren und Exportieren...", KissMsgCode.Text, i + 1);
                    }
                    else
                    {
                        // add line to dialog
                        userText = KissMsg.GetMLMessage("Plausi", "ExportFall", "Fall {0}: Exportieren...", KissMsgCode.Text, i + 1);
                    }

                    // add line to dialog
                    DlgProgressLog.AddLine(userText);

                    // reset vars
                    _plausiFehler = String.Empty;

                    SqlQuery sqlXML = DBUtil.OpenSQL(@"
                        SELECT XML FROM dbo.BFSDossier WITH (READUNCOMMITTED)
                        WHERE BFSDossierID = {0}",
                        _arrayBfsDossierID[i]
                    );
                    string xmlString = Utils.ConvertToString(sqlXML["XML"]);

                    if (!string.IsNullOrEmpty(xmlString))
                    {
                        xmlFehlerliste = _plausEx.TestDossierEx(xmlString, true, _enablePlausiDuringExport);

                        SavePlausiFehler(xmlFehlerliste, _arrayBfsDossierID[i]);

                        // calc time
                        duration = DateTime.Now - startTime;

                        userText += String.Format(" ({0:n0}s)", duration.TotalSeconds);
                        DlgProgressLog.UpdateLastLine(userText);
                    }
                    else
                    {
                        _plausiFehler = KissMsg.GetMLMessage("Plausi", "PlausiErrorNoXML", "Das Dossier {0} ist nicht vorbereiten und kann daher nicht exportiert werden!", KissMsgCode.Text, _arrayBfsDossierID[i]);
                        userText += _plausiFehler;
                        DlgProgressLog.UpdateLastLine(userText);
                    }

                    // add plausifehler (if any defined)
                    if (!String.IsNullOrEmpty(_plausiFehler))
                    {
                        // add row
                        DlgProgressLog.AddError(KissMsg.GetMLMessage("Plausi", "PlausiErrorGotten_v01", "PlausEx-Fehler: {0}", KissMsgCode.Text, _plausiFehler));
                    }
                }

                DlgProgressLog.AddLine(KissMsg.GetMLMessage("Plausi", "ErzeugeExportdatei", "Exportdatei erzeugen (dies kann einige Minuten dauern)..."));

                //alle Dateien im Export-Verzeichnis löschen
                try
                {
                    foreach (FileInfo fileInfo in new DirectoryInfo(this.ExportDir).GetFiles())
                    {
                        fileInfo.Delete();
                    }
                }
                catch (Exception ex)
                {
                    // logging
                    logger.Warn(String.Format("Could not delete files from ExportDir. ExportDir='{0}', Message='{1}'.", this.ExportDir, ex.Message));

                    // add to dialog
                    DlgProgressLog.AddLine(KissMsg.GetMLMessage("Plausi", "ErrorDeleteExportDir", "Fehler beim Löschen der Daten aus ExportDir ('{0}'): {1}", KissMsgCode.Text, this.ExportDir, ex.Message));
                }

                int jahr = _erhebungsJahr;

                SqlQuery sqlAnzahl = DBUtil.OpenSQL(@"
                    SELECT 
                      anzahlStichtage = (
                        SELECT COUNT(*) FROM dbo.BfsDossier
                        WHERE Jahr = {0} AND Stichtag = 1),
                      anzahlAnfang = (
                        SELECT COUNT(*) FROM dbo.BfsDossier
                        WHERE Jahr = {0} AND Stichtag = 0)",
                    _erhebungsJahr
                );

                _anzahlStichtage = Utils.ConvertToInt(sqlAnzahl["anzahlStichtage"]);
                _anzahlAnfangszustaende = Utils.ConvertToInt(sqlAnzahl["anzahlAnfang"]);

                Interop.SoStat.FinishResult ret = _plausEx.FinishEx2(
                    ref jahr, 
                    ref _anzahlAnfangszustaende, 
                    ref _anzahlStichtage
                );

                if (ret.lState != Interop.SoStat.eState.eDone)
                {
                    logger.Debug(String.Format("Fehler beim Erzeugen der Exportdatei: {0}", ret.sFehlerMeldung));

                    DlgProgressLog.AddError(KissMsg.GetMLMessage("Plausi", "FehlerBeiErzeugen", "- Fehler beim Erzeugen der Exportdatei: {0}", KissMsgCode.Text, ret.sFehlerMeldung));
                }

                DlgProgressLog.AddError(KissMsg.GetMLMessage("Plausi", "AnzahlFaelleInDatei", "- exportierte Fälle in der Exportdatei: {0}", KissMsgCode.Text, ret.lNumberOfDossiers.ToString()));

                //export resultat auf Disk schreiben
                try
                {
                    StreamWriter sw = File.CreateText(String.Format("{0}{1}", this.ExportDir, "ExportResult.xml"));
                    sw.Write(ret.sMeldung);
                    sw.Flush();
                    sw.Close();
                }
                catch (Exception ex)
                {
                    // logging
                    logger.Debug(String.Format("Error writing ExportResult.xml to disc: {0}", ex.Message));

                    // add to dialog
                    DlgProgressLog.AddError(KissMsg.GetMLMessage("Plausi", "ErrorWritingExportResult", "Fehler beim Schreiben der ExportResult.xml-Datei: {0}", KissMsgCode.Text, ex.Message));
                }

                // logging
                logger.Debug("export finished");

                // set flag, export done
                this.ExportSuccess = true;

                // add info to dialog
                DlgProgressLog.AddLine(KissMsg.GetMLMessage("Plausi", "ExportAbgeschlossen", "Export abgeschlossen"));
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
            catch (KissCancelException ex)
            {
                // logging
                logger.Debug(String.Format("KissCancelException in export: {0}", ex.Message));

                // show info
                ex.ShowMessage();
            }
            catch (CancelledByUserException cbuex)
            {
                // logging
                logger.Debug(String.Format("CancelledByUserException in export: {0}", cbuex.Message));

                try
                {
                    DlgProgressLog.AddLine(KissMsg.GetMLMessage("Plausi", "ExportAbgebrochen", "Export abgebrochen durch Benutzer/-in"));
                }
                catch { };
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();

                // export failed
                ExportSuccess = false;
            }
            finally
            {
                DisposePlausEx();
                Cursor.Current = Cursors.Default;
            }
        }

        private void UpdateDossier(int bfsDossierID, XmlDocument xmlDoc)
        {
            string xmlString = null;
            if (xmlDoc != null)
            {
                xmlString = xmlDoc.InnerXml;
            }

            try
            {
                DBUtil.ExecuteScalarSQLThrowingException(@"
                UPDATE BFSDossier
                        SET PlausibilisierungDatum = CASE WHEN 1 = {0} THEN GETDATE()
                                                          ELSE PlausibilisierungDatum
                                                     END,
                        ExportDatum                = CASE WHEN 1 = {1} THEN GETDATE()
                                                          ELSE ExportDatum
                                                     END,
                        XML                        = CASE WHEN 1 = {2} THEN {3}
                                                          ELSE XML
                                                     END
                        WHERE BFSDossierID = {4}", _enablePlausiDuringExport, true, true, xmlString, bfsDossierID);
            }
            catch (Exception ex)
            {
                // logging
                logger.Debug(String.Format("error UpdateDossiers: Message='{0}'", ex.Message));
            }

        }

        #endregion

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            DisposePlausEx();
        }

        #endregion
    }
}