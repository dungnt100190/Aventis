using System;
using System.Data;
using KiSS4.DB;

namespace KiSS4.Asyl
{
    public enum BgBewilligungStatus
    {
        InVorbereitung = 1,
        Abgelehnt = 2,
        Angefragt = 3,

        Erteilt = 5,

        Gesperrt = 9
    }

    public enum BgKategorie
    {
        Einnahmen = 1,

        Ausgaben = 2,

        Vermoegen = 5,

        Kuerzung = 4,
        Vorabzug = 6,
        Abzahlung = 3,

        ZusaetzlicheLeistung = 100,
        Einzelzahlung = 101
    }

    public enum BgSpezkontoTyp
    {
        Ausgabekonto = 1,
        Vorabzugkonto = 2,
        Abzahlungskonto = 3
    }

    public enum AyPositionsartID
    {
        GBminus = 60001,
        GBnormal = 60002,
        GBplus = 60003,
        Zahnarzt = 60010,
        Nettolohn = 60901,
        ALVTaggelder = 60902,
        ALVNachzahlung = 60904
    }

    /// <summary>
    /// Summary description for AyUtil.
    /// </summary>
    public class AyUtil
    {
        private AyUtil() { }

        #region Lookup
        internal static SqlQuery GetSqlQueryKostenart()
        {
            return DBUtil.OpenSQL(@"
				SELECT BgKostenartID, Text = IsNull(KontoNr + ': ', '') + Name
				FROM AyKostenart  BKA");
        }

        internal static SqlQuery GetSqlQueryKostenart_Einzelzahlung()
        {
            return DBUtil.OpenSQL(@"
				SELECT BgKostenartID, Text = IsNull(KontoNr + ': ', '') + Name
				FROM AyKostenart  BKA
				WHERE EXISTS (SELECT * FROM AyPositionsart WHERE BgKostenartID = BKA.BgKostenartID AND BgKategorieCode IN (2, 100))");
        }

        [Obsolete]
        internal static SqlQuery GetSqlQueryNrmKonto()
        {
            return DBUtil.OpenSQL(@"
				SELECT Code, Value1 + ', ' + Text AS Text
				FROM XLOVCode
				WHERE LOVName = 'NrmKonto'");
        }
        #endregion

        #region Finanzplan Kennzahlen
        internal static string BgFinanzplan_Kennzahlen(string bgFinanzplanID)
        {
            string sql = @"
				  HgGrundbedarf = (SELECT Count(*) FROM BgFinanzplan_BaPerson WHERE BgFinanzplanID = {0}),
				  UeGrundbedarf = (SELECT Count(*) FROM BgFinanzplan_BaPerson WHERE BgFinanzplanID = {0} AND IstUnterstuetzt = 1)";

            return string.Format(sql, bgFinanzplanID);
        }
        #endregion

        #region BaPerson
        internal static SqlQuery GetPersonen_Unterstuetzt(int bgBudgetID)
        {
            return DBUtil.OpenSQL(@"
				SELECT PRS.BaPersonID, PRS.NameVorname
				FROM BgBudget                       BBG
				  INNER JOIN BgFinanzplan           SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
				  INNER JOIN FaLeistung             LST ON LST.FaLeistungID   = SFP.FaLeistungID
				  INNER JOIN BgFinanzplan_BaPerson  SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
				  INNER JOIN vwPerson               PRS ON PRS.BaPersonID     = SPP.BaPersonID
				WHERE BBG.BgBudgetID = {0} AND SPP.IstUnterstuetzt = 1
				ORDER BY CASE WHEN LST.BaPersonID = SPP.BaPersonID THEN 0 ELSE 1 END, PRS.Name, PRS.Vorname"
                , bgBudgetID);
        }
        #endregion

        #region Zahlungsmodus
        internal static SqlQuery GetZahlungsmodus(int bgBudgetID)
        {
            return GetZahlungsmodus(bgBudgetID, false);
        }

        internal static SqlQuery GetZahlungsmodus(int bgBudgetID, bool indivitell)
        {
            string sql = "";

            if (indivitell)
            {
                sql =
                    @"
                    --SQLCHECK_IGNORE--
					SELECT
					  BgZahlungsmodusID    = CONVERT(int, NULL),
					  NameZahlungsmodus    = '',
					  KbAuszahlungsArtCode = CONVERT(int, NULL),
					  BaZahlungswegID      = CONVERT(int, NULL),
					  ReferenzNummer       = CONVERT(varchar(50), NULL),
					  Periodizitaet        = CONVERT(int, 1)
                    UNION ALL ";
            }

            return DBUtil.OpenSQL(sql + @"
				SELECT DISTINCT SZM.BgZahlungsmodusID, SZM.NameZahlungsmodus, SZM.KbAuszahlungsArtCode, SZM.BaZahlungswegID, SZM.ReferenzNummer,
				  Periodizitaet = CASE
				                    WHEN TRM.Datum IS NOT NULL  THEN 3  -- Individuell
				                    WHEN TRM.Anzahl = 1         THEN 1  -- 1x pro Monat
				                    WHEN TRM.Anzahl = 2         THEN 2  -- 2x pro Monat
				                    ELSE 1
				                  END
				FROM BgZahlungsmodus       SZM
				  INNER JOIN BgFinanzplan  SFP ON SFP.FaLeistungID = SZM.FaLeistungID
				  INNER JOIN BgBudget      BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
				  LEFT  JOIN (SELECT BgZahlungsmodusID, Datum = MIN(Datum), Anzahl = COUNT(*)
				              FROM BgZahlungsmodusTermin
				              GROUP BY BgZahlungsmodusID) TRM ON TRM.BgZahlungsmodusID = SZM.BgZahlungsmodusID
				WHERE BBG.BgBudgetID = {0}
				  AND ( SZM.DatumVon IS NULL OR SZM.DatumVon <= CASE WHEN BBG.MasterBudget = 1 THEN COALESCE(SFP.DatumBis, SFP.GeplantBis, '99991231') ELSE dbo.fnLastDayOf(dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)) END )
				  AND ( SZM.DatumBis IS NULL OR SZM.DatumBis >= CASE WHEN BBG.MasterBudget = 1 THEN IsNull(SFP.DatumVon, SFP.GeplantVon)               ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)  END )
				ORDER BY 2, 1"
                , bgBudgetID);
        }
        #endregion

        #region Spezialkonto
        internal static SqlQuery GetSpezKonto(int bgBudgetID, BgSpezkontoTyp bgSpezkontoTypCode)
        {
            return GetSpezKonto(bgBudgetID, bgSpezkontoTypCode, DBNull.Value);
        }

        internal static SqlQuery GetSpezKonto(int bgBudgetID, BgSpezkontoTyp bgSpezkontoTypCode, object bgKostenartID)
        {
            return GetSpezKonto(bgBudgetID, DBNull.Value, bgSpezkontoTypCode, bgKostenartID);
        }

        //internal static SqlQuery GetSpezKonto(int bgBudgetID, object bgPositionID, BgSpezkontoTyp bgSpezkontoTypCode)
        //{
        //    return GetSpezKonto(bgBudgetID, bgPositionID, bgSpezkontoTypCode, DBNull.Value);
        //}

        internal static SqlQuery GetSpezKonto(int bgBudgetID, object bgPositionID, BgSpezkontoTyp bgSpezkontoTypCode, object bgKostenartID)
        {
            SqlQuery qry = new SqlQuery();
            qry.AfterFill += new EventHandler(qryGetSpezKonto_AfterFill);

            qry.Fill(@"
				SELECT SSK.BgSpezkontoID, SSK.NameSpezkonto,
				  DisplayText = SSK.NameSpezkonto + ' ({0:N2})',
				  Saldo       = dbo.fnBgSpezkonto(SSK.BgSpezkontoID, 3, {0}, {1}),
				  SSK.BgKostenartID, SSK.BaPersonID, SSK.BaInstitutionID
				FROM BgBudget              BBG
				  INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
				  INNER JOIN BgSpezkonto   SSK ON SSK.FaLeistungID = SFP.FaLeistungID
				WHERE BBG.BgBudgetID = {0} AND SSK.BgSpezkontoTypCode = {2}
				  AND ( SSK.DatumVon IS NULL OR dbo.fnDateOf(CASE WHEN BgSpezkontoTypCode = 3 THEN DateAdd(m, -3, SSK.DatumVon) ELSE SSK.DatumVon END) <= CASE WHEN BBG.MasterBudget = 1 THEN dbo.fnDateOf(SFP.DatumBis) ELSE dbo.fnLastDayOf(dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)) END )
				  AND ( SSK.DatumBis IS NULL OR dbo.fnDateOf(SSK.DatumBis) >= CASE WHEN BBG.MasterBudget = 1 THEN dbo.fnDateOf(IsNull(SFP.DatumVon, SFP.GeplantVon)) ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)  END )
				  AND ({3} IS NULL OR SSK.BgKostenartID IS NULL OR SSK.BgKostenartID = {3})
				  AND SSK.OhneEinzelzahlung = 0"
                , bgBudgetID, bgPositionID, (int)bgSpezkontoTypCode, bgKostenartID);

            return qry;
        }

        private static void qryGetSpezKonto_AfterFill(object sender, EventArgs e)
        {
            SqlQuery qry = (SqlQuery)sender;

            foreach (DataRow row in qry.DataTable.Rows)
            {
                row["DisplayText"] = string.Format((string)row["DisplayText"], (decimal)row["Saldo"]);

                row.AcceptChanges();
                qry.RowModified = false;
            }
        }
        #endregion

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

        #region User Budget
        internal static void ApplyShStatusCodeToSqlQuery_SFP(SqlQuery qry, int bgFinanzplanID)
        {
            object BgBewilligungStatusCode = DBUtil.ExecuteScalarSQL(@"
				SELECT BgBewilligungStatusCode 
				FROM BgFinanzplan
				WHERE BgFinanzplanID = {0}",
                bgFinanzplanID);

            if (BgBewilligungStatusCode == null) return;

            if ((int)BgBewilligungStatusCode >= (int)BgBewilligungStatus.Erteilt)
                SqlQueryEditOff(qry);
        }
        #endregion

        #region User Einzelzahlung
        internal static void ApplyKbBuchungStatusCodeToSqlQuery_SEZ(SqlQuery qry, int bgPositionID)
        {
            object KbBuchungStatusCode = DBUtil.ExecuteScalarSQL(@"
				SELECT FBL.KbBuchungStatusCode
				FROM BgPosition                  BPO
				  INNER JOIN KbBuchung           FBL ON FBL.BgBudgetID = BPO.BgBudgetID
				  INNER JOIN KbBuchungKostenart  KBK ON KBK.KbBuchungID = FBL.KbBuchungID AND KBK.BgPositionID = BPO.BgPositionID
				WHERE BPO.BgPositionID = {0}"
                , bgPositionID);

            if (KbBuchungStatusCode == null) return;

            switch ((int)KbBuchungStatusCode)
            {
                case 1:  // vorbereitet (Preview)
                case 2:  // freigegeben
                    break;

                default:
                    SqlQueryEditOff(qry);
                    break;
            }
        }
        #endregion

