﻿/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Updates the LOV "TaskType" by adding entries into dbo.XLOVCode
-------------------------------------------------------------------------------------------------
  TEST:    EXEC dbo.LOV 'TaskType';
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- get the LOVID
-------------------------------------------------------------------------------
DECLARE @LOVName VARCHAR(100);
SET @LOVName = 'TaskType';

DECLARE @LOVID INT
SELECT @LOVID = XLOVID FROM dbo.XLOV
WHERE LOVName = @LOVName;

-------------------------------------------------------------------------------
-- create the data in XLOVCode
-------------------------------------------------------------------------------
INSERT INTO dbo.XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3,
                          Description, System, LOVCodeName)
  SELECT XLOVID = @LOVID,
         LOVName     = @LOVName,
         Code        = 19,
         Text        = 'Kind wird 1-jährig',
         SortKey     = 19,
         ShortText   = NULL,
         BFSCode     = NULL,
         Value1      = 'Kind erreicht am {0} das erste Altersjahr.',
         Value2      = 'Anmeldung Primano prüfen',
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = NULL
 
-- info
PRINT ('Info: Inserted LOV "' + @LOVName + '" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO