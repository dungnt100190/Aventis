SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject LOV;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Show LOVCode entries for LIKE matching search value
    @LOVSerachValue: The search name for any LOVName containing the name
  -
  RETURNS: Table of matching entries within table LOVCode
=================================================================================================
  TEST:    LOV Modul
=================================================================================================*/

CREATE PROCEDURE dbo.LOV
(
  @SearchLOVName VARCHAR(50)
)
AS
BEGIN
  SELECT LOVName, 
         Code, 
         Text, 
         TextTID, 
         SortKey, 
         ShortText, 
         ShortTextTID, 
         BFSCode, 
         Value1, 
         Value1TID, 
         Value2, 
         Value2TID, 
         Value3, 
         Value3TID, 
         Description,
         LOVCodeName,
         IsActive,
         System, 
         XLOVCodeTS
  FROM dbo.XLOVCode WITH (READUNCOMMITTED) 
  WHERE LOVName LIKE '%' + @SearchLOVName + '%'
  ORDER BY LOVName, SortKey;
END;
