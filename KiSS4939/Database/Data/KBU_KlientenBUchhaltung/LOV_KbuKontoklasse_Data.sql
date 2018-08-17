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
            WHERE LOVName = 'KbuKontoklasse'))
BEGIN
  DELETE LOC
  FROM dbo.XLOVCode LOC
  WHERE LOC.LOVName = 'KbuKontoklasse';
  
  DELETE LOV
  FROM dbo.XLOV LOV
  WHERE LOV.LOVName = 'KbuKontoklasse';
  
  PRINT ('Info: Deleted LOV "KbuKontoklasse" with its codes');
END;
GO

-------------------------------------------------------------------------------
-- create the data in XLOV
-------------------------------------------------------------------------------
INSERT INTO dbo.XLOV (LOVName, Description, System, Expandable, ModulID, LastUpdated, 
                      NameValue1, NameValue2, NameValue3, Translatable)
  SELECT LOVName      = 'KbuKontoklasse',
         Description  = 'Beschreibt die Klasse eines Kontos (Aufwand, Ertrag...)',
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
  SELECT LOVName     = 'KbuKontoklasse',
         Code        = 1,
         Text        = 'Aktiven',
         SortKey     = 1,
         ShortText   = 'Ak',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = 'Das Konto ist ein Aktivkonto.',
         System      = 1,
         LOVCodeName = 'Aktiven'

  UNION ALL
  
  -- Code 2
  SELECT LOVName     = 'KbuKontoklasse',
         Code        = 2,
         Text        = 'Passiven',
         SortKey     = 2,
         ShortText   = 'Pa',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = 'Das Konto ist ein Passivkonto.',
         System      = 1,
         LOVCodeName = 'Passiven'
		 
  UNION ALL

  -- Code 3
  SELECT LOVName     = 'KbuKontoklasse',
         Code        = 3,
         Text        = 'Aufwand',
         SortKey     = 3,
         ShortText   = 'Au',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = 'Das Konto ist ein Aufwandkonto.',
         System      = 1,
         LOVCodeName = 'Aufwand'

  UNION ALL
  
  -- Code 4
  SELECT LOVName     = 'KbuKontoklasse',
         Code        = 4,
         Text        = 'Ertrag',
         SortKey     = 4,
         ShortText   = 'Er',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = 'Das Konto ist ein Ertragskonto.',
         System      = 1,
         LOVCodeName = 'Ertrag';
  

-- info
PRINT ('Info: Created LOV "KbuKontoklasse" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO