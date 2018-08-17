using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KiSS4.DB;

namespace KiSS4.Klientenbuchhaltung.ZH
{
    public class BelegeKorrigierenTemporaryTableHelper
    {
        public static void InitTemporaryKbBuchungBruttoPersonTable()
        {
            DBUtil.ExecSQL(@"
	                IF OBJECT_ID('tempdb..#TempKbBuchungBruttoPerson') IS NULL 
	                BEGIN
		                CREATE TABLE #TempKbBuchungBruttoPerson
		                (
                            KbBuchungBruttoPersonID int IDENTITY(1,1) NOT NULL,
			                KbBuchungBruttoID int NOT NULL,
			                Person varchar(100) NULL,
                            BaPersonID int NOT NULL,
                            Schuldner_BaInstitutionID int NULL DEFAULT (NULL),
                            Schuldner_BaPersonID int NULL DEFAULT (NULL),
			                Buchungstext varchar(200) NULL,
			                Betrag money NOT NULL,
			                VerwPeriodeVon datetime NULL,
			                VerwPeriodeBis datetime NULL,
                            SpezBgKostenartID int NULL DEFAULT (NULL),
                            SpezHauptvorgang int NULL DEFAULT (NULL),
                            SpezTeilvorgang int NULL DEFAULT (NULL),
                            GesperrtFuerWV bit DEFAULT (0),
                            Zinsperiode int NULL DEFAULT (NULL)
		                )
	                END

                    DELETE FROM #TempKbBuchungBruttoPerson   -- Entferne alle Einträge, falls die Tabelle schon vorhanden war
                    ");
        }

        public static int LoadDetailsIntoTemporaryKbBuchungBruttoPersonTable(int kbBuchungBruttoID)
        {
            RemoveDetailsFromTemporaryKbBuchungBruttoPersonTable(kbBuchungBruttoID);

            return DBUtil.ExecSQL(@"
                    INSERT INTO #TempKbBuchungBruttoPerson
                        SELECT KbBuchungBruttoID,
                                PER.Name + IsNull(', ' + PER.Vorname, '') + ' (' + 
                                   ISNULL(CONVERT(varchar,dbo.fnGetAgeMortal(PER.Geburtsdatum, GetDate(),PER.Sterbedatum)),'-') + ',' +
                                   ISNULL(PER.GeschlechtKurz,'?') + ')',
			                    KBP.BaPersonID,
                                Schuldner_BaInstitutionID,
                                Schuldner_BaPersonID,
			                    Buchungstext,
			                    Betrag,
			                    VerwPeriodeVon,
			                    VerwPeriodeBis,
                                SpezBgKostenartID,
                                SpezHauptvorgang,
                                SpezTeilvorgang,
                                GesperrtFuerWV,
                                Zinsperiode
                        FROM KbBuchungBruttoPerson KBP
                        INNER JOIN vwPerson PER ON PER.BaPersonID = KBP.BaPersonID

                        WHERE KbBuchungBruttoID = {0}", kbBuchungBruttoID);
        }

       public static void RemoveDetailsFromTemporaryKbBuchungBruttoPersonTable(int kbBuchungBruttoID)
       {
            DBUtil.ExecSQL(@"
                    DELETE FROM #TempKbBuchungBruttoPerson
                        WHERE KbBuchungBruttoID = {0}", kbBuchungBruttoID);  
       }

       public static void AddDetailToTemporaryKbBuchungBruttoPersonTable(int KbBuchungBruttoID, string Person, int BaPersonID, object Schuldner_BaInstitutionID, object Schuldner_BaPersonID, string Buchungstext, decimal Betrag, DateTime VerwPeriodeVon, DateTime VerwPeriodeBis, object SpezBgKostenartID, object SpezHauptvorgang, object SpezTeilvorgang, bool GesperrtFuerWV, object Zinsperiode)
       {
            DBUtil.ExecSQL(@"
                    INSERT INTO #TempKbBuchungBruttoPerson
                        SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}", 
                                KbBuchungBruttoID, Person, BaPersonID, 
                                Schuldner_BaInstitutionID, Schuldner_BaPersonID, 
                                Buchungstext, Betrag, 
                                VerwPeriodeVon, VerwPeriodeBis, 
                                SpezBgKostenartID, SpezHauptvorgang, SpezTeilvorgang, 
                                GesperrtFuerWV, Zinsperiode);
       }

       public static void AddDetailToTemporaryKbBuchungBruttoPersonTable(int KbBuchungBruttoID, string Person, int BaPersonID, string Buchungstext, decimal Betrag, DateTime VerwPeriodeVon, DateTime VerwPeriodeBis)
       {
           DBUtil.ExecSQL(@"
                    INSERT INTO #TempKbBuchungBruttoPerson
                        SELECT {0}, {1}, {2}, NULL, NULL, {3}, {4}, {5}, {6}, NULL, NULL, NULL, 0, NULL", KbBuchungBruttoID, Person, BaPersonID, Buchungstext, Betrag, VerwPeriodeVon, VerwPeriodeBis);
       }

       public static void UpdateBuchungstextOfTemporaryKbBuchungBruttoPersonTable(int KbBuchungBruttoID, string Buchungstext)
       {
           DBUtil.ExecSQL(@"
                    UPDATE #TempKbBuchungBruttoPerson 
                        SET Buchungstext = {1}
                    WHERE KbBuchungBruttoID = {0}", KbBuchungBruttoID, Buchungstext);
       }

       public static void UpdateVerwPeriodeOfTemporaryKbBuchungBruttoPersonTable(int KbBuchungBruttoID, DateTime verwPerVon, DateTime verwPerBis)
       {
           DBUtil.ExecSQL(@"
                    UPDATE #TempKbBuchungBruttoPerson 
                        SET VerwPeriodeVon = {1}, VerwPeriodeBis = {2}
                    WHERE KbBuchungBruttoID = {0}", KbBuchungBruttoID, verwPerVon, verwPerBis);
       }
    }
}
