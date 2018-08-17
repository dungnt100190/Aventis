SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgGetBudget
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKgGetBudget.sql $
  $Author: Mmarghitola $
  $Modtime: 19.08.10 18:00 $
  $Revision: 13 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKgGetBudget.sql $
 * 
 * 13    20.08.10 10:37 Mmarghitola
 * #6492: Korrektur Anzeige Kontoname
 * 
 * 12    17.08.10 13:25 Mmarghitola
 * #6492: SQL umschreiben
 * 
 * 10    12.08.10 15:25 Mmarghitola
 * #6331: Concurrency Violations verhindern
 * 
 * 9     11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 8     2.08.09 14:00 Mweber
 * 
 * 9     19.07.09 19:07 Mweber
 * KgBewilligungCode ausblenden in grauem Masterbudget 
 * 
 * 8     14.07.09 9:47 Mweber
 * #4712 neuer Parameter @inklVergangeneLeistungen
 * 
 * 6     28.06.09 18:56 Rstahel
 * #4712: Diverse Anpassungen Stored Procedures
 * 
 * 5     12.05.09 12:07 Mweber
 * 
 * 4     12.05.09 12:03 Mweber
 * 
 * 1     16.09.08 16:50 Mminder
 * 
 * 1     9.09.08 14:59 Aklopfenstein
 *
 * 2     12.5.09 MWeber
 *       neue Spalte KgPeriodeStatusCode im Result Set
 *
 * VSS FIRST
=================================================================================================*/

CREATE PROCEDURE [dbo].[spKgGetBudget]
(
  @KgBudgetID int,
  @inklVergangeneLeistungen bit = 1
)
AS BEGIN


DECLARE @KgPosition table (
       KgPositionID             int,
       KgBudgetID               int,
       KgPositionsKategorieCode int,
       MasterbudgetPositionID   int,
       KontoNr                  varchar(10),
       Buchungstext             varchar(100),
       Betrag                   money,
       EffektivText             varchar(200),
       EffektivBetrag           money,
       Bemerkung                text,
       BuchungDatum             datetime,
       ValutaDatum              datetime,
       ValutaTermine            varchar(1000),
       BaInstitutionID          int,
       KgAuszahlungsArtCode     int,
       KgAuszahlungsTerminCode  int,
       KgWochentagCodes         varchar(200),
       BaZahlungswegID          int,
       MitteilungZeile1         varchar(35),
       MitteilungZeile2         varchar(35),
       MitteilungZeile3         varchar(35),
       MitteilungZeile4         varchar(35),
       ReferenzNummer           varchar(50),
       EinzahlungsscheinCode    int,
       ErstelltUserID           int,
       ErstelltDatum            datetime,
       MutiertUserID            int,
       MutiertDatum             datetime,
       Gruppe                   int,
       KategorieCode            int,
       Text                     varchar(100),
       Total                    money,
       Doc                      int,
       Konto                    varchar(111),
       Kreditor                 varchar(200),
       Debitor                  varchar(150),
       ZusatzInfo               varchar(500),
       Info                     varchar(200),
       Status                   int,
       StatusMin                int,
       AnzahlBelege             int,
       M                        varchar(1),
       PscdFehlermeldung        varchar(200),
       KgPeriodeStatusCode      int,
       DatumVon					        datetime,
       DatumBis					        datetime,
       KgBewilligungCode    	  int,
       KgPositionTS             Binary(8)
)

INSERT INTO @KgPosition (
       KgPositionID,KgBudgetID,KgPositionsKategorieCode,MasterbudgetPositionID,
       KontoNr,Buchungstext,Betrag,Bemerkung,
       BuchungDatum,BaInstitutionID,KgAuszahlungsArtCode,KgAuszahlungsTerminCode,KgWochentagCodes,
       BaZahlungswegID,MitteilungZeile1,MitteilungZeile2,MitteilungZeile3,MitteilungZeile4,
       ReferenzNummer,EinzahlungsscheinCode,
       ErstelltUserID,ErstelltDatum,MutiertUserID,MutiertDatum,
       ValutaDatum,ValutaTermine,
       Gruppe,KategorieCode,Text,Total,Doc,Konto,Debitor,Kreditor,ZusatzInfo,
       EffektivText,EffektivBetrag,Info,Status,StatusMin,AnzahlBelege,M,PscdFehlermeldung,KgPeriodeStatusCode, DatumVon, DatumBis, KgBewilligungCode, KgPositionTS)

SELECT POS.KgPositionID,POS.KgBudgetID,POS.KgPositionsKategorieCode,POS.MasterbudgetPositionID,
       POS.KontoNr,POS.Buchungstext,POS.Betrag,POS.Bemerkung,
       POS.BuchungDatum,POS.BaInstitutionID,POS.KgAuszahlungsArtCode,POS.KgAuszahlungsTerminCode,POS.KgWochentagCodes,
       POS.BaZahlungswegID,POS.MitteilungZeile1,POS.MitteilungZeile2,POS.MitteilungZeile3,POS.MitteilungZeile4,
       POS.ReferenzNummer,KRE.EinzahlungsscheinCode,
       POS.ErstelltUserID,POS.ErstelltDatum,POS.MutiertUserID,POS.MutiertDatum,
       ValutaDatum   = CASE WHEN POS.KgAuszahlungsTerminCode = 4 THEN VAL.Datum END,
       ValutaTermine = dbo.fnKgGetValutaTermine(POS.KgPositionID),
       Gruppe        = 0,
       KategorieCode = POS.KgPositionsKategorieCode,
       Text          = POS.Buchungstext,
       Total         = CONVERT(money,NULL),
       Doc           = (SELECT CASE WHEN COUNT(*) > 0 THEN count(*) END FROM KgDokument WHERE KgPositionID = POS.KgPositionID),
       -- Get Konto through Buchung (if it exists), else through Position
       Konto         = ISNULL(
                        (SELECT TOP 1 KontoNr + ' ' + KontoName
                        FROM dbo.KgKonto KON WITH (READUNCOMMITTED)
                        WHERE KON.KgPeriodeID = BUC.KgPeriodeID AND KON.KontoNR = POS.KontoNR),
                        (SELECT TOP 1 KontoNr + ' ' + KontoName
                        FROM dbo.KgPeriode PER WITH (READUNCOMMITTED) 
                        INNER JOIN dbo.KgKonto KON WITH (READUNCOMMITTED) ON
                          KON.KgPeriodeID = PER.KgPeriodeID AND KON.KontoNr = POS.KontoNr
                       WHERE PER.FaLeistungID = BDG.FaLeistungID AND
                        POS.BuchungDatum BETWEEN PER.PeriodeVon AND PER.PeriodeBis
                      )),
       Debitor       = DEB.Name,
       Kreditor      = KRE.Kreditor,
       ZusatzInfo    = CASE POS.KgPositionsKategorieCode
                       WHEN 1 THEN KRE.ZusatzInfo
                       WHEN 2 THEN KRE.ZusatzInfo
                       WHEN 3 THEN DEB.AdresseMehrzeilig
                       END,
       EffektivText  = (SELECT 'effektiv ' + CONVERT(varchar(20),SUM(AUS.Betrag),1) + ' (' + CONVERT(varchar, MAX(BUC2.ValutaDatum), 104) + ')'
                        FROM   dbo.KgBuchung BUC WITH(READUNCOMMITTED)
                               INNER JOIN dbo.KgOpAusgleich AUS  WITH(READUNCOMMITTED) on AUS.OpBuchungID  = BUC.KgBuchungID
                               INNER JOIN dbo.KgBuchung     BUC2 WITH(READUNCOMMITTED) on BUC2.KgBuchungID = AUS.AusgleichBuchungID
                        WHERE  BUC.KgPositionID = POS.KgPositionID),
       EffektivBetrag = (SELECT SUM(AUS.Betrag)
                        FROM   dbo.KgBuchung BUC WITH(READUNCOMMITTED)
                               INNER JOIN dbo.KgOpAusgleich AUS  WITH(READUNCOMMITTED) on AUS.OpBuchungID = BUC.KgBuchungID
                               INNER JOIN dbo.KgBuchung     BUC2 WITH(READUNCOMMITTED) on BUC2.KgBuchungID = AUS.AusgleichBuchungID
                        WHERE  BUC.KgPositionID = POS.KgPositionID),
       Info          = CASE POS.KgPositionsKategorieCode
                       WHEN 1 THEN AZA.ShortText +
                                   CASE WHEN POS.KgAuszahlungsTerminCode = 6
                                   THEN ' (' + dbo.fnLOVTextListe('KgWochentag',POS.KgWochentagCodes) + ')'
                                   ELSE ', ' + AZT.Text
                                   END
                       WHEN 2 THEN IsNull(CONVERT(varchar,VAL.Datum,104),'') + ISNULL(', ' + KRE.InstitutionName,'')
                       WHEN 3 THEN IsNull(CONVERT(varchar,VAL.Datum,104),'') + ISNULL(', ' + DEB.Name,'')
                       END,
       Status        = CASE WHEN BDG.KgMasterBudgetID IS NOT NULL THEN ISNULL(STAMAX.KgBuchungStatusCode,1) END,
       StatusMin     = CASE WHEN BDG.KgMasterBudgetID IS NOT NULL AND STAMAX.KgBuchungStatusCode <> STAMIN.KgBuchungStatusCode
                       THEN STAMIN.KgBuchungStatusCode
                       END,
       AnzahlBelege  = CASE WHEN POS.KgPositionsKategorieCode = 1
                       THEN (SELECT CASE WHEN COUNT(*) = 0 THEN NULL ELSE COUNT(*) END FROM KgBuchung WHERE KgPositionID = POS.KgPositionID)
                       END,
       M             = CASE WHEN POS.MasterbudgetPositionID IS NOT NULL THEN 'M' END,
       PscdFehlermeldung = BUC.PscdFehlermeldung,
       KgPeriodeStatusCode = PER.KgPeriodeStatusCode,
       POS.DatumVon,
       POS.DatumBis,
       KgBewilligungCode = CASE WHEN BDG.KgMasterBudgetID IS NULL AND BDG.KgBewilligungCode >= 5 THEN POS.KgBewilligungCode END,
       KgPositionTS
FROM   dbo.KgPosition POS
       INNER JOIN dbo.KgBudget      BDG WITH(READUNCOMMITTED) on BDG.KgBudgetID = POS.KgBudgetID
       LEFT  JOIN dbo.XLOVCode      AZA WITH(READUNCOMMITTED) on AZA.LOVName = 'KgAuszahlungsart' AND AZA.Code = POS.KgAuszahlungsArtCode
       LEFT  JOIN dbo.XLOVCode      AZT WITH(READUNCOMMITTED) on AZT.LOVName = 'KgAuszahlungsTermin' AND AZT.Code = POS.KgAuszahlungsTerminCode
       LEFT  JOIN dbo.vwKreditor    KRE WITH(READUNCOMMITTED) on KRE.BaZahlungswegID = POS.BaZahlungswegID
       LEFT  JOIN dbo.vwInstitution DEB WITH(READUNCOMMITTED) on DEB.BaInstitutionID = POS.BaInstitutionID
       OUTER APPLY
       (
         SELECT KgPeriodeID = MAX(KgPeriodeID), PSCDFehlermeldung = MAX(PSCDFehlermeldung)
         FROM   dbo.KgBuchung B WITH(READUNCOMMITTED)
         WHERE  KgPositionID = POS.KgPositionID
      ) BUC
      OUTER APPLY
      (
         SELECT TOP 1 KgBuchungStatusCode = S.Code
         FROM dbo.XLOVCode S WITH(READUNCOMMITTED)
         WHERE S.LOVName = 'KgBuchungsStatus' AND S.Code IN
          (SELECT DISTINCT KgBuchungStatusCode FROM dbo.KgBuchung BUC WHERE BUC.KgPositionID = POS.KgPositionID)
         ORDER BY S.SortKey DESC
      ) STAMAX
      OUTER APPLY
      (
         SELECT TOP 1 KgBuchungStatusCode = S.Code
         FROM dbo.XLOVCode S WITH(READUNCOMMITTED)
         WHERE S.LOVName = 'KgBuchungsStatus' AND S.Code IN
          (SELECT DISTINCT KgBuchungStatusCode FROM dbo.KgBuchung BUC WHERE BUC.KgPositionID = POS.KgPositionID)
         ORDER BY S.SortKey ASC
      ) STAMIN
       LEFT  JOIN dbo.KgPeriode        PER WITH(READUNCOMMITTED) on PER.KgPeriodeID = BUC.KgPeriodeID
       OUTER APPLY
       (
        SELECT Datum = MIN(Datum)
        FROM   dbo.KgPositionValuta WITH(READUNCOMMITTED)
			  WHERE  KgPositionID = POS.KgPositionID
        ) VAL
WHERE  POS.KgBudgetID = @KgBudgetID AND
       (@inklVergangeneLeistungen = 1 OR ISNULL(POS.DatumBis,GETDATE()) >= GETDATE())  -- vergangene Leistung: BisDatum in der Vergangenheit

INSERT @KgPosition (KategorieCode, Text, Gruppe, Total)
SELECT KAT.Code,KAT.Text, 1, SUM(CASE WHEN KategorieCode in (1,2) THEN ISNULL(-Betrag,0) ELSE ISNULL(Betrag,0) END)
FROM   XLOVCode KAT
       LEFT JOIN @KgPosition TMP on TMP.KgPositionsKategorieCode = KAT.Code
WHERE  KAT.LOVName = 'KgPositionsKategorie'
GROUP BY KAT.Code,KAT.Text

INSERT @KgPosition (KategorieCode, Text, Gruppe, Total)
SELECT 99,'Budgetsaldo', 1, SUM(CASE WHEN KategorieCode in (1,2) THEN IsNull(-Betrag,0) ELSE IsNull(Betrag,0) END)
FROM   @KgPosition
WHERE  Gruppe = 0

SELECT
  KgPositionID,
  KgBudgetID,
  KgPositionsKategorieCode,
  MasterbudgetPositionID,
  KontoNr,
  Buchungstext,
  Betrag,
  EffektivText,
  EffektivBetrag,
  Bemerkung,
  BuchungDatum,
  ValutaDatum,
  ValutaTermine,
  BaInstitutionID,
  KgAuszahlungsArtCode,
  KgAuszahlungsTerminCode,
  KgWochentagCodes,
  BaZahlungswegID,
  MitteilungZeile1,
  MitteilungZeile2,
  MitteilungZeile3,
  MitteilungZeile4,
  ReferenzNummer,
  EinzahlungsscheinCode,
  ErstelltUserID,
  ErstelltDatum,
  MutiertUserID,
  MutiertDatum,
  Gruppe,
  KategorieCode,
  Text,
  Total,
  Doc,
  Konto,
  Kreditor,
  Debitor,
  ZusatzInfo,
  Info,
  Status,
  StatusMin,
  AnzahlBelege,
  M,
  PscdFehlermeldung,
  KgPeriodeStatusCode,
  DatumVon,
  DatumBis,
  KgBewilligungCode,
  KgPositionTS = CONVERT(timestamp, KgPositionTS)
FROM @KgPosition
ORDER BY KategorieCode, Gruppe DESC, CONVERT(int,IsNull(KontoNr,0))
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
