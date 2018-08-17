using System;
using System.Data;
using System.Net.Mail;
using System.Text;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    #region Enumerations

    public enum BgBewilligungStatus
    {
        InVorbereitung = 1,
        Abgelehnt = 2,
        Angefragt = 3,

        Erteilt = 5,

        Gesperrt = 9
    }

    public enum BgSpezkontoTyp
    {
        Ausgabekonto = 1,
        Vorabzugkonto = 2,
        Abzahlungskonto = 3,
        Kuerzungen = 4
    }

    public enum KbBuchungsStatus
    {
        Vorbereitet = 1,
        Freigegeben = 2,
        ZahlauftragErstellt = 3,
        BarbelegAusgedruckt = 4,
        ZahlauftragFehlerhaft = 5,
        Ausgeglichen = 6,
        Gesperrt = 7,
        Storniert = 8,
        Rückläufer = 9,
        TeilweiseAusgeglichen = 10,
        Barbezug = 11,
        Angefragt = 12,
        Verbucht = 13,
        Bewilligt = 14,
        Abgelehnt = 15
    }

    #endregion

    /// <summary>
    /// Summary description for ShUtil.
    /// </summary>
    public class ShUtil
    {
        #region Fields

        #region Private Static Fields

        private static SqlQuery qryRichtlinie = DBUtil.OpenSQL(@"
            SELECT HG_MIN = $0.00, HG_MAX = NULL, HG_DEF = NULL,
                   UE_MIN = $0.00, UE_MAX = NULL, UE_DEF = NULL,
                   PR_MIN = $0.00, PR_MAX = NULL, PR_DEF = NULL
            WHERE 1=0;");

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "ShUtil";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShUtil"/> class. Private only!
        /// </summary>
        private ShUtil()
        {
        }

        #endregion

        #region EventHandlers

        internal static void ApplyShStatusCodeToSqlQuery_SFP(SqlQuery qry, int bgFinanzplanID)
        {
            object BgBewilligungStatusCode = DBUtil.ExecuteScalarSQL(@"
                SELECT SFP.BgBewilligungStatusCode
                FROM BgFinanzplan  SFP
                WHERE SFP.BgFinanzplanID = {0};", bgFinanzplanID);

            if (BgBewilligungStatusCode == null)
            {
                return;
            }

            if ((int)BgBewilligungStatusCode >= (int)BgBewilligungStatus.Erteilt)
            {
                SqlQueryEditOff(qry);
            }
        }

        internal static void CreateTaskForDoubleSupport_NeueSozialhilfe(int senderUserId, string personIdCsv)
        {
            string betreff = "Sozialhilfe eröffnet bei Gläubiger mit Alimentenbevorschussung";
            CreateTaskForDoubleSupport(betreff, senderUserId, personIdCsv);
        }

        internal static void CreateTaskForDoubleSupport_SozialhilfeAbgeschlossen(int senderId, string personIdCsv)
        {
            string betreff = "Sozialhilfe geschlossen bei Gläubiger im Alimenteninkasso";
            CreateTaskForDoubleSupport(betreff, senderId, personIdCsv);
        }

        internal static void CreateTaskForDoubleSupport_SozialhilfeReaktiviert(int senderId, string personIdCsv)
        {
            string betreff = "Sozialhilfe reaktiviert bei Gläubiger mit Alimentenbevorschussung";
            CreateTaskForDoubleSupport(betreff, senderId, personIdCsv);
        }

        internal static SqlQuery GetBgBewilligung_Neu()
        {
            SqlQuery qryBgBewilligung = DBUtil.OpenSQL(@"
                SELECT *
                FROM BgBewilligung
                WHERE 1 = 0");

            qryBgBewilligung.Insert("BgBewilligung");
            qryBgBewilligung["UserID"] = Session.User.UserID;

            return qryBgBewilligung;
        }

        internal static int GetBgFinanzplanID_of_BgBudgetID(int bgBudgetID)
        {
            return Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT BgFinanzplanID
                FROM dbo.BgBudget
                WHERE BgBudgetID = {0};", bgBudgetID));
        }

        internal static int GetFaLeistungID_of_BgBudgetID(int bgBudgetID)
        {
            return Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT SFP.FaLeistungID
                FROM dbo.BgFinanzplan     SFP
                  INNER JOIN dbo.BgBudget BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
                WHERE BBG.BgBudgetID = {0}", bgBudgetID));
        }

        internal static SqlQuery GetPersonen_Unterstuetzt(int bgBudgetID)
        {
            return DBUtil.OpenSQL(@"
                SELECT PRS.BaPersonID, PRS.NameVorname, PRS.Name, PRS.Vorname, LT = CASE WHEN LST.BaPersonID = PRS.BaPersonID THEN 0 ELSE 1 END
                FROM BgBudget                       BBG
                  INNER JOIN BgFinanzplan           SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN FaLeistung             LST ON LST.FaLeistungID   = SFP.FaLeistungID
                  INNER JOIN BgFinanzplan_BaPerson  SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN vwPerson               PRS ON PRS.BaPersonID     = SPP.BaPersonID
                WHERE BBG.BgBudgetID = {0} AND SPP.IstUnterstuetzt = 1
                UNION ALL SELECT NULL, '', '', '', 0
                ORDER BY LT, PRS.Name, PRS.Vorname;", bgBudgetID);
        }

        internal static SqlQuery GetSqlQueryKostenart_Einzelzahlung()
        {
            return DBUtil.OpenSQL(@"
                SELECT BgKostenartID, Name AS Text
                FROM BgKostenart  BKA
                WHERE EXISTS (SELECT TOP 1 1
                              FROM WhPositionsart
                              WHERE BgKostenartID = BKA.BgKostenartID
                                AND BgKategorieCode IN (2, 100));");
        }

        private static void qryGetSpezKonto_AfterFill(object sender, EventArgs e)
        {
            SqlQuery qry = (SqlQuery)sender;

            foreach (DataRow row in qry.DataTable.Rows)
            {
                row["DisplayText"] = string.Format((string)row["DisplayText"], row["Saldo"]);

                row.AcceptChanges();
                qry.RowModified = false;
            }
        }

        #endregion

        #region Methods

        #region Internal Static Methods

        internal static void ApplyActionSil(DlgBewilligung dlg, SqlQuery qryBgPosition, int bgFinanzplanID)
        {
            Session.BeginTransaction();
            try
            {
                if (dlg != null && !dlg.ActiveSQLQuery.Post())
                {
                    throw new KissCancelException();
                }

                switch (dlg.Aktion)
                {
                    case BewilligungAktion.Anfragen:
                    case BewilligungAktion.Zurueckweisen:
                    case BewilligungAktion.Weiterempfehlen:
                        //Statusupdate auf BgPosition inkl Detailpositionen
                        ShUtil.SetBewilligungStatusFromPosition(
                            (int)qryBgPosition[DBO.BgPosition.BgPositionID],
                            DlgBewilligung.GetNextBewilligungStatus(dlg.Aktion) as BgBewilligungStatus?,
                            true);
                        break;

                    case BewilligungAktion.Bewilligen:
                        DBUtil.ExecSQL(600, "EXECUTE spWhFinanzplan_Bewilligen {0}, {1}, {2}"
                            , bgFinanzplanID
                            , qryBgPosition[DBO.BgPosition.DatumVon]
                            , qryBgPosition[DBO.BgPosition.BgPositionID]);
                        break;
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                // rollback changes
                Session.Rollback();

                // show error message
                KissMsg.ShowError("ShUtil", "ErrorPositionBewilligen", "Es ist ein Fehler beim Bewilligen der Position(en) aufgetreten.", ex);

                // refresh
                qryBgPosition.Refresh();
            }

            qryBgPosition.Refresh();
        }

        internal static void ApplyShStatusCodeToSqlQuery(SqlQuery qry, int bgBudgetID)
        {
            object BgBewilligungStatusCode = DBUtil.ExecuteScalarSQL(@"
                SELECT SFP.BgBewilligungStatusCode
                FROM BgBudget              BBG
                  INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                WHERE BBG.BgBudgetID = {0}", bgBudgetID);

            if (BgBewilligungStatusCode == null)
            {
                return;
            }

            if ((int)BgBewilligungStatusCode >= (int)BgBewilligungStatus.Erteilt)
            {
                SqlQueryEditOff(qry);
            }
        }

        /// <summary>
        /// Creates a new Finanzplan of the given type and refreshes the modultree.
        /// </summary>
        /// <param name="faLeistungID">The leistung to create the Finanzplan for.</param>
        /// <param name="whHilfeTypCode">The type of Finanzplan to create.</param>
        internal static void BgFinanzplanNeu(int faLeistungID, KiSS.DBScheme.LOV.WhHilfeTypCode whHilfeTypCode)
        {
            //{1} - WhHilfeTypCode: 2 = Finanzplan
            SqlQuery qry =
                DBUtil.OpenSQL(
                    @"
                SELECT
                  GeplantVon       = DateAdd(d, 1, dbo.fnLastDayOf(IsNull(SFP.DatumBis, SFP.GeplantBis))),
                  DefaultMonths    = CASE WHEN Month(SFP.GeplantBis) - Month(SFP.DatumBis) = 0 OR {1} = 2 THEN CONVERT(int, XLC.Value1) ELSE DateDiff(month, SFP.DatumBis, SFP.GeplantBis) END,
                  BgPositionsartID = (SELECT TOP 1 Code FROM XLOVCode  XLC
                                      WHERE LOVName = 'WhGrundbedarfTyp'
                                        AND NOT EXISTS (SELECT * FROM XLOVCode WHERE LOVName = XLC.LOVName AND SortKey < XLC.SortKey))
                FROM BgFinanzplan      SFP
                  LEFT  JOIN XLOVCode  XLC ON XLC.LOVName = 'WhHilfeTyp' AND XLC.Code = {1}
                WHERE SFP.FaLeistungID = {0}
                  AND NOT EXISTS (SELECT * FROM BgFinanzplan
                                  WHERE FaLeistungID = {0} AND IsNull(DatumBis, GeplantBis) > IsNull(SFP.DatumBis, SFP.GeplantBis))

                UNION ALL

                SELECT
                  GeplantVon       = dbo.fnFirstDayOf(FAL.DatumVon),
                  DefaultMonths    = CONVERT(int, XLC.Value1),
                  BgPositionsartID = (SELECT TOP 1 Code FROM XLOVCode  XLC
                                      WHERE LOVName = 'WhGrundbedarfTyp'
                                        AND NOT EXISTS (SELECT * FROM XLOVCode WHERE LOVName = XLC.LOVName AND SortKey < XLC.SortKey))
                FROM FaLeistung        FAL
                  LEFT  JOIN XLOVCode  XLC ON XLC.LOVName = 'WhHilfeTyp' AND XLC.Code = {1}
                WHERE FAL.FaLeistungID = {0}"
                    , faLeistungID, (int)whHilfeTypCode);

            DBUtil.ExecSQL("EXECUTE spWhFinanzPlan_Create {0}, {1}, {2}, {3}"
                           , faLeistungID
                           , qry["GeplantVon"]
                           , ((DateTime)qry["GeplantVon"]).AddMonths((int)qry["DefaultMonths"]).AddDays(-1)
                           , (int)whHilfeTypCode);
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        internal static void CreateTaskForDoubleSupport(string betreff, int senderUserId, string personIdCsv)
        {
            try
            {
                string sql = string.Format(@"
                    INSERT INTO dbo.XTask (TaskTypeCode, TaskStatusCode, CreateDate, ExpirationDate, [Subject], SenderID, TaskSenderCode,
                                            ReceiverID, TaskReceiverCode, FaLeistungID, BaPersonID, JumpToPath)
                    SELECT 1, 1, GETDATE(), GETDATE(), '{0}', {1}, 1,
                        LEI.UserID, 1, LEI.FaLeistungID, GLB.BaPersonID,
                        'BaPersonID='+CONVERT(varchar(20),LEI.BaPersonID)+';ModulID=4;'
                        +'TreeNodeID=CtlIkLeistung'+CONVERT(varchar(20),LEI.FaLeistungID)+'\Glaeubiger'+CONVERT(varchar(20),GLB.IkGlaeubigerID)
                        +';FaLeistungID='+CONVERT(varchar(20),LEI.FaLeistungID)+';FaFallID='+CONVERT(varchar(20),LEI.BaPersonID)+';ClassName=FrmFall'
                    FROM IkGlaeubiger GLB
                      INNER JOIN IkRechtstitel RTL ON RTL.IkRechtstitelID = GLB.IkRechtstitelID
                      INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = RTL.FaLeistungID
                      LEFT JOIN  vwPerson PRS ON PRS.BaPersonID = GLB.BaPersonID
                    WHERE GLB.Aktiv = 1 -- Gläubiger Aktiv
                      AND LEI.FaProzessCode = 401 -- Aliment
                      AND LEI.DatumVon < GETDATE() AND (LEI.DatumBis IS NULL OR GETDATE() BETWEEN LEI.DatumVon AND LEI.DatumBis)
                      AND GLB.BaPersonID IN ({2})", betreff, senderUserId, personIdCsv);

                DBUtil.ExecSQLThrowingException(sql);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("Eine Pendenz hätte erstellt werden sollen, aber es ist ein Fehler aufgetreten.", ex);
            }
        }

        internal static int GetBgPositionsartID(LOV.BgPositionsArt BgPositionsartCode, DateTime stichTag)
        {
            return GetBgPositionsartID((int)BgPositionsartCode, stichTag);
        }

        internal static int GetBgPositionsartID(int BgPositionsartCode, DateTime stichTag)
        {
            return GetBgPositionsartID(BgPositionsartCode, stichTag, true).Value;
        }

        internal static int? GetBgPositionsartID(int BgPositionsartCode, DateTime stichTag, bool throwException)
        {
            DateTime ersterDesMonats = stichTag.AddDays(1 - stichTag.Day);
            DateTime letzterDesMonats = ersterDesMonats.AddMonths(1).AddDays(-1);

            object result = DBUtil.ExecuteScalarSQL(@"
                SELECT TOP 1 POA.BgPositionsartID
                FROM BgPositionsart POA
                WHERE POA.BgPositionsartCode = {0}
                  AND ISNULL(POA.DatumVon, '1900-01-01') <= {2} AND ISNULL(POA.DatumBis, '2999-12-31') >= {1}",
                BgPositionsartCode, ersterDesMonats.ToString("yyyy-MM-dd"), letzterDesMonats.ToString("yyyy-MM-dd"));

            if (result is int)
            {
                return (int)result;
            }

            if (!throwException)
                return null;

            throw new KissCancelException(string.Format("Es gibt keine BgPositionsart mit BgPositionsartCode: {0}, die am {1} aktiv ist.", BgPositionsartCode, stichTag));
        }

        /// <summary>
        /// Get integer value from code object
        /// </summary>
        /// <param name="code">The code to parse as integer</param>
        /// <returns>Integer value of code or 0 if code could not be parsed</returns>
        internal static int GetCode(object code)
        {
            int? result = code as int?;
            if (!result.HasValue)
            {
                result = 0;
            }
            return result.Value;
        }

        /// <summary>
        /// Get new BelegNr for payments. This call should always be done within an open transaction.
        /// </summary>
        /// <param name="bgBudgetID">The id of the budget used for selecting the KbPeriodeID</param>
        /// <param name="bgPositionID">The id of the position used for validation</param>
        /// <param name="kbBelegkreisId">The id of the kbBelegKreis as out param </param>
        /// <returns>A valid BelegNr for the given <paramref name="bgPositionID"/></returns>
        /// <exception cref="KissCancelException">Thrown in case of validation error</exception>
        internal static int GetNewBelegNr(int bgBudgetID, int bgPositionID, out int? kbBelegkreisId)
        {
            // init vars
            object newBelegNrObj = null;
            int newBelegNr = -1;

            // get current KbPeriodeID for given budget
            int kbPeriodeID = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT ISNULL(dbo.fnKbGetPeriodeID(1, {0}, NULL, NULL, 1), -1);", bgBudgetID));

            // validate current BgPositionID
            if (bgPositionID < 1)
            {
                // invalid BgPositionID
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME, "CouldNotGetValidBgPositionID", "Die aktuelle BgPositionID ist ungültig."));
            }

            // validate current BgBudgetID
            if (bgBudgetID < 1)
            {
                // invalid BgBudgetID
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME, "CouldNotGetValidBgBudgetID", "Die aktuelle BgBudgetID ist ungültig."));
            }

            // validate PeriodeID
            if (kbPeriodeID < 0)
            {
                // invalid KbPeriodeID
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "CouldNotGetPeriodeIDForBudget",
                                                                   "Es konnte keine gültige KbPeriodeID anhand des gewählten Budgets gefunden werden."));
            }

            // get unique record number
            newBelegNrObj = DBUtil.ExecuteScalarSQLThrowingException(@"
                EXEC dbo.spKbGetBelegNr {0}, 4, NULL, 0;", kbPeriodeID);

            // validate content of new BelegNr
            if (newBelegNrObj == null || !(newBelegNrObj is int) || Convert.ToInt32(newBelegNrObj) < 1)
            {
                // invalid new record number (empty/not int/out of scope)
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "InvalidNewRecordNumberValue",
                                                                   "Die automatisch generierte BelegNr. hat einen ungültigen Wert."));
            }

            // set number
            newBelegNr = Convert.ToInt32(newBelegNrObj);

            // validate new record number for security purpose
            if (!ValidateBelegNr(kbPeriodeID, newBelegNr, bgPositionID))
            {
                // invalid new record number (duplicate)
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "InvalidNewRecordNumberUnique",
                                                                   "Die automatisch generierte BelegNr. ('{0}') existiert bereits und kann nicht nochmals verwendet werden.", newBelegNr));
            }

            // get the id of KbBelegKreis
            kbBelegkreisId = KliBuUtil.GetKbBelegKreisId(kbPeriodeID, 4);

            // if we are here, the new BelegNr is valid
            return newBelegNr;
        }

        internal static SqlQuery GetPersonen(int bgBudgetID)
        {
            return DBUtil.OpenSQL(@"
                SELECT PRS.BaPersonID, PRS.NameVorname
                FROM BgBudget                       BBG
                  INNER JOIN BgFinanzplan           SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN FaLeistung             LST ON LST.FaLeistungID   = SFP.FaLeistungID
                  INNER JOIN BgFinanzplan_BaPerson  SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN vwPerson               PRS ON PRS.BaPersonID     = SPP.BaPersonID
                WHERE BBG.BgBudgetID = {0}
                ORDER BY CASE WHEN LST.BaPersonID = SPP.BaPersonID THEN 0 ELSE 1 END, PRS.Name, PRS.Vorname"
                , bgBudgetID);
        }

        internal static SqlQuery GetRichtlinie(int bgPositionsartID, int bgBudgetID)
        {
            return GetRichtlinie(DBUtil.ExecuteScalarSQL("SELECT sqlRichtlinie FROM BgPositionsart WHERE BgPositionsartID = {0}", bgPositionsartID), bgBudgetID);
        }

        internal static SqlQuery GetRichtlinie(object sqlRichtlinie, int bgBudgetID)
        {
            if (DBUtil.IsEmpty(sqlRichtlinie))
            {
                return qryRichtlinie;
            }

            try
            {
                SqlQuery qry = DBUtil.OpenSQL(string.Format(@"
                    DECLARE @RefDate         DATETIME,
                            @BgBudgetID      INT,
                            @BgFinanzplanID  INT

                    SELECT @RefDate        = IsNull(SFP.DatumVon, SFP.GeplantVon),
                           @BgBudgetID     = {0},
                           @BgFinanzplanID = BBG.BgFinanzplanID
                    FROM BgBudget    BBG
                      INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                    WHERE BBG.BgBudgetID = {0}

                    {1}", "{0}", sqlRichtlinie), bgBudgetID);

                if (qry.Count == 1)
                {
                    foreach (DataColumn col in qry.DataTable.Columns)
                    {
                        if (!DBUtil.IsEmpty(qry[col.ColumnName]))
                        {
                            return qry;
                        }
                    }
                }
            }
            catch { }

            return qryRichtlinie;
        }

        internal static SqlQuery GetSpezKonto(int bgBudgetID, BgSpezkontoTyp bgSpezkontoTypCode)
        {
            return GetSpezKonto(bgBudgetID, DBNull.Value, bgSpezkontoTypCode, DBNull.Value);
        }

        internal static SqlQuery GetSpezKonto(int bgBudgetID, BgSpezkontoTyp bgSpezkontoTypCode, string AddWhere)
        {
            return GetSpezKonto(bgBudgetID, DBNull.Value, bgSpezkontoTypCode, DBNull.Value, AddWhere);
        }

        internal static SqlQuery GetSpezKonto(int bgBudgetID, BgSpezkontoTyp bgSpezkontoTypCode, object BgKostenartID)
        {
            return GetSpezKonto(bgBudgetID, DBNull.Value, bgSpezkontoTypCode, BgKostenartID);
        }

        internal static SqlQuery GetSpezKonto(int bgBudgetID, object bgPositionID, BgSpezkontoTyp bgSpezkontoTypCode)
        {
            return GetSpezKonto(bgBudgetID, bgPositionID, bgSpezkontoTypCode, DBNull.Value);
        }

        internal static SqlQuery GetSpezKonto(int bgBudgetID, object bgPositionID, BgSpezkontoTyp bgSpezkontoTypCode, object bgKostenartID)
        {
            return GetSpezKonto(bgBudgetID, bgPositionID, bgSpezkontoTypCode, bgKostenartID, "AND ( {2} < 3 OR OhneEinzelzahlung = 0 OR EXISTS (SELECT * FROM BgPosition WHERE BgPositionID = {1} AND BgKategorieCode = 101 AND BgSpezkontoID = SSK.BgSpezkontoID) )");
        }

        internal static SqlQuery GetSpezKonto(int bgBudgetID, object bgPositionID, BgSpezkontoTyp bgSpezkontoTypCode, object bgKostenartID, string AddWhere)
        {
            SqlQuery qry = new SqlQuery();
            qry.AfterFill += new EventHandler(qryGetSpezKonto_AfterFill);

            qry.Fill(@"
                SELECT SSK.BgSpezkontoID, SSK.NameSpezkonto,
                  DisplayText = SSK.NameSpezkonto + ' ({0:N2})',
                  Saldo       = dbo.fnBgSpezkonto(SSK.BgSpezkontoID, 4, {0}, {1}),
                  SSK.BgKostenartID, SSK.BaPersonID, SSK.BaInstitutionID,
                  BKA.BgSplittingartCode
                FROM BgBudget              BBG
                  INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN BgSpezkonto   SSK ON SSK.FaLeistungID = SFP.FaLeistungID
                  LEFT  JOIN BgKostenart   BKA ON BKA.BgKostenartID = SSK.BgKostenartID
                WHERE BBG.BgBudgetID = {0} AND SSK.BgSpezkontoTypCode = {2}
                  " + AddWhere + @"
                  AND ( SSK.DatumVon IS NULL OR dbo.fnDateOf(CASE WHEN BgSpezkontoTypCode = 3 THEN DateAdd(m, -3, SSK.DatumVon) ELSE SSK.DatumVon END) <= CASE WHEN BBG.MasterBudget = 1 THEN dbo.fnDateOf(SFP.DatumBis) ELSE dbo.fnLastDayOf(dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)) END )
                  AND ( SSK.DatumBis IS NULL OR dbo.fnDateOf(SSK.DatumBis) >= CASE WHEN BBG.MasterBudget = 1 THEN dbo.fnDateOf(SFP.DatumVon) ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)  END )
                  AND ({3} IS NULL OR SSK.BgKostenartID IS NULL OR SSK.BgKostenartID = {3})"
                , bgBudgetID, bgPositionID, (int)bgSpezkontoTypCode, bgKostenartID);

            return qry;
        }

        internal static object GetSpezKontoID(int bgBudgetID, int bgPositionsartID)
        {
            return DBUtil.ExecuteScalarSQL(@"
                SELECT SSK.BgSpezkontoID
                FROM BgBudget              BBG
                  INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN BgSpezkonto   SSK ON SSK.FaLeistungID = SFP.FaLeistungID
                WHERE BBG.BgBudgetID = {0} AND SSK.BgPositionsartID = {1}"
                , bgBudgetID, bgPositionsartID);
        }

        internal static SqlQuery GetSqlQueryKostenart()
        {
            return DBUtil.OpenSQL(@"
                SELECT BgKostenartID, Name AS Text
                FROM BgKostenart");
        }

        /// <summary>
        /// Sucht BgPositionsarten der übergegenen BgGruppe, BgKategorieCode &lt; 100,
        /// BgPositionsartCode NOT IN (32030, 32031, 32032, 32033, 32034).
        /// </summary>
        internal static SqlQuery GetSqlQueryShPositionTyp(LOV.BgGruppeCode bgGruppeCode, DateTime datumVon, DateTime datumBis, bool concatKontoNrName)
        {
            return DBUtil.OpenSQL(@"
                SELECT SPT.BgPositionsartID, SPT.Name,
                  Code = SPT.BgPositionsartID,
                  Text = CASE {3} WHEN 1 THEN SPT.KontoNrName ELSE SPT.Name END +
                                CASE
                                  WHEN SPT.DatumVon BETWEEN {1} AND {2} THEN ' (ab: ' + Convert(varchar, SPT.DatumVon, 104) + ')'
                                  WHEN SPT.DatumBis BETWEEN {1} AND {2} THEN ' (bis: ' + Convert(varchar, SPT.DatumBis, 104) + ')'
                                  ELSE ''
                                END,
                  SPT.HilfeText,
                  SPT.VerwaltungSD_Default
                FROM WhPositionsart     SPT
                WHERE SPT.BgGruppeCode = {0} AND BgKategorieCode < 100
                  AND ISNULL(SPT.DatumVon, '1900-01-01') <= {2} AND ISNULL(SPT.DatumBis, '2999-12-31') >= {1}
                  AND SPT.BgPositionsartCode NOT IN (32030, 32031, 32032, 32033, 32034) -- Erwerbsmehrkosten
                ORDER BY CASE {3}
                           WHEN 1 THEN SPT.KontoNrName
                           ELSE SPT.Name
                         END, SPT.SortKey"
                , bgGruppeCode, datumVon.ToString("yyyy-MM-dd"), datumBis.ToString("yyyy-MM-dd"), concatKontoNrName);
        }

        /// <summary>
        /// Gibt ein SqlQuery zurück, um ein PositionsartID-LookupField zu initialisieren.
        /// </summary>
        internal static SqlQuery GetSqlQueryShPositionTyp(LOV.BgGruppeCode bgGruppeCode, LOV.BgKategorieCode bgKategorieCode, DateTime datumVon, DateTime datumBis, bool concatKontoNrName)
        {
            return DBUtil.OpenSQL(@"
                SELECT
                    SPT.BgPositionsartID, SPT.Name,
                    Code = SPT.BgPositionsartID,
                    Text = CASE {4} WHEN 1 THEN SPT.KontoNrName ELSE SPT.Name END +
                                CASE
                                  WHEN SPT.DatumVon BETWEEN {2} AND {3} THEN ' (ab: ' + Convert(varchar, SPT.DatumVon, 104) + ')'
                                  WHEN SPT.DatumBis BETWEEN {2} AND {3} THEN ' (bis: ' + Convert(varchar, SPT.DatumBis, 104) + ')'
                                  ELSE ''
                                END
                FROM WhPositionsart SPT
                WHERE ISNULL(SPT.DatumVon, '1900-01-01') <= {3} AND ISNULL(SPT.DatumBis, '2999-12-31') >= {2}
                  AND SPT.BgKategorieCode = {1} AND SPT.BgGruppeCode = {0}
                ORDER BY CASE {4}
                           WHEN 1 THEN SPT.KontoNrName
                           ELSE SPT.Name
                         END, SPT.SortKey", bgGruppeCode, bgKategorieCode, datumVon.ToString("yyyy-MM-dd"), datumBis.ToString("yyyy-MM-dd"), concatKontoNrName);
        }

        /// <summary>
        /// Gibt ein SqlQuery zurück, um ein PositionsartID-LookupField zu initialisieren.
        /// Default-KategorieCode: Ausgaben.
        /// </summary>
        internal static SqlQuery GetSqlQueryShPositionTyp(LOV.BgGruppeCode bgGruppeCode, LOV.BgPositionsArt bgPositionsartMin, LOV.BgPositionsArt bgPositionsartMax, DateTime datumVon, DateTime datumBis, bool concatKontoNrName)
        {
            return GetSqlQueryShPositionTyp(bgGruppeCode, LOV.BgKategorieCode.Ausgaben, bgPositionsartMin, bgPositionsartMax, datumVon, datumBis, concatKontoNrName);
        }

        internal static SqlQuery GetSqlQueryShPositionTyp(int bgPositionsartMin, int bgPositionsartMax, DateTime datumVon, DateTime datumBis, bool concatKontoNrName)
        {
            return DBUtil.OpenSQL(@"
                SELECT
                    SPT.*,
                    Code = SPT.BgPositionsartID,
                    Text = CASE {4} WHEN 1 THEN SPT.KontoNrName ELSE SPT.Name END +
                                CASE
                                  WHEN SPT.DatumVon BETWEEN {2} AND {3} THEN ' (ab: ' + Convert(varchar, SPT.DatumVon, 104) + ')'
                                  WHEN SPT.DatumBis BETWEEN {2} AND {3} THEN ' (bis: ' + Convert(varchar, SPT.DatumBis, 104) + ')'
                                  ELSE ''
                                END
                FROM WhPositionsart SPT
                WHERE SPT.BgPositionsartCode BETWEEN {0} AND {1}
                  AND ISNULL(SPT.DatumVon, '1900-01-01') <= {3} AND ISNULL(SPT.DatumBis, '2999-12-31') >= {2}
                ORDER BY CASE {4}
                           WHEN 1 THEN SPT.KontoNrName
                           ELSE SPT.Name
                         END, SPT.SortKey", bgPositionsartMin, bgPositionsartMax, datumVon.ToString("yyyy-MM-dd"), datumBis.ToString("yyyy-MM-dd"), concatKontoNrName);
        }

        internal static SqlQuery GetSqlQueryShPositionTyp(LOV.BgGruppeCode bgGruppeCode, LOV.BgKategorieCode bgKategorieCode, LOV.BgPositionsArt bgPositionsartMin, LOV.BgPositionsArt bgPositionsartMax, DateTime datumVon, DateTime datumBis, bool concatKontoNrName)
        {
            return DBUtil.OpenSQL(@"
                SELECT
                    SPT.BgPositionsartID,
                    SPT.Name,
                    Code = BgPositionsartID,
                    Text = CASE {6} WHEN 1 THEN SPT.KontoNrName ELSE SPT.Name END +
                                CASE
                                  WHEN SPT.DatumVon BETWEEN {4} AND {5} THEN ' (ab: ' + Convert(varchar, SPT.DatumVon, 104) + ')'
                                  WHEN SPT.DatumBis BETWEEN {4} AND {5} THEN ' (bis: ' + Convert(varchar, SPT.DatumBis, 104) + ')'
                                  ELSE ''
                                END,
                    SPT.BgPositionsartCode
                FROM WhPositionsart SPT
                WHERE SPT.BgPositionsartCode BETWEEN {2} AND {3}
                  AND ISNULL(SPT.DatumVon, '1900-01-01') <= {5} AND ISNULL(SPT.DatumBis, '2999-12-31') >= {4}
                  AND SPT.BgKategorieCode = {1} AND SPT.BgGruppeCode = {0}
                ORDER BY CASE {6}
                           WHEN 1 THEN SPT.KontoNrName
                           ELSE SPT.Name
                         END, SPT.SortKey", bgGruppeCode, bgKategorieCode, bgPositionsartMin, bgPositionsartMax, datumVon.ToString("yyyy-MM-dd"), datumBis.ToString("yyyy-MM-dd"), concatKontoNrName);
        }

        /// <summary>
        /// ZH FAMOZ Only
        /// </summary>
        /// <returns></returns>
        internal static SqlQuery GetSqlQueryWhPositionTyp(int bgGruppeCode)
        {
            return DBUtil.OpenSQL(@"
                SELECT SPT.BgPositionsartID, SPT.Name,
                    Code = SPT.BgPositionsartID,
                  Text = BKA.KontoNr + ' ' + SPT.Name
                FROM WhPositionsart     SPT
                  INNER JOIN BgKostenart  BKA ON BKA.BgKostenartID = SPT.BgKostenartID
                WHERE SPT.BgGruppeCode = {0} AND BgKategorieCode < 100
                  AND SPT.BgPositionsartID NOT IN (32030, 32031, 32032, 32033, 32034) -- Erwerbsmehrkosten
                ORDER BY SPT.SortKey"
                , bgGruppeCode);
        }

        internal static bool HasPermissionSil(int bgPositionID)
        {
            return (bool)DBUtil.ExecuteScalarSQL("SELECT dbo.fnWhPosition_Permission({0}, {1})", bgPositionID, Session.User.UserID);
        }

        internal static decimal RoundMoney(decimal val)
        {
            return Math.Round(val * 2, 1) / 2;
        }

        /// <summary>
        /// Sendet eine Bewilligungsmail.
        /// </summary>
        /// <param name="typ">Was wird bewilligt? (FinanzPlan, Ueberbrueckungshilfe, Einzelzahlung, ZusaetzlicheLeistung)</param>
        /// <param name="aktion">Art der Bewilligungsanfrage (Bewilligen, Zurueckweisen, Anfragen, Aufheben, Sperren, SperrungAufheben)</param>
        /// <param name="emailAddress">Email-Adresse des Empfängers</param>
        /// <param name="receiverUserID">UserID des Empfängers</param>
        /// <param name="recordID">ID des Finanzplans/Ueberbrueckungshilfe/Einzelzahlung...</param>
        /// <param name="sperrungSofort">Wird nur benötigt wenn <paramref name="aktion"/>=<code>Sperren</code> ist: <c>true</c> wenn der Finanzplan/Ueberbrueckungshilfe per sofort beendet werden soll, sonst <c>false</c> oder <c>null</c>.</param>
        /// <param name="bemerkungen"></param>
        internal static void SendMail(BewilligungTyp typ, BewilligungAktion aktion, string emailAddress, int receiverUserID, int recordID, bool? sperrungSofort, string bemerkungen)
        {
            MailMessage msg = new MailMessage(Session.User.EMail, emailAddress);
            msg.BodyEncoding = Encoding.UTF8;
            msg.Subject = "";

            if (typ == BewilligungTyp.FinanzPlan || typ == BewilligungTyp.Ueberbrueckungshilfe)
            {
                switch (aktion)
                {
                    case BewilligungAktion.Bewilligen:
                        msg.Subject = string.Format(@"KiSS 4.0 - Finanzplan #{0}: Antwort zur Bewilligung", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthFpAnswPos", "") as string;
                        break;

                    case BewilligungAktion.Zurueckweisen:
                        msg.Subject = string.Format(@"KiSS 4.0 - Finanzplan #{0}: Antwort zur Bewilligung", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthFpAnswNeg", "") as string;
                        break;

                    case BewilligungAktion.Anfragen:
                    case BewilligungAktion.Weiterempfehlen:
                        msg.Subject = string.Format(@"KiSS 4.0 - Finanzplan #{0}: Anfrage zur Bewilligung", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthFpRequest", "") as string;
                        break;

                    case BewilligungAktion.Aufheben:
                        msg.Subject = string.Format(@"KiSS 4.0 - Finanzplan #{0}: Aufhebung der Bewilligung", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthFpRemove", "") as string;
                        break;

                    case BewilligungAktion.Sperren:
                        msg.Subject = string.Format(@"KiSS 4.0 - Finanzplan #{0}: Vorzeitige Beendigung des Finanzplanes", recordID);
                        if (sperrungSofort ?? false)
                            msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthFpTerminate", "") as string;
                        else
                            msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthFpRequest", "") as string; //sollte hier nicht etwas wie AuthFpLock stehen? (AuthFpRequest wird schon bei 'Anfrage zur Bewilligung' verwendet)
                        break;

                    case BewilligungAktion.SperrungAufheben:
                        msg.Subject = string.Format(@"KiSS 4.0 - Finanzplan #{0}: Entsperrung des Finanzplanes", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthFpUnlock", "") as string;
                        break;
                }

                msg.Body = msg.Body.Replace("{{FpKey}}", recordID.ToString());
                msg.Body = msg.Body.Replace("{{BgFinanzplanID}}", recordID.ToString());
            }
            else if (typ == BewilligungTyp.Einzelzahlung)
            {
                switch (aktion)
                {
                    case BewilligungAktion.Bewilligen:
                        msg.Subject = string.Format(@"KiSS 4.0 - Einzelzahlung #{0}: Antwort zur Bewilligung", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthEzAnswPos", "") as string;
                        break;

                    case BewilligungAktion.Zurueckweisen:
                        msg.Subject = string.Format(@"KiSS 4.0 - Einzelzahlung #{0}: Antwort zur Bewilligung", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthEzAnswNeg", "") as string;
                        break;

                    case BewilligungAktion.Anfragen:
                    case BewilligungAktion.Weiterempfehlen:
                        msg.Subject = string.Format(@"KiSS 4.0 - Einzelzahlung #{0}: Anfrage zur Bewilligung", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthEzRequest", "") as string;
                        break;

                    case BewilligungAktion.Aufheben:
                        msg.Subject = string.Format(@"KiSS 4.0 - Einzelzahlung #{0}: Aufhebung der Bewilligung", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthEzRemove", "") as string;
                        break;
                }

                msg.Body = msg.Body.Replace("{{EzKey}}", recordID.ToString());
                msg.Body = msg.Body.Replace("{{BgPositionID}}", recordID.ToString());
            }
            else if (typ == BewilligungTyp.SIL)
            {
                switch (aktion)
                {
                    case BewilligungAktion.Bewilligen:
                        msg.Subject = string.Format(@"KiSS 4.0 - SIL #{0}: Antwort zur Bewilligung", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthSILAnswPos", "") as string;
                        break;

                    case BewilligungAktion.Zurueckweisen:
                        msg.Subject = string.Format(@"KiSS 4.0 - SIL #{0}: Antwort zur Bewilligung", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthSILAnswNeg", "") as string;
                        break;

                    case BewilligungAktion.Anfragen:
                    case BewilligungAktion.Weiterempfehlen:
                        msg.Subject = string.Format(@"KiSS 4.0 - SIL #{0}: Anfrage zur Bewilligung", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthSILRequest", "") as string;
                        break;

                    case BewilligungAktion.Aufheben:
                        msg.Subject = string.Format(@"KiSS 4.0 - SIL #{0}: Aufhebung der Bewilligung", recordID);
                        msg.Body = DBUtil.GetConfigValue(@"System\Sozialhilfe\Mail\AuthSILRemove", "") as string;
                        break;
                }

                msg.Body = msg.Body.Replace("{{BgPositionID}}", recordID.ToString());
            }

            // sender
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT *,
                       Anrede    = CASE GenderCode
                                     WHEN 1 THEN 'Herr'
                                     ELSE 'Frau'
                                   END,
                       Abteilung = dbo.fnOrgUnitOfUser(UserID, 0)
                FROM dbo.XUser
                WHERE UserID = {0};", Session.User.UserID);

            msg.Body = msg.Body.Replace("{{SenderAccost}}", qry["Anrede"].ToString());
            msg.Body = msg.Body.Replace("{{SenderName}}", qry["LastName"].ToString());
            msg.Body = msg.Body.Replace("{{SenderFirstname}}", qry["FirstName"].ToString());
            msg.Body = msg.Body.Replace("{{SenderSite}}", qry["Abteilung"].ToString());
            msg.Body = msg.Body.Replace("{{SenderTel}}", qry["Phone"].ToString());
            msg.Body = msg.Body.Replace("{{SenderMail}}", qry["EMail"].ToString());

            //receiver
            qry.Fill(qry.SelectStatement, receiverUserID);

            msg.Body = msg.Body.Replace("{{ReceiverAccost}}", qry["Anrede"].ToString());
            msg.Body = msg.Body.Replace("{{ReceiverName}}", qry["LastName"].ToString());
            msg.Body = msg.Body.Replace("{{ReceiverFirstname}}", qry["FirstName"].ToString());
            msg.Body = msg.Body.Replace("{{ReceiverSite}}", qry["Abteilung"].ToString());
            msg.Body = msg.Body.Replace("{{ReceiverTel}}", qry["Phone"].ToString());
            msg.Body = msg.Body.Replace("{{ReceiverMail}}", qry["EMail"].ToString());

            //general
            msg.Body = msg.Body.Replace("{{Date}}", DateTime.Now.ToString("d.M.yyyy"));
            msg.Body = msg.Body.Replace("{{Time}}", DateTime.Now.ToString("HH:mm"));

            msg.Body = msg.Body.Replace("{{Remark}}", bemerkungen);

            SmtpClient smtpClient = new SmtpClient();

            //check System-Config, ob DefaultCredentials gesetzt werden müssen
            var useDefaultCredentials = DBUtil.GetConfigBool(@"System\Mail\UseWindowsCredentials", false);
            if (useDefaultCredentials)
            {
                smtpClient.UseDefaultCredentials = true;
            }
            smtpClient.Host = (string)DBUtil.GetConfigValue(@"System\Mail\SMTP-Relay", "to.be.configured");
            smtpClient.Send(msg);
        }

        /// <summary>
        /// Statusupdate auf BgPosition inkl Detailpositionen
        /// </summary>
        /// <param name="bgPositionID">BgPositionID der Position zu anpassen</param>
        /// <param name="status">Neuer Status</param>
        /// <param name="includeDetailPositions">
        ///     <c>True</c> will update all positions (master/detail)
        ///     <c>False</c> will only update given <paramref name="bgPositionID"/>
        /// </param>
        internal static void SetBewilligungStatusFromPosition(int bgPositionID, BgBewilligungStatus? status, bool includeDetailPositions)
        {
            if (includeDetailPositions)
            {
                //Statusupdate auf BgPosition inkl Detailpositionen
                DBUtil.ExecSQL(@"
                        UPDATE BgPosition
                        SET BgBewilligungStatusCode = {0}
                        WHERE BgPositionID = {1}
                           OR BgPositionID_Parent = {1}",
                    status,
                    bgPositionID);
            }
            else
            {
                //Statusupdate auf BgPosition
                DBUtil.ExecSQL(@"
                        UPDATE BgPosition
                        SET BgBewilligungStatusCode = {0}
                        WHERE BgPositionID = {1}",
                    status,
                    bgPositionID);
            }
        }

        internal static void SqlQueryEditOff(SqlQuery qry)
        {
            if (qry == null)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();
                return;
            }

            qry.CanInsert = false;
            qry.CanUpdate = false;
            qry.CanDelete = false;
        }

        /// <summary>
        /// Validate record date and number. Throws an exception if data is invalid.
        /// </summary>
        /// <param name="kbPeriodeID">The id of the entry in KbPeriode</param>
        /// <param name="edtBelegDatum">The control containing the date that has to match with periode entry</param>
        /// <param name="edtBelegNr">The control containing the unique number of the record that has to be within given range of periode</param>
        /// <param name="bgPositionID">The id within BgPosition, used to validate BelegNr in KbBuchung and KbBuchungKostenart</param>
        /// <exception cref="KissInfoException">Exception is thrown if either the date or the number is invalid</exception>
        /// <exception cref="ArgumentNullException">Exception is thrown if one or more parameters are invalid</exception>
        internal static void ValidateBelegDatumAndNr(int kbPeriodeID, ref KissDateEdit edtBelegDatum, ref KissCalcEdit edtBelegNr, int bgPositionID)
        {
            // validate
            if (edtBelegDatum == null)
            {
                throw new ArgumentNullException("edtBelegDatum", "The control containing the record date is null.");
            }

            if (edtBelegNr == null)
            {
                throw new ArgumentNullException("edtBelegNr", "The control containing the record number is null.");
            }

            // validate BelegDatum and BelegNr using db-functions
            bool isBelegDatumValid = Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnKbCheckBelegDatum({0}, {1});", kbPeriodeID, edtBelegDatum.EditValue));

            if (!isBelegDatumValid)
            {
                // invalid BelegDatum
                edtBelegDatum.Focus();
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "InvalidBelegDatumInCheck",
                                                                 "Das eingegebene Beleg-Datum ist ungültig für das aktuelle Budget und die zugehörige Periode (ID={0}).",
                                                                 kbPeriodeID));
            }

            // validate BelegNr with or without KbBuchung entry
            bool isBelegNrValid = ValidateBelegNr(kbPeriodeID, edtBelegNr.EditValue, bgPositionID);

            if (!isBelegNrValid)
            {
                // invalid BelegNr
                edtBelegNr.Focus();
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "InvalidBelegNrInCheck",
                                                                 "Die eingegebene Beleg-Nr. ist ungültig für das aktuelle Budget und die zugehörige Periode (ID={0}).",
                                                                 kbPeriodeID));
            }
        }

        /// <summary>
        /// Validate record number
        /// </summary>
        /// <param name="kbPeriodeID">The id of the entry in KbPeriode</param>
        /// <param name="belegNr">The unique number of the record that has to be within given range of periode</param>
        /// <param name="bgPositionID">The id within BgPosition, used to validate BelegNr in KbBuchung and KbBuchungKostenart</param>
        /// <returns><c>True</c> if record number is valid and unique, otherwise <c>False</c></returns>
        internal static bool ValidateBelegNr(int kbPeriodeID, object belegNr, int bgPositionID)
        {
            return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                -------------------------------------------------------------------------------
                -- init vars
                -------------------------------------------------------------------------------
                DECLARE @KbPeriodeID INT;
                DECLARE @BgPositionID INT;
                DECLARE @BelegNr INT;

                SET @KbPeriodeID  = {0};
                SET @BgPositionID = {1};
                SET @BelegNr      = {2};

                -------------------------------------------------------------------------------
                -- validate data
                -------------------------------------------------------------------------------
                IF (EXISTS(SELECT TOP 1 1
                           FROM dbo.KbBuchungKostenart KOA WITH (READUNCOMMITTED)
                             INNER JOIN dbo.KbBuchung BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = KOA.KbBuchungID
                                                                                AND BUC.BelegNr IS NOT NULL     -- belegnr has to be given to ensure we can add belegnr on existing empty entries
                           WHERE KOA.BgPositionID = @BgPositionID))
                BEGIN
                  -- we have at least one entry in KbBuchung for given BgPositionID > BelegNr has to be same as any of these entries
                  IF (NOT EXISTS(SELECT TOP 1 1
                                 FROM dbo.KbBuchungKostenart KOA WITH (READUNCOMMITTED)
                                   INNER JOIN dbo.KbBuchung BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = KOA.KbBuchungID
                                                                                      AND BUC.BelegNr = @BelegNr
                                 WHERE KOA.BgPositionID = @BgPositionID))
                  BEGIN
                    -- BelegNr does not match with one of the current records, so it seems to be invalid
                    SELECT [Result] = 0;
                  END
                  ELSE
                  BEGIN
                    -- BelegNr does match, everything is ok
                    SELECT [Result] = 1;
                  END;
                END
                ELSE
                BEGIN
                  -------------------------------------------------------------------------------
                  -- no entry in KbBuchung, perform additional check
                  -------------------------------------------------------------------------------
                  SELECT [Result] = dbo.fnKbCheckBelegNr(@KbPeriodeID, 4, NULL, @BelegNr, NULL);
                END;", kbPeriodeID, bgPositionID, belegNr));
        }

        #endregion

        #endregion
    }
}