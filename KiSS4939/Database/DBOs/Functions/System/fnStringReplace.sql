SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE spDropObject fnStringReplace
GO
/*===============================================================================================
  $Author: Peter Salajan $
  $Revision: 1 $
=================================================================================================
  Description: Replaces {0} in a given varchar 
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  @OriginalString Original value 
  @Value0 replacement value 1
  -
  RETURNS: the replaced varchar
  -
=================================================================================================
   TEST:  SELECT dbo.fnStringReplace('1 = {0}', '1') 
=================================================================================================*/

CREATE FUNCTION dbo.fnStringReplace
(
  @OriginalString VARCHAR(MAX),
  @Value0 VARCHAR(100)
)
RETURNS VARCHAR(MAX) 
AS 
BEGIN
DECLARE @TmpString VARCHAR(MAX) 
 
 IF @Value0 IS NOT NULL
 BEGIN
 SET @TmpString = REPLACE(@OriginalString, '{0}', ISNULL(@Value0,''));
 END

RETURN @TmpString;
END;
