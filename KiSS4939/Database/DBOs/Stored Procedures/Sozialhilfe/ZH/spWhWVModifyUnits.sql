SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhWVModifyUnits
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhWVModifyUnits.sql $
  $Author: Mmarghitola $
  $Modtime: 24.09.10 10:12 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhWVModifyUnits.sql $
 * 
 * 13    24.09.10 10:13 Mmarghitola
 * ungültiges Zeichen entfernt
 * 
 * 12    23.09.10 21:14 Mminder
 * #6561 Attribute von WV-Einheiten werden in separaten Tabellen abgelegt
 * und von dort beim Bilden geholt
 * 
 * 11    23.09.10 20:52 Mminder
 * #6561 Check nicht für nicht bewilligte FP durchführen
 * 
 * 10    19.08.10 15:59 Mminder
 * #6561 SKZNummer, HeimatkantonNr und Rekursverfahren nach einfacherer
 * Regel übernehmen
 * 
 * 9     15.07.10 14:57 Mmarghitola
 * #6438: Bei gleichen, aufeinanderfolgenden WV-Codes derselben Person nur
 * den ersten in die WhWVEinheitMitglied übernehmen (wie bei alten
 * WV-Einträgen zu erkennen). Verhindert eine Exception durch doppelte
 * BaPerson-WhWvEinheit.
 * 
 * 8     18.06.10 16:15 Mminder
 * #5819: Fürs Bis-Datum wird nun auch bei einem Update 31.12.9999 durch
 * NULL ersetzt
 * 
 * 7     20.05.10 14:07 Lloreggia
 * NULL-Zeichen entfernt
 * 
 * 6     19.05.10 10:46 Mminder
 * #5819: SKZ-Nummer und Heimatkantonnummer übernehmen, wenn Träger ändert
 * 
 * 5     19.05.10 9:21 Mminder
 * #5819: Träger von IST zu SOLL-Einheit übernehmen
 * 
 * 4     17.05.10 16:49 Mminder
 * #5819: WV-Einheitenbildung abhängig von Finanzplanzusammenstellung
 * 
 * 3     11.12.09 12:51 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 17:59 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhWVModifyUnits]
(
  @FaFallID    int,
  @ErrorIfNoFP bit = 1
)
AS BEGIN

--declare @FaFallID int
--set @FaFallID = 51052
--set @FaFallID = 50529

DECLARE @DateMax              DATETIME,
        @DateMin              DATETIME,
        @msg                  VARCHAR(1000),
        @WhWVEinheitID        INT,
        @WhWVEinheitID_insert INT;

SET @DateMax = dbo.fnDateSerial(9999,12,31);
SET @DateMin = dbo.fnDateSerial(1753, 1, 1);

-- Hinweis, falls noch keine Personen einem Haushalt zugeordnet wurden
IF NOT EXISTS (SELECT *
               FROM dbo.FaFallPerson                  FAP WITH (READUNCOMMITTED) 
                 INNER JOIN dbo.FaLeistung            LEI WITH (READUNCOMMITTED) ON LEI.FaFallID       = FAP.FaFallID
                 INNER JOIN dbo.BgFinanzplan          BFP WITH (READUNCOMMITTED) ON BFP.FaLeistungID   = LEI.FaLeistungID
                 INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = BFP.BgFinanzplanID AND FPP.BaPersonID = FAP.BaPersonID
               WHERE FAP.FaFallID = @FaFallID AND BFP.BgBewilligungStatusCode IN (5,9) AND FPP.IstUnterstuetzt = 1) BEGIN
  IF( @ErrorIfNoFP = 1 ) BEGIN
    SET @msg = 'WV-Einheiten werden erst beim Visum eines Finanzplans generiert!'
    RAISERROR(@msg,18,1)
  END
  RETURN
END

-- Alle Datums dieses Falles bestimmen, an denen die Zusammenstellung von Einheiten ändern könnte
-- auf diese werden die WV-Codes zerstückelt
DECLARE @UnterstuetztePersonen TABLE
(
  BaPersonID int
)

INSERT INTO @UnterstuetztePersonen
SELECT FPP.BaPersonID
FROM dbo.FaFallPerson                  FAP WITH (READUNCOMMITTED) 
  INNER JOIN dbo.FaLeistung            LEI WITH (READUNCOMMITTED) ON LEI.FaFallID       = FAP.FaFallID
  INNER JOIN dbo.BgFinanzplan          BFP WITH (READUNCOMMITTED) ON BFP.FaLeistungID   = LEI.FaLeistungID
  INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = BFP.BgFinanzplanID AND FPP.BaPersonID = FAP.BaPersonID
WHERE LEI.FaFallID = @FaFallID AND BFP.BgBewilligungStatusCode IN (5,9) AND FPP.IstUnterstuetzt = 1


DECLARE @DatesTemp TABLE
(
  DateFrom DATETIME,
  DateTo   DATETIME
)

INSERT INTO @DatesTemp(DateFrom, DateTo)
SELECT DISTINCT WVC.DatumVon, ISNULL(DATEADD(DAY,1,WVC.DatumBis), @DateMax)
FROM dbo.FaFallPerson                  FAP WITH (READUNCOMMITTED) 
  INNER JOIN dbo.FaLeistung            LEI WITH (READUNCOMMITTED) ON LEI.FaFallID       = FAP.FaFallID
  INNER JOIN dbo.BaWVCode              WVC WITH (READUNCOMMITTED) ON WVC.BaPersonID     = FAP.BaPersonID
WHERE FAP.FaFallID = @FaFallID AND WVC.BaWVStatusCode = 1
  AND FAP.BaPersonID IN (SELECT BaPersonID FROM @UnterstuetztePersonen)
ORDER BY DatumVon

--Zusätzliche Stückelung: manuell herausgelöste Einheiten
INSERT INTO @DatesTemp(DateFrom, DateTo)
SELECT DISTINCT DatumVon, ISNULL(DATEADD(DAY,1,DatumBis), @DateMax)
FROM dbo.WhWVEinheit
WHERE FaFallID = @FaFallID AND EinheitHerausgeloest = 1
ORDER BY DatumVon

--Zusätzliche Stückelung: Finanzplan-Datums werden auch berücksichtigt
INSERT INTO @DatesTemp(DateFrom, DateTo)
SELECT DISTINCT BFP.DatumVon, ISNULL(DATEADD(DAY,1,BFP.DatumBis), @DateMax)
FROM dbo.FaLeistung           LEI
  INNER JOIN dbo.BgFinanzplan BFP WITH (READUNCOMMITTED) ON BFP.FaLeistungID = LEI.FaLeistungID
WHERE LEI.FaFallID = @FaFallID AND BFP.BgBewilligungStatusCode IN (5,9)
ORDER BY DatumVon


-- Zusammenzug, uniqueness
DECLARE @Dates TABLE
(
  Date DATETIME
)

INSERT INTO @Dates(Date)
SELECT DISTINCT DateFrom
FROM @DatesTemp

INSERT INTO @Dates(Date)
SELECT DISTINCT DateTo
FROM @DatesTemp
WHERE DateTo NOT IN (SELECT Date FROM @Dates)


-- Tabelle, welche die zerstückelten WV-Codes enthält
DECLARE @Splits TABLE
(
  SplitID                    INT IDENTITY(1,1),
  BaPersonID                 INT,
  DatumVon                   DATETIME,
  DatumBis                   DATETIME,
  WVCode                     INT,
  BEDCode                    INT,
  WVUnitID                   INT NULL,
  BaWVCodeID                 INT,
  BgFinanzplanID             INT,
  TrennungAusBgFinanzplanID  INT,
  EinheitHerausgeloest       BIT NOT NULL DEFAULT(0),
  ManuellEinheitID           INT
)

DECLARE @BaPersonID        INT
DECLARE @DatumVon          DATETIME
DECLARE @DatumBis          DATETIME
DECLARE @WVCode            INT
DECLARE @BEDCode           INT
DECLARE @Date              DATETIME
DECLARE @OldDate           DATETIME
DECLARE @WVUnitID          DATETIME
DECLARE @BaWVCodeID        INT
DECLARE @Identic           BIT
DECLARE @BgFinanzplanID    INT


DECLARE cCodes CURSOR LOCAL FAST_FORWARD FOR
  SELECT DISTINCT WVC.BaPersonID, WVC.DatumVon, IsNull(WVC.DatumBis, @DateMax), WVC.WVCode, WVC.BaBedID, WVC.BaWVCodeID
  FROM dbo.FaFallPerson     FAP
    INNER JOIN dbo.BaWVCode WVC ON WVC.BaPersonID = FAP.BaPersonID
  WHERE FAP.FaFallID = @FaFallID AND WVC.BaWVStatusCode = 1
    AND FAP.BaPersonID IN (SELECT BaPersonID FROM @UnterstuetztePersonen)
  ORDER BY WVC.BaPersonID

OPEN cCodes
WHILE 1=1 BEGIN
  FETCH NEXT FROM cCodes INTO @BaPersonID, @DatumVon, @DatumBis, @WVCode, @BEDCode, @BaWVCodeID
  IF @@FETCH_STATUS <> 0 BREAK

  SET @OldDate = @DatumVon

  DECLARE cDates CURSOR LOCAL FAST_FORWARD FOR
    SELECT Date
    FROM   @Dates
    WHERE  Date > @DatumVon AND Date < @DatumBis
    ORDER BY Date

  OPEN cDates
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cDates INTO @Date
    IF @@FETCH_STATUS <> 0 BREAK

    INSERT INTO @Splits( BaPersonID, DatumVon, DatumBis, WVCode, BEDCode, BaWVCodeID)
    VALUES (@BaPersonID, @OldDate, DATEADD(DAY,-1,@Date), @WVCode, @BEDCode, @BaWVCodeID)
    
    SET @OldDate = @Date
  END
  CLOSE cDates
  DEALLOCATE cDates
  
  IF @OldDate < @DatumBis BEGIN
    INSERT INTO @Splits (BaPersonID, DatumVon, DatumBis, WVCode, BEDCode, BaWVCodeID)
    VALUES (@BaPersonID, @OldDate, @DatumBis, @WVCode, @BEDCode, @BaWVCodeID)
  END

END
CLOSE cCodes
DEALLOCATE cCodes


-- Bestimmen, zu welchem Finanzplan ein Split gehört (wenn überhaupt)
UPDATE SPL
SET BgFinanzplanID            = BFP.BgFinanzplanID,
    TrennungAusBgFinanzplanID = BFP.BgFinanzplanID
FROM dbo.FaLeistung                    LEI
  INNER JOIN dbo.BgFinanzplan          BFP ON BFP.FaLeistungID = LEI.FaLeistungID
  INNER JOIN dbo.BgFinanzplan_BaPerson FPP ON FPP.BgFinanzplanID = BFP.BgFinanzplanID AND FPP.IstUnterstuetzt = 1
  INNER JOIN @Splits                   SPL ON SPL.BaPersonID = FPP.BaPersonID AND dbo.fnDatumUeberschneidung(SPL.DatumVon, SPL.DatumBis, BFP.DatumVon, BFP.DatumBis) = 1
WHERE LEI.FaFallID = @FaFallID


-- Splits, die nicht durch Finanzplan abgedeckt sind, einem FP zuordnen
-- zuerst rückwärts auf der Zeitachse den letzten suchen...
UPDATE SPL
SET TrennungAusBgFinanzplanID = FPS.BgFinanzplanID
FROM @Splits         SPL
  INNER JOIN @Splits FPS ON FPS.SplitID = (SELECT TOP 1 SplitID
                                           FROM @Splits
                                           WHERE BaPersonID = SPL.BaPersonID AND
                                                 BgFinanzplanID IS NOT NULL AND
                                                 DatumVon < SPL.DatumVon
                                           ORDER BY DATEDIFF(d, DatumVon, SPL.DatumVon))
WHERE SPL.TrennungAusBgFinanzplanID IS NULL

-- ...danach vorwärts auf der Zeitachse den nächsten suchen (für den Zeitraum vor dem ersten FP)
UPDATE SPL
SET TrennungAusBgFinanzplanID = FPS.BgFinanzplanID
FROM @Splits         SPL
  INNER JOIN @Splits FPS ON FPS.SplitID = (SELECT TOP 1 SplitID
                                           FROM @Splits
                                           WHERE BaPersonID = SPL.BaPersonID AND
                                                 BgFinanzplanID IS NOT NULL AND
                                                 DatumVon > SPL.DatumVon
                                           ORDER BY DATEDIFF(d, SPL.DatumVon, DatumVon))
WHERE SPL.TrennungAusBgFinanzplanID IS NULL


DECLARE @WVUnits TABLE
(
  ID                         INT IDENTITY(1,1),
  DatumVon                   DATETIME,
  DatumBis                   DATETIME,
  WVCode                     INT,
  BEDCode                    INT,
  Mitglieder                 VARCHAR(100),
  EinheitHerausgeloest       BIT,
  ManuellEinheitID           INT,
  BgFinanzplanID             INT,
  TrennungAusBgFinanzplanID  INT,
  BaPersonID_Traeger         INT
)

-- manuell herausgelöste markieren, die dürfen nicht mit anderen gruppiert werden
UPDATE SPL
SET EinheitHerausgeloest = 1,
    ManuellEinheitID = WVE.WhWVEinheitID
FROM @Splits                         SPL
  INNER JOIN dbo.WhWVEinheit         WVE WITH (READUNCOMMITTED) ON WVE.DatumVon           <=        SPL.DatumVon AND
                                                            ISNULL(WVE.DatumBis,@DateMax) >= ISNULL(SPL.DatumBis,@DateMax) AND
                                                                   WVE.WVCode              =        SPL.WVCode AND
                                                                   WVE.BEDCode             =        SPL.BEDCode
  INNER JOIN dbo.WhWVEinheitMitglied WVM WITH (READUNCOMMITTED) ON WVM.WhWVEinheitID = WVE.WhWVEinheitID AND
                                                                   WVM.BaPersonID    = SPL.BaPersonID
WHERE FaFallID = @FaFallID AND WVE.EinheitHerausgeloest = 1


-- WV-Einheiten erstellen
INSERT INTO @WVUnits (DatumVon, DatumBis, WVCode, BEDCode, Mitglieder, EinheitHerausgeloest, ManuellEinheitID, BgFinanzplanID, TrennungAusBgFinanzplanID)
  SELECT DatumVon, ISNULL(DatumBis,@DateMax), WVCode, BEDCode, dbo.ConcDistinctOrder(BaPersonID), EinheitHerausgeloest, ManuellEinheitID, BgFinanzplanID, TrennungAusBgFinanzplanID
  FROM @Splits
  GROUP BY DatumVon, ISNULL(DatumBis,@DateMax), WVCode, BEDCode, EinheitHerausgeloest, ManuellEinheitID, BgFinanzplanID, TrennungAusBgFinanzplanID


-- die Splits zu WV-Einheiten zuordnen
UPDATE SPL
SET WVUnitID = ID
FROM @Splits          SPL
  INNER JOIN @WVUnits WVU ON        SPL.DatumVon                      =        WVU.DatumVon AND
                             ISNULL(SPL.DatumBis,@DateMax)            = ISNULL(WVU.DatumBis,@DateMax) AND
                                    SPL.WVCode                        =        WVU.WVCode AND
                                    SPL.BEDCode                       =        WVU.BEDCode AND
                                    SPL.EinheitHerausgeloest          =        WVU.EinheitHerausgeloest AND
                             ISNULL(SPL.ManuellEinheitID,-1)          = ISNULL(WVU.ManuellEinheitID,-1) AND
                             ISNULL(SPL.BgFinanzplanID,-1)            = ISNULL(WVU.BgFinanzplanID,-1) AND
                             ISNULL(SPL.TrennungAusBgFinanzplanID,-1) = ISNULL(WVU.TrennungAusBgFinanzplanID,-1)

-- Einheiten verbinden
-- Cursor ist nötig, da mehrere hintereinanderliegende Winheiten fusioniert werden können
DECLARE @Counter int
SET @Counter = 0
WHILE (@Counter = 0 OR (@@ROWCOUNT > 0 AND @Counter < 1000)) --watchdog
BEGIN
  SET @Counter = @Counter + 1

  UPDATE WVU
  SET DatumVon = CASE WHEN WVU.DatumVon < CMP.DatumVon THEN WVU.DatumVon ELSE CMP.DatumVon END,
      DatumBis = CASE WHEN WVU.DatumBis > CMP.DatumBis THEN WVU.DatumBis ELSE CMP.DatumBis END
  FROM @WVUnits         WVU
    INNER JOIN @WVUnits CMP ON WVU.WVCode               = CMP.WVCode AND
                               WVU.BEDCode              = CMP.BEDCode AND
                               WVU.Mitglieder           = CMP.Mitglieder AND
                               WVU.EinheitHerausgeloest = CMP.EinheitHerausgeloest AND
                               WVU.ID <> CMP.ID AND
                               WVU.DatumBis = DATEADD(DAY,-1,CMP.DatumVon)
END 


-- Splits von fusionierten WV-Einheiten an die übriggebliebenen umhängen
-- nach obigem cursor sind die Bis-Datum der zu fusionierenden WVE gleich, die mit der längsten Dauer wird beibehalten
UPDATE SPL
SET WVUnitID = CMP.ID
FROM @Splits SPL
  INNER JOIN @WVUnits WVU ON WVU.ID = SPL.WVUnitID
  INNER JOIN @WVUnits CMP ON WVU.WVCode = CMP.WVCode AND 
                             WVU.BEDCode = CMP.BEDCode AND
                             WVU.Mitglieder = CMP.Mitglieder AND
                             WVU.EinheitHerausgeloest = CMP.EinheitHerausgeloest AND
                             WVU.ID <> CMP.ID AND
                             WVU.DatumBis = CMP.DatumBis AND
                             DATEDIFF(DAY,WVU.DatumVon,WVU.DatumBis) < DATEDIFF(DAY,CMP.DatumVon,CMP.DatumBis)

-- Überzählige WV-Einheiten löschen
DELETE WVU
FROM @WVUnits         WVU
  INNER JOIN @WVUnits CMP ON WVU.WVCode = CMP.WVCode AND 
                             WVU.BEDCode = CMP.BEDCode AND
                             WVU.Mitglieder = CMP.Mitglieder AND
                             WVU.EinheitHerausgeloest = CMP.EinheitHerausgeloest AND
                             WVU.ID <> CMP.ID AND
                             WVU.DatumBis = CMP.DatumBis AND
                             DATEDIFF(DAY,WVU.DatumVon,WVU.DatumBis) < DATEDIFF(DAY,CMP.DatumVon,CMP.DatumBis)


--SELECT * FROM @WVUnits

DECLARE @WhWVEinheit TABLE
(
  WhWVEinheitID    INT IDENTITY(1,1),
  FaFallID	       INT,
  DatumVon	       DATETIME,
  DatumBis	       DATETIME,
  BaPersonID	   INT,
  WVCode	       INT,
  BEDCode	       INT,
  WhWVEinheitID_OK INT,
  ManuellEinheitID INT,
  WVUID            INT
)

DECLARE @WhWVEinheitMitglied TABLE
(
  WhWVEinheitMitgliedID INT IDENTITY(1,1),
  WhWVEinheitID         INT,
  BaPersonID            INT,
  BaWVCodeID            INT
)


-- temporäre WV-Einheiten erstellen
-- WV-Träger bestimmen
INSERT INTO @WhWVEinheit (FaFallID, DatumVon, DatumBis, WVCode, BEDCode, BaPersonID, ManuellEinheitID, WVUID)
SELECT @FaFallID, WVU.DatumVon, WVU.DatumBis, WVU.WVCode, WVU.BEDCode, SPL.BaPersonID, WVU.ManuellEinheitID, WVU.ID
FROM   @WVUnits      WVU
  INNER JOIN @Splits SPL ON SplitID = (SELECT TOP 1 SplitID
                                       FROM   @Splits        SPLI
                                         INNER JOIN dbo.vwPerson PRS  ON PRS.BaPersonID = SPLI.BaPersonID
                                       WHERE  WVUnitID = WVU.ID
                                       ORDER BY CASE WHEN PRS.[Alter] >= 18 THEN GeschlechtCode + 10 ELSE GeschlechtCode END DESC, PRS.[Alter] DESC)
ORDER BY ID

INSERT INTO @WhWVEinheitMitglied (WhWVEinheitID, BaPersonID, BaWVCodeID)
SELECT WVE.WhWVEinheitID, SPL.BaPersonID, MIN(SPL.BaWVCodeID)
FROM   @WVUnits           WVU
  INNER JOIN @Splits      SPL ON SPL.WVUnitID = WVU.ID
  INNER JOIN @WhWVEinheit WVE ON WVE.WVUID    = WVU.ID
GROUP BY WVE.WhWVEinheitID, SPL.BaPersonID

/*
select * from @splits

select 'SOLL', '@WhWVEinheit/Mitglied', *
from @WhWVEinheit WVE
  INNER JOIN @WhWVEinheitMitglied WVM ON WVM.WhWVEinheitID = WVE.WhWVEinheitID
*/


DECLARE @BestehendeWVEinheitenVerwertbar TABLE
(
  WhWVEinheitID          INT,
  BEDCode                INT,
  WVCode                 INT,
  DatumVon               DATETIME,
  DatumBis               DATETIME,
  VerwPeriodeMin         DATETIME,
  VerwPeriodeMax         DATETIME,
  BaPersonID             INT,
  Mitglieder             VARCHAR(100),
  BebuchteMitglieder     VARCHAR(100),
  AnzahlEP               INT,
  VorgehenCode           INT,
  WhWVEinheitID_SOLL     INT
)

-- Bestimmen von SKZNummer pro UT/WV-Code
-- und Heimatkanton-Nr und Rekursverfahren-Daten pro UT/WV-Code/BED
DECLARE @UT2SKZ TABLE
(
  BaPersonID INT,
  SKZNummer  INT
)

DECLARE @UT2HeimatNr_Rekurs TABLE
(
  BaPersonID                       INT,
  WVCode                           INT,
  BEDCode                          INT,
  HeimatkantonNr                   VARCHAR(20),
  Rekurs                           DATETIME,
  RekursMutiertUserID              INT,
  RekursMutiertDatum               DATETIME,
  RekursAbgeschlossen              DATETIME,
  RekursAbgeschlossenMutiertUserID INT,
  RekursAbgeschlossenMutiertDatum  DATETIME
)

DECLARE @Count INT;
DECLARE @BetroffeneUT VARCHAR(200);
DECLARE @Message VARCHAR(MAX);


INSERT INTO @UT2SKZ (BaPersonID, SKZNummer)
SELECT BaPersonID, MAX(SKZNummer)
FROM WhSKZNummer
WHERE BaPersonID IN (SELECT BaPersonID FROM @WhWVEinheit) OR
      BaPersonID IN (SELECT BaPersonID FROM dbo.WhWVEinheit WHERE FaFallID = @FaFallID AND Ungueltig = 0)
GROUP BY BaPersonID

-- Prüfen ob SKZNummer eindeutig ist
SELECT @msg = 'Folgende Unterstützungsträger haben unterschiedliche KSA-Nummern' + dbo.ConcDistinct(CHAR(13) + CHAR(10) + 'Person ' + CAST(BaPersonID AS VARCHAR(30)) + ': KSANummern ' + Nummern), @Count = SUM(Anzahl)
FROM
(
  SELECT U2S.BaPersonID, Nummern = dbo.ConcDistinct(U2S.SKZNummer) + ',' + dbo.ConcDistinct(' '+ CAST(WVE.SKZNummer AS VARCHAR(30)) + CASE WHEN WVE.FaFallID <> @FaFallID THEN '(Fall '+ CAST(WVE.FaFallID AS VARCHAR(30)) + ')' ELSE '' END), Anzahl = COUNT(*)
  FROM @UT2SKZ U2S
    INNER JOIN dbo.WhWVEinheit WVE ON WVE.BaPersonID = U2S.BaPersonID AND
                                      WVE.SKZNummer IS NOT NULL AND WVE.SKZNummer <> U2S.SKZNummer
  GROUP BY U2S.BaPersonID
) TMP

IF @Count > 0 BEGIN
  RAISERROR(@msg, 18, 1)
  RETURN
END

-- HeimatkantonNr und Rekursverfahren-Daten bestimmen
/*
INSERT INTO @UT2HeimatNr_Rekurs (BaPersonID, WVCode, BEDCode, HeimatkantonNr, Rekurs, RekursMutiertUserID, RekursMutiertDatum, 
                                 RekursAbgeschlossen, RekursAbgeschlossenMutiertUserID, RekursAbgeschlossenMutiertDatum)
SELECT BaPersonID, WVCode, BEDCode, MAX(HeimatkantonNr), MAX(Rekurs), MAX(RekursMutiertUserID), MAX(RekursMutiertDatum),
       MAX(RekursAbgeschlossen), MAX(RekursAbgeschlossenMutiertUserID), MAX(RekursAbgeschlossenMutiertDatum)
FROM dbo.WhWVEinheit
WHERE BaPersonID IN (SELECT BaPersonID FROM @WhWVEinheit) OR
      BaPersonID IN (SELECT BaPersonID FROM dbo.WhWVEinheit WHERE FaFallID = @FaFallID AND Ungueltig = 0)
GROUP BY BaPersonID, WVCode, BEDCode
*/

INSERT INTO @UT2HeimatNr_Rekurs (BaPersonID, WVCode, BEDCode, HeimatkantonNr, Rekurs, RekursMutiertUserID, RekursMutiertDatum, 
                                 RekursAbgeschlossen, RekursAbgeschlossenMutiertUserID, RekursAbgeschlossenMutiertDatum)
SELECT BaPersonID, WVCode, BEDCode, MAX(HeimatkantonNr), MAX(Rekurs), MAX(RekursMutiertUserID), MAX(RekursMutiertDatum),
       MAX(RekursAbgeschlossen), MAX(RekursAbgeschlossenMutiertUserID), MAX(RekursAbgeschlossenMutiertDatum)
FROM WhHeimatKantonNr_Rekurs
WHERE BaPersonID IN (SELECT BaPersonID FROM @WhWVEinheit) OR
      BaPersonID IN (SELECT BaPersonID FROM dbo.WhWVEinheit WHERE FaFallID = @FaFallID AND Ungueltig = 0)
GROUP BY BaPersonID, WVCode, BEDCode

-- HeimatkantonNr eindeutig?
SELECT @msg = 'Folgende Unterstützungsträger haben unterschiedliche Heimatkanton-Nummern' + dbo.ConcDistinct(CHAR(13) + CHAR(10) + 'Person ' + CAST(BaPersonID AS VARCHAR(30)) + ' / BED ' + CAST(BEDCode AS VARCHAR(30)) + ': Heimatkanton-Nummern ' + Nummern), @Count = SUM(Anzahl)
FROM
(
  SELECT U2H.BaPersonID, U2H.BEDCode, Nummern = dbo.ConcDistinct(U2H.HeimatkantonNr) + ',' + dbo.ConcDistinct(CAST(WVE.HeimatkantonNr AS VARCHAR(30)) + CASE WHEN WVE.FaFallID <> @FaFallID THEN '(Fall '+ CAST(WVE.FaFallID AS VARCHAR(30)) + ')' ELSE '' END), Anzahl = COUNT(*)
  FROM @UT2HeimatNr_Rekurs U2H
    INNER JOIN dbo.WhWVEinheit WVE ON WVE.BaPersonID = U2H.BaPersonID AND
                                      WVE.BEDCode    = U2H.BEDCode AND
                                      WVE.HeimatkantonNr IS NOT NULL AND WVE.HeimatkantonNr <> U2H.HeimatkantonNr
  GROUP BY U2H.BaPersonID, U2H.BEDCode
) TMP

IF @Count > 0 BEGIN
  RAISERROR(@msg, 18, 1)
  RETURN
END

-- HeimatkantonNr eindeutig?
SELECT @msg = 'Folgende Unterstützungsträger haben unterschiedliche Angaben zu Rekursvervahren:' + dbo.ConcDistinct(CHAR(13) + CHAR(10) + 'Person ' + CAST(BaPersonID AS VARCHAR(30)) + ' / BED ' + CAST(BEDCode AS VARCHAR(30)) + ': ' + Datums), @Count = SUM(Anzahl)
FROM
(
  SELECT U2H.BaPersonID,
         U2H.BEDCode,
         Datums = dbo.ConcDistinct('Rekurs ' + CONVERT(VARCHAR, U2H.Rekurs, 104) + 
                                   CASE WHEN U2H.RekursAbgeschlossen IS NOT NULL THEN ', Rekurs abgeschlossen ' + CONVERT(VARCHAR, U2H.RekursAbgeschlossen, 104) ELSE '' END +
                                   CASE WHEN WVE.FaFallID <> @FaFallID THEN '(Fall '+ CAST(WVE.FaFallID AS VARCHAR(30)) + ')'
                                                                       ELSE ''
                                   END),
         Anzahl = COUNT(*)
  FROM @UT2HeimatNr_Rekurs U2H
    INNER JOIN dbo.WhWVEinheit WVE ON WVE.BaPersonID = U2H.BaPersonID AND
                                      WVE.BEDCode    = U2H.BEDCode AND
                                      (
                                        WVE.Rekurs              IS NOT NULL AND WVE.Rekurs              <> U2H.Rekurs OR
                                        WVE.RekursAbgeschlossen IS NOT NULL AND WVE.RekursAbgeschlossen <> U2H.RekursAbgeschlossen
                                      )
  GROUP BY U2H.BaPersonID, U2H.BEDCode
) TMP

IF @Count > 0 BEGIN
  RAISERROR(@msg, 18, 1)
  RETURN
END


/*
VorgehenCode (bezieht sich jeweils auf IST-WV-Einheit):
 1: SOLL-Einheit mit gleichem BED, WVC, Mitglieder gefunden, IST-Verwendungsperioden werden durch den Zeitraum der SOLL-Einheit abgedeckt
    -> IST-Einheit beibehalten (manuell gewählter Träger wird nicht verändert), ggf. Zeitraum anpassen
 2: wie 1, aber eine SOLL-Einheit deckt die Verwendungsperioden von mehr als einer IST-Einheit ab
    -- oder --
    SOLL-Einheit mit gleichem BED, WVC gefunden & Verw-Zeitraum abgedeckt, SOLL hat zusätzliche Mitglieder (z.B. neues Kind) oder SOLL hat weniger Mitglieder, die aber im IST nicht bebucht wurden
    -> SOLL-Einheit verwenden, die Einzelposten werden von den IST-Einheiten an die SOLL-Einheit umgehängt
 3: IST-Einheit kann nicht übernommen werden
*/


-- Dieses Statement verursacht normalerweise eine Warnung 'Warning: Null value is eliminated by an aggregate or other SET operation.'
INSERT INTO @BestehendeWVEinheitenVerwertbar(WhWVEinheitID, BEDCode, WVCode, DatumVon, DatumBis, VerwPeriodeMin, VerwPeriodeMax,
            BaPersonID, Mitglieder, BebuchteMitglieder, AnzahlEP)
SELECT WVE.WhWVEinheitID, WVE.BEDCode, WVE.WVCode, WVE.DatumVon, ISNULL(WVE.DatumBis,@DateMax), 
       VerwPeriodeMin = MIN(WVP.DatumVon),
       -- Bei Monatssplitting ist DatumBis das Ende des Monats, es zählt aber nur der erste des Monats.
       -- Deshalb darf dieses Datum nicht künstlich die bebuchte Verwendungsperiode verlängern
       VerwPeriodeMax = MAX(CASE WHEN WVP.BgSplittingArtCode = 2 THEN WVP.DatumVon ELSE WVP.DatumBis END),
       WVE.BaPersonID, dbo.ConcDistinctOrder(WVM.BaPersonID), dbo.ConcDistinctOrder(WVP.BeguenstigterBaPersonID), COUNT(DISTINCT WVP.KbWVEinzelpostenID)
FROM dbo.WhWVEinheit                 WVE
  INNER JOIN dbo.WhWVEinheitMitglied WVM ON WVM.WhWVEinheitID         = WVE.WhWVEinheitID
  LEFT  JOIN dbo.KbWVEinzelposten    WVP ON WVP.WhWVEinheitMitgliedID = WVM.WhWVEinheitMitgliedID
WHERE FaFallID = @FaFallID AND WVE.Ungueltig = 0
GROUP BY WVE.WhWVEinheitID, WVE.BEDCode, WVE.WVCode, WVE.DatumVon, WVE.DatumBis, WVE.BaPersonID


-- IST und SOLL identisch inkl. Mitglieder
UPDATE IST
SET VorgehenCode       = 1,
    WhWVEinheitID_SOLL = SOL.WhWVEinheitID
FROM @BestehendeWVEinheitenVerwertbar IST
  INNER JOIN (
               SELECT WVE.WhWVEinheitID, WVE.WVCode, WVE.BEDCode, WVE.DatumVon, WVE.DatumBis, Mitglieder = dbo.ConcDistinctOrder(WVM.BaPersonID)
               FROM @WhWVEinheit                 WVE
                 INNER JOIN @WhWVEinheitMitglied WVM ON WVE.WhWVEinheitID = WVM.WhWVEinheitID
               GROUP BY WVE.WhWVEinheitID, WVE.WVCode, WVE.BEDCode, WVE.DatumVon, WVE.DatumBis
             ) SOL ON SOL.BEDCode    = IST.BEDCode AND
                      SOL.WVCode     = IST.WVCode AND
                      SOL.Mitglieder = IST.Mitglieder AND
                     (IST.AnzahlEP = 0 AND dbo.fnDatumUeberschneidung(SOL.DatumVon,SOL.DatumBis,IST.DatumVon,IST.DatumBis) = 1 OR 
                      SOL.DatumVon  <= IST.VerwPeriodeMin AND
                      SOL.DatumBis  >= IST.VerwPeriodeMax)

-- IST wird von SOLL abgedeckt, SOLL hat mindestens die bebuchten Mitglieder von IST
-- Dieses Statement verursacht normalerweise eine Warnung 'Warning: Null value is eliminated by an aggregate or other SET operation.'
UPDATE UPD
SET VorgehenCode       = 2,
    WhWVEinheitID_SOLL = TMP.ID_Soll
FROM @BestehendeWVEinheitenVerwertbar UPD
  INNER JOIN (SELECT ID_Ist = MAP.WhWVEinheitID, ID_Soll = TME.WhWVEinheitID
              FROM @BestehendeWVEinheitenVerwertbar MAP
                INNER JOIN @WhWVEinheit             TME ON TME.BEDCode     = MAP.BEDCode AND
                                                           TME.WVCode      = MAP.WVCode AND
                                                          (MAP.AnzahlEP = 0 AND dbo.fnDatumUeberschneidung(TME.DatumVon,TME.DatumBis,MAP.DatumVon,MAP.DatumBis) = 1 OR 
                                                           TME.DatumVon   <= MAP.VerwPeriodeMin AND
                                                           TME.DatumBis   >= MAP.VerwPeriodeMax)
                LEFT  JOIN dbo.WhWVEinheitMitglied  IST ON IST.WhWVEinheitID         = MAP.WhWVEinheitID
                LEFT  JOIN dbo.KbWVEinzelposten     WVP ON WVP.WhWVEinheitMitgliedID = IST.WhWVEinheitMitgliedID
                LEFT  JOIN @WhWVEinheitMitglied     SOP ON SOP.WhWVEinheitID         = TME.WhWVEinheitID AND
                                                           SOP.BaPersonID            = WVP.BeguenstigterBaPersonID
                LEFT  JOIN @WhWVEinheitMitglied     SOT ON SOT.WhWVEinheitID         = TME.WhWVEinheitID AND
                                                           SOT.BaPersonID            = WVP.UnterstuetzungstraegerBaPersonID
              WHERE MAP.VorgehenCode IS NULL
              GROUP BY MAP.WhWVEinheitID, TME.WhWVEinheitID
              HAVING COUNT(DISTINCT WVP.BeguenstigterBaPersonID)          >  0                              AND -- EPs vorhanden
                     COUNT(DISTINCT WVP.BeguenstigterBaPersonID)          <= COUNT(DISTINCT SOP.BaPersonID) AND -- Anzahl IST bebucht <= Anzahl SOLL gleich wie bebucht. NULL wird nicht mitgezählt
                     COUNT(DISTINCT WVP.UnterstuetzungstraegerBaPersonID) <= COUNT(DISTINCT SOT.BaPersonID)     -- alle bebuchten UTs müssen in der neuen WV-Einheit vorhanden sein
                                                                                                                -- falls der UT nicht bebucht wurde, entstehen sonst Inkonsistenzen
             ) TMP ON TMP.ID_Ist = UPD.WhWVEinheitID


-- Vorgehen ist anders, wenn eine SOLL-Einheit mehr als eine IST-Einheiten abdeckt
UPDATE @BestehendeWVEinheitenVerwertbar
SET VorgehenCode = CASE WHEN VorgehenCode = 1 THEN 2 ELSE VorgehenCode END
WHERE WhWVEinheitID_SOLL IN
(
  SELECT WhWVEinheitID_SOLL
  FROM @BestehendeWVEinheitenVerwertbar
  WHERE WhWVEinheitID_SOLL IS NOT NULL
  GROUP BY WhWVEinheitID_SOLL
  HAVING COUNT(*) > 1
)


-- Die restlichen Konstellationen werden per Gutschrift & Neuverrechnung angepasst
UPDATE @BestehendeWVEinheitenVerwertbar
SET VorgehenCode = 3
WHERE VorgehenCode IS NULL


-- Träger bestimmen für VorgehenCode 2
-- bestehenden Träger übernehmen, wenn nicht eindeutig, nichts übernehmen -> Vorschlag für SOLL wird übernommen
UPDATE WVE
SET BaPersonID = ALT.BaPersonID
FROM @WhWVEinheit WVE
  INNER JOIN @WhWVEinheitMitglied WVM ON WVM.WhWVEinheitID = WVE.WhWVEinheitID
  INNER JOIN (SELECT WhWVEinheitID_SOLL, BaPersonID = MIN(MAP.BaPersonID)
              FROM @BestehendeWVEinheitenVerwertbar MAP
                INNER JOIN dbo.WhWVEinheit          IST ON IST.WhWVEinheitID = MAP.WhWVEinheitID
              WHERE VorgehenCode = 2
              GROUP BY WhWVEinheitID_SOLL
              HAVING COUNT(DISTINCT MAP.BaPersonID) = 1) ALT ON ALT.WhWVEinheitID_SOLL = WVE.WhWVEinheitID AND
                                                                ALT.BaPersonID = WVM.BaPersonID -- bestehender Träger muss auch in SOLL-Einheit vorkommen!

-- genaueres Bestimmen des Trägers, z.B. wenn die Zusammenstellung der Einheit geändert hat, der Träger aber immer noch dabei ist.
UPDATE WVE
SET BaPersonID = TMP.BaPersonID
FROM @WhWVEinheit WVE
  INNER JOIN 
(
SELECT WES.WhWVEinheitID, WEI.BaPersonID
FROM @WhWVEinheit                    WES
  INNER JOIN dbo.WhWVEinheit         WEI ON WEI.FaFallID      = WES.FaFallID AND 
                                            WEI.Ungueltig     = 0 AND
                                            WEI.BEDCode       = WES.BEDCode AND
                                            WEI.WVCode        = WES.WVCode AND
                                            dbo.fnDatumUeberschneidung(WES.DatumVon, WES.DatumBis, WEI.DatumVon, ISNULL(WEI.DatumBis, @DateMax)) = 1 
  INNER JOIN @WhWVEinheitMitglied    WMS ON WMS.WhWVEinheitID = WES.WhWVEinheitID
  LEFT  JOIN dbo.WhWVEinheitMitglied WMI ON WMI.WhWVEinheitID = WEI.WhWVEinheitID AND
                                            WMI.BaPersonID    = WMS.BaPersonID
  INNER JOIN dbo.WhWVEinheitMitglied WTI ON WTI.WhWVEinheitID = WEI.WhWVEinheitID AND
                                            WTI.BaPersonID    = WEI.BaPersonID    AND --UT
                                            WTI.BaPersonID    = WMS.BaPersonID
GROUP BY WES.WhWVEinheitID, WEI.WhWVEinheitID, WEI.BaPersonID
HAVING COUNT(DISTINCT WMS.BaPersonID) <= COUNT(DISTINCT WMI.BaPersonID) -- Anzahl IST bebucht <= Anzahl SOLL gleich wie bebucht. NULL wird nicht mitgezählt
) TMP ON TMP.WhWVEinheitID = WVE.WhWVEinheitID


-- Nun ist klar, was gemacht werden soll, let's do it
BEGIN TRY
  BEGIN TRAN

/*
select 'vorher', WVE.WhWVEinheitID, CONVERT(VARCHAR,WVE.DatumVon,104),CONVERT(VARCHAR,WVE.DatumBis,104), WVE.BaPersonID, WVE.Ungueltig, WVE.WVCode, WVE.BEDCode, Mitglieder = dbo.ConcDistinctOrder(WVM.BaPersonID), AnzahlEP = COUNT(WVP.KbWVEinzelpostenID)
from   dbo.WhWVEinheit               WVE
  inner join dbo.WhWVEinheitMitglied WVM ON WVM.WhWVEinheitID = WVE.WhWVEinheitID
  LEFT  JOIN dbo.KbWVEinzelposten    WVP ON WVP.WhWVEinheitMitgliedID = WVM.WhWVEinheitMitgliedID
where  FaFallID = @FaFallID
group by WVE.WhWVEinheitID, WVE.DatumVon, WVE.DatumBis, WVE.BaPersonID, WVE.Ungueltig, WVE.WVCode, WVE.BEDCode
order by WVE.WhWVEinheitID
*/

  -- Alle IST-Einheiten, die nicht übernommen werden (VorgehenCode = 1), werden ungültig
  UPDATE WhWVEinheit
  SET Ungueltig = 1
  WHERE FaFallID = @FaFallID AND WhWVEinheitID NOT IN 
  (
    SELECT WhWVEinheitID
    FROM @BestehendeWVEinheitenVerwertbar
    WHERE VorgehenCode = 1
  )

  -- Zeitraum der bestehenden Einheit anpassen falls nötig
  UPDATE IST
  SET DatumVon = SOL.DatumVon, DatumBis = CASE WHEN SOL.DatumBis < @DateMax THEN SOL.DatumBis END
  FROM dbo.WhWVEinheit                          IST
    INNER JOIN @BestehendeWVEinheitenVerwertbar MAP ON IST.WhWVEinheitID = MAP.WhWVEinheitID
    INNER JOIN @WhWVEinheit                     SOL ON SOL.WhWVEinheitID = MAP.WhWVEinheitID_SOLL
  WHERE MAP.VorgehenCode = 1 AND (IST.DatumVon <> SOL.DatumVon OR ISNULL(IST.DatumBis,@DateMax) <> ISNULL(SOL.DatumBis,@DateMax))

  DECLARE @WhWVEinheitID_tmp INT,
          @VorgehenCode      INT

  DECLARE cWVEinheiten CURSOR LOCAL FAST_FORWARD FOR
    SELECT DISTINCT WVE.WhWVEinheitID, MAP.VorgehenCode
    FROM @WhWVEinheit                            WVE
      LEFT JOIN @BestehendeWVEinheitenVerwertbar MAP ON MAP.WhWVEinheitID_SOLL = WVE.WhWVEinheitID
    WHERE WVE.WhWVEinheitID NOT IN (SELECT WhWVEinheitID_SOLL FROM @BestehendeWVEinheitenVerwertbar WHERE VorgehenCode IN (1))

  OPEN cWVEinheiten
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cWVEinheiten INTO @WhWVEinheitID_tmp, @VorgehenCode
    IF @@FETCH_STATUS <> 0 BREAK

      -- SOLL-Einheit in echten Tabellen erstellen
      INSERT INTO WhWVEinheit(FaFallID, DatumVon, DatumBis, BaPersonID, WVCode, BEDCode)
        SELECT FaFallID, DatumVon, CASE WHEN DatumBis < @DateMax THEN DatumBis END, BaPersonID, WVCode, BEDCode
        FROM @WhWVEinheit
        WHERE WhWVEinheitID = @WhWVEinheitID_tmp
      SET @WhWVEinheitID_insert = SCOPE_IDENTITY()
      INSERT INTO WhWVEinheitMitglied(WhWVEinheitID, BaPersonID, BaWVCodeID)
        SELECT @WhWVEinheitID_insert, BaPersonID, BaWVCodeID
        FROM @WhWVEinheitMitglied
        WHERE WhWVEinheitID = @WhWVEinheitID_tmp

      IF @VorgehenCode = 2 BEGIN
        -- Einzelposten von den abgelösten IST-Einheiten an die SOLL-Einheit umhängen
        UPDATE WEP
        SET WhWVEinheitMitgliedID = NEU.WhWVEinheitMitgliedID
        FROM @BestehendeWVEinheitenVerwertbar MAP
          INNER JOIN dbo.WhWVEinheitMitglied  ALT ON ALT.WhWVEinheitID         = MAP.WhWVEinheitID
          INNER JOIN dbo.KbWVEinzelposten     WEP ON WEP.WhWVEinheitMitgliedID = ALT.WhWVEinheitMitgliedID
          INNER JOIN dbo.WhWVEinheitMitglied  NEU ON NEU.WhWVEinheitID         = @WhWVEinheitID_insert AND
                                                     NEU.BaPersonID            = ALT.BaPersonID
        WHERE MAP.WhWVEinheitID_SOLL = @WhWVEinheitID_tmp

        -- alte WV-Einheiten löschen, es dürfen keine EPs mehr daran hängen
        DELETE WVE
        FROM dbo.WhWVEinheit WVE
          INNER JOIN @BestehendeWVEinheitenVerwertbar MAP ON MAP.WhWVEinheitID_SOLL = WVE.WhWVEinheitID
        WHERE MAP.WhWVEinheitID_SOLL = @WhWVEinheitID_tmp
      END

  END
  CLOSE cWVEinheiten
  DEALLOCATE cWVEinheiten

  -- Ungültige Einheiten ohne Einzelposten löschen
  DELETE dbo.WhWVEinheit
  WHERE FaFallID = @FaFallID AND Ungueltig = 1 AND WhWVEinheitID NOT IN
  (
    SELECT WVM.WhWVEinheitID
    FROM dbo.WhWVEinheitMitglied      WVM
      INNER JOIN dbo.KbWVEinzelposten WEP ON WEP.WhWVEinheitMitgliedID = WVM.WhWVEinheitMitgliedID
    WHERE WVM.WhWVEinheitID IS NOT NULL
  )

  -- Attribute von UT setzen
  -- SKZNummer
  UPDATE WVE
  SET SKZNummer = MAP.SKZNummer
  FROM dbo.WhWVEinheit WVE
    INNER JOIN @UT2SKZ MAP ON MAP.BaPersonID = WVE.BaPersonID AND
                              MAP.SKZNummer IS NOT NULL AND MAP.SKZNummer <> ISNULL(WVE.SKZNummer,-1)
    INNER JOIN dbo.XLOVCode    WVC ON WVC.LOVName = 'BaWVCode' AND
                                      WVC.Code = WVE.WVCode AND
                                      WVC.ShortText NOT LIKE '_-E'
  WHERE FaFallID = @FaFallID AND Ungueltig = 0

  -- HeimatkantonNr
  UPDATE WVE
  SET HeimatkantonNr = MAP.HeimatkantonNr
  FROM dbo.WhWVEinheit             WVE
    INNER JOIN @UT2HeimatNr_Rekurs MAP ON MAP.BaPersonID = WVE.BaPersonID AND
                                   MAP.BEDCode           = WVE.BEDCode AND
                                   MAP.HeimatkantonNr IS NOT NULL AND MAP.HeimatkantonNr <> ISNULL(WVE.HeimatkantonNr,'')
  WHERE FaFallID = @FaFallID AND Ungueltig = 0

  -- Rekursverfahren
  UPDATE WVE
  SET Rekurs = MAP.Rekurs,
      RekursAbgeschlossen = MAP.RekursAbgeschlossen
  FROM dbo.WhWVEinheit             WVE
    INNER JOIN @UT2HeimatNr_Rekurs MAP ON MAP.BaPersonID = WVE.BaPersonID AND
                                   MAP.BEDCode = WVE.BEDCode AND
                                   (
                                     MAP.Rekurs IS NOT NULL AND MAP.Rekurs <> ISNULL(WVE.Rekurs,'') OR
                                     MAP.RekursAbgeschlossen IS NOT NULL AND MAP.RekursAbgeschlossen <> ISNULL(WVE.RekursAbgeschlossen,'')
                                   )
  WHERE FaFallID = @FaFallID AND Ungueltig = 0

/*
select 'nachher', WVE.WhWVEinheitID, CONVERT(VARCHAR,WVE.DatumVon,104),CONVERT(VARCHAR,WVE.DatumBis,104), WVE.BaPersonID, WVE.Ungueltig, WVE.WVCode, WVE.BEDCode, Mitglieder = dbo.ConcDistinctOrder(WVM.BaPersonID), AnzahlEP = COUNT(WVP.KbWVEinzelpostenID)
from   dbo.WhWVEinheit               WVE
  inner join dbo.WhWVEinheitMitglied WVM ON WVM.WhWVEinheitID = WVE.WhWVEinheitID
  LEFT  JOIN dbo.KbWVEinzelposten    WVP ON WVP.WhWVEinheitMitgliedID = WVM.WhWVEinheitMitgliedID
where  FaFallID = @FaFallID
group by WVE.WhWVEinheitID, WVE.DatumVon, WVE.DatumBis, WVE.BaPersonID, WVE.Ungueltig, WVE.WVCode, WVE.BEDCode
order by WVE.WhWVEinheitID

SELECT 'IST', WhWVEinheitID, BEDCode, WVCode, CONVERT(VARCHAR,DatumVon,104), CONVERT(VARCHAR,DatumBis,104), CONVERT(VARCHAR,VerwPeriodeMin,104), CONVERT(VARCHAR,VerwPeriodeMax,104),
              BaPersonID, Mitglieder, BebuchteMitglieder, AnzahlEP, VorgehenCode, WVEID_Soll = WhWVEinheitID_SOLL
FROM @BestehendeWVEinheitenVerwertbar
*/

  --rollback
  COMMIT  
END TRY
BEGIN CATCH
  ROLLBACK
  DECLARE @errormsg varchar(500)
  SET @errormsg = ERROR_MESSAGE()
  RAISERROR(@errormsg,18,1)  
END CATCH

END

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
