/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: (Re)Creates the LOV "KbuKontoklasse" by adding its entries to dbo.XLOV and dbo.XLOVCode
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
            WHERE LOVName = 'KbuTransferlaufStatus'))
BEGIN
  DELETE LOC
  FROM dbo.XLOVCode LOC
  WHERE LOC.LOVName = 'KbuTransferlaufStatus';
  
  DELETE LOV
  FROM dbo.XLOV LOV
  WHERE LOV.LOVName = 'KbuTransferlaufStatus';
  
  PRINT ('Info: Deleted LOV "KbuTransferlaufStatus" with its codes');
END;
GO

-------------------------------------------------------------------------------
-- create the data in XLOV
-------------------------------------------------------------------------------
INSERT INTO dbo.XLOV (LOVName, Description, System, Expandable, ModulID, LastUpdated, 
                      NameValue1, NameValue2, NameValue3, Translatable)
  SELECT LOVName      = 'KbuTransferlaufStatus',
         Description  = 'Zustand eines Transferlaufs',
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
  SELECT LOVName     = 'KbuTransferlaufStatus',
         Code        = 1,
         Text        = 'Erstellt',
         SortKey     = 1,
         ShortText   = 'Neu',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = 'Transferlauf wurde angelegt, aber noch nicht gestartet',
         System      = 1,
         LOVCodeName = 'Created'

  UNION ALL
  
  -- Code 2
  SELECT LOVName     = 'KbuTransferlaufStatus',
         Code        = 2,
         Text        = 'Transfer läuft',
         SortKey     = 2,
         ShortText   = 'Tra',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = 'Belege werden transferiert',
         System      = 1,
         LOVCodeName = 'Running'

  UNION ALL
  
  -- Code 3
  SELECT LOVName     = 'KbuTransferlaufStatus',
         Code        = 3,
         Text        = 'Abgebrochen',
         SortKey     = 3,
         ShortText   = 'Abg',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = 'Transfer wurde abgebrochen (dies ist ein Endzustand)',
         System      = 1,
         LOVCodeName = 'Cancelled'

  UNION ALL

  -- Code 4
  SELECT LOVName     = 'KbuTransferlaufStatus',
         Code        = 4,
         Text        = 'Durchgeführt',
         SortKey     = 4,
         ShortText   = 'OK',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = 'Transfer wurde durchgeführt (dies ist ein Endzustand)',
         System      = 1,
         LOVCodeName = 'Done';

-- info
PRINT ('Info: Created LOV "KbuTransferlaufStatus" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO