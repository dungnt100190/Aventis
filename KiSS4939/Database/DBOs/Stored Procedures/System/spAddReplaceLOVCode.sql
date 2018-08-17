SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spAddReplaceLOVCode;
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

CREATE PROCEDURE dbo.spAddReplaceLOVCode
(
  @LOVName VARCHAR(100),
  @Code INT,
  @Text VARCHAR(200),
  @SortKey VARCHAR(100),
  @ShortText VARCHAR(20) = NULL
)
AS 
BEGIN
  EXECUTE dbo.spAddReplaceLOVCodeExt @LOVName, @Code, @Text, @SortKey, @ShortText, NULL, NULL, NULL, NULL, NULL, 1;
END;
GO
