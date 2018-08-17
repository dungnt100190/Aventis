SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE spDropObject fnStringReplace5
GO
/*===============================================================================================
  $Author: Peter Salajan $
  $Revision: 1 $
=================================================================================================
  Description: Replaces {0} - {4} in a given varchar 
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  @OriginalString Original value 
  @Value0 replacement value 1
  @Value1 replacement value 2
  @Value2 replacement value 3
  @Value3 replacement value 4
  @Value4 replacement value 5
  -
  RETURNS: the replaced varchar
  -
=================================================================================================
   TEST:  SELECT dbo.fnStringReplace5('1 = {0}, 2 = {1}, 3 = {2}, 4 = {3}, 5 = {4}', '1', '2', '3', '4', '5') 
=================================================================================================*/

CREATE FUNCTION dbo.fnStringReplace5
(
  @OriginalString VARCHAR(MAX),
  @Value0 VARCHAR(100),
  @Value1 VARCHAR(100),
  @Value2 VARCHAR(100),
  @Value3 VARCHAR(100),
  @Value4 VARCHAR(100)
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
 
 IF @Value2 IS NOT NULL
 BEGIN
  SET @TmpString = REPLACE(@TmpString, '{2}', ISNULL(@Value2,''));
 END
  
 IF @Value3 IS NOT NULL
 BEGIN
  SET @TmpString = REPLACE(@TmpString, '{3}', ISNULL(@Value3,''));
 END
 
 IF @Value4 IS NOT NULL
 BEGIN
  SET @TmpString = REPLACE(@TmpString, '{4}', ISNULL(@Value4,''));
 END

RETURN @TmpString;
END;
