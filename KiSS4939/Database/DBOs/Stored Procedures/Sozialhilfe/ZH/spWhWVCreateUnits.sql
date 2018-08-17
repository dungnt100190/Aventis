SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhWVCreateUnits
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spWhWVCreateUnits
(
  @FaFallID int
)
AS BEGIN

--declare @FaFallID int
--set @FaFallID = 51052
--set @FaFallID = 50529

DECLARE @Dates TABLE
(
  date datetime
)
DECLARE @DateMax datetime,
        @msg varchar(500)
SET @DateMax = dbo.fnDateSerial(9999,12,31)
-- Hinweis, falls noch keine Personen einem Haushalt zugeordnet wurden
IF NOT EXISTS (SELECT *
               FROM dbo.FaFallPerson                  FAP WITH (READUNCOMMITTED) 
                 INNER JOIN dbo.FaLeistung            LEI WITH (READUNCOMMITTED) ON LEI.FaFallID       = FAP.FaFallID
                 INNER JOIN dbo.BgFinanzplan          BFP WITH (READUNCOMMITTED) ON BFP.FaLeistungID   = LEI.FaLeistungID
                 INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = BFP.BgFinanzplanID AND FPP.BaPersonID = FAP.BaPersonID
               WHERE FAP.FaFallID = @FaFallID AND FPP.IstUnterstuetzt = 1) BEGIN
  SET @msg = 'Bitte bestimmen Sie zuerst im Finanzplan die unterstützten Personen, damit für diese die WV-Einheiten erzeugt werden können'
  RAISERROR(@msg,18,1)
  RETURN
END

-- Alle Datums der WV-Codes dieses Falles bestimmen
-- auf diese werden die WV-Cdoes zerstückelt
INSERT INTO @Dates(date)
SELECT DISTINCT WVC.DatumVon
FROM dbo.FaFallPerson                  FAP WITH (READUNCOMMITTED) 
  INNER JOIN dbo.FaLeistung            LEI WITH (READUNCOMMITTED) ON LEI.FaFallID       = FAP.FaFallID
  INNER JOIN dbo.BgFinanzplan          BFP WITH (READUNCOMMITTED) ON BFP.FaLeistungID   = LEI.FaLeistungID
  INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = BFP.BgFinanzplanID AND FPP.BaPersonID = FAP.BaPersonID
  INNER JOIN dbo.BaWVCode              WVC WITH (READUNCOMMITTED) ON WVC.BaPersonID     = FPP.BaPersonID
WHERE FAP.FaFallID = @FaFallID AND WVC.BaWVStatusCode = 1 AND FPP.IstUnterstuetzt = 1
ORDER BY DatumVon

INSERT INTO @Dates(date)
SELECT DISTINCT IsNull(WVC.DatumBis, @DateMax)
FROM dbo.FaFallPerson                  FAP WITH (READUNCOMMITTED) 
  INNER JOIN dbo.FaLeistung            LEI WITH (READUNCOMMITTED) ON LEI.FaFallID       = FAP.FaFallID
  INNER JOIN dbo.BgFinanzplan          BFP WITH (READUNCOMMITTED) ON BFP.FaLeistungID   = LEI.FaLeistungID
  INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = BFP.BgFinanzplanID AND FPP.BaPersonID = FAP.BaPersonID
  INNER JOIN dbo.BaWVCode              WVC WITH (READUNCOMMITTED) ON WVC.BaPersonID     = FPP.BaPersonID
WHERE FAP.FaFallID = @FaFallID 
  AND FPP.IstUnterstuetzt = 1 
  AND WVC.BaWVStatusCode = 1 
  AND (WVC.DatumBis IS NULL 
    OR WVC.DatumBis NOT IN (SELECT date FROM @Dates) 
    AND DATEADD(day,1,WVC.DatumBis) NOT IN (SELECT date FROM @Dates))
ORDER BY IsNull(WVC.DatumBis, @DateMax)

-- Tabelle, welche die zerstückelten WV-Codes enthält
DECLARE @Splits TABLE
(
  SplitID      int IDENTITY(1,1),
  BaPersonID   int,
  DatumVon     datetime,
  DatumBis     datetime,
  WVCode       int,
  BaBedID      int,
  SKZNummer    varchar(50),
  SKZNummerInt int,
  WVUnitID     int NULL,
  BaWVCodeID   int
)

DECLARE @BaPersonID int
DECLARE @DatumVon datetime
DECLARE @DatumBis datetime
DECLARE @WVCode int
DECLARE @BaBedID int
DECLARE @date datetime
DECLARE @oldDate datetime
DECLARE @WVUnitID datetime
DECLARE @SKZNummer varchar(50)
DECLARE @BaWVCodeID int


