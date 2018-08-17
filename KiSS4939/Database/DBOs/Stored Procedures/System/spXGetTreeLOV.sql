SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXGetTreeLOV;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spXGetTreeLOV
AS
BEGIN
  DECLARE @IdPerson INT;
  DECLARE @Name VARCHAR(50);
  DECLARE @Age INT;
  DECLARE @Relation VARCHAR(30);
  DECLARE @TreeId VARCHAR(20);
  
  CREATE TABLE #tmp
  (
    ID VARCHAR(100),
    ParentID VARCHAR(100),
    Type VARCHAR(10),
    Name VARCHAR(100),
    LOVName VARCHAR(100),
    ModulID INT,
    IconID INT
  );
  
  -- Modul
  INSERT #tmp
    SELECT 'M' + CONVERT(VARCHAR,Code),
           '',
           'M',
           Text,
           Text,
           Code,
           Code
    FROM dbo.XLOVCode WITH (READUNCOMMITTED)
    WHERE LOVName = 'Modul'
    ORDER BY SortKey;
  
  -- LOV's
  INSERT #tmp
    SELECT 'L' + LOVName,
           'M' + CONVERT(VARCHAR, CASE 
                                    WHEN ModulID BETWEEN 0 AND 6 THEN ModulID
                                    ELSE 0
                                  END),
           'L',
           LOVName,
           LOVName,
           CASE 
             WHEN ModulID BETWEEN 0 AND 6 THEN ModulID
             ELSE 0
           END,
           7
    FROM dbo.XLOV WITH (READUNCOMMITTED);
  
  SELECT * 
  FROM #tmp 
  ORDER BY ModulID, Type DESC, Name;
END;
GO