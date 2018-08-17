SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spAddReplaceLOV;
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

CREATE PROCEDURE dbo.spAddReplaceLOV
(
  @LOVName VARCHAR(100),
  @ModulID INT = NULL
)
AS 
BEGIN
  EXECUTE spAddReplaceLOVExt @LOVName, NULL, 1, 0, @ModulID;
END;
GO
