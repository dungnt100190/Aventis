using KiSSSvc.DAL.KiSSDBTableAdapters;
using System;
using KiSSSvc.Logging;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace KiSSSvc.DAL
{
    partial class KiSSDB
    {
        partial class XDocumentDataTable
        {
        }

        partial class KbOpAusgleichDataTable
        {
        }

        partial class SstIKAuszugDataTable
        {
        }

        public static void CheckDBName(string dbname)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(global::KiSSSvc.DAL.Properties.Settings.Default.KiSS_40_MASTERConnectionString);
            if (builder.InitialCatalog.ToUpper() != dbname.ToUpper())
                throw new Exception(string.Format("Dieser KiSS-Serviceserver wurde für die Datenbank '{0}' konfiguriert, nicht für '{1}'.", builder.InitialCatalog, dbname));
        }

        public static string GetDBName()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(global::KiSSSvc.DAL.Properties.Settings.Default.KiSS_40_MASTERConnectionString);
            return builder.InitialCatalog;
        }

        public static string GetDBServerName()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(global::KiSSSvc.DAL.Properties.Settings.Default.KiSS_40_MASTERConnectionString);
            return builder.DataSource;
        }

        public static bool CheckDBConnection()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(KiSSSvc.DAL.KiSSDB.ReplacePwd(global::KiSSSvc.DAL.Properties.Settings.Default.KiSS_40_MASTERConnectionString));
                con.Open();
                if (con.State == ConnectionState.Open)
                    return true;
            }
            finally
            {
                con.Close();
            }
            return false;
        }

        public static string ReplacePwd(string connectionstring)
        {
            try
            {
                return Scrambler.DecryptPasswordInConnectionString(connectionstring);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                return connectionstring;
            }
        }
    }
}

namespace KiSSSvc.DAL.KiSSDBTableAdapters
{

    partial class BaInstitutionOnlyTableAdapter
    {
        public KiSSDB.BaInstitutionOnlyDataTable GetInstitutionsAndSchuldnerOfKbBuchungIDs(int[] kbBuchungIDs, int[] kbBuchungBruttoIDs)
        {
            KiSSDB.BaInstitutionOnlyDataTable dataTable = new KiSSDB.BaInstitutionOnlyDataTable();
            List<string> clauses = new List<string>();
            if (kbBuchungIDs != null && kbBuchungIDs.Length > 0)
            {
                string inID = string.Join(", ", new List<int>(kbBuchungIDs).ConvertAll<string>(Convert.ToString).ToArray());
                clauses.Add(string.Format(@"
INSERT INTO @tmp
SELECT KBB.KbBuchungBruttoID
FROM   KbBuchungKostenart          KBK
  INNER JOIN KbBuchung             KBU ON KBK.KbBuchungID       = KBU.KbBuchungID
  INNER JOIN KbBuchungBruttoPerson KBP ON KBP.BgPositionID      = KBK.BgPositionID
  INNER JOIN KbBuchungBrutto       KBB ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID AND (KBB.ValutaDatum = KBU.ValutaDatum OR (KBK.PositionImBeleg IS NULL AND KBK.Betrag = $0.00) )
WHERE KBU.KbBuchungID IN ({0})

SELECT DISTINCT BaInstitutionID = ZAL.BaInstitutionID
FROM KbBuchung                  KBB 
  INNER JOIN KbBuchungKostenart KBK ON KBK.KbBuchungID = KBB.KbBuchungID 
  INNER JOIN BaZahlungsweg      ZAL ON ZAL.BaZahlungswegID = KBB.BaZahlungswegID
WHERE (ZAL.BaInstitutionID IS NOT NULL) AND (KBB.KbBuchungStatusCode IN (2,4,5) /*freigegeben,ausgedruckt,fehlerhaft*/) AND KBB.KbBuchungID IN ({0})

UNION

SELECT DISTINCT BaInstitutionID = ZAL.BaPersonID
FROM KbBuchung                  KBB 
  INNER JOIN KbBuchungKostenart KBK ON KBK.KbBuchungID = KBB.KbBuchungID 
  INNER JOIN BaZahlungsweg      ZAL ON ZAL.BaZahlungswegID = KBB.BaZahlungswegID
WHERE (ZAL.BaPersonID IS NOT NULL) AND (KBB.KbBuchungStatusCode IN (2,4,5) /*freigegeben,ausgedruckt,fehlerhaft*/) AND KBB.KbBuchungID IN ({0})", inID));
            }

            string bruttoIDsWhereClause = "";
            if (kbBuchungBruttoIDs != null && kbBuchungBruttoIDs.Length > 0)
            {
                string inID = string.Join(", ", new List<int>(kbBuchungBruttoIDs).ConvertAll<string>(Convert.ToString).ToArray());
                bruttoIDsWhereClause = string.Format("KBB.KbBuchungBruttoID IN ({0}) OR", inID);
            }
            clauses.Add(string.Format(@"
SELECT DISTINCT BaInstitutionID = KBK.Schuldner_BaInstitutionID
FROM KbBuchungBrutto               KBB
  INNER JOIN KbBuchungBruttoPerson KBK ON KBK.KbBuchungBruttoID = KBB.KbBuchungBruttoID
WHERE (KBB.KbBuchungStatusCode IN (2,4,5) /*freigegeben,ausgedruckt,fehlerhaft*/) AND (KBK.Schuldner_BaInstitutionID IS NOT NULL) AND ({0} KBB.KbBuchungBruttoID IN (SELECT KbBuchungBruttoID FROM @tmp))

UNION

SELECT DISTINCT BaInstitutionID = KBK.Schuldner_BaPersonID
FROM KbBuchungBrutto               KBB
  INNER JOIN KbBuchungBruttoPerson KBK ON KBK.KbBuchungBruttoID = KBB.KbBuchungBruttoID
WHERE (KBB.KbBuchungStatusCode IN (2,4,5) /*freigegeben,ausgedruckt,fehlerhaft*/) AND (KBK.Schuldner_BaPersonID IS NOT NULL) AND ({0} KBB.KbBuchungBruttoID IN (SELECT KbBuchungBruttoID FROM @tmp))

UNION

--InvMDAS-Buchungen
SELECT BaInstitutionID = BaPersonID
FROM KbBuchungBrutto               KBB
  INNER JOIN KbBuchungBruttoPerson KBK ON KBK.KbBuchungBruttoID = KBB.KbBuchungBruttoID
WHERE BgBudgetID IS NULL AND BaPersonID <> 499998 AND ({0} KBB.KbBuchungBruttoID IN (SELECT KbBuchungBruttoID FROM @tmp))", bruttoIDsWhereClause));


            this.Adapter.SelectCommand = CommandCollection[0];
            this.Adapter.SelectCommand.CommandText = @"DECLARE @tmp TABLE( KbBuchungBruttoID int )" + string.Join(" UNION ", clauses.ToArray());

            this.Adapter.Fill(dataTable);
            return dataTable;
        }
    }

    partial class KgBuchungTableAdapter
    {
        public virtual KiSSDB.KgBuchungDataTable GetKgBuchungByIDs(string[] idArray)
        {
            string inID = string.Join(",", idArray);
            this.Adapter.SelectCommand = CommandCollection[2];
            this.Adapter.SelectCommand.CommandText = string.Format(@"
                   SELECT KgBuchungID, KgPeriodeID, KgPositionID, KgBuchungTypCode, KgAusgleichStatusCode, KgZahlungseingangID, CodeVorlage, BelegNr, BelegNrPos, 
                      BuchungsDatum, SollKtoNr, HabenKtoNr, Betrag, BetragFW, FbWaehrungID, Text, ValutaDatum, TransferDatum, KgBuchungStatusCode, UserIDKasse, 
                      BaZahlungswegID, BaInstitutionID, EinzahlungsscheinCode, KgAuszahlungsArtCode, BaBankID, BankKontoNummer, IBANNummer, PostKontoNummer,
                       ESRTeilnehmer, ESRReferenznummer, MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4, ErstelltUserID, ErstelltDatum, 
                      MutiertUserID, MutiertDatum, KgBuchungTS, PscdFehlermeldung, PscdBelegNr, CAST(0 AS bigint) AS StorniertBelegNr, NULL AS StorniertValuta, 
                      BeguenstigtName, BeguenstigtStrasse, BeguenstigtName2, BeguenstigtHausNr, BeguenstigtPostfach, BeguenstigtOrt, BeguenstigtPLZ, 
                      BeguenstigtLandCode, BarbezugDatum, StorniertKgBuchungID
                FROM KgBuchung AS KBU 
                WHERE KgBuchungID IN ({0}) AND KgBuchungStatusCode IN (2,4,5) /*freigegeben,ausgedruckt,fehlerhaft*/ AND TransferDatum IS NULL", inID);
            //Log.Info(this.GetType(), this.Adapter.SelectCommand.CommandText);
            KiSSDB.KgBuchungDataTable dataTable = new KiSSDB.KgBuchungDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Gibt die ersten N Buchungen zurück. Momentan wird die Funktion nur für Schnittstellen-Tests verwendet.
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public virtual KiSSDB.KgBuchungDataTable GetKgBuchungTopN(int anzahlBuchungen)
        {
            this.Adapter.SelectCommand = CommandCollection[2];
            this.Adapter.SelectCommand.CommandText = string.Format(@"
                   SELECT TOP {0} KgBuchungID, KgPeriodeID, KgPositionID, KgBuchungTypCode, KgAusgleichStatusCode, KgZahlungseingangID, CodeVorlage, BelegNr, BelegNrPos, 
                      BuchungsDatum, SollKtoNr, HabenKtoNr, Betrag, BetragFW, FbWaehrungID, Text, ValutaDatum, TransferDatum, KgBuchungStatusCode, UserIDKasse, 
                      BaZahlungswegID, BaInstitutionID, EinzahlungsscheinCode, KgAuszahlungsArtCode, BaBankID, BankKontoNummer, IBANNummer, PostKontoNummer,
                       ESRTeilnehmer, ESRReferenznummer, MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4, ErstelltUserID, ErstelltDatum, 
                      MutiertUserID, MutiertDatum, KgBuchungTS, PscdFehlermeldung, PscdBelegNr, CAST(0 AS bigint) AS StorniertBelegNr, NULL AS StorniertValuta, 
                      BeguenstigtName, BeguenstigtStrasse, BeguenstigtName2, BeguenstigtHausNr, BeguenstigtPostfach, BeguenstigtOrt, BeguenstigtPLZ, 
                      BeguenstigtLandCode, BarbezugDatum, StorniertKgBuchungID
                FROM KgBuchung AS KBU 
                WHERE KgBuchungStatusCode = 2 /*freigegeben*/ AND TransferDatum IS NULL AND HabenKtoNr = 2000
              ORDER BY KBU.KgBuchungID DESC", anzahlBuchungen);

            //Log.Info(this.GetType(), this.Adapter.SelectCommand.CommandText);
            KiSSDB.KgBuchungDataTable dataTable = new KiSSDB.KgBuchungDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        public virtual KiSSDB.KgBuchungDataTable GetStornoKgBuchungByIDs(string[] idArray)
        {
            string inID = string.Join(",", idArray);
            this.Adapter.SelectCommand = CommandCollection[3];
            this.Adapter.SelectCommand.CommandText = string.Format(@"
                SELECT STO.Adresszeile1, STO.Adresszeile2, STO.Adresszeile3, STO.Adresszeile4, STO.BaBankID,
                  STO.BaInstitutionID, STO.BaZahlungswegID, STO.BankKontoNummer, STO.BelegNr, STO.BelegNrPos, STO.Betrag,
                  STO.BetragEff, STO.BetragFW, STO.BuchungsDatum, STO.CodeVorlage, STO.DatumEff, STO.ESRReferenznummer,
                  STO.ESRTeilnehmer, STO.EinzahlungsscheinCode, STO.ErstelltDatum, STO.ErstelltUserID, STO.FbWaehrungID,
                  STO.HabenKtoNr, STO.IBANNummer, STO.KgAusgleichStatusCode, STO.KgAuszahlungsArtCode, STO.KgBuchungID,
                  STO.KgBuchungStatusCode, STO.KgBuchungTS, STO.KgBuchungTypCode, STO.KgPeriodeID, STO.KgPositionID,
                  STO.KgZahlungseingangID, STO.MitteilungZeile1, STO.MitteilungZeile2, STO.MitteilungZeile3,
                  STO.MitteilungZeile4, STO.MutiertDatum, STO.MutiertUserID, STO.PostKontoNummer, STO.PscdBelegNr,
                  STO.PscdFehlermeldung, STO.SollKtoNr, STO.Text, STO.TransferDatum, STO.UserIDKasse, STO.ValutaDatum,
                  STO.Zahlungsfrist,
                  BUC.KgBuchungID AS StorniertKgBuchungID,
                  BUC.ValutaDatum AS StorniertValutaDatum,
                  BUC.PscdBelegNr AS StorniertBelegNr
                FROM KgBuchung AS STO
                  INNER JOIN KgBuchung AS BUC ON BUC.KgBuchungID = STO.StorniertKgBuchungID
                  INNER JOIN KgPosition AS POS ON POS.KgPositionID = STO.KgPositionID
                WHERE (STO.KgBuchungID IN ({0}) ) AND (STO.KgBuchungTypCode = 3) AND (STO.KgBuchungStatusCode = 2)", inID);
            KiSSDB.KgBuchungDataTable dataTable = new KiSSDB.KgBuchungDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
    }

    partial class BaPLZTableAdapter
    {
        public virtual KiSSDB.BaPLZDataTable GetPLZByPLZOrName(string inPLZ, string inName)
        {
            this.Adapter.SelectCommand = CommandCollection[0];
            this.Adapter.SelectCommand.CommandText = string.Format("SELECT BaPLZID, PLZ, Name FROM BaPLZ WHERE PLZ IN ({0}) OR Name IN ({1})", inPLZ, inName);
            KiSSDB.BaPLZDataTable dataTable = new KiSSDB.BaPLZDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
    }

    partial class ZipUserTableAdapter
    {
        public virtual KiSSDB.ZipUserDataTable GetUserForMultipleZIP(string[] zipArray)
        {
            KiSSDB.ZipUserDataTable dataTable = new KiSSDB.ZipUserDataTable();

            if (zipArray == null || zipArray.Length == 0)
            {
                return dataTable;
            }

            string inZip = string.Join(",", zipArray);

            Adapter.SelectCommand = CommandCollection[1];
            Adapter.SelectCommand.CommandText = string.Format(@"

                --Person is Fallträger: wir nehmen die letzte aktuelle Fallführung
                SELECT PRS.BaPersonID, PRS.ZIPNr, LEI.FaLeistungID, FaFallID = NULL, LEI.UserID, LEI.ModulID
                FROM dbo.BaPerson       PRS
                  INNER JOIN dbo.FaFall FAL ON FAL.BaPersonID = PRS.BaPersonID
                  CROSS APPLY (SELECT TOP 1 LEI1.FaLeistungID, LEI1.UserID, LEI1.ModulID
                               FROM dbo.FaLeistung LEI1
                               WHERE LEI1.FaFallID = FAL.FaFallID
                                 AND LEI1.FaProzessCode = 200
                                 AND LEI1.DatumBis IS NULL
                               ORDER BY LEI1.DatumVon DESC) LEI
                WHERE PRS.ZIPNr IN ({0})

                UNION

                --Person ist Leistungsträger: wir nehmen diese Leistung(en)
                SELECT PRS.BaPersonID, PRS.ZIPNr, LEI.FaLeistungID, FaFallID = NULL, LEI.UserID, LEI.ModulID
                FROM dbo.BaPerson           PRS
                  INNER JOIN dbo.FaLeistung LEI ON LEI.BaPersonID = PRS.BaPersonID
                WHERE PRS.ZIPNr IN ({0})
                  AND LEI.DatumBis IS NULL

                UNION

                --Person kommt in einem Fall vor, ist aber bei keiner Leistung der Leistungsträger: wir nehmen die aktuelle Fallführung des Falls
                SELECT PRS.BaPersonID, PRS.ZIPNr, LEI.FaLeistungID, FaFallID = NULL, LEI.UserID, LEI.ModulID
                FROM dbo.BaPerson             PRS
                  INNER JOIN dbo.FaFallPerson FFP ON FFP.BaPersonID = PRS.BaPersonID
                  INNER JOIN dbo.FaFall       FAL ON FAL.FaFallID   = FFP.FaFallID
                  CROSS APPLY (SELECT TOP 1 LEI1.FaLeistungID, LEI1.UserID, LEI1.ModulID
                               FROM dbo.FaLeistung LEI1
                               WHERE LEI1.FaFallID = FAL.FaFallID
                                 AND LEI1.FaProzessCode = 200
                                 AND LEI1.DatumBis IS NULL
                               ORDER BY LEI1.DatumVon DESC) LEI
                WHERE PRS.ZIPNr IN ({0})
                ORDER BY PRS.ZIPNr, LEI.UserID, LEI.ModulID;", inZip);

            Adapter.Fill(dataTable);
            return dataTable;
        }
    }

    partial class FaLeistungTableAdapter
    {
        public KiSSDB.FaLeistungDataTable GetLeistungenByIDs(int[] idArray)
        {
            KiSSDB.FaLeistungDataTable dataTable = new KiSSDB.FaLeistungDataTable();
            if (idArray == null || idArray.Length == 0)
                return dataTable; // null object

            string inID = string.Join(", ", new List<int>(idArray).ConvertAll<string>(Convert.ToString).ToArray());

            this.Adapter.SelectCommand = CommandCollection[2];
            this.Adapter.SelectCommand.CommandText = string.Format(@"
SELECT LEI.FaLeistungID, LEI.FaFallID, FaProzessCode, BaPersonID, DatumVon, DatumBis, PscdVertragsgegenstandID, FaLeistungTS, CAST(FaLeistungTS AS bigint) + 0 AS FaLeistungTSCast, Fallverantwortlicher = USR.LogonName, LEI.ModulID
FROM FaLeistung LEI
  INNER JOIN XUser USR ON USR.UserID = LEI.UserID
WHERE FaLeistungID IN ({0})", inID);

            this.Adapter.Fill(dataTable);
            return dataTable;
        }
    }

    partial class KbBuchungBruttoTableAdapter
    {
        public KiSSDB.KbBuchungBruttoDataTable GetBruttoBelegeByKbBuchungIDs(int[] kbBuchungIDs, int[] kbBuchungBruttoIDs)
        {
            KiSSDB.KbBuchungBruttoDataTable dataTable = new KiSSDB.KbBuchungBruttoDataTable();
            string nettoIDsClause = "";
            if (kbBuchungIDs != null && kbBuchungIDs.Length > 0)
            {
                string inID = string.Join(", ", new List<int>(kbBuchungIDs).ConvertAll<string>(Convert.ToString).ToArray());
                nettoIDsClause = string.Format(@"OR KbBuchungBruttoID IN
(
SELECT KBB.KbBuchungBruttoID
FROM   KbBuchungKostenart          KBK
  INNER JOIN KbBuchung             KBU ON KBK.KbBuchungID       = KBU.KbBuchungID
  INNER JOIN KbBuchungBruttoPerson KBP ON KBP.BgPositionID      = KBK.BgPositionID
  INNER JOIN KbBuchungBrutto       KBB ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID AND (KBB.ValutaDatum = KBU.ValutaDatum OR (KBK.PositionImBeleg IS NULL AND KBK.Betrag = $0.00) )
WHERE KBU.KbBuchungID IN ({0})
)", inID);
            }

            string bruttoIDsClause = "";
            if (kbBuchungBruttoIDs != null && kbBuchungBruttoIDs.Length > 0)
                bruttoIDsClause = string.Format("OR KbBuchungBruttoID IN ({0})", string.Join(", ", new List<int>(kbBuchungBruttoIDs).ConvertAll<string>(Convert.ToString).ToArray()));

            this.Adapter.SelectCommand = CommandCollection[2];
            this.Adapter.SelectCommand.CommandText = string.Format(@"                                             
SELECT KBU.*, PscdVertragsgegenstandID = LEI.PscdVertragsgegenstandID, 
  BaPersonID_LT = LEI.BaPersonID
FROM KbBuchungBrutto     KBU
  LEFT JOIN BgBudget     BUD ON BUD.BgBudgetID     = KBU.BgBudgetID
  LEFT JOIN BgFinanzplan FIP ON FIP.BgFinanzplanID = BUD.BgFinanzplanID
  LEFT JOIN FaLeistung   LEI ON LEI.FaLeistungID   = IsNull(FIP.FaLeistungID,KBU.FaLeistungID)
WHERE 1=0 {0} {1}", nettoIDsClause, bruttoIDsClause);
            this.Adapter.Fill(dataTable);
            return dataTable;
        }


        public KiSSDB.KbBuchungBruttoDataTable GetBruttoBelegeByGruppierungUmbuchung(string gruppierungUmbuchung)
        {
            KiSSDB.KbBuchungBruttoDataTable dataTable = new KiSSDB.KbBuchungBruttoDataTable();
            if (gruppierungUmbuchung != null)
            {
                this.Adapter.SelectCommand = CommandCollection[2];
                this.Adapter.SelectCommand.CommandText = string.Format(@"                                             
SELECT KBU.*, PscdVertragsgegenstandID = LEI.PscdVertragsgegenstandID, 
  BaPersonID_LT = LEI.BaPersonID
FROM KbBuchungBrutto     KBU
  LEFT JOIN BgBudget     BUD ON BUD.BgBudgetID     = KBU.BgBudgetID
  LEFT JOIN BgFinanzplan FIP ON FIP.BgFinanzplanID = BUD.BgFinanzplanID
  LEFT JOIN FaLeistung   LEI ON LEI.FaLeistungID   = IsNull(FIP.FaLeistungID,KBU.FaLeistungID)
WHERE KBU.GruppierungUmbuchung = '{0}'", gruppierungUmbuchung);
                this.Adapter.Fill(dataTable);
            }

            return dataTable;
        }
    }

    partial class KbBuchungBruttoPersonTableAdapter
    {
        public int GetBgKategorieCode(int kbBuchungBruttoPersonID)
        {
            SqlCommand cmd = this.Connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format(@"
                                SELECT POS.BgKategorieCode FROM BgPosition POS
                                    inner join KbBuchungBruttoPerson KBP on KBP.BgPositionID = POS.BgPositionID
                                WHERE KBP.KbBuchungBruttoPersonID = {0}", kbBuchungBruttoPersonID);

            ConnectionState previousConnectionState = cmd.Connection.State;
            if (((cmd.Connection.State & ConnectionState.Open)
                                        != ConnectionState.Open))
            {
                cmd.Connection.Open();
            }
            try
            {
                object id = cmd.ExecuteScalar();
                if (id is int)
                    return (int)id;
                throw new Exception(string.Format("BgKategoryCode konnte nicht gefunden werden für KbBuchungBruttoPersonID = {0}.", kbBuchungBruttoPersonID));
            }
            finally
            {
                if ((previousConnectionState == ConnectionState.Closed))
                {
                    cmd.Connection.Close();
                }
            }
        }

        public List<int> GetAllBPNumersInBudget(int bgBudgetID)
        {

            SqlCommand cmd = this.Connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format(@"
                                SELECT DISTINCT KBK.BaPersonID
                                FROM KbBuchungKostenart KBK
                                  INNER JOIN KbBuchung  KBU ON KBU.KbBuchungID = KBK.KbBuchungID
                                WHERE KBU.BgBudgetID = {0}", bgBudgetID);
            ConnectionState previousConnectionState = cmd.Connection.State;
            if (((cmd.Connection.State & ConnectionState.Open)
                                 != ConnectionState.Open))
            {
                cmd.Connection.Open();
            }
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<int> numbers = new List<int>();
                while (reader.Read())
                    numbers.Add(reader.GetInt32(0));
                return numbers;
            }
            finally
            {
                if ((previousConnectionState == ConnectionState.Closed))
                {
                    cmd.Connection.Close();
                }
            }
        }
    }
    partial class KbBuchungTableAdapter
    {
        /// <summary>
        /// Erstellt eine Transaktion und gibt das SqlTransaction Object zurück
        /// </summary>
        /// <returns></returns>
        public SqlTransaction BeginTransaction()
        {
            return this.Connection.BeginTransaction();
        }

        public KiSSDB.KbBuchungDataTable GetAlimBelegeFromKbBuchungIDs(int[] idArray)
        {
            KiSSDB.KbBuchungDataTable dataTable = new KiSSDB.KbBuchungDataTable();
            if (idArray == null || idArray.Length == 0)
                return dataTable; // null object

            string inID = string.Join(", ", new List<int>(idArray).ConvertAll<string>(Convert.ToString).ToArray());

            this.Adapter.SelectCommand = CommandCollection[1];
            this.Adapter.SelectCommand.CommandText = string.Format(@"                                             
SELECT KBU.*, PscdVertragsgegenstandID = LEI.PscdVertragsgegenstandID, LEI.FaLeistungID, 
  IstKreditorBuchung = CASE HabenKtoNr WHEN KRE.KontoNr THEN 1 ELSE 0 END,
  IstDebitorBuchung  = CASE SollKtoNr  WHEN DEB.KontoNr THEN 1 ELSE 0 END,
  AnDritte = CASE WHEN BaZahlungswegID NOT IN (SELECT BaZahlungswegID
                                               FROM BaZahlungsweg    ZAL
                                                 INNER JOIN PscdSentFaLeistung_Person SNT ON SNT.BaPersonID = ZAL.BaPersonID
                                               WHERE SNT.FaLeistungID = LEI.FaLeistungID) THEN 1 ELSE 0 END,
  BaPersonID_LT      = LEI.BaPersonID
FROM KbBuchung             KBU
  LEFT  JOIN IkPosition    IKP ON IKP.IkPositionID    = KBU.IkPositionID
  LEFT  JOIN IkRechtstitel RET ON RET.IkRechtstitelID = IKP.IkRechtstitelID
  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID    = COALESCE(RET.FaLeistungID, IKP.FaLeistungID, KBU.FaLeistungID)
  LEFT  JOIN KbKonto       DEB ON DEB.KbPeriodeID     = KBU.KbPeriodeID AND ',' + DEB.KbKontoartCodes + ',' LIKE '%,20,%' /*Debitor*/
  LEFT  JOIN KbKonto       KRE ON KRE.KbPeriodeID     = KBU.KbPeriodeID AND ',' + KRE.KbKontoartCodes + ',' LIKE '%,30,%' /*Kreditor*/
WHERE KBU.ModulID IN (3,4) /*W-Inkasso, ALIM*/ AND KbBuchungStatusCode IN (2,4,5,16) /*freigegeben,ausgedruckt,fehlerhaft,rückläufer-korrigiert*/ AND (TransferDatum IS NULL OR KbBuchungStatusCode = 16 ) AND (HabenKtoNr = KRE.KontoNr OR SollKtoNr = DEB.KontoNr) AND KbBuchungID IN({0})", inID);

            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Liefert Netto-Buchungen zurück
        /// </summary>
        /// <param name="idArray"></param>
        /// <param name="getAllStatus">Wenn true, wird jeder Status zurückgegeben, sonst wird gefilert auf KbBuchungStatusCode IN (2,4,5,16) </param>
        /// <param name="getAllDependend">Wenn true, dann werden auch alle abhängigen Netto-Buchungen zurückgegeben</param>
        /// <returns></returns>
        public KiSSDB.KbBuchungDataTable GetWhBelegeFromKbBuchungIDs(int[] idArray, bool getAllStatus, bool getAllDependend)
        {
            KiSSDB.KbBuchungDataTable dataTable = new KiSSDB.KbBuchungDataTable();
            if (idArray == null || idArray.Length == 0)
                return dataTable; // null object

            string inID = string.Join(", ", new List<int>(idArray).ConvertAll<string>(Convert.ToString).ToArray());

            this.Adapter.SelectCommand = CommandCollection[1];
            this.Adapter.SelectCommand.CommandText = string.Format(@"  
  SELECT distinct 
      KRE.KontoNr, 
      DEB.KontoNr, 
      LEI.FaLeistungID, 
      KBU.*, 
      PscdVertragsgegenstandID = LEI.PscdVertragsgegenstandID, 
      IstKreditorBuchung = CASE KBU.HabenKtoNr WHEN KRE.KontoNr THEN 1 ELSE 0 END,
      IstDebitorBuchung = CASE KBU.SollKtoNr WHEN DEB.KontoNr THEN 1 ELSE 0 END,
      AnDritte = CASE WHEN KBU.BaZahlungswegID NOT IN (SELECT BaZahlungswegID
                                                 FROM BaZahlungsweg    ZAL
                                                   INNER JOIN PscdSentFaLeistung_Person SNT ON SNT.BaPersonID = ZAL.BaPersonID
                                                 WHERE SNT.FaLeistungID = LEI.FaLeistungID) THEN 1 ELSE 0 END,
      BaPersonID_LT = LEI.BaPersonID,
      KBS.StornoBelegNr
  FROM KbBuchung KBU
      LEFT  JOIN BgBudget     BUD ON BUD.BgBudgetID     = KBU.BgBudgetID
      LEFT  JOIN BgFinanzplan FIP ON FIP.BgFinanzplanID = BUD.BgFinanzplanID
      INNER JOIN FaLeistung   LEI ON LEI.FaLeistungID   = IsNull(FIP.FaLeistungID,KBU.FaLeistungID)
      LEFT  JOIN KbKonto      DEB ON DEB.KbPeriodeID    = KBU.KbPeriodeID AND ',' + DEB.KbKontoartCodes + ',' LIKE '%,20,%' /*Debitor*/
      LEFT  JOIN KbKonto      KRE ON KRE.KbPeriodeID    = KBU.KbPeriodeID AND ',' + KRE.KbKontoartCodes + ',' LIKE '%,30,%' /*Kreditor*/
      LEFT  JOIN KBBuchungStorno KBS ON KBS.KbBuchungID = KBU.KbBuchungID
  WHERE ({1} KBU.KbBuchungStatusCode IN (2,4,5,16) /*freigegeben,ausgedruckt,fehlerhaft,Rückläufer korrigiert*/ 
        AND (KBU.TransferDatum IS NULL OR KBU.KbBuchungStatusCode = 16 )) 
        AND (KBU.HabenKtoNr = KRE.KontoNr OR KBU.SollKtoNr = DEB.KontoNr) 
        AND (KBU.KbBuchungID IN({0}) {2})", inID, getAllStatus ? "1=1 OR" : "", getAllDependend ? " OR KBU.KbBuchungID IN (SELECT * FROM dbo.fnGetAllDependendNettoBelegIDs(" + idArray[0].ToString() + "))" : "");

            this.Adapter.Fill(dataTable);
            return dataTable;
        }
    }

    partial class BgFinanzPlanTableAdapter
    {
        public int GetFinanzPlanIDByBudgetID(int bgBudgetID)
        {
            SqlCommand cmd = this.Connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format(@"
                                SELECT BgFinanzPlanID
                                FROM BgBudget
                                WHERE BgBudgetID = {0}", bgBudgetID);
            ConnectionState previousConnectionState = cmd.Connection.State;
            if (((cmd.Connection.State & ConnectionState.Open)
                                 != ConnectionState.Open))
            {
                cmd.Connection.Open();
            }
            try
            {
                object id = cmd.ExecuteScalar();
                if (id is int)
                    return (int)id;
                throw new Exception(string.Format("Budget mit BgBudgetID = {0} hat keinen Fremdschlüssel BgFinanzPlanID", bgBudgetID));
            }
            finally
            {
                if ((previousConnectionState == ConnectionState.Closed))
                {
                    cmd.Connection.Close();
                }
            }
        }
    }

    partial class QueryAdapter
    {
        public int? GetOrgUnitIDFromStrasseCodeAndHausNr(int BaStrasseID, string HausNr)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[0];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return GetOrgUnitIDFromStrasseAndHausNrPrivate(BaStrasseID, HausNr) as int?;
        }
        public DateTime GetDateOfBudgetID(int bgbudgetID)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[2];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return (DateTime)GetDateOfBudget(bgbudgetID);
        }

        public long GetBelegNr(string belegart)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[1];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return (long)spKbGetBelegNr(belegart);
        }

        public long GetFirstKeyID(string belegart)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[9];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return (long)GetFirstID(belegart);
        }

        public string GetPSCDServerProxyURL()
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[7];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return GetPSCDServerProxy() as string;
        }

        public object GetLastZVMJobStartTime()
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[3];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return GetLastZVMJobStart();
        }

        public int UpdateLastZVMJobStartTime(DateTime? time)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[4];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return UpdateLastZVMJobStart(time);
        }

        public object GetLastZVMProcessJobStartTime()
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[5];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return GetLastZVMProcessJobStart();
        }

        public int UpdateLastZVMProcessJobStartTime(DateTime? time)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[6];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return UpdateLastZVMProcessJobStart(time);
        }

        public bool RemoveBelegNumber(long belegNr)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[8];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return RemoveBelegNr(belegNr) == 1;
        }

        public string GetKgKontoNrByKontoartPublic(int kgKontoartCode, int kbPeriodeID)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[10];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return (string)GetKgKontoNrByKontoart(kgKontoartCode, kbPeriodeID);
        }

        public string GetKbKontoNrByKontoartPublic(int kbKontoartCode, int kbPeriodeID)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[13];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return (string)GetKbKontoNrByKontoart(kbKontoartCode, kbPeriodeID);
        }

        public int? GetBaPersonIdFromZkbKontoNummer(string zkbKontoNummer)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[11];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return GetKlientFromZkbKontoNummer(zkbKontoNummer) as int?;
        }

        public string GetMucFromZKBAccountNr(string zkbKontoNummer)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[12];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return GetMuCFromZKB(zkbKontoNummer) as string;
        }

        public object ProcessAusgleichsinfo(long? ausgleichBelegNr, decimal ausgleichBetrag, DateTime? ausgleichDatum, int? ausgleichGrund, DateTime? einzahlungDatum, int? vgID, int? gpID, long opBelegNr, int? posImOP, string zahlstapel, int? posImZahlstapel, int? OPUOW, int? OPUPZ, string WVSTAT)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[14];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);

            // WVSTAT auf 1 Zeichen begrenzen
            if (!string.IsNullOrEmpty(WVSTAT))
                WVSTAT = WVSTAT.Substring(0, 1);
            return this.spPscdProcessAusgleichsinfo(ausgleichBelegNr, ausgleichBetrag, ausgleichDatum, ausgleichGrund, einzahlungDatum, vgID, gpID, opBelegNr, posImOP, zahlstapel, posImZahlstapel, OPUOW, OPUPZ, WVSTAT);
        }

        public object UpdateWvStatus(int? pscdWvStatusLogID, long opBelegNr, string WVSTAT, string FUBANAME,
                                              string TIMESTAMP, string MANDT, string OPUPK, string OPUPW, string OPUPZ)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[15];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return this.spPscdUpdateWvStatus(pscdWvStatusLogID, opBelegNr, WVSTAT, FUBANAME, TIMESTAMP, MANDT, OPUPK, OPUPW, OPUPZ);
        }

        public int? GetBudgetIDByKbBuchungBruttoID(int kbBuchungBruttoID)
        {
            SqlCommand cmd = (System.Data.SqlClient.SqlCommand)CommandCollection[16];
            cmd.Connection.ConnectionString = Scrambler.DecryptPasswordInConnectionString(cmd.Connection.ConnectionString);
            return GetBudgetIDOfBruttoBeleg(kbBuchungBruttoID) as int?;
        }
    }

    partial class KbWVEinzelpostenTableAdapter
    {
        public KiSSDB.KbWVEinzelpostenDataTable GetWVEinzelpostenByIDs(int[] idArray)
        {
            KiSSDB.KbWVEinzelpostenDataTable dataTable = new KiSSDB.KbWVEinzelpostenDataTable();
            if (idArray == null || idArray.Length == 0)
                return dataTable; // null object

            string inID = string.Join(", ", new List<int>(idArray).ConvertAll<string>(Convert.ToString).ToArray());

            this.Adapter.SelectCommand = CommandCollection[1];
            this.Adapter.SelectCommand.CommandText = string.Format(@"                                             
SELECT WVP.BEDCode, WVP.BeguenstigterBaPersonID, WVP.Betrag, WVP.BgSplittingArtCode, WVP.Buchungstext, WVP.DatumBis, WVP.DatumVon, WVP.Hauptvorgang, WVP.HeimatkantonNr, WVP.KbBuchungBruttoPersonID, WVP.KbWVEinzelpositionTS, WVP.KbWVEinzelpostenID, WVP.KbWVEinzelpostenStatusCode, WVP.KbWVLaufID, WVP.PscdBelegNr, WVP.PscdFehlermeldung, WVP.SKZNummer, WVP.SplittingDurchWVLaufDatumBis, WVP.StorniertKbWVEinzelpostenID, WVP.Teilvorgang, WVP.TransferDatum, WVP.Ungueltig, WVP.UnterstuetzungsanzeigeDocumentID, WVP.UnterstuetzungstraegerBaPersonID, WVP.WVCode, WVP.WhWVEinheitMitgliedID,
WVP.WohnHeimatKanton, WVEinheitID = WVE.WhWVEinheitID, Vertragsgegenstand = LEI.PscdVertragsgegenstandID, BelegNrBuchung = IsNull(STO.BelegNr,KBB.BelegNr), WVP.WVCodeVon, WVP.WVCodeBis, Ansprechperson = USR.LogonName, BgBudgetID = KBB.BgBudgetID, Heimatkanton = GEM.Kanton, PIM.PersonenImHaushalt, MGL.PersonenUnterstuetzt, Leistungsart = BKA.KontoNr, LeistungsartText = BKA.Name, KBP.PositionImBeleg, PRS.NationalitaetCode
,UntPersonenImHaushalt = (select count(*) from BgBudget BDG, BgFinanzplan_BaPerson FPP where BDG.BgBudgetID = KBB.BgBudgetID AND BDG.BgFinanzplanID = FPP.BgFinanzplanID AND FPP.IstUnterstuetzt = 1), KBB.Kostenstelle,
Storno = CASE WHEN StorniertKbWVEinzelpostenID IS NULL THEN 0 ELSE 1 END
FROM KbWVEinzelposten              WVP
  INNER JOIN WhWVEinheitMitglied   WVM ON WVM.WhWVEinheitMitgliedID   = WVP.WhWVEinheitMitgliedID
  INNER JOIN WhWVEinheit           WVE ON WVE.WhWVEinheitID           = WVM.WhWVEinheitID
  INNER JOIN KbBuchungBruttoPerson KBP ON KBP.KbBuchungBruttoPersonID = WVP.KbBuchungBruttoPersonID
  INNER JOIN KbBuchungBrutto       KBB ON KBB.KbBuchungBruttoID       = KBP.KbBuchungBruttoID
  INNER JOIN BgKostenart           BKA ON BKA.BgKostenartID           = KBB.BgKostenartID
  INNER JOIN FaLeistung            LEI ON LEI.FaLeistungID            = KBB.FaLeistungID
  INNER JOIN vwUser                USR ON USR.UserID                  = LEI.UserID
  INNER JOIN BaPerson              PRS ON PRS.BaPErsonID              = WVP.BeguenstigterBaPersonID
  LEFT  JOIN BaGemeinde            GEM ON GEM.BaGemeindeID            = PRS.HeimatgemeindeCode
  LEFT  JOIN BgBudget              BUD ON BUD.BgBudgetID              = KBB.BgBudgetID
  LEFT  JOIN (SELECT BgFinanzplanID, PersonenImHaushalt = Count(*)
              FROM BgFinanzplan_BaPerson
              GROUP BY BgFinanzplanID) PIM ON PIM.BgFinanzplanID = BUD.BgFinanzplanID
  LEFT  JOIN (SELECT WhWVEinheitID, PersonenUnterstuetzt = Count(*)
              FROM WhWVEinheitMitglied
              GROUP BY WhWVEinheitID) MGL ON MGL.WhWVEinheitID = WVM.WhWVEinheitID
  LEFT JOIN KbBuchungBrutto STO ON WVP.StorniertKbWvEinzelpostenID IS NOT NULL AND STO.KbBuchungBruttoID = (SELECT TOP 1 KbBuchungBruttoID
                                                                                                            FROM KbBuchungBrutto
                                                                                                            WHERE StorniertKbBuchungBruttoID = KBB.KbBuchungBruttoID)
WHERE KbWVEinzelpostenID IN ({0})
  AND WVP.KbWVEinzelpostenStatusCode = 1 /*Lieferbar*/
  AND WVP.TransferDatum IS NULL

UNION ALL

-- migrierte Posten
SELECT WVP.BEDCode, WVP.BeguenstigterBaPersonID, WVP.Betrag, WVP.BgSplittingArtCode, WVP.Buchungstext, WVP.DatumBis, WVP.DatumVon, WVP.Hauptvorgang, WVP.HeimatkantonNr, WVP.KbBuchungBruttoPersonID, WVP.KbWVEinzelpositionTS, WVP.KbWVEinzelpostenID, WVP.KbWVEinzelpostenStatusCode, WVP.KbWVLaufID, WVP.PscdBelegNr, WVP.PscdFehlermeldung, WVP.SKZNummer, WVP.SplittingDurchWVLaufDatumBis, WVP.StorniertKbWVEinzelpostenID, WVP.Teilvorgang, WVP.TransferDatum, WVP.Ungueltig, WVP.UnterstuetzungsanzeigeDocumentID, WVP.UnterstuetzungstraegerBaPersonID, WVP.WVCode, WVP.WhWVEinheitMitgliedID,
WVP.WohnHeimatKanton, WVEinheitID = NULL, Vertragsgegenstand = NULL, BelegNrBuchung = WEP.BelegNrProleist, WVCodeVon = WVC.DatumVon, WVCodeBis = WVC.DatumBis, Ansprechperson = NULL, BgBudgetID = NULL, Heimatkanton = GEM.Kanton, PersonenImHaushalt = NULL, PersonenUnterstuetzt = NULL,
Leistungsart = CASE LANrProleist
WHEN 1    THEN 991
WHEN 11   THEN 992
WHEN 110  THEN 110
WHEN 001 THEN 991
WHEN 011 THEN 992
WHEN 110 THEN 110
WHEN 115 THEN 110
WHEN 120 THEN 121
WHEN 130 THEN 119
WHEN 210 THEN 130
WHEN 220 THEN 131
WHEN 230 THEN 315
WHEN 240 THEN 311
WHEN 280 THEN 321
WHEN 310 THEN 141
WHEN 311 THEN 143
WHEN 315 THEN 128
WHEN 320 THEN 140
WHEN 321 THEN 210
WHEN 322 THEN 170
WHEN 330 THEN 160
WHEN 340 THEN 213
WHEN 410 THEN 330
WHEN 411 THEN 230
WHEN 412 THEN 240
WHEN 413 THEN 341
WHEN 414 THEN 261
WHEN 415 THEN 242
WHEN 416 THEN 310
WHEN 419 THEN 216
WHEN 420 THEN 215
WHEN 431 THEN 370
WHEN 435 THEN 390
WHEN 437 THEN 370
WHEN 438 THEN 380
WHEN 510 THEN 510
WHEN 515 THEN 512
WHEN 520 THEN 120
WHEN 530 THEN 125
WHEN 620 THEN 430
WHEN 661 THEN 320
WHEN 710 THEN 361
WHEN 730 THEN 360
WHEN 811 THEN 720
WHEN 812 THEN 721
WHEN 813 THEN 723
WHEN 814 THEN 724
WHEN 815 THEN 740
WHEN 816 THEN 725
WHEN 818 THEN 798
WHEN 820 THEN 722
WHEN 821 THEN 730
WHEN 822 THEN 731
WHEN 823 THEN 732
WHEN 824 THEN 741
WHEN 825 THEN 735
WHEN 826 THEN 733
WHEN 827 THEN 734
WHEN 828 THEN 742
WHEN 831 THEN 710
WHEN 832 THEN 711
WHEN 833 THEN 743
WHEN 841 THEN 736
WHEN 851 THEN 750
WHEN 852 THEN 751
WHEN 861 THEN 754
WHEN 862 THEN 755
WHEN 864 THEN 756
WHEN 871 THEN 989
WHEN 872 THEN 780
WHEN 881 THEN 760
WHEN 882 THEN 822
WHEN 883 THEN 762
WHEN 884 THEN 761
WHEN 892 THEN 763
WHEN 911 THEN 820
WHEN 912 THEN 821
WHEN 913 THEN 810
WHEN 920 THEN 850
WHEN 921 THEN 830
WHEN 922 THEN 831
WHEN 931 THEN 880
WHEN 951 THEN 870
WHEN 952 THEN 872
WHEN 953 THEN 874
WHEN 954 THEN 876
WHEN 980 THEN 852
WHEN 981 THEN 861
WHEN 982 THEN 860
WHEN 983 THEN 862
WHEN 991 THEN 990
END,
LeistungsartText = LATextProleist, PositionImBeleg = NULL, PRS.NationalitaetCode, NULL, NULL,
Storno = CASE WHEN StorniertKbWVEinzelpostenID IS NULL THEN 0 ELSE 1 END
FROM KbWVEinzelposten              WVP
  INNER JOIN MigWVEinzelposten     WEP ON WEP.KbWVEinzelpostenID      = WVP.KbWVEinzelpostenID
  INNER JOIN BaPerson              PRS ON PRS.BaPersonID              = WVP.BeguenstigterBaPersonID
  LEFT  JOIN BaGemeinde            GEM ON GEM.BaGemeindeID            = PRS.HeimatgemeindeCode
  INNER JOIN BaWVCode              WVC ON WVC.BaWVCodeID = (SELECT TOP 1 BaWVCodeID 
                                                            FROM BaWVCode                       WVCI
                                                              INNER JOIN XLOVCode               LOVI  ON LOVI.LOVName = 'BaWVCode' AND LOVI.Code = WVCI.WVCode
                                                              INNER JOIN BaWVCodeLOVEx          LOVXI ON LOVXI.BaWVCodeLOVExID = LOVI.Code	
                                                            WHERE WVCI.BaWVStatusCode = 1 AND WVCI.BaPersonID = WEP.BaPersonID  AND (WEP.VonDatum BETWEEN WVCI.DatumVon AND IsNull(WVCI.DatumBis,'9999-12-31') OR WEP.BisDatum BETWEEN WVCI.DatumVon AND IsNull(WVCI.DatumBis,'9999-12-31'))
                                                            ORDER BY DATEDIFF(d,CASE WHEN WVCI.DatumVon > WEP.VonDatum THEN WVCI.DatumVon ELSE WEP.VonDatum END,CASE WHEN WVCI.DatumBis < WEP.BisDatum THEN WVCI.DatumBis ELSE WEP.BisDatum END) DESC, CASE WHEN LOVXI.Hauptvorgang IS NULL THEN 2 ELSE 1 END) -- falls sich codes überschneiden, den nehmen, der weiterverrechenbar ist
WHERE WVP.KbWVEinzelpostenID IN ({0})
  AND WVP.KbWVEinzelpostenStatusCode = 1 /*Lieferbar*/
  AND WVP.TransferDatum IS NULL
  AND WVP.KbBuchungBruttoPersonID IS NULL
ORDER BY Storno ASC
", inID);

            this.Adapter.Fill(dataTable);
            return dataTable;
        }
    }

    partial class XDocumentTableAdapter
    {
        public virtual KiSSDB.XDocumentDataTable GetDocument(int documentID)
        {
            this.Adapter.SelectCommand = CommandCollection[0];
            this.Adapter.SelectCommand.CommandText = string.Format(@"
                   SELECT * FROM XDocument WHERE DocumentID = {0}", documentID);
            //Log.Info(this.GetType(), this.Adapter.SelectCommand.CommandText);
            KiSSDB.XDocumentDataTable dataTable = new KiSSDB.XDocumentDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
    }

    partial class SstIKAuszugTableAdapter
    {
    }

}