DECLARE cCodes CURSOR FAST_FORWARD FOR
  SELECT DISTINCT WVC.BaPersonID, WVC.DatumVon, IsNull(WVC.DatumBis, @DateMax), WVC.WVCode, WVC.BaBedID, WVC.SKZNummer, WVC.BaWVCodeID
  FROM dbo.FaFallPerson                  FAP
    INNER JOIN dbo.FaLeistung            LEI ON LEI.FaFallID       = FAP.FaFallID
    INNER JOIN dbo.BgFinanzplan          BFP ON BFP.FaLeistungID   = LEI.FaLeistungID
    INNER JOIN dbo.BgFinanzplan_BaPerson FPP ON FPP.BgFinanzplanID = BFP.BgFinanzplanID AND FPP.BaPersonID = FAP.BaPersonID
    INNER JOIN dbo.BaWVCode              WVC ON WVC.BaPersonID     = FPP.BaPersonID
  WHERE FAP.FaFallID = @FaFallID AND WVC.BaWVStatusCode = 1 AND FPP.IstUnterstuetzt = 1
  ORDER BY BaPersonID

OPEN cCodes
WHILE 1=1 BEGIN
  FETCH NEXT FROM cCodes INTO @BaPersonID, @DatumVon, @DatumBis, @WVCode, @BaBedID, @SKZNummer, @BaWVCodeID
  IF @@FETCH_STATUS <> 0 BREAK

  SET @oldDate = @DatumVon

  DECLARE cDates CURSOR FAST_FORWARD FOR
    SELECT date
    FROM   @Dates
    WHERE  date > @DatumVon AND date < @DatumBis

  OPEN cDates
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cDates INTO @date
    IF @@FETCH_STATUS <> 0 BREAK

    INSERT INTO @Splits( BaPersonID, DatumVon, DatumBis, WVCode, BaBedID, SKZNummer, BaWVCodeID)
    VALUES (@BaPersonID, @oldDate, DATEADD(day,-1,@date), @WVCode, @BaBedID, @SKZNummer, @BaWVCodeID)
    
    SET @oldDate = @date
  END
  CLOSE cDates
  DEALLOCATE cDates
  
  IF @oldDate < @DatumBis BEGIN
    INSERT INTO @Splits( BaPersonID, DatumVon, DatumBis, WVCode, BaBedID, SKZNummer, BaWVCodeID)
    VALUES (@BaPersonID, @oldDate, @DatumBis, @WVCode, @BaBedID, @SKZNummer, @BaWVCodeID)
  END

END
CLOSE cCodes
DEALLOCATE cCodes

-- SKZ-Nr bestimmen (aus Personendaten)
DECLARE @SplitID int
DECLARE @SKZNr varchar(50)

DECLARE cUnits CURSOR FAST_FORWARD FOR
SELECT SplitID, SKZNummer
FROM   @Splits

OPEN cUnits
WHILE 1=1 BEGIN
  FETCH NEXT FROM cUnits INTO @SplitID, @SKZNr
  IF @@FETCH_STATUS <> 0 BREAK

  BEGIN TRY
    UPDATE @Splits
    SET    SKZNummerInt = CAST(REPLACE(REPLACE(REPLACE(@SKZNr,'''',''),' ',''),'.','') AS int)
    WHERE  SplitID = @SplitID
  END TRY
  BEGIN CATCH
  END CATCH
END
CLOSE cUnits
DEALLOCATE cUnits


DECLARE @WVUnits TABLE
(
  ID          int IDENTITY(1,1),
  DatumVon    datetime,
  DatumBis    datetime,
  WVCode      int,
  BaBedID     int,
  SKZNummerVC varchar(50),
  SKZNummer   int,
  Members     varchar(100)  
)
  SELECT DatumVon, IsNull(DatumBis,@DateMax), WVCode, BaBedID, dbo.ConcDistinctOrder(BaPersonID)
  FROM @Splits
  GROUP BY DatumVon, IsNull(DatumBis,@DateMax), WVCode, BaBedID

-- WV-Einheiten erstellen
INSERT INTO @WVUnits (DatumVon, DatumBis, WVCode, BaBedID, Members)
  SELECT DatumVon, IsNull(DatumBis,@DateMax), WVCode, BaBedID, dbo.ConcDistinctOrder(BaPersonID)
  FROM @Splits
  GROUP BY DatumVon, IsNull(DatumBis,@DateMax), WVCode, BaBedID

-- die Splits zu WV-Einheiten zuordnen
UPDATE SPL
SET WVUnitID = ID
FROM @Splits          SPL
  INNER JOIN @WVUnits WVU ON SPL.DatumVon = WVU.DatumVon AND IsNull(SPL.DatumBis,@DateMax) = IsNull(WVU.DatumBis,@DateMax) AND SPL.WVCode = WVU.WVCode AND SPL.BaBedID = WVU.BaBedID


/*
-- List all members in Unit (to compare) into the field Members
DECLARE cMembers CURSOR FAST_FORWARD FOR
  SELECT WVUnitID, BaPersonID
  FROM @WVUnits        WVU
    INNER JOIN @Splits SPL ON SPL.DatumVon = WVU.DatumVon AND IsNull(SPL.DatumBis,@DateMax) = IsNull(WVU.DatumBis,@DateMax) AND SPL.WVCode = WVU.WVCode AND SPL.BaBedID = WVU.BaBedID
  ORDER BY BaPersonID

OPEN cMembers
WHILE 1=1 BEGIN
  FETCH NEXT FROM cMembers INTO @WVUnitID, @BaPersonID
  IF @@FETCH_STATUS <> 0 BREAK

  UPDATE @WVUnits
  SET Members = IsNull(Members + ',','') + CAST(@BaPersonID AS varchar)
  WHERE ID = @WVUnitID
END
CLOSE cMembers
DEALLOCATE cMembers
*/

--select *, dbo.fnLOVText('BaWVCode', WVCode)
--from @WVUnits         WVU

-- join units (cursor is necessary because more than 2 units in a row can be joined)
DECLARE @Counter int
SET @Counter = 0
WHILE (@Counter = 0 OR (@@ROWCOUNT > 0 AND @Counter < 1000))
BEGIN
  SET @Counter = @Counter + 1

  UPDATE WVU
  SET DatumVon = CASE WHEN WVU.DatumVon < CMP.DatumVon THEN WVU.DatumVon ELSE CMP.DatumVon END,
      DatumBis = CASE WHEN WVU.DatumBis > CMP.DatumBis THEN WVU.DatumBis ELSE CMP.DatumBis END
  FROM @WVUnits         WVU
    INNER JOIN @WVUnits CMP ON WVU.WVCode = CMP.WVCode AND WVU.BaBedID = CMP.BaBedID AND WVU.Members = CMP.Members AND WVU.ID <> CMP.ID AND WVU.DatumBis = DATEADD(day,-1,CMP.DatumVon)
END 

--select DATEDIFF(day,WVU.DatumVon,WVU.DatumBis), DATEDIFF(day,CMP.DatumVon,CMP.DatumBis)
--from @WVUnits         WVU
--  INNER JOIN @WVUnits CMP ON WVU.WVCode = CMP.WVCode AND WVU.BaBedID = CMP.BaBedID AND WVU.Members = CMP.Members AND WVU.ID <> CMP.ID AND WVU.DatumBis = CMP.DatumBis AND DATEDIFF(day,WVU.DatumVon,WVU.DatumBis) < DATEDIFF(day,CMP.DatumVon,CMP.DatumBis)


DELETE WVU
FROM @WVUnits         WVU
  INNER JOIN @WVUnits CMP ON WVU.WVCode = CMP.WVCode AND WVU.BaBedID = CMP.BaBedID AND WVU.Members = CMP.Members AND WVU.ID <> CMP.ID AND WVU.DatumBis = CMP.DatumBis AND DATEDIFF(day,WVU.DatumVon,WVU.DatumBis) < DATEDIFF(day,CMP.DatumVon,CMP.DatumBis)

--select *
--from @WVUnits         WVU
-- ToDo: don't delete all, keep the unchanged units/members
DELETE FROM WhWVEinheitMitglied WHERE WhWVEinheitID IN (SELECT WhWVEinheitID FROM WhWVEinheit WHERE FaFallID = @FaFallID)
DELETE FROM WhWVEinheit WHERE FaFallID = @FaFallID 

INSERT INTO WhWVEinheit (FaFallID, DatumVon, DatumBis, WVCode, BEDCode, BaPersonID, SKZNummer)
SELECT @FaFallID, WVU.DatumVon, CASE WHEN WVU.DatumBis = @DateMax THEN NULL ELSE WVU.DatumBis END, WVU.WVCode, WVU.BaBedID, SPL.BaPersonID, SPL.SKZNummerInt
FROM   @WVUnits      WVU
  INNER JOIN @Splits SPL ON SplitID = (SELECT TOP 1 SplitID
                                       FROM   @Splits        SPLI
                                         INNER JOIN vwPerson PRS  ON PRS.BaPersonID = SPLI.BaPersonID
                                       WHERE  WVUnitID = WVU.ID
                                       ORDER BY CASE WHEN PRS.[Alter] >= 18 THEN GeschlechtCode ELSE GeschlechtCode + 10 END, PRS.[Alter] DESC)

--select *
--from   WhWVEinheit
--where  FaFallID = @FaFallID

INSERT INTO WhWVEinheitMitglied (WhWVEinheitID, BaPersonID, BaWVCodeID)
SELECT WVE.WhWVEinheitID, SPL.BaPersonID, SPL.BaWVCodeID
FROM   @WVUnits      WVU
  INNER JOIN @Splits SPL     ON SPL.WVUnitID = WVU.ID
  INNER JOIN WhWVEinheit WVE ON WVE.FaFallID = @FaFallID AND WVE.DatumVon = WVU.DatumVon AND IsNull(WVE.DatumBis,@DateMax) = IsNull(WVU.DatumBis,@DateMax) AND WVE.WVCode = WVU.WVCode AND WVE.BEDCode = WVU.BaBedID

--select MGL.*
--from   WhWVEinheit               WVE
--  inner join WhWVEinheitMitglied MGL ON MGL.WhWVEinheitID = WVE.WhWVEinheitID
--where  FaFallID = @FaFallID
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
