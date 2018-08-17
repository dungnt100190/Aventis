/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: (Re)Creates the LOV "<LOVName>" by adding its entries to dbo.XLOV and dbo.XLOVCode
-------------------------------------------------------------------------------------------------
  TEST:    EXEC dbo.LOV '<LOVName>';
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
SET @LOVName = 'Leistungsart';

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
         Description  = 'Leistungsart bfs',
         System       = 1,
         Expandable   = 0,
         ModulID      = -1,
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
         Text        = 'Regulärer Fall ohne Zielvereinbarung',
         SortKey     = 1,
         ShortText   = '',
         BFSCode     = 1,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'S',
         Description = NULL,
         System      = 1,
         LOVCodeName = ''
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 2,
         Text        = 'Regulärer Fall mit Zielvereinbarung',
         SortKey     = 2,
         ShortText   = '',
         BFSCode     = 2,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'S',
         Description = NULL,
         System      = 1,
         LOVCodeName = '';
  
  SELECT LOVName     = @LOVName,
         Code        = 2,
         Text        = 'Kantonale Beihilfen zur Altersrente',
         SortKey     = 35,
         ShortText   = '',
         BFSCode     = 35,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'S',
         Description = NULL,
         System      = 1,
         LOVCodeName = '';
  
  SELECT LOVName     = @LOVName,
         Code        = 2,
         Text        = 'Kantonale Beihilfen zur Invalidentrente',
         SortKey     = 36,
         ShortText   = '',
         BFSCode     = 36,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'S',
         Description = NULL,
         System      = 1,
         LOVCodeName = '';
  
  SELECT LOVName     = @LOVName,
         Code        = 2,
         Text        = 'Kantonale Beihilfen zur Hinterlassenenrente',
         SortKey     = 37,
         ShortText   = '',
         BFSCode     = 37,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'S',
         Description = NULL,
         System      = 1,
         LOVCodeName = '';

-- info
PRINT ('Info: Created LOV "' + @LOVName + '" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO