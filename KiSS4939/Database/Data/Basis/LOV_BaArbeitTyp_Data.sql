﻿/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: (Re)Creates the LOV "BaArbeitTyp" by adding its entries to dbo.XLOV and dbo.XLOVCode
-------------------------------------------------------------------------------------------------
  TEST:    EXEC dbo.LOV 'BaArbeitTyp';
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
SET @LOVName = 'BaArbeitTyp';

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
         Description  = '',
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
         Text        = 'Erwerbsarbeit',
         SortKey     = 1,
         ShortText   = '',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = ''
  
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 2,
         Text        = 'Beschäftigungsprogramm',
         SortKey     = 2,
         ShortText   = '',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = ''
         
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 3,
         Text        = 'Integrationsprojekt',
         SortKey     = 3,
         ShortText   = '',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = ''
         
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 4,
         Text        = 'Sprachkurs',
         SortKey     = 4,
         ShortText   = '',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = ''
         
       
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 5,
         Text        = 'Ausbildung mit Stipendium',
         SortKey     = 5,
         ShortText   = '',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = ''     
         
       
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 6,
         Text        = 'Ausbildung ohne Stipendium',
         SortKey     = 6,
         ShortText   = '',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = ''      
         
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 7,
         Text        = 'Arbeitslosen-Taggelder',
         SortKey     = 7,
         ShortText   = '',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = ''                                            
         
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 8,
         Text        = 'Gemeinnützige Arbeit',
         SortKey     = 8,
         ShortText   = '',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = ''   
         
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 9,
         Text        = 'Praktikum',
         SortKey     = 9,
         ShortText   = '',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = ''    
         
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 10,
         Text        = 'Stellensucherprogramm',
         SortKey     = 10,
         ShortText   = '',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = ''         
         
  UNION ALL
  
  SELECT LOVName     = @LOVName,
         Code        = 11,
         Text        = 'Weiteres',
         SortKey     = 11,
         ShortText   = '',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = ''                                                            
                  

-- info
PRINT ('Info: Created LOV "' + @LOVName + '" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO