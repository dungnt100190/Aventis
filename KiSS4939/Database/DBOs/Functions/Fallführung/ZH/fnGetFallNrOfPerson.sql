SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetFallNrOfPerson
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnGetFallNrOfPerson(@BaPersonID int)
RETURNS varchar(4000)
AS
BEGIN
  DECLARE @List varchar(2000)
  DECLARE @Text varchar(200)
  SET @List = ''

  DECLARE C CURSOR FOR
  SELECT FaFallID FROM dbo.FaFall WITH (READUNCOMMITTED) WHERE BaPersonID = @BaPersonID
  ORDER BY DatumVon DESC

  OPEN C
  FETCH NEXT FROM C INTO @Text
  WHILE @@fetch_status = 0 BEGIN
    IF len(IsNull(@Text,'')) > 0 BEGIN
      IF @List <> '' SET @List = @List + ','
      SET @List = @List + @Text
    END
    FETCH NEXT FROM C INTO @Text
  END
  CLOSE C
  DEALLOCATE C

  RETURN @List
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
