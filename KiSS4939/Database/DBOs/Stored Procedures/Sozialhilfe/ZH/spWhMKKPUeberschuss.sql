SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhMKKPUeberschuss
GO

/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Wird von Abfrage Wirtschaftliche Hilfe / MKKP / MKKP Überschuss verwendet
	  @DatumVon: 
    @DatumBis: 
    @OrgGruppeID: 
    @TeamID: 
    @UserID: 
    @BaPersonID: 
    @FaFallID: 
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spWhMKKPUeberschuss
(
	@DatumVon datetime,
  @DatumBis datetime,
  @OrgGruppeID int,
  @TeamID int,
  @UserID int,
  @BaPersonID int,
  @FaFallID int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

IF OBJECT_ID('tempdb..#Suchparameter') IS NOT NULL BEGIN
  DROP TABLE #Suchparameter
END
IF OBJECT_ID('tempdb..#Kandidaten') IS NOT NULL BEGIN
  DROP TABLE #Kandidaten
END

IF OBJECT_ID('tempdb..#MKKPResult') IS NOT NULL BEGIN
  DROP TABLE #MKKPResult
END

SELECT @DatumVon = ISNULL(@DatumVon, '17530101'), @DatumBis = ISNULL(@DatumBis, '30000101')

DECLARE @LAList table
(
  KontoNr varchar(6)
)
INSERT INTO @LAList SELECT SplitValue FROM dbo.fnSplitStringToValues(
  '740,741,742,743,' +             -- AZL
  '751,752,753,' +                 -- KK-Rückerstattungen
  '798,' +                         -- RZ Überschuss an KL
  '814,817,' +                     -- (Rückerstattung gem. Schulgesetz, alte UB-Saldi aus Reso
  '830,831,' +                     -- Verwandtenunterstuetzung
  '860,861,862,' +                 -- RE anteilscheine, RE Mietzinsdepot
  '863,864,' +                     -- RE Doppelzahlungen
  '870,871,872,873,' +             -- div. Rückerstattungen
  '876,877,880,881,890,891,892,' + -- div. Rückerstattungen
  '989,990,991,992', ',', 1        -- div. Weitervverrechnungs-Leistungsarten
)

BEGIN TRY

--finde person und zeitraum, am schluss kontoauszug
CREATE TABLE #Suchparameter
(
  BaPersonID int,
  FallBaPersonID int,
  DatumVon datetime -- datum erster Einnahme
  PRIMARY KEY (BaPersonID, FallBaPersonID)
)

INSERT INTO #Suchparameter
SELECT
  BaPersonID = FAP.BaPersonID,
  FallBaPersonID = TMP.FallBaPersonID,
  DatumVon = dateadd(day, -day(MIN(BVP.VerwPeriodeVon)) + 1, MIN(BVP.VerwPeriodeVon)) -- erster Tag vom Monat des ersten Datums
FROM
(
  SELECT DISTINCT
    FallBaPersonID = FAL.BaPersonID
  FROM dbo.FaFall FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.vwUser					USR WITH (READUNCOMMITTED) ON USR.UserID = FAL.UserID
    INNER JOIN dbo.FaFallPerson   FAP WITH (READUNCOMMITTED) ON FAP.FaFallID = FAL.FaFallID
    INNER JOIN dbo.FaLeistung     LEI WITH (READUNCOMMITTED) ON LEI.FaFallID = FAL.FaFallID
        AND (LEI.DatumVon BETWEEN @DatumVon AND @DatumBis
          OR LEI.DatumVon < @DatumVon AND (LEI.DatumBis IS NULL OR LEI.DatumBis > @DatumBis)
          OR LEI.DatumBis BETWEEN @DatumVon AND @DatumBis)
  WHERE
    (@FaFallID IS NULL OR FAL.FaFallID = @FaFallID)
    AND (FAL.DatumVon BETWEEN @DatumVon AND @DatumBis
      OR FAL.DatumVon < @DatumVon AND (FAL.DatumBis IS NULL OR FAL.DatumBis > @DatumBis)
      OR FAL.DatumBis BETWEEN @DatumVon AND @DatumBis)
    AND (@UserID IS NULL OR @UserID = FAL.UserID)
    AND (@BaPersonID IS NULL OR @BaPersonID = FAP.BaPersonID)
    AND ((@OrgGruppeID IS NULL AND @TeamID IS NULL) OR USR.OrgUnitID IN (SELECT OrgUnitID FROM dbo.fnOrgUnitsOfTeam(@OrgGruppeID,@TeamID)))
) TMP
  CROSS APPLY
  (-- Einnahmen pro Fall
    SELECT VerwPeriodeVon = Convert(datetime, dbo.fnMax(@DatumVon, MIN(EA.VerwPeriodeVon)))
    FROM
    (
      SELECT VerwPeriodeVon = MIN(KBP_I.VerwPeriodeVon)
      FROM dbo.FaFall FAL_I -- KiSS
        INNER JOIN dbo.FaLeistung             LEI_I WITH (READUNCOMMITTED) ON FAL_I.FaFallID = LEI_I.FaFallID
          AND (LEI_I.DatumVon BETWEEN @DatumVon AND @DatumBis OR @DatumVon BETWEEN LEI_I.DatumVon AND LEI_I.DatumBis)
        INNER JOIN dbo.KbBuchungBrutto        KBB_I WITH (READUNCOMMITTED) ON LEI_I.FaLeistungID = KBB_I.FaLeistungID
        INNER JOIN dbo.KbBuchungBruttoPerson  KBP_I WITH (READUNCOMMITTED) ON KBP_I.KbBuchungBruttoID = KBB_I.KbBuchungBruttoID
        LEFT JOIN dbo.KbBuchungKostenart      KBA_I WITH (READUNCOMMITTED) ON KBA_I.BgPositionID = KBP_I.BgPositionID
        LEFT JOIN dbo.KbBuchung               BUC_I WITH (READUNCOMMITTED) ON BUC_I.KbBuchungID = KBA_I.KbBuchungID
      WHERE
        FAL_I.BaPersonID = TMP.FallBaPersonID
         AND LEI_I.ModulID = 3
        AND KBP_I.Betrag > 0
        AND (KBP_I.VerwPeriodeVon BETWEEN @DatumVon AND @DatumBis OR @DatumVon BETWEEN KBP_I.VerwPeriodeVon AND KBP_I.VerwPeriodeBis)
        AND KBB_I.KbBuchungStatusCode IN (3 ,6, 10)-- Zahlauftrag erstellt, ausgeglichen, teilausgeglichen
        AND (KBA_I.BgPositionID IS NULL OR BUC_I.KbBuchungStatusCode IN (6, 10))
      UNION 
      SELECT VerwPeriodeVon = MIN(MIG_I.VerwendungVon) -- ProLeist
      FROM dbo.FaFall FAL_II
        INNER JOIN dbo.FaLeistung             LEI_II WITH (READUNCOMMITTED) ON FAL_II.FaFallID = LEI_II.FaFallID
        INNER JOIN dbo.MigDetailBuchung       MIG_I WITH (READUNCOMMITTED) ON MIG_I.FaLeistungID = LEI_II.FaLeistungID
          AND (MIG_I.VerwendungVon BETWEEN @DatumVon AND @DatumBis OR @DatumVon BETWEEN MIG_I.VerwendungVon AND MIG_I.VerwendungBis)
      WHERE FAL_II.BaPersonID = TMP.FallBaPersonID
        AND MIG_I.LeistungsArtNrProLeist < 9000
        AND MIG_I.BuchungsStatusCode = 1 /*Korrekt*/
      GROUP BY MIG_I.FaLeistungID, Mig_I.KissLeistungsart, MIG_I.BaPersonID, MIG_I.BelegNummer
      HAVING SUM(MIG_I.Betrag) < 0 -- Einnahmen in Proleist haben negatives Vorzeichen
    
    ) EA
  ) BVP
  INNER JOIN dbo.FaFall         FAL WITH (READUNCOMMITTED) ON TMP.FallBaPersonID = FAL.BaPersonID
  INNER JOIN dbo.FaFallPerson   FAP WITH (READUNCOMMITTED) ON FAP.FaFallID = FAL.FaFallID
GROUP BY FAP.BaPersonID, TMP.FallBaPersonID

--Select Count(*) from #Suchparameter -- Test
----------------------------------------------------------------------------------------------------------------------------
-- bis hier: 8 sek, mit Anfangsdatum 11 sek
----------------------------------------------------------------------------------------------------------------------------

CREATE TABLE #Kandidaten
(
  BaPersonID int,
  FallBaPersonID int,
  DatumVon datetime -- Erste Einzahlung
  PRIMARY KEY (BaPersonID, FallBaPersonID)
)

--Vorfilterung: Ausgaben abrunden, Einnahmen aufrunden
INSERT INTO #Kandidaten
SELECT --TOP 100  -- TEST
  TMP.BaPersonID,
  TMP.FallBaPersonID,
  DatumVon = MIN(TMP.DatumVon)
FROM
(
  SELECT --TOP 100  -- TEST
    SUC.BaPersonID,
    SUC.FallBaPersonID,
    Betrag = dbo.[fnWhGetBetragKontoauszug](BKA.BgSplittingArtCode, KBP.Betrag, KBP.VerwPeriodeVon, KBP.VerwPeriodeBis, SUC.DatumVon, @DatumBis),
    SUC.DatumVon
  FROM #Suchparameter						      SUC
    INNER JOIN dbo.KbBuchungBruttoPerson	KBP WITH (READUNCOMMITTED) ON SUC.BaPersonID = KBP.BaPersonID
	    AND (SUC.DatumVon BETWEEN KBP.VerwPeriodeVon AND KBP.VerwPeriodeBis
		    OR KBP.VerwPeriodeVon BETWEEN SUC.DatumVon AND @DatumBis)
    INNER JOIN dbo.KbBuchungBrutto			  KBB WITH (READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
      AND (KBB.KbBuchungstatusCode <> 8 OR KBB.GruppierungUmbuchung NOT LIKE 'S0%')
    INNER JOIN dbo.BgKostenart        BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = KBB.BgKostenartID
      AND BKA.KontoNr NOT IN (SELECT LAL.KontoNr FROM @LAList LAL) AND BKA.KontoNr NOT IN ('140', '170')
  -- 41%  = 26
  WHERE (KBB.KbBuchungstatusCode = 6 AND KBP.BgPositionID IS NULL
      OR KBB.KbBuchungstatusCode = 8 AND KBB.GruppierungUmbuchung NOT LIKE 'S0%') -- Umbuchung
    OR EXISTS (SELECT BUC.KbBuchungID
			          FROM dbo.KbBuchungKostenart KBA WITH (READUNCOMMITTED)
				          INNER JOIN dbo.KbBuchung  BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = KBA.KbBuchungID
			          WHERE KBA.BgPositionID = KBP.BgPositionID
                  AND (KbBuchungStatusCode = 6 OR KBP.Betrag > 0 AND (KBB.Abgetreten = 0 OR KbBuchungStatusCode = 10)))
                  -- Entweder ausgeglichen [6] oder Einnahme (nicht abgetreten oder teilausgeglichen[10])
  UNION ALL -- ProLeist
  SELECT
    SUC.BaPersonID,
    SUC.FallBaPersonID,
    Betrag = dbo.[fnWhGetBetragKontoauszug](IsNull(BKA.BgSplittingArtCode, 2/*Monat*/), MIG.Betrag, MIG.VerwendungVon, MIG.VerwendungBis, SUC.DatumVon, @DatumBis),
    SUC.DatumVon
  FROM #Suchparameter						SUC
    INNER JOIN dbo.MigDetailBuchung MIG WITH (READUNCOMMITTED) ON MIG.BaPersonID = SUC.BaPersonID
	    AND (SUC.DatumVon BETWEEN MIG.VerwendungVon AND MIG.VerwendungBis
		    OR MIG.VerwendungVon BETWEEN SUC.DatumVon AND @DatumBis)
      AND MIG.KissLeistungsArt NOT IN (SELECT KontoNr FROM @LAList) AND MIG.KissLeistungsArt NOT IN ('140', '170')
      AND MIG.LeistungsArtNrProLeist < 9000
      AND MIG.BuchungsStatusCode = 1 /*Korrekt*/
    LEFT  JOIN dbo.BgKostenart      BKA WITH (READUNCOMMITTED) ON BKA.KontoNr = MIG.KissLeistungsart
) TMP
GROUP BY TMP.BaPersonID, TMP.FallBaPersonID
HAVING SUM(Betrag) > 0
--bis hier: 17 sek. ohne Proleist bei einem team über knapp 10000 personen/monate und 635 Kandidaten

----------------------------------------------------------------------------------------------------------------------------
--Select Count(*) from #Kandidaten -- Test
-- bis hier: 12 sek.
----------------------------------------------------------------------------------------------------------------------------

CREATE TABLE #MKKPResult
(
  BaPersonID int,
  DisplayText varchar(200),
  FaFallID int,
  FallBaPersonID int,
  Einnahmen money,
  Ausgaben money,
  Saldo money,
  BetragLA140 money,
  BetragLA170 money,
  KVGPraemie money,
  SZ varchar(200),
  QT varchar(200),
  MA varchar(200),
  DatumVon datetime -- datum erster Einnahme
  PRIMARY KEY (BaPersonID, FallBaPersonID)
)

INSERT INTO #MKKPResult
SELECT
  KAN.BaPersonID,
  DisplayText = MAX(PER.DisplayText),
  FaFallID = FAL.FaFallID,
  FallBaPersonID = KAN.FallBaPersonID,
  Einnahmen = SUM(ISNULL(KON.Einnahmen, $0.00)),
  Ausgaben = -SUM(ISNULL(KON.Ausgaben, $0.00)),
  Saldo = SUM(ISNULL(KON.Einnahmen, $0.00)) + SUM(ISNULL(KON.Ausgaben, $0.00)),
  BetragLA140 = SUM(ISNULL(KON.Betrag140, $0.00)),
  BetragLA170 = SUM(ISNULL(KON.Betrag170, $0.00)),
  KVGPraemie = (SUM(ISNULL(KON.Betrag140, $0.00)) + SUM(ISNULL(KON.Betrag170, $0.00))) / datediff(month, @datumVon, @datumBis + 1),
  SZ = MAX(USR.SozialzentrumKurz),
  QT = MAX(USR.OrgUnitShort),
  MA = MAX(USR.NameVorname),
  DatumVon = MIN(KAN.DatumVon)
FROM #Kandidaten						KAN
  CROSS APPLY (
    SELECT 
      Ausgaben  = SUM(CASE WHEN EA = 'A' AND LA NOT IN ('140', '170') THEN BetragEffektiv ELSE $0.0 END), -- ('140', '170') 
      Einnahmen = SUM(CASE WHEN EA = 'E' AND LA NOT IN ('140', '170') THEN BetragEffektiv ELSE $0.0 END), -- ('140', '170') 
      Betrag140 = SUM(CASE WHEN LA = '140' THEN BetragEffektiv ELSE 0.00 END),
      Betrag170 = SUM(CASE WHEN LA = '170' THEN BetragEffektiv ELSE 0.00 END)
    FROM fnWhKontoauszug(KAN.FallBaPersonID,
      CONVERT(varchar(10),KAN.BaPersonID), --PersonenListe
      3, --KbKontoZeitraumCode 3 = Verwendungsperiode
      KAN.DatumVon, --DatumVon
      @DatumBis, --DatumBis
      null, --Buchungstext
      null,--@LAList, --LAList, ohne LA 140
      0, --Verdichtet
      1, --InklProLeist
      0, --InklVermittlungsfall
      0, --InklGruen
      0, --InklRot
      0, --InklStorno
      null,--@EA
      0 -- Klientenkontoabrechnungsmodus
    )
    WHERE LA NOT IN (SELECT KontoNr FROM @LAList)
  ) KON
  CROSS APPLY (SELECT TOP 1 FaFallID, UserID FROM dbo.FaFall FAL WITH (READUNCOMMITTED) WHERE FAL.BaPersonID = KAN.FallBaPersonID ORDER BY FaFallID DESC) FAL
  LEFT JOIN dbo.vwPersonSimple			PER WITH (READUNCOMMITTED) ON PER.BaPersonID = KAN.BaPersonID
  INNER JOIN dbo.vwUser			  USR WITH (READUNCOMMITTED) ON USR.UserID = FAL.UserID
GROUP BY KAN.BaPersonID, KAN.FallBaPersonID, FAL.FaFallID
HAVING SUM(KON.Einnahmen) > -SUM(KON.Ausgaben)

-- Füge Personen ohne Überschuss ein, die in einem Fall sind, in dem Personen mit Überschuss vorhanden sind(wobei Fall jeden Fall mit gleichem Fallträger abdeckt)
INSERT INTO #MKKPResult
SELECT
  TMP.BaPersonID,
  DisplayText = MAX(PER.DisplayText),
  FaFallID = FAL.FaFallID,
  FallBaPersonID = TMP.FallBaPersonID,
  Einnahmen = SUM(ISNULL(KON.Einnahmen, $0.00)),
  Ausgaben = -SUM(ISNULL(KON.Ausgaben, $0.00)),
  Saldo = SUM(ISNULL(KON.Einnahmen, $0.00)) + SUM(ISNULL(KON.Ausgaben, $0.00)),
  BetragLA140 = SUM(ISNULL(KON.Betrag140, $0.00)),
  BetragLA170 = SUM(ISNULL(KON.Betrag170, $0.00)),
  KVGPraemie = (SUM(ISNULL(KON.Betrag140, $0.00)) + SUM(ISNULL(KON.Betrag170, $0.00))) / datediff(month, @datumVon, @datumBis + 1),
  SZ = MAX(USR.SozialzentrumKurz),
  QT = MAX(USR.OrgUnitShort),
  MA = MAX(USR.NameVorname),
  DatumVon = MIN(TMP.DatumVon)
FROM
(
  -- KISS
  SELECT DISTINCT BFP.BaPersonID, RES.FallBaPersonID, RES.DatumVon
  FROM #MKKPResult RES
    INNER JOIN dbo.FaFall                 FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = RES.FallBaPersonID
    INNER JOIN dbo.FaLeistung             LEI WITH (READUNCOMMITTED) ON LEI.FaFallID = FAL.FaFallID
    INNER JOIN dbo.BgFinanzplan           FIP WITH (READUNCOMMITTED) ON FIP.FaLeistungID = LEI.FaLeistungID
    INNER JOIN dbo.BgFinanzplan_BaPerson  BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = FIP.BgFinanzplanID
  WHERE BFP.IstUnterstuetzt = 1
    AND (FIP.DatumVon BETWEEN RES.DatumVon AND @DatumBis OR RES.DatumVon BETWEEN FIP.DatumVon AND FIP.DatumBis OR FIP.DatumBis IS NULL AND RES.DatumVon >= FIP.DatumVon)
    AND NOT EXISTS (SELECT FallBaPersonID FROM #MKKPResult RES_I WHERE RES_I.FallBaPersonID = RES.FallBaPersonID AND RES_I.BaPersonID = BFP.BaPersonID)
  UNION 
  -- Proleist
  SELECT DISTINCT MIG.BaPersonID, RES.FallBaPersonID, RES.DatumVon
  FROM #MKKPResult RES
    INNER JOIN dbo.FaFall           FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = RES.FallBaPersonID
    INNER JOIN dbo.FaLeistung       LEI WITH (READUNCOMMITTED) ON LEI.FaFallID = FAL.FaFallID
    INNER JOIN dbo.MigDetailBuchung MIG WITH (READUNCOMMITTED) ON MIG.FaLeistungID = LEI.FaLeistungID
      AND MIG.LeistungsArtNrProLeist < 9000
      AND MIG.BuchungsStatusCode = 1 /*Korrekt*/
  WHERE
    (MIG.VerwendungVon BETWEEN RES.DatumVon AND @DatumBis OR RES.DatumVon BETWEEN MIG.VerwendungVon AND MIG.VerwendungBis)
    AND NOT EXISTS (SELECT FallBaPersonID FROM #MKKPResult RES_I WHERE RES_I.FallBaPersonID = RES.FallBaPersonID AND RES_I.BaPersonID = MIG.BaPersonID)
) TMP -- Personen ohne Überschuss in einem Fall mit Personen mit Überschuss
  CROSS APPLY (
    SELECT
      Ausgaben  = SUM(CASE WHEN EA = 'A' AND LA NOT IN ('140', '170') THEN BetragEffektiv ELSE $0.0 END), -- ('140', '170') 
      Einnahmen = SUM(CASE WHEN EA = 'E' AND LA NOT IN ('140', '170') THEN BetragEffektiv ELSE $0.0 END), -- ('140', '170') 
      Betrag140 = SUM(CASE WHEN LA = '140' THEN BetragEffektiv ELSE 0.00 END),
      Betrag170 = SUM(CASE WHEN LA = '170' THEN BetragEffektiv ELSE 0.00 END)
    FROM fnWhKontoauszug(TMP.FallBaPersonID,
      CONVERT(varchar(10),TMP.BaPersonID), --PersonenListe
      3, --KbKontoZeitraumCode 3 = Verwendungsperiode
      TMP.DatumVon, --DatumVon
      @DatumBis, --DatumBis
      null, --Buchungstext
      null,--@LAList, --LAList, ohne LA 140
      0, --Verdichtet
      1, --InklProLeist
      0, --InklVermittlungsfall
      0, --InklGruen
      0, --InklRot
      0, --InklStorno
      null,--@EA
      0 -- Klientenkontoabrechnungsmodus
    )
    WHERE LA NOT IN (SELECT KontoNr FROM @LAList)
  ) KON
  CROSS APPLY (SELECT TOP 1 FaFallID, UserID FROM dbo.FaFall FAL WITH (READUNCOMMITTED) WHERE FAL.BaPersonID = TMP.FallBaPersonID ORDER BY FaFallID DESC) FAL
  LEFT JOIN dbo.vwPersonSimple			PER WITH (READUNCOMMITTED) ON PER.BaPersonID = TMP.BaPersonID
  INNER JOIN dbo.vwUser			  USR WITH (READUNCOMMITTED) ON USR.UserID = FAL.UserID
GROUP BY TMP.BaPersonID, TMP.FallBaPersonID, FAL.FaFallID

SELECT
  FaFallID,
  NameVorname = MAX(PER.NameVorname),
  FallBaPersonID = MAX(FallBaPersonID),
  Einnahmen = SUM(Einnahmen),
  Ausgaben = SUM(Ausgaben),
  Saldo = SUM(Saldo),
  BetragLA140 = SUM(BetragLA140),
  BetragLA170 = SUM(BetragLA170),
  KVGPraemie = SUM(KVGPraemie),
  SZ = MAX(SZ),
  QT = MAX(QT),
  MA = MAX(MA),
  DatumErsteEinnahme = MIN(DatumVon) -- datum erster Einnahme
FROM #MKKPResult RES
  LEFT JOIN dbo.vwPersonSimple			PER WITH (READUNCOMMITTED) ON PER.BaPersonID = RES.FallBaPersonID
GROUP BY FaFallID
ORDER BY MA, NameVorname

SELECT
  DetailBaPersonID = BaPersonID,
  DetailNameVorname = DisplayText,
  FaFallID = FaFallID,
  FallBaPersonID,
  DetailEinnahmen = Replace(Convert(varchar(20), Einnahmen, 1), ',', ''''),
  DetailAusgaben = Replace(Convert(varchar(20), Ausgaben, 1), ',', ''''),
  DetailSaldo = Replace(Convert(varchar(20), Saldo, 1), ',', ''''),
  DetailBetrag140 = Replace(Convert(varchar(20), BetragLA140, 1), ',', ''''),
  DetailBetrag170 = Replace(Convert(varchar(20), BetragLA170, 1), ',', ''''),
  DetailBetragKVG = Replace(Convert(varchar(20), KVGPraemie, 1), ',', ''''),
  SZ,
  QT,
  MA ,
  DatumErsteEinnahme = DatumVon -- datum erster Einnahme
FROM #MKKPResult RES

DROP TABLE #Suchparameter
DROP TABLE #Kandidaten
DROP TABLE #MKKPResult
--
END TRY
BEGIN CATCH
  IF OBJECT_ID('tempdb..#Suchparameter') IS NOT NULL BEGIN
    DROP TABLE #Suchparameter
  END
  IF OBJECT_ID('tempdb..#Kandidaten') IS NOT NULL BEGIN
    DROP TABLE #Kandidaten
  END

  IF OBJECT_ID('tempdb..#MKKPResult') IS NOT NULL BEGIN
    DROP TABLE #MKKPResult
  END
  IF ERROR_NUMBER() IS NOT NULL BEGIN
  	DECLARE @error_message varchar(2000), @error_number int, @error_severity int, @error_state int,
		  @error_procedure varchar(200), @error_line int
	  SELECT @error_message = N'Error %d, Level %d, State %d, Procedure %s, Line %d, Message: ' +ERROR_MESSAGE(), @error_number = ERROR_NUMBER(), @error_severity = ERROR_SEVERITY(),
  		@error_state = ERROR_STATE(), @error_procedure = ERROR_PROCEDURE(), @error_line = ERROR_LINE()
  	RAISERROR (@error_message, @error_severity, 1, @error_number, @error_severity, @error_state, @error_procedure, @error_line);
  END
END CATCH


END
GO
