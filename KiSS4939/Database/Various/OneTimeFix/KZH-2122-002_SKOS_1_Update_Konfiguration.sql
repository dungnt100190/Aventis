/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Script zur Anpassung der Konfiguration (Task KISS-618)
=================================================================================================*/


DECLARE @Stichtag DATETIME;
SET @Stichtag = '20160501';

-------------------------------------------------------------------------------
-- step 1: System-Konfiguration
-------------------------------------------------------------------------------
EXEC dbo.spAddXConfig @KeyPath = 'System\Sozialhilfe\SKOS2005\GBL\1', 
                      @DatumVon = @Stichtag, 
                      @ValueVar = 986.00, 
                      @ValueCode = 4, 
                      @Description = 'Grundbedarf 1 Person', 
                      @OriginalValue = NULL, 
                      @System = 0 

EXEC dbo.spAddXConfig @KeyPath = 'System\Sozialhilfe\SKOS2005\GBL\2', 
                      @DatumVon = @Stichtag, 
                      @ValueVar = 1509.00, 
                      @ValueCode = 4, 
                      @Description = 'Grundbedarf 2 Personen', 
                      @OriginalValue = NULL, 
                      @System = 0 

EXEC dbo.spAddXConfig @KeyPath = 'System\Sozialhilfe\SKOS2005\GBL\3', 
                      @DatumVon = @Stichtag, 
                      @ValueVar = 1834.00, 
                      @ValueCode = 4, 
                      @Description = 'Grundbedarf 3 Personen', 
                      @OriginalValue = NULL, 
                      @System = 0 

EXEC dbo.spAddXConfig @KeyPath = 'System\Sozialhilfe\SKOS2005\GBL\4', 
                      @DatumVon = @Stichtag, 
                      @ValueVar = 2110.00, 
                      @ValueCode = 4, 
                      @Description = 'Grundbedarf 4 Personen', 
                      @OriginalValue = NULL, 
                      @System = 0 

EXEC dbo.spAddXConfig @KeyPath = 'System\Sozialhilfe\SKOS2005\GBL\5', 
                      @DatumVon = @Stichtag, 
                      @ValueVar = 2386.00, 
                      @ValueCode = 4, 
                      @Description = 'Grundbedarf 5 Personen', 
                      @OriginalValue = NULL, 
                      @System = 0 

EXEC dbo.spAddXConfig @KeyPath = 'System\Sozialhilfe\SKOS2005\GBL\6', 
                      @DatumVon = @Stichtag, 
                      @ValueVar = 2586.00, 
                      @ValueCode = 4, 
                      @Description = 'Grundbedarf 6 Personen', 
                      @OriginalValue = NULL, 
                      @System = 0 

EXEC dbo.spAddXConfig @KeyPath = 'System\Sozialhilfe\SKOS2005\GBL\7', 
                      @DatumVon = @Stichtag, 
                      @ValueVar = 2786.00, 
                      @ValueCode = 4, 
                      @Description = 'Grundbedarf 7 Personen', 
                      @OriginalValue = NULL, 
                      @System = 0 

EXEC dbo.spAddXConfig @KeyPath = 'System\Sozialhilfe\SKOS2005\GBL_PerPerson', 
                      @DatumVon = @Stichtag, 
                      @ValueVar = 200.00, 
                      @ValueCode = 4, 
                      @Description = 'Grundbedarf pro weitere Person', 
                      @OriginalValue = NULL, 
                      @System = 0 
PRINT ('Info: System-Konfiguration angepasst');


-------------------------------------------------------------------------------
-- step 2: Positionsarten als "inaktiv" markieren (in sämtlichen vorhandenen Kategorien: Ausgabe, Einnahme, ZL, usw.):
--           - 380 MIZ ab 25 Jahren 
--           - 381 MIZ 16-25 Jahre
-------------------------------------------------------------------------------
-- Skript R4744_KZH-2087_LOV.sql (im Branch 4.7.41) muss vorher ausgeführt werden
UPDATE POA 
  SET BgKategorieCode = BgKategorieCode + 10000
FROM dbo.BgPositionsart POA WITH (READUNCOMMITTED)
  INNER JOIN dbo.BgKostenart KOA WITH (READUNCOMMITTED) ON KOA.BgKostenartID = POA.BgKostenartID
WHERE KOA.KontoNr IN ('380', '381')
PRINT ('Info: Positionsarten von KOAs 380 und 381 als "inaktiv" markiert');


-------------------------------------------------------------------------------
-- step 3: Werteliste "WhGrundbedarfTyp" anpassen: Text bei XLOVCode für LA 110
--         neu: "LA 110 SKOS 2005 / 2011 / 2013 / 2016 (gültig ab 01.05.2016)"
-------------------------------------------------------------------------------
UPDATE LOC 
  SET [Text] = 'LA 110 SKOS 2005 / 2011 / 2013 / 2016 (gültig ab 01.05.2016)'
FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
WHERE LOVName = 'WhGrundbedarfTyp'
  AND Code = 32015
PRINT ('Info: Werteliste "WhGrundbedarfTyp" angepasst. Text bei XLOVCode für LA 110 = "LA 110 SKOS 2005 / 2011 / 2013 / 2016 (gültig ab 01.05.2016)"');