/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: (Re)Creates the LOV "WshPeriodizitaet" by adding its entries to dbo.XLOV and dbo.XLOVCode
           Formerly known as WshAuszahlungTermin
-------------------------------------------------------------------------------------------------
  TEST:    EXEC dbo.LOV 'WshPeriodizitaet';
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- drop the LOV if existing
-------------------------------------------------------------------------------
DECLARE @LOVName VARCHAR(100);
SET @LOVName = 'WshPeriodizitaet';

IF (EXISTS (SELECT TOP 1 1
            FROM dbo.XLOV
            WHERE LOVName = @LOVName))
BEGIN
  DELETE LOC
  FROM dbo.XLOVCode LOC
  WHERE LOC.LOVName = @LOVName;
  
  DELETE LOV
  FROM dbo.XLOV LOV
  WHERE LOV.LOVName = @LOVName;
  
  PRINT ('Info: Deleted LOV "' + @LOVName + '" with its codes');
END;

-------------------------------------------------------------------------------
-- create the data in XLOV
-------------------------------------------------------------------------------
INSERT INTO dbo.XLOV (LOVName, Description, System, Expandable, ModulID, LastUpdated, 
                      NameValue1, NameValue2, NameValue3, Translatable)
  SELECT LOVName      = @LOVName,
         Description  = 'Gewünschte Periodizität für die Auszahlungen',
         System       = 1,
         Expandable   = 0,
         ModulID      = 103,
         LastUpdated  = GETDATE(),
         NameValue1   = NULL,
         NameValue2   = NULL,
         NameValue3   = NULL,
         Translatable = 1;

-------------------------------------------------------------------------------
-- create the data in XLOVCode
-------------------------------------------------------------------------------
INSERT INTO dbo.XLOVCode (LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3,
                          Description, System, LOVCodeName)
  SELECT LOVName     = @LOVName,
         Code        = 1,
         Text        = '1x pro Monat',
         SortKey     = 1,
         ShortText   = '1x p.M.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'ZH,M', --Ein M, da es pro Monat genau eine Monatsposition erzeugt beim Übertrag vom GB in MBs
         Description = NULL,
         System      = 1,
         LOVCodeName = '1xProMonat'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 2,
         Text        = '2x pro Monat',
         SortKey     = 2,
         ShortText   = '2x p.M.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'ZH,M', --Ein M, da es pro Monat genau eine Monatsposition erzeugt beim Übertrag vom GB in MBs
         Description = NULL,
         System      = 1,
         LOVCodeName = '2xProMonat'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 3,
         Text        = 'Wöchentlich',
         SortKey     = 3,
         ShortText   = 'Wl.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'ZH,M', --Ein M, da es pro Monat genau eine Monatsposition erzeugt beim Übertrag vom GB in MBs
         Description = NULL,
         System      = 1,
         LOVCodeName = 'Woechentlich'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 4,
         Text        = 'Valuta',
         SortKey     = 4,
         ShortText   = 'Val.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'ZH,Einnahme,M', --Ein M, da es pro Monat genau eine Monatsposition erzeugt beim Übertrag vom GB in MBs
         Description = NULL,
         System      = 1,
         LOVCodeName = 'Valuta'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 5,
         Text        = '14-täglich',
         SortKey     = 5,
         ShortText   = '14-Tgl.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = '14Taeglich'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 6,
         Text        = 'Wochentage',
         SortKey     = 6,
         ShortText   = 'WT.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'Wochentage'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 7,
         Text        = 'Quartal',
         SortKey     = 7,
         ShortText   = 'Quart.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'ZH,Einnahme',
         Description = NULL,
         System      = 1,
         LOVCodeName = 'Quartal'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 8,
         Text        = 'Semester',
         SortKey     = 8,
         ShortText   = 'Sem.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'ZH,Einnahme',
         Description = NULL,
         System      = 1,
         LOVCodeName = 'Semester'
  /*
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 99,
         Text        = 'Individuell', -- since #7472-016 no more needed
         SortKey     = 99,
         ShortText   = 'Ind.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'Individuell'
  */

-- info
PRINT ('Info: Created LOV "' + @LOVName + '" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO