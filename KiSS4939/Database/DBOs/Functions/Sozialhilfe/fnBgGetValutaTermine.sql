SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBgGetValutaTermine
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
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnBgGetValutaTermine
 (@BgAuszahlungPersonID int)
RETURNS varchar(500)
AS BEGIN
DECLARE   @ValutaTermine varchar(500),
          @Datum datetime

  DECLARE C CURSOR FOR
  SELECT Datum FROM dbo.BgAuszahlungPersonTermin WITH (READUNCOMMITTED) WHERE BgAuszahlungPersonID = @BgAuszahlungPersonID ORDER BY Datum

  SET @ValutaTermine = ''

  OPEN C
  FETCH NEXT FROM C INTO @Datum
  WHILE @@fetch_status = 0 BEGIN
    IF @ValutaTermine <> '' SET @ValutaTermine = @ValutaTermine + '  '  -- 2 leerschläge
    SET @ValutaTermine = @ValutaTermine + CONVERT(varchar,day(@Datum)) + '.' + CONVERT(varchar,month(@Datum))
    FETCH NEXT FROM C INTO @Datum
  END
  CLOSE C
  DEALLOCATE C

  RETURN @ValutaTermine
END
GO