        #region Bewilligung
        internal static SqlQuery GetBgBewilligung_Neu()
        {
            SqlQuery qryBgBewilligung = DBUtil.OpenSQL("SELECT * FROM BgBewilligung WHERE 1 = 0");

            qryBgBewilligung.Insert("BgBewilligung");
            qryBgBewilligung["UserID"] = Session.User.UserID;

            return qryBgBewilligung;
        }
        #endregion

        private static SqlQuery qryRichtlinie = DBUtil.OpenSQL(@"
			SELECT HG_MIN = $0.00, HG_MAX = NULL, HG_DEF = NULL,
			       UE_MIN = $0.00, UE_MAX = NULL, UE_DEF = NULL,
			       PR_MIN = $0.00, PR_MAX = NULL, PR_DEF = NULL
			WHERE 1=0");

        internal static SqlQuery GetRichtlinie(int bgPositionsartID, int bgBudgetID)
        {
            return GetRichtlinie(DBUtil.ExecuteScalarSQL("SELECT sqlRichtlinie FROM BgPositionsart WHERE BgPositionsartID = {0}", bgPositionsartID), bgBudgetID);
        }

        internal static SqlQuery GetRichtlinie(object sqlRichtlinie, int bgBudgetID)
        {
            if (DBUtil.IsEmpty(sqlRichtlinie)) return qryRichtlinie;

            try
            {
                SqlQuery qry = DBUtil.OpenSQL(string.Format(@"
				DECLARE @RefDate         DATETIME,
				        @BgBudgetID      INT,
				        @BgFinanzplanID  INT

				SELECT @RefDate        = IsNull(SFP.DatumVon, SFP.GeplantVon),
				       @BgBudgetID     = {0},
				       @BgFinanzplanID = BBG.BgFinanzplanID
				FROM BgBudget              BBG
				  INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
				WHERE BBG.BgBudgetID = {0}

				{1}", "{0}", sqlRichtlinie), bgBudgetID);

                if (qry.Count == 1)
                    foreach (DataColumn col in qry.DataTable.Columns)
                        if (!DBUtil.IsEmpty(qry[col.ColumnName]))
                            return qry;
            }
            catch { }

            return qryRichtlinie;
        }

        #region ID of
        internal static int GetFaLeistungID_of_BgBudgetID(int bgBudgetID)
        {
            return (int)DBUtil.ExecuteScalarSQL(@"
				SELECT SFP.FaLeistungID
				FROM BgFinanzplan      SFP
				  INNER JOIN BgBudget  BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
				WHERE BBG.BgBudgetID = {0}"
                , bgBudgetID);
        }
        #endregion
    }
}
