-----------------------------------------------------------------------------------------------------------------------------
-- #8787 - Anpassung GBL
-----------------------------------------------------------------------------------------------------------------------------
DECLARE @Stichtag DATETIME
DECLARE @BgFinanzplanID INT
DECLARE @PROCESS BIT

Set @Stichtag = '2013-05-31'
Set @PROCESS  = 1

----
-- Liste der 110/120/121-GBL Finanzpläne, die erst nach dem Stichtag geplant sind => Keine automatische Anpassung geplant
----

-- LA 110 - SKOS 2005/SKOS 2011 (Gültig ab 01.06.2013)
SELECT DISTINCT Fall=LEI.FaFallID, SA=USR.DisplayText, LT=LT.DisplayText, FT=FT.DisplayText, WMA=FT.Wohnsitz FROM dbo.BgFinanzplan FIP
  INNER JOIN dbo.BgBudget BUD   ON BUD.BgFinanzplanID = FIP.BgFinanzplanID AND MasterBudget = 1
  INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BUD.BgBudgetID  
  INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FIP.FaLeistungID
  INNER JOIN vwUser USR         ON USR.UserID = LEI.UserID
  INNER JOIN vwPerson LT        ON LT.BaPersonID = LEI.BaPersonID
  INNER JOIN FaFall FAL         ON FAL.FaFallID = LEI.FaFallID
  INNER JOIN vwPerson FT        ON FT.BaPersonID = FAL.BaPersonID
WHERE WhGrundbedarfTypCode IN (32015) 
  AND ISNULL(FIP.DatumVon, FIP.GeplantVon) >= @Stichtag
  AND ISNULL(FIP.Bemerkung, '') NOT LIKE 'Automatisch terminierter und wieder eröffneter Finanzplan per%'

-- LA 120 - GBL stationärer Aufenthalt
SELECT DISTINCT Fall=LEI.FaFallID, SA=USR.DisplayText, LT=LT.DisplayText, FT=FT.DisplayText, WMA=FT.Wohnsitz FROM dbo.BgFinanzplan FIP
  INNER JOIN dbo.BgBudget BUD   ON BUD.BgFinanzplanID = FIP.BgFinanzplanID AND MasterBudget = 1
  INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BUD.BgBudgetID  
  INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FIP.FaLeistungID
  INNER JOIN vwUser USR         ON USR.UserID = LEI.UserID
  INNER JOIN vwPerson LT        ON LT.BaPersonID = LEI.BaPersonID
  INNER JOIN FaFall FAL         ON FAL.FaFallID = LEI.FaFallID
  INNER JOIN vwPerson FT        ON FT.BaPersonID = FAL.BaPersonID
WHERE WhGrundbedarfTypCode IN (32019) 
  AND ISNULL(FIP.DatumVon, FIP.GeplantVon) >= @Stichtag  -- Beginnt nach dem Stichtag 
  AND ISNULL(FIP.Bemerkung, '') NOT LIKE 'Automatisch terminierter und wieder eröffneter Finanzplan per%'
  AND POS.Betrag <> 0
  AND POS.BgPositionsartID IN
(
3102,
32015,
32019,
40262,
40263,
40264,
40490
)

-- LA 121 - GBL Spezialsituation
SELECT DISTINCT Fall=LEI.FaFallID, SA=USR.DisplayText, LT=LT.DisplayText, FT=FT.DisplayText, WMA=FT.Wohnsitz FROM dbo.BgFinanzplan FIP
  INNER JOIN dbo.BgBudget BUD   ON BUD.BgFinanzplanID = FIP.BgFinanzplanID AND MasterBudget = 1
  INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BUD.BgBudgetID  
  INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FIP.FaLeistungID
  INNER JOIN vwUser USR         ON USR.UserID = LEI.UserID
  INNER JOIN vwPerson LT        ON LT.BaPersonID = LEI.BaPersonID
  INNER JOIN FaFall FAL         ON FAL.FaFallID = LEI.FaFallID
  INNER JOIN vwPerson FT        ON FT.BaPersonID = FAL.BaPersonID
WHERE WhGrundbedarfTypCode IN (3102) 
  AND ISNULL(FIP.DatumVon, FIP.GeplantVon) >= @Stichtag  -- Beginnt nach dem Stichtag 
  AND ISNULL(FIP.Bemerkung, '') NOT LIKE 'Automatisch terminierter und wieder eröffneter Finanzplan per%'
  AND POS.Betrag <> 0
  AND POS.BgPositionsartID IN
(
3102,
32015,
32019,
40262,
40263,
40264,
40490
)

----
-- Automatische Korrektur der normalen 110-GBL
----
SELECT DISTINCT Fall=LEI.FaFallID, SA=USR.DisplayText, LT=LT.DisplayText, FT=FT.DisplayText, WMA=FT.Wohnsitz FROM dbo.BgFinanzplan FIP
  INNER JOIN dbo.BgBudget BUD   ON BUD.BgFinanzplanID = FIP.BgFinanzplanID AND MasterBudget = 1
  INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BUD.BgBudgetID  
  INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FIP.FaLeistungID
  INNER JOIN vwUser USR         ON USR.UserID = LEI.UserID
  INNER JOIN vwPerson LT        ON LT.BaPersonID = LEI.BaPersonID
  INNER JOIN FaFall FAL         ON FAL.FaFallID = LEI.FaFallID
  INNER JOIN vwPerson FT        ON FT.BaPersonID = FAL.BaPersonID
WHERE WhGrundbedarfTypCode IN (32015) 
  AND ISNULL(FIP.DatumVon, FIP.GeplantVon) < @Stichtag  -- Beginnt vor dem Stichtag 
  AND ISNULL(FIP.DatumBis, FIP.GeplantBis) > @Stichtag  -- Läuft über den Stichtag hinaus

IF @PROCESS = 1 BEGIN
  DECLARE cur CURSOR FOR 
  SELECT DISTINCT FIP.BgFinanzplanID FROM dbo.BgFinanzplan FIP
    INNER JOIN dbo.BgBudget BUD   ON BUD.BgFinanzplanID = FIP.BgFinanzplanID AND MasterBudget = 1
    INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BUD.BgBudgetID  
    INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FIP.FaLeistungID
  WHERE WhGrundbedarfTypCode IN (32015) 
    AND ISNULL(FIP.DatumVon, FIP.GeplantVon) < @Stichtag  -- Beginnt vor dem Stichtag 
    AND ISNULL(FIP.DatumBis, FIP.GeplantBis) > @Stichtag  -- Läuft über den Stichtag hinaus

  OPEN cur
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cur INTO @BgFinanzplanID
    IF @@FETCH_STATUS <> 0 BREAK

	  EXEC #spTEMPFinanzplanBeendenUndWiedereroeffnen @BgFinanzplanID, @Stichtag
  END
  CLOSE cur
  DEALLOCATE cur
END

----
-- Automatische Korrektur der 120-GBL (LA 120 - GBL stationärer Aufenthalt)
----
SELECT DISTINCT Fall=LEI.FaFallID, SA=USR.DisplayText, LT=LT.DisplayText, FT=FT.DisplayText, WMA=FT.Wohnsitz FROM dbo.BgFinanzplan FIP
  INNER JOIN dbo.BgBudget BUD   ON BUD.BgFinanzplanID = FIP.BgFinanzplanID AND MasterBudget = 1
  INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BUD.BgBudgetID  
  INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FIP.FaLeistungID
  INNER JOIN vwUser USR         ON USR.UserID = LEI.UserID
  INNER JOIN vwPerson LT        ON LT.BaPersonID = LEI.BaPersonID
  INNER JOIN FaFall FAL         ON FAL.FaFallID = LEI.FaFallID
  INNER JOIN vwPerson FT        ON FT.BaPersonID = FAL.BaPersonID
WHERE WhGrundbedarfTypCode IN (32019) 
  AND ISNULL(FIP.DatumVon, FIP.GeplantVon) < @Stichtag  -- Beginnt vor dem Stichtag 
  AND ISNULL(FIP.DatumBis, FIP.GeplantBis) > @Stichtag  -- Läuft über den Stichtag hinaus
  AND POS.Betrag <> 0
  AND POS.BgPositionsartID IN
(
3102,
32015,
32019,
40262,
40263,
40264,
40490
)

IF @PROCESS = 1 BEGIN
  DECLARE cur2 CURSOR FOR 
  SELECT distinct FIP.BgFinanzplanID FROM dbo.BgFinanzplan FIP
    INNER JOIN dbo.BgBudget BUD   ON BUD.BgFinanzplanID = FIP.BgFinanzplanID AND MasterBudget = 1
    INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BUD.BgBudgetID  
    INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FIP.FaLeistungID
  WHERE WhGrundbedarfTypCode IN (32019) 
    AND ISNULL(FIP.DatumVon, FIP.GeplantVon) < @Stichtag  -- Beginnt vor dem Stichtag 
    AND ISNULL(FIP.DatumBis, FIP.GeplantBis) > @Stichtag  -- Läuft über den Stichtag hinaus
    AND POS.Betrag <> 0
    AND POS.BgPositionsartID IN
  (
  3102,
  32015,
  32019,
  40262,
  40263,
  40264,
  40490
  )

  OPEN cur2
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cur2 INTO @BgFinanzplanID
    IF @@FETCH_STATUS <> 0 BREAK

	  EXEC #spTEMPFinanzplanBeendenUndWiedereroeffnen @BgFinanzplanID, @Stichtag
  END
  CLOSE cur2
  DEALLOCATE cur2
END

----
-- Automatische Korrektur der 121-GBL (LA 121 - GBL Spezialsituation)
----
SELECT DISTINCT Fall=LEI.FaFallID, SA=USR.DisplayText, LT=LT.DisplayText, FT=FT.DisplayText, WMA=FT.Wohnsitz FROM dbo.BgFinanzplan FIP
  INNER JOIN dbo.BgBudget BUD   ON BUD.BgFinanzplanID = FIP.BgFinanzplanID AND MasterBudget = 1
  INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BUD.BgBudgetID  
  INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FIP.FaLeistungID
  INNER JOIN vwUser USR         ON USR.UserID = LEI.UserID
  INNER JOIN vwPerson LT        ON LT.BaPersonID = LEI.BaPersonID
  INNER JOIN FaFall FAL         ON FAL.FaFallID = LEI.FaFallID
  INNER JOIN vwPerson FT        ON FT.BaPersonID = FAL.BaPersonID
WHERE WhGrundbedarfTypCode IN (3102) 
  AND ISNULL(FIP.DatumVon, FIP.GeplantVon) < @Stichtag  -- Beginnt vor dem Stichtag 
  AND ISNULL(FIP.DatumBis, FIP.GeplantBis) > @Stichtag  -- Läuft über den Stichtag hinaus
  AND POS.Betrag <> 0
  AND POS.BgPositionsartID IN
(
3102,
32015,
32019,
40262,
40263,
40264,
40490
)

IF @PROCESS = 1 BEGIN
  DECLARE cur3 CURSOR FOR 
  SELECT DISTINCT FIP.BgFinanzplanID FROM dbo.BgFinanzplan FIP
    INNER JOIN dbo.BgBudget BUD   ON BUD.BgFinanzplanID = FIP.BgFinanzplanID AND MasterBudget = 1
    INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BUD.BgBudgetID  
    INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FIP.FaLeistungID
  WHERE WhGrundbedarfTypCode IN (3102) 
    AND ISNULL(FIP.DatumVon, FIP.GeplantVon) < @Stichtag  -- Beginnt vor dem Stichtag 
    AND ISNULL(FIP.DatumBis, FIP.GeplantBis) > @Stichtag  -- Läuft über den Stichtag hinaus
    AND POS.Betrag <> 0
    AND POS.BgPositionsartID IN
  (
  3102,
  32015,
  32019,
  40262,
  40263,
  40264,
  40490
  )

  OPEN cur3
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cur3 INTO @BgFinanzplanID
    IF @@FETCH_STATUS <> 0 BREAK

	  EXEC #spTEMPFinanzplanBeendenUndWiedereroeffnen @BgFinanzplanID, @Stichtag
  END
  CLOSE cur3
  DEALLOCATE cur3
END