/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: (Re)Creates the LOV "KbuAuszahlungArt" by adding its entries to dbo.XLOV and dbo.XLOVCode
-------------------------------------------------------------------------------------------------
  TEST:    EXEC dbo.LOV 'KbuAuszahlungArt';
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
SET @LOVName = 'KbuAuszahlungArt';

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
         Description  = 'Auszahlungsart eines Beleges innerhalb der Klientenbuchhaltung',
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
         Text        = 'Elektronische Auszahlung',
         SortKey     = 1,
         ShortText   = 'Elektr.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'ZH',
         Description = NULL,
         System      = 1,
         LOVCodeName = 'ElektronischeAuszahlung'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 2,
         Text        = 'Papierverfügung',
         SortKey     = 2,
         ShortText   = 'Pap.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'Papierverfuegung'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 3,
         Text        = 'Cash / Barauszahlung',
         SortKey     = 3,
         ShortText   = 'Bar',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = 'ZH',
         Description = NULL,
         System      = 1,
         LOVCodeName = 'CashBarauszahlung'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 4,
         Text        = 'Check',
         SortKey     = 4,
         ShortText   = 'Check',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'Check'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 5,
         Text        = 'Interne Verrechnung',
         SortKey     = 5,
         ShortText   = 'Int. V.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'InterneVerrechnung'
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 6,
         Text        = 'SIL-Antrag',
         SortKey     = 6,
         ShortText   = 'SIL-A.',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = 'SILAntrag';

-- info
PRINT ('Info: Created LOV "' + @LOVName + '" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO