/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: (Re)Creates the LOV "WshBewilligungStatus" by adding its entries to dbo.XLOV and dbo.XLOVCode
-------------------------------------------------------------------------------------------------
  TEST:    EXEC dbo.LOV 'WshBewilligungStatus';
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
SET @LOVName = 'WshBewilligungStatus';

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
         Description  = 'Bewilligungsstatus der WSH Budget-Position',
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
         Text        = 'In Vorbereitung',
         SortKey     = 1,
         ShortText   = 'In V.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'InVorbereitung'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 2,
         Text        = 'Bewilligung abgelehnt',
         SortKey     = 2,
         ShortText   = 'Bew. abgel.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'BewilligungAbgelehnt'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 3,
         Text        = 'Bewilligung angefragt',
         SortKey     = 3,
         ShortText   = 'Bew. angefr.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'BewilligungAngefragt'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 5,
         Text        = 'Bewilligung erteilt',
         SortKey     = 5,
         ShortText   = 'Bew. ert.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'BewilligungErteilt'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 9,
         Text        = 'Gesperrt',
         SortKey     = 9,
         ShortText   = 'Gesp.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'Gesperrt';

-- info
PRINT ('Info: Created LOV "' + @LOVName + '" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO