
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: (Re)Creates the LOV "KbuProzessart" by adding its entries to dbo.XLOV and dbo.XLOVCode
-------------------------------------------------------------------------------------------------
  TEST:    EXEC dbo.LOV 'KbuProzessart';
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
SET @LOVName = 'KbuProzessart';

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
         Description  = 't.b.d.',
         System       = 1,
         Expandable   = 0,
         ModulID      = 117, -- KBU
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
         Text        = 'WSH',
         SortKey     = 1,
         ShortText   = 'WSH',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'WSH'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 2,
         Text        = 'WV',
         SortKey     = 2,
         ShortText   = 'WV',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'WV'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 3,
         Text        = 'Inkasso',
         SortKey     = 3,
         ShortText   = 'Ink.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'Inkasso'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 4,
         Text        = 'Rückläufer',
         SortKey     = 4,
         ShortText   = 'R.L.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'RueckLaeufer'  

-- info
PRINT ('Info: Created LOV "' + @LOVName + '" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO