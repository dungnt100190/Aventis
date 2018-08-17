/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: (Re)Creates the LOV "KbuBelegstatus" by adding its entries to dbo.XLOV and dbo.XLOVCode
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps 
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- drop the LOV if existing
-------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM dbo.XLOV
            WHERE LOVName = 'KbuBelegstatus'))
BEGIN
  DELETE LOC
  FROM dbo.XLOVCode LOC
  WHERE LOC.LOVName = 'KbuBelegstatus';
  
  DELETE LOV
  FROM dbo.XLOV LOV
  WHERE LOV.LOVName = 'KbuBelegstatus';
  
  PRINT ('Info: Deleted LOV "KbuBelegstatus" with its codes');
END;
GO

-------------------------------------------------------------------------------
-- create the data in XLOV
-------------------------------------------------------------------------------
INSERT INTO dbo.XLOV (LOVName, Description, System, Expandable, ModulID, LastUpdated, 
                      NameValue1, NameValue2, NameValue3, Translatable)
  SELECT LOVName      = 'KbuBelegstatus',
         Description  = 'Beschreibt die möglichen Stati eines Belegs',
         System       = 1,
         Expandable   = 0,
         ModulID      = 117,
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
  -- Code 1
  SELECT LOVName     = 'KbuBelegstatus',
         Code        = 1,
         Text        = 'Vorschlag',
         SortKey     = 1,
         ShortText   = 'Vo',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = 'Der Beleg ist nur ein Vorschlag',
         System      = 1,
         LOVCodeName = 'Vorschlag'

  UNION ALL
  
  -- Code 2
  SELECT LOVName     = 'KbuBelegstatus',
         Code        = 2,
         Text        = 'Freigegeben',
         SortKey     = 2,
         ShortText   = 'Fg',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = 'Der Beleg ist freigegeben.',
         System      = 1,
         LOVCodeName = 'Freigegeben'

  UNION ALL
  
  -- Code 3
  SELECT LOVName     = 'KbuBelegstatus',
         Code        = 3,
         Text        = 'Verbucht',
         SortKey     = 3,
         ShortText   = 'Vb',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = 'Der Beleg ist verbucht.',
         System      = 1,
         LOVCodeName = 'Verbucht'

  
 

-- info
PRINT ('Info: Created LOV "KbuBelegstatus" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO