SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE spDropObject fnStringReplace2
GO
/*===============================================================================================
  $Author: Peter Salajan $
  $Revision: 1 $
=================================================================================================
  Description: Replaces {0} - {1} in a given varchar 
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  @OriginalString Original value 
  @Value0 replacement value 1
  @Value1 replacement value 2
  -
  RETURNS: the replaced varchar
  -
=================================================================================================
   TEST:  SELECT dbo.fnStringReplace2('1 = {0}, 2 = {1}', '1', '2') 
=================================================================================================*/

CREATE FUNCTION dbo.fnStringReplace2
(
  @OriginalString VARCHAR(MAX),
  @Value0 VARCHAR(100),
  @Value1 VARCHAR(100)
)
RETURNS VARCHAR(MAX) 
AS 
BEGIN
DECLARE @TmpString VARCHAR(MAX) 
 
 IF @Value0 IS NOT NULL
 BEGIN
 SET @TmpString = REPLACE(@OriginalString, '{0}', ISNULL(@Value0,''));
 END
 
 IF @Value1 IS NOT NULL
 BEGIN
  SET @TmpString = REPLACE(@TmpString, '{1}', ISNULL(@Value1,''));
 END

RETURN @TmpString;
END;